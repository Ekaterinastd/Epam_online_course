using System;
using System.Collections.Generic;

namespace M10.Generics_and_Collections
{
    public class Book : IComparable
    {
        public Book(string name, int amount, int year)
        {
            Name = name;
            Amount = amount;
            Year = year;
        }

        public string Name { get; private set; }
        public int Amount { get; private set; }
        public int Year { get; private set; }


        public int CompareTo(object obj)
        {
            return this.Name.CompareTo((obj as Book).Name);
        }

        public override bool Equals(object obj)
        {
            var book = obj as Book;
            return book != null &&
                   Name == book.Name &&
                   Amount == book.Amount &&
                   Year == book.Year;
        }

        public override int GetHashCode()
        {
            var hashCode = -341310605;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            return hashCode;
        }
    }
}
