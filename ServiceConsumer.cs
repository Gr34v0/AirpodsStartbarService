using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using InTheHand.Net.Sockets;
using System.IO.Pipes;
using System.ServiceProcess;


namespace AirpodsStartbarService
{
    internal class ServiceConsumer
    {
        private string _pipeName = "airpods-service";
        private bool _deviceDetected;
        public UpdateBatteryEnum updateInfo = UpdateBatteryEnum.NoUpdate;
        public bool serviceOnline = false;

        List<string> connectedDevices;
        public bool deviceDetected
        {
            get
            {
                return _deviceDetected;
            }
            private set
            {
                _deviceDetected = deviceDetected;
            }
        }

        public string pipeName
        {
            get
            {
                return _pipeName;
            }
            private set
            {
                _pipeName = value;
            }
        }

        public Timer updateTimer;
        public Timer restartServiceTimer;

        internal AirpodsData data = new AirpodsData();

        public ServiceConsumer()
        {
            connectedDevices = new List<string>();
            deviceDetected = false;
        }

        public void StartBackend()
        {
            Task scanningService = Task.Factory.StartNew(async () =>
            {
                string activeDevicePrediction = "";
                while (true)
                {
                    List<string> tmpList = await scanDevices();
                    if (!tmpList.Contains(activeDevicePrediction) && activeDevicePrediction != "")
                    {
                        Console.WriteLine("Connected device has been disconnected: " + activeDevicePrediction);

                        updateTimer.Dispose();
                        restartServiceTimer.Dispose();

                        activeDevicePrediction = "";

                        updateInfo = UpdateBatteryEnum.AutoUpdate;
                        await stopService();
                    }
                    else
                    {
                        foreach (string device in tmpList)
                        {
                            if (!connectedDevices.Contains(device) && device.ToLower().Contains("airpods"))
                            {
                                Console.WriteLine("Detected new device connection: " + device);

                                activeDevicePrediction = device;

                                updateInfo = UpdateBatteryEnum.AutoUpdate;

                                updateTimer = makeUpdateTimer();
                                restartServiceTimer = makeRestartTimer();
                                break;
                            }
                        }
                    }

                    connectedDevices = tmpList;
                }
            });
        }

        internal void batteryUpdateConsume(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            updateInfo = UpdateBatteryEnum.AutoUpdate;
            autoEvent.Set();
        }

        internal void restartServiceEvent(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            restartService();
            autoEvent.Set();
            updateInfo = UpdateBatteryEnum.AutoUpdate;
        }

        internal Timer makeUpdateTimer()
        {
            return new Timer(batteryUpdateConsume, new AutoResetEvent(true), 1000, 30000);
        }

        internal Timer makeRestartTimer()
        {
            return new Timer(restartServiceEvent, new AutoResetEvent(true), 1000, 300000);
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

        internal async void restartService()
        {
            await stopService();
            await startService();
        }

        internal async Task<bool> startService()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                ServiceController service = new ServiceController(pipeName);
                if (service.Status != ServiceControllerStatus.Running && service.Status != ServiceControllerStatus.StartPending)
                {
                    try
                    {
                        Console.WriteLine("Starting Service");
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running);
                        Console.Write("Service Started");
                        
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine("Service could not be started as it is in the following state: " + service.Status);
                    }
                }
                serviceOnline = true;
            });
            await task;
            task.Dispose();
            return true;
        }

        internal async Task<bool> stopService()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                ServiceController service = new ServiceController(pipeName);
                if (service.Status != ServiceControllerStatus.Stopped || service.Status != ServiceControllerStatus.StopPending)
                {
                    try
                    {
                        Console.WriteLine("Stopping Service");
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped);
                        Console.WriteLine("Service Stopped");
                        
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine("Service could not be stopped as it is in the following state: " + service.Status);
                    }
                    data = new AirpodsData();
                    updateInfo = UpdateBatteryEnum.AutoUpdate;
                }
                serviceOnline = false;
            });
            await task;
            task.Dispose();
            return true;
        }

    }
}
