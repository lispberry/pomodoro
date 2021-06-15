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
        public formRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            int kol_num = 0;
            int kol_let_up = 0;
            int kol_let_low = 0;
            bool kol_rus_let = false;
            int kol_simb = 0;

            for (int i = 0; i < tbPassword.Text.Length; i++)
            {
                if (!kol_rus_let)
                {
                    char ch = tbPassword.Text[i];
                    if (Regex.Match(tbPassword.Text, "[а-яА-ЯёЁ]").Value.Length > 0)
                        kol_rus_let = true;
                    else
                        if (Char.IsNumber(ch))
                        kol_num++;
                    else if (Char.IsLetter(ch))
                    {
                        if (Char.IsUpper(ch))
                            kol_let_up++;
                        else kol_let_low++;
                    }
                    else kol_simb++;
                }
            }
            if (tbUsername.Text == "" && tbPassword.Text == "" && tbConfirmPassword.Text == "")
            {
                MessageBox.Show("Логин и пароль не должны быть пустыми", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                if (kol_rus_let)
            {
                MessageBox.Show("В пароле не должно быть русских букв", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                    if (tbPassword.Text.Length < 8)
            {
                MessageBox.Show("В пароле должно быть не менее 8 символов", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                        if (kol_num < 1 | kol_simb < 1 | kol_let_up < 1 | kol_let_low < 1)
            {
                if (kol_num < 1) MessageBox.Show("Пароль должен содержать как минимум 1 цифру", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (kol_simb < 1) MessageBox.Show("Пароль должен содержать как минимум 1спец.символ", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (kol_let_low < 1) MessageBox.Show("Пароль должен содержать как минимум 1 символ нижнего регистра", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (kol_let_up < 1) MessageBox.Show("Пароль должен содержать как минимум 1 символ верхнего регистра", "Не удалось зарегистрироваться", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
