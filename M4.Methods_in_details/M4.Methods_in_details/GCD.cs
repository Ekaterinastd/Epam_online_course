using System;

namespace M4.Methods_in_details
{
    public class GCD
    {
        /// <summary>
        /// Вычисление НОД по алгоритму Евклида для двух, трех и т.д. целых чисел
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>НОД</returns>
        public static int EuclideanAlgorithm(params int[] numbers)
        {
            int gcd = numbers[0];

            for (var i = 1; i < numbers.Length; i++)
                gcd = GetGCDEuclidean(gcd, numbers[i]);

            return gcd;
        }

        /// <summary>
        /// Вычисление НОД для пары целых чисел по алгоритму Евклида
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>НОД двух чисел</returns>
        private static int GetGCDEuclidean(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException();
            if (b == 0)
                return Math.Abs(a);
            return GetGCDEuclidean(b, a % b);
        }

        public static int SteinAlgoritm(params int[] numbers)
        {
            int gcd = numbers[0];

            for (var i = 1; i < numbers.Length; i++)
                gcd = GetGCDEuclidean(gcd, numbers[i]);

            return gcd;
        }

        /// <summary>
        /// Вычисление НОД для пары целых чисел по алгоритму Стейна
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>НОД двух чисел</returns>
        private static int GetGCDStein(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException();

            if (a % 2 == 0)
                if (b % 2 == 0)
                    return GetGCDStein(a / 2, b / 2) * 2;
                else return GetGCDStein(a / 2, b);
            else
            {
                if (b % 2 == 0)
                    return GetGCDStein(a, b / 2);
                else if (a >= b)
                    return GetGCDStein((a - b) / 2, b);
                else return GetGCDStein(a, (b - a) / 2);
            }
        }
    }
}
