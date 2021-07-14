using IPMonitor.Service.Services;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using System.Windows.Forms;

namespace IPMonitor.Service
{
    public partial class IPMonitor : ServiceBase
    {
        private System.Timers.Timer _mIntervalTimer;

        public IPMonitor()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _mIntervalTimer = new System.Timers.Timer();
            _mIntervalTimer.AutoReset = false;
            _mIntervalTimer.Elapsed += Timer_Elapsed;
            ValidateIPAddress(ConnectionHelper.GetExternalIpAddress());
            SetupTimer(_mIntervalTimer);
            EventLog.WriteEntry("IP Monitor started successfully...");
        }

        private void SetupTimer(System.Timers.Timer timer)
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
            int intervalMinutes;
            int.TryParse(ConfigurationManager.AppSettings.Get("executionMinutes"), out intervalMinutes);
            if (intervalMinutes == 0)
            {
                intervalMinutes = 10;
            }
            timer.Interval = intervalMinutes * 60000;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ValidateIPAddress(ConnectionHelper.GetExternalIpAddress());
            SetupTimer((System.Timers.Timer)sender);
        }

        private void ValidateIPAddress(string ipAddress) 
        {
            try
            {
                string strFileIpAddress = "";
                string strIpAddressFilePath = "";
                // read the file path from configuration
                strIpAddressFilePath = ConfigurationManager.AppSettings.Get("ipAddressFile");
                // if file path not defined in configuration, use the default
                if (string.IsNullOrEmpty(strIpAddressFilePath))
                {
                    strIpAddressFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\IPMonitor.txt";
                }
                // read the ip address file content if the file exists
                if (File.Exists(strIpAddressFilePath))
                {
                    strFileIpAddress = File.ReadAllText(strIpAddressFilePath);
                }
                // if the file is empty or doesn't exist, write the ip address to the file (creates file if necessary).
                if (string.IsNullOrEmpty(strIpAddressFilePath))
                {
                    File.WriteAllText(strIpAddressFilePath, ipAddress);
                }
                // if the ip address has changed, throw an exception
                else if (strFileIpAddress != ipAddress)
                {
                    File.WriteAllText(strIpAddressFilePath, ipAddress);

                    MessageBox.Show(string.Format("The external IP Address has changed to \"{0}\".", ipAddress), "IP Address Changed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
            }
            catch (Exception err)
            {
                ExceptionHelper.WriteErrorToFile(err);
                ExceptionHelper.WriteErrorToEventLog(err);
            }
        }

        protected override void OnStop()
        {
        }

        private void IPMonitorNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(string.Format("External IP Address: {0}", ConnectionHelper.GetExternalIpAddress()), "IP Address Changed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }
    }
}
