using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePatternQAs
{
    class Student
    {
        int rollNo;
        string name;
        //Instance Constructor
        public Student(int rollNo, string name)
        {
            this.rollNo = rollNo;
            this.name = name;
        }
        //Copy Constructor
        public Student( Student student)
        {
            this.name = student.name;
            this.rollNo = student.rollNo;
        }
        public void DisplayDetails()
        {
            Console.WriteLine(" Student name :{0}, Roll no: {1}", name,rollNo);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** A simple copy constructor demo***\n");
            Student student1 = new Student(1, "John");
            Console.WriteLine(" The details of student1 is as follows:");
            student1.DisplayDetails();
            Console.WriteLine("\n Copying student1 to student2 now");            
            Student student2 = new Student(student1);
            Console.WriteLine(" The details of student2 is as follows:");
            student2.DisplayDetails();
            Console.ReadKey();
        }
    }
}
