using System;
using System.Collections.Generic;
using System.Linq;
using LinqTask.StudentStatistics;

namespace LinqTask
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintEvenArray(Enumerable.Range(0, 30).ToArray());
            PrintWordsThatStartWhitChar(
                new string[]
                {
                    "Не", "стреляйте",
                    "Я", "всего", "лишь", "робкий", "шепот",
                    "Всего", "лишь", "тихий", "вздох",
                    "Перед", "остановкой"
                }, 
                'р'
            );
            TestStudentStatisticsModule();
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
                str += $"\tBest subject: {Statistics.GetBestGrade(student).ToString()}\n";
                str += $"\tWorst subject: {Statistics.GetWorstGrade(student).ToString()}";
                Console.WriteLine(str);
            }
        }

        static void PrintWordsThatStartWhitChar(string[] words, char character)
        {
            var newWords = words.Where(s => s.First() == character);

            string str = $"Words that starts with {character}: ";

            foreach (var item in newWords)
            {
                str += $"{item} ";
            }

            Console.WriteLine(str);
        }

        static void PrintEvenArray(int[] array)
        {
            var evenNumbers = array.Where(i => i % 2 == 0);

            string str = "Even numbers: ";

            foreach (var item in evenNumbers)
            {
                str += $"{item} ";
            }

            Console.WriteLine(str);
        }
    }
}
