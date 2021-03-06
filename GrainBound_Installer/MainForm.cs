﻿using System;
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
//using IWshRuntimeLibrary;

namespace GrainBound_Installer
{
    public partial class MainForm : Form
    {
        private const bool CHECK_FOR_DOT_NET = false; // Change this depending on whether or not to check for .net (I don't think it's important)

        private bool dlDotNet = false, downloading = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private WebClient webClient;
        private void MainForm_Load(object sender, EventArgs e)
        {
            tboxLocation.Text = "C:\\Users\\" + Environment.UserName + "\\Desktop\\GrainBound";

            WebRequest.DefaultWebProxy = null;
            webClient = new WebClient();
            webClient.Proxy = null;
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);

            string installLoc = GBRegistry.checkRegistryKey(GBRegistry.GRAINBOUND_INSTALL_KEY);
            if(installLoc != null)
            {
                if(Directory.Exists(installLoc))
                {
                    this.Hide();
                    (new UninstallForm()).ShowDialog();
                }
                else
                {
                    GBRegistry.removeRegistryKey();
                }
            }
        }

        #region WebClient Functions

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (dlDotNet)
                lblStatus.Text = "Status: Downloading .Net Files (" + e.ProgressPercentage + "%, " + (e.BytesReceived / 1000) + " kB / " + (e.TotalBytesToReceive / 1000) + " kB)...";
            else
                lblStatus.Text = "Status: Downloading GrainBound Files (" + e.ProgressPercentage + "%, " + (e.BytesReceived / 1000) + " kB / " + (e.TotalBytesToReceive / 1000) + " kB)...";

            pgbProgress.Value = e.ProgressPercentage;
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            downloading = false;
            btnCancel.Text = "Close";

            if (e.Cancelled)
            {
                try
                {
                    Directory.Delete(tboxLocation.Text, true);
                }
                catch { }

                lblStatus.Text = "Status: Cancelled.";
                btnInstall.Enabled = true;
                btnInstallLocation.Enabled = true;
                tboxLocation.Enabled = true;
                pgbProgress.Value = 0;

                return;
            }
            if (e.Error != null)
            {
                try
                {
                    Directory.Delete(tboxLocation.Text, true);
                }
                catch { }

                MessageBox.Show("An error occurred during download: " + e.Error.Message, "Error");
                lblStatus.Text = "Status: An error occurred.";
                btnInstall.Enabled = true;
                btnInstallLocation.Enabled = true;
                tboxLocation.Enabled = true;
                pgbProgress.Value = 0;
                return;
            }

