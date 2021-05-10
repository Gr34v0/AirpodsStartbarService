﻿namespace AirpodsStartbarService
{
    partial class serviceMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(serviceMainWindow));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.leftEarBudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightEarBudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargingCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftPodLabel = new System.Windows.Forms.Label();
            this.rightPodLabel = new System.Windows.Forms.Label();
            this.caseLabel = new System.Windows.Forms.Label();
            this.rightIndicator = new System.Windows.Forms.Label();
            this.leftIndicator = new System.Windows.Forms.Label();
            this.chargingImageCase = new System.Windows.Forms.PictureBox();
            this.chargingImageLeft = new System.Windows.Forms.PictureBox();
            this.chargingImageRight = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageCase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // leftPodLabel
            // 
            this.leftPodLabel.BackColor = System.Drawing.Color.White;
            this.leftPodLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftPodLabel.Location = new System.Drawing.Point(257, 338);
            this.leftPodLabel.Name = "leftPodLabel";
            this.leftPodLabel.Size = new System.Drawing.Size(55, 28);
            this.leftPodLabel.TabIndex = 3;
            this.leftPodLabel.Text = "-";
            this.leftPodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightPodLabel
            // 
            this.rightPodLabel.BackColor = System.Drawing.Color.White;
            this.rightPodLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightPodLabel.Location = new System.Drawing.Point(127, 338);
            this.rightPodLabel.Name = "rightPodLabel";
            this.rightPodLabel.Size = new System.Drawing.Size(55, 28);
            this.rightPodLabel.TabIndex = 4;
            this.rightPodLabel.Text = "-";
            this.rightPodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // caseLabel
            // 
            this.caseLabel.BackColor = System.Drawing.Color.White;
            this.caseLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caseLabel.Location = new System.Drawing.Point(523, 406);
            this.caseLabel.Name = "caseLabel";
            this.caseLabel.Size = new System.Drawing.Size(64, 28);
            this.caseLabel.TabIndex = 5;
            this.caseLabel.Text = "-";
            this.caseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightIndicator
            // 
            this.rightIndicator.BackColor = System.Drawing.Color.White;
            this.rightIndicator.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightIndicator.Location = new System.Drawing.Point(127, 107);
            this.rightIndicator.Name = "rightIndicator";
            this.rightIndicator.Size = new System.Drawing.Size(55, 35);
            this.rightIndicator.TabIndex = 6;
            this.rightIndicator.Text = "Right";
            // 
            // leftIndicator
            // 
            this.leftIndicator.BackColor = System.Drawing.Color.White;
            this.leftIndicator.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftIndicator.Location = new System.Drawing.Point(257, 107);
            this.leftIndicator.Name = "leftIndicator";
            this.leftIndicator.Size = new System.Drawing.Size(55, 35);
            this.leftIndicator.TabIndex = 7;
            this.leftIndicator.Text = "Left";
            // 
            // chargingImageCase
            // 
            this.chargingImageCase.BackColor = System.Drawing.Color.White;
            this.chargingImageCase.Image = global::AirpodsStartbarService.Properties.Resources.chargingbolt_small;
            this.chargingImageCase.Location = new System.Drawing.Point(491, 406);
            this.chargingImageCase.Name = "chargingImageCase";
            this.chargingImageCase.Size = new System.Drawing.Size(35, 28);
            this.chargingImageCase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.chargingImageCase.TabIndex = 10;
            this.chargingImageCase.TabStop = false;
            this.chargingImageCase.Visible = false;
            // 
            // chargingImageLeft
            // 
            this.chargingImageLeft.BackColor = System.Drawing.Color.White;
            this.chargingImageLeft.Image = global::AirpodsStartbarService.Properties.Resources.chargingbolt_small;
            this.chargingImageLeft.Location = new System.Drawing.Point(309, 338);
            this.chargingImageLeft.Name = "chargingImageLeft";
            this.chargingImageLeft.Size = new System.Drawing.Size(35, 28);
            this.chargingImageLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.chargingImageLeft.TabIndex = 9;
            this.chargingImageLeft.TabStop = false;
            this.chargingImageLeft.Visible = false;
            // 
            // chargingImageRight
            // 
            this.chargingImageRight.BackColor = System.Drawing.Color.White;
            this.chargingImageRight.Image = global::AirpodsStartbarService.Properties.Resources.chargingbolt_small;
            this.chargingImageRight.Location = new System.Drawing.Point(97, 338);
            this.chargingImageRight.Name = "chargingImageRight";
            this.chargingImageRight.Size = new System.Drawing.Size(35, 28);
            this.chargingImageRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.chargingImageRight.TabIndex = 8;
            this.chargingImageRight.TabStop = false;
            this.chargingImageRight.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::AirpodsStartbarService.Properties.Resources.airpods_image_small;
            this.pictureBox1.Location = new System.Drawing.Point(-3, -30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(806, 533);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // serviceMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 492);
            this.Controls.Add(this.chargingImageCase);
            this.Controls.Add(this.chargingImageLeft);
            this.Controls.Add(this.chargingImageRight);
            this.Controls.Add(this.leftIndicator);
            this.Controls.Add(this.rightIndicator);
            this.Controls.Add(this.caseLabel);
            this.Controls.Add(this.rightPodLabel);
            this.Controls.Add(this.leftPodLabel);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(814, 531);
            this.MinimumSize = new System.Drawing.Size(814, 531);
            this.Name = "serviceMainWindow";
            this.Text = "Airpods Service";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageCase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingImageRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label rightPodLabel;
        private System.Windows.Forms.Label caseLabel;
        private System.Windows.Forms.Label rightIndicator;
        private System.Windows.Forms.Label leftIndicator;
        private System.Windows.Forms.PictureBox chargingImageRight;
        private System.Windows.Forms.PictureBox chargingImageLeft;
        private System.Windows.Forms.PictureBox chargingImageCase;
    }
}