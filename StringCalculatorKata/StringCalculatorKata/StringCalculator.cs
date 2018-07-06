using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
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

            var output = RemoveNonNumericInput(input);
            ThrowExceptionErrorMessage(output);
            var sum = output.Where(x => int.Parse(x) <= 1000).Sum(int.Parse);
            return sum;
        }

        private static void ThrowExceptionErrorMessage(IEnumerable<string> output)
        {
            var NegativeValues = output.Where(x => int.Parse(x) < 0);
            if (NegativeValues.Any())
            {
                var Negatives = string.Join(";", NegativeValues.ToArray());
                throw new Exception($"Negatives are not allowed{Negatives}");
            }
        }

        private static IEnumerable<string> RemoveNonNumericInput(string input)
        {
            var separator = new char[] { ',', '\n', ';' ,'*','#','~','$','^','%','!','|','|'};
            var output = input.Replace("//", string.Empty)
                              .Replace("[",string.Empty)
                              .Replace("]",string.Empty)
                              .Replace("{",string.Empty)
                              .Replace("}",string.Empty)
                              .Replace("(",string.Empty)
                              .Replace(")",string.Empty)
            .Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return output;
        }

       
    }
}