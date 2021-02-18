using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace Mikonator
{


    class RsaFileDemo2
    {
        public static void LaunchDecryption()
        {


            byte[] encrypted = Convert.FromBase64String(Myglobals.message2decrypt);
            string publicKey = Myglobals.filenamepk;
            string privateKey = Myglobals.filenamesk;
            GenerateKeys(publicKey, privateKey);
            /// byte[] encrypted = Encrypt(publicKey, Encoding.UTF8.GetBytes(message));
            byte[] decrypted = Decrypt(privateKey, encrypted);

            /// Console.WriteLine("Original\n\t " + message + "\n");
            ///Console.WriteLine("Encrypted\n\t" + BitConverter.ToString(encrypted).Replace("-", "") + "\n");
            ///Console.WriteLine("Decrypted\n\t" + Encoding.UTF8.GetString(decrypted));

            ///Console.ReadLine();
        }

        private static void GenerateKeys(string publicKeyFile, string privateKeyFile)
        {
            using (var rsa = new RSACryptoServiceProvider((int)KeySizes.SIZE_4096))
            {
                rsa.PersistKeyInCsp = false;
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                if (File.Exists(privateKeyFile))
                    File.Exists(privateKeyFile);
                else File.WriteAllText(privateKeyFile, privateKey);

                if (File.Exists(publicKeyFile))
                    File.Exists(publicKeyFile);
                else File.WriteAllText(publicKeyFile, publicKey);





            }
        }





        private static byte[] Decrypt(string privateKeyFile, byte[] encrypted)
        {
            byte[] decrypted;
            using (var rsa = new RSACryptoServiceProvider((int)KeySizes.SIZE_4096))
            {
                rsa.PersistKeyInCsp = false;
                string privateKey = File.ReadAllText(privateKeyFile);
                rsa.FromXmlString(privateKey);
                decrypted = rsa.Decrypt(encrypted, true);

            }

            Myglobals.decrypt = Encoding.UTF8.GetString(decrypted);
         

           
            return decrypted;





        }
    }
}