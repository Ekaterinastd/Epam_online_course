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
            int IsAllNull = 0;
            foreach (var n in numbers)
                if (n != 0)
                    IsAllNull += 1;
            if (IsAllNull==0)
                throw new ArgumentException();

            int gsd=numbers[0];

            for (var i = 1; i < numbers.Length; i++)
                gsd = GetGCDEuclidean(gsd, numbers[i]);

            return gsd;
        }

        private static int GetGCDEuclidean(int a, int b)
        {
            if(a==0&& b==0)
                throw new ArgumentException();
            if (b == 0)
                return Math.Abs(a);
            return GetGCDEuclidean(b, a % b);
        }
    }
}
