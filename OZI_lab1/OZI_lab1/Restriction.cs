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
    public partial class Restriction : Form
    {
        UserContext userContext = new UserContext();

        public Restriction()
        {
            InitializeComponent();
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
            else if (userContext.Users.Find(userName.Text).Restriction == true)
            {
                MessageBox.Show("Обмеження вже накладено.");
            }
            else
            {
                userContext.Users.Find(userName.Text).Restriction = true;
                MessageBox.Show("Користувача успішно обмежено в паролях.");
            }

            userContext.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (userName.Text == "")
            {
                MessageBox.Show("Введіть ім`я користувача.");
            }
            else if (userContext.Users.Find(userName.Text) == null)
            {
                MessageBox.Show("Користувача з таким іменем не існує.");
            }
            else if (userContext.Users.Find(userName.Text).Restriction == false)
            {
                MessageBox.Show("Користувач не обмежений.");
            }
            else
            {
                userContext.Users.Find(userName.Text).Restriction = false;
                MessageBox.Show("Обмеження успішно зняті.");
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
