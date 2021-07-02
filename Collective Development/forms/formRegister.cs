using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Collective_Development.forms
{
    public partial class formRegister : Form
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

        public bool Register(string login, string password)
        {
            if (Exists(login)) return false;

            using (var conn = new NpgsqlConnection(Constants.ConnectionString))
            {
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "INSERT INTO \"user\"(login, password) VALUES(@login, @password)"
                };
                cmd.Parameters.AddWithValue("login", login);
                cmd.Parameters.AddWithValue("password", password);

                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public formRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            int kolNum = 0;
            int kolLetUp = 0;
            int kolLetLow = 0;
            bool kolRusLet = false;
            int kolSymbol = 0;

            for (int i = 0; i < tbPassword.Text.Length; i++)
            {
                if (!kolRusLet)
                {
                    char ch = tbPassword.Text[i];
                    if (Regex.Match(tbPassword.Text, "[а-яА-ЯёЁ]").Value.Length > 0)
                        kolRusLet = true;
                    else
                        if (Char.IsNumber(ch))
                        kolNum++;
                        else 
                            if (Char.IsLetter(ch))
                            {
                                if (Char.IsUpper(ch))
                                    kolLetUp++;
                                else kolLetLow++;
                            }
                            else kolSymbol++;
                }
            }

            if (tbUsername.Text == "" && tbPassword.Text == "" && tbConfirmPassword.Text == "")
            {
                MessageBox.Show("Логин и пароль не должны быть пустыми", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                if (kolRusLet)
                {
                    MessageBox.Show("В пароле не должно быть русских букв", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (tbPassword.Text.Length < 8)
                    {
                        MessageBox.Show("В пароле должно быть не менее 8 символов", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        if (kolNum < 1 | kolSymbol < 1 | kolLetUp < 1 | kolLetLow < 1)
                        {
                            if (kolNum < 1) MessageBox.Show("Пароль должен содержать как минимум 1 цифру", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (kolSymbol < 1) MessageBox.Show("Пароль должен содержать как минимум 1спец.символ", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (kolLetLow < 1) MessageBox.Show("Пароль должен содержать как минимум 1 символ нижнего регистра", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (kolLetUp < 1) MessageBox.Show("Пароль должен содержать как минимум 1 символ верхнего регистра", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            if (tbPassword.Text == tbConfirmPassword.Text)
                            {
                                //создание аккаунта
                                tbUsername.Text = "";
                                tbPassword.Text = "";
                                tbConfirmPassword.Text = "";
                                MessageBox.Show("Ваш аккаунт был успешно зарегистрован", "Регистрация прошла успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Пароли не совпадают, пожалуйста, попробуйте еще раз", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbPassword.Text = "";
                                tbConfirmPassword.Text = "";
                                tbPassword.Focus();
                            }
        }
        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                tbPassword.PasswordChar = '\0';
                tbConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '•';
                tbConfirmPassword.PasswordChar = '•';
            }
        }

        private void lblBackToAuth_Click(object sender, EventArgs e)
        {
            new formLogin().Show();
            this.Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
