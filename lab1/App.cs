
public class App
{
    public static void Main()
    {
        CourseService courseService = new();
        TeacherService teacherService = new();
        StudentService studentService = new();
        Dictionary<int, string> courseCodeToName = new Dictionary<int, string>();
        Dictionary<int, string> teacherIdToName = new Dictionary<int, string>();

        // Создаем новых преподавателей
        teacherService.AddNewTeacher(1, "Кай", "Сенат");
        teacherService.AddNewTeacher(2, "Георгий", "Айсгергерт");
        teacherService.AddNewTeacher(3, "Кен", "Канеки");

        // Добавим с словарь расшифровой teacherid
        teacherIdToName.Add(0, "Преподаватель не назначен");
        teacherIdToName.Add(1, "Кай Сенат");
        teacherIdToName.Add(2, "Георгий Айсгергерт");
        teacherIdToName.Add(3, "Кен Канеки");

        // Создаем онлайн курсы
        courseService.CreateOnlineCourse(100, "Математический анализ", "https://zoom.com");
        courseService.CreateOnlineCourse(101, "Линейная алгебра", "https://zoom.com");

        // Создаем оффлайн курсы
        courseService.CreateOfflineCourse(102, "ООП", "1033");
        courseService.CreateOfflineCourse(103, "Базы данных", "3342");

        // Добавим с словарь расшифровкой courseCode
        courseCodeToName.Add(100, "Математический анализ");
        courseCodeToName.Add(101, "Линейная алгебра");
        courseCodeToName.Add(102, "ООП");
        courseCodeToName.Add(103, "Базы данных");

        // Создаем студентов
        studentService.CreateStudent(1, "Виталий", "Корнеплод");
        studentService.CreateStudent(2, "Анастасия", "Землеройка");

        // Добавляем студентов на курс
        courseService.AddStudentToCourse(103, 1);
        courseService.AddStudentToCourse(103, 2);
        
        // Добавим курсы к студентам
        studentService.AddCourseToStudent(1, 103);
        studentService.AddCourseToStudent(2, 103);

        // Прикрепим преподавателей к курсам
        courseService.AttachTeacher(101, 1);
        courseService.AttachTeacher(103, 2);

        // Добавим курсы к преподавателям
        teacherService.AddCourse(1, 101);
        teacherService.AddCourse(2, 103);

        // Можно получить список созданных курсов как экземпляры класса
        List<Course> allCourses = courseService.GetCourses();
        // Получим список со строками о имеющихся курсах
        Console.WriteLine("---Список со строками о имеющихся курсах---");
        List<string> allCoursesString = courseService.GetStringCourses(teacherIdToName);
        foreach (string i in allCoursesString)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();

        // Можно получить список преподавателей с курсами как эклезмпляры класса
        List<Teacher> allTeachers = teacherService.GetTeachers();
        // Получим список со строками о преподавателе
        // Нужно передать определенный teacherId
        int teacherIdForTest = 1;
        Console.WriteLine("---Список с курсами определенного преподавателя---");
        Console.WriteLine("Преподаватель: " + teacherIdToName[teacherIdForTest] + "("+"id="+teacherIdForTest+")");
        List<string> allTeachersString = teacherService.GetTeacherCourses(teacherIdForTest, courseCodeToName);
        foreach (string i in allTeachersString)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();

        // Получим информацию о студентах записанных на каждый курс
        int courseCodeForTest = 103;
        Console.WriteLine("---Список со студентами для определенного курса---");
        Console.WriteLine(courseCodeToName[courseCodeForTest] + "(" + "courseCode=" + courseCodeForTest.ToString() + ")");
        List<string>  StudentsAtCourse = studentService.GetStudentsInCourse(courseCodeForTest);
        foreach (string i in StudentsAtCourse)
        {
            Console.WriteLine(i);
        }

        // Возможность удалять курсы
        courseService.RemoveCourse(100);
        teacherService.RemoveCourse(100);
        // Получим список со строками о имеющихся курсах
        Console.WriteLine();
        Console.WriteLine("---Список со строками о имеющихся курсах(после удаления курса)---");
        List<string> allCoursesString1 = courseService.GetStringCourses(teacherIdToName);
        foreach (string i in allCoursesString1)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
    }
}