using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Collective_Development.forms
{
    public partial class formInstruction : Form
    {
        public formInstruction()
        {
            InitializeComponent();
            lblEngDoc.Visible = false;
            lblRusDoc.Visible = true;
        }

        private void formInstruction_Load(object sender, EventArgs e)
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
            label1.ForeColor = ThemeColor.SecondaryColor;
        }

        private void btnChangeLanguage_Click(object sender, EventArgs e)
        {
            if (btnChangeLanguage.Text == "Русский")
            {
                btnChangeLanguage.Text = "English";
                label1.Text = "Language of documentation:";
                lblEngDoc.Visible = false;
                lblRusDoc.Visible = true;
            }
            else
            {
                btnChangeLanguage.Text = "Русский";
                label1.Text = "Язык документации:";
                lblEngDoc.Visible = true;
                lblRusDoc.Visible = false;
            }
        }
    }
}
