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
            tboxLocation.Text = GBRegistry.checkRegistryKey(GBRegistry.GRAINBOUND_INSTALL_KEY);
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            bool backedUpProjects = false;
            string newPath = "";

            if (MessageBox.Show("This operation will permanently remove GrainBound from your computer. Are you sure you wish to proceed?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string[] files = Directory.GetFiles(tboxLocation.Text, "*.grainbound", SearchOption.AllDirectories);
                if(files.Length > 0)
                {
                    DialogResult result = MessageBox.Show("GrainBound files have been detected inside the install folder. Do you want to save these files before uninstalling?\n\nYes = GrainBound projects will be moved to a different folder, then the program will be uninstalled.\nNo = Delete all files, including GrainBound projects.\nCancel = Stop uninstallation process.", "GrainBound Saved Projects Detected", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        newPath = tboxLocation.Text.Substring(0, tboxLocation.Text.LastIndexOf("\\")) + "\\GrainBound Projects";
                        try
                        {
                            Directory.CreateDirectory(newPath);
                            for (int i = 0; i < files.Length; i++) File.Move(files[i], newPath + files[i].Substring(files[i].LastIndexOf("\\")));
                            backedUpProjects = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while moving GrainBound projects: " + ex.Message + "\n\nThe uninstall process has been cancelled.", "Error");
                        }
                    }
                    else if(result == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                btnUninstall.Text = "Uninstalling...";
                btnUninstall.Enabled = false;
                Directory.Delete(tboxLocation.Text, true);
                if (File.Exists("C:\\Users\\" + Environment.UserName + "\\Desktop\\GrainBound.lnk"))
                    File.Delete("C:\\Users\\" + Environment.UserName + "\\Desktop\\GrainBound.lnk");
                GBRegistry.removeRegistryKey();
                MessageBox.Show("GrainBound uninstalled successfully." + (backedUpProjects ? (" Existing projects have been moved to " + newPath) : ""), "Success");
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
