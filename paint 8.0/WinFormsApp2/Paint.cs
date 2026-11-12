using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Paint : Form
    {
        private enum ToolType { Pencil, Eraser, Line, Curve, Rectangle, Ellipse, Fill, Text, Triangle, Diamond, Star, Picker, Select }

        private ToolType _currentTool = ToolType.Pencil;
        private Color _primaryColor = Color.Red, _secondaryColor = Color.White, _activeDrawColor = Color.Red;
        private int _penSize = 3;
        private bool _isShapeFilled, _showGrid, _isFullScreen, _isDrawing, _isSelecting;
        private float _zoom = 1f;
        private Bitmap _bitmap = null!;
        private Graphics _graphics = null!;
        private Point _startPoint, _lastPoint;
        private Bitmap? _backupBitmap, _clipboardBitmap;
        private Rectangle _selectionRect = Rectangle.Empty;
        private const int MaxUndo = 30;
        private readonly List<Bitmap> _undoStack = new(), _redoStack = new();
        private readonly List<Point> _curvePoints = new();

        public Paint() { InitializeComponent(); DoubleBuffered = true; }

        private void Paint_Load(object? sender, EventArgs e)
        {
            Text = "Paint";
            WindowState = FormWindowState.Maximized;
            panelCanvasContainer.AutoScroll = true;
            panelCanvasContainer.Dock = DockStyle.Fill;
            UpdateColorButtonUI();
            UpdatePenSizeButton();
            CreateNewCanvas(1200, 800);
            KeyPreview = true;
            KeyDown += Paint_KeyDown;
        }

        private void ColorButton_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sender is not Button btn) return;
            if (e.Button == MouseButtons.Right) _secondaryColor = btn.BackColor;
            else _primaryColor = btn.BackColor;
            UpdateColorButtonUI();
        }

        private void UpdateColorButtonUI()
        {
            btnColor1.BackColor = _primaryColor;
            btnColor1.ForeColor = _primaryColor.GetBrightness() < 0.5 ? Color.White : Color.Black;
            btnColor1.Text = "Цвет 🎨";
            btnColor2.BackColor = _secondaryColor;
        }

        private void UpdatePenSizeButton()
        {
            btnPenSize.Text = "Толщина ▼";
            var bmp = new Bitmap(60, 24);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);
                using var p = new Pen(Color.Black, Math.Min(_penSize, 15));
                g.DrawLine(p, 5, 12, 55, 12);
            }
            btnPenSize.Image = bmp;
            btnPenSize.ImageAlign = ContentAlignment.MiddleRight;
        }

        private void btnPenSize_Click(object? sender, EventArgs e)
        {
            var menu = new ContextMenuStrip { ShowImageMargin = false, ShowCheckMargin = false };
            foreach (int size in new[] { 1, 2, 3, 5, 8, 12, 16, 24, 32 })
            {
                var item = new ToolStripMenuItem { AutoSize = false, Size = new Size(200, 35), Padding = new Padding(0) };
                item.Paint += (s, pe) =>
                {
                    var mi = (ToolStripMenuItem)s!;
                    pe.Graphics.FillRectangle(mi.Selected ? new SolidBrush(Color.FromArgb(200, 220, 240)) : Brushes.White, mi.ContentRectangle);
                    using var p = new Pen(Color.Black, Math.Min(size, 20)) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                    pe.Graphics.DrawLine(p, 5, mi.Height / 2, mi.Width - 5, mi.Height / 2);
                };
                item.Click += (s, ev) => { _penSize = size; UpdatePenSizeButton(); };
                menu.Items.Add(item);
            }
            menu.Show(btnPenSize, new Point(0, btnPenSize.Height));
        }

        private void CreateNewCanvas(int width, int height)
        {
            foreach (var b in _undoStack) b.Dispose();
            foreach (var b in _redoStack) b.Dispose();
            _undoStack.Clear();
            _redoStack.Clear();
            _graphics?.Dispose();
            var old = _bitmap;
            _bitmap = new Bitmap(width, height);
            pictureBox.Image = _bitmap;
            old?.Dispose();
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            _graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _selectionRect = Rectangle.Empty;

            int aw = Math.Max(panelCanvasContainer.ClientSize.Width - 100, 1000);
            int ah = Math.Max(panelCanvasContainer.ClientSize.Height - 100, 800);
            ChangeZoom(Math.Max(0.2f, Math.Min(1f, Math.Min((float)aw / width, (float)ah / height))));
            UpdateThumbnail();
            pictureBox.Invalidate();
        }

        private void btnTabFile_Click(object? sender, EventArgs e)
        {
            var saveAs = new ToolStripMenuItem("Сохранить как");
            saveAs.DropDownItems.Add("Изображение PNG...", null, btnSave_Click);
            saveAs.DropDownItems.Add("Изображение JPEG...", null, btnSave_Click);
            var print = new ToolStripMenuItem("Печать");
            print.DropDownItems.Add("Печать...", null, (s, ev) => Print(false));
            print.DropDownItems.Add("Предварительный просмотр", null, (s, ev) => Print(true));

            var menu = new ContextMenuStrip();
            menu.Items.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem("Создать", null, (s, ev) => CreateNewCanvas(1200, 800)) { ShortcutKeyDisplayString = "Ctrl+N" },
                new ToolStripMenuItem("Открыть", null, btnOpen_Click) { ShortcutKeyDisplayString = "Ctrl+O" },
                new ToolStripMenuItem("Сохранить", null, btnSave_Click) { ShortcutKeyDisplayString = "Ctrl+S" },
                saveAs,
                new ToolStripMenuItem("Сохранить как проект", null, btnSaveProject_Click) { ShortcutKeyDisplayString = "Ctrl+Shift+S" },
                new ToolStripSeparator(), print, new ToolStripSeparator(),
                new ToolStripMenuItem("Выйти", null, (s, ev) => Close())
            });
            menu.Show(btnTabFile, new Point(0, btnTabFile.Height));
        }

        private void Paint_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N) { CreateNewCanvas(1200, 800); e.Handled = true; }
            else if (e.Control && e.KeyCode == Keys.O) { btnOpen_Click(sender, e); e.Handled = true; }
            else if (e.Control && e.Shift && e.KeyCode == Keys.S) { btnSaveProject_Click(sender, e); e.Handled = true; }
            else if (e.Control && e.KeyCode == Keys.S) { btnSave_Click(sender, e); e.Handled = true; }
            else if (e.Control && e.KeyCode == Keys.P) { Print(false); e.Handled = true; }
        }

        private void btnTabHome_Click(object? s, EventArgs e) => SwitchTab(true);
        private void btnTabView_Click(object? s, EventArgs e) => SwitchTab(false);
        private void SwitchTab(bool isHome)
        {
            panelHomeRibbon.Visible = isHome;
            panelViewRibbon.Visible = !isHome;
            btnTabHome.BackColor = isHome ? Color.FromArgb(230, 230, 230) : Color.White;
            btnTabView.BackColor = isHome ? Color.White : Color.FromArgb(230, 230, 230);
        }

        private void SetTool(ToolType tool, Button? activeButton)
        {
            _currentTool = tool;
            _selectionRect = Rectangle.Empty;
            _curvePoints.Clear();
            foreach (var b in new[] { btnPencil, btnFill, btnText, btnEraser, btnPicker }) b.BackColor = Color.Transparent;
            if (activeButton != null) activeButton.BackColor = Color.FromArgb(200, 220, 240);
            pictureBox.Invalidate();
        }

        private void btnPencil_Click(object? s, EventArgs e) => SetTool(ToolType.Pencil, btnPencil);
        private void btnFill_Click(object? s, EventArgs e) => SetTool(ToolType.Fill, btnFill);
        private void btnText_Click(object? s, EventArgs e) => SetTool(ToolType.Text, btnText);
        private void btnEraser_Click(object? s, EventArgs e) => SetTool(ToolType.Eraser, btnEraser);
        private void btnPicker_Click(object? s, EventArgs e) => SetTool(ToolType.Picker, btnPicker);
        private void btnBrush_Click(object? s, EventArgs e) { SetTool(ToolType.Pencil, btnPencil); _penSize = 15; UpdatePenSizeButton(); }
        private void btnShapeLine_Click(object? s, EventArgs e) => SetTool(ToolType.Line, null);
        private void btnShapeCurve_Click(object? s, EventArgs e) => SetTool(ToolType.Curve, null);
        private void btnShapeEllipse_Click(object? s, EventArgs e) => SetTool(ToolType.Ellipse, null);
        private void btnShapeRect_Click(object? s, EventArgs e) => SetTool(ToolType.Rectangle, null);
        private void btnShapeTriangle_Click(object? s, EventArgs e) => SetTool(ToolType.Triangle, null);
        private void btnShapeDiamond_Click(object? s, EventArgs e) => SetTool(ToolType.Diamond, null);
        private void btnShapeStar_Click(object? s, EventArgs e) => SetTool(ToolType.Star, null);
        private void btnSelect_Click(object? s, EventArgs e) => SetTool(ToolType.Select, null);
        private void btnFillMode_Click(object? s, EventArgs e) { _isShapeFilled = !_isShapeFilled; btnFillMode.Text = _isShapeFilled ? "Заливка ▾" : "Контур ▾"; }

        private void btnColor1_Click(object? s, EventArgs e) => PickColor(true);
        private void btnColor2_Click(object? s, EventArgs e) => PickColor(false);
        private void PickColor(bool primary)
        {
            using var cd = new ColorDialog { Color = primary ? _primaryColor : _secondaryColor };
            if (cd.ShowDialog() != DialogResult.OK) return;
            if (primary) _primaryColor = cd.Color;
            else _secondaryColor = cd.Color;
            UpdateColorButtonUI();
        }

        private void btnCopy_Click(object? s, EventArgs e)
        {
            _clipboardBitmap?.Dispose();
            _clipboardBitmap = _selectionRect != Rectangle.Empty
                ? _bitmap.Clone(_selectionRect, _bitmap.PixelFormat)
                : (Bitmap)_bitmap.Clone();
        }

        private void btnCut_Click(object? s, EventArgs e)
        {
            if (_selectionRect == Rectangle.Empty) return;
            _clipboardBitmap?.Dispose();
            _clipboardBitmap = _bitmap.Clone(_selectionRect, _bitmap.PixelFormat);
            using (var g = Graphics.FromImage(_bitmap)) g.FillRectangle(Brushes.White, _selectionRect);
            pictureBox.Invalidate();
        }

        private void btnPaste_Click(object? s, EventArgs e)
        {
            if (_clipboardBitmap == null) return;
            SaveState();
            using (var g = Graphics.FromImage(_bitmap)) g.DrawImage(_clipboardBitmap, 0, 0);
            pictureBox.Invalidate();
            UpdateThumbnail();
        }

        private void btnCrop_Click(object? s, EventArgs e)
        {
            if (_selectionRect == Rectangle.Empty) return;
            SaveState();
            _bitmap = _bitmap.Clone(_selectionRect, _bitmap.PixelFormat);
            _graphics.Dispose();
            _graphics = Graphics.FromImage(_bitmap);
            pictureBox.Image = _bitmap;
            _selectionRect = Rectangle.Empty;
            ChangeZoom(_zoom);
            UpdateThumbnail();
        }

        private void btnRotate_Click(object? s, EventArgs e)
        {
            SaveState();
            _bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            _graphics.Dispose();
            _graphics = Graphics.FromImage(_bitmap);
            pictureBox.Image = _bitmap;
            ChangeZoom(_zoom);
            pictureBox.Invalidate();
            UpdateThumbnail();
        }

        private void btnResize_Click(object? s, EventArgs e)
        {
            using var prompt = new Form
            {
                Text = "Изменение размеров", Size = new Size(300, 180),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false
            };
            var txtW = new TextBox { Left = 100, Top = 18, Width = 150, Text = _bitmap.Width.ToString() };
            var txtH = new TextBox { Left = 100, Top = 48, Width = 150, Text = _bitmap.Height.ToString() };
            var btnOk = new Button { Text = "ОК", Left = 100, Width = 150, Top = 90, DialogResult = DialogResult.OK };
            prompt.Controls.AddRange(new Control[] {
                new Label { Left = 20, Top = 20, Text = "Ширина:", AutoSize = true }, txtW,
                new Label { Left = 20, Top = 50, Text = "Высота:", AutoSize = true }, txtH, btnOk
            });
            prompt.AcceptButton = btnOk;
            if (prompt.ShowDialog() != DialogResult.OK) return;
            if (!int.TryParse(txtW.Text, out int w) || !int.TryParse(txtH.Text, out int h) || w <= 0 || h <= 0) return;

            SaveState();
            var nb = new Bitmap(w, h);
            using (var g = Graphics.FromImage(nb))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(_bitmap, 0, 0, w, h);
            }
            _graphics.Dispose();
            _bitmap.Dispose();
            _bitmap = nb;
            _graphics = Graphics.FromImage(_bitmap);
            pictureBox.Image = _bitmap;
            ChangeZoom(_zoom);
            UpdateThumbnail();
        }

        private void btnZoomIn_Click(object? s, EventArgs e) => ChangeZoom(_zoom + 0.2f);
        private void btnZoomOut_Click(object? s, EventArgs e) => ChangeZoom(_zoom - 0.2f);
        private void btnZoomReset_Click(object? s, EventArgs e) => ChangeZoom(1f);
        private void ChangeZoom(float newZoom)
        {
            _zoom = Math.Max(0.1f, Math.Min(5f, newZoom));
            pictureBox.Size = new Size((int)(_bitmap.Width * _zoom), (int)(_bitmap.Height * _zoom));
            pictureBox.Location = new Point(20, 20);
            lblCanvasSize.Text = $"{(int)(_bitmap.Width * _zoom)} × {(int)(_bitmap.Height * _zoom)} пикс. (Масштаб {(_zoom * 100):F0}%)";
        }

        private void chkGrid_CheckedChanged(object? s, EventArgs e) { _showGrid = chkGrid.Checked; pictureBox.Invalidate(); }
        private void chkStatus_CheckedChanged(object? s, EventArgs e) => statusStrip.Visible = chkStatus.Checked;

        private void btnFullScreen_Click(object? s, EventArgs e)
        {
            _isFullScreen = !_isFullScreen;
            FormBorderStyle = _isFullScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
            WindowState = _isFullScreen ? FormWindowState.Maximized : FormWindowState.Normal;
            panelViewRibbon.Visible = panelHomeRibbon.Visible = !_isFullScreen;
            panelTabs.Visible = panelQuickAccess.Visible = !_isFullScreen;
            statusStrip.Visible = !_isFullScreen;
        }

        private void btnThumbnail_Click(object? s, EventArgs e)
        {
            pictureBoxThumbnail.Visible = !pictureBoxThumbnail.Visible;
            if (pictureBoxThumbnail.Visible) UpdateThumbnail();
        }

        private void UpdateThumbnail()
        {
            if (!pictureBoxThumbnail.Visible) return;
            var old = pictureBoxThumbnail.Image;
            pictureBoxThumbnail.Image = null;
            old?.Dispose();
            pictureBoxThumbnail.Image = new Bitmap(_bitmap, pictureBoxThumbnail.Size);
        }

        private void pictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) return;
            _activeDrawColor = e.Button == MouseButtons.Left ? _primaryColor : _secondaryColor;
            var dp = new Point((int)(e.X / _zoom), (int)(e.Y / _zoom));
            _startPoint = dp;
            _lastPoint = dp;

            switch (_currentTool)
            {
                case ToolType.Picker:
                    var picked = _bitmap.GetPixel(Math.Clamp(dp.X, 0, _bitmap.Width - 1), Math.Clamp(dp.Y, 0, _bitmap.Height - 1));
                    if (e.Button == MouseButtons.Left) _primaryColor = picked;
                    else _secondaryColor = picked;
                    UpdateColorButtonUI();
                    SetTool(ToolType.Pencil, btnPencil);
                    return;
                case ToolType.Select:
                    _isSelecting = true;
                    _isDrawing = true;
                    _selectionRect = Rectangle.Empty;
                    return;
                case ToolType.Text:
                    ShowTextInput(dp);
                    return;
                case ToolType.Fill:
                    SaveState();
                    int fx = Math.Clamp(dp.X, 0, _bitmap.Width - 1), fy = Math.Clamp(dp.Y, 0, _bitmap.Height - 1);
                    FloodFill(fx, fy, _bitmap.GetPixel(fx, fy), _activeDrawColor);
                    pictureBox.Invalidate();
                    return;
                case ToolType.Pencil:
                case ToolType.Eraser:
                    SaveState();
                    _isDrawing = true;
                    using (var brush = new SolidBrush(_currentTool == ToolType.Eraser ? Color.White : _activeDrawColor))
                    {
                        float r = _penSize / 2f;
                        _graphics.FillEllipse(brush, dp.X - r, dp.Y - r, _penSize, _penSize);
                    }
                    pictureBox.Invalidate();
                    return;
                default:
                    SaveState();
                    _isDrawing = true;
                    _backupBitmap = (Bitmap)_bitmap.Clone();
                    if (_currentTool == ToolType.Curve) { _curvePoints.Clear(); _curvePoints.Add(dp); }
                    return;
            }
        }

        private void pictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            var dp = new Point((int)(e.X / _zoom), (int)(e.Y / _zoom));
            lblCoords.Text = $"{dp.X}, {dp.Y} пикс.";
            if (!_isDrawing) return;

            if (_currentTool == ToolType.Select && _isSelecting)
            {
                _selectionRect = new Rectangle(
                    Math.Min(_startPoint.X, dp.X), Math.Min(_startPoint.Y, dp.Y),
                    Math.Abs(_startPoint.X - dp.X), Math.Abs(_startPoint.Y - dp.Y));
            }
            else if (_currentTool == ToolType.Pencil || _currentTool == ToolType.Eraser)
            {
                using var pen = new Pen(_currentTool == ToolType.Eraser ? Color.White : _activeDrawColor, _penSize)
                    { StartCap = LineCap.Round, EndCap = LineCap.Round };
                _graphics.DrawLine(pen, _lastPoint, dp);
                _lastPoint = dp;
            }
            else if (_currentTool == ToolType.Curve && _backupBitmap != null)
            {
                _curvePoints.Add(dp);
                _graphics.DrawImage(_backupBitmap, 0, 0);
                if (_curvePoints.Count >= 2)
                {
                    using var pen = new Pen(_activeDrawColor, _penSize) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                    _graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    _graphics.DrawCurve(pen, _curvePoints.ToArray(), 0.5f);
                }
            }
            else if (_backupBitmap != null && _currentTool != ToolType.Fill && _currentTool != ToolType.Text && _currentTool != ToolType.Picker)
            {
                _graphics.DrawImage(_backupBitmap, 0, 0);
                DrawShape(_graphics, _startPoint, dp);
            }
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            _isDrawing = false;
            _isSelecting = false;
            _curvePoints.Clear();
            _backupBitmap?.Dispose();
            _backupBitmap = null;
            UpdateThumbnail();
        }

        private void pictureBox_Paint(object? s, PaintEventArgs e)
        {
            if (_showGrid)
            {
                using var pen = new Pen(Color.FromArgb(220, 220, 220));
                int step = Math.Max(1, (int)(20 * _zoom));
                for (int i = 0; i < pictureBox.Width; i += step) e.Graphics.DrawLine(pen, i, 0, i, pictureBox.Height);
                for (int j = 0; j < pictureBox.Height; j += step) e.Graphics.DrawLine(pen, 0, j, pictureBox.Width, j);
            }
            if (_currentTool == ToolType.Select && _selectionRect != Rectangle.Empty)
            {
                using var pen = new Pen(Color.Blue, 1) { DashStyle = DashStyle.Dash };
                e.Graphics.DrawRectangle(pen, (int)(_selectionRect.X * _zoom), (int)(_selectionRect.Y * _zoom),
                    (int)(_selectionRect.Width * _zoom), (int)(_selectionRect.Height * _zoom));
            }
        }

        private void DrawShape(Graphics g, Point p1, Point p2)
        {
            int x = Math.Min(p1.X, p2.X), y = Math.Min(p1.Y, p2.Y);
            int w = Math.Abs(p1.X - p2.X), h = Math.Abs(p1.Y - p2.Y);
            using var pen = new Pen(_activeDrawColor, _penSize);
            using var brush = new SolidBrush(_activeDrawColor);
            void Draw(Action<Pen> outline, Action<Brush> fill) { if (_isShapeFilled) fill(brush); else outline(pen); }

            switch (_currentTool)
            {
                case ToolType.Line: g.DrawLine(pen, p1, p2); break;
                case ToolType.Rectangle: Draw(p => g.DrawRectangle(p, x, y, w, h), b => g.FillRectangle(b, x, y, w, h)); break;
                case ToolType.Ellipse: Draw(p => g.DrawEllipse(p, x, y, w, h), b => g.FillEllipse(b, x, y, w, h)); break;
                case ToolType.Triangle:
                    var tri = new[] { new Point(x + w / 2, y), new Point(x, y + h), new Point(x + w, y + h) };
                    Draw(p => g.DrawPolygon(p, tri), b => g.FillPolygon(b, tri));
                    break;
                case ToolType.Diamond:
                    var dia = new[] { new Point(x + w / 2, y), new Point(x + w, y + h / 2), new Point(x + w / 2, y + h), new Point(x, y + h / 2) };
                    Draw(p => g.DrawPolygon(p, dia), b => g.FillPolygon(b, dia));
                    break;
                case ToolType.Star:
                    var star = new Point[10];
                    double angle = Math.PI / 5;
                    for (int i = 0; i < 10; i++)
                    {
                        int r = i % 2 == 0 ? w / 2 : w / 4;
                        star[i] = new Point(x + w / 2 + (int)(r * Math.Sin(i * angle)), y + h / 2 - (int)(r * Math.Cos(i * angle)));
                    }
                    Draw(p => g.DrawPolygon(p, star), b => g.FillPolygon(b, star));
                    break;
            }
        }

        private void FloodFill(int x, int y, Color target, Color replacement)
        {
            if (target.ToArgb() == replacement.ToArgb()) return;
            var rect = new Rectangle(0, 0, _bitmap.Width, _bitmap.Height);
            if (!rect.Contains(x, y)) return;

            var data = _bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            try
            {
                int tArgb = target.ToArgb(), rArgb = replacement.ToArgb();
                IntPtr basePtr = data.Scan0;
                int stride = data.Stride, w = _bitmap.Width, h = _bitmap.Height;
                var stack = new Stack<Point>();
                stack.Push(new Point(x, y));
                while (stack.Count > 0)
                {
                    var p = stack.Pop();
                    if (p.X < 0 || p.Y < 0 || p.X >= w || p.Y >= h) continue;
                    int offset = p.Y * stride + p.X * 4;
                    if (Marshal.ReadInt32(basePtr, offset) != tArgb) continue;
                    Marshal.WriteInt32(basePtr, offset, rArgb);
                    stack.Push(new Point(p.X + 1, p.Y));
                    stack.Push(new Point(p.X - 1, p.Y));
                    stack.Push(new Point(p.X, p.Y + 1));
                    stack.Push(new Point(p.X, p.Y - 1));
                }
            }
            finally { _bitmap.UnlockBits(data); }
        }

        private void ShowTextInput(Point location)
        {
            var txt = new TextBox
            {
                Location = new Point((int)(location.X * _zoom) + 20, (int)(location.Y * _zoom) + 20),
                Font = new Font("Arial", _penSize * 4),
                ForeColor = _activeDrawColor,
                BackColor = Color.White,
                Width = 200
            };
            pictureBox.Controls.Add(txt);
            txt.Focus();
            bool done = false;

            void Commit(bool save)
            {
                if (done) return;
                done = true;
                if (save && !string.IsNullOrEmpty(txt.Text))
                {
                    SaveState();
                    using (var g = Graphics.FromImage(_bitmap))
                    {
                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        using var br = new SolidBrush(_activeDrawColor);
                        g.DrawString(txt.Text, txt.Font, br, location.X, location.Y);
                    }
                    UpdateThumbnail();
                }
                pictureBox.Controls.Remove(txt);
                txt.Dispose();
                pictureBox.Invalidate();
            }
            txt.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter) { ev.SuppressKeyPress = true; Commit(true); }
                else if (ev.KeyCode == Keys.Escape) Commit(false);
            };
            txt.LostFocus += (s, ev) => Commit(true);
        }

        private void SaveState()
        {
            _undoStack.Add((Bitmap)_bitmap.Clone());
            if (_undoStack.Count > MaxUndo)
            {
                _undoStack[0].Dispose();
                _undoStack.RemoveAt(0);
            }
            foreach (var b in _redoStack) b.Dispose();
            _redoStack.Clear();
        }

        private void btnUndo_Click(object? s, EventArgs e) => Restore(_undoStack, _redoStack);
        private void btnRedo_Click(object? s, EventArgs e) => Restore(_redoStack, _undoStack);
        private void Restore(List<Bitmap> from, List<Bitmap> to)
        {
            if (from.Count == 0) return;
            to.Add((Bitmap)_bitmap.Clone());
            int last = from.Count - 1;
            _graphics.Dispose();
            _bitmap.Dispose();
            _bitmap = from[last];
            from.RemoveAt(last);
            _graphics = Graphics.FromImage(_bitmap);
            pictureBox.Image = _bitmap;
            pictureBox.Invalidate();
            UpdateThumbnail();
        }

        private void btnOpen_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|Project Files|*.drawproj"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            if (Path.GetExtension(ofd.FileName).Equals(".drawproj", StringComparison.OrdinalIgnoreCase))
            {
                using var doc = JsonDocument.Parse(File.ReadAllText(ofd.FileName));
                var root = doc.RootElement;
                byte[] bytes = Convert.FromBase64String(root.GetProperty("Image").GetString()!);
                CreateNewCanvas(root.GetProperty("Width").GetInt32(), root.GetProperty("Height").GetInt32());
                using (var ms = new MemoryStream(bytes))
                using (var img = Image.FromStream(ms)) _graphics.DrawImage(img, 0, 0);
                _primaryColor = Color.FromArgb(root.GetProperty("Primary").GetInt32());
                _secondaryColor = Color.FromArgb(root.GetProperty("Secondary").GetInt32());
                _penSize = root.GetProperty("PenSize").GetInt32();
                ChangeZoom(root.GetProperty("Zoom").GetSingle());
                UpdateColorButtonUI();
                UpdatePenSizeButton();
            }
            else
            {
                using var img = Image.FromFile(ofd.FileName);
                CreateNewCanvas(img.Width, img.Height);
                _graphics.DrawImage(img, 0, 0);
            }
            pictureBox.Invalidate();
            UpdateThumbnail();
        }

        private void btnSave_Click(object? s, EventArgs e)
        {
            using var sfd = new SaveFileDialog { Filter = "PNG Image|*.png|JPEG Image|*.jpg", DefaultExt = "png" };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            string ext = Path.GetExtension(sfd.FileName).ToLower();
            _bitmap.Save(sfd.FileName, ext is ".jpg" or ".jpeg" ? ImageFormat.Jpeg : ImageFormat.Png);
        }

        private void btnSaveProject_Click(object? s, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "Проект рисования (*.drawproj)|*.drawproj",
                DefaultExt = "drawproj",
                Title = "Сохранить как проект"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            using var ms = new MemoryStream();
            _bitmap.Save(ms, ImageFormat.Png);
            File.WriteAllText(sfd.FileName, JsonSerializer.Serialize(new
            {
                Width = _bitmap.Width,
                Height = _bitmap.Height,
                Zoom = _zoom,
                Primary = _primaryColor.ToArgb(),
                Secondary = _secondaryColor.ToArgb(),
                PenSize = _penSize,
                Image = Convert.ToBase64String(ms.ToArray())
            }, new JsonSerializerOptions { WriteIndented = true }));
            MessageBox.Show("Проект успешно сохранён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Print(bool preview)
        {
            using var pd = new PrintDocument();
            pd.PrintPage += PrintDocument_PrintPage;
            if (preview)
            {
                using var ppd = new PrintPreviewDialog { Document = pd, Width = 800, Height = 600 };
                ppd.ShowDialog();
            }
            else
            {
                using var pdlg = new PrintDialog { Document = pd };
                if (pdlg.ShowDialog() == DialogResult.OK) pd.Print();
            }
        }

        private void PrintDocument_PrintPage(object? s, PrintPageEventArgs e)
        {
            if (_bitmap == null || e.Graphics == null) return;
            var mb = e.MarginBounds;
            float ratio = Math.Min(mb.Width / (float)_bitmap.Width, mb.Height / (float)_bitmap.Height);
            int w = (int)(_bitmap.Width * ratio), h = (int)(_bitmap.Height * ratio);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImage(_bitmap, (int)(mb.Left + (mb.Width - w) / 2), (int)(mb.Top + (mb.Height - h) / 2), w, h);
            e.HasMorePages = false;
        }
    }
}