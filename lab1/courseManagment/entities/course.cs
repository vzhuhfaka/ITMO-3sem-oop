public abstract class Course
{
    public string Name {get; set;}
    public int CourseCode {get; set;}
    public int TeacherId {get; set;} 
    
    public readonly List<int> StudentIds = [];
    public void AddStudent(int studentId)
    {
        StudentIds.Add(studentId);
    }
    public void RemoveStudent(int studentId)
    {
        StudentIds.Remove(studentId);
    }
    public Course(int courseCode, string name)
    {
        Name = name;
        CourseCode = courseCode;
    }
}