using System.Collections.Generic;

namespace M7.Framework_Fundamentals
{
    public static class UniqueInOrder
    {
        public static new List<T> GetUniqueInOrder<T>(IEnumerable<T> input)
        {
            var listOfSymbols = new List<T>();
            T buff = default (T);
            foreach(var symb in input)
            {
                if (!buff.Equals(symb))
                    listOfSymbols.Add(symb);
                buff = symb;
            }
            return listOfSymbols;
        }
    }
}
