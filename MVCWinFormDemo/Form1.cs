using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MVCWinFormDemo
{
    //View    
    public partial class StudentForm : Form
    {
        StudentController studentController;
        public StudentForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentController = new StudentController(new StudentModel(), this);
            this.showStudentsListView.MultiSelect = false;
            this.showStudentsListView.HideSelection = false;
            //Show enrolled student at the beginning
            studentController.GetEnrolledStudents();
        }      
        
        public void ShowEnrolledStudents(List<string> studentList)
        {
            //clear the listview first
            showStudentsListView.Items.Clear();            
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //Original Structure-Showing newly added student at the bottom of list
            foreach (string student in studentList)
            {
                showStudentsListView.Items.Add(student);
            }
            //New Structure-Showing newly added student at the top of list
            //studentList.Reverse();
            //foreach (string student in studentList)
            //{
            //    showStudentsListView.Items.Add(student);
            //}

        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            //We will not add an empty student name
            if (addStudentTextBox.Text != String.Empty)
            {
                //Get the new name from GUI 
                string newName = addStudentTextBox.Text;
                List<string> updatedStudentList = new List<string>();
                //Add a student name and get the new student list through controller
                updatedStudentList = studentController.AddStudent(newName);

                //Now Display back to GUI.This value is coming through the controller.
                showStudentsListView.Items.Clear();
                studentController.GetEnrolledStudents();
                //clearing the addStudentTextBox content
                addStudentTextBox.Clear();
            }
        }

        private void removeStudentButton_Click(object sender, EventArgs e)
        {
            //We can select only one item at a time
            if(showStudentsListView.SelectedItems.Count==1)
                {
                //Get the name from GUI 
                string studentName = showStudentsListView.SelectedItems[0].Text;
                List<string> updatedStudentList = new List<string>();
                //Remove the student name and get the new student list through controller
                updatedStudentList = studentController.RemoveStudent(studentName);
                //Now Display back to GUI.This value is coming through the controller.
                showStudentsListView.Items.Clear();
                studentController.GetEnrolledStudents();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    //Controller
    public interface IController
    {
        void GetEnrolledStudents();
        List<string> AddStudent(String studentName);
        List<string> RemoveStudent(String studentName);
    }
    public class StudentController : IController
    {
        private IModel model;        
        private StudentForm view;

        public StudentController(IModel model, StudentForm view)
        {
            this.model = model;
            this.view = view;           
        }        
        public void GetEnrolledStudents()
        {
            List<string> enrolledStudents = model.GetEnrolledStudentDetailsFromModel();
            view.ShowEnrolledStudents(enrolledStudents);
        }
        //Sending a request to model to add a student to the  student list
        public List<string> AddStudent(String studentName)
        {
            List<string> postAdditionStudentList = new List<string>();
            postAdditionStudentList = model.AddStudentToModel(studentName);
            return postAdditionStudentList;
        }
        //Sending a request to model to remove a student from the student list
        public List<string> RemoveStudent(String studentName)
        {
            List<string> postRemovalStudentList = new List<string>();
            postRemovalStudentList=model.RemoveStudentFromModel(studentName);
            return postRemovalStudentList;
        }
    }
}
//Model
public interface IModel
{
    List<string> GetEnrolledStudentDetailsFromModel();
    List<string> AddStudentToModel(string studentName);
    List<string> RemoveStudentFromModel(string studentName);

}
    public class StudentModel:IModel
    {
        private List<string> enrolledStudents = new List<string>{ "Amit", "John", "Sam" };
        
        public List<string> GetEnrolledStudentDetailsFromModel()
        {
            return enrolledStudents;
        }
        //Adding a student to the model(student list)
        public List<string> AddStudentToModel(string studentName)
        {
            enrolledStudents.Add(studentName);
            return enrolledStudents;
        }
        //Removing a student from model(student list)
        public List<string> RemoveStudentFromModel(string studentName)
        {
            enrolledStudents.Remove(studentName);           
           //After the removal of a student name, send the updated list to controller
           return enrolledStudents;
        }
    }
  
    
