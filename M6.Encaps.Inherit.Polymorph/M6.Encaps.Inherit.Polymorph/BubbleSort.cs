using System;

namespace M6.Encaps.Inherit.Polymorph
{
    public class BubbleSort
    {
        public enum Criteria
        {
            Sum,
            Max,
            Min
        }

        /// <summary>
        /// Сортировка упорядочиванием строк матрицы.
        /// </summary>
        /// <param name="array">Матрица</param>
        /// <param name="criteria">Критерий</param>
        /// <param name="increase">По возрастанию</param>
        /// <returns></returns>
        public static int[,] GetBubbleSort(int[,] array, Criteria criteria, bool increase)
        {
            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            if (criteria == Criteria.Sum)
                return SortByLineSum(array, increase);
            else if (criteria == Criteria.Min)
                return SortByLineMin(array, increase);
            else if (criteria == Criteria.Max)
                return SortByLineMax(array, increase);
            else throw new ArgumentException("Invalid type");
        }

        /// <summary>
        /// Сортировка в порядке возрастания (убывания) сумм элементов строк матрицы.
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="increase">По возрастанию</param>
        /// <returns>Отсортированный массив</returns>
        private static int[,] SortByLineSum(int[,] array, bool increase)
        {
            var counter = 0;
            while (counter <= (array.GetLength(0) - 1) * array.GetLength(0) / 2)//цикл-счётчик итераций (и только!)
            {
                for (var i = 0; i < array.GetLength(0) - 1; i++)
                {
                    var sum1 = FindSum(array, i);

                    if (increase)
                    {
                        if (sum1 > FindSum(array, i + 1))
                        {
                            ExchangeLines(array, i);
                            break;
                        }
                    }
                    else
                    {
                        if (sum1 < FindSum(array, i + 1))
                        {
                            ExchangeLines(array, i);
                            break;
                        }
                    }

                }
                counter++;
            }

            return array;
        }

        private static int FindSum(int[,] array, int i)
        {
            var sum = 0;
            for (var j = 0; j < array.GetLength(1); j++)
                sum += array[i, j];
            return sum;
        }

        /// <summary>
        /// Сортировка в порядке возрастания (убывания) минимальных элементов строк матрицы.
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="increase">По возрастанию</param>
        /// <returns>Отсортированный массив</returns>
        private static int[,] SortByLineMin(int[,] array, bool increase)
        {
            var counter = 0;
            while (counter <= (array.GetLength(0) - 1) * array.GetLength(0) / 2)//цикл-счётчик итераций (и только!)
            {
                for (var i = 0; i < array.GetLength(0) - 1; i++)
                {
                    var min1 = FindMin(array, i);

                    if (increase)
                    {
                        if (min1 > FindMin(array, i + 1))
                        {
                            ExchangeLines(array, i);
                            break;
                        }
                    }
                    else
                    {
                        if (min1 < FindMin(array, i + 1))
                        {
                            ExchangeLines(array, i);
                            break;
                        }
                    }

                }
                counter++;
            }

            return array;
        }

        private static int FindMin(int[,] array, int i)
        {
            var min = array[i, 0];
            for (var j = 1; j < array.GetLength(1); j++)
            {
                if (min > array[i, j])
                    min = array[i, j];
            }
            return min;
        }

        /// <summary>
        /// Обмен i и i+1 строк массива.
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="i">Индекс строки</param>
        private static void ExchangeLines(int[,] array, int i)
        {
            for (var x = 0; x < array.GetLength(1); x++)
            {
                var temp = array[i, x];
                array[i, x] = array[i + 1, x];
                array[i + 1, x] = temp;
            }
        }

        /// <summary>
        /// Сортировка в порядке возрастания (убывания) максимальных элементов строк матрицы.
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="increase">По возрастанию</param>
        /// <returns>Отсортированный массив</returns>
        private static int[,] SortByLineMax(int[,] array, bool increase)
        {
            var counter = 0;
            while (counter <= (array.GetLength(0) - 1) * array.GetLength(0) / 2)//цикл-счётчик итераций (и только!)
            {
                for (var i = 0; i < array.GetLength(0) - 1; i++)
                {
                    var max1 = FindMax(array, i);

                    if (increase)
                    {
                        if (max1 > FindMax(array, i + 1))
                        {
                            ExchangeLines(array, i);
                            break;
                        }
                    }
                    else
                    {
                        if (max1 < FindMax(array, i + 1))
                        {
                            ExchangeLines(array, i);
                            break;
                        }
                    }
                }
                counter++;
            }

            return array;
        }

        private static int FindMax(int[,] array, int i)
        {
            var max = array[i, 0];
            for (var j = 1; j < array.GetLength(1); j++)
            {
                if (max < array[i, j])
                    max = array[i, j];
            }
            return max;
        }
    
    }
}
