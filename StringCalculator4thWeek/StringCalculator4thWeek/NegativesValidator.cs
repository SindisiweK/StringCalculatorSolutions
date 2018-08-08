using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator4thWeek
{
    public class NegativesValidator 
    {
        public void CheckNagativeValues(string input, IEnumerable<string> negativeValues)
        {
            if (negativeValues.Any())
            {
                throw new Exception($"Negative values are not allowed{input}");
            }
        }
    }
}