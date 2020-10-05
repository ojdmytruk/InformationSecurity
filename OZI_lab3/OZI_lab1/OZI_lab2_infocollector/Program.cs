using System;
using System.Management;
using System.IO;
using Microsoft.Win32;

namespace OZI_lab2_infocollector
{
    class Program
    {
        static void Main(string[] args)
        {
            string computerInfo = "";

            //інформація про комп'ютер
            SelectQuery SqComp = new SelectQuery("Win32_OperatingSystem");
            ManagementObjectSearcher compOSDetails = new ManagementObjectSearcher(SqComp);
            ManagementObjectCollection osDetailsCollectionComp = compOSDetails.Get();
            foreach (ManagementObject comp in osDetailsCollectionComp)
            {
                computerInfo += comp["SystemDirectory"].ToString();
                computerInfo += comp["WindowsDirectory"].ToString();
                Console.WriteLine("System directory: {0}", comp["SystemDirectory"].ToString());
                Console.WriteLine("Windows directory: {0}", comp["WindowsDirectory"].ToString());
            }
            computerInfo += Environment.MachineName;
            computerInfo += Environment.UserName;
            Console.WriteLine("Computer name: {0}", Environment.MachineName);
            Console.WriteLine("User name: {0}", Environment.UserName);

            //інформація про кількість кнопок мишки
            SelectQuery SqMouse = new SelectQuery("Win32_PointingDevice");
            ManagementObjectSearcher mouseOSDetails = new ManagementObjectSearcher(SqMouse);
            ManagementObjectCollection osDetailsCollectionMouse = mouseOSDetails.Get();
            foreach (ManagementObject mouse in osDetailsCollectionMouse)
            {
                computerInfo += mouse["NumberOfButtons"].ToString();
                Console.WriteLine("Number of mouse buttons : {0}", mouse["NumberOfButtons"].ToString());
            }

            //інформація про висоту екрану
            SelectQuery SqMonitor = new SelectQuery("Win32_VideoController");
            ManagementObjectSearcher monitorOSDetails = new ManagementObjectSearcher(SqMonitor);
            ManagementObjectCollection osDetailsCollectionMonitor = monitorOSDetails.Get();
            foreach (ManagementObject monitor in osDetailsCollectionMonitor)
            {
                computerInfo += monitor["CurrentVerticalResolution"].ToString();
                Console.WriteLine("Monitor Hight : {0}", monitor["CurrentVerticalResolution"].ToString());
            }

            //набір дискових пристроїв
            foreach (var drive in DriveInfo.GetDrives())
            {
                computerInfo += drive.Name;
                Console.WriteLine("Drive name: " + drive.Name);
            }

            //файлова система диску, на якому встановлена програма
            string root = Path.GetPathRoot(System.Reflection.Assembly.GetEntryAssembly().Location);
            DriveInfo driveInfo = new DriveInfo(root);
            computerInfo += driveInfo.DriveFormat;
            Console.WriteLine(driveInfo.DriveFormat);


            Console.WriteLine();
            Console.WriteLine("All computer info : {0}", computerInfo);

            var key = "gheju392pkjd902bhfj334j22030893j";
            var encryptedComputerInfo = Encryption.Encrypt(key, computerInfo);
            Console.WriteLine("Encrypted info : {0}", encryptedComputerInfo);
            SaveEncryptedInfo(encryptedComputerInfo);
            ReadEncryptedInfo();

            Console.ReadKey();

        }

        public static void SaveEncryptedInfo(string encryptedInfo) 
        {
            RegistryKey userKey = Registry.CurrentUser;
            RegistryKey personalKey = userKey.CreateSubKey("Dmytruk_");
            personalKey.SetValue("Dmytruk", encryptedInfo);
            personalKey.Close();
            Console.WriteLine();
            Console.WriteLine("Sign is added to registry");
            Console.WriteLine();

            
        }

        public static void ReadEncryptedInfo() 
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey personalKey = currentUserKey.OpenSubKey("Dmytruk_", true);

            try
            {
                string signedData = personalKey.GetValue("Dmytruk").ToString();
                Console.WriteLine(signedData);
            }
            catch
            {
                Console.WriteLine("Wrong key is provided. You cannot install program");
                Console.ReadKey();
            }
            
            personalKey.Close();            
        }

        public static void DeleteKey()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.OpenSubKey("Dmytruk_", true);
            helloKey.DeleteValue("Dmytruk");
            currentUserKey.DeleteSubKey("Dmytruk_");
        }
    }
}
