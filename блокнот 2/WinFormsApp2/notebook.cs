#nullable enable
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NotepadApp
{
    public partial class notebook : Form
    {
        private string? currentFilePath;

        public notebook()
        {
            InitializeComponent();
            UpdateStatusBar();
            UpdateInsertMode();
        }

        // ================= Обновление статусной строки =================
        private void RichTextBox1_TextChanged(object? sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        private void RichTextBox1_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateCursorPosition();
        }

        private void RichTextBox1_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
                UpdateInsertMode();
        }

        private void UpdateStatusBar()
        {
            charsLabel.Text = $"Символов: {richTextBox1.TextLength}";
            fileLabel.Text = string.IsNullOrEmpty(currentFilePath) ? "Без имени" : currentFilePath;
            UpdateCursorPosition();
        }

        private void UpdateCursorPosition()
        {
            int index = richTextBox1.SelectionStart;
            int line = richTextBox1.GetLineFromCharIndex(index);
            int firstCharOfLine = richTextBox1.GetFirstCharIndexFromLine(line);
            int column = index - firstCharOfLine;
            positionLabel.Text = $"Стр {line + 1}, Стлб {column + 1}";
        }

        private void UpdateInsertMode()
        {
            bool overwrite = IsOverwriteMode();
            insertModeLabel.Text = overwrite ? "OVR" : "INS";
        }

        // ================= P/Invoke для режима вставки =================
        private const int EM_GETINSERTMODE_REAL = 0x0400 + 22;

        private bool IsOverwriteMode()
        {
            try
            {
                IntPtr result = SendMessage(richTextBox1.Handle, EM_GETINSERTMODE_REAL, IntPtr.Zero, IntPtr.Zero);
                return result != IntPtr.Zero;
            }
            catch
            {
                return false;
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        // ================== Обработчики меню "Файл" ==================
        private void NewMenuItem_Click(object? sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                var result = MessageBox.Show("Сохранить изменения в текущем файле?", "Блокнот", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel) return;
                if (result == DialogResult.Yes) SaveMenuItem_Click(sender, e);
            }
            richTextBox1.Clear();
            currentFilePath = null;
            Text = "Блокнот";
            UpdateStatusBar();
        }

        private void OpenMenuItem_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*", Title = "Открыть файл" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
                currentFilePath = ofd.FileName;
                Text = "Блокнот — " + Path.GetFileName(ofd.FileName);
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveMenuItem_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveAsMenuItem_Click(sender, e);
                return;
            }
            try
            {
                File.WriteAllText(currentFilePath, richTextBox1.Text);
                Text = "Блокнот — " + Path.GetFileName(currentFilePath);
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAsMenuItem_Click(object? sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog { Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*", Title = "Сохранить файл", FileName = "Новый файл.txt" };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                File.WriteAllText(sfd.FileName, richTextBox1.Text);
                currentFilePath = sfd.FileName;
                Text = "Блокнот — " + Path.GetFileName(sfd.FileName);
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertFileMenuItem_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*", Title = "Вставить содержимое файла" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                richTextBox1.SelectedText = File.ReadAllText(ofd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка вставки файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintMenuItem_Click(object? sender, EventArgs e)
        {
            using var printDialog = new PrintDialog();
            using var printDoc = new System.Drawing.Printing.PrintDocument();

            printDoc.PrintPage += (s, ev) =>
            {
                if (ev.Graphics != null)
                {
                    ev.Graphics.DrawString(
                        richTextBox1.Text,
                        richTextBox1.Font,
                        new SolidBrush(richTextBox1.ForeColor),
                        ev.MarginBounds.Left,
                        ev.MarginBounds.Top
                    );
                }
            };

            printDialog.Document = printDoc;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDoc.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при печати: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExitMenuItem_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // ================== Обработчики меню "Правка" ==================
        private void UndoMenuItem_Click(object? sender, EventArgs e) => richTextBox1.Undo();
        private void RedoMenuItem_Click(object? sender, EventArgs e) => richTextBox1.Redo();
        private void CutMenuItem_Click(object? sender, EventArgs e) => richTextBox1.Cut();
        private void CopyMenuItem_Click(object? sender, EventArgs e) => richTextBox1.Copy();
        private void PasteMenuItem_Click(object? sender, EventArgs e) => richTextBox1.Paste();
        private void SelectAllMenuItem_Click(object? sender, EventArgs e) => richTextBox1.SelectAll();

        // ================== Обработчики меню "Формат" ==================
        private void FontMenuItem_Click(object? sender, EventArgs e)
        {
            using var fontDialog = new FontDialog();
            fontDialog.Font = richTextBox1.SelectionLength > 0 && richTextBox1.SelectionFont != null ? richTextBox1.SelectionFont : richTextBox1.Font;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectionLength > 0)
                    richTextBox1.SelectionFont = fontDialog.Font;
                else
                    richTextBox1.Font = fontDialog.Font;
            }
        }

        private void ColorMenuItem_Click(object? sender, EventArgs e)
        {
            using var colorDialog = new ColorDialog();
            colorDialog.Color = richTextBox1.SelectionLength > 0 ? richTextBox1.SelectionColor : richTextBox1.ForeColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectionLength > 0)
                    richTextBox1.SelectionColor = colorDialog.Color;
                else
                    richTextBox1.ForeColor = colorDialog.Color;
            }
        }

        private void BackgroundColorMenuItem_Click(object? sender, EventArgs e)
        {
            using var colorDialog = new ColorDialog();

            // Если выделен текст — берем цвет его фона, иначе — фон всего редактора
            colorDialog.Color = richTextBox1.SelectionLength > 0
                ? richTextBox1.SelectionBackColor
                : richTextBox1.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectionLength > 0)
                    richTextBox1.SelectionBackColor = colorDialog.Color; // Цвет фона выделения
                else
                    richTextBox1.BackColor = colorDialog.Color; // Цвет фона всего документа
            }
        }
    }
}
