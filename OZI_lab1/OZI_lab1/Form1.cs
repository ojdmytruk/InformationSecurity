using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace OZI_lab1
{
    public partial class Form1 : Form
    {
        UserContext db = new UserContext();
        User user = new User();
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private bool IsUserNameValid()
        {
            if (usernameTextBox.Text == "")
            {
                MessageBox.Show("Введіть ім`я користувача.");
                return false;
            }
            else if (db.Users.Find(usernameTextBox.Text) == null)
            {
                MessageBox.Show("Користувача з таким іменем не існує.");
                return false;
            }
            else if (db.Users.Find(usernameTextBox.Text).Blocked == true)
            {
                MessageBox.Show("Користувач заблокований.");
                return false;
            }
            else
            {
                user = db.Users.Find(usernameTextBox.Text);
                return true;
            }
        }

        private bool IsPasswordValid()
        {
            var key = "gheju392pkjd902bhfj334j22030893j";
            if (Encryption.Decrypt(key, user.Password) != passwordTextBox.Text)
            {
                MessageBox.Show("Невірний пароль.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (IsUserNameValid())
            {
                if (IsPasswordValid())
                {
                    if (user.Role == "admin")
                    {
                        Administrator administrator = new Administrator(user);
                        administrator.Show();
                    }
                    else if (user.Role == "user")
                    {
                        UserForm userForm = new UserForm(user);
                        userForm.Show();
                    }
                }
                else
                {
                    if (counter == 3)
                    {
                        Close();
                    }                    
                    counter++;
                }
            }              

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
    }
}
