using M3.Creating_types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaskMethods.Test
{
    [TestClass]
    public class FindNthRootTest
    {
        void Test(double number, double degree, double accurancy, double expected)
        {
            Assert.AreEqual(Methods.FindNthRoot(number, degree, accurancy), expected, accurancy);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Test(1, 5, 0.0001, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Test(8, 3, 0.0001, 2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Test(0.001, 3, 0.0001, 0.1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Test(0.04100625, 4, 0.0001, 0.45);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Test(8, 3, 0.0001, 2);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Test(0.0279936, 7, 0.0001, 0.6);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Test(0.0081, 4, 0.1, 0.3);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Test(-0.008, 3, 0.1, -0.2);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Test(0.004241979, 9, 0.00000001, 0.545);
        }
    }

    [TestClass]
    public class BubbleSortTest
    {
        void Test(int[,] array, Methods.Criteria criteria, bool increase, int[,] expected)
        {
            CollectionAssert.AreEqual(Methods.BubbleSort(array, criteria, increase), expected);
        }

        [TestMethod]
        public void SumSortByIncreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, Methods.Criteria.Sum, true, new int[,] { { 0, 2, 5 }, { 7, 8, 9 }, { 10, 20, 3 } });
        }

        [TestMethod]
        public void SumSortByIncreaseTest2()
        {
            Test(new int[,] { { 0, 2, 5 }, { 7, 8, 9 }, { 10, 20, 3 } }, Methods.Criteria.Sum, true, new int[,] { { 0, 2, 5 }, { 7, 8, 9 }, { 10, 20, 3 } });
        }

        [TestMethod]
        public void SumSortByIncreaseTest3()
        {
            Test(new int[,] { { 1, 2, 0 }, { 10, 2, 2 }, { 9, 1, 1 }, { 3, 3, 3 }, { 0, 0, 0 } }, Methods.Criteria.Sum, true, new int[,] { { 0, 0, 0 }, { 1, 2, 0 }, { 3, 3, 3 }, { 9, 1, 1 }, { 10, 2, 2 } });
        }

        [TestMethod]
        public void SumSortByDecreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, Methods.Criteria.Sum, false, new int[,] { { 10, 20, 3 }, { 7, 8, 9 }, { 0, 2, 5 } });
        }

        [TestMethod]
        public void SumSortByDecreaseTest2()
        {
            Test(new int[,] { { 1, 2, 0 }, { 10, 2, 2 }, { 9, 1, 1 }, { 3, 3, 3 }, { 0, 0, 0 } }, Methods.Criteria.Sum, false, new int[,] { { 10, 2, 2 }, { 9, 1, 1 }, { 3, 3, 3 }, { 1, 2, 0 }, { 0, 0, 0 } });
        }

        [TestMethod]
        public void MinSortByIncreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, Methods.Criteria.Min, true, new int[,] { { 0, 2, 5 }, { 10, 20, 3 }, { 7, 8, 9 } });
        }

        [TestMethod]
        public void MinSortByIncreaseTest2()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 0, 0, 0 } }, Methods.Criteria.Min, true, new int[,] { { 0, 0, 0 }, { 20, 2, 22 }, { 3, 13, 33 }, { 8, 18, 88 }, { 11, 11, 9 } });
        }

        [TestMethod]
        public void MinSortByIncreaseTest3()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 10, 10, 10 } }, Methods.Criteria.Min, true, new int[,] { { 20, 2, 22 }, { 3, 13, 33 }, { 8, 18, 88 }, { 11, 11, 9 }, { 10, 10, 10 } });
        }

        [TestMethod]
        public void MinSortByDecreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, Methods.Criteria.Min, false, new int[,] { { 7, 8, 9 }, { 10, 20, 3 }, { 0, 2, 5 } });
        }

        [TestMethod]
        public void MinSortByDecreaseTest2()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 0, 0, 0 } }, Methods.Criteria.Min, false, new int[,] { { 11, 11, 9 }, { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 0, 0, 0 } });
        }

        [TestMethod]
        public void MaxSortByIncreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, Methods.Criteria.Max, true, new int[,] { { 0, 2, 5 }, { 7, 8, 9 }, { 10, 20, 3 } });
        }

        [TestMethod]
        public void MaxSortByIncreaseTest2()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 0, 0, 0 } }, Methods.Criteria.Max, true, new int[,] { { 0, 0, 0 }, { 11, 11, 9 }, { 20, 2, 22 }, { 3, 13, 33 }, { 8, 18, 88 } });
        }

        [TestMethod]
        public void MaxSortByIncreaseTest3()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 10, 10, 10 } }, Methods.Criteria.Max, true, new int[,] { { 10, 10, 10 }, { 11, 11, 9 }, { 20, 2, 22 }, { 3, 13, 33 }, { 8, 18, 88 } });
        }

        [TestMethod]
        public void MaxSortByDecreaseTest1()
        {
            Test(new int[,] { { 10, 20, 3 }, { 0, 2, 5 }, { 7, 8, 9 } }, Methods.Criteria.Max, false, new int[,] { { 10, 20, 3 }, { 7, 8, 9 }, { 0, 2, 5 } });
        }

        [TestMethod]
        public void MaxSortByDecreaseTest2()
        {
            Test(new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 0, 0, 0 } }, Methods.Criteria.Max, false, new int[,] { { 8, 18, 88 }, { 3, 13, 33 }, { 20, 2, 22 }, { 11, 11, 9 }, { 0, 0, 0 } });
        }
    }
}
