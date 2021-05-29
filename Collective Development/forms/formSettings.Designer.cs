
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tbDefaulWorkTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(41, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(160, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Блокировка клавиатуры";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(41, 81);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(119, 19);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Звуковой сигнал";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // tbDefaulWorkTime
            // 
            this.tbDefaulWorkTime.Location = new System.Drawing.Point(306, 30);
            this.tbDefaulWorkTime.Name = "tbDefaulWorkTime";
            this.tbDefaulWorkTime.Size = new System.Drawing.Size(71, 23);
            this.tbDefaulWorkTime.TabIndex = 5;
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
            this.btnSaveChanges.Location = new System.Drawing.Point(418, 341);
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
            this.ClientSize = new System.Drawing.Size(625, 391);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.tbDefaulWorkTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Name = "formSettings";
            this.Text = "formSettings";
            this.Load += new System.EventHandler(this.FormPage1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox tbDefaulWorkTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveChanges;
    }
}