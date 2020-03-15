using M11.LINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTests
{
    [TestClass]
    public class Tests
    {
        List<Student> allStudents = new List<Student> {
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

        [TestMethod]
        public void AllByNameTest()
        {
            var students = allStudents;
            CollectionAssert.AreEqual(students, LINQ_queries.GetResults(LINQ_queries.Criteria.ByName));
        }

        [TestMethod]
        public void PartByNameTest()
        {
            var students = allStudents.Take(5).ToList();
            CollectionAssert.AreEqual(students, LINQ_queries.GetResults(LINQ_queries.Criteria.ByName,5));
        }

        [TestMethod]
        public void AllByNameDesTest()
        {
            var students = allStudents;
            CollectionAssert.AreEqual(students, LINQ_queries.GetResults(LINQ_queries.Criteria.ByName, descending: true));
        }

        [TestMethod]
        public void AllByTest_Test()
        {
            var students = new List<Student> {
                allStudents[1],
                allStudents[3],
                allStudents[5],
                allStudents[7],
                allStudents[9],
                allStudents[0],
                allStudents[2],
                allStudents[4],
                allStudents[6],
                allStudents[8],                
            };
            CollectionAssert.AreEqual(students, LINQ_queries.GetResults(LINQ_queries.Criteria.ByTest));
        }

        [TestMethod]
        public void AllByDateTest()
        {
            var students = new List<Student> {
                allStudents[0],
                allStudents[1],
                allStudents[4],
                allStudents[8],
                allStudents[9],
                allStudents[2],
                allStudents[6],
                allStudents[7],
                allStudents[3],
                allStudents[5],                
            };
            CollectionAssert.AreEqual(students, LINQ_queries.GetResults(LINQ_queries.Criteria.ByDate));
        }

        [TestMethod]
        public void AllByAssessmentTest()
        {
            var students = new List<Student> {
                allStudents[6],
                allStudents[7],
                allStudents[4],
                allStudents[5],
                allStudents[2],
                allStudents[3],
                allStudents[0],
                allStudents[1],
                allStudents[8],
                allStudents[9],
            };
            CollectionAssert.AreEqual(students, LINQ_queries.GetResults(LINQ_queries.Criteria.ByAssessment));
        }
    }
}
