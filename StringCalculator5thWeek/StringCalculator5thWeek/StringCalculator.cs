using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator5thWeek
{
    public class StringCalculator
    {

        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }
            var outPut = EliminateDelimeters(input);
            CheckForNegatives(input, outPut);
            return GetSum(outPut);
        }

        private static int GetSum(IEnumerable<string> outPut)
        {
            return outPut.Where(x => int.Parse(x) < 1000 ).Sum(int.Parse);
        }

        private static void CheckForNegatives(string input, IEnumerable<string> outPut)
        {
            var negativeValues = outPut.Where(n => int.Parse(n) < 0);
            if (negativeValues.Any())
            {
                throw new Exception($"Negative values are forbiden{input}");
            }
        }

        private static string[] EliminateDelimeters(string input)
        {
            var separator = new char[] { ',', '\n', ';', '*', '<', '>', ':', '|', '@', '#', '$', '~', '`', '^', '&', '?', '!', '%' };
            var outPut = input
                .Replace(")", string.Empty)
                .Replace("(", string.Empty)
                .Replace("}", string.Empty)
                .Replace("{", string.Empty)
                .Replace("]", string.Empty)
                .Replace("[", string.Empty)
                .Replace("//", string.Empty)
                .Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return outPut;
        }
    }
}