using Collective_Development.data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Collective_Development.forms
{
    public partial class formSettings : Form
    {
        public int defaultWorkTime;
        public bool soundSignal;
        public Settings settings = new Settings();
        public string login = "demo";
         
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

        public void ShowSettings()
        {
            tbDefaulWorkTime.Text = settings.DefaultDelayTime.ToString();
            chbxSound.Checked = settings.AddSound;
            chbxKeyboardBlock.Checked = settings.BlockKeyBoard;
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
            {
                MessageBox.Show("Введите корректное значение");
            } else
            {
                settings.DefaultDelayTime = defaultWorkTime;
                settings.AddSound = chbxSound.Checked;
                settings.BlockKeyBoard = chbxKeyboardBlock.Checked;

                Settings.Update(login, settings);
                btnSaveChanges.Visible = false;
            }
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

        private void tbDefaulWorkTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
