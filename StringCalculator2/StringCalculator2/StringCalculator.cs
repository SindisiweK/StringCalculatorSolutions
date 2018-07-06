using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator2
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }
            var sumOfValues = EliminateDelimeters(input);
            var SumOfInput = sumOfValues.Where(x => int.Parse(x) <= 1000).Sum(int.Parse);
            return SumOfInput;
        }

        private static IEnumerable<string> EliminateDelimeters(string input)
        {
            var separator = new char[] { ',', '\n', ';', '*', '~', '!', '`', '@', '$', '%','#','^'};
            var result = input.Replace("//", string.Empty)
                              .Replace("[", string.Empty)
                              .Replace("]", string.Empty)
                              .Replace("{", string.Empty)
                              .Replace("}", string.Empty)
                              .Replace("(",string.Empty)
                              .Replace(")",string.Empty)
                              .Split(separator, StringSplitOptions.RemoveEmptyEntries);
            ExceptionErrorMessage(result);
            return result;
        }
     
        private static void ExceptionErrorMessage(IEnumerable<string> input)
        {
            var negativeValues = input.Where(x => int.Parse(x) < 0);

            if (negativeValues.Any())
            {
                var negativeNumbers = string.Join(",", negativeValues.ToArray());
                throw new Exception($"Negatives are not allowed{negativeNumbers}");
            }
        }



    }
}