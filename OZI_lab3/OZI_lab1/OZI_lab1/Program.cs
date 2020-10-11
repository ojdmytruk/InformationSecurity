using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OZI_lab1
{
    static class Program
    {        
        [STAThread]
        static void Main()
        {
            string key = "yIDkNUvqZFxeicQ6p7Y1vQ==";
            FileStream fileStream = new FileStream("hash.txt", FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream);
            if (key == streamReader.ReadLine())
            {
                UserContext db = new UserContext();
                UserCopyContext dbc = new UserCopyContext();

                if (db.Users.Find("olesiaDmytruk") == null)
                {
                    db.Users.Add(new User { Name = "olesiaDmytruk", Role = "admin", Password = "Olesia,24", PasswordLength = 9, Blocked = false, Restriction = true });
                }

                db.SaveChanges();

                foreach (var user in db.Users)
                {
                    dbc.Users.Add(db.Users.Find(user));
                }
                dbc.SaveChanges();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("Невірний ключ");
            }
                                    
            
        }
    }
}
