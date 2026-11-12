using System;
using System.Windows.Forms;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        double firstNumber = 0;
        string operation = "";
        bool isNewNumber = true;
        bool hasError = false;

        public Form1()
        {
            InitializeComponent();
        }

        // Кнопки цифр (0-9)
        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (hasError)
            {
                txtDisplay.Text = "0";
                hasError = false;
                isNewNumber = true;
            }

            if (isNewNumber)
            {
                txtDisplay.Text = btn.Text;
                isNewNumber = false;
            }
            else
            {
                if (txtDisplay.Text == "0")
                    txtDisplay.Text = btn.Text;
                else
                    txtDisplay.Text += btn.Text;
            }
        }

        // Кнопки операций (+, -, *, /)
        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (hasError)
            {
                txtDisplay.Text = "0";
                hasError = false;
                isNewNumber = true;
                return;
            }

            if (!double.TryParse(txtDisplay.Text, out firstNumber))
            {
                txtDisplay.Text = "Ошибка";
                hasError = true;
                isNewNumber = true;
                operation = "";
                return;
            }

            operation = btn.Text;
            isNewNumber = true;
        }

        // Кнопка "="
        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (hasError || operation == "") return;

            double secondNumber;
            if (!double.TryParse(txtDisplay.Text, out secondNumber))
            {
                txtDisplay.Text = "Ошибка";
                hasError = true;
                isNewNumber = true;
                operation = "";
                return;
            }

            double result = 0;

            switch (operation)
            {
                case "+": result = firstNumber + secondNumber; break;
                case "-": result = firstNumber - secondNumber; break;
                case "*": result = firstNumber * secondNumber; break;
                case "/":
                    if (secondNumber == 0)
                    {
                        txtDisplay.Text = "Деление на 0";
                        hasError = true;
                        isNewNumber = true;
                        operation = "";
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
                default:
                    return;
            }

            if (double.IsNaN(result) || double.IsInfinity(result))
            {
                txtDisplay.Text = "Ошибка";
                hasError = true;
            }
            else
            {
                txtDisplay.Text = result.ToString();
            }

            isNewNumber = true;
            operation = "";
        }

        // Кнопка "C" (очистить)
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            operation = "";
            isNewNumber = true;
            hasError = false;
        }

        // Кнопка "," (запятая для дробей)
        private void btnComma_Click(object sender, EventArgs e)
        {
            if (hasError)
            {
                txtDisplay.Text = "0";
                hasError = false;
                isNewNumber = true;
            }

            if (isNewNumber)
            {
                txtDisplay.Text = "0,";
                isNewNumber = false;
                return;
            }

            if (!txtDisplay.Text.Contains(","))
                txtDisplay.Text += ",";
        }
    }
}