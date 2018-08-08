using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator4thWeek
{
    public class StringCalculator
    {
        private readonly DelimeterSeparator _delimeterSeparator = new DelimeterSeparator();
        private readonly NegativesValidator _negativesValidator = new NegativesValidator();
        private readonly SumIdentifier _sumIdentifier = new SumIdentifier();

        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;
            var outPut = _delimeterSeparator.SeparateDelimeters(input);
            var negativeValues = outPut.Where(n => int.Parse(n) < 0);
            _negativesValidator.CheckNagativeValues(input, negativeValues);
            return _sumIdentifier.GetSum(outPut);
        }
    }
}