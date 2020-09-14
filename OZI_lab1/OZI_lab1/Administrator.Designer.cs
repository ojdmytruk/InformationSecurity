namespace OZI_lab1
{
    partial class Administrator
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
            this.changePassword = new System.Windows.Forms.Button();
            this.controlUsers = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // changePassword
            // 
            this.changePassword.Location = new System.Drawing.Point(34, 32);
            this.changePassword.Name = "changePassword";
            this.changePassword.Size = new System.Drawing.Size(109, 36);
            this.changePassword.TabIndex = 0;
            this.changePassword.Text = "Змінити пароль";
            this.changePassword.UseVisualStyleBackColor = true;
            this.changePassword.Click += new System.EventHandler(this.changePassword_Click);
            // 
            // controlUsers
            // 
            this.controlUsers.Location = new System.Drawing.Point(34, 74);
            this.controlUsers.Name = "controlUsers";
            this.controlUsers.Size = new System.Drawing.Size(109, 36);
            this.controlUsers.TabIndex = 1;
            this.controlUsers.Text = "Керування користувачами";
            this.controlUsers.UseVisualStyleBackColor = true;
            this.controlUsers.Click += new System.EventHandler(this.controlUsers_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(34, 141);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(109, 36);
            this.exit.TabIndex = 2;
            this.exit.Text = "Вихід";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(125, 2);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(48, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Довідка";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 211);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.controlUsers);
            this.Controls.Add(this.changePassword);
            this.Name = "Administrator";
            this.Text = "Administrator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changePassword;
        private System.Windows.Forms.Button controlUsers;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}