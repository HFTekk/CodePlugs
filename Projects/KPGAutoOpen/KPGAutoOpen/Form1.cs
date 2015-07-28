using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections;

namespace KPGAutoOpen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            findInstalledPrograms();
            
        }

        Hashtable fpu = new Hashtable();
        
        private void findInstalledPrograms()
        {
            string appPattern = "*KPG*D";
            string defaultPath = "c:\\Program Files (x86)\\Kenwood Fpu\\";
            string[] dirs = Directory.GetDirectories(defaultPath, appPattern);
            foreach (string dir in dirs)
            {
                txtOutput.Text += dir + "\r\n";
                string pattern = "KPG[0-9]+[A-Z][A-Z]?";
                Match appMatch = Regex.Match(dir, pattern);
                string applicationTitle = appMatch.ToString();

                string exePattern = "*kpg*d.exe";
                string[] exec = Directory.GetFiles(dir, exePattern);
                fpu.Add(applicationTitle, exec[0]);


            }
        }

        private void txtOutput_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
            {
                if (s[i].EndsWith(".dat"))
                {
                    StreamReader reader = new StreamReader(s[i]);
                    char[] buff = new char[32];
                    reader.ReadBlock(buff, 0, 32);
                    string buffer = new string(buff);

                    string appPattern = "KPG[0-9]+[A-Z][A-Z]?";
                    Match appMatch = Regex.Match(buffer, appPattern);
                    string applicationTitle = appMatch.ToString();

                    string verPattern = @"V[0-9]+\.[0-9][0-9]";
                    Match verMatch = Regex.Match(buffer, verPattern);
                    string applicationVersion = verMatch.ToString();

                    string modelPattern = "(TK|NX).?[0-9]+[0-9A-Z]{2}";
                    Match modelMatch = Regex.Match(buffer, modelPattern);
                    string radioModel = modelMatch.ToString();

                    txtOutput.Text += applicationTitle + " " + applicationVersion + "\r\n" + radioModel +"\r\n" + s[i] + "\r\n\r\n";

                    reader.Close();

                    string path = fpu[applicationTitle].ToString();

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.CreateNoWindow = false;
                    startInfo.UseShellExecute = false;
                    startInfo.FileName = path;
                    startInfo.WindowStyle = ProcessWindowStyle.Normal;
                    startInfo.Arguments = "\"file=" + s[i] + "\"";


                    try
                    {
                        Process.Start(startInfo);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\r\n" + s[i]);

                    }

                }
            }
                
        }

        private void txtOutput_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
