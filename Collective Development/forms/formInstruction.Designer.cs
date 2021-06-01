
namespace Collective_Development.forms
{
    partial class formInstruction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formInstruction));
            this.lblRusDoc = new System.Windows.Forms.Label();
            this.btnChangeLanguage = new System.Windows.Forms.Button();
            this.lblEngDoc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRusDoc
            // 
            this.lblRusDoc.AllowDrop = true;
            this.lblRusDoc.AutoSize = true;
            this.lblRusDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRusDoc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRusDoc.Location = new System.Drawing.Point(0, 0);
            this.lblRusDoc.Name = "lblRusDoc";
            this.lblRusDoc.Size = new System.Drawing.Size(624, 403);
            this.lblRusDoc.TabIndex = 0;
            this.lblRusDoc.Text = resources.GetString("lblRusDoc.Text");
            // 
            // btnChangeLanguage
            // 
            this.btnChangeLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeLanguage.Location = new System.Drawing.Point(433, 397);
            this.btnChangeLanguage.Name = "btnChangeLanguage";
            this.btnChangeLanguage.Size = new System.Drawing.Size(167, 27);
            this.btnChangeLanguage.TabIndex = 7;
            this.btnChangeLanguage.Text = "English";
            this.btnChangeLanguage.UseVisualStyleBackColor = true;
            this.btnChangeLanguage.Click += new System.EventHandler(this.btnChangeLanguage_Click);
            // 
            // lblEngDoc
            // 
            this.lblEngDoc.AllowDrop = true;
            this.lblEngDoc.AutoSize = true;
            this.lblEngDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEngDoc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEngDoc.Location = new System.Drawing.Point(0, 0);
            this.lblEngDoc.Name = "lblEngDoc";
            this.lblEngDoc.Size = new System.Drawing.Size(600, 351);
            this.lblEngDoc.TabIndex = 8;
            this.lblEngDoc.Text = resources.GetString("lblEngDoc.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Language of documentation:";
            // 
            // formInstruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEngDoc);
            this.Controls.Add(this.btnChangeLanguage);
            this.Controls.Add(this.lblRusDoc);
            this.Name = "formInstruction";
            this.Text = "Пользовательская документация";
            this.Load += new System.EventHandler(this.formInstruction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRusDoc;
        private System.Windows.Forms.Button btnChangeLanguage;
        private System.Windows.Forms.Label lblEngDoc;
        private System.Windows.Forms.Label label1;
    }
}