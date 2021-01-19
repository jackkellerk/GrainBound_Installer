
namespace GrainBound_Installer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /*
         ************** FOR CUSTOM FONTS
         * 
        private System.Drawing.Text.PrivateFontCollection pfc = new System.Drawing.Text.PrivateFontCollection();
        private void initCustomFont()
        {
            byte[] fontData = Properties.Resources.Avenir_LT_85_Heavy;
            System.IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            pfc.AddMemoryFont(fontPtr, fontData.Length);
        }
        */

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pboxLogo = new System.Windows.Forms.PictureBox();
            this.tboxLocation = new System.Windows.Forms.TextBox();
            this.cboxDesktopShortcut = new System.Windows.Forms.CheckBox();
            this.btnInstallLocation = new System.Windows.Forms.Button();
            this.label1 = new GrainBound_Installer.AALabel();
            this.label14 = new GrainBound_Installer.AALabel();
            this.label13 = new GrainBound_Installer.AALabel();
            this.lblAddr2 = new GrainBound_Installer.AALabel();
            this.lblAddr1 = new GrainBound_Installer.AALabel();
            this.label6 = new GrainBound_Installer.AALabel();
            this.lblEmail = new GrainBound_Installer.AALabel();
            this.label4 = new GrainBound_Installer.AALabel();
            this.label3 = new GrainBound_Installer.AALabel();
            this.label2 = new GrainBound_Installer.AALabel();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(466, 298);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(2);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(93, 37);
            this.btnInstall.TabIndex = 0;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(564, 298);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 37);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(14, 298);
            this.pgbProgress.Margin = new System.Windows.Forms.Padding(2);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(448, 36);
            this.pgbProgress.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(11, 282);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status:";
            // 
            // pboxLogo
            // 
            this.pboxLogo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pboxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pboxLogo.Image")));
            this.pboxLogo.Location = new System.Drawing.Point(338, 10);
            this.pboxLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pboxLogo.Name = "pboxLogo";
            this.pboxLogo.Size = new System.Drawing.Size(416, 254);
            this.pboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxLogo.TabIndex = 4;
            this.pboxLogo.TabStop = false;
            this.pboxLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pboxLogo_MouseDown);
            this.pboxLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pboxLogo_MouseMove);
            // 
            // tboxLocation
            // 
            this.tboxLocation.Location = new System.Drawing.Point(14, 259);
            this.tboxLocation.Name = "tboxLocation";
            this.tboxLocation.Size = new System.Drawing.Size(448, 20);
            this.tboxLocation.TabIndex = 18;
            // 
            // cboxDesktopShortcut
            // 
            this.cboxDesktopShortcut.AutoSize = true;
            this.cboxDesktopShortcut.Checked = true;
            this.cboxDesktopShortcut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxDesktopShortcut.Location = new System.Drawing.Point(514, 261);
            this.cboxDesktopShortcut.Name = "cboxDesktopShortcut";
            this.cboxDesktopShortcut.Size = new System.Drawing.Size(143, 17);
            this.cboxDesktopShortcut.TabIndex = 20;
            this.cboxDesktopShortcut.Text = "Create Desktop Shortcut";
            this.tooltip.SetToolTip(this.cboxDesktopShortcut, "Create a shortcut for the program on the Desktop.");
            this.cboxDesktopShortcut.UseVisualStyleBackColor = true;
            // 
            // btnInstallLocation
            // 
            this.btnInstallLocation.Location = new System.Drawing.Point(466, 257);
            this.btnInstallLocation.Name = "btnInstallLocation";
            this.btnInstallLocation.Size = new System.Drawing.Size(42, 23);
            this.btnInstallLocation.TabIndex = 21;
            this.btnInstallLocation.Text = "...";
            this.tooltip.SetToolTip(this.btnInstallLocation, "Select program install location.");
            this.btnInstallLocation.UseVisualStyleBackColor = true;
            this.btnInstallLocation.Click += new System.EventHandler(this.btnInstallLocation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 243);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Install Location:";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(14, 132);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(463, 17);
            this.label14.TabIndex = 17;
            this.label14.Text = "This software is under development and is the Intellectual Property (IP) of Grain" +
    "Bound LLC.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 110);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Disclaimer:";
            // 
            // lblAddr2
            // 
            this.lblAddr2.AutoSize = true;
            this.lblAddr2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAddr2.Location = new System.Drawing.Point(172, 206);
            this.lblAddr2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddr2.Name = "lblAddr2";
            this.lblAddr2.Size = new System.Drawing.Size(138, 13);
            this.lblAddr2.TabIndex = 11;
            this.lblAddr2.Text = "Bethlehem, PA, USA 18015";
            this.tooltip.SetToolTip(this.lblAddr2, "Open GrainBound address in Google Maps.");
            this.lblAddr2.Click += new System.EventHandler(this.lblAddr_Click);
            // 
            // lblAddr1
            // 
            this.lblAddr1.AutoSize = true;
            this.lblAddr1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAddr1.Location = new System.Drawing.Point(184, 183);
            this.lblAddr1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddr1.Name = "lblAddr1";
            this.lblAddr1.Size = new System.Drawing.Size(126, 13);
            this.lblAddr1.TabIndex = 10;
            this.lblAddr1.Text = "301 Broadway, Suite 500";
            this.tooltip.SetToolTip(this.lblAddr1, "Open GrainBound address in Google Maps.");
            this.lblAddr1.Click += new System.EventHandler(this.lblAddr_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 206);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "1-855-GRAINBD (472-4623)";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEmail.Location = new System.Drawing.Point(14, 183);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(111, 13);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "info@grainbound.com";
            this.tooltip.SetToolTip(this.lblEmail, "Send an email to GrainBound.");
            this.lblEmail.Click += new System.EventHandler(this.lblEmail_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 160);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Contact Us:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Version: 1.1A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Early Access Preview";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 345);
            this.Controls.Add(this.btnInstallLocation);
            this.Controls.Add(this.cboxDesktopShortcut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxLocation);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblAddr2);
            this.Controls.Add(this.lblAddr1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pboxLogo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInstall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "GrainBound Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pboxLogo;
        private System.Windows.Forms.TextBox tboxLocation;
        private System.Windows.Forms.CheckBox cboxDesktopShortcut;
        private System.Windows.Forms.Button btnInstallLocation;
        private AALabel label2;
        private AALabel label3;
        private AALabel label4;
        private AALabel lblEmail;
        private AALabel label6;
        private AALabel lblAddr1;
        private AALabel lblAddr2;
        private AALabel label13;
        private AALabel label14;
        private AALabel label1;
        private System.Windows.Forms.ToolTip tooltip;
    }
}

