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
        public int defaultWorkTime;
        public bool soundSignal;
        public formSettings()
        {
            InitializeComponent();
            //брать значение всех настроек из бд
            tbDefaulWorkTime.Text = "40";
            btnSaveChanges.Visible = false;

            defaultWorkTime = Convert.ToInt32(tbDefaulWorkTime.Text);
        }
       
        private void FormPage1_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        public void LoadTheme()
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
            if (!Int32.TryParse(tbDefaulWorkTime.Text, out defaultWorkTime) || defaultWorkTime <= 0)
                MessageBox.Show("Введите корректное значение");
            else btnSaveChanges.Visible = false;
        }

        private void tbDefaulWorkTime_TextChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Visible = true;
        }

        private void chbxKeyboardBlock_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Visible = true;
        }

        private void chbxSound_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Visible = true;
            soundSignal = chbxSound.Checked;
        }
    }
}
