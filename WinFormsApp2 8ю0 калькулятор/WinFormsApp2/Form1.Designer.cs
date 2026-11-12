namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btn0, btn1, btn2, btn3, btn4;
        private System.Windows.Forms.Button btn5, btn6, btn7, btn8, btn9;
        private System.Windows.Forms.Button btnPlus, btnMinus, btnMultiply, btnDivide;
        private System.Windows.Forms.Button btnEquals, btnClear, btnComma;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtDisplay = new TextBox();
            btn0 = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnPlus = new Button();
            btnMinus = new Button();
            btnMultiply = new Button();
            btnDivide = new Button();
            btnEquals = new Button();
            btnClear = new Button();
            btnComma = new Button();
            SuspendLayout();
            // 
            // txtDisplay
            // 
            txtDisplay.Font = new Font("Segoe UI", 16F);
            txtDisplay.Location = new Point(12, 12);
            txtDisplay.Name = "txtDisplay";
            txtDisplay.Size = new Size(260, 36);
            txtDisplay.TabIndex = 0;
            txtDisplay.Text = "0";
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            // 
            // btn0
            // 
            btn0.Location = new Point(12, 228);
            btn0.Name = "btn0";
            btn0.Size = new Size(60, 50);
            btn0.TabIndex = 1;
            btn0.Text = "0";
            btn0.Click += btnNumber_Click;
            // 
            // btn1
            // 
            btn1.Location = new Point(12, 172);
            btn1.Name = "btn1";
            btn1.Size = new Size(60, 50);
            btn1.TabIndex = 2;
            btn1.Text = "1";
            btn1.Click += btnNumber_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(78, 172);
            btn2.Name = "btn2";
            btn2.Size = new Size(60, 50);
            btn2.TabIndex = 3;
            btn2.Text = "2";
            btn2.Click += btnNumber_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(144, 172);
            btn3.Name = "btn3";
            btn3.Size = new Size(60, 50);
            btn3.TabIndex = 4;
            btn3.Text = "3";
            btn3.Click += btnNumber_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(12, 116);
            btn4.Name = "btn4";
            btn4.Size = new Size(60, 50);
            btn4.TabIndex = 5;
            btn4.Text = "4";
            btn4.Click += btnNumber_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(78, 116);
            btn5.Name = "btn5";
            btn5.Size = new Size(60, 50);
            btn5.TabIndex = 6;
            btn5.Text = "5";
            btn5.Click += btnNumber_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(144, 116);
            btn6.Name = "btn6";
            btn6.Size = new Size(60, 50);
            btn6.TabIndex = 7;
            btn6.Text = "6";
            btn6.Click += btnNumber_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(12, 60);
            btn7.Name = "btn7";
            btn7.Size = new Size(60, 50);
            btn7.TabIndex = 8;
            btn7.Text = "7";
            btn7.Click += btnNumber_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(78, 60);
            btn8.Name = "btn8";
            btn8.Size = new Size(60, 50);
            btn8.TabIndex = 9;
            btn8.Text = "8";
            btn8.Click += btnNumber_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(144, 60);
            btn9.Name = "btn9";
            btn9.Size = new Size(60, 50);
            btn9.TabIndex = 10;
            btn9.Text = "9";
            btn9.Click += btnNumber_Click;
            // 
            // btnPlus
            // 
            btnPlus.Location = new Point(210, 228);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(60, 50);
            btnPlus.TabIndex = 11;
            btnPlus.Text = "+";
            btnPlus.Click += btnOperation_Click;
            // 
            // btnMinus
            // 
            btnMinus.Location = new Point(210, 172);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(60, 50);
            btnMinus.TabIndex = 12;
            btnMinus.Text = "-";
            btnMinus.Click += btnOperation_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.Location = new Point(210, 116);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(60, 50);
            btnMultiply.TabIndex = 13;
            btnMultiply.Text = "*";
            btnMultiply.Click += btnOperation_Click;
            // 
            // btnDivide
            // 
            btnDivide.Location = new Point(210, 60);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(60, 50);
            btnDivide.TabIndex = 14;
            btnDivide.Text = "/";
            btnDivide.Click += btnOperation_Click;
            // 
            // btnEquals
            // 
            btnEquals.Location = new Point(144, 228);
            btnEquals.Name = "btnEquals";
            btnEquals.Size = new Size(60, 50);
            btnEquals.TabIndex = 15;
            btnEquals.Text = "=";
            btnEquals.Click += btnEquals_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(12, 284);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(258, 40);
            btnClear.TabIndex = 16;
            btnClear.Text = "C";
            btnClear.Click += btnClear_Click;
            // 
            // btnComma
            // 
            btnComma.Location = new Point(78, 228);
            btnComma.Name = "btnComma";
            btnComma.Size = new Size(60, 50);
            btnComma.TabIndex = 17;
            btnComma.Text = ",";
            btnComma.Click += btnComma_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(291, 336);
            Controls.Add(txtDisplay);
            Controls.Add(btn0);
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btn4);
            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btn7);
            Controls.Add(btn8);
            Controls.Add(btn9);
            Controls.Add(btnPlus);
            Controls.Add(btnMinus);
            Controls.Add(btnMultiply);
            Controls.Add(btnDivide);
            Controls.Add(btnEquals);
            Controls.Add(btnClear);
            Controls.Add(btnComma);
            Name = "Form1";
            Text = "Калькулятор";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}