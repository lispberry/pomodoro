using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Collective_Development.forms
{
    public partial class formSettings : Form
    {
        public formSettings()
        {
            InitializeComponent();
            //брать значение всех настроек из бд
            tbDefaulWorkTime.Text = "40";
        }
       
        private void FormPage1_Load(object sender, EventArgs e)
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
            
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //заносить значения настроек в бд
        }
    }
}
