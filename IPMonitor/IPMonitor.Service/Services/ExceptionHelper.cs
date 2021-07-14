using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPMonitor.Service.Services
{
    public static class ExceptionHelper
    {
        public static void WriteErrorToFile(Exception ex)
        {
            try
            {
                string strLogFilePath = ConfigurationManager.AppSettings.Get("logFile");
                if (string.IsNullOrEmpty(strLogFilePath))
                {
                    strLogFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\IPMonitorErrorLog.txt";
                }
                string strLogEntry = string.Format("{6}: IP Monitor encountered an error. See the details below.{0}Message:{1}{2}{3}Stack Trace:{4}{5}", Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.StackTrace, DateTime.Now.ToString());
                File.WriteAllText(strLogFilePath, strLogEntry);
            }
            catch (Exception err)
            {
                WriteErrorToEventLog(err);
            }
        }

        public static void WriteErrorToEventLog(Exception ex)
        {
            try
            {
                if (!EventLog.SourceExists("Application"))
                {
                    EventLog.CreateEventSource("Application", "IPMonitor");
                }
                EventLog eventLog = new EventLog();
                eventLog.Source = "Application";
                eventLog.WriteEntry(string.Format("{6}: IP Monitor encountered an error. See the details below.{0}Message:{1}{2}{3}Stack Trace:{4}{5}", Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.StackTrace, DateTime.Now.ToString()), EventLogEntryType.Error);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
