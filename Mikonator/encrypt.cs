using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Mikonator;

namespace Mikonator
{
    public enum KeySizes
    {
        SIZE_512 = 512,
        SIZE_1024 = 1024,
        SIZE_2048 = 2048,
        SIZE_8192 = 8192,
        SIZE_4096 = 4096,
        SIZE_952 = 952,
        SIZE_1369 = 1369
        
    };

    class RsaFileDemo
    {
        public static void LaunchEncryption()
        {
           
            string publicKey = Myglobals.filenamepk;
            string privateKey = Myglobals.filenamesk;
            GenerateKeys(publicKey, privateKey);
            string message = Myglobals.message2encrypt;
            byte[] encrypted = Encrypt(publicKey, Encoding.UTF8.GetBytes(message));


            ///  Console.WriteLine("Original\n\t " + message + "\n");
            /// Console.WriteLine("Encrypted\n\t" + BitConverter.ToString(encrypted).Replace("-", "") + "\n");


            /// Console.ReadLine();
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


        private static byte[] Encrypt(string publicKeyFile, byte[] plain)
        {
            byte[] encrypted;
            using (var rsa = new RSACryptoServiceProvider((int)KeySizes.SIZE_4096))
            {
                rsa.PersistKeyInCsp = false;
                string publicKey = File.ReadAllText(publicKeyFile);
                rsa.FromXmlString(publicKey);
                encrypted = rsa.Encrypt(plain, true);
            }

            Myglobals.encrypt = Convert.ToBase64String(encrypted);

            ///Myglobals.encrypt = System.Text.Encoding.Default.GetString(encrypted);



            return encrypted;

        }
    }
}









