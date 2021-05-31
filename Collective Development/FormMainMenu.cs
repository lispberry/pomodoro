using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Collective_Development.data;

namespace Collective_Development
{
    public partial class FormMainMenu : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private static forms.formUserData formUserData = new forms.formUserData();
        private static forms.formStatistics formStatistics = new forms.formStatistics();
        private static forms.formSettings formSettings = new forms.formSettings();
        private static forms.formInstruction formInstruction = new forms.formInstruction();
        private static forms.formMainPage formMainPage = new forms.formMainPage(formSettings);

        private User user;
        
        public FormMainMenu()
        {    
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            btnMainPage_Click(btnMainPage, null);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        public void Show(User user)
        {
            this.user = user;
            lblUserName.Text = user.Login;
            formUserData.AddUserData(user);
            formMainPage.AddTaskBoards(Card.GetCards(user.Login));
            formSettings.login = user.Login;
            formSettings.settings = Settings.GetSettings(user.Login);
            formSettings.ShowSettings();

            Show();
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelUser.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            ActivateButton(btnSender);
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Card.RemoveCards(user.Login);

            Settings.Update(user.Login, formSettings.settings);
            Card.AddCards(user.Login, formMainPage.GetCards());

            Application.Exit();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnMainPage_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            formMainPage.LoadTheme();
            OpenChildForm(formMainPage, sender);
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            formSettings.LoadTheme();
            OpenChildForm(formSettings, sender);
        }
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            formStatistics.LoadTheme();
            OpenChildForm(formStatistics, sender);
        }
        private void btnUserData_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            formUserData.LoadTheme();
            OpenChildForm(formUserData, sender);
        }

        private void btnInstruction_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            formInstruction.LoadTheme();
            OpenChildForm(formInstruction, sender);
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void FormMainMenu_Close(object sender, EventArgs e)
        {
        }
    }
}
