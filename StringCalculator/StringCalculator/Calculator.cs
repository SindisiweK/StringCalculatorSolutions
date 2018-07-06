using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        
        public int Add(string input)
        {
            var sumOfValues = GetListOfValues(input);
            ReplaceDelimeter(input);
            return sumOfValues.Where(number => int.Parse(number) <= 1000).Sum(int.Parse);
        }
        private string ReplaceDelimeter(string input)
        {
            if (input.StartsWith("//"))
            {
                var replacer = input.Replace("//", string.Empty)[0];

                input = input.Replace("//", string.Empty)
                    .TrimStart(replacer)
                    .Replace(replacer, ',');
            }
            return input;
        }
        private static IEnumerable<string> GetListOfValues(string input)
        {
               var listOfNumbers = input
                   .Replace("[",string.Empty)
                   .Replace("]",string.Empty)
                    .Split(',', '/', '/', ';','\n','*','%','$','#','@','&','~','!','^')
                   .Where(n=>!n.Equals(string.Empty));

            GetErrorMessage(listOfNumbers);

            return listOfNumbers;
        }
        private static void GetErrorMessage(IEnumerable<string> input)
        {
            var negativeNumbers = input.Where(number => int.Parse(number) < 0);
          
            if (negativeNumbers.Any())
            {
                var negativeValues = string.Join(",", negativeNumbers.ToArray());
                throw new Exception($"Negative values are not allowed {negativeValues}");
            }
        }
    }
}