using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OZI_lab1
{
    public partial class AddUser : Form
    {
        UserCopyContext userContext = new UserCopyContext();

        public AddUser()
        {
            InitializeComponent();
        }

        private bool IsPasswordPossible(string password)
        {
            if ((password.Any(c => char.IsLetter(c))) && (password.Any(c => char.IsNumber(c))) && (password.Any(c => char.IsPunctuation(c))))
                return true;
            else return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userContext.Users.Find(userName.Text) != null)
                MessageBox.Show("Користувач з таким іменем існує");
            else if (IsPasswordPossible(password.Text))
            {
                userContext.Users.Add(new User { Name = userName.Text, Password = password.Text, PasswordLength = password.Text.Length, Blocked = false, Restriction = true, Role = "user" });
                MessageBox.Show("Користувача додано");
            }
            else MessageBox.Show("Пароль має містити букви, цифри та розділові знаки");
            userContext.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (userContext.Users.Find(userName.Text) != null)
                MessageBox.Show("Користувач з таким іменем існує");
            else if (password.Text != "")
                MessageBox.Show("Пароль повинен бути вiдсутнім");
            else
            {
                userContext.Users.Add(new User { Name = userName.Text, Password = null, PasswordLength = 0, Blocked = false, Restriction = false, Role = "user" });
                MessageBox.Show("Користувача додано");
            }
            userContext.SaveChanges();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
    }
}
