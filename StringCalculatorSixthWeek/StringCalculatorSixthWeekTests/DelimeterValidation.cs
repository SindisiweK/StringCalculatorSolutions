using System;
using System.Linq;

namespace StringCalculatorSixthWeek
{
    public class DelimeterValidation
    {
        public string[] SeparateDelimeters(string input)
        {
            var separator = new char[] { ',', ';', '\n', ':', '.', '|', '*', '&', '^', '%', '$', '#', '@', '!', '~', '`', '<', '>', '?', '_' };
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

        public void ValiadateNegativeValues(string input, string[] outPut)
        {
            var negativeValues = outPut.Where(n => int.Parse(n) < 0);
            if (negativeValues.Any())
            {
                throw new Exception($"Negative values are not allowed{input}");
            }
        }
    }
}