
namespace Collective_Development.forms
{
    partial class formMainPage
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
            this.btnAddCard = new System.Windows.Forms.Button();
            this.btnDeleteCard = new System.Windows.Forms.Button();
            this.btnSaveCards = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddCard
            // 
            this.btnAddCard.Location = new System.Drawing.Point(299, 381);
            this.btnAddCard.Name = "btnAddCard";
            this.btnAddCard.Size = new System.Drawing.Size(137, 27);
            this.btnAddCard.TabIndex = 1;
            this.btnAddCard.Text = "Добавить карточку";
            this.btnAddCard.UseVisualStyleBackColor = true;
            this.btnAddCard.Click += new System.EventHandler(this.btnAddCard_Click);
            // 
            // btnDeleteCard
            // 
            this.btnDeleteCard.Location = new System.Drawing.Point(466, 381);
            this.btnDeleteCard.Name = "btnDeleteCard";
            this.btnDeleteCard.Size = new System.Drawing.Size(137, 27);
            this.btnDeleteCard.TabIndex = 2;
            this.btnDeleteCard.Text = "Удалить карточку";
            this.btnDeleteCard.UseVisualStyleBackColor = true;
            this.btnDeleteCard.Click += new System.EventHandler(this.btnDeleteCard_Click);
            // 
            // btnSaveCards
            // 
            this.btnSaveCards.Location = new System.Drawing.Point(130, 381);
            this.btnSaveCards.Name = "btnSaveCards";
            this.btnSaveCards.Size = new System.Drawing.Size(137, 27);
            this.btnSaveCards.TabIndex = 3;
            this.btnSaveCards.Text = "Сохранить";
            this.btnSaveCards.UseVisualStyleBackColor = true;
            this.btnSaveCards.Click += new System.EventHandler(this.btnSaveCards_Click);
            // 
            // formMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 411);
            this.Controls.Add(this.btnSaveCards);
            this.Controls.Add(this.btnDeleteCard);
            this.Controls.Add(this.btnAddCard);
            this.Name = "formMainPage";
            this.Text = "Ваши карточки";
            this.Load += new System.EventHandler(this.formMainPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddCard;
        private System.Windows.Forms.Button btnDeleteCard;
        private System.Windows.Forms.Button btnSaveCards;
    }
}