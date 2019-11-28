using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace M2.Basic_Coding
{
    public class Program
    {
        /// <summary>
        /// Вставка битов с j-ого по i-ый одного числа в другое
        /// </summary>
        /// <param name="firstNum">число, в которое вставляются биты второго</param>
        /// <param name="secondNum">число, биты которого вставляются в первое</param>
        /// <param name="i">первая позиция</param>
        /// <param name="j">последняя позиция</param>
        /// <returns></returns>
        public static int InsertNumber(int firstNum, int secondNum, int i, int j)
        {
            if (i > j)
                throw new ArgumentException("i must be less then j");
            if (i < 0 || j < 0 || i > 31 || j > 31)
                throw new ArgumentNullException("i and j must belong to the interval [0;31]");
            var binResult = new char[32];
            var binFirstNum = Convert.ToString(firstNum, 2);

            for (var x = 0; x < binFirstNum.Length; x++)
                binResult[binResult.Length - binFirstNum.Length + x] = binFirstNum[x];

            var binSecondNum = Convert.ToString(secondNum, 2);
            var index = j - i;

            for (var x = j; x >= i; x--)
            {
                if (index >= binSecondNum.Length)
                    binResult[binResult.Length - 1 - x] = (char)0;
                else binResult[binResult.Length - 1 - x] = binSecondNum[binSecondNum.Length-index-1];
                index--;
            }

            var binStringResult = new string(binResult);
            binStringResult = binStringResult.Substring(binStringResult.Length - Math.Max(binFirstNum.Length, j));
            var decResult = 0;

            for (var x = 0; x < binStringResult.Length; x++)
            {
                if (binStringResult[binStringResult.Length - 1 - x] == '1')
                    decResult += (int)Math.Pow(2, x);
            }

            return decResult;
        }

        /// <summary>
        /// Поиск максимума в неотсортированном целочисленном массиве
        /// </summary>
        /// <param name="array">массив чисел</param>
        /// <param name="startInd">индекс начала подмассива</param>
        /// <param name="endInd">индекс конца подмассива</param>
        /// <returns>максимальный элемент</returns>
        public static int GetMax(int[] array, int startInd, int endInd)
        {
            if (array.Length == 1)
                return array[0];
            else
            {
                while (startInd != endInd)
                {
                    var temp1 = GetMax(array, startInd, (startInd + endInd) / 2);
                    var temp2 = GetMax(array, (startInd + endInd) / 2 + 1, endInd);
                    return Math.Max(temp1, temp2);
                }
                return array[startInd];
            }
        }

        /// <summary>
        /// Поиск в вещественном массиве индекса элемента, для которого сумма элементов слева и сумма элементов справа равны.
        /// </summary>
        /// <param name="array">массив вещественных чисел</param>
        /// <param name="index">индекс элемента</param>
        /// <returns></returns>
        public static int GetIndexEqualSum(double[] array, int index)
        {
            if (index == array.Length - 1)
                return -1;
            if (array.Length == 0)
                return -1;

            var rightSum = 0.0;
            var leftSum = 0.0;

            for (var i = 0; i < index; i++)
                leftSum += array[i];

            for (var i = index + 1; i < array.Length; i++)
                rightSum += array[i];

            if (Math.Round(leftSum, 10) == Math.Round(rightSum, 10))
                return index;
            else
                return GetIndexEqualSum(array, index + 1);
        }

        /// <summary>
        /// Конкатенации двух строк, содержащих только символы латинского алфавита, исключая повторяющиеся символы.
        /// </summary>
        /// <param name="s1">первая строка</param>
        /// <param name="s2">вторая строка</param>
        /// <returns></returns>
        public static string ConcatStringsWithDifSymbols(string s1, string s2)
        {
            foreach (var symb in s1)
                if (!char.IsLetter(symb) || symb < 'A' || symb > 'z')
                    throw new ArgumentException("Strings must consisit latin letters only");
            foreach (var symb in s2)
                if (!char.IsLetter(symb) || symb < 'A' || symb > 'z')
                    throw new ArgumentException("Strings must consisit latin letters only");
            foreach (var symb in s2)
                if (!s1.Contains(symb))
                    s1 += symb;
            return s1;
        }

        /// <summary>
        /// Составление ближайшего наибольшего целого из цифр исходного числа
        /// </summary>
        /// <param name="number">исходное число</param>
        /// <returns>Ближайшее большее целое из цифр исходного числа</returns>
        public static int FindNextBiggerNumber(int number)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            if (number < 0)
                throw new ArgumentException("number must be positive");
            if (number <= 11)
                return -1;
          
            var result = GetPermutationsList(number);

            time.Stop();
            var timeFind = time.ElapsedMilliseconds;

            if (result.Count > 0)
                return result.Min();
            else return -1;            
        }

        private static List<int> biggerNumbersList;

        /// <summary>
        /// Получает список всех перестановок
        /// </summary>
        /// <param name="num">Исходное число</param>
        /// <returns>Список перестановок, где каждая больше исходного числа</returns>
        private static List<int> GetPermutationsList(int num)
        {
            var strNum = num.ToString();
            biggerNumbersList = new List<int> ();
            RecPermutation(strNum.ToArray(), strNum.Length, num);
            return biggerNumbersList;
        }

        /// <summary>
        /// Рекурсивный поиск всех перестановок
        /// </summary>
        /// <param name="numeral">массив цифр исходного числа</param>
        /// <param name="n">длина числа</param>
        /// <param name="number">исходное число</param>
        private static void RecPermutation(char[] numeral, int n, int number)
        {
            for (var i = 0; i < n; i++)
            {
                var temp = numeral[n - 1];
                for (var j = n - 1; j > 0; j--)
                {
                    numeral[j] = numeral[j - 1];
                }
                numeral[0] = temp;
                if (i < n - 1) AddToList(numeral, number);
                if (n > 0) RecPermutation(numeral, n - 1,number);
            }
        }

        /// <summary>
        /// Добавляет новую перестановку в список, если она больше исходного числа
        /// </summary>
        /// <param name="numeral">Массив символов</param>
        /// <param name="number">исходное число</param>
        private static void AddToList(char[] numeral, int number)
        {
            var bufer = new StringBuilder("");
            for (int i = 0; i < numeral.Count(); i++)
            {
                bufer.Append(numeral[i]);
            }
            if (!biggerNumbersList.Contains(Convert.ToInt32(bufer.ToString())) && Convert.ToInt32(bufer.ToString()) > number)
            {
                biggerNumbersList.Add(Convert.ToInt32(bufer.ToString()));
            }
        }

        public static int[] FilterDigit(int[] fullArray, int num)
        {
            var result = new List<int>();
            foreach (var el in fullArray)
                if (el.ToString().Contains(num.ToString()))
                    result.Add(el);
            if (result.Count == 0)
                throw new ArgumentException("Array doesn't contains this number");
            else return result.ToArray();
        }

        static void Main(string[] args)
        {
            var res = InsertNumber(9,13,4,9);
            //var r2 = GetMax(new int[] { 5, 1, -2, 0, 10, 3 }, 0, 5);
            var r3 = GetIndexEqualSum(new double[0], 0);
            //var r4 = ConcatStringsWithDifSymbols("aslkmf", "stpaz");
            
        }
    }
}
