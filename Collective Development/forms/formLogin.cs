using Collective_Development.data;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Collective_Development.forms
{
    public partial class formLogin : Form
    {
        public bool Exists(string login)
        {
            using (var conn = new NpgsqlConnection(Constants.ConnectionString))
            {
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "SELECT COUNT(*) from \"user\" WHERE login = @login"
                };
                cmd.Parameters.AddWithValue("login", login);

                return ((Int64)cmd.ExecuteScalar()) == 1;
            }
        }

        public User Login(string login, string password)
        {
            using (var conn = new NpgsqlConnection(Constants.ConnectionString))
            {
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "SELECT name, surname, age, login from \"user\" where login = @login and password = @password"
                };
                cmd.Parameters.AddWithValue("login", login);
                cmd.Parameters.AddWithValue("password", password);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User()
                    {
                        Name = (string)reader[0],
                        Surname = (string)reader[1],
                        Age = (int)reader[2],
                        Login = (string)reader[3]
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Register(string login, string password)
        {
            if (Exists(login)) return false;

            using (var conn = new NpgsqlConnection(Constants.ConnectionString))
            {
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "INSERT INTO \"user\" VALUES(@login, @password) RETURNING login"
                };

                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public formLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //если пользователь с таким логином и паролем есть
            var user = Login(tbUsername.Text, tbPassword.Text);
            if (user != null)
            {
                //то открываем приложение и вводим все данные из бд
                new FormMainMenu().Show(user);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUsername.Text = "";
                tbPassword.Text = "";
                tbUsername.Focus();
            }
        }

        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '•';
            }
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            new formRegister().Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
