using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4.Methods_in_details
{
    public static class DoubleExtension
    {
        public static string ToIEEE754Format(this double number)
        {
            var stringNumber = new StringBuilder();

            stringNumber.Append(number > 0 ? "0" : "1");//записываем знак числа

            var part = Math.Abs(number).ToString().Split(',');
            var firstPart = Convert.ToString(Convert.ToInt32(part[0]),2); //двоичное представление части числа до ,
            var secondPart = Convert.ToInt32(part[1])*Math.Pow(10,-part[1].Length);
            var b = 0.5;
            var sum = 0.0;
            var degree = 1;
            var temp = 0.0;
            var binarySecondPart = new List<byte>();
            while (true)
            {
                if (Math.Abs(sum - secondPart) < 0.0000000001)
                    break;
                temp = Math.Pow(b, degree);
                if (sum + temp <= secondPart)
                {
                    sum += temp;
                    binarySecondPart.Add(1);
                }
                else
                    binarySecondPart.Add(0);
                degree++;
            }
            var binSPart = new StringBuilder();
            foreach(var s in binarySecondPart)
                binSPart.Append(s == 0 ? "0" : "1");

            var fPMant = new StringBuilder();
            fPMant.Append(firstPart.Substring(firstPart.IndexOf('1') + 1));//какой должна быть длина и как её задать?
            while (fPMant.Length < 7)
                fPMant.Append(0);

            var exp = 128 - 1 + fPMant.Length;
            stringNumber.Append(Convert.ToString(exp,2));

            var mantissa = fPMant.ToString() + binSPart;
            stringNumber.Append(mantissa);

            return stringNumber.ToString();
        }
    }
}
