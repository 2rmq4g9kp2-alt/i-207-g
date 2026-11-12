using System;

namespace Lesson3
{
    public class GUIConsolApp
    {
        private static void PrintMenu()
        {
            Console.Write("\nВыберите задачу:\n");
            Console.Write("0  - счёт процентов\n");
            Console.Write("1  - умножение\n");
            Console.Write("2  - деление\n");
            Console.Write("3  - вычитание\n");
            Console.Write("4  - сложение\n");
            Console.Write("5  - сумма массива\n");
            Console.Write("6  - вывод массива\n");
            Console.Write("7  - максимум\n");
            Console.Write("8  - минимум\n");
            Console.Write("9  - факториал\n");
            Console.Write("10 - деление с остатком\n");
            Console.Write("11 - обратное процентам\n");
            Console.Write("12 - сортировка массива\n");
            Console.Write("Номер задачи: ");
        }
        public static void Run()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                PrintMenu();
                string choice = Console.ReadLine()?.Trim();

                try
                {
                    if (choice == "0")
                    {
                        Console.Write($"Результат: {MathWork.Percent(MathWork.ReadDouble("Число: "), MathWork.ReadDouble("Процент: ")):F2}");
                    }
                    else if (choice == "1")
                    {
                        Console.Write($"Результат: {MathWork.Multiply(MathWork.ReadDouble("A: "), MathWork.ReadDouble("B: "))}");
                    }
                    else if (choice == "2")
                    {
                        Console.Write($"Результат: {MathWork.Divide(MathWork.ReadDouble("A: "), MathWork.ReadDouble("B: "))}");
                    }
                    else if (choice == "3")
                    {
                        Console.Write($"Результат: {MathWork.Substract(MathWork.ReadDouble("A: "), MathWork.ReadDouble("B: "))}");
                    }
                    else if (choice == "4")
                    {
                        Console.Write($"Результат: {MathWork.Add(MathWork.ReadDouble("A: "), MathWork.ReadDouble("B: "))}");
                    }
                    else if (choice == "5")
                    {
                        Console.Write($"Сумма: {MathWork.SumArray(MathWork.InputArray())}");
                    }
                    else if (choice == "6")
                    {
                        MathWork.PrintArray(MathWork.InputArray());
                    }
                    else if (choice == "7")
                    {
                        Console.Write($"Максимум: {MathWork.MaxArray(MathWork.InputArray())}");
                    }
                    else if (choice == "8")
                    {
                        Console.Write($"Минимум: {MathWork.MinArray(MathWork.InputArray())}");
                    }
                    else if (choice == "9")
                    {
                        Console.Write($"Факториал: {MathWork.Factorial(MathWork.ReadInt("Введите N: "))}");
                    }
                    else if (choice == "10")
                    {
                        var (q, r) = MathWork.DivRem(MathWork.ReadInt("Делимое: "), MathWork.ReadInt("Делитель: "));
                        Console.Write($"Целая часть: {q}, остаток: {r}");
                    }
                    else if (choice == "11")
                    {
                        Console.Write($"Без процентов: {MathWork.ReversePercent(MathWork.ReadDouble("Сумма: "), MathWork.ReadDouble("Процент: ")):F2}");
                    }
                    else if (choice == "12")
                    {
                        var arr = MathWork.InputArray();
                        MathWork.SortArray(arr);
                        MathWork.PrintArray(arr);
                    }
                    else
                    {
                        Console.Write("Неверный пункт меню.");
                    }
                }
                catch (Exception ex)
                {
                    Console.Write($"Ошибка: {ex.Message}");
                }

                Console.Write("\nПродолжить? (пробел — да, y/yes/д/да — да, иначе — выход): ");
                string raw = Console.ReadLine() ?? "";
                string answer = raw.Trim().ToLower();

                if (string.IsNullOrEmpty(raw) || raw == " " || answer == "y" || answer == "yes" || answer == "д" || answer == "да")
                {
                    Console.Clear();
                }
                else
                {
                    keepRunning = false;
                }
            }

            Console.Write("Программа завершена!");
        }
    }
}