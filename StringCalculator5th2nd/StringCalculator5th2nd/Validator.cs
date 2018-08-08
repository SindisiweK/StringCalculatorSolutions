using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator5th2nd
{
    public class Validator
    {
        public void ValidateNegativeValues(string input, IEnumerable<string> outPut)
        {
            var negativeValues = outPut.Where(n => int.Parse(n) < 0);
            if (negativeValues.Any())
            {
                throw new Exception($"Negative values are restricted{input}");
            }
        }

        public string[] SeparateDelimeters(string input)
        {
            var separator = new char[] { ',', '\n', ';', '*', '&', '^', '%', '#', '@', '!', '~', '<', '>', '|', '`', ':', '?', '_', '!', '.', '$' };
            var outPut = input.Replace(")", string.Empty)
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