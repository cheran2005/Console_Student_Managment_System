
namespace SchoolApp.Models
{
    public class Enrollment
    {
        public Course Course {get;}
        public Student Student {get;}

        public double Grade {get; private set;}

        public Enrollment(Course Course,Student Student,double Grade)
        {
            this.Course = Course;
            this.Student = Student;
            this.Grade = Grade;
        }


        public void ChangeGrade(double NewGrade)
        {
            Grade = NewGrade;
            return;
        }



    }
}