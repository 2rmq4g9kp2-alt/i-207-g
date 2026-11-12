using System;

namespace Calculator
{
    internal class calculator
    {
        static void Main(string[] args)
        {
            var math = new CalculatorMath();
            while (true)
            {
                Console.Write("\n КАЛЬКУЛЯТОР \n");
                Console.Write(" 1. Сложение (+)\n");
                Console.Write(" 2. Вычитание (-)\n");
                Console.Write(" 3. Умножение (*)\n");
                Console.Write(" 4. Деление (/)\n");
                Console.Write(" 0. Выход\n");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();
                Console.Write("\n");

                if (choice == "0") break;

                switch (choice)
                {
                    case "1": TwoNumbers(math.Addition, "сложения"); break;
                    case "2": TwoNumbers(math.Subtraction, "вычитания"); break;
                    case "3": TwoNumbers(math.Multiplication, "умножения"); break;
                    case "4": TwoNumbers(math.Divider, "деления"); break;

                    default:
                        Console.Write("Нет такого пункта.\n");
                        break;
                }
            }
        }

        static void TwoNumbers(Func<double, double, double> op, string name)
        {
            Console.Write("Введите первое число: ");
            double x = ReadDouble();
            Console.Write("Введите второе число: ");
            double y = ReadDouble();
            Console.Write($"Результат {name}: {op(x, y)}\n");
        }

        static double ReadDouble()
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (double.TryParse(s?.Replace('.', ','), out double v))
                    return v;
                Console.Write("Ошибка. Введите число: ");
            }
        }
    }
}