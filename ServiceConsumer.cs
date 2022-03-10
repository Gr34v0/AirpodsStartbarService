using System;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using InTheHand.Net.Sockets;
using System.IO.Pipes;


namespace AirpodsStartbarService
{
    internal class ServiceConsumer
    {
        private string _pipeName = "airpods-service";

        List<string> connectedDevices;

        public string pipeName
        {
            get
            {
                return _pipeName;
            }
            set
            {
                _pipeName = value;
            }
        }

        public Timer updateTimer;
        public Timer restartServiceTimer;

        public ServiceConsumer()
        {
            connectedDevices = new List<string>();
        }

        public void StartBackend(ServiceMainWindow activeForm)
        {
            
            Task scanningService = Task.Factory.StartNew(() =>
            {
                updateTimer = new Timer();
                updateTimer.Interval = 30000;
                updateTimer.Tick += activeForm.batteryUpdateConsume;

                restartServiceTimer = new Timer();
                restartServiceTimer.Interval = 300000;
                restartServiceTimer.Tick += activeForm.restartServiceEvent;

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

                        activeForm.batteryUpdate(false);
                    }
                    else
                    {
                        foreach (string device in tmpList)
                        {
                            if (!connectedDevices.Contains(device))
                            {
                                Console.WriteLine("Detected new device connection: " + device);

                                activeDevicePrediction = device;

                                activeForm.batteryUpdate(false);

                                updateTimer.Start();

                                restartServiceTimer.Start();
                            }
                        }
                    }

                    connectedDevices = tmpList;
                }
            });
        }

        internal Task<List<string>> scanDevices()
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

        public string readPipe()
        {
            using (NamedPipeClientStream pipe = new NamedPipeClientStream(
                ".",
                pipeName,
                PipeAccessRights.ReadData | PipeAccessRights.WriteAttributes,
                PipeOptions.None,
                System.Security.Principal.TokenImpersonationLevel.None,
                HandleInheritability.None
                ))
            {
                try
                {
                    pipe.Connect();
                }
                catch (UnauthorizedAccessException uae)
                {
                    return "Cannot connect to pipe";
                }
                catch (System.Reflection.TargetInvocationException tie)
                {
                    return "Already Connected to pipe";
                }
                catch (IOException ioe)
                {
                    return ioe.Message;
                }

                StreamReader pipeStream;
                string result;
                try
                {
                    using (pipeStream = new StreamReader(pipe))
                    {
                        result = pipeStream.ReadLine();
                    }
                }
                catch
                {
                    Console.WriteLine("Unable to open StreamReader to pipe");
                    result = "";
                }
                pipe.Close();
                return result;
            }
  
        }
    }
}
