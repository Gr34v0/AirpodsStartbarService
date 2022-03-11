namespace AirpodsStartbarService
{
    partial class ServiceMainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceMainWindow));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.leftEarBudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightEarBudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargingCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.leftPodLabel = new System.Windows.Forms.Label();
            this.chargingImageRight = new System.Windows.Forms.PictureBox();
            this.chargingImageLeft = new System.Windows.Forms.PictureBox();
            this.leftIndicator = new System.Windows.Forms.Label();
            this.chargingImageCase = new System.Windows.Forms.PictureBox();
            this.rightPodLabel = new System.Windows.Forms.Label();
            this.rightIndicator = new System.Windows.Forms.Label();
            this.caseLabel = new System.Windows.Forms.Label();
            this.aboutPanel = new System.Windows.Forms.Panel();
            this.githubVisitText = new System.Windows.Forms.Label();
            this.githubText = new System.Windows.Forms.PictureBox();
            this.githubLogo = new System.Windows.Forms.PictureBox();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.backToMainViewButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.updatingInfoToast = new System.Windows.Forms.Label();
            this.toolStripAbout = new System.Windows.Forms.ToolStripLabel();
            this.toolStripFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.updateAirpodsDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageCase)).BeginInit();
            this.aboutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.githubText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.githubLogo)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Airpods Tip Text";
            this.notifyIcon1.BalloonTipTitle = "Airpods Tip Title";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Airpods Service";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftEarBudToolStripMenuItem,
            this.rightEarBudToolStripMenuItem,
            this.chargingCaseToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 92);
            // 
            // leftEarBudToolStripMenuItem
            // 
            this.leftEarBudToolStripMenuItem.Name = "leftEarBudToolStripMenuItem";
            this.leftEarBudToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.leftEarBudToolStripMenuItem.Text = "Left Ear Bud:       -";
            this.leftEarBudToolStripMenuItem.Click += new System.EventHandler(this.genericStripMenuItem_Click);
            // 
            // rightEarBudToolStripMenuItem
            // 
            this.rightEarBudToolStripMenuItem.Name = "rightEarBudToolStripMenuItem";
            this.rightEarBudToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.rightEarBudToolStripMenuItem.Text = "Right Ear Bud:    - ";
            this.rightEarBudToolStripMenuItem.Click += new System.EventHandler(this.genericStripMenuItem_Click);
            // 
            // chargingCaseToolStripMenuItem
            // 
            this.chargingCaseToolStripMenuItem.Name = "chargingCaseToolStripMenuItem";
            this.chargingCaseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.chargingCaseToolStripMenuItem.Text = "Charging Case:  -";
            this.chargingCaseToolStripMenuItem.Click += new System.EventHandler(this.genericStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::AirpodsStartbarService.Properties.Resources.airpods_image_small;
            this.pictureBox1.Location = new System.Drawing.Point(0, -37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(798, 529);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // leftPodLabel
            // 
            this.leftPodLabel.BackColor = System.Drawing.Color.White;
            this.leftPodLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftPodLabel.Location = new System.Drawing.Point(275, 336);
            this.leftPodLabel.Name = "leftPodLabel";
            this.leftPodLabel.Size = new System.Drawing.Size(55, 28);
            this.leftPodLabel.TabIndex = 3;
            this.leftPodLabel.Text = "-";
            this.leftPodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chargingImageRight
            // 
            this.chargingImageRight.BackColor = System.Drawing.Color.White;
            this.chargingImageRight.Image = global::AirpodsStartbarService.Properties.Resources.chargingbolt_small;
            this.chargingImageRight.Location = new System.Drawing.Point(173, 336);
            this.chargingImageRight.Name = "chargingImageRight";
            this.chargingImageRight.Size = new System.Drawing.Size(35, 28);
            this.chargingImageRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.chargingImageRight.TabIndex = 8;
            this.chargingImageRight.TabStop = false;
            this.chargingImageRight.Visible = false;
            // 
            // chargingImageLeft
            // 
            this.chargingImageLeft.BackColor = System.Drawing.Color.White;
            this.chargingImageLeft.Image = global::AirpodsStartbarService.Properties.Resources.chargingbolt_small;
            this.chargingImageLeft.Location = new System.Drawing.Point(234, 336);
            this.chargingImageLeft.Name = "chargingImageLeft";
            this.chargingImageLeft.Size = new System.Drawing.Size(35, 28);
            this.chargingImageLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.chargingImageLeft.TabIndex = 9;
            this.chargingImageLeft.TabStop = false;
            this.chargingImageLeft.Visible = false;
            // 
            // leftIndicator
            // 
            this.leftIndicator.BackColor = System.Drawing.Color.White;
            this.leftIndicator.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftIndicator.Location = new System.Drawing.Point(259, 105);
            this.leftIndicator.Name = "leftIndicator";
            this.leftIndicator.Size = new System.Drawing.Size(55, 21);
            this.leftIndicator.TabIndex = 7;
            this.leftIndicator.Text = "Left";
            // 
            // chargingImageCase
            // 
            this.chargingImageCase.BackColor = System.Drawing.Color.White;
            this.chargingImageCase.Image = global::AirpodsStartbarService.Properties.Resources.chargingbolt_small;
            this.chargingImageCase.Location = new System.Drawing.Point(538, 373);
            this.chargingImageCase.Name = "chargingImageCase";
            this.chargingImageCase.Size = new System.Drawing.Size(35, 28);
            this.chargingImageCase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.chargingImageCase.TabIndex = 10;
            this.chargingImageCase.TabStop = false;
            this.chargingImageCase.Visible = false;
            // 
            // rightPodLabel
            // 
            this.rightPodLabel.BackColor = System.Drawing.Color.White;
            this.rightPodLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightPodLabel.Location = new System.Drawing.Point(112, 336);
            this.rightPodLabel.Name = "rightPodLabel";
            this.rightPodLabel.Size = new System.Drawing.Size(55, 28);
            this.rightPodLabel.TabIndex = 4;
            this.rightPodLabel.Text = "-";
            this.rightPodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightIndicator
            // 
            this.rightIndicator.BackColor = System.Drawing.Color.White;
            this.rightIndicator.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightIndicator.Location = new System.Drawing.Point(138, 105);
            this.rightIndicator.Name = "rightIndicator";
            this.rightIndicator.Size = new System.Drawing.Size(55, 21);
            this.rightIndicator.TabIndex = 6;
            this.rightIndicator.Text = "Right";
            // 
            // caseLabel
            // 
            this.caseLabel.BackColor = System.Drawing.Color.White;
            this.caseLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caseLabel.Location = new System.Drawing.Point(525, 404);
            this.caseLabel.Name = "caseLabel";
            this.caseLabel.Size = new System.Drawing.Size(64, 28);
            this.caseLabel.TabIndex = 5;
            this.caseLabel.Text = "-";
            this.caseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutPanel
            // 
            this.aboutPanel.Controls.Add(this.githubVisitText);
            this.aboutPanel.Controls.Add(this.githubText);
            this.aboutPanel.Controls.Add(this.githubLogo);
            this.aboutPanel.Controls.Add(this.aboutLabel);
            this.aboutPanel.Controls.Add(this.backToMainViewButton);
            this.aboutPanel.Location = new System.Drawing.Point(0, 25);
            this.aboutPanel.Name = "aboutPanel";
            this.aboutPanel.Size = new System.Drawing.Size(798, 467);
            this.aboutPanel.TabIndex = 15;
            this.aboutPanel.Visible = false;
            // 
            // githubVisitText
            // 
            this.githubVisitText.AutoSize = true;
            this.githubVisitText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.githubVisitText.Location = new System.Drawing.Point(503, 142);
            this.githubVisitText.Name = "githubVisitText";
            this.githubVisitText.Size = new System.Drawing.Size(184, 24);
            this.githubVisitText.TabIndex = 16;
            this.githubVisitText.Text = "Visit the project on";
            this.githubVisitText.Click += new System.EventHandler(this.githubVisitText_Click);
            // 
            // githubText
            // 
            this.githubText.Image = global::AirpodsStartbarService.Properties.Resources.GitHub_Logo;
            this.githubText.Location = new System.Drawing.Point(538, 182);
            this.githubText.Name = "githubText";
            this.githubText.Size = new System.Drawing.Size(217, 88);
            this.githubText.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.githubText.TabIndex = 15;
            this.githubText.TabStop = false;
            this.githubText.Click += new System.EventHandler(this.githubText_Click);
            // 
            // githubLogo
            // 
            this.githubLogo.Image = global::AirpodsStartbarService.Properties.Resources.GitHub_Mark_120px_plus;
            this.githubLogo.Location = new System.Drawing.Point(432, 182);
            this.githubLogo.Name = "githubLogo";
            this.githubLogo.Size = new System.Drawing.Size(100, 88);
            this.githubLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.githubLogo.TabIndex = 14;
            this.githubLogo.TabStop = false;
            this.githubLogo.Click += new System.EventHandler(this.githubLogo_Click);
            // 
            // aboutLabel
            // 
            this.aboutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.Location = new System.Drawing.Point(49, 101);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(310, 306);
            this.aboutLabel.TabIndex = 13;
            this.aboutLabel.Text = "ABOUT TEST VALUE";
            // 
            // backToMainViewButton
            // 
            this.backToMainViewButton.BackColor = System.Drawing.Color.White;
            this.backToMainViewButton.Location = new System.Drawing.Point(3, 3);
            this.backToMainViewButton.Name = "backToMainViewButton";
            this.backToMainViewButton.Size = new System.Drawing.Size(64, 51);
            this.backToMainViewButton.TabIndex = 12;
            this.backToMainViewButton.Text = "Back";
            this.backToMainViewButton.UseVisualStyleBackColor = false;
            this.backToMainViewButton.Click += new System.EventHandler(this.backToMainViewButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.caseLabel);
            this.mainPanel.Controls.Add(this.rightIndicator);
            this.mainPanel.Controls.Add(this.rightPodLabel);
            this.mainPanel.Controls.Add(this.chargingImageCase);
            this.mainPanel.Controls.Add(this.leftIndicator);
            this.mainPanel.Controls.Add(this.chargingImageLeft);
            this.mainPanel.Controls.Add(this.chargingImageRight);
            this.mainPanel.Controls.Add(this.leftPodLabel);
            this.mainPanel.Controls.Add(this.pictureBox1);
            this.mainPanel.Controls.Add(this.aboutPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(798, 492);
            this.mainPanel.TabIndex = 14;
            // 
            // updatingInfoToast
            // 
            this.updatingInfoToast.BackColor = System.Drawing.Color.White;
            this.updatingInfoToast.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatingInfoToast.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.updatingInfoToast.Location = new System.Drawing.Point(176, 40);
            this.updatingInfoToast.Name = "updatingInfoToast";
            this.updatingInfoToast.Size = new System.Drawing.Size(511, 33);
            this.updatingInfoToast.TabIndex = 17;
            this.updatingInfoToast.Text = "Establishing Connection To Airpods";
            this.updatingInfoToast.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStripAbout
            // 
            this.toolStripAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripAbout.Name = "toolStripAbout";
            this.toolStripAbout.Size = new System.Drawing.Size(40, 22);
            this.toolStripAbout.Text = "About";
            this.toolStripAbout.Click += new System.EventHandler(this.toolStripAbout_Click);
            // 
            // toolStripFile
            // 
            this.toolStripFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateAirpodsDataToolStripMenuItem,
            this.testToolStripMenuItem});
            this.toolStripFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripFile.Image")));
            this.toolStripFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.Size = new System.Drawing.Size(38, 22);
            this.toolStripFile.Text = "File";
            this.toolStripFile.ToolTipText = "toolStripFile";
            // 
            // updateAirpodsDataToolStripMenuItem
            // 
            this.updateAirpodsDataToolStripMenuItem.Name = "updateAirpodsDataToolStripMenuItem";
            this.updateAirpodsDataToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.updateAirpodsDataToolStripMenuItem.Text = "Update Airpods Data";
            this.updateAirpodsDataToolStripMenuItem.Click += new System.EventHandler(this.updateAirpodsDataToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.testToolStripMenuItem.Text = "Restart Airpods Monitoring Service";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAbout,
            this.toolStripFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(798, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ServiceMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 492);
            this.Controls.Add(this.updatingInfoToast);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mainPanel);
            this.MaximumSize = new System.Drawing.Size(814, 531);
            this.MinimumSize = new System.Drawing.Size(814, 531);
            this.Name = "ServiceMainWindow";
            this.Text = "Airpods Service";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageCase)).EndInit();
            this.aboutPanel.ResumeLayout(false);
            this.aboutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.githubText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.githubLogo)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftEarBudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightEarBudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargingCaseToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label leftPodLabel;
        private System.Windows.Forms.PictureBox chargingImageRight;
        private System.Windows.Forms.PictureBox chargingImageLeft;
        private System.Windows.Forms.Label leftIndicator;
        private System.Windows.Forms.PictureBox chargingImageCase;
        private System.Windows.Forms.Label rightPodLabel;
        private System.Windows.Forms.Label rightIndicator;
        private System.Windows.Forms.Label caseLabel;
        private System.Windows.Forms.Panel aboutPanel;
        private System.Windows.Forms.Label githubVisitText;
        private System.Windows.Forms.PictureBox githubText;
        private System.Windows.Forms.PictureBox githubLogo;
        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.Button backToMainViewButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripLabel toolStripAbout;
        private System.Windows.Forms.ToolStripDropDownButton toolStripFile;
        private System.Windows.Forms.ToolStripMenuItem updateAirpodsDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label updatingInfoToast;
    }
}