using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;

namespace StringCalculatorFourth
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var results = SkipDelimeters(input);
            ThrowExceptionErrorMessage(input, results);
   
            var sum = results.Where(x => int.Parse(x) <= 1000).Sum(int.Parse);
            return sum;
        }

        private static void ThrowExceptionErrorMessage(string input, IEnumerable<string> results)
        {
            var negatives = results.Where(x => int.Parse(x) < 0);
            if (negatives.Any())
            {
                throw new Exception($"Negatives are forbbiden{input}");
            }
        }

        private static IEnumerable<string> SkipDelimeters(string input)
        {
            var separator = new char[] { ',', '\n', ';', '*', '#', '~', '$', '^', '%', '!', '|', '|' };
            var results = input.Replace("{", string.Empty)
                               .Replace("}", string.Empty)
                               .Replace("(", string.Empty)
                               .Replace(")", string.Empty)
                               .Replace("]", string.Empty)
                               .Replace("[", string.Empty)
                               .Replace("//", string.Empty)
                              .Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return results;
        }
    }
}