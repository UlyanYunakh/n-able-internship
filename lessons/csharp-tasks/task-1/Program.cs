using System;
using System.Collections.Generic;
using task_1.StudentStatistics;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestStudentStatisticsModule();
            TestDelegateModule();
        }

        static void TestDelegateModule()
        {
            Console.WriteLine("\nDelegate test 1: \n");
            TestValidateMethod();
            
            Console.WriteLine("\nDelegate test 2: \n");
            TestFormatMethod();
        }

        static void TestFormatMethod()
        {
            int[] intArray = new int[10]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            string intStr = "Array: ";
            foreach (var item in intArray)
            {
                intStr += item + " ";
            }
            Console.WriteLine(intStr);

            ArrayHelper.FormatArray<int>(intArray, (int item) => item + 10);

            intStr = "Formatted array: ";
            foreach (var item in intArray)
            {
                intStr += item + " ";
            }
            Console.WriteLine(intStr);
        }

        static void TestValidateMethod()
        {
            int[] intArray = new int[10]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            string intStr = "Array 1: ";
            foreach (var item in intArray)
            {
                intStr += item + " ";
            }
            Console.WriteLine(intStr);

            bool result = ArrayHelper.ValidateArrayItems<int>(intArray, (int item) => item > 0);
            Console.WriteLine($"Every item of Array 1 is greater than zero? Answer: {result}");

            intArray = new int[10]
            {
                1, 2, -3, 4, 5, -6, 7, 8, 9, 10
            };

            intStr = "Array 2: ";
            foreach (var item in intArray)
            {
                intStr += item + " ";
            }
            Console.WriteLine(intStr);

            result = ArrayHelper.ValidateArrayItems<int>(intArray, (int item) => item > 0);
            Console.WriteLine($"Every item of Array 2 is greater than zero? Answer: {result}");
        }

        static void TestStudentStatisticsModule()
        {
            string[] subjectNamesArray = new string[10]
            {
                "PE", "Math", "Physics", "Art", "Grammar", "History", "Literature",
                "Programming", "Biology", "Philosophy"
            };

            string[] studentNamesArray = new string[5]
            {
                "John Lennon", "Paul Atreides", "Asuka Soryu Langley",
                "Akira", "Kenada"
            };

            List<Student> studentsList = new List<Student>();
            Random rnd = new Random();

            foreach (var studentName in studentNamesArray)
            {
                List<Subject> subjectList = new List<Subject>();

                foreach (var subjectName in subjectNamesArray)
                    subjectList.Add(new Subject()
                    {
                        Name = subjectName,
                        Grade = rnd.Next(0, 100)
                    });

                studentsList.Add(new Student()
                {
                    Name = studentName,
                    Subjects = subjectList
                });
            }

            foreach (var student in studentsList)
            {
                string str = $"\n{student.Name} statistics: \n";
                str += $"\tAvarage grade: {Statistics.GetAverageGrade(student)}\n";
                str += $"\tBest subject: {Statistics.GetBestSubject(student).ToString()}\n";
                str += $"\tWorst subject: {Statistics.GetWorstSubject(student).ToString()}";
                Console.WriteLine(str);
            }
        }
    }
}
