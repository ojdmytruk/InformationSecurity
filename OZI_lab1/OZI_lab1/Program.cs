using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OZI_lab1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var key = "gheju392pkjd902bhfj334j22030893j";
            UserContext db = new UserContext();
            db.Users.Remove(db.Users.Find("olesiaDmytruk"));
            string encryptedPassword = Encryption.Encrypt(key, "Olesia,24");
            if (db.Users.Find("olesiaDmytruk") == null)
            {
                db.Users.Add(new User { Name = "olesiaDmytruk", Role = "admin", Password = encryptedPassword, PasswordLength = 9, Blocked = false, Restriction = true });
            }
            
            db.SaveChanges();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
