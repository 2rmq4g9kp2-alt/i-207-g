using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Calculator
{
    internal static class ConsoleDesign
    {
        internal const ConsoleColor Accent = ConsoleColor.Cyan;
        internal const ConsoleColor Success = ConsoleColor.Green;
        internal const ConsoleColor Error = ConsoleColor.Red;
        internal const ConsoleColor Menu = ConsoleColor.White;

      
        internal static void Init()
        {
            try { Console.OutputEncoding = Encoding.UTF8; } catch { }
            Console.Title = "Калькулятор";
            Console.SetOut(new DesignWriter(Console.Out));
        }
    }
    internal sealed class DesignWriter : TextWriter
    {
        private readonly TextWriter _inner;
        public DesignWriter(TextWriter inner) { _inner = inner; }
        public override Encoding Encoding => _inner.Encoding;

        public override void Write(char c) => Write(c.ToString());

        public override void Write(string s)
        {
            if (s == null) { _inner.Write(s); return; }

            var fragments = Classify(s);
            var old = Console.ForegroundColor;
            foreach (var (text, color) in fragments)
            {
                if (color.HasValue) Console.ForegroundColor = color.Value;
                _inner.Write(text);
            }
            Console.ForegroundColor = old;
        }
        private static List<(string text, ConsoleColor? color)> Classify(string s)
        {
            var list = new List<(string, ConsoleColor?)>();

         
            if (s.Contains("КАЛЬКУЛЯТОР"))
            {
                list.Add((s, ConsoleDesign.Accent));
                return list;
            }

            if (s.Contains("Результат"))
            {
                list.Add((s, ConsoleDesign.Success));
                return list;
            }

            if (s.Contains("Ошибка") || s.Contains("Нет такого") || s.Contains("Деление на ноль"))
            {
                list.Add((s, ConsoleDesign.Error));
                return list;
            }

            if (s.Contains("Выберите пункт"))
            {
                list.Add((s, ConsoleDesign.Accent));
                return list;
            }

            var trimmed = s.TrimStart();
            if (trimmed.Length > 2 && char.IsDigit(trimmed[0]) && trimmed[1] == '.')
            {
                int leading = s.Length - trimmed.Length;
                int cut = leading + 2;   
                list.Add((s.Substring(0, cut), ConsoleDesign.Accent));
                list.Add((s.Substring(cut), ConsoleDesign.Menu));
                return list;
            }

            list.Add((s, (ConsoleColor?)null));
            return list;
        }
    }
}