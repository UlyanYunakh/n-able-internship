namespace task_1.StudentSatistics
{
    public static class Statistics
    {
        public static Subject GetBestSubject(Student student)
        {
            if (student == null)
                return null;

            if (student.Subjects.Count <= 0)
                return null;

            Subject bestSubject = student.Subjects[0];

            foreach (var currSubject in student.Subjects)
                if (currSubject.Grade > bestSubject.Grade)
                    bestSubject = currSubject;

            return bestSubject;
        }

        public static Subject GetWorstSubject(Student student)
        {
            if (student == null)
                return null;

            if (student.Subjects.Count <= 0)
                return null;

            Subject worstSubject = student.Subjects[0];

            foreach (var currSubject in student.Subjects)
                if (currSubject.Grade < worstSubject.Grade)
                    worstSubject = currSubject;

            return worstSubject;
        }

        public static double GetAverageGrade(Student student)
        {
            double average = 0;

            foreach (var currSubject in student.Subjects)
                average += currSubject.Grade;

            average /= student.Subjects.Count;

            return average;
        }
    }
}