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

namespace Project_1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Описание", typeof(string));
            dt.Columns.Add("Дедлайн", typeof(DateTime));
            dt.Columns.Add("Срок выполнения", typeof(string));

            dt.Rows.Add("Футбол", "2023, 05, 27", "6 месяцев");
            dt.Rows.Add("Прием у доктора", "27/04/2023", "2 недели");
            dt.Rows.Add("Сделать проект", "08/04/2023", "3 недели");

            TaskTable.DataSource = dt;
        }

        public class Task
        {
            public string description;
            public DateTime term;
            public DateTime deadline;

            public Task(string _description, DateTime _term, DateTime _deadline)
            {
                this.description = _description;
                this.term = _term;
                this.deadline = _deadline;

            }

        }
        List<Task> task = new List<Task>();
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.labelTime.Text = DateTime.Now.ToString("hh:mm:ss");
            int hours = int.Parse(DateTime.Now.ToString("HH"));
            if (hours > 12)
            {
                labelAMPM.Text = "PM";
            }
            else
            {
                labelAMPM.Text = "AM";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile myprofile = new Profile();
            myprofile.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void exit_MouseEnter(object sender, EventArgs e)
        {
            exit.ForeColor = Color.White;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.ForeColor = Color.Black;
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
