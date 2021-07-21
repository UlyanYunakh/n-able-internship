namespace task_1.StudentStatistics
{
    public class Subject
    {
        public string Name { get; set; } = "NON";
        public double Grade { get; set; } = 0;

        public override string ToString() => $"{Name}, {Grade}";
    }
}