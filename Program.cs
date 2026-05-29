using SchoolApp.Models;


SchoolManager schoolmanager = new SchoolManager();

string? studentname;
string? coursecode;
string? teacher;
string? coursename;
string? Courseid;
string? Studentid;
string? Grade;





static bool tryParse(string? text)
{
    //check if text is able to convert to int
    if (string.IsNullOrEmpty(text)|| !int.TryParse(text, out int result))
    {
        return false;
    }

    else   
    {
        return true;
    }

}



while (true)
{
    

    Console.WriteLine("\n\n-------------------- Welcome To The Student Managment System ---------------------\n\n");

    Console.WriteLine("\n1 ----> Add Student \n2 ----> Add Course \n3 ----> Enroll Student into Course  \n4 ----> Assign Grade to Student \n5 ----> Get All Students \n6 ----> Get specific Student Enrollment\n7 ----> Show All Courses");

    Console.WriteLine("\n\nEnter Input: ");


    int UserInput = Convert.ToInt32(Console.ReadLine());

    switch(UserInput)
    {
        

        case 1:
            Console.WriteLine("\n\nEnter Student Name:");

            studentname = Console.ReadLine();

            if (string.IsNullOrEmpty(studentname))
            {
                Console.WriteLine("\n\nInvalid student name.");
                break;
            }
            schoolmanager.AddStudent(studentname);
            break;

        case 2:
            Console.WriteLine("\n\nEnter Course Code:");

            coursecode = Console.ReadLine();

            Console.WriteLine("\n\nEnter Teacher Name:");

            teacher = Console.ReadLine();

            Console.WriteLine("\n\nEnter Course Name:");

            coursename = Console.ReadLine();

            if (string.IsNullOrEmpty(coursecode) || string.IsNullOrEmpty(teacher) || string.IsNullOrEmpty(coursename))
            {
                Console.WriteLine("\n\nInvalid Input.");
                
                break;
            }

            schoolmanager.AddCourse(coursecode,teacher,coursename);
            break;

        case 3:
            Console.WriteLine("\n\nEnter Course Id:");

            Courseid = Console.ReadLine();

            Console.WriteLine("\n\nEnter Student Id:");

            Studentid = Console.ReadLine();

            if (!tryParse(Courseid) || !tryParse(Studentid))
            {
                Console.WriteLine("\nInvalid Input Type");
                break;
            }

            schoolmanager.EnrollCourse(int.Parse(Courseid!),int.Parse(Studentid!));
            break;
        
        case 4:
            Console.WriteLine("\n\nEnter Course Id:");

            Courseid = Console.ReadLine();

            Console.WriteLine("\n\nEnter Student Id:");

            Studentid = Console.ReadLine();

            Console.WriteLine("\n\nEnter Grade:");

            Grade = Console.ReadLine();

            if (!tryParse(Courseid) || !tryParse(Studentid))
            {
                Console.WriteLine("\nInvalid Input Type");
                break;
            }

            schoolmanager.AssignGrade(int.Parse(Courseid!),int.Parse(Studentid!), int.Parse(Grade!));
            break;
        
        case 5:
            schoolmanager.GetStudents();
            break;

        case 6:
            Console.WriteLine("\n\nEnter Student Id:");

            Studentid = Console.ReadLine();

            if (!tryParse(Studentid))
            {
                Console.WriteLine("\nInvalid Input Type");
                break;
            }

            schoolmanager.GetStudentEnrollment(int.Parse(Studentid!));
            break;


        case 7:

            schoolmanager.GetCourses();
            break;


        default:
            Console.WriteLine("\nInvalid User Input");
            break;
    }
}
