namespace OZI_lab1
{
    partial class PasswordPhrase
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
            this.textBox_passwordPhrase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.submit_password_phrase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_passwordPhrase
            // 
            this.textBox_passwordPhrase.Location = new System.Drawing.Point(13, 38);
            this.textBox_passwordPhrase.Name = "textBox_passwordPhrase";
            this.textBox_passwordPhrase.Size = new System.Drawing.Size(350, 20);
            this.textBox_passwordPhrase.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введіть парольну фразу:";
            // 
            // submit_password_phrase
            // 
            this.submit_password_phrase.Location = new System.Drawing.Point(135, 64);
            this.submit_password_phrase.Name = "submit_password_phrase";
            this.submit_password_phrase.Size = new System.Drawing.Size(102, 38);
            this.submit_password_phrase.TabIndex = 2;
            this.submit_password_phrase.Text = "Встановити парольну фразу";
            this.submit_password_phrase.UseVisualStyleBackColor = true;
            this.submit_password_phrase.Click += new System.EventHandler(this.submit_password_phrase_Click);
            // 
            // PasswordPhrase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 114);
            this.Controls.Add(this.submit_password_phrase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_passwordPhrase);
            this.Name = "PasswordPhrase";
            this.Text = "PasswordPhrase";
            this.Load += new System.EventHandler(this.PasswordPhrase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_passwordPhrase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submit_password_phrase;
    }
}