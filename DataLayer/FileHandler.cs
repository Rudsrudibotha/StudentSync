using StudentSync.PresentationLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSync.DataLayer
{
    
    public class FileHandler
    {
        private static string _filePath = "StudentsFile.txt";

        public static void SaveStudentToFile(Student student)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, true))
                {
                    writer.WriteLine(student.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving student to file: {ex.Message}");
            }
        }

        public static Student[] LoadStudentsFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new Student[0];
                }

                string[] lines = File.ReadAllLines(_filePath);
                Student[] students = new Student[lines.Length];
                
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] studentData = lines[i].Split(',');
                    students[i] = new Student
                    {
                        StudentId = int.Parse(studentData[0]),
                        StudentName = studentData[1],
                        StudentSurname = studentData[2],
                        StudentEmail = studentData[3],
                        StudentPhone = studentData[4],
                        Course = studentData[5]
                    };
                }

                return students;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading students from file: {ex.Message}");
            }
        }
        
        public static void DeleteStudent(int studentId)
        {
            try
            {
                var students = LoadStudentsFromFile();
                var updatedStudents = students.Where(student => student.StudentId != studentId).ToList();

                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    foreach (var student in updatedStudents)
                    {
                        writer.WriteLine(student.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting student from file: {ex.Message}");
            }
        }

        public static void UpdateStudentInfo(Student updatedStudent)
        {
            try
            {
                var students = LoadStudentsFromFile();
                var updatedStudents = students.Select(student =>
                {
                    if (student.StudentId == updatedStudent.StudentId)
                    {
                        return updatedStudent;
                    }
                    return student;
                }).ToList();

                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    foreach (var student in updatedStudents)
                    {
                        writer.WriteLine(student.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating student in file: {ex.Message}");
            }
        }
        public static class ReportGenerator
        {
            private static string _summaryFilePath = "Summary.txt";

            public static void GenerateSummaryReport()
            {
                try
                {
                    var students = LoadStudentsFromFile();
                    var totalStudents = students.Count;
                    var averageAge = students.Average(s => s.Age);

                    using (StreamWriter writer = new StreamWriter(_summaryFilePath))
                    {
                        writer.WriteLine($"Total Students: {totalStudents}");
                        writer.WriteLine($"Average Age: {averageAge:F2}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error generating summary report: {ex.Message}");
                }
            }

            private static List<Student> LoadStudentsFromFile()
            {
                return new List<Student>();
            }
        }


        private static Student ParseStudent(string line)
        {
            var parts = line.Split(',');
            if (parts.Length != 7) return null;

            try
            {
                return new Student
                {
                    StudentName = parts[0].Trim(),
                    StudentSurname = parts[1].Trim(),
                    StudentId = int.Parse(parts[2].Trim()),
                    StudentEmail = parts[3].Trim(),
                    StudentPhone = parts[4].Trim(),
                    Course = parts[5].Trim(),
                    Age = int.Parse(parts[6].Trim())
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
