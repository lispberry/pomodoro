using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Media;
using Tulpep.NotificationWindow;

namespace Collective_Development
{
    class TaskBoard
    {
        public Panel taskPanel;
        private Timer timer;
        public Button btnStart, btnStop;
        public TextBox tbBoardName, tbTimerText;
        public int current_min, current_sec, default_min, default_sec;
        public bool readOnly;
        private forms.formMainPage parentForm;
        public SoundPlayer player1;
        public SoundPlayer player2;

        public TaskBoard(int m, int s, string name, bool readOnly, forms.formMainPage parentForm)
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
            tbBoardName.ReadOnly = readOnly;
            tbBoardName.TextChanged+= new EventHandler(tbBoardName_TextChanged);

            tbTimerText = new TextBox();
            tbTimerText.Text = Convert.ToString(m) + ":0";
            tbTimerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbTimerText.BackColor = System.Drawing.SystemColors.Control;
            tbTimerText.BorderStyle = BorderStyle.None;
            tbTimerText.Size = new System.Drawing.Size(82, 31);
            tbTimerText.Location = new System.Drawing.Point(255, 14);
            tbTimerText.TextChanged += new EventHandler(tbTimerText_TextChanged);
            tbTimerText.KeyPress += new KeyPressEventHandler(tbTimerText_KeyPress);
            tbTimerText.MaxLength = 5;

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
            default_sec = current_sec = s;
            this.readOnly = readOnly;
            this.parentForm = parentForm;

            player1 = new SoundPlayer();
            player1.Stream = Properties.Resources.sound1;
            player2 = new SoundPlayer();
            player2.Stream = Properties.Resources.sound2;
        }

        void tbTimerText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(":")) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
        void tbTimerText_TextChanged(object sender, EventArgs e)
        {
            if (tbTimerText.Focused)
            {
                btnStart.Enabled = btnStop.Enabled = false;
                parentForm.ActiveBtnSave();
            }
        }
        void tbBoardName_TextChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = btnStop.Enabled = false;
            parentForm.ActiveBtnSave();
        }
        public void btnStart_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                timer.Start();
                btnStart.Text = "Пауза";
                //tbTimerText.ReadOnly = true;
                tbTimerText.Enabled = false;
            }
            else 
            {
                timer.Stop();
                btnStart.Text = "Пуск";
                //tbTimerText.ReadOnly = false;
                tbTimerText.Enabled = true;
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            tbTimerText.Text = Convert.ToString(default_min) + ":" + Convert.ToString(default_sec);
            current_min = default_min;
            current_sec = default_sec;
            btnStart.Text = "Пуск";
            //tbTimerText.ReadOnly = false;
            tbTimerText.Enabled = true;
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
                if (parentForm.formSettings.soundSignal)
                {
                    if (tbBoardName.Text != "Перерыв")
                    {
                        player1.Play();
                        if (true)
                        {
                            Task.Factory.StartNew(async () =>
                            {
                                await Task.Delay(TimeSpan.FromSeconds(4));
                                player1.Stop();
                            });
                        }
                    }
                    else
                    {
                        player2.Play();
                        if (true)
                        {
                            Task.Factory.StartNew(async () =>
                            {
                                await Task.Delay(TimeSpan.FromSeconds(3.18));
                                player2.Stop();
                            });
                        }
                    }
                }
                if (tbBoardName.Text != "Перерыв")
                {
                    //MessageBox.Show("Время работы вышло. Начинается время отдыха");
                    parentForm.StartBreak();

                    PopupNotifier popup = new PopupNotifier();

                    popup.HeaderHeight = 1;
                    popup.ShowGrip = false;
                    popup.HeaderColor = ThemeColor.SecondaryColor;
                    popup.BodyColor = ThemeColor.PrimaryColor;
                    popup.Delay = 10000;

                    popup.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
                    popup.TitleColor = Color.Gainsboro;
                    popup.TitleText = "ПОРА ОТДОХНУТЬ!";

                    popup.ContentFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
                    popup.ContentColor = Color.Gainsboro;
                    popup.ContentText = "Совет: попейте воды, встаньте со стула и разомнитесь";

                    popup.Popup();

                    timer.Stop();
                }
                else
                {
                    PopupNotifier popupEnd = new PopupNotifier();
                 
                    popupEnd.HeaderHeight = 1;
                    popupEnd.ShowGrip = false;
                    popupEnd.HeaderColor = ThemeColor.SecondaryColor;
                    popupEnd.BodyColor = ThemeColor.PrimaryColor;
                    popupEnd.Delay = 10000;

                    popupEnd.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
                    popupEnd.TitleColor = Color.Gainsboro;
                    popupEnd.TitleText = "ПОРА ЗА РАБОТУ!";

                    popupEnd.ContentFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
                    popupEnd.ContentColor = Color.Gainsboro;
                    popupEnd.ContentText = "Совет: сконцентрируйтесь";

                    popupEnd.Popup();
                }

                tbTimerText.Text = Convert.ToString(default_min) + ":" + Convert.ToString(default_sec);
                current_min = default_min;
                current_sec = default_sec;
                btnStart.Text = "Пуск";
                //tbTimerText.ReadOnly = false;
                tbTimerText.Enabled = true;
            }
            tbTimerText.Text = Convert.ToString(current_min) + ":" + Convert.ToString(current_sec);
        }
        public Action ClickOnPanel { get { return TaskPanel_Click; } set { TaskPanel_Click = value; } }
        private Action TaskPanel_Click;
        private void taskPanel_Click(object sender, EventArgs e)
        {
            parentForm.ReleasePanels();
            Panel panel = (Panel)sender;
            panel.BackColor = tbBoardName.BackColor = tbTimerText.BackColor = ThemeColor.SecondaryColor;
            tbBoardName.ForeColor = btnStart.ForeColor = btnStop.ForeColor = tbTimerText.ForeColor = Color.Gainsboro;
        }
    }
}
