using M6.Encaps.Inherit.Polymorph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BubbleSortTests
{
    [TestClass]
    public class BubbleSortTest
    {
        void Test(int[,] array, BubbleSort.Criteria criteria, bool increase, int[,] expected)
        {
            CollectionAssert.AreEqual(BubbleSort.GetBubbleSort(array, criteria, increase), expected);
        }

        [TestMethod]
        public void SumSortByIncreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, BubbleSort.Criteria.Sum, true, new int[,] { { 0, 2, 5 }, { 7, 8, 9 }, { 10, 20, 3 } });
        }

        [TestMethod]
        public void SumSortByIncreaseTest2()
        {
            Test(new int[,] { { 0, 2, 5 }, { 7, 8, 9 }, { 10, 20, 3 } }, BubbleSort.Criteria.Sum, true, new int[,] { { 0, 2, 5 }, { 7, 8, 9 }, { 10, 20, 3 } });
        }

        [TestMethod]
        public void SumSortByIncreaseTest3()
        {
            Test(new int[,] { { 1, 2, 0 }, { 10, 2, 2 }, { 9, 1, 1 }, { 3, 3, 3 }, { 0, 0, 0 } }, BubbleSort.Criteria.Sum, true, new int[,] { { 0, 0, 0 }, { 1, 2, 0 }, { 3, 3, 3 }, { 9, 1, 1 }, { 10, 2, 2 } });
        }

        [TestMethod]
        public void SumSortByDecreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, BubbleSort.Criteria.Sum, false, new int[,] { { 10, 20, 3 }, { 7, 8, 9 }, { 0, 2, 5 } });
        }

        [TestMethod]
        public void SumSortByDecreaseTest2()
        {
            Test(new int[,] { { 1, 2, 0 }, { 10, 2, 2 }, { 9, 1, 1 }, { 3, 3, 3 }, { 0, 0, 0 } }, BubbleSort.Criteria.Sum, false, new int[,] { { 10, 2, 2 }, { 9, 1, 1 }, { 3, 3, 3 }, { 1, 2, 0 }, { 0, 0, 0 } });
        }

        [TestMethod]
        public void MinSortByIncreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, BubbleSort.Criteria.Min, true, new int[,] { { 0, 2, 5 }, { 10, 20, 3 }, { 7, 8, 9 } });
        }

        [TestMethod]
        public void MinSortByIncreaseTest2()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 0, 0, 0 } }, BubbleSort.Criteria.Min, true, new int[,] { { 0, 0, 0 }, { 20, 2, 22 }, { 3, 13, 33 }, { 8, 18, 88 }, { 11, 11, 9 } });
        }

        [TestMethod]
        public void MinSortByIncreaseTest3()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 10, 10, 10 } }, BubbleSort.Criteria.Min, true, new int[,] { { 20, 2, 22 }, { 3, 13, 33 }, { 8, 18, 88 }, { 11, 11, 9 }, { 10, 10, 10 } });
        }

        [TestMethod]
        public void MinSortByDecreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, BubbleSort.Criteria.Min, false, new int[,] { { 7, 8, 9 }, { 10, 20, 3 }, { 0, 2, 5 } });
        }

        [TestMethod]
        public void MinSortByDecreaseTest2()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 0, 0, 0 } }, BubbleSort.Criteria.Min, false, new int[,] { { 11, 11, 9 }, { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 0, 0, 0 } });
        }

        [TestMethod]
        public void MaxSortByIncreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, BubbleSort.Criteria.Max, true, new int[,] { { 0, 2, 5 }, { 7, 8, 9 }, { 10, 20, 3 } });
        }

        [TestMethod]
        public void MaxSortByIncreaseTest2()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 0, 0, 0 } }, BubbleSort.Criteria.Max, true, new int[,] { { 0, 0, 0 }, { 11, 11, 9 }, { 20, 2, 22 }, { 3, 13, 33 }, { 8, 18, 88 } });
        }

        [TestMethod]
        public void MaxSortByIncreaseTest3()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 10, 10, 10 } }, BubbleSort.Criteria.Max, true, new int[,] { { 10, 10, 10 }, { 11, 11, 9 }, { 20, 2, 22 }, { 3, 13, 33 }, { 8, 18, 88 } });
        }

        [TestMethod]
        public void MaxSortByDecreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, BubbleSort.Criteria.Max, false, new int[,] { { 10, 20, 3 }, { 7, 8, 9 }, { 0, 2, 5 } });
        }

        [TestMethod]
        public void MaxSortByDecreaseTest2()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 0, 0, 0 } }, BubbleSort.Criteria.Max, false, new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 0, 0, 0 } });
        }
    }
}
