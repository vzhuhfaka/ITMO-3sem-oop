public class StudentService
{
    private readonly List<Student> Students = [];
    public void CreateStudent(int studentId, string name, string surname)
    {
        Student student = new Student(studentId, name, surname);
        Students.Add(student);
    }
    public void AddCourseToStudent(int studentId, int courseCode)
    {
        Student? foundStudent = FindByStudentId(studentId);
        if (foundStudent != null)
        {
            foundStudent.AddCourse(courseCode);
        } else
        {
            throw new Exception("foundTeacher is not found");
        }
    }
    public void RemoveCourse(int courseCode)
    {
        foreach (Student student in Students)
        {
            if (student.GetCourseCodes().Contains(courseCode))
            {
                student.RemoveCourse(courseCode);
            }
        }
    }
    public List<string> GetStudentsInCourse(int courseCode)
    {
        List<string> studentsAtCourse = [];
        int countStudents = 1;
        foreach (Student student in Students)
        {
            if (student.GetCourseCodes().Contains(courseCode))
            {
                string s = $"{countStudents}. {student.Name} {student.Surname}(studentId={student.StudentId})";
                studentsAtCourse.Add(s);
                countStudents++;
            }
        }
        return studentsAtCourse;
    }
    private Student? FindByStudentId(int studentId)
    {
        foreach (Student i in Students)
        {
            if (i.StudentId == studentId)
            {
                return i;
            }
        }
        return null;
    }
}