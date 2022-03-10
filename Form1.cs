using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.ServiceProcess;
using System.Security.Principal;
using System.Collections.Generic;
using InTheHand.Net.Sockets;

namespace AirpodsStartbarService
{
    public partial class serviceMainWindow : Form
    {
        private ServiceConsumer batteryService;
        private AirpodsData data = new AirpodsData()
        {
            status = false,
            left = -1,
            right = -1,
            case1 = -1,
            charging_left = false,
            charging_right = false,
            charging_case1 = false,
            error = "",
            addr = "",
            model = "",
            rssi = 0
        };
        private Timer updateTimer;
        private Timer restartServiceTimer;
        string serviceName = "airpods-service";
        List<string> connectedDevices;
        

        public serviceMainWindow()
        {
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

            startService();

            InitializeComponent();
#if !DEBUG
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
#endif
            connectedDevices = new List<string>();

            aboutLabel.Text = AboutText();

            batteryService = new ServiceConsumer(serviceName);
            
            Task scanningService = Task.Factory.StartNew(() =>
            {
                updateTimer = new Timer();
                updateTimer.Interval = 30000;
                updateTimer.Tick += batteryUpdateConsume;

                restartServiceTimer = new Timer();
                restartServiceTimer.Interval = 300000;
                restartServiceTimer.Tick += restartServiceEvent;

                string activeDevicePrediction = "";
                while (true)
                {
                    List<string> tmpList = scanDevices().Result;
                    if (!tmpList.Contains(activeDevicePrediction) && activeDevicePrediction != "")
                    {
                        Console.WriteLine("Connected device has been disconnected: " + activeDevicePrediction);

                        updateTimer.Stop();

                        restartServiceTimer.Stop();

                        activeDevicePrediction = "";

                        batteryUpdate(false);
                    }
                    else 
                    {
                        foreach (string device in tmpList)
                        {
                            if (!connectedDevices.Contains(device))
                            {
                                Console.WriteLine("Detected new device connection: " + device);

                                activeDevicePrediction = device;

                                batteryUpdate(false);

                                updateTimer.Start();

                                restartServiceTimer.Start();
                            }
                        }
                    }
                    
                    connectedDevices = tmpList;
                }
            });

        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            updateTimer.Stop();
            restartServiceTimer.Stop();
            stopService();
            Application.Exit();
        }

        private void genericStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void batteryUpdateConsume(object sender, EventArgs e)
        {
            batteryUpdate(false);
        }

        private async void batteryUpdate(bool manual = true)
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
                        data = JsonConvert.DeserializeObject<AirpodsData>(battVal);
                        Console.WriteLine(data.ToString());
                    }
                    catch
                    {
                        Console.WriteLine(battVal);
                    }

                    string leftVal = "";
                    string rightVal = "";
                    string caseVal = "";

                    string disconText = "-";

                    if (data.left == -1)
                    {
                        leftVal = disconText;
                    }
                    else
                    {
                        leftVal = data.left.ToString() + "%";
                    }

                    if (data.right == -1)
                    {
                        rightVal = disconText;
                    }
                    else
                    {
                        rightVal = data.right.ToString() + "%";
                    }

                    if (data.case1 == -1)
                    {
                        caseVal = disconText;
                    }
                    else
                    {
                        caseVal = data.case1.ToString() + "%";
                    }

                    string displayTextLeft = String.Format("Left Ear Bud:     {0}", leftVal);
                    string displayTextRight = String.Format("Right Ear Bud:    {0}", rightVal);
                    string displayTextCase = String.Format("Charging Case:    {0}", caseVal);

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

                        if (data.charging_left)
                        {
                            this.chargingImageLeft.Show();
                        }
                        else
                        {
                            this.chargingImageLeft.Hide();
                        }
                        this.chargingImageLeft.Update();

                        if (data.charging_right)
                        {
                            this.chargingImageRight.Show();
                        }
                        else
                        {
                            this.chargingImageRight.Hide();
                        }
                        this.chargingImageRight.Update();

                        if (data.charging_case1)
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
                            Timer toastTimer = new Timer();
                            toastTimer.Interval = 5000;
                            toastTimer.Tick += (sender, args) => { updatingInfoToast.Visible = false; toastTimer.Stop(); toastTimer.Dispose(); };
                            toastTimer.Start();
                        }
                        else
                        {
                            updatingInfoToast.Visible = false;
                        }

                    };

                    this.Invoke(inv);
                    return;
                }
            });

            await task;
            task.Dispose();
           
        }

        private void restartServiceEvent(object sender, EventArgs e)
        {
            restartService();
        }

        private async void restartService()
        {
            await stopService();
            await startService();
        }

        private async Task<bool> startService()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                ServiceController service = new ServiceController(serviceName);
                if (service.Status != ServiceControllerStatus.Running && service.Status != ServiceControllerStatus.StartPending)
                {
                    Console.WriteLine("Starting Service");
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                }
            });
            await task;
            task.Dispose();
            return true;
        }

        private async Task<bool> stopService()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                ServiceController service = new ServiceController(serviceName);
                if (service.Status != ServiceControllerStatus.Stopped || service.Status != ServiceControllerStatus.StopPending)
                {
                    Console.WriteLine("Stopping Service");
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                }
            });
            await task;
            task.Dispose();
            return true;
        }

        private static bool IsAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void toolStripAbout_Click(object sender, EventArgs e)
        {
            updatingInfoToast.BackColor = Color.Transparent;
            aboutPanel.Show();
        }

        private void backToMainViewButton_Click(object sender, EventArgs e)
        {
            updatingInfoToast.BackColor = Color.White;
            aboutPanel.Hide();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restartService();
        }

        private void githubVisitText_Click(object sender, EventArgs e)
        {
            navigateToGithubLink();
        }

        private void githubLogo_Click(object sender, EventArgs e)
        {
            navigateToGithubLink();
        }

        private void githubText_Click(object sender, EventArgs e)
        {
            navigateToGithubLink();
        }

        private void navigateToGithubLink()
        {
            System.Diagnostics.Process.Start("http://github.com/Gr34v0/AirpodsStartbarService");
        }


        private void updateAirpodsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scanDevices();
            batteryUpdate(true);
        }

        private void updatingInfoToast_Click(object sender, EventArgs e)
        {

        }

        private Task<List<string>> scanDevices()
        {
            return Task.Factory.StartNew(() => {
                BluetoothClient client = new BluetoothClient();
                List<string> items = new List<string>();
                BluetoothDeviceInfo[] devices = client.DiscoverDevices();
                foreach (BluetoothDeviceInfo d in devices)
                {
                    if (d.Connected)
                    {
                        items.Add(d.DeviceName);
                    }
                }
                return items;
            });
        }

        private string AboutText()
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