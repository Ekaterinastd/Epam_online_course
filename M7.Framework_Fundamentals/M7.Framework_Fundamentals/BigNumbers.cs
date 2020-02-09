using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7.Framework_Fundamentals
{
    public static class BigNumbers
    {
        public static string GetSum(string n1, string n2)
        {
            if (n1.Length == 0 && n2.Length == 0)
                return "0";
            var result = new StringBuilder();
            n1 = Reverse(n1);
            n2 = Reverse(n2);
            var remainder = 0;
            var sum = 0;
            for (var i = 0; i < Math.Max(n1.Length, n2.Length); i++)
            {
                sum = i >= n1.Length ? 0 : n1[i] - '0';
                sum += i >= n2.Length ? 0 : n2[i] - '0';
                sum += remainder;
                if (sum > 9)
                {
                    remainder = 1;
                    sum -= 10;
                }
                else
                    remainder = 0;
                
                result.Append(sum);
            }
            return Reverse(result.ToString());
        }

        private static string Reverse(string input)
        {
            var symbols = input.ToCharArray();
            Array.Reverse(symbols);
            return new string(symbols);
        }
    }
}
