using System;
using System.Linq;

namespace Lesson3
{
    public static class MathWork
    {
        public static double Percent(double number, double percentage)
            => number * percentage / 100;

        public static double ReversePercent(double total, double percent)
            => total / (1 + percent / 100);

        public static double Multiply(double a, double b) => a * b;
        public static double Substract(double a, double b) => a - b;
        public static double Add(double a, double b) => a + b;

        public static double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Деление на ноль невозможно.");
            return a / b;
        }

        public static (int quotient, int remainder) DivRem(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException("Деление на ноль невозможно.");
            return (a / b, a % b);
        }
         
        public static long Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("Число должно быть неотрицательным.");
            long result = 1;
            for (int i = 2; i <= n; i++) result *= i;
            return result;
        }

        public static int SumArray(int[] arr) => arr.Sum();

        public static int MaxArray(int[] arr)
        {
            if (arr.Length == 0) throw new ArgumentException("Массив пуст.");
            return arr.Max();
        }

        public static int MinArray(int[] arr)
        {
            if (arr.Length == 0) throw new ArgumentException("Массив пуст.");
            return arr.Min();
        }

        public static void SortArray(int[] arr) => Array.Sort(arr);

        public static int[] InputArray()
        {
            int size = ReadInt("Введите размер массива: ");
            if (size <= 0) throw new ArgumentException("Размер должен быть положительным.");

            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
                arr[i] = ReadInt($"Введите элемент [{i}]: ");
            return arr;
        }

        public static void PrintArray(int[] arr)
            => Console.WriteLine("Элементы массива: " + string.Join(", ", arr));

        // Безопасное чтение чисел
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v)) return v;
                Console.Write("Ошибка: введите целое число.");
            }
        }

        public static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double v)) return v;
                Console.WriteLine("Ошибка: введите число.");
            }
        }
    }
}