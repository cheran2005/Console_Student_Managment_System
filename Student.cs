using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Student
    {
        public string Name {get;}
        public int Studentid {get;}

        public double Average {get;private set;}

        public Student(int Studentid,string Name)
        {
            this.Name = Name;
            this.Studentid = Studentid;
            Average = 0;
            
        }

        public void editAverage(double Average)
        {
            if (Average<0 || Average > 100)
            {
                Console.WriteLine("\nInvalid Average.");
                return;
            }
            this.Average = Average;
            Console.WriteLine("\nAverage Change Success.");
            return;
        }

    }
}