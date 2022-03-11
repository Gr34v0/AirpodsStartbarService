using System;
using System.Windows.Forms;

namespace AirpodsStartbarService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ServiceConsumer serviceConsumer = new ServiceConsumer();
            ServiceMainWindow serviceMainWindow = new ServiceMainWindow(serviceConsumer);
            serviceConsumer.activeForm = serviceMainWindow;
            serviceConsumer.StartBackend();
            Application.Run(serviceMainWindow);
        }
    }
}
