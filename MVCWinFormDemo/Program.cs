using System;
using System.Windows.Forms;

namespace MVCWinFormDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StudentForm studentView = new StudentForm();            
            IModel studentModel = new StudentModel();
            IController cnt = new StudentController(studentModel,studentView);
            Application.Run(new StudentForm());
        }
    }
}
