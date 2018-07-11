using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace StringCalculator2ndWeek
{
    public class StringCalculator
    {
      
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var output = SkipNonNumericalInput(input);
            EliminateNegativeValues(input, output);
            return CalculateSum(output);
        }

        private static int CalculateSum(IEnumerable<string> output)
        {
            return output.Where(x => int.Parse(x) <= 1000).Sum(int.Parse);
        }

        private static string[] SkipNonNumericalInput(string input)
        {
            var separator = new char[] { ',', '\n', ';', '*', '%', '$', '~', '^', '#', '|', '|', '!' };

            var output = input.Replace(")", string.Empty)
                              .Replace("(", string.Empty)
                              .Replace("}", string.Empty)
                              .Replace("{", string.Empty)
                              .Replace("]", string.Empty)
                              .Replace("[", string.Empty)
                              .Replace("//", string.Empty)
                              .Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return output;
        }

        private static void EliminateNegativeValues(string input, IEnumerable<string> output)
        {
            var negativeValues = output.Where(n => int.Parse(n) < 0);

            if (negativeValues.Any())
            {
                throw new Exception($"Negatives are not allowed{input}");
            }
        }
    }
}