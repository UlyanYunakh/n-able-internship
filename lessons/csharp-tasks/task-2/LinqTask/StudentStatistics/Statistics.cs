using System.Linq;

namespace LinqTask.StudentStatistics
{
    public static class Statistics
    {
        public static Subject GetBestGrade(Student student)
        {
            if (student == null)
                return null;

            if (student.Subjects.Count <= 0)
                return null;

            var bestGrade = student.Subjects.OrderByDescending(s=> s.Grade).First();

            return bestGrade;
        }

        public static Subject GetWorstGrade(Student student)
        {
            if (student == null)
                return null;

            if (student.Subjects.Count <= 0)
                return null;

            var worstGrade = student.Subjects.OrderBy(s=> s.Grade).First();

            return worstGrade;
        }

        public static double GetAverageGrade(Student student)
        {
            var average = student.Subjects.Select(s => s.Grade).Average();

            return average;
        }
    }
}