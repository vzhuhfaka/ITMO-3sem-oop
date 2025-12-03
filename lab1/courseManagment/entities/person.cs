public abstract class Person
{
    public string? Name {get; set;}
    public string? Surname {get; set;}
    protected readonly List<int> CourseCodes = [];
    public void AddCourse(int courseCode)
    {
        CourseCodes.Add(courseCode);
    }
    public void RemoveCourse(int courseCode)
    {
        CourseCodes.Remove(courseCode);
    }
    public Person(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
}