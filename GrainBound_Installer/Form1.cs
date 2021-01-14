using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO.Compression;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using IWshRuntimeLibrary;

namespace GrainBound_Installer
{
    public partial class Form1 : Form
    {
        private bool firstRun = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(firstRun)
            {
                button1.Enabled = true;
                button2.Enabled = true;

                button1.Text = "Continue";
                MessageBox.Show("Click continue once you have installed .Net Core 5");
                firstRun = false;

                if(Environment.Is64BitOperatingSystem)
                {
                    Process.Start("C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\dotnet-runtime-3.1.10-win-x64.exe");
                }
                else
                {
                    Process.Start("C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\dotnet-runtime-3.1.10-win-x86.exe");
                }
            }
            else
            {
                System.Threading.Thread.Sleep(3000);
                unZipApplication();
            }           
        }

        private void unZipApplication()
        {      
            label1.Text = "Status: Unzipping files...";
            string zipPath = @"C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\GrainBound.zip";
            string extractPath = @"C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\GrainBound";

            if(Directory.Exists(@"C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\GrainBound"))
            {
                Directory.Delete(@"C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\GrainBound", true);
            }

            System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);

            CreateShortcut();
        }

        private void CreateShortcut()
        {
            System.Threading.Thread.Sleep(3000);
            label1.Text = "Status: Creating application shortcut...";
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\GrainBound.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "GrainBound Application";            
            shortcut.TargetPath = "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\GrainBound\\GrainBound\\GrainBound.exe";
            shortcut.WorkingDirectory = "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\GrainBound\\GrainBound";
            shortcut.Save();

            button2.Enabled = true;
            label1.Text = "Status: Installation complete!";
            button2.Text = "Exit";
            MessageBox.Show("Installation Complete!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(firstRun)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                System.IO.File.Delete(@"C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\windowsdesktop-runtime-5.0.0-win-x86.exe");
                System.IO.File.Delete(@"C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\windowsdesktop-runtime-5.0.0-win-x64.exe");
                label1.Text = "Status: Downloading files...";                              

                if(Environment.Is64BitOperatingSystem)
                {
                    WebClient webClient = new WebClient();
                    string sourceFile = @"https://download.visualstudio.microsoft.com/download/pr/9845b4b0-fb52-48b6-83cf-4c431558c29b/41025de7a76639eeff102410e7015214/dotnet-runtime-3.1.10-win-x64.exe";
                    string destFile = @"C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\dotnet-runtime-3.1.10-win-x64.exe";
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.DownloadFileAsync(new Uri(sourceFile), destFile);
                }
                else
                {
                    WebClient webClient = new WebClient();
                    string sourceFile = @"https://download.visualstudio.microsoft.com/download/pr/abb3fb5d-4e82-4ca8-bc03-ac13e988e608/b34036773a72b30c5dc5520ee6a2768f/dotnet-runtime-3.1.10-win-x86.exe";
                    string destFile = @"C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\dotnet-runtime-3.1.10-win-x86.exe";
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.DownloadFileAsync(new Uri(sourceFile), destFile);
                }
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                System.IO.File.Delete(@"C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\GrainBound.zip");
                label1.Text = "Status: Downloading files...";
                WebClient webClient = new WebClient();
                string sourceFile = @"http://www.tutoran.net/GrainBound.zip";
                string destFile = @"C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\GrainBound.zip";
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri(sourceFile), destFile);
            }          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
