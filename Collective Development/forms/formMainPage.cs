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
        private List<TaskBoard> taskBoards = new List<TaskBoard>();
        public forms.formSettings formSettings;
        public formMainPage(forms.formSettings formSettings)
        {
            InitializeComponent();
            this.formSettings = formSettings;
            btnSaveCards.Visible = false;
        }

        public IEnumerable<data.Card> GetCards()
        {
            foreach (var task in taskBoards)
            {
                yield return new data.Card()
                {
                    Min = task.current_min,
                    Sec = task.current_sec,
                    Name = task.tbBoardName.Text
                };
            }
        }

        public void AddTaskBoards(IEnumerable<data.Card> cards)
        {
            taskBoards = new List<TaskBoard>();

            foreach (var card in cards)
            {
                taskBoards.Add(new TaskBoard(card.Min, card.Sec, card.Name, true, this));
            }
            foreach (var taskBoard in  taskBoards)
            {
                Controls.Add(taskBoard.taskPanel);
                taskBoard.ClickOnPanel = ReleasePanels;
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
                taskBoards.Add(new TaskBoard(formSettings.defaultWorkTime, 0, "Выполняемая задача", false, this));
                taskBoards[taskBoards.Count - 1].ClickOnPanel = ReleasePanels;
                Controls.Add(taskBoards[taskBoards.Count - 1].taskPanel);
            }
        }
        public void StartBreak()
        {
            for (int i = 0; i < taskBoards.Count; i++)
            {
                if (taskBoards[i].tbBoardName.Text == "Перерыв")
                    taskBoards[i].btnStart_Click(null, null);
            }
        }
        public void ReleasePanels()
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
                    if (!taskBoards[i].readOnly)
                    {
                        Controls.Remove(taskBoards[i].taskPanel);
                        taskBoards.RemoveAt(i);
                    }
                    else MessageBox.Show("Вы не можете удалять стандартные карточки");
                    return;
                }
            MessageBox.Show("Выберите карточку для удаления");
        }
        public void ActiveBtnSave()
        {
            btnSaveCards.Visible = true;
        }
        private void btnSaveCards_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < taskBoards.Count; i++)
            {
                int new_min, new_sec;
                if (taskBoards[i].tbTimerText.Text.Contains(':') &&
                    Int32.TryParse(taskBoards[i].tbTimerText.Text.Substring(0, taskBoards[i].tbTimerText.Text.IndexOf(':')), out new_min) &&
                    Int32.TryParse(taskBoards[i].tbTimerText.Text.Substring(taskBoards[i].tbTimerText.Text.IndexOf(':') + 1, taskBoards[i].tbTimerText.Text.Length - taskBoards[i].tbTimerText.Text.IndexOf(':') - 1), out new_sec) &&
                    new_sec <= 60)
                {
                    taskBoards[i].current_min =taskBoards[i].default_min= new_min;
                    taskBoards[i].current_sec =taskBoards[i].default_sec= new_sec;
                }
                else
                {
                    MessageBox.Show("Введите корректные данные!");
                    return;
                }
            }
            btnSaveCards.Visible = false;
            //сохранять все карточки в бд
            for (int i = 0; i < taskBoards.Count; i++)
            {
                taskBoards[i].btnStart.Enabled = taskBoards[i].btnStop.Enabled = true;
            }

        }
    }
}
