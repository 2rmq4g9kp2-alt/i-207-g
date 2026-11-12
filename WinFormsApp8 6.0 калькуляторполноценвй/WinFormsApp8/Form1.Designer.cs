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
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnEquals = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnComma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDisplay
            // 
            this.txtDisplay.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDisplay.Location = new System.Drawing.Point(12, 12);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(260, 36);
            this.txtDisplay.TabIndex = 0;
            this.txtDisplay.Text = "0";
            this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(12, 228);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(60, 50);
            this.btn0.TabIndex = 1;
            this.btn0.Text = "0";
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(12, 172);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(60, 50);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "1";
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(78, 172);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(60, 50);
            this.btn2.TabIndex = 3;
            this.btn2.Text = "2";
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(144, 172);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(60, 50);
            this.btn3.TabIndex = 4;
            this.btn3.Text = "3";
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(12, 116);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(60, 50);
            this.btn4.TabIndex = 5;
            this.btn4.Text = "4";
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(78, 116);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(60, 50);
            this.btn5.TabIndex = 6;
            this.btn5.Text = "5";
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(144, 116);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(60, 50);
            this.btn6.TabIndex = 7;
            this.btn6.Text = "6";
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(12, 60);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(60, 50);
            this.btn7.TabIndex = 8;
            this.btn7.Text = "7";
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(78, 60);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(60, 50);
            this.btn8.TabIndex = 9;
            this.btn8.Text = "8";
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(144, 60);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(60, 50);
            this.btn9.TabIndex = 10;
            this.btn9.Text = "9";
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(210, 228);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(60, 50);
            this.btnPlus.TabIndex = 11;
            this.btnPlus.Text = "+";
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(210, 172);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(60, 50);
            this.btnMinus.TabIndex = 12;
            this.btnMinus.Text = "-";
            // 
            // btnMultiply
            // 
            this.btnMultiply.Location = new System.Drawing.Point(210, 116);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(60, 50);
            this.btnMultiply.TabIndex = 13;
            this.btnMultiply.Text = "*";
            // 
            // btnDivide
            // 
            this.btnDivide.Location = new System.Drawing.Point(210, 60);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(60, 50);
            this.btnDivide.TabIndex = 14;
            this.btnDivide.Text = "/";
            // 
            // btnEquals
            // 
            this.btnEquals.Location = new System.Drawing.Point(144, 228);
            this.btnEquals.Name = "btnEquals";
            this.btnEquals.Size = new System.Drawing.Size(60, 50);
            this.btnEquals.TabIndex = 15;
            this.btnEquals.Text = "=";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 284);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(258, 40);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "C";
            // 
            // btnComma
            // 
            this.btnComma.Location = new System.Drawing.Point(78, 228);
            this.btnComma.Name = "btnComma";
            this.btnComma.Size = new System.Drawing.Size(60, 50);
            this.btnComma.TabIndex = 17;
            this.btnComma.Text = ",";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(283, 334);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnEquals);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnComma);
            this.Name = "Form1";
            this.Text = "Калькулятор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}