            if (dlDotNet)
            {
                Process.Start(tboxLocation.Text + "\\dotnet.exe");

                lblStatus.Text = "Status: Done downloading .Net files.";
                btnInstall.Enabled = true;
                btnInstallLocation.Enabled = true;
                tboxLocation.Enabled = true;
                pgbProgress.Value = 0;

                installFiles();

                return;
            }
            else unzipApplication();
        }

        #endregion

        #region Install Functions

        private const string DOTNET_PATH_64 = "https://download.visualstudio.microsoft.com/download/pr/9845b4b0-fb52-48b6-83cf-4c431558c29b/41025de7a76639eeff102410e7015214/dotnet-runtime-3.1.10-win-x64.exe";
        private const string DOTNET_PATH_32 = "https://download.visualstudio.microsoft.com/download/pr/abb3fb5d-4e82-4ca8-bc03-ac13e988e608/b34036773a72b30c5dc5520ee6a2768f/dotnet-runtime-3.1.10-win-x86.exe";
        private void checkDotNet()
        {
            if (Environment.Version.Major >= 5 || !CHECK_FOR_DOT_NET)
            {
                installFiles();
                return;
            }

            if (MessageBox.Show("This application requires .Net Core 5 or above (This computer has version " + Environment.Version.ToString() + "). Install version 5.0.0 now?", "Newer .Net Core Required", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnInstall.Enabled = false;
                btnInstallLocation.Enabled = false;
                tboxLocation.Enabled = false;

                lblStatus.Text = "Status: Downloading .Net Files...";
                dlDotNet = true;

                try
                {
                    if (Environment.Is64BitOperatingSystem)
                    {
                        webClient.DownloadFileAsync(new Uri(DOTNET_PATH_64), tboxLocation.Text + "\\dotnet.exe");
                    }
                    else
                    {
                        webClient.DownloadFileAsync(new Uri(DOTNET_PATH_32), tboxLocation.Text + "\\dotnet.exe");
                    }
                    downloading = true;
                    btnCancel.Text = "Cancel";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while downloading .Net Core: " + ex.Message, "Error");

                    btnInstall.Enabled = true;
                    btnInstallLocation.Enabled = true;
                    tboxLocation.Enabled = true;

                    lblStatus.Text = "Status: Failed to download .Net files.";
                }
            }
            else
            {
                installFiles();
            }
        }

        //https://www.jackkellerk.com/GrainBound.zip
        private const string GRAINBOUND_PATH = "http://71.230.68.146:8080/GB_INSTALL.zip";
        private void installFiles()
        {
            btnInstall.Enabled = false;
            btnInstallLocation.Enabled = false;
            tboxLocation.Enabled = false;

            lblStatus.Text = "Status: Starting download of GrainBound Files...";
            dlDotNet = false;

            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    (se, cert, chain, sslerror) =>
                    {
                        return true;
                    };

                webClient.DownloadFileAsync(new Uri(GRAINBOUND_PATH), tboxLocation.Text + "\\gb.zip");
                downloading = true;
                btnCancel.Text = "Cancel";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while downloading GrainBound files: " + ex.Message, "Error");

                btnInstall.Enabled = true;
                btnInstallLocation.Enabled = true;
                tboxLocation.Enabled = true;

                lblStatus.Text = "Status: Failed to download GrainBound files.";
            }
        }

        private void unzipApplication()
        {
            lblStatus.Text = "Status: Unzipping files...";
            lblStatus.Refresh();

            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(tboxLocation.Text + "\\gb.zip", tboxLocation.Text);

                File.Delete(tboxLocation.Text + "\\gb.zip");

                File.Copy(
                    tboxLocation.Text + "\\python\\Lib\\pywin32_system32\\pythoncom37.dll",
                    "C:\\Windows\\System32\\pythoncom37.dll");
                File.Copy(
                    tboxLocation.Text + "\\python\\Lib\\pywin32_system32\\pywintypes37.dll",
                    "C:\\Windows\\System32\\pywintypes37.dll");
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while unzipping install files. Message: " + ex.Message, "Error");
                Process.Start(tboxLocation.Text);
            }

            if (cboxDesktopShortcut.Checked)
                createShortcut();

            GBRegistry.createRegistryKey(GBRegistry.GRAINBOUND_INSTALL_KEY, tboxLocation.Text);

            btnInstall.Enabled = true;
            btnInstallLocation.Enabled = true;
            tboxLocation.Enabled = true;
            lblStatus.Text = "Status: Complete.";
            pgbProgress.Value = 0;

            MessageBox.Show("GrainBound installation complete.", "Installation Complete");
            Application.Exit();
        }

        private void createShortcut()
        {
            lblStatus.Text = "Status: Creating application shortcut...";

            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();

            object shDesktop = (object)"Desktop";
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut((string)shell.SpecialFolders.Item(ref shDesktop) + @"\GrainBound.lnk");

            shortcut.IconLocation = tboxLocation.Text + "\\logo.ico";
            shortcut.Description = "GrainBound Application";
            shortcut.TargetPath = tboxLocation.Text + "\\RunGrainBound.bat";
            shortcut.WorkingDirectory = tboxLocation.Text;

            try
            {
                shortcut.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while creating a desktop shortcut. Message: " + ex.Message, "Error");
            }
        }

        #endregion

        #region Update Functions

        private const string VERSION_PATH = "test.test/version.txt";
        private string retrievedRecentVersion = null;
        private string getMostRecentVersion()
        {
            try
            {
                if(retrievedRecentVersion == null)
                {
                    retrievedRecentVersion = webClient.DownloadString(VERSION_PATH);
                }
                return retrievedRecentVersion;
            }
            catch { return null; }
        }
        private string getCurrentVersion()
        {
            return GBRegistry.checkRegistryKey(GBRegistry.GRAINBOUND_VERSION_KEY);
        }
        private bool checkClientUpdated()
        {
            return getCurrentVersion() == getMostRecentVersion();
        }

        // set version key upon install
        // check version key upon program start
        // if version is set and not updated, change form elements to say "update" rather than "install" but do same shit

        #endregion

        #region Form Functions

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tboxLocation.Text))
            {
                try
                {
                    Directory.Delete(tboxLocation.Text, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting existing GrainBound files. Message: " + ex.Message, "Error");
                }
            }

            try
            {
                Directory.CreateDirectory(tboxLocation.Text);
                checkDotNet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error creating the install folder: " + ex.Message + (ex.Message.Contains("Access to the path") ? " (Try running the installer as administrator)" : ""), "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!downloading)
            {
                Application.Exit();
                return;
            }

            webClient.CancelAsync();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (downloading)
            {
                MessageBox.Show("There is currently a download in progress. Please cancel the download before closing.", "Error");
                e.Cancel = true;
            }
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:info@grainbound.com");
        }

        // These use hardcoded values for hovering over logo.
        private void pboxLogo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > 80 && e.X < 350 && e.Y < 135) Process.Start("https://www.grainbound.com/");
        }
        private void pboxLogo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > 80 && e.X < 350 && e.Y < 135)
            {
                pboxLogo.Cursor = Cursors.Hand;
                //tooltip.SetToolTip(pboxLogo, "Open the GrainBound website.");
            }
            else
            {
                pboxLogo.Cursor = Cursors.Default;
                //tooltip.SetToolTip(pboxLogo, null);
            }
        }

        private void lblAddr_Click(object sender, EventArgs e)
        {
            Process.Start("https://maps.google.com/?q=301 Broadway, Bethlehem PA 18015");
        }

        private void btnInstallLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK) tboxLocation.Text = fbd.SelectedPath + @"\GrainBound";
        }

        #endregion
    }
}
