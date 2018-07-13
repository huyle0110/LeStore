using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace LeStoreLibrary.Utils
{
    public class LogWriter
    {
        static string LogExceptionPath = string.Empty;
        static string LogMsgPath = string.Empty;
        static readonly object lockLog = new object();
        static readonly object lockRaw = new object();
        public static void Init()
        {
            string LogFolderPath = WebConfigurationManager.AppSettings["LogFolderPath"];
            if (!Directory.Exists(LogFolderPath))
                Directory.CreateDirectory(LogFolderPath);
            LogExceptionPath = Path.Combine(LogFolderPath, "LogException.txt");
            if (!Directory.Exists(LogExceptionPath))
                Directory.CreateDirectory(LogExceptionPath);
            LogMsgPath = Path.Combine(LogFolderPath, "LogException.txt");
            if (!Directory.Exists(LogExceptionPath))
                Directory.CreateDirectory(LogExceptionPath);
        }
        public static void WriteLogException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Begin Write Log: " + DateTime.Now.ToString());
            sb.AppendLine("Exception: " + ex.ToString());
            sb.AppendLine("The End Write Log.");
            WriteFile(LogExceptionPath, sb.ToString());
        }

        public static void WriteLogMsg(string Message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Begin Write Log Message: " + DateTime.Now.ToString());
            sb.AppendLine("Message:" + Message);
            sb.AppendLine("The End Write Log.");
            WriteFile(LogMsgPath, sb.ToString());
        }

        public static void WriteFile(string LogPath, string Content)
        {
            Task.Factory.StartNew(() => {
                lock (lockRaw)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(LogPath, true, Encoding.UTF8))
                        {
                            writer.WriteLine(Content);
                        };
                    }
                    catch { }
                }
            });
        }
    }
}
