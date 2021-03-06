
namespace Collective_Development.forms
{
    partial class formSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chbxKeyboardBlock = new System.Windows.Forms.CheckBox();
            this.chbxSound = new System.Windows.Forms.CheckBox();
            this.tbDefaulWorkTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chbxKeyboardBlock
            // 
            this.chbxKeyboardBlock.AutoSize = true;
            this.chbxKeyboardBlock.Location = new System.Drawing.Point(76, 119);
            this.chbxKeyboardBlock.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chbxKeyboardBlock.Name = "chbxKeyboardBlock";
            this.chbxKeyboardBlock.Size = new System.Drawing.Size(314, 36);
            this.chbxKeyboardBlock.TabIndex = 0;
            this.chbxKeyboardBlock.Text = "Блокировка клавиатуры";
            this.chbxKeyboardBlock.UseVisualStyleBackColor = true;
            this.chbxKeyboardBlock.CheckedChanged += new System.EventHandler(this.chbxKeyboardBlock_CheckedChanged);
            // 
            // chbxSound
            // 
            this.chbxSound.AutoSize = true;
            this.chbxSound.Location = new System.Drawing.Point(76, 173);
            this.chbxSound.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chbxSound.Name = "chbxSound";
            this.chbxSound.Size = new System.Drawing.Size(231, 36);
            this.chbxSound.TabIndex = 1;
            this.chbxSound.Text = "Звуковой сигнал";
            this.chbxSound.UseVisualStyleBackColor = true;
            this.chbxSound.CheckedChanged += new System.EventHandler(this.chbxSound_CheckedChanged);
            // 
            // tbDefaulWorkTime
            // 
            this.tbDefaulWorkTime.Location = new System.Drawing.Point(568, 64);
            this.tbDefaulWorkTime.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbDefaulWorkTime.MaxLength = 2;
            this.tbDefaulWorkTime.Name = "tbDefaulWorkTime";
            this.tbDefaulWorkTime.Size = new System.Drawing.Size(128, 39);
            this.tbDefaulWorkTime.TabIndex = 5;
            this.tbDefaulWorkTime.TextChanged += new System.EventHandler(this.tbDefaulWorkTime_TextChanged);
            this.tbDefaulWorkTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDefaulWorkTime_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(498, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Длительность работы по умолчанию (мин):";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.Location = new System.Drawing.Point(828, 813);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(310, 58);
            this.btnSaveChanges.TabIndex = 6;
            this.btnSaveChanges.Text = "Сохранить изменения";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 877);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.tbDefaulWorkTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbxSound);
            this.Controls.Add(this.chbxKeyboardBlock);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "formSettings";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.FormPage1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbxKeyboardBlock;
        private System.Windows.Forms.CheckBox chbxSound;
        private System.Windows.Forms.TextBox tbDefaulWorkTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveChanges;
    }
}