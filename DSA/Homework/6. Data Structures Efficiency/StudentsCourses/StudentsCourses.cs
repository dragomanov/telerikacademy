/*
 * 1. A text file students.txt holds information about students and their courses in the following format: 
 * 
 * Kiril  | Ivanov   | C# 
 * Stefka | Nikolova | SQL 
 * Stela  | Mineva   | Java 
 * Milena | Petrova  | C# 
 * Ivan   | Grigorov | C# 
 * Ivan   | Kolev    | SQL 
 * 
 * Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them 
 * prints the students ordered by family and then by name: 
 * 
 * C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova 
 * Java: Stela Mineva 
 * SQL: Ivan Kolev, Stefka Nikolova 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentsCourses
{
    class StudentsCourses
    {
        static void Main(string[] args)
        {
            var studentsInCourses = GetStudentsFromFile();

            foreach (var course in studentsInCourses)
            {
                Console.WriteLine("{0}: {1}", course.Key, String.Join(", ", course.Value));
            }
        }

        private static IDictionary<string, List<string>> GetStudentsFromFile()
        {
            var studentsInCourses = new SortedDictionary<string, List<string>>();
            var allStudents = File.ReadAllLines(@"..\..\students.txt");
            foreach (var student in allStudents)
            {
                var studentArr = student.Split(new String[] { "|", " " }, StringSplitOptions.RemoveEmptyEntries);
                var studentName = studentArr[0] + " " + studentArr[1];
                var courseName = studentArr[2];

                if (studentsInCourses.ContainsKey(courseName))
                {
                    studentsInCourses[courseName].Add(studentName);
                }
                else
                {
                    studentsInCourses.Add(courseName, new List<string> { studentName });
                }
            }

            var sortedCourses = new SortedDictionary<string, List<string>>();
            foreach (var course in studentsInCourses)
            {
                var sortedStudents = course.Value
                    .Select(student => new { firstName = student.Split(' ')[0], lastName = student.Split(' ')[1]})
                    .OrderBy(student => student.lastName)
                    .ThenBy(student => student.firstName)
                    .Select(student => student.firstName + ' ' + student.lastName)
                    .ToList();
                sortedCourses.Add(course.Key, sortedStudents);
            }

            return sortedCourses;
        }
    }
}
