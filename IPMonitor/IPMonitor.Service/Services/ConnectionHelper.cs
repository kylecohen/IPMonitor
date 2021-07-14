using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IPMonitor.Service.Services
{
    public static class ConnectionHelper
    {
        /// <summary>
        /// Use web client to get external IP address. Writes errors to the text file indicated in the application's configuraiton file (key = "logFile", value = path to folder in which to save log file). The log file defaults to the application root as "IPMonitor.log.txt".
        /// </summary>
        /// <returns>The external IP address of the system. Null if not obtained. </returns>
        public static string GetExternalIpAddress()
        {
            try
            {
                WebClient webClient = new WebClient();
                UTF8Encoding utf8 = new UTF8Encoding();
                string strHostName = Dns.GetHostName();
                string strVerifiedIpAddress = utf8.GetString(webClient.DownloadData("http://whatismyip.com/automation/n09230945.asp"));
                if (string.IsNullOrEmpty(strVerifiedIpAddress))
                {
                    throw new Exception("Could not obtain IP address");
                }
                return strVerifiedIpAddress;
            }
            catch(Exception ex)
            {
                //write error to text file
                ExceptionHelper.WriteErrorToFile(ex);
                ExceptionHelper.WriteErrorToEventLog(ex);
            }
            return null;
        }
    }
}
