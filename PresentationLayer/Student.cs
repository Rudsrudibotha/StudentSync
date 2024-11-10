using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSync.PresentationLayer
{

    public class Student
    {

        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int StudentId { get; set; }
        public string StudentEmail { get; set;}
        public string StudentPhone { get; set;}
        public string Course { get; set;}
        public int Age { get; set;}
        public override string ToString()
        {
            return $"{StudentName},{StudentSurname},{StudentId},{StudentEmail},{StudentPhone},{Course},{Age}";
        }
        public class SummaryReport
        {
            [DisplayName("Total Students")]
            public int TotalStudents { get; set; }

            [DisplayName("Average Age")]
            public double AverageAge { get; set; }

            //Importation of values
        }
    }
}
