
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
            this.chbxKeyboardBlock.Location = new System.Drawing.Point(41, 56);
            this.chbxKeyboardBlock.Name = "chbxKeyboardBlock";
            this.chbxKeyboardBlock.Size = new System.Drawing.Size(160, 19);
            this.chbxKeyboardBlock.TabIndex = 0;
            this.chbxKeyboardBlock.Text = "Блокировка клавиатуры";
            this.chbxKeyboardBlock.UseVisualStyleBackColor = true;
            this.chbxKeyboardBlock.CheckedChanged += new System.EventHandler(this.chbxKeyboardBlock_CheckedChanged);
            // 
            // chbxSound
            // 
            this.chbxSound.AutoSize = true;
            this.chbxSound.Location = new System.Drawing.Point(41, 81);
            this.chbxSound.Name = "chbxSound";
            this.chbxSound.Size = new System.Drawing.Size(119, 19);
            this.chbxSound.TabIndex = 1;
            this.chbxSound.Text = "Звуковой сигнал";
            this.chbxSound.UseVisualStyleBackColor = true;
            this.chbxSound.CheckedChanged += new System.EventHandler(this.chbxSound_CheckedChanged);
            // 
            // tbDefaulWorkTime
            // 
            this.tbDefaulWorkTime.Location = new System.Drawing.Point(306, 30);
            this.tbDefaulWorkTime.Name = "tbDefaulWorkTime";
            this.tbDefaulWorkTime.Size = new System.Drawing.Size(71, 23);
            this.tbDefaulWorkTime.TabIndex = 5;
            this.tbDefaulWorkTime.TextChanged += new System.EventHandler(this.tbDefaulWorkTime_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Длительность работы по умолчанию (мин):";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.Location = new System.Drawing.Point(446, 381);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(167, 27);
            this.btnSaveChanges.TabIndex = 6;
            this.btnSaveChanges.Text = "Сохранить изменения";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 411);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.tbDefaulWorkTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbxSound);
            this.Controls.Add(this.chbxKeyboardBlock);
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