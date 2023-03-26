using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void exit_MouseEnter(object sender, EventArgs e)
        {
            exit.ForeColor = Color.White;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.ForeColor = Color.Black;
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (surname.Text == "")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }
            if (patronym.Text == "")
            {
                MessageBox.Show("Введите отчество");
                return;
            }
            if (login.Text == "")
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (password.Text == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if (doublepassword.Text == "")
            {
                MessageBox.Show("Введите пароль повторно");
                return;
            }

            if (isUserExists())
                return;


            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `name`, `surname`, `patronym`) VALUES (@login , @password, @name, @surname, @patronym)", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname.Text;
            command.Parameters.Add("@patronym", MySqlDbType.VarChar).Value = patronym.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт был создан");
            else
                MessageBox.Show("Аккаунт не был создан");
            db.closeConnection();

        }

        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @userL", db.getConnection());
            command.Parameters.Add("@userL", MySqlDbType.VarChar).Value = login.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже есть,введите другой");
                return true;
            }
            else
                return false;
        }

        private void autoreg_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginF = new LoginForm();
            loginF.Show();
        }
        private void autoreg_MouseEnter(object sender, EventArgs e)
        {
            autoreg.ForeColor = Color.DarkSlateBlue;
        }


    }
}
