using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Collective_Development
{
    class TaskBoard
    {
        public Panel taskPanel;
        private Timer timer;
        public Button btnStart, btnStop;
        public TextBox tbBoardName, tbTimerText;
        private int current_min, current_sec, default_min;
        public bool allowDel;
        public TaskBoard(int m, string name, bool allowDel)
        {
            taskPanel = new Panel();
            taskPanel.Dock = DockStyle.Top;
            taskPanel.Size = new System.Drawing.Size(641, 60);
            taskPanel.BorderStyle = BorderStyle.FixedSingle;
            taskPanel.Click += new EventHandler(taskPanel_Click);

            tbBoardName = new TextBox();
            tbBoardName.Text = name;
            tbBoardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbBoardName.BackColor = System.Drawing.SystemColors.Control;
            tbBoardName.BorderStyle = BorderStyle.Fixed3D;
            tbBoardName.Size = new System.Drawing.Size(190, 19);
            tbBoardName.Location = new System.Drawing.Point(28, 21);

            tbTimerText = new TextBox();
            tbTimerText.Text = Convert.ToString(m) + ":00";
            tbTimerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbTimerText.BackColor = System.Drawing.SystemColors.Control;
            tbTimerText.BorderStyle = BorderStyle.None;
            tbTimerText.Size = new System.Drawing.Size(82, 31);
            tbTimerText.Location = new System.Drawing.Point(240, 14);
            tbTimerText.TextChanged += new EventHandler(tbTimerText_TextChanged);

            btnStart = new Button();
            btnStart.Text = "Пуск";
            btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnStart.Size = new System.Drawing.Size(128, 38);
            btnStart.Location = new System.Drawing.Point(350, 10);
            btnStart.Click += new EventHandler(btnStart_Click);

            btnStop = new Button();
            btnStop.Text = "Стоп";
            btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnStop.Size = new System.Drawing.Size(128, 38);
            btnStop.Location = new System.Drawing.Point(500, 10);
            btnStop.Click += new EventHandler(btnStop_Click);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);

            taskPanel.Controls.Add(btnStart);
            taskPanel.Controls.Add(btnStop);
            taskPanel.Controls.Add(tbBoardName);
            taskPanel.Controls.Add(tbTimerText);

            default_min = current_min = m;
            current_sec = 0;
            this.allowDel = allowDel;
        }
        void tbTimerText_TextChanged(object sender, EventArgs e)
        {
            //int new_min, new_sec;
            //if (tbTimerText.Text.Contains(':') &&
            //    Int32.TryParse(tbTimerText.Text.Substring(0, tbTimerText.Text.IndexOf(':')), out new_min) &&
            //        Int32.TryParse(tbTimerText.Text.Substring(2, tbTimerText.Text.IndexOf(':') + 1), out new_sec))
            //{
            //    current_min = new_min;
            //    current_sec = new_sec;
            //}
            //else
            //    MessageBox.Show("Введите корректные данные!");
        }
        void btnStart_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                timer.Start();
                btnStart.Text = "Пауза";
                tbTimerText.ReadOnly = true;
            }
            else 
            {
                timer.Stop();
                btnStart.Text = "Пуск";
                tbTimerText.ReadOnly = false;
            }
        }
        void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            tbTimerText.Text = Convert.ToString(default_min) + ":00";
            current_min = default_min;
            current_sec = 0;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            current_sec = current_sec - 1;
            if (current_sec == -1)
            {
                current_min = current_min - 1;
                current_sec = 59;
            }
            if (current_min == 0 && current_sec == 0)
            {
                timer.Stop();
                MessageBox.Show("Время вышло!");
            }
            tbTimerText.Text = Convert.ToString(current_min) + ":" + Convert.ToString(current_sec);
        }
        public Action ClickOnPanel { get { return TaskPanel_Click; } set { TaskPanel_Click = value; } }
        private Action TaskPanel_Click;
        private void taskPanel_Click(object sender, EventArgs e)
        {
            TaskPanel_Click();
            Panel panel = (Panel)sender;
            panel.BackColor = tbBoardName.BackColor = tbTimerText.BackColor = ThemeColor.SecondaryColor;
            tbBoardName.ForeColor = btnStart.ForeColor = btnStop.ForeColor = tbTimerText.ForeColor = Color.Gainsboro;
        }
    }
}
