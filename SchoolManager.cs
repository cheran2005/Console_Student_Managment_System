using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SchoolApp.Models
{
    public class SchoolManager
    {
        private List<Student> Students = new List<Student>();
        private List<Course> Courses = new List<Course>();

        //[Student Id] = list of enrollments
        private Dictionary<int, List<Enrollment>> Enrollments = new Dictionary<int , List<Enrollment>>();

        public void AddStudent(string name)
        {
            
            Student NewStudent = new Student(GetLatestStudentid(),name);
            Students.Add(NewStudent);
            Console.WriteLine("\nStudent Successfully Added");
            return;
        }

        public void AddCourse(string CourseCode,string Teacher,string CourseName)
        {
            Course NewCourse = new Course(GetLatestCourseid(),CourseCode,Teacher,CourseName);
            Courses.Add(NewCourse);
            Console.WriteLine("\nCourse Successfully Added");
            return;
        }

        public int GetLatestStudentid()
        {
            if (Students.Count == 0)
            {
                return 0;
            }
            int id = Students.Max(Student => Student.Studentid) + 1;
            return id;
        }

        public int GetLatestCourseid()
        {
            if (Courses.Count == 0)
            {
                return 0;
            }

            int id = Courses.Max(Course => Course.Courseid) + 1;
            return id;
        }

        public void EnrollCourse(int Courseid,int Studentid)
        {
            Course? course = Courses.FirstOrDefault( Course => Course.Courseid ==Courseid);
            Student? student = Students.FirstOrDefault(Student => Student.Studentid == Studentid);
            if (course == null || student == null )
            {
                Console.WriteLine("\nStudent or Course does not exist.");
                return;
            }
            

            if (!Enrollments.ContainsKey(Studentid))
            {
                Enrollments[Studentid] = new List<Enrollment>();
            }

            Enrollment? CheckDup = Enrollments[Studentid].FirstOrDefault(Enrollment => Enrollment.Course.Courseid == Courseid);
            if (CheckDup != null)
            {
                Console.WriteLine("\nCourse Already Enrolled");
                return;
            }

            Enrollment newEnrollment = new Enrollment(course,student,0);
            Enrollments[Studentid].Add(newEnrollment);
            Console.WriteLine("\nCourse Successfully Enrolled");
            return;


        }

        public void AssignGrade(int Courseid,int Studentid, double Grade)
        {
            if (Enrollments.ContainsKey(Studentid))
            {
                Enrollment? AssignEnrollment = Enrollments[Studentid].FirstOrDefault(Enrollment => Enrollment.Course.Courseid == Courseid);

                if (AssignEnrollment == null)
                {
                    Console.WriteLine("\nStudent not enrolled in course.");
                    return;
                }
                AssignEnrollment.ChangeGrade(Grade);

                Console.WriteLine("\nGrade Successfully Assigned");
                return;
            }

            else
            {
                Console.WriteLine("\nStudent does not exist.");
                return;
            }
        }

        public void GetStudents()
        {
            Console.WriteLine("\n\n ---------------------------Students In The System -------------------------\n");
            for (int i = 0; i< Students.Count ; i++)
            {
                
                Console.WriteLine("\nName: " + Students[i].Name + "     Student Id: "+ Students[i].Studentid);
            }
            return;
        }

        public void GetCourses()
        {
            Console.WriteLine("\n\n ---------------------------Courses In The System -------------------------\n");
            for (int i = 0; i< Courses.Count ; i++)
            {
                
                Console.WriteLine("\nCourse Name: " + Courses[i].CourseName + "     Course Id: "+ Courses[i].Courseid+ "    Course Code: "+ Courses[i].CourseCode + "   Teacher: "+ Courses[i].Teacher);
            }
            return;
        }

        public Student? GetStudent(int Studentid)
        {
            Student? SearchedStudent = Students.FirstOrDefault(Student => Student.Studentid == Studentid);
            return SearchedStudent;
        }

        public void UpdateStudentAverage(int Studentid)
        {
            double AverageGrade = 0;
                for (int i =0 ; i< Enrollments[Studentid].Count ; i++)
            {
                AverageGrade += Enrollments[Studentid][i].Grade;
            }
            Student? student = Students.FirstOrDefault(Student => Student.Studentid == Studentid);
            student.editAverage(AverageGrade/Enrollments[Studentid].Count);
        }
        
        public void GetStudentEnrollment(int Studentid)
        {
            Student? student = GetStudent(Studentid);

            if (student == null)
            {
                Console.WriteLine("\nStudent Does Not Exist.");
                return;
            }
            
            Console.WriteLine("\n\n --- "+student.Name+" Enrolled Courses  ---");
            if (Enrollments.ContainsKey(Studentid))
            {

                
                for (int i =0 ; i< Enrollments[Studentid].Count ; i++)
                {
                    Console.WriteLine("\n\nCourseid: " + Enrollments[Studentid][i].Course.Courseid + 
                    "  Course Code: "+ Enrollments[Studentid][i].Course.CourseCode +
                    "  Course Name: " + Enrollments[Studentid][i].Course.CourseName +
                    "  Teacher: " + Enrollments[Studentid][i].Course.Teacher +
                    " Grade: " + Enrollments[Studentid][i].Grade);


                    

                }

                Console.WriteLine("\nAverage Grade: " + AverageGrade/Enrollments[Studentid].Count);
                
            }

            else
            {
                Console.WriteLine("\nStudent is not enrolled in any courses or is not in the system");
            }
            return;
        }
        




    }
}