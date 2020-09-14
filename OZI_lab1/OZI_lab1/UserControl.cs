using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OZI_lab1
{
    public partial class UserControl : Form
    {
        User user = new User();
        UserContext userContext = new UserContext();

        public UserControl(User userObj)
        {
            InitializeComponent();
            user = userObj;
            dataGridViewUsers.DataSource = userContext.Users.ToList();

        }

        private void addUser_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
        }

        private void blockUser_Click(object sender, EventArgs e)
        {
            BlockUser blockUser = new BlockUser();
            blockUser.Show();
        }

        private void restrictUser_Click(object sender, EventArgs e)
        {
            Restriction restriction = new Restriction();
            restriction.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
    }
}
