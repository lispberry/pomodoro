using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Collective_Development.forms
{
    public partial class formMainPage : Form
    {
        private List<TaskBoard> taskBoards;
        public formMainPage()
        {
            InitializeComponent();
            taskBoards = new List<TaskBoard>();
            taskBoards.Add(new TaskBoard(15, "Большой перерыв"));
            taskBoards.Add(new TaskBoard(5, "Маленький перерыв"));
            taskBoards.Add(new TaskBoard(40, "Работа"));

            for (int i = 0; i < taskBoards.Count; i++)
            {
                Controls.Add(taskBoards[i].taskPanel);
                taskBoards[i].ClickOnPanel = ReleasePanels;
            }
        }
        private void formMainPage_Load(object sender, EventArgs e)
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
            ReleasePanels();
        }
        private void btnAddCard_Click(object sender, EventArgs e)
        {
            if (taskBoards.Count > 5)
            {
                MessageBox.Show("Добавлено максимальное число карточек");
                return;
            }
            else
            {
                //40 - значение из настроек. Брать из бд
                taskBoards.Add(new TaskBoard(40, "Выполняемая задача"));
                taskBoards[taskBoards.Count - 1].ClickOnPanel = ReleasePanels;
                Controls.Add(taskBoards[taskBoards.Count - 1].taskPanel);
            }
        }
        private void ReleasePanels()
        {
            for (int i = 0; i < taskBoards.Count; i++)
            {
                taskBoards[i].taskPanel.BackColor = taskBoards[i].tbBoardName.BackColor = taskBoards[i].tbTimerText.BackColor = SystemColors.Control;
                taskBoards[i].tbBoardName.ForeColor = taskBoards[i].btnStart.ForeColor = taskBoards[i].btnStop.ForeColor = taskBoards[i].tbTimerText.ForeColor = Color.Black;
            }
        }
        private void btnDeleteCard_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < taskBoards.Count; i++)
                if (taskBoards[i].taskPanel.BackColor != SystemColors.Control)
                {
                    Controls.Remove(taskBoards[i].taskPanel);
                    taskBoards.RemoveAt(i);
                    return;
                }
            MessageBox.Show("Выберите карточку для удаления");
        }
    }
}
