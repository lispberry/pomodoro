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
            btnSaveData.Visible = false;
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
            chbxPref1.ForeColor = chbxPref2.ForeColor = chbxPref3.ForeColor = chbxPref5.ForeColor = chbxPref4.ForeColor = chbxPref6.ForeColor = ThemeColor.PrimaryColor;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            btnSaveData.Visible = true;
        }

        private void tbSurname_TextChanged(object sender, EventArgs e)
        {
            btnSaveData.Visible = true;
        }

        private void tbAge_TextChanged(object sender, EventArgs e)
        {
            btnSaveData.Visible = true;
        }

        private void chbxPref1_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveData.Visible = true;
        }

        private void chbxPref2_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveData.Visible = true;
        }

        private void chbxPref3_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveData.Visible = true;
        }

        private void chbxPref4_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveData.Visible = true;
        }

        private void chbxPref5_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveData.Visible = true;
        }

        private void chbxPref6_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveData.Visible = true;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            //сохранить изменения в бд
            btnSaveData.Visible = false;
        }
    }
}
