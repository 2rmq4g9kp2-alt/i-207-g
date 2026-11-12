namespace WinFormsApp2
{
    partial class Paint
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelQuickAccess = new Panel();
            lblTitle = new Label();
            btnQuickSave = new Button();
            btnQuickUndo = new Button();
            btnQuickRedo = new Button();
            panelTabs = new Panel();
            btnTabFile = new Button();
            btnTabHome = new Button();
            btnTabView = new Button();
            panelHomeRibbon = new Panel();
            lblBuffer = new Label();
            btnPaste = new Button();
            btnCut = new Button();
            btnCopy = new Button();
            lblImage = new Label();
            btnSelect = new Button();
            btnCrop = new Button();
            btnResize = new Button();
            btnRotate = new Button();
            lblTools = new Label();
            btnPencil = new Button();
            btnFill = new Button();
            btnText = new Button();
            btnEraser = new Button();
            btnPicker = new Button();
            lblBrushes = new Label();
            btnBrush = new Button();
            lblShapes = new Label();
            btnShapeLine = new Button();
            btnShapeCurve = new Button();
            btnShapeEllipse = new Button();
            btnShapeRect = new Button();
            btnShapeTriangle = new Button();
            btnShapeDiamond = new Button();
            btnShapeStar = new Button();
            btnFillMode = new Button();
            lblSize = new Label();
            btnPenSize = new Button();
            lblColors = new Label();
            btnColor1 = new Button();
            btnColor2 = new Button();
            flowColors = new FlowLayoutPanel();
            panelViewRibbon = new Panel();
            lblZoom = new Label();
            btnZoomIn = new Button();
            btnZoomOut = new Button();
            btnZoomReset = new Button();
            lblShowHide = new Label();
            chkGrid = new CheckBox();
            chkStatus = new CheckBox();
            lblShow = new Label();
            btnFullScreen = new Button();
            btnThumbnail = new Button();
            panelCanvasContainer = new Panel();
            pictureBox = new PictureBox();
            pictureBoxThumbnail = new PictureBox();
            statusStrip = new StatusStrip();
            lblCoords = new ToolStripStatusLabel();
            lblCanvasSize = new ToolStripStatusLabel();

            // 20 кнопок палитры для отображения в конструкторе
            btnPalette0 = new Button();
            btnPalette1 = new Button();
            btnPalette2 = new Button();
            btnPalette3 = new Button();
            btnPalette4 = new Button();
            btnPalette5 = new Button();
            btnPalette6 = new Button();
            btnPalette7 = new Button();
            btnPalette8 = new Button();
            btnPalette9 = new Button();
            btnPalette10 = new Button();
            btnPalette11 = new Button();
            btnPalette12 = new Button();
            btnPalette13 = new Button();
            btnPalette14 = new Button();
            btnPalette15 = new Button();
            btnPalette16 = new Button();
            btnPalette17 = new Button();
            btnPalette18 = new Button();
            btnPalette19 = new Button();

            panelQuickAccess.SuspendLayout();
            panelTabs.SuspendLayout();
            panelHomeRibbon.SuspendLayout();
            panelViewRibbon.SuspendLayout();
            panelCanvasContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumbnail).BeginInit();
            statusStrip.SuspendLayout();
            flowColors.SuspendLayout();
            SuspendLayout();
            // 
            // panelQuickAccess
            // 
            panelQuickAccess.BackColor = Color.White;
            panelQuickAccess.Controls.Add(lblTitle);
            panelQuickAccess.Controls.Add(btnQuickSave);
            panelQuickAccess.Controls.Add(btnQuickUndo);
            panelQuickAccess.Controls.Add(btnQuickRedo);
            panelQuickAccess.Dock = DockStyle.Top;
            panelQuickAccess.Location = new Point(0, 0);
            panelQuickAccess.Name = "panelQuickAccess";
            panelQuickAccess.Size = new Size(1250, 30);
            panelQuickAccess.TabIndex = 5;
            // ... (кнопки быстрого доступа остаются без изменений) ...
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(200, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(117, 15);
            lblTitle.Text = "Безымянный - Paint";

            btnQuickSave.FlatAppearance.BorderSize = 0;
            btnQuickSave.FlatStyle = FlatStyle.Flat;
            btnQuickSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuickSave.Location = new Point(10, 3);
            btnQuickSave.Size = new Size(24, 24);
            btnQuickSave.Text = "💾";
            btnQuickSave.Click += btnSave_Click;

            btnQuickUndo.FlatAppearance.BorderSize = 0;
            btnQuickUndo.FlatStyle = FlatStyle.Flat;
            btnQuickUndo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuickUndo.Location = new Point(45, 3);
            btnQuickUndo.Size = new Size(24, 24);
            btnQuickUndo.Text = "↩";
            btnQuickUndo.Click += btnUndo_Click;

            btnQuickRedo.FlatAppearance.BorderSize = 0;
            btnQuickRedo.FlatStyle = FlatStyle.Flat;
            btnQuickRedo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuickRedo.Location = new Point(80, 3);
            btnQuickRedo.Size = new Size(24, 24);
            btnQuickRedo.Text = "↪";
            btnQuickRedo.Click += btnRedo_Click;
            // 
            // panelTabs
            // 
            panelTabs.BackColor = Color.White;
            panelTabs.Controls.Add(btnTabFile);
            panelTabs.Controls.Add(btnTabHome);
            panelTabs.Controls.Add(btnTabView);
            panelTabs.Dock = DockStyle.Top;
            panelTabs.Location = new Point(0, 30);
            panelTabs.Name = "panelTabs";
            panelTabs.Size = new Size(1250, 35);
            panelTabs.TabIndex = 4;

            btnTabFile.BackColor = Color.FromArgb(0, 120, 215);
            btnTabFile.FlatAppearance.BorderSize = 0;
            btnTabFile.FlatStyle = FlatStyle.Flat;
            btnTabFile.ForeColor = Color.White;
            btnTabFile.Location = new Point(10, 0);
            btnTabFile.Size = new Size(60, 30);
            btnTabFile.Text = "Файл";
            btnTabFile.UseVisualStyleBackColor = false;
            btnTabFile.Click += btnTabFile_Click;

            btnTabHome.BackColor = Color.FromArgb(230, 230, 230);
            btnTabHome.FlatAppearance.BorderSize = 0;
            btnTabHome.FlatStyle = FlatStyle.Flat;
            btnTabHome.Location = new Point(75, 0);
            btnTabHome.Size = new Size(80, 30);
            btnTabHome.Text = "Главная";
            btnTabHome.UseVisualStyleBackColor = false;
            btnTabHome.Click += btnTabHome_Click;

            btnTabView.BackColor = Color.White;
            btnTabView.FlatAppearance.BorderSize = 0;
            btnTabView.FlatStyle = FlatStyle.Flat;
            btnTabView.Location = new Point(160, 0);
            btnTabView.Size = new Size(60, 30);
            btnTabView.Text = "Вид";
            btnTabView.UseVisualStyleBackColor = false;
            btnTabView.Click += btnTabView_Click;
            // 
            // panelHomeRibbon
            // 
            panelHomeRibbon.BackColor = Color.FromArgb(245, 245, 245);
            panelHomeRibbon.Controls.Add(lblBuffer);
            panelHomeRibbon.Controls.Add(btnPaste);
            panelHomeRibbon.Controls.Add(btnCut);
            panelHomeRibbon.Controls.Add(btnCopy);
            panelHomeRibbon.Controls.Add(lblImage);
            panelHomeRibbon.Controls.Add(btnSelect);
            panelHomeRibbon.Controls.Add(btnCrop);
            panelHomeRibbon.Controls.Add(btnResize);
            panelHomeRibbon.Controls.Add(btnRotate);
            panelHomeRibbon.Controls.Add(lblTools);
            panelHomeRibbon.Controls.Add(btnPencil);
            panelHomeRibbon.Controls.Add(btnFill);
            panelHomeRibbon.Controls.Add(btnText);
            panelHomeRibbon.Controls.Add(btnEraser);
            panelHomeRibbon.Controls.Add(btnPicker);
            panelHomeRibbon.Controls.Add(lblBrushes);
            panelHomeRibbon.Controls.Add(btnBrush);
            panelHomeRibbon.Controls.Add(lblShapes);
            panelHomeRibbon.Controls.Add(btnShapeLine);
            panelHomeRibbon.Controls.Add(btnShapeCurve);
            panelHomeRibbon.Controls.Add(btnShapeEllipse);
            panelHomeRibbon.Controls.Add(btnShapeRect);
            panelHomeRibbon.Controls.Add(btnShapeTriangle);
            panelHomeRibbon.Controls.Add(btnShapeDiamond);
            panelHomeRibbon.Controls.Add(btnShapeStar);
            panelHomeRibbon.Controls.Add(btnFillMode);
            panelHomeRibbon.Controls.Add(lblSize);
            panelHomeRibbon.Controls.Add(btnPenSize);
            panelHomeRibbon.Controls.Add(lblColors);
            panelHomeRibbon.Controls.Add(btnColor1);
            panelHomeRibbon.Controls.Add(btnColor2);
            panelHomeRibbon.Controls.Add(flowColors);
            panelHomeRibbon.Dock = DockStyle.Top;
            panelHomeRibbon.Location = new Point(0, 65);
            panelHomeRibbon.Name = "panelHomeRibbon";
            panelHomeRibbon.Size = new Size(1250, 110);
            panelHomeRibbon.TabIndex = 3;

            // ... (код элементов HomeRibbon остается прежним) ...
            lblBuffer.Location = new Point(10, 88);
            lblBuffer.Size = new Size(140, 20);
            lblBuffer.Text = "Буфер обмена";

            btnPaste.FlatAppearance.BorderSize = 0;
            btnPaste.FlatStyle = FlatStyle.Flat;
            btnPaste.Location = new Point(10, 5);
            btnPaste.Size = new Size(45, 60);
            btnPaste.Text = "📋\nВставить";
            btnPaste.Click += btnPaste_Click;

            btnCut.FlatAppearance.BorderSize = 0;
            btnCut.FlatStyle = FlatStyle.Flat;
            btnCut.Location = new Point(60, 10);
            btnCut.Size = new Size(95, 25);
            btnCut.Text = "✂ Вырезать";
            btnCut.Click += btnCut_Click;

            btnCopy.FlatAppearance.BorderSize = 0;
            btnCopy.FlatStyle = FlatStyle.Flat;
            btnCopy.Location = new Point(60, 38);
            btnCopy.Size = new Size(95, 25);
            btnCopy.Text = "📄 Копировать";
            btnCopy.Click += btnCopy_Click;

            lblImage.Location = new Point(170, 88);
            lblImage.Size = new Size(150, 20);
            lblImage.Text = "Изображение";

            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.Location = new Point(170, 5);
            btnSelect.Size = new Size(45, 60);
            btnSelect.Text = "🔲\nВыделить";
            btnSelect.Click += btnSelect_Click;

            btnCrop.FlatAppearance.BorderSize = 0;
            btnCrop.FlatStyle = FlatStyle.Flat;
            btnCrop.Location = new Point(220, 10);
            btnCrop.Size = new Size(95, 25);
            btnCrop.Text = "✂️ Обрезать";
            btnCrop.Click += btnCrop_Click;

            btnResize.FlatAppearance.BorderSize = 0;
            btnResize.FlatStyle = FlatStyle.Flat;
            btnResize.Location = new Point(220, 38);
            btnResize.Size = new Size(95, 25);
            btnResize.Text = "📐 Изменить";
            btnResize.Click += btnResize_Click;

            btnRotate.FlatAppearance.BorderSize = 0;
            btnRotate.FlatStyle = FlatStyle.Flat;
            btnRotate.Location = new Point(220, 66);
            btnRotate.Size = new Size(95, 25);
            btnRotate.Text = "🔄 Повернуть";
            btnRotate.Click += btnRotate_Click;

            lblTools.Location = new Point(340, 88);
            lblTools.Size = new Size(140, 20);
            lblTools.Text = "Инструменты";

            btnPencil.BackColor = Color.FromArgb(200, 220, 240);
            btnPencil.FlatAppearance.BorderSize = 0;
            btnPencil.FlatStyle = FlatStyle.Flat;
            btnPencil.Font = new Font("Segoe UI", 16F);
            btnPencil.Location = new Point(340, 5);
            btnPencil.Size = new Size(35, 35);
            btnPencil.Text = "✏";
            btnPencil.UseVisualStyleBackColor = false;
            btnPencil.Click += btnPencil_Click;

            btnFill.FlatAppearance.BorderSize = 0;
            btnFill.FlatStyle = FlatStyle.Flat;
            btnFill.Font = new Font("Segoe UI", 14F);
            btnFill.Location = new Point(380, 5);
            btnFill.Size = new Size(35, 35);
            btnFill.Text = "\U0001faa3";
            btnFill.Click += btnFill_Click;

            btnText.FlatAppearance.BorderSize = 0;
            btnText.FlatStyle = FlatStyle.Flat;
            btnText.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnText.Location = new Point(420, 5);
            btnText.Size = new Size(35, 35);
            btnText.Text = "A";
            btnText.Click += btnText_Click;

            btnEraser.FlatAppearance.BorderSize = 0;
            btnEraser.FlatStyle = FlatStyle.Flat;
            btnEraser.Font = new Font("Segoe UI", 14F);
            btnEraser.Location = new Point(340, 45);
            btnEraser.Size = new Size(35, 35);
            btnEraser.Text = "\U0001f9fd";
            btnEraser.Click += btnEraser_Click;

            btnPicker.FlatAppearance.BorderSize = 0;
            btnPicker.FlatStyle = FlatStyle.Flat;
            btnPicker.Font = new Font("Segoe UI", 14F);
            btnPicker.Location = new Point(380, 45);
            btnPicker.Size = new Size(35, 35);
            btnPicker.Text = "💧";
            btnPicker.Click += btnPicker_Click;

            lblBrushes.Location = new Point(510, 88);
            lblBrushes.Size = new Size(70, 20);
            lblBrushes.Text = "Кисти";

            btnBrush.FlatAppearance.BorderSize = 0;
            btnBrush.FlatStyle = FlatStyle.Flat;
            btnBrush.Location = new Point(510, 5);
            btnBrush.Size = new Size(60, 60);
            btnBrush.Text = "🖌\nКисти";
            btnBrush.Click += btnBrush_Click;

            lblShapes.Location = new Point(590, 88);
            lblShapes.Size = new Size(220, 20);
            lblShapes.Text = "Фигуры";

            btnShapeLine.FlatAppearance.BorderSize = 0;
            btnShapeLine.FlatStyle = FlatStyle.Flat;
            btnShapeLine.Location = new Point(590, 5);
            btnShapeLine.Size = new Size(25, 25);
            btnShapeLine.Text = "／";
            btnShapeLine.Click += btnShapeLine_Click;

            btnShapeCurve.FlatAppearance.BorderSize = 0;
            btnShapeCurve.FlatStyle = FlatStyle.Flat;
            btnShapeCurve.Location = new Point(620, 5);
            btnShapeCurve.Size = new Size(25, 25);
            btnShapeCurve.Text = "∿";
            btnShapeCurve.Click += btnShapeCurve_Click;

            btnShapeEllipse.FlatAppearance.BorderSize = 0;
            btnShapeEllipse.FlatStyle = FlatStyle.Flat;
            btnShapeEllipse.Location = new Point(650, 5);
            btnShapeEllipse.Size = new Size(25, 25);
            btnShapeEllipse.Text = "◯";
            btnShapeEllipse.Click += btnShapeEllipse_Click;

            btnShapeRect.FlatAppearance.BorderSize = 0;
            btnShapeRect.FlatStyle = FlatStyle.Flat;
            btnShapeRect.Location = new Point(680, 5);
            btnShapeRect.Size = new Size(25, 25);
            btnShapeRect.Text = "▭";
            btnShapeRect.Click += btnShapeRect_Click;

            btnShapeTriangle.FlatAppearance.BorderSize = 0;
            btnShapeTriangle.FlatStyle = FlatStyle.Flat;
            btnShapeTriangle.Location = new Point(710, 5);
            btnShapeTriangle.Size = new Size(25, 25);
            btnShapeTriangle.Text = "▲";
            btnShapeTriangle.Click += btnShapeTriangle_Click;

            btnShapeDiamond.FlatAppearance.BorderSize = 0;
            btnShapeDiamond.FlatStyle = FlatStyle.Flat;
            btnShapeDiamond.Location = new Point(740, 5);
            btnShapeDiamond.Size = new Size(25, 25);
            btnShapeDiamond.Text = "♦";
            btnShapeDiamond.Click += btnShapeDiamond_Click;

            btnShapeStar.FlatAppearance.BorderSize = 0;
            btnShapeStar.FlatStyle = FlatStyle.Flat;
            btnShapeStar.Location = new Point(770, 5);
            btnShapeStar.Size = new Size(25, 25);
            btnShapeStar.Text = "★";
            btnShapeStar.Click += btnShapeStar_Click;

            btnFillMode.FlatAppearance.BorderSize = 0;
            btnFillMode.FlatStyle = FlatStyle.Flat;
            btnFillMode.Location = new Point(590, 40);
            btnFillMode.Size = new Size(100, 30);
            btnFillMode.Text = "Контур ▾";
            btnFillMode.Click += btnFillMode_Click;

            lblSize.Location = new Point(830, 88);
            lblSize.Size = new Size(70, 20);
            lblSize.Text = "Толщина";

            btnPenSize.FlatAppearance.BorderColor = Color.Gray;
            btnPenSize.FlatStyle = FlatStyle.Flat;
            btnPenSize.Location = new Point(830, 15);
            btnPenSize.Size = new Size(130, 35);
            btnPenSize.Text = "Толщина:  ▼";
            btnPenSize.Click += btnPenSize_Click;

            lblColors.Location = new Point(970, 88);
            lblColors.Size = new Size(230, 20);
            lblColors.Text = "Цвета";

            btnColor1.BackColor = Color.Red;
            btnColor1.FlatAppearance.BorderColor = Color.Gray;
            btnColor1.FlatStyle = FlatStyle.Flat;
            btnColor1.ForeColor = Color.White;
            btnColor1.Location = new Point(970, 15);
            btnColor1.Size = new Size(80, 35);
            btnColor1.Text = "Цвет 🎨";
            btnColor1.Click += btnColor1_Click;

            btnColor2.BackColor = Color.White;
            btnColor2.FlatAppearance.BorderColor = Color.Gray;
            btnColor2.FlatStyle = FlatStyle.Flat;
            btnColor2.Location = new Point(1060, 15);
            btnColor2.Size = new Size(35, 35);
            btnColor2.Click += btnColor2_Click;

            // flowColors
            flowColors.Location = new Point(1105, 5);
            flowColors.Size = new Size(130, 86);

            // Настройка 20 кнопок палитры
            ConfigurePaletteButton(btnPalette0, Color.Black, 0);
            ConfigurePaletteButton(btnPalette1, Color.Gray, 1);
            ConfigurePaletteButton(btnPalette2, Color.DarkRed, 2);
            ConfigurePaletteButton(btnPalette3, Color.Red, 3);
            ConfigurePaletteButton(btnPalette4, Color.Orange, 4);
            ConfigurePaletteButton(btnPalette5, Color.Gold, 5);
            ConfigurePaletteButton(btnPalette6, Color.Yellow, 6);
            ConfigurePaletteButton(btnPalette7, Color.LimeGreen, 7);
            ConfigurePaletteButton(btnPalette8, Color.Green, 8);
            ConfigurePaletteButton(btnPalette9, Color.Teal, 9);
            ConfigurePaletteButton(btnPalette10, Color.Cyan, 10);
            ConfigurePaletteButton(btnPalette11, Color.SteelBlue, 11);
            ConfigurePaletteButton(btnPalette12, Color.Blue, 12);
            ConfigurePaletteButton(btnPalette13, Color.Navy, 13);
            ConfigurePaletteButton(btnPalette14, Color.Purple, 14);
            ConfigurePaletteButton(btnPalette15, Color.Magenta, 15);
            ConfigurePaletteButton(btnPalette16, Color.Brown, 16);
            ConfigurePaletteButton(btnPalette17, Color.Maroon, 17);
            ConfigurePaletteButton(btnPalette18, Color.SaddleBrown, 18);
            ConfigurePaletteButton(btnPalette19, Color.White, 19);

            // 
            // panelViewRibbon (ИСПРАВЛЕНО: Dock = Top, размер = 110, чтобы не перекрывать холст)
            // 
            panelViewRibbon.BackColor = Color.FromArgb(245, 245, 245);
            panelViewRibbon.Controls.Add(lblZoom);
            panelViewRibbon.Controls.Add(btnZoomIn);
            panelViewRibbon.Controls.Add(btnZoomOut);
            panelViewRibbon.Controls.Add(btnZoomReset);
            panelViewRibbon.Controls.Add(lblShowHide);
            panelViewRibbon.Controls.Add(chkGrid);
            panelViewRibbon.Controls.Add(chkStatus);
            panelViewRibbon.Controls.Add(lblShow);
            panelViewRibbon.Controls.Add(btnFullScreen);
            panelViewRibbon.Controls.Add(btnThumbnail);
            panelViewRibbon.Dock = DockStyle.Top; // БЫЛО Fill
            panelViewRibbon.Location = new Point(0, 175);
            panelViewRibbon.Name = "panelViewRibbon";
            panelViewRibbon.Size = new Size(1250, 110); // БЫЛО 625
            panelViewRibbon.TabIndex = 2;
            panelViewRibbon.Visible = false;

            lblZoom.Location = new Point(10, 88);
            lblZoom.Size = new Size(180, 20);
            lblZoom.Text = "Масштаб";
            lblZoom.TextAlign = ContentAlignment.MiddleCenter;

            btnZoomIn.FlatAppearance.BorderSize = 0;
            btnZoomIn.FlatStyle = FlatStyle.Flat;
            btnZoomIn.Location = new Point(10, 5);
            btnZoomIn.Size = new Size(50, 60);
            btnZoomIn.Text = "➕\nУвеличить";
            btnZoomIn.Click += btnZoomIn_Click;

            btnZoomOut.FlatAppearance.BorderSize = 0;
            btnZoomOut.FlatStyle = FlatStyle.Flat;
            btnZoomOut.Location = new Point(65, 5);
            btnZoomOut.Size = new Size(50, 60);
            btnZoomOut.Text = "➖\nУменьшить";
            btnZoomOut.Click += btnZoomOut_Click;

            btnZoomReset.FlatAppearance.BorderSize = 0;
            btnZoomReset.FlatStyle = FlatStyle.Flat;
            btnZoomReset.Location = new Point(120, 5);
            btnZoomReset.Size = new Size(50, 60);
            btnZoomReset.Text = "🔍\n100%";
            btnZoomReset.Click += btnZoomReset_Click;

            lblShowHide.Location = new Point(210, 88);
            lblShowHide.Size = new Size(160, 20);
            lblShowHide.Text = "Показать или скрыть";
            lblShowHide.TextAlign = ContentAlignment.MiddleCenter;

            chkGrid.AutoSize = true;
            chkGrid.Location = new Point(220, 25);
            chkGrid.Size = new Size(95, 19);
            chkGrid.Text = "Линии сетки";
            chkGrid.CheckedChanged += chkGrid_CheckedChanged;

            chkStatus.AutoSize = true;
            chkStatus.Checked = true;
            chkStatus.CheckState = CheckState.Checked;
            chkStatus.Location = new Point(220, 55);
            chkStatus.Size = new Size(125, 19);
            chkStatus.Text = "Строка состояния";
            chkStatus.CheckedChanged += chkStatus_CheckedChanged;

            lblShow.Location = new Point(390, 88);
            lblShow.Size = new Size(180, 20);
            lblShow.Text = "Показать";
            lblShow.TextAlign = ContentAlignment.MiddleCenter;

            btnFullScreen.FlatAppearance.BorderSize = 0;
            btnFullScreen.FlatStyle = FlatStyle.Flat;
            btnFullScreen.Location = new Point(390, 5);
            btnFullScreen.Size = new Size(80, 60);
            btnFullScreen.Text = "🖥️\nВо весь экран";
            btnFullScreen.Click += btnFullScreen_Click;

            btnThumbnail.FlatAppearance.BorderSize = 0;
            btnThumbnail.FlatStyle = FlatStyle.Flat;
            btnThumbnail.Location = new Point(480, 5);
            btnThumbnail.Size = new Size(50, 60);
            btnThumbnail.Text = "🖼️\nЭскиз";
            btnThumbnail.Click += btnThumbnail_Click;
            // 
            // panelCanvasContainer
            // 
            panelCanvasContainer.AutoScroll = true;
            panelCanvasContainer.BackColor = Color.FromArgb(200, 200, 200);
            panelCanvasContainer.Controls.Add(pictureBox);
            panelCanvasContainer.Controls.Add(pictureBoxThumbnail);
            panelCanvasContainer.Dock = DockStyle.Fill;
            panelCanvasContainer.Location = new Point(0, 175);
            panelCanvasContainer.Name = "panelCanvasContainer";
            panelCanvasContainer.Size = new Size(1250, 603);
            panelCanvasContainer.TabIndex = 0;

            pictureBox.BackColor = Color.White;
            pictureBox.Location = new Point(50, 50);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1044, 600);
            pictureBox.TabStop = false;
            pictureBox.Paint += pictureBox_Paint;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;

            pictureBoxThumbnail.BackColor = Color.LightGray;
            pictureBoxThumbnail.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxThumbnail.Dock = DockStyle.Right;
            pictureBoxThumbnail.Location = new Point(1223, 0);
            pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            pictureBoxThumbnail.Size = new Size(10, 650);
            pictureBoxThumbnail.TabStop = false;
            pictureBoxThumbnail.Visible = false;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(245, 245, 245);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblCoords, lblCanvasSize });
            statusStrip.Location = new Point(0, 778);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1250, 22);
            statusStrip.TabIndex = 1;

            lblCoords.Name = "lblCoords";
            lblCoords.Size = new Size(57, 17);
            lblCoords.Text = "0, 0 пикс.";

            lblCanvasSize.Name = "lblCanvasSize";
            lblCanvasSize.Size = new Size(1178, 17);
            lblCanvasSize.Spring = true;
            lblCanvasSize.Text = "800 × 600 пикс.";
            lblCanvasSize.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Paint
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 800);
            Controls.Add(panelCanvasContainer);
            Controls.Add(statusStrip);
            Controls.Add(panelViewRibbon);
            Controls.Add(panelHomeRibbon);
            Controls.Add(panelTabs);
            Controls.Add(panelQuickAccess);
            Name = "Paint";
            Text = "Безымянный - Paint";
            Load += Paint_Load;
            panelQuickAccess.ResumeLayout(false);
            panelQuickAccess.PerformLayout();
            panelTabs.ResumeLayout(false);
            panelHomeRibbon.ResumeLayout(false);
            panelViewRibbon.ResumeLayout(false);
            panelViewRibbon.PerformLayout();
            panelCanvasContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumbnail).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            flowColors.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigurePaletteButton(Button btn, Color color, int index)
        {
            btn.BackColor = color;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.FlatAppearance.BorderSize = 1;
            btn.Size = new Size(20, 20);
            btn.Margin = new Padding(1);
            btn.Cursor = Cursors.Hand;
            btn.MouseDown += ColorButton_MouseDown;
            flowColors.Controls.Add(btn);
        }

        #endregion

        private System.Windows.Forms.Panel panelQuickAccess;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnQuickSave, btnQuickUndo, btnQuickRedo;
        private System.Windows.Forms.Panel panelTabs;
        private System.Windows.Forms.Button btnTabFile, btnTabHome, btnTabView;
        private System.Windows.Forms.Panel panelHomeRibbon;
        private System.Windows.Forms.Label lblBuffer, lblImage, lblTools, lblBrushes, lblShapes, lblSize, lblColors;
        private System.Windows.Forms.Button btnPaste, btnCut, btnCopy;
        private System.Windows.Forms.Button btnSelect, btnCrop, btnResize, btnRotate;
        private System.Windows.Forms.Button btnPencil, btnFill, btnText, btnEraser, btnPicker;
        private System.Windows.Forms.Button btnBrush;
        private System.Windows.Forms.Button btnShapeLine, btnShapeCurve, btnShapeEllipse, btnShapeRect, btnShapeTriangle, btnShapeDiamond, btnShapeStar, btnFillMode;
        private System.Windows.Forms.Button btnPenSize;
        private System.Windows.Forms.Button btnColor1, btnColor2;
        private System.Windows.Forms.FlowLayoutPanel flowColors;
        private System.Windows.Forms.Panel panelViewRibbon;
        private System.Windows.Forms.Label lblZoom, lblShowHide, lblShow;
        private System.Windows.Forms.Button btnZoomIn, btnZoomOut, btnZoomReset;
        private System.Windows.Forms.CheckBox chkGrid, chkStatus;
        private System.Windows.Forms.Button btnFullScreen, btnThumbnail;
        private System.Windows.Forms.Panel panelCanvasContainer;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox pictureBoxThumbnail;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblCoords;
        private System.Windows.Forms.ToolStripStatusLabel lblCanvasSize;

        private System.Windows.Forms.Button btnPalette0, btnPalette1, btnPalette2, btnPalette3, btnPalette4;
        private System.Windows.Forms.Button btnPalette5, btnPalette6, btnPalette7, btnPalette8, btnPalette9;
        private System.Windows.Forms.Button btnPalette10, btnPalette11, btnPalette12, btnPalette13, btnPalette14;
        private System.Windows.Forms.Button btnPalette15, btnPalette16, btnPalette17, btnPalette18, btnPalette19;
    }
}