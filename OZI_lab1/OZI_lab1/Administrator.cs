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
    public partial class Administrator : Form
    {
        User user = new User();

        public Administrator(User userObj)
        {
            InitializeComponent();
            user = userObj;
        }

        private void changePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(user.Name);
            changePassword.Show();
        }

        private void controlUsers_Click(object sender, EventArgs e)
        {
            UserControl userControl = new UserControl(user);
            userControl.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
    }
}
