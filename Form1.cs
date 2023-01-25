using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            klk();
        }

        private static Random WTF = new Random();
        public static string RandomString(int length)
        {
            const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            return new string(Enumerable.Repeat(Chars, length).Select(s => s[WTF.Next(s.Length)]).ToArray());
        }

        private void klk()
        {
            const string REGISTRY_KEY = @"HKEY_CURRENT_USER\Prototype";
            const string REGISTY_FIRSTRUN = "123";
            const string REGISTY_LASTNAME = "321";
            string RandomTitle = RandomString(WTF.Next(5, 25)) + ".exe";

            try
            {
                if (Convert.ToInt32(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTY_FIRSTRUN, 0)) == 0)
                {

                    this.Text = RandomTitle;
                    this.Name = RandomTitle;
                    this.AccessibleName = RandomTitle;


                    string TempPath = Convert.ToString(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTY_LASTNAME, 0));
                    string tt = Convert.ToString(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTY_FIRSTRUN, 0));

                    // >> Check if our Main File exists & delte it if it does (Change this to the default name of your programm)
                    if (AppDomain.CurrentDomain.FriendlyName != "Epic.exe") { File.Delete("Epic.exe"); }

                    // >> Check if the File exists & delete it if it does
                    if (File.Exists(TempPath))
                    {
                        Thread.Sleep(1000);
                        File.Delete(TempPath);
                    }
                    File.Delete(TempPath);

                    // >> Set "FirstRun" Value in Registry to "1"
                    Microsoft.Win32.Registry.SetValue(REGISTRY_KEY, REGISTY_FIRSTRUN, 1, Microsoft.Win32.RegistryValueKind.DWord);
                    // >> Set the "LastName" Value in the Registry so we can delete it later
                    Microsoft.Win32.Registry.SetValue(REGISTRY_KEY, REGISTY_LASTNAME, Directory.GetCurrentDirectory() + @"\" + AppDomain.CurrentDomain.FriendlyName, Microsoft.Win32.RegistryValueKind.String);
                }
                else
                {

                    // >> Copy's current File in the same Directory with a Random Name
                    File.Copy(AppDomain.CurrentDomain.FriendlyName, RandomTitle);
                    // >> Set's the "FirstRun" Registry Value to "0"
                    Microsoft.Win32.Registry.SetValue(REGISTRY_KEY, REGISTY_FIRSTRUN, 0, Microsoft.Win32.RegistryValueKind.DWord);
                    // >> Start's the newly created File

                    Process.Start(RandomTitle);
                    this.Close();
                }

            }
            catch
            {
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            const string REGISTRY_KEY = @"HKEY_CURRENT_USER\Prototype";
            const string REGISTY_FIRSTRUN = "tt";
            string RandomTitle = RandomString(WTF.Next(5, 15)) + ".exe";
            try
            {
                if (Convert.ToInt32(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTY_FIRSTRUN, 0)) == 1)
                {

                    this.Text = RandomTitle;
                    this.Name = RandomTitle;
                    this.AccessibleName = RandomTitle;
                }
            }
            catch
            { }
        }
    }
}
