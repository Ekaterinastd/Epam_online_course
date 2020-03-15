using System;
using System.Collections.Generic;
using System.Linq;

namespace M11.LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sort criteria (ByName, ByTest, ByDate, ByAssessment): ");
            var criteria = Console.ReadLine();

            Console.Write("Enter number of strings: ");
            var number = int.Parse(Console.ReadLine());
            Console.Write("Enter 1 if sort by descending, else any symbol: ");
            var descending = Console.ReadLine()=="1"? true: false;
            var result = new List<Student>();
            switch (criteria)
            {
                case "ByName":
                    result = LINQ_queries.GetResults(LINQ_queries.Criteria.ByName, number, descending);
                    break;
                case "ByTest":
                    result = LINQ_queries.GetResults(LINQ_queries.Criteria.ByTest, number, descending);
                    break;
                case "ByDate":
                    result = LINQ_queries.GetResults(LINQ_queries.Criteria.ByDate, number, descending);
                    break;
                case "ByAssessment":
                    result = LINQ_queries.GetResults(LINQ_queries.Criteria.ByAssessment, number, descending);
                    break;
                default:
                    throw new ArgumentException("This sort criteria doesn't exist");
            }
            Console.WriteLine("Result:");
            foreach (var r in result)
                Console.WriteLine(r.ToString());
            Console.ReadKey();
        }
    }
}
