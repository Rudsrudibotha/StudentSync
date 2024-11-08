using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentSync.PresentationLayer
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

        }

        private void AddStudent_Click(object sender, EventArgs e)
        {
            AddaStudent AddAStudentForm = new AddaStudent();
            AddAStudentForm.Show();
            this.Hide();

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenerateReports generateReports = new GenerateReports();
            generateReports.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeleteS DeleteSt = new DeleteS();
            DeleteSt.Show();
            this.Hide();
        }
    }
}
