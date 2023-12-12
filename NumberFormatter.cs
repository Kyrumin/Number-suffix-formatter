using System;

namespace Kyrumin
{
    public static class NumberFormatter
    {
        private static readonly string[] suffixes = {"", "K", "M", "B", "T"};

        public static string FormatNumber<T>(T num) where T : struct, IComparable, IFormattable, IConvertible
        {
            if (num.CompareTo(Convert.ChangeType(0, typeof(T))) == 0) return "0";

            double value = Convert.ToDouble(num);
            int suffixIndex = 0;

            while (suffixIndex + 1 < suffixes.Length && value >= 1000d)
            {
                value /= 1000d;
                suffixIndex++;
            }

            // Возвращаем отформатированное число с соответствующим суффиксом
            return value.ToString("#.##") + suffixes[suffixIndex];
        }
    }
}