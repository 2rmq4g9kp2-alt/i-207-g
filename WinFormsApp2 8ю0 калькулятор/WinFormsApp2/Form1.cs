using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        double firstNumber = 0;
        string operation = "";
        bool isNewNumber = true;
        bool hasError = false;

        // новое: пам€ть дл€ повторного "="
        double lastOperand = 0;
        string lastOperation = "";

        public Form1()
        {
            InitializeComponent();
        }

        //  нопки цифр (0-9)
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

        //  нопки операций (+, -, *, /)
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
                SetError("ќшибка");
                return;
            }

            operation = btn.Text;
            isNewNumber = true;
        }

        //  нопка "=" Ч теперь повтор€ет последнюю операцию
        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (hasError) return;

            double left, right;
            string op;

            if (operation != "")
            {
                // обычный расчЄт: firstNumber <op> введЄнное число
                if (!double.TryParse(txtDisplay.Text, out right))
                {
                    SetError("ќшибка");
                    return;
                }
                left = firstNumber;
                op = operation;
            }
            else
            {
                // повтор: текущее число на экране <op> lastOperand
                if (lastOperation == "" || !isNewNumber) return;
                if (!double.TryParse(txtDisplay.Text, out left))
                {
                    SetError("ќшибка");
                    return;
                }
                right = lastOperand;
                op = lastOperation;
            }

            double result;
            switch (op)
            {
                case "+": result = left + right; break;
                case "-": result = left - right; break;
                case "*": result = left * right; break;
                case "/":
                    if (right == 0)
                    {
                        SetError("ƒеление на 0");
                        return;
                    }
                    result = left / right;
                    break;
                default:
                    return;
            }

            if (double.IsNaN(result) || double.IsInfinity(result))
            {
                SetError("ќшибка");
                return;
            }

            txtDisplay.Text = result.ToString();
            firstNumber = result;          // следующа€ операци€ начнЄтс€ от результата
            lastOperation = op;            // запоминаем, чтобы повтор€ть по "="
            lastOperand = right;
            isNewNumber = true;
            operation = "";
        }

        // ќбщий обработчик ошибки
        private void SetError(string message)
        {
            txtDisplay.Text = message;
            hasError = true;
            isNewNumber = true;
            operation = "";
        }

        //  нопка "C" (очистить) Ч сбрасываем и пам€ть повтора
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            operation = "";
            lastOperation = "";
            lastOperand = 0;
            isNewNumber = true;
            hasError = false;
        }

        //  нопка "," (зап€та€ дл€ дробей)
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