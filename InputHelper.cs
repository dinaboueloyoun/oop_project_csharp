using System;

namespace ExaminationSystem
{
    public static class InputHelper
    {
        public static string ReadNonEmptyString(string prompt, bool forbidNumeric = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(input))
                {
                    UI.ShowWarning("Value cannot be empty. Try again.");
                    continue;
                }
                if (forbidNumeric && IsNumericOnly(input))
                {
                    UI.ShowWarning("Numbers are not allowed here. Enter text.");
                    continue;
                }
                return input.Trim();
            }
        }

        public static int ReadIntInRange(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (!int.TryParse(input, out int val))
                {
                    UI.ShowWarning("Enter a valid integer.");
                    continue;
                }
                if (val < min || val > max)
                {
                    UI.ShowWarning($"Enter a number between {min} and {max}.");
                    continue;
                }
                return val;
            }
        }

        public static double ReadDoubleNonNegative(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (!double.TryParse(input, out double val))
                {
                    UI.ShowWarning("Enter a valid number.");
                    continue;
                }
                if (val < 0)
                {
                    UI.ShowWarning("Value must be >= 0.");
                    continue;
                }
                return val;
            }
        }

        private static bool IsNumericOnly(string s)
        {
            s = s.Trim();
            if (string.IsNullOrEmpty(s)) return false;
            foreach (char c in s)
                if (!char.IsDigit(c)) return false;
            return true;
        }
    }
}
