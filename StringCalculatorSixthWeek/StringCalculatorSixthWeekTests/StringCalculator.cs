using System;
using System.Linq;

namespace StringCalculatorSixthWeek
{
    public class StringCalculator
    {
        private readonly DelimeterValidation _delimeterValidation = new DelimeterValidation();

        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var outPut = _delimeterValidation.SeparateDelimeters(input);
            _delimeterValidation.ValiadateNegativeValues(input, outPut);
            var sum = outPut.Where(x => int.Parse(x) <= 1000).Sum(int.Parse);
            return sum;
        }
    }
}