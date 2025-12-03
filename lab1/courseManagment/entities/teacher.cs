public class Teacher : Person
{
    public int TeacherId {get; set;}

    public List<int> GetCourseCodes()
    {
        return new List<int>(CourseCodes);
    }
    public Teacher (int teacherId, string name, string surname) : base (name, surname)
    {
        TeacherId = teacherId;
    }
}