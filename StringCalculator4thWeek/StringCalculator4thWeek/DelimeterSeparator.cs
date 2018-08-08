using System;

namespace StringCalculator4thWeek
{
    public class DelimeterSeparator 
    {
        public string[] SeparateDelimeters(string input)
        {
            var separator = new char[] { ',', '\n', ';', '*', '<', '>', ':', '|', '@', '#', '$', '~', '`', '^', '&', '?', '!', '%' };
            var outPut = input.Replace("}", string.Empty)
                .Replace("{", string.Empty)
                .Replace(")", string.Empty)
                .Replace("(", string.Empty)
                .Replace("]", string.Empty)
                .Replace("[", string.Empty)
                .Replace("//", string.Empty)
                .Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return outPut;
        }
    }
}