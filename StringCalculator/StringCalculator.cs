using System;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            return string.IsNullOrEmpty(numbers)
                       ? 0
                       : GetSum(numbers);
        }

        private static int GetSum(string numbers)
        {
            var delimiter = GetPossibleDelimiter;
            var newnumbers = numbers;

            if (HasSpecificDelimiter(numbers)) //for specific delimiters
            {
                delimiter = GetSpecificDelimiter(numbers);
                newnumbers = GetSpecificNumbers(numbers);
            }

            return ContainsAny(numbers, delimiter)
                       ? newnumbers.Split(delimiter.ToCharArray()).Sum(ParseToInt)
                       : ParseToInt(newnumbers);

        }

        private static bool HasSpecificDelimiter(string numbers) => numbers.StartsWith("//");

		private static readonly string GetPossibleDelimiter = ",\n";

		private static string GetSpecificDelimiter(string numbers) => numbers.Substring(2, numbers.IndexOf("\n", StringComparison.Ordinal) - 2);

        private static string GetSpecificNumbers(string numbers)
        {
            return numbers.Substring(numbers.IndexOf("\n", StringComparison.Ordinal) + 1,
                                     numbers.Length - numbers.IndexOf("\n", StringComparison.Ordinal) - 1);
        }
        private static int ParseToInt(string n)
        {
            int result = 0;
            if (!IsGreaterThanThousand(Convert.ToInt32(n)) && !string.IsNullOrEmpty(n))
                result = Convert.ToInt32(n);
            ValidateNumbersAsPerRule(result);

            return result;
        }

        private static bool IsGreaterThanThousand(int nn) => nn > 1000;


        private static bool ContainsAny(string input, string getPossibleDelimiters) => getPossibleDelimiters.ToCharArray().Any(input.Contains);

        private static void ValidateNumbersAsPerRule(int number)
        {
            if (number < 0)
                throw new ArgumentException(
                    $"string contains [{number}], which does not meet rule. entered number should not negative.");
        }
    }
}
