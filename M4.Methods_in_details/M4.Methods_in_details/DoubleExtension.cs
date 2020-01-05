using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M4.Methods_in_details
{
    public static class DoubleExtension
    {
        const int mantissaLength = 52;

        /// <summary>
        /// Приведение числа с плавающей точкой к формату IEEE754
        /// </summary>
        /// <param name="number">Исходное десятичное число</param>
        /// <returns>Исходное число в формате IEEE754</returns>
        public static string ToIEEE754Format(this double number)
        {
            var stringNumber = new StringBuilder();
            var sign = Math.Sign(-0.0);

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
                case double.Epsilon:
                    stringNumber.Append("0000000000000000000000000000000000000000000000000000000000000001");
                    break;
                default:
                    {
                        stringNumber.Append(number >= 0 ? "0" : "1"); // записываем знак числа

                        var parts = Math.Abs(number).ToString().Split(',');
                        var firstPart = Convert.ToString(Convert.ToInt64(parts[0]), 2); // двоичное представление части числа до ,

                        var binarySecondPart = GetSecondPart(parts);
                        var exp =  firstPart.Length - (firstPart + new string(binarySecondPart.Select(x=>(char)(x+'0')).ToArray())).IndexOf('1');
                        var expWithOffset = Convert.ToString(1023 + exp - 1, 2);

                        while (expWithOffset.Length < 11)
                            expWithOffset = "0" + expWithOffset;

                        foreach (var e in expWithOffset)
                            stringNumber.Append(e);

                       var mantissa = firstPart + new string(binarySecondPart.Select(x => (char)(x + '0')).ToArray());

                        mantissa = mantissa.TrimStart('0').Substring(1);
                        while (mantissa.Length < 52)
                            mantissa += '0';
                        mantissa = mantissa.Substring(0, 52);
                        foreach (var m in mantissa)
                            stringNumber.Append(m);
                        break;
                    }
            }

            return stringNumber.ToString();
        }

        /// <summary>
        /// Приведение дробной части числа к бинарному виду
        /// </summary>
        /// <param name="parts">Целая и дробная часть числа</param>
        /// <returns>Дробная часть числа в бинарном виде</returns>
        private static List<double> GetSecondPart(string[] parts)
        {
            double secondPart = 0;
            if (parts.Length > 1)
                secondPart = Convert.ToInt64(parts[1]) * Math.Pow(10, -parts[1].Length);// часть числа после ,
            var binarySecondPart = new List<double>();

            if (parts.Length > 1)
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

            return binarySecondPart;
        }
    }
}
