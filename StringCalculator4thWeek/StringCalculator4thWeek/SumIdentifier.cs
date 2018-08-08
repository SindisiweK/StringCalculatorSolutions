using System.Collections.Generic;
using System.Linq;

namespace StringCalculator4thWeek
{
    public class SumIdentifier 
    {
        public int GetSum(IEnumerable<string> outPut)
        {
            return outPut.Where(x => int.Parse(x) <= 1000).Sum(int.Parse);
        }
    }
}