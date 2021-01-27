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
//using IWshRuntimeLibrary;

namespace GrainBound_Installer
{
    public partial class UninstallForm : Form
    {
        public UninstallForm()
        {
            InitializeComponent();
        }

        private void UninstallForm_Load(object sender, EventArgs e)
        {
            checkRegistryKey();
            tboxLocation.Text = installLoc;
        }


        Microsoft.Win32.RegistryKey regKey;
        private string installLoc;
        private void checkRegistryKey()
        {
            try
            {
                regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("GrainBound");
                installLoc = (string)regKey.GetValue("InstallInfo");
                regKey.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to access registry key: " + ex.Message, "Error");
                this.Close();
            }
        }
        private void removeRegistryKey()
        {
            Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("GrainBound");
            regKey.Close();
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This operation will permanently remove GrainBound from your computer. Are you sure you wish to proceed?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnUninstall.Text = "Uninstalling...";
                btnUninstall.Enabled = false;
                Directory.Delete(tboxLocation.Text, true);
                if (File.Exists("C:\\Users\\" + Environment.UserName + "\\Desktop\\GrainBound.lnk"))
                    File.Delete("C:\\Users\\" + Environment.UserName + "\\Desktop\\GrainBound.lnk");
                removeRegistryKey();
                MessageBox.Show("GrainBound uninstalled successfully.", "Success");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UninstallForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
