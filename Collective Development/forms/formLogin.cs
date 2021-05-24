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
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //если пользователь с таким логином и паролем есть
            if (true)
            {
                //то открываем главную форму, в ней надо на странице с данными о пользователе вводить данные из бд
                new FormMainMenu().Show();
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
    }
}
