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
    public partial class PasswordPhrase : Form
    {
        public String passwordPhraseValue { get; set; }

        public PasswordPhrase()
        {
            InitializeComponent();
            passwordPhraseValue = "";
        }

        private void PasswordPhrase_Load(object sender, EventArgs e)
        {

        }

        private void submit_password_phrase_Click(object sender, EventArgs e)
        {
            if ((textBox_passwordPhrase.Text == null) || !textBox_passwordPhrase.Text.Any(x => char.IsLetter(x)) || !textBox_passwordPhrase.Text.Any(x => char.IsDigit(x)))
                MessageBox.Show("Поле парольної фрази не може бути пустим та складатись лише з пробілів та симвоів");
            else
                passwordPhraseValue = textBox_passwordPhrase.Text;
            EncryptUserInfo.CreateValue(passwordPhraseValue);

        }
    }
}
