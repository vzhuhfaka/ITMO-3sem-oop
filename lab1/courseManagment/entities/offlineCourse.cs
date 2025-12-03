public class OfflineCourse : Course
{
    public string Сlassroom {get; set;}

    public OfflineCourse (int courseCode, string name, string classroom) : base(courseCode, name)
    {
        Сlassroom = classroom;
    }
}