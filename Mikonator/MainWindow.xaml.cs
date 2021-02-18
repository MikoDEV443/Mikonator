using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mikonator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            if (File.Exists("./icons/pub.cert"))
            {
                Myglobals.filenamepk = "./icons/pub.cert";
                Myglobals.filenamesk = "./icons/priv.cert";

            }
            else
            {
                MessageBox.Show("When you start the Program for the first time you have to run it as admin");
                System.Environment.Exit(0);

            }



            RsaFileDemo.LaunchEncryption();

        }

        
        

        private void btndecrypt_Click(object sender, RoutedEventArgs e)
        {
            Myglobals.message2decrypt = txtencrypted.Text;
            try
            {
                RsaFileDemo2.LaunchDecryption();
                txtdecrypted.Text = Myglobals.decrypt;
            }
            catch
            {
                MessageBox.Show("CANT DECRYPT STRING !!!");
            }
           




        }

        private void btnencrypt_Click(object sender, RoutedEventArgs e)
        {
            Myglobals.message2encrypt = txtdecrypted.Text;
            RsaFileDemo.LaunchEncryption();
            txtencrypted.Text = Myglobals.encrypt;

        }

        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            txtencrypted.Text = "";
            txtdecrypted.Text = "";

        }

        private void btncopytoClipboard_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(Myglobals.encrypt);

        }

        private void btncopytoclipboard2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(Myglobals.decrypt);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnsk_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".cert";
            ofd.Title = "Select PrivateKey";
            ///ofd.Filter = "Pem File (.PEM)|*.PEM";
            if (ofd.ShowDialog() == true)
            {
                Myglobals.filenamesk = ofd.FileName;

            }
        }

        private void btnpk_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".cert";
            ofd.Title = "Select Publickey";
            ///ofd.Filter = "Pem File (.PEM)|*.PEM";
            if (ofd.ShowDialog() == true)
            {
                Myglobals.filenamepk = ofd.FileName;

            }
        }
    }
    
    public static class Myglobals
    {
        public static string filenamesk;
        public static string filenamepk;
        public static string decrypt;
        public static string encrypt;
        public static string encryp2;
        public static byte[] encryptbytes;
        public static byte[] encryptbytes2;
        public static string message2encrypt = "no";
        public static string message2decrypt;
        public static string Username;
        public static string time;
        public static string amail;
        public static int zufall2;
        public static string PublicKey;
        public static string a;
        public static string UserID;
        public static int checkbox;
        public static string receive;
        public static string content;
        public static string decrypt2;
        public static string restartcmd;
    }
}
   

