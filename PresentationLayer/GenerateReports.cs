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
using static StudentSync.PresentationLayer.Student;

namespace StudentSync.PresentationLayer
{
    public partial class GenerateReports : Form
    {
        private List<Student> students = new List<Student>();
        private string studentsFilePath = "StudentsFile.tx";
        private string summaryFilePath = "Summary.txt";


        public GenerateReports()
        {
            InitializeComponent();
            string binPath = AppDomain.CurrentDomain.BaseDirectory;
            studentsFilePath = Path.Combine(binPath, "StudentsFile.tx");
            summaryFilePath = Path.Combine(binPath, "Summary.txt");
            LoadStudents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }
        private void LoadStudents()
        {
            try
            {
                if (File.Exists(studentsFilePath))
                {
                    students = File.ReadAllLines(studentsFilePath)
                        .Select(line => ParseStudent(line))
                        .Where(student => student != null)
                        .ToList();
                }
                else
                {
                    MessageBox.Show("Students file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Student ParseStudent(string line)
        {
            try
            {
                var parts = line.Split(',');
                if (parts.Length < 7) return null;

                if (!int.TryParse(parts[2].Trim(), out int studentId) ||
                    !int.TryParse(parts[6].Trim(), out int age))
                {
                    return null;
                }

                return new Student
                {
                    StudentName = parts[0].Trim(),
                    StudentSurname = parts[1].Trim(),
                    StudentId = studentId,
                    StudentEmail = parts[3].Trim(),
                    StudentPhone = parts[4].Trim(),
                    Course = parts[5].Trim(),
                    Age = age
                };
            }
            catch
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No student data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var summaryData = new List<SummaryReport>
                {
                    new SummaryReport
                    {
                        TotalStudents = students.Count,
                        AverageAge = Math.Round(students.Average(s => s.Age), 2)
                    }
                };

                dataGridView1.DataSource = null; 
                dataGridView1.DataSource = summaryData;

                SaveSummaryToFile(summaryData[0].TotalStudents, summaryData[0].AverageAge);

                MessageBox.Show("Summary report generated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating summary: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSummaryToFile(int totalStudents, double averageAge)
        {
            try
            {
                var summaryLines = new[]
                {
                    $"Summary Report Date {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                    $"Total Students: {totalStudents}",
                    $"Average Age: {averageAge:F2} years"
                };

                File.WriteAllLines(summaryFilePath, summaryLines);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving summary to file: {ex.Message}");
            }
        }
    }
}
