public class CourseService
{
    private readonly List<Course> Courses = [];
    public void CreateOnlineCourse(int courseCode, string name, string meetingLink)
    {
        OnlineCourse onlineCourse = new(courseCode, name, meetingLink);
        Courses.Add(onlineCourse);
    }
    public void CreateOfflineCourse(int courseCode, string name, string classroom)
    {
        OfflineCourse offlineCourse = new(courseCode, name, classroom);
        Courses.Add(offlineCourse);
    }
    public void RemoveCourse(int courseCode)
    {
        Course? courseToRemove = FindByCourseCode(courseCode);
        
        if (courseToRemove != null)
        {
            Courses.Remove(courseToRemove);
        }
        else
        {
            throw new Exception($"Course with code {courseCode} not found");
        }
    }
    public void AddStudentToCourse(int courseCode, int studentId)
    {
        Course? foundCourse = FindByCourseCode(courseCode);
        if (foundCourse != null)
        {
            foundCourse.AddStudent(studentId);
        } else
        {
            throw new Exception("foundCourse is not found");
        }
    }
    public void RemoveStudentFromCourse(int courseCode, int studentId)
    {
        Course? foundCourse = FindByCourseCode(courseCode);
        if (foundCourse != null)
        {
            foundCourse.RemoveStudent(studentId);
        } else
        {
            throw new Exception("foundCourse is not found");
        }
    }
    public void AttachTeacher(int courseCode, int teacherId)
    {
        Course? foundCourse = FindByCourseCode(courseCode);
        if (foundCourse != null)
        {
            foundCourse.TeacherId = teacherId;
        } else
        {
            throw new Exception("foundCourse is not found");
        }
    }
    public List<Course> GetCourses()
    {
        return new List<Course>(Courses);
    }
    public List<string> GetStringCourses(Dictionary<int, string> teacherIdToname)
    {
        List<string> courses = [];
        int countCourses = 1;
        foreach (Course course in Courses)
        {
            if (course is OnlineCourse online)
            {
                string s = $"{countCourses}. format: online; code: {online.CourseCode}; teacher: {teacherIdToname[online.TeacherId]}(id={online.TeacherId}); name: {online.Name}";
                courses.Add(s);
            } else if (course is OfflineCourse offline)
            {
                string s = $"{countCourses}. format: offline; code: {offline.CourseCode}; teacher: {teacherIdToname[offline.TeacherId]}(id={offline.TeacherId}); name: {offline.Name}";
                courses.Add(s);
            }
            countCourses++;
        }
        return courses;
    }
    private Course? FindByCourseCode(int courseCode)
    {
        foreach (Course i in Courses)
        {
            if (i.CourseCode == courseCode)
            {
                return i;
            }
        }
        return null;
    }
}