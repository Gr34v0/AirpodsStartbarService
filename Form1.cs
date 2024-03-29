﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Security.Principal;

namespace AirpodsStartbarService
{
    public partial class ServiceMainWindow : Form
    {
        internal ServiceConsumer batteryService;
        

        internal string serviceName;

        internal ServiceMainWindow(ServiceConsumer batteryServiceImport)
        {
            batteryService = batteryServiceImport;
            serviceName = batteryService.pipeName;

            if (!IsAdmin())
            {
                if(MessageBox.Show("Airpods Startbar Service must be run in Administrator Mode") == DialogResult.OK)
                {
                    if (Application.MessageLoop)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                }
            }

            
            InitializeComponent();
#if !DEBUG
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
#endif
            aboutLabel.Text = AboutText();

            Task tsk = Task.Factory.StartNew(() => 
            {
                while (!batteryService.serviceOnline)
                {
                    Thread.Sleep(500);
                }

                while (true)
                {
                    if (batteryService.updateInfo != UpdateBatteryEnum.NoUpdate)
                    {
                        batteryUpdate(false);
                        batteryService.updateInfo = UpdateBatteryEnum.NoUpdate;
                    }
                    Thread.Sleep(500);
                }
            });

        }

        internal void Form1_Load(object sender, EventArgs e)
        {
            Displaynotify();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            return;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        protected void Displaynotify()
        {
            try
            {
                notifyIcon1.Icon = new Icon(Path.GetFullPath(@"\images\airpods-image-icon.ico"));
            }
            catch (Exception ex)
            {
            }
        }

        internal void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        internal void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            batteryService.updateTimer.Dispose();
            batteryService.restartServiceTimer.Dispose();
            batteryService.stopService();
            Application.Exit();
        }

        internal void genericStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        internal static bool IsAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        internal void toolStripAbout_Click(object sender, EventArgs e)
        {
            updatingInfoToast.BackColor = Color.Transparent;
            aboutPanel.Show();
        }

        internal void backToMainViewButton_Click(object sender, EventArgs e)
        {
            updatingInfoToast.BackColor = Color.White;
            aboutPanel.Hide();
        }

        internal void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            batteryService.restartService();
        }

        internal void githubVisitText_Click(object sender, EventArgs e)
        {
            navigateToGithubLink();
        }

        internal void githubLogo_Click(object sender, EventArgs e)
        {
            navigateToGithubLink();
        }

        internal void githubText_Click(object sender, EventArgs e)
        {
            navigateToGithubLink();
        }

        internal void navigateToGithubLink()
        {
            System.Diagnostics.Process.Start("http://github.com/Gr34v0/AirpodsStartbarService");
        }

        internal void updateAirpodsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            batteryService.scanDevices();
            batteryService.updateInfo = UpdateBatteryEnum.ManualUpdate;
        }

        internal async void batteryUpdate(bool manual = true)
        {
            if (manual)
            {
                updatingInfoToast.Text = "Updating Battery Info...";
                updatingInfoToast.Visible = true;
            }
            Task task = Task.Factory.StartNew(() =>
            {
                string battVal = batteryService.readPipe();
                if (battVal != null && batteryService != null)
                {
                    battVal = battVal.Replace("case", "case1");

                    try
                    {
                        batteryService.data = JsonConvert.DeserializeObject<AirpodsData>(battVal);
                        Console.WriteLine(batteryService.data.ToString());
                    }
                    catch
                    {
                        Console.WriteLine(battVal);
                    }

                    string leftVal = "";
                    string rightVal = "";
                    string caseVal = "";

                    string disconText = "-";

                    if (batteryService.data.left == -1)
                    {
                        leftVal = disconText;
                    }
                    else
                    {
                        leftVal = batteryService.data.left.ToString() + "%";
                    }

                    if (batteryService.data.right == -1)
                    {
                        rightVal = disconText;
                    }
                    else
                    {
                        rightVal = batteryService.data.right.ToString() + "%";
                    }

                    if (batteryService.data.case1 == -1)
                    {
                        caseVal = disconText;
                    }
                    else
                    {
                        caseVal = batteryService.data.case1.ToString() + "%";
                    }

                    string displayTextLeft = String.Format("Left Ear Bud:     {0}", leftVal);
                    string displayTextRight = String.Format("Right Ear Bud:    {0}", rightVal);
                    string displayTextCase = String.Format("Charging Case:    {0}", caseVal);

                    DateTime nowTime = DateTime.Now;
                    Console.WriteLine(nowTime.Minute + ":" + nowTime.Second);
                    Console.WriteLine(displayTextLeft);
                    Console.WriteLine(displayTextRight);
                    Console.WriteLine(displayTextCase);

                    MethodInvoker inv = delegate
                    {
                        notifyIcon1.Text = "Airpods Battery\r\n" + displayTextLeft + "\r\n" + displayTextRight;

                        this.leftEarBudToolStripMenuItem.Text = displayTextLeft;
                        this.rightEarBudToolStripMenuItem.Text = displayTextRight;
                        this.chargingCaseToolStripMenuItem.Text = displayTextCase;

                        this.rightPodLabel.Text = rightVal;
                        this.leftPodLabel.Text = leftVal;
                        this.caseLabel.Text = caseVal;

                        this.contextMenuStrip1.Refresh();
                        this.contextMenuStrip1.Update();

                        this.rightPodLabel.Update();
                        this.leftPodLabel.Update();
                        this.caseLabel.Update();

                        if (batteryService.data.charging_left)
                        {
                            this.chargingImageLeft.Show();
                        }
                        else
                        {
                            this.chargingImageLeft.Hide();
                        }
                        this.chargingImageLeft.Update();

                        if (batteryService.data.charging_right)
                        {
                            this.chargingImageRight.Show();
                        }
                        else
                        {
                            this.chargingImageRight.Hide();
                        }
                        this.chargingImageRight.Update();

                        if (batteryService.data.charging_case1)
                        {
                            this.chargingImageCase.Show();
                        }
                        else
                        {
                            this.chargingImageCase.Hide();
                        }
                        this.chargingImageCase.Update();

                        if (manual)
                        {
                            updatingInfoToast.Text = "Battery Info Updated";
                            System.Windows.Forms.Timer toastTimer = new System.Windows.Forms.Timer();
                            toastTimer.Interval = 5000;
                            toastTimer.Tick += (sender, args) => { updatingInfoToast.Visible = false; toastTimer.Stop(); toastTimer.Dispose(); };
                            toastTimer.Start();
                        }
                        else
                        {
                            updatingInfoToast.Visible = false;
                        }

                        if(leftVal == disconText && rightVal == disconText && caseVal == disconText)
                        {
                            updatingInfoToast.Text = "Establishing Connection To Airpods";
                        }

                        updatingInfoToast.Update();

                    };

                    this.Invoke(inv);
                    return;
                }
            });

            await task;
            task.Dispose();
        }

        internal string AboutText()
        {
            return
                "I was extremely annoyed with not being able to simply view the battery life on my AirPods when I was using them with my Windows laptop." +
                "I don't have any Apple devices, but I love using my AirPods for meetings and music which can be frustrating due to the lack of integration.\r\n\r\n" +
                "I have now solved this issue with help from ohandean's Airpods Windows Service, and made it open for anyone to use.\r\n\r\n" +
                "Hopefully you find this useful\r\n\r\n - Holly G"
                ;
        }
    }
}