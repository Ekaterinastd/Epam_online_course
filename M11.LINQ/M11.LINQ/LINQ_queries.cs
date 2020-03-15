using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace M11.LINQ
{
    public class LINQ_queries
    {
        public static  BinarySearchTree<Student> ReadFile(Func<Student, Student, int> comparator = null)
        {
            if (comparator == null)
            {
                comparator = new Func<Student, Student, int>((s1, s2) => s1.Name.CompareTo(s2.Name));
            }

            var students = new[] {
                new Student("Bill", "Math", new DateTime(2020,01,02),89),
                new Student("Bill", "Literature", new DateTime(2020,01,02),89),
                new Student("Colin", "Math", new DateTime(2020,01,03),71),
                new Student("Colin", "Literature", new DateTime(2020,09,03),71),
                new Student("Jeff", "Math", new DateTime(2020,01,02),65),
                new Student("Jeff", "Literature", new DateTime(2020,11,02),65),
                new Student("Max", "Math", new DateTime(2020,01,03),55),
                new Student("Max", "Literature", new DateTime(2020,01,04),55),
                new Student("Steve", "Math", new DateTime(2020,01,02),90),
                new Student("Steve", "Literature", new DateTime(2020,01,02),90)
            };

            var serializer = new XmlSerializer(typeof(Student[]));
            using (var stream = new FileStream(Path.GetPathRoot(@"M11.LINQ\M11.LINQ\bin\Debug") + "studentsResult.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, students);
            }
            Student[] list;
            using (var stream = new FileStream(Path.GetPathRoot(@"M11.LINQ\M11.LINQ\bin\Debug") + "studentsResult.xml", FileMode.OpenOrCreate))
            {
                list = serializer.Deserialize(stream) as Student[];
            }
            var tree = new BinarySearchTree<Student>(comparator);
            foreach (var el in list)
            {
                tree.Add(el);
            }
            return tree;
        }

        public enum Criteria
        {
            ByName,
            ByTest,
            ByDate,
            ByAssessment
        }

        public static List<Student> GetResults(Criteria criteria, int numberOfRows=int.MaxValue, bool descending=false)//добавить критерий
        {
            var result = new List<Student>();
            BinarySearchTree<Student> tree;

            if(criteria==Criteria.ByName)
                tree = ReadFile();
            else if (criteria == Criteria.ByTest)
                tree = ReadFile((s1, s2) => s1.Test.CompareTo(s2.Test));
            else if (criteria == Criteria.ByDate)
                tree = ReadFile((s1, s2) => s1.Date.CompareTo(s2.Date));
            else
                tree = ReadFile((s1, s2) => s1.Assessment.CompareTo(s2.Assessment));

            result = tree.InOrderTraversal().Take(numberOfRows).ToList();
            if (descending)
                result.Reverse();
            return result;
        }
    }
}
