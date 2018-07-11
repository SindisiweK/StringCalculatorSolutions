using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace StringCalculatorScnd
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }
            var results = EliminateNonNumerics(input);
            ThrowExceptionForNegativeValues(input, results);
            return GetSum(results);
        }

        private static void ThrowExceptionForNegativeValues(string input, IEnumerable<string> results)
        {
            var negativeValues = results.Where(x => int.Parse(x) < 0);
            if (negativeValues.Any())
            {
                throw new Exception($"Negatives are not allowed{input}");
            }
        }

        private static string[] EliminateNonNumerics(string input)
        {
            var eliminator = new char[] { ',', '\n', ';', '*', '!', '~', '$', '@', '^', '%', '|', '|', '&', '#', '!', '`', ':', '?' };
            var results = input.Replace("]", string.Empty)
                               .Replace("[", string.Empty)
                               .Replace("}", string.Empty)
                               .Replace("{", string.Empty)
                               .Replace(")", string.Empty)
                               .Replace("(", string.Empty)
                               .Replace("//", string.Empty)
                               .Split(eliminator, StringSplitOptions.RemoveEmptyEntries);
            return results;
        }

        private static int GetSum(IEnumerable<string> results)
        {
            return results.Where(x => int.Parse(x) <= 1000).Sum(int.Parse);
        }
    }
}