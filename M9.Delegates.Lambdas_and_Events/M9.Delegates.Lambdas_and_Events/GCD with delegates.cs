using System;
using System.Diagnostics;

namespace M9.Delegates.Lambdas_and_Events
{
    public class GCD
    {
        static Func<int, int, int> Algorithm = GetGCDEuclidean;


        /// <summary>
        /// Вычисление НОД по алгоритму Евклида для двух, трех и т.д. целых чисел
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>НОД</returns>
        public static int EuclideanAlgorithm(params int[] numbers)
        {
            int gcd = numbers[0];

            for (var i = 1; i < numbers.Length; i++)
                gcd = Algorithm(gcd, numbers[i]);

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
            return Algorithm(b, a % b);
        }

        public static int SteinAlgoritm(params int[] numbers)
        {
            int gcd = numbers[0];
            Algorithm = GetGCDStein;

            for (var i = 1; i < numbers.Length; i++)
                gcd = Algorithm(gcd, numbers[i]);

            return gcd;
        }

        /// <summary>
        /// Вычисление НОД для пары целых чисел по алгоритму Стейна
        /// </summary>
        /// <param name="a">первое число</param>
        /// <param name="b">второе число</param>
        /// <returns>НОД двух чисел</returns>
        private static int GetGCDStein(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException();

            if (a % 2 == 0)
                if (b % 2 == 0)
                    return Algorithm(a / 2, b / 2) * 2;
                else return Algorithm(a / 2, b);
            else
            {
                if (b % 2 == 0)
                    return Algorithm(a, b / 2);
                else if (a >= b)
                    return Algorithm((a - b) / 2, b);
                else return Algorithm(a, (b - a) / 2);
            }
        }

        /// <summary>
        /// Время поиска НОД по определённому алгоритму
        /// </summary>
        /// <param name="method">Название метода поиска НОД</param>
        /// <param name="numbers">Входные данные для метода поиска НОД</param>
        /// <returns>Время</returns>
        public static long GetRuntime(Func<int[], int> method, params int[] numbers)
        {
            var sw = new Stopwatch();
            sw.Start();
            method(numbers);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}

