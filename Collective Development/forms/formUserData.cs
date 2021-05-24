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
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = label7.ForeColor = ThemeColor.SecondaryColor;

            label2.ForeColor = label3.ForeColor = label4.ForeColor= label5.ForeColor = label6.ForeColor =label12.ForeColor = ThemeColor.PrimaryColor;
        }
    }
}
