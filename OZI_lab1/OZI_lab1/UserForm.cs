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
    public partial class UserForm : Form
    {
        User user = new User();

        public UserForm(User userObj)
        {
            InitializeComponent();
            user = userObj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(user.Name);
            changePassword.Show();
        }

        private void button3_Click(object sender, EventArgs e)
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
