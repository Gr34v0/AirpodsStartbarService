using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.ServiceProcess;
using System.Security.Principal;

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
        private Timer timer;
        private Timer serviceTimer;
        string serviceName = "airpods-service";

        public serviceMainWindow()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            batteryService = new ServiceConsumer(serviceName);

            restartService();

            timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += batteryUpdate;
            timer.Start();

            serviceTimer = new Timer();
            serviceTimer.Interval = 300000;
            serviceTimer.Tick += restartServiceEvent;
            serviceTimer.Start();
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
                notifyIcon1.Icon = new Icon(Path.GetFullPath(@"\images\Icon1.ico"));
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
            timer.Stop();
            serviceTimer.Stop();
            Application.Exit();
        }

        private void genericStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void batteryUpdate(object sender, EventArgs e)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                string battVal = batteryService.readPipe();
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
                string displayTextRight =String.Format("Right Ear Bud:    {0}", rightVal);
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

                };
                this.Invoke(inv);
                return;
            });
        }

        private void restartServiceEvent(object sender, EventArgs e)
        {
            restartService();
        }

        private void restartService()
        {
            Console.WriteLine("Restarting Service");
            ServiceController service = new ServiceController(serviceName);
            if(service.Status == ServiceControllerStatus.Running)
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped);
            }
            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running);
        }

        private static bool IsAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void toolStripFile_Click(object sender, EventArgs e)
        {

        }

        private void toolStripAbout_Click(object sender, EventArgs e)
        {
            backToMainViewButton.Show();
            //this.Hide();
            //AboutForm aboutForm = new AboutForm();
            //aboutForm.Show();
            pictureBox1.Hide();
            leftPodLabel.Hide();
            rightPodLabel.Hide();
        }

        private void backToMainViewButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            leftPodLabel.Show();
            rightPodLabel.Show();
        }
    }
}