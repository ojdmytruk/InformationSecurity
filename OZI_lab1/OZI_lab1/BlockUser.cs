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
    public partial class BlockUser : Form
    {
        UserContext userContext = new UserContext();

        public BlockUser()
        {
            InitializeComponent();
        }

        private void blockEnteredUser_Click(object sender, EventArgs e)
        {
            if (userName.Text == "")
            {
                MessageBox.Show("Введіть ім`я користувача.");
            }
            else if (userContext.Users.Find(userName.Text) == null)
            {
                MessageBox.Show("Користувача з таким іменем не існує.");
            }
            else if (userContext.Users.Find(userName.Text).Blocked == true)
            {
                MessageBox.Show("Користувач вже заблокований.");
            }
            else
            {
                userContext.Users.Find(userName.Text).Blocked = true;
                MessageBox.Show("Користувача успішно заблоковано.");
            }
            userContext.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userName.Text == "")
            {
                MessageBox.Show("Введіть ім`я користувача.");
            }
            else if (userContext.Users.Find(userName.Text) == null)
            {
                MessageBox.Show("Користувача з таким іменем не існує.");
            }
            else if (userContext.Users.Find(userName.Text).Blocked == false)
            {
                MessageBox.Show("Користувач не заблокований.");
            }
            else
            {
                userContext.Users.Find(userName.Text).Blocked = false;
                MessageBox.Show("Користувача успішно розблоковано.");
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
