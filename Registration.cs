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

            name.Text = "Введите имя";
            name.ForeColor = Color.Gray;

            surname.Text = "Введите фамилию";
            surname.ForeColor = Color.Gray;

            patronym.Text = "Введите отчество";
            patronym.ForeColor = Color.Gray;

            birthdate.Text = "Введите дату рождения";
            birthdate.ForeColor = Color.Gray;

            job.Text = "Введите должность";
            job.ForeColor = Color.Gray;

            login.Text = "Введите логин";
            login.ForeColor = Color.Gray;

            password.Text = "Введите пароль";
            password.ForeColor = Color.Gray;

            doublepassword.Text = "Введите пароль повторно";
            doublepassword.ForeColor = Color.Gray;
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
            if (birthdate.Text == "")
            {
                MessageBox.Show("Введите дату рождения");
                return;
            }
            if (job.Text == "")
            {
                MessageBox.Show("Введите должность");
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

        private void name_Enter(object sender, EventArgs e)
        {
            if (name.Text == "Введите имя")
            {
                name.Text = "";
                name.ForeColor = Color.Black;
            }
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                name.Text = "Введите имя";
                name.ForeColor = Color.Gray;
            }
        }

        private void surname_Enter(object sender, EventArgs e)
        {
            if (surname.Text == "Введите фамилию")
            {
                surname.Text = "";
                surname.ForeColor = Color.Black;
            }
        }

        private void surname_Leave(object sender, EventArgs e)
        {
            if (surname.Text == "")
            {
                surname.Text = "Введите фамилию";
                surname.ForeColor = Color.Gray;
            }
        }

        private void patronym_Enter(object sender, EventArgs e)
        {
            if (patronym.Text == "Введите отчество")
            {
                patronym.Text = "";
                patronym.ForeColor = Color.Black;
            }
        }

        private void patronym_Leave(object sender, EventArgs e)
        {
            if (patronym.Text == "")
            {
                patronym.Text = "Введите отчество";
                patronym.ForeColor = Color.Gray;
            }
        }
        private void birthdate_Enter(object sender, EventArgs e)
        {
            if (birthdate.Text == "Введите дату рождения")
            {
                birthdate.Text = "";
                birthdate.ForeColor = Color.Black;
            }
        }

        private void birthdate_Leave(object sender, EventArgs e)
        {
            if (birthdate.Text == "")
            {
                birthdate.Text = "Введите дату рождения";
                birthdate.ForeColor = Color.Gray;
            }
        }
        private void job_Enter(object sender, EventArgs e)
        {
            if (job.Text == "Введите должность")
            {
                job.Text = "";
                job.ForeColor = Color.Black;
            }
        }

        private void job_Leave(object sender, EventArgs e)
        {
            if (job.Text == "")
            {
                job.Text = "Введите должность";
                job.ForeColor = Color.Gray;
            }
        }
        private void login_Enter(object sender, EventArgs e)
        {
            if (login.Text == "Введите логин")
            {
                login.Text = "";
                login.ForeColor = Color.Black;
            }
        }

        private void login_Leave(object sender, EventArgs e)
        {
            if (login.Text == "")
            {
                login.Text = "Введите логин";
                login.ForeColor = Color.Gray;
            }
        }
        private void password_Enter(object sender, EventArgs e)
        {
            if (password.Text == "Введите пароль")
            {
                password.Text = "";
                password.ForeColor = Color.Black;
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Введите пароль";
                password.ForeColor = Color.Gray;
            }
        }

        private void doublepassword_Enter(object sender, EventArgs e)
        {
            if (doublepassword.Text == "Введите пароль повторно")
            {
                doublepassword.Text = "";
                doublepassword.ForeColor = Color.Black;
            }
        }

        private void doublepassword_Leave(object sender, EventArgs e)
        {
            if (doublepassword.Text == "")
            {
                doublepassword.Text = "Введите пароль повторно";
                doublepassword.ForeColor = Color.Gray;
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
