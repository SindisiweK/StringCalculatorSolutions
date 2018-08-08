using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator5th2nd
{
    public class StringCalculator
    {
        private readonly Validator _validator = new Validator();

        public object Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }
            var outPut = _validator.SeparateDelimeters(input);
            _validator.ValidateNegativeValues(input, outPut);
            var sum = outPut.Where(x => int.Parse(x) <= 1000).Sum(int.Parse);
            return sum;
        } 
    }
}