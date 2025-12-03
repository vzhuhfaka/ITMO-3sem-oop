public class Student : Person
{
    public int StudentId;
    public List<int> GetCourseCodes()
    {
        return new List<int>(CourseCodes);
    }
    public Student(int studentId, string name, string surname) : base (name, surname)
    {
        StudentId = studentId;
    }
}