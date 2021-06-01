using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Collective_Development.forms
{
    public partial class formUserData : Form
    {
        public formUserData()
        {
            InitializeComponent();
        }
        private void formUserData_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        public void LoadTheme()
        {
            foreach (Control ctrls in this.Controls)
            {
                if (ctrls.GetType() == typeof(Button))
                {
                    Button btn = (Button)ctrls;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                //if (ctrls.GetType() == typeof(CheckBox))
                //{
                //    CheckBox chBx = (CheckBox)ctrls;
                //    chBx.ForeColor = ThemeColor.PrimaryColor;
                //}
            }
            label1.ForeColor = label7.ForeColor = ThemeColor.SecondaryColor;

            label2.ForeColor = label3.ForeColor = label4.ForeColor = ThemeColor.PrimaryColor;
            checkBox1.ForeColor = checkBox2.ForeColor = checkBox3.ForeColor = checkBox4.ForeColor = checkBox5.ForeColor = checkBox6.ForeColor = ThemeColor.PrimaryColor;
        }
    }
}
