using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace OZI_lab1
{
    public class EncryptUserInfo
    {
        public static void CreateValue(string passwordPhrase)
        {
            Random random = new Random();
            int num_letters = 5;
            char[] letters = "abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
            string word = "";
            for (int j = 1; j <= num_letters; j++)
            {
                int letter_num = random.Next(0, letters.Length - 1);
                word += letters[letter_num];
            }
            string phraseForHash = passwordPhrase + word;

            //DES - блоковий
            DES DESalg = DES.Create();
            string FileName = "des.txt";
            EncryptTextToFile(phraseForHash, FileName, DESalg.Key, DESalg.IV);
            FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fStream);
            
            string desKey = streamReader.ReadLine();
            fStream.Close();
            streamReader.Close();
            //CFB - зворотній зв'язок
            byte[] plainBytes = Encoding.UTF8.GetBytes(desKey);
            byte[] savedKey = new byte[16];
            byte[] savedIV = new byte[16];
            byte[] cipherBytes;
            using (RijndaelManaged Aes128 = new RijndaelManaged())
            {
                Aes128.BlockSize = 128;
                Aes128.KeySize = 128;
                Aes128.Mode = CipherMode.CFB;
                Aes128.FeedbackSize = 8;
                Aes128.Padding = PaddingMode.None;
                Aes128.GenerateKey();
                Aes128.GenerateIV();
                Aes128.Key.CopyTo(savedKey, 0);
                Aes128.IV.CopyTo(savedIV, 0);

                using (var encryptor = Aes128.CreateEncryptor())
                using (var msEncrypt = new MemoryStream())
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (var bw = new BinaryWriter(csEncrypt, Encoding.UTF8))
                {
                    bw.Write(plainBytes);
                    bw.Close();

                    cipherBytes = msEncrypt.ToArray();
                }               
            }
            string cfbKey = cipherBytes.ToString();

            //MD2
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
            crypt.HashAlgorithm = "md2";
            string hashFinal = crypt.HashStringENC(cfbKey);
            FileStream fStreamF = File.Open("hash.txt", FileMode.OpenOrCreate);
            StreamWriter sWriter = new StreamWriter(fStreamF);
            sWriter.WriteLine(hashFinal);
            sWriter.Close();
            fStreamF.Close();
        }

        public static void EncryptTextToFile(String Data, String FileName, byte[] Key, byte[] IV)
        {
            try
            {
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // DES - блокове симетричне шифрування
                DES DESalg = DES.Create();
                CryptoStream cStream = new CryptoStream(fStream, DESalg.CreateEncryptor(Key, IV), CryptoStreamMode.Write);
                StreamWriter sWriter = new StreamWriter(cStream);
                sWriter.WriteLine(Data);
                sWriter.Close();
                cStream.Close();
                fStream.Close();
            }
            catch (CryptographicException e)
            {                
            }
            catch (UnauthorizedAccessException e)
            {
            }
        }

        public static string DecryptTextFromFile(String FileName, byte[] Key, byte[] IV)
        {
            try
            {
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);
                DES DESalg = DES.Create();
                CryptoStream cStream = new CryptoStream(fStream, DESalg.CreateDecryptor(Key, IV), CryptoStreamMode.Read);
                StreamReader sReader = new StreamReader(cStream);
                string val = sReader.ReadLine();
                sReader.Close();
                cStream.Close();
                fStream.Close();
                return val;
            }
            catch (CryptographicException e)
            {
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                return null;
            }

           
            
        }


        public static void EncryptFile(string inFile)
        {
            const string EncrFolder = @"c:\Encrypt\";
            Aes aes = Aes.Create();
            ICryptoTransform transform = aes.CreateEncryptor();
            FileStream fStreamF = File.Open("hash.txt", FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fStreamF);
            byte[] keyEncrypted = Encoding.ASCII.GetBytes(streamReader.ReadLine());
            fStreamF.Close();
            streamReader.Close();

            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            int lKey = keyEncrypted.Length;
            LenK = BitConverter.GetBytes(lKey);
            int lIV = aes.IV.Length;
            LenIV = BitConverter.GetBytes(lIV);

            int startFileName = inFile.LastIndexOf("\\") + 1;
            string outFile = EncrFolder + inFile.Substring(startFileName, inFile.LastIndexOf(".") - startFileName) + ".enc";

            using (FileStream outFs = new FileStream(outFile, FileMode.Create))
            {

                outFs.Write(LenK, 0, 4);
                outFs.Write(LenIV, 0, 4);
                outFs.Write(keyEncrypted, 0, lKey);
                outFs.Write(aes.IV, 0, lIV);

                using (CryptoStream outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                {
                    int count = 0;
                    int offset = 0;

                    int blockSizeBytes = aes.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];
                    int bytesRead = 0;

                    using (FileStream inFs = new FileStream(inFile, FileMode.Open))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamEncrypted.Write(data, 0, count);
                            bytesRead += blockSizeBytes;
                        }
                        while (count > 0);
                        inFs.Close();
                    }
                    outStreamEncrypted.FlushFinalBlock();
                    outStreamEncrypted.Close();
                }
                outFs.Close();
            }
        }




    }
}

