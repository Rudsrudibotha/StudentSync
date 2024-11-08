using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentSync.PresentationLayer
{
    public partial class DeleteS : Form
    {
        private List<Student> students = new List<Student>();
        private string filePath = "StudentsFile.txt";

        public DeleteS()
        {
            InitializeComponent();
            LoadStudents();
        }
        private void LoadStudents()
        {
            students = File.ReadAllLines(filePath)
                .Select(line => ParseStudent(line))
                .Where(student => student != null)
                .ToList();

            dataGridView1.DataSource = students;
        }
        private Student ParseStudent(string line)
        {
            var parts = line.Split(',');

            if (parts.Length < 5) return null;

            return new Student
            {
                StudentName = parts.Length > 0 ? parts[0].Trim() : string.Empty,
                StudentSurname = parts.Length > 1 ? parts[1].Trim() : string.Empty,
                StudentId = (parts.Length > 2 && int.TryParse(parts[2].Trim(), out int studentId)) ? studentId : 0,
                StudentPhone = parts.Length > 3 ? parts[3].Trim() : string.Empty,
                StudentEmail = parts.Length > 4 ? parts[4].Trim() : string.Empty,
                Course = parts.Length > 5 ? parts[5].Trim() : string.Empty,
                Age = (parts.Length > 1 && int.TryParse(parts[6].Trim(), out int age)) ? age : 0

            };

        }

        // Search button (button3) click event to find a student by ID
        private void button2_Click(object sender, EventArgs e)
        {
            int studentID;
            if (!int.TryParse(textBox3.Text.Trim(), out studentID) || textBox3.Text.Length != 6)
            {
                MessageBox.Show("Please enter a valid 6-digit Student ID.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = students.FirstOrDefault(s => s.StudentId == studentID);
            if (student != null)
            {
                textBox1.Text = student.StudentName;
                textBox2.Text = student.StudentSurname;
                textBox4.Text = student.StudentPhone;
                textBox5.Text = student.StudentEmail;
                textBox6.Text = student.Course;
                textBox7.Text = student.Age.ToString();
                dataGridView1.DataSource = new List<Student> { student }; // Show only the found student
            }
            else
            {
                MessageBox.Show("Student not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int studentID;
            if (!int.TryParse(textBox3.Text.Trim(), out studentID) || textBox3.Text.Length != 6)
            {
                MessageBox.Show("Please enter a valid 6-digit Student ID.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = students.FirstOrDefault(s => s.StudentId == studentID);
            if (student != null)
            {
                // Update student details
                student.StudentName = textBox1.Text.Trim();
                student.StudentSurname = textBox2.Text.Trim();
                student.StudentPhone = textBox4.Text.Trim();
                student.StudentEmail = textBox5.Text.Trim();
                student.Course = textBox6.Text.Trim();
                student.Age = int.Parse(textBox7.Text.Trim());

                // Refresh DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students;

                // Save changes to file
                SaveStudentsToFile();
                MessageBox.Show("Student details updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Student not found. Please search before updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveStudentsToFile()
        {
            var lines = students.Select(s => $"{s.StudentName},{s.StudentSurname},{s.StudentId},{s.StudentPhone},{s.StudentEmail},{s.Course},{s.Age}");
            File.WriteAllLines(filePath, lines);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DeleteS_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string surname = textBox2.Text.Trim();
            int studentID;
            string studentPhone = textBox4.Text.Trim();
            string studentEmail = textBox5.Text.Trim();
            string studentcourses = textBox6.Text.Trim();
            int age;

            if (!int.TryParse(textBox3.Text.Trim(), out studentID))
            {
                MessageBox.Show("Please enter valid data for Student ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(textBox7.Text.Trim(), out age))
            {
                MessageBox.Show("Please enter valid data for Age.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var studentToDelete = students.FirstOrDefault(s =>
                s.StudentName == name &&
                s.StudentSurname == surname &&
                s.StudentId == studentID &&
                s.StudentPhone == studentPhone &&
                s.StudentEmail == studentEmail &&
                s.Course == studentcourses &&
                s.Age == age);

            if (studentToDelete != null)
            {
                students.Remove(studentToDelete);
                SaveStudentsToFile();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students;

                MessageBox.Show("Student deleted successfully.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Student does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadStudents();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show(); 
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
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
            string filepath = "StudentsFile.txt";
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                writer.WriteLine(student.ToString());
            }
            MessageBox.Show("Student Has Been Added");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}