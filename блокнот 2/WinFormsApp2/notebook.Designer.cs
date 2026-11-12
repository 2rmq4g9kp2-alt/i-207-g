namespace NotepadApp
{
    partial class notebook
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
            menuStrip1 = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            newMenuItem = new ToolStripMenuItem();
            openMenuItem = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            saveAsMenuItem = new ToolStripMenuItem();
            insertFileMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            printMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitMenuItem = new ToolStripMenuItem();
            editMenuItem = new ToolStripMenuItem();
            undoMenuItem = new ToolStripMenuItem();
            redoMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            cutMenuItem = new ToolStripMenuItem();
            copyMenuItem = new ToolStripMenuItem();
            pasteMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            selectAllMenuItem = new ToolStripMenuItem();
            formatMenuItem = new ToolStripMenuItem();
            fontMenuItem = new ToolStripMenuItem();
            colorMenuItem = new ToolStripMenuItem();
            backgroundColorMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            fileLabel = new ToolStripStatusLabel();
            charsLabel = new ToolStripStatusLabel();
            positionLabel = new ToolStripStatusLabel();
            insertModeLabel = new ToolStripStatusLabel();
            richTextBox1 = new RichTextBox();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenuItem, editMenuItem, formatMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(933, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newMenuItem, openMenuItem, saveMenuItem, saveAsMenuItem, insertFileMenuItem, toolStripSeparator1, printMenuItem, toolStripSeparator2, exitMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(48, 20);
            fileMenuItem.Text = "Файл";
            // 
            // newMenuItem
            // 
            newMenuItem.Name = "newMenuItem";
            newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newMenuItem.Size = new Size(173, 22);
            newMenuItem.Text = "Создать";
            newMenuItem.Click += NewMenuItem_Click;
            // 
            // openMenuItem
            // 
            openMenuItem.Name = "openMenuItem";
            openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openMenuItem.Size = new Size(173, 22);
            openMenuItem.Text = "Открыть...";
            openMenuItem.Click += OpenMenuItem_Click;
            // 
            // saveMenuItem
            // 
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveMenuItem.Size = new Size(173, 22);
            saveMenuItem.Text = "Сохранить";
            saveMenuItem.Click += SaveMenuItem_Click;
            // 
            // saveAsMenuItem
            // 
            saveAsMenuItem.Name = "saveAsMenuItem";
            saveAsMenuItem.Size = new Size(173, 22);
            saveAsMenuItem.Text = "Сохранить как...";
            saveAsMenuItem.Click += SaveAsMenuItem_Click;
            // 
            // insertFileMenuItem
            // 
            insertFileMenuItem.Name = "insertFileMenuItem";
            insertFileMenuItem.Size = new Size(173, 22);
            insertFileMenuItem.Text = "Вставить файл...";
            insertFileMenuItem.Click += InsertFileMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(170, 6);
            // 
            // printMenuItem
            // 
            printMenuItem.Name = "printMenuItem";
            printMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            printMenuItem.Size = new Size(173, 22);
            printMenuItem.Text = "Печать...";
            printMenuItem.Click += PrintMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(170, 6);
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(173, 22);
            exitMenuItem.Text = "Выход";
            exitMenuItem.Click += ExitMenuItem_Click;
            // 
            // editMenuItem
            // 
            editMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoMenuItem, redoMenuItem, toolStripSeparator3, cutMenuItem, copyMenuItem, pasteMenuItem, toolStripSeparator4, selectAllMenuItem });
            editMenuItem.Name = "editMenuItem";
            editMenuItem.Size = new Size(59, 20);
            editMenuItem.Text = "Правка";
            // 
            // undoMenuItem
            // 
            undoMenuItem.Name = "undoMenuItem";
            undoMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoMenuItem.Size = new Size(190, 22);
            undoMenuItem.Text = "Отменить";
            undoMenuItem.Click += UndoMenuItem_Click;
            // 
            // redoMenuItem
            // 
            redoMenuItem.Name = "redoMenuItem";
            redoMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoMenuItem.Size = new Size(190, 22);
            redoMenuItem.Text = "Вернуть";
            redoMenuItem.Click += RedoMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(187, 6);
            // 
            // cutMenuItem
            // 
            cutMenuItem.Name = "cutMenuItem";
            cutMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutMenuItem.Size = new Size(190, 22);
            cutMenuItem.Text = "Вырезать";
            cutMenuItem.Click += CutMenuItem_Click;
            // 
            // copyMenuItem
            // 
            copyMenuItem.Name = "copyMenuItem";
            copyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyMenuItem.Size = new Size(190, 22);
            copyMenuItem.Text = "Копировать";
            copyMenuItem.Click += CopyMenuItem_Click;
            // 
            // pasteMenuItem
            // 
            pasteMenuItem.Name = "pasteMenuItem";
            pasteMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteMenuItem.Size = new Size(190, 22);
            pasteMenuItem.Text = "Вставить";
            pasteMenuItem.Click += PasteMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(187, 6);
            // 
            // selectAllMenuItem
            // 
            selectAllMenuItem.Name = "selectAllMenuItem";
            selectAllMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllMenuItem.Size = new Size(190, 22);
            selectAllMenuItem.Text = "Выделить всё";
            selectAllMenuItem.Click += SelectAllMenuItem_Click;
            // 
            // formatMenuItem
            // 
            formatMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fontMenuItem, colorMenuItem, backgroundColorMenuItem });
            formatMenuItem.Name = "formatMenuItem";
            formatMenuItem.Size = new Size(62, 20);
            formatMenuItem.Text = "Формат";
            // 
            // fontMenuItem
            // 
            fontMenuItem.Name = "fontMenuItem";
            fontMenuItem.Size = new Size(146, 22);
            fontMenuItem.Text = "Шрифт...";
            fontMenuItem.Click += FontMenuItem_Click;
            // 
            // colorMenuItem
            // 
            colorMenuItem.Name = "colorMenuItem";
            colorMenuItem.Size = new Size(146, 22);
            colorMenuItem.Text = "Цвет текста...";
            colorMenuItem.Click += ColorMenuItem_Click;
            // 
            // backgroundColorMenuItem
            // 
            backgroundColorMenuItem.Name = "backgroundColorMenuItem";
            backgroundColorMenuItem.Size = new Size(146, 22);
            backgroundColorMenuItem.Text = "Цвет фона...";
            backgroundColorMenuItem.Click += BackgroundColorMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { fileLabel, charsLabel, positionLabel, insertModeLabel });
            statusStrip1.Location = new Point(0, 503);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(933, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // fileLabel
          
            // charsLabel
            // 
            charsLabel.Name = "charsLabel";
            charsLabel.Size = new Size(76, 17);
            charsLabel.Text = "Символов: 0";
            // 
            // positionLabel
            // 
            positionLabel.Name = "positionLabel";
            positionLabel.Size = new Size(78, 17);
            positionLabel.Text = "Стр 1, Стлб 1";
            // 
            // insertModeLabel
            // 
            insertModeLabel.Name = "insertModeLabel";
            insertModeLabel.Size = new Size(25, 17);
            insertModeLabel.Text = "INS";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ScrollBar;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(0, 24);
            richTextBox1.Margin = new Padding(4, 3, 4, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(933, 479);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.SelectionChanged += RichTextBox1_SelectionChanged;
            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            richTextBox1.KeyUp += RichTextBox1_KeyUp;
            // 
            // notebook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 525);
            Controls.Add(richTextBox1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "notebook";
            Text = "Блокнот";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel fileLabel;
        private System.Windows.Forms.ToolStripStatusLabel charsLabel;
        private System.Windows.Forms.ToolStripStatusLabel positionLabel;
        private System.Windows.Forms.ToolStripStatusLabel insertModeLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}