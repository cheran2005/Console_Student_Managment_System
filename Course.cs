namespace SchoolApp.Models
{
    public class Course
    {
        public string CourseName {get;}
        public int Courseid {get;}
        public string CourseCode {get;}
        public string Teacher {get;}

        public Course(int Courseid,string CourseCode,string Teacher,string CourseName)
        {
            this.Courseid = Courseid;
            this.CourseCode = CourseCode;
            this.CourseName = CourseName;
            this.Teacher = Teacher;
        }



    }
}