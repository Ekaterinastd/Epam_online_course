using System;
using System.Collections.Generic;
using System.Text;

namespace M4.Methods_in_details
{
    public static class DoubleExtension
    {
        public static string ToIEEE754Format(this double number)
        {
            var stringNumber = new StringBuilder();

            switch (number)
            {
                case double.MaxValue:
                    stringNumber.Append("0111111111101111111111111111111111111111111111111111111111111111");
                    break;
                case double.MinValue:
                    stringNumber.Append("1111111111101111111111111111111111111111111111111111111111111111");
                    break;
                case double.NaN:
                    stringNumber.Append("1111111111111000000000000000000000000000000000000000000000000000");
                    break;
                case double.PositiveInfinity:
                    stringNumber.Append("0111111111110000000000000000000000000000000000000000000000000000");
                    break;
                case double.NegativeInfinity:
                    stringNumber.Append("1111111111110000000000000000000000000000000000000000000000000000");
                    break;
                default:
                    {
                        stringNumber.Append(number >= 0 ? "0" : "1");//записываем знак числа

                        var part = Math.Abs(number).ToString().Split(',');
                        var firstPart = Convert.ToString(Convert.ToInt64(part[0]), 2); //двоичное представление части числа до ,
                        double secondPart = 0;

                        if (part.Length > 1)
                            secondPart = Convert.ToInt64(part[1]) * Math.Pow(10, -part[1].Length);// часть числа после ,

                        var binarySecondPart = new List<double>();

                        if (part.Length > 1)
                        {
                            while (true)
                            {
                                secondPart = secondPart * 2;
                                binarySecondPart.Add(Math.Truncate(secondPart));
                                secondPart = secondPart % 1;
                                if (secondPart == 0)
                                {
                                    binarySecondPart.Add(0);
                                    break;
                                }
                            }
                        }

                        var expWithOffset = Convert.ToString(firstPart.Length - 1 + 1023, 2);
                        foreach (var e in expWithOffset)
                            stringNumber.Append(e);
                        var mantissa = new string[52];
                        for (var i = 0; i < firstPart.Length - 1; i++)
                        {
                            mantissa[i] = firstPart.Substring(i + 1, 1);
                        }

                        if (part.Length > 1)
                        {
                            for (var i = 0; i < binarySecondPart.Count; i++)
                            {
                                if (firstPart.Length - 1 + i == 52)
                                    break;
                                else mantissa[firstPart.Length - 1 + i] = Convert.ToString(binarySecondPart[i]);
                            }
                        }
                        foreach (var m in mantissa)
                        {
                            if (m == null)
                                stringNumber.Append(0);
                            else stringNumber.Append(m);
                        }
                        break;
                    }
            }            

            return stringNumber.ToString();
        }
    }
}
