using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M11.LINQ
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Test { get; set; }
        public DateTime Date { get; set; }
        public double Assessment { get; set; }

        public Student(string name, string test, DateTime date, double assessment)
        {
            Name = name;
            Test = test;
            Date = date;
            Assessment = assessment;
        }

        public Student()
        {
        }

        public override string ToString()
        {
            return Name + " " + Test + " " + Date + " " + Assessment;
        }

        public override bool Equals(object obj)
        {
            var s = (Student)obj;
            return Name == s.Name && Test == s.Test && Date == s.Date && Assessment == s.Assessment;
        }
    }
}
