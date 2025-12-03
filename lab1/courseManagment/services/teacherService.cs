public class TeacherService
{
    private readonly List<Teacher> Teachers = [];
    public void AddNewTeacher(int teacherId, string name, string surname)
    {
        Teacher teacher = new(teacherId, name, surname);
        Teachers.Add(teacher);
    }
    public void AddCourse(int teacherId, int courseCode)
    {
        Teacher? foundTeacher = FindByTeacherId(teacherId);
        if (foundTeacher != null)
        {
            foundTeacher.AddCourse(courseCode);
        } else
        {
            throw new Exception("foundTeacher is not found");
        }
    }
    public void RemoveCourse(int courseCode)
    {
        foreach (Teacher teacher in Teachers)
        {
            if (teacher.GetCourseCodes().Contains(courseCode))
            {
                teacher.RemoveCourse(courseCode);
            }
        }
    }
    public List<Teacher> GetTeachers()
    {
        return new List<Teacher>(Teachers);
    }
    public List<string> GetTeacherCourses(int teacherId, Dictionary<int, string> courseCodeToName)
    {
        List<string> courseNames = [];
        int countCourses = 1;
        foreach (Teacher teacher in Teachers)
        {
            if (teacher.TeacherId == teacherId)
            {
                List<int> courses = teacher.GetCourseCodes();
                foreach (int i in courses)
                {
                    string coursename = countCourses.ToString() + ". " + courseCodeToName[i];
                    courseNames.Add(coursename);
                    countCourses++;
                }
            }
        }
        return courseNames;
    }
    private Teacher? FindByTeacherId(int teacherId)
    {
        foreach (Teacher i in Teachers)
        {
            if (i.TeacherId == teacherId)
            {
                return i;
            }
        }
        return null;
    }
}