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
                string strLogEntry = string.Format("IP Monitor encountered an error. See the details below.{0}Message:{1}{2}Stack Trace:{3}{4}", Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.StackTrace);
                File.WriteAllText(strLogFilePath, strLogEntry);
            }
            catch (Exception err)
            {
                WriteErrorToEventLog(err);
            }
        }

        public static void WriteErrorToEventLog(Exception ex)
        {
            EventLog eventLog = new EventLog("IPMonitor");
            eventLog.WriteEntry(string.Format("IP Monitor encountered an error. See the details below.{0}Message:{1}{2}Stack Trace:{3}{4}", Environment.NewLine, Environment.NewLine, ex.Message, Environment.NewLine, Environment.NewLine, ex.StackTrace), EventLogEntryType.Error);
        }
    }
}
