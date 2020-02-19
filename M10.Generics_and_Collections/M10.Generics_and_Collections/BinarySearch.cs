using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10.Generics_and_Collections
{
    public class BinarySearch
    {
        public static int BinarySearchGeneric<T>(List<T> collection, T element)where T:IComparable
        {
            //отсортировать collection
            var left = 0;
            var right = 0;

            right = (collection as List<T>).Count - 1;
            while (left < right)
            {
                var middle = (right + left) / 2;
                if (collection.ElementAt(middle).CompareTo(element)<=0)
                    right = middle;
                else left = middle + 1;
            }
            if (collection.ElementAt(right).CompareTo(element)==0)
                return right;

            return -1;
        }
    }
}
