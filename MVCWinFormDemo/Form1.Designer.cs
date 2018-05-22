namespace MVCWinFormDemo
{
    partial class StudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.showStudentsListView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.addStudentLabel = new System.Windows.Forms.Label();
            this.addStudentButton = new System.Windows.Forms.Button();
            this.addStudentTextBox = new System.Windows.Forms.TextBox();
            this.removeStudentButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showStudentsListView
            // 
            this.showStudentsListView.Location = new System.Drawing.Point(465, 198);
            this.showStudentsListView.Name = "showStudentsListView";
            this.showStudentsListView.Size = new System.Drawing.Size(140, 348);
            this.showStudentsListView.TabIndex = 6;
            this.showStudentsListView.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enrolled Students";
            // 
            // addStudentLabel
            // 
            this.addStudentLabel.AutoSize = true;
            this.addStudentLabel.Location = new System.Drawing.Point(12, 160);
            this.addStudentLabel.Name = "addStudentLabel";
            this.addStudentLabel.Size = new System.Drawing.Size(145, 25);
            this.addStudentLabel.TabIndex = 9;
            this.addStudentLabel.Text = "Add a student";
            // 
            // addStudentButton
            // 
            this.addStudentButton.Location = new System.Drawing.Point(17, 262);
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(184, 54);
            this.addStudentButton.TabIndex = 10;
            this.addStudentButton.Text = "Add Student";
            this.addStudentButton.UseVisualStyleBackColor = true;
            this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
            // 
            // addStudentTextBox
            // 
            this.addStudentTextBox.Location = new System.Drawing.Point(17, 198);
            this.addStudentTextBox.Name = "addStudentTextBox";
            this.addStudentTextBox.Size = new System.Drawing.Size(229, 31);
            this.addStudentTextBox.TabIndex = 11;
            // 
            // removeStudentButton
            // 
            this.removeStudentButton.Location = new System.Drawing.Point(12, 406);
            this.removeStudentButton.Name = "removeStudentButton";
            this.removeStudentButton.Size = new System.Drawing.Size(254, 75);
            this.removeStudentButton.TabIndex = 12;
            this.removeStudentButton.Text = "Remove Selected Student";
            this.removeStudentButton.UseVisualStyleBackColor = true;
            this.removeStudentButton.Click += new System.EventHandler(this.removeStudentButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "A Sample MVC Winform Application Demo";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 579);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(145, 59);
            this.exitButton.TabIndex = 14;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 891);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeStudentButton);
            this.Controls.Add(this.addStudentTextBox);
            this.Controls.Add(this.addStudentButton);
            this.Controls.Add(this.addStudentLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.showStudentsListView);
            this.Name = "StudentForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView showStudentsListView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label addStudentLabel;
        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.TextBox addStudentTextBox;
        private System.Windows.Forms.Button removeStudentButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitButton;
    }
}

