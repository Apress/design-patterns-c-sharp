using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPatternWithCompositePatternEx
{
    interface IEmployee
    {
        void PrintStructures();
        void Accept(IVisitor visitor);        
    }
    //Employees who have Subordinates
    class CompositeEmployee : IEmployee
    {
        private string name;
        private string dept;
        //New field for this example
        private int yearsOfExperience;
        //The container for child objects
        private List<IEmployee> controls;
        // constructor
        public CompositeEmployee(string name, string dept,int experience)
        {
            this.name = name;
            this.dept = dept;
            this.yearsOfExperience = experience;
            controls = new List<IEmployee>();
        }
        public void Add(IEmployee e)
        {
            controls.Add(e);
        }
        public void Remove(IEmployee e)
        {
            controls.Remove(e);
        }
        // Gets the name
        public string Name
        {
            get { return this.name; }
            //set { _name = value; }
        }
        // Gets the department name
        public string Dept
        {
            get { return this.dept; }           
        }
        // Gets the yrs. of experience
        public int Experience
        {
            get { return this.yearsOfExperience; }           
        }
        public List<IEmployee> Controls
        {
           get { return this.controls; }
        }        
        public void PrintStructures()
        {
            Console.WriteLine("\t" + this.name + " works in  " + this.dept + " Experience :" + this.yearsOfExperience + " years");
            foreach (IEmployee e in controls)
            {
                e.PrintStructures();
            }
        }
        public void Accept(IVisitor visitor)
        {
            visitor.VisitCompositeElement(this);            
        }      
    }
    class Employee : IEmployee
    {
        private string name;
        private string dept;
        //New field for this example
        private int yearsOfExperience;        
        // constructor
        public Employee(string name, string dept, int experience)
        {
            this.name = name;
            this.dept = dept;
            this.yearsOfExperience = experience;
        }
        public void PrintStructures()
        {
            Console.WriteLine("\t\t" + this.name + " works in  " + this.dept + " Experience :" + this.yearsOfExperience + " years");
        }
        // Gets the name
        public string Name
        {
            get { return this.name; }          
        }
        // Gets the department name
        public string Dept
        {
            get { return this.dept; }
            //set { _name = value; }
        }
        // Gets the yrs. of experience
        public int Experience
        {
            get { return this.yearsOfExperience; }
        }       
        public void Accept(IVisitor visitor)
        {
            visitor.VisitLeafNode(this);
        }
    }

    interface IVisitor
    {
        void VisitCompositeElement(CompositeEmployee employees);
        void VisitLeafNode(Employee employee);        
    }
    class Visitor : IVisitor
    {
        public void VisitCompositeElement(CompositeEmployee employee)
        {
            //We'll promote them if experience is greater than 15 years
            bool eligibleForPromotion = employee.Experience > 15 ? true : false;
            Console.WriteLine("\t\t" + employee.Name + " from  " + employee.Dept + " is eligible for promotion? " + eligibleForPromotion);
        }

        public void VisitLeafNode(Employee employee)
        { 
            //We'll promote them if experience is greater than 12 years
            bool eligibleForPromotion = employee.Experience > 12 ? true : false;
            Console.WriteLine("\t\t" + employee.Name + " from  " + employee.Dept + " is eligible for promotion? " + eligibleForPromotion);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Visitor Pattern combined with Composite Pattern Demo***\n");
            #region Similar code structure taken from Composite Pattern demo            
            //Prinipal of the college
            CompositeEmployee Principal = new CompositeEmployee("Dr.S.Som(Principal)", "Planning-Supervising-Managing",20);
            //The college has 2 Head of Departments-One from MAths, One from Computer Sc.
            CompositeEmployee hodMaths = new CompositeEmployee("Mrs.S.Das(HOD-Maths)", "Maths",14);
            CompositeEmployee hodCompSc = new CompositeEmployee("Mr. V.Sarcar(HOD-CSE)", "Computer Sc.",16);

            //2 other teachers works in Mathematics department
            Employee mathTeacher1 = new Employee("Math Teacher-1", "Maths", 14);
            Employee mathTeacher2 = new Employee("Math Teacher-2", "Maths", 6);

            //3 other teachers works in Computer Sc. department
            Employee cseTeacher1 = new Employee("CSE Teacher-1", "Computer Sc.", 10);
            Employee cseTeacher2 = new Employee("CSE Teacher-2", "Computer Sc.", 13);
            Employee cseTeacher3 = new Employee("CSE Teacher-3", "Computer Sc.", 7);


            //Teachers of Mathematics directly reports to HOD-Maths
            hodMaths.Add(mathTeacher1);
            hodMaths.Add(mathTeacher2);

            //Teachers of Computer Sc directly reports to HOD-Comp.Sc
            hodCompSc.Add(cseTeacher1);
            hodCompSc.Add(cseTeacher2);
            hodCompSc.Add(cseTeacher3);

            //Principal is on top of college
            //HOD -Maths and Comp. Sc directly reports to him
            Principal.Add(hodMaths);
            Principal.Add(hodCompSc);
                      
            Console.WriteLine("\n Testing the overall structure");
            //Prints the complete structure
            Principal.PrintStructures();
            #endregion

            Console.WriteLine("\n***Visitor starts visiting our composite structure***\n");
            IVisitor aVisitor = new Visitor();
            /*Principal is already holding the highest position.
            We are not checking whether he is eligible for promotion or not*/
            //Principal.Accept(aVisitor);

            //For employees who directly reports to Principal
            foreach (IEmployee e in Principal.Controls)
            {
                e.Accept(aVisitor);
            }
            //For employees who directly reports to HOD-Maths
            foreach (IEmployee e in hodMaths.Controls)
            {
                e.Accept(aVisitor);
            }
            //For employees who directly reports to HOD-Comp.Sc
            foreach (IEmployee e in hodCompSc.Controls)
            {
                e.Accept(aVisitor);
            }

            Console.ReadLine();
        }        
    }
}
