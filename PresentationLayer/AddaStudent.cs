using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudentSync.PresentationLayer
{
    public partial class AddaStudent : Form
    {

        public AddaStudent()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Name
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Surname
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //ID
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Email
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //Cellphone
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //Course
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Student studentadd = new Student()
                {
                        StudentName = textBox1.Text,
                        StudentSurname = textBox2.Text,
                        StudentId = int.Parse(textBox3.Text),
                        StudentPhone = textBox5.Text,
                        StudentEmail = textBox4.Text,
                        Course = textBox6.Text,
                        Age = int.Parse(textBox7.Text), 
                };
                
                SaveToFile(studentadd);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"This is not correct:{ex.Message}");
            }
        }
        private static void SaveToFile(Student student)
        {
            string filepath = "StudentsFile.tx";
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                writer.WriteLine(student.ToString());
            }
            MessageBox.Show("Student Has Been Added");
        }

        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
