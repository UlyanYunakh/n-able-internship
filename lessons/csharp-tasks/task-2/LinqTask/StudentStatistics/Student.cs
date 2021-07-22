using System.Collections.Generic;

namespace LinqTask.StudentStatistics
{
    public class Student
    {
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}