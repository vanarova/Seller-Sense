using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Helper
{
    internal abstract class Logger
    {
        internal abstract void Log(string message, LogLevel logLevel);
        internal abstract void Log(string message, LogLevel logLevel, bool IsApplicationLevelError);

       internal enum LogLevel
        {
            warning =0, error = 1, fatal = 2, debug = 3, info = 4
        }
    }


    internal class FileLogger : Logger
    {
        private readonly string _mapDirPath;
        private readonly string _globalLogPath;
        private const string logFileName = "log.txt";

        public FileLogger(string companyCode)
        {
            (_, _mapDirPath) = ProjIO.GetCompanyMapDirIfExist(companyCode);
        }

        public FileLogger()
        {
            _globalLogPath = ProjIO.DefaultWorkspaceLocation();
        }

        internal override void Log(string message, LogLevel logLevel)
        {
            var logMessage = $"[{DateTime.Now}] [{logLevel.ToString()}] {message}";
            using (var writer = File.AppendText(Path.Combine(_mapDirPath, logFileName)))
            {
                writer.WriteLine(logMessage);
            }
        }

        internal override void Log(string message, LogLevel logLevel, bool IsApplicationLevelError)
        {
            var logMessage = $"[{DateTime.Now}] [{logLevel.ToString()}] {message}";
#if DEBUG
            if(!string.IsNullOrEmpty(_mapDirPath)) //check to avoid wrong calls of log method
              throw new InvalidOperationException("Application level log is called when _mapDirPath is not empty");
#endif
            using (var writer = File.AppendText(Path.Combine(_globalLogPath, logFileName)))
            {
                writer.WriteLine(logMessage);
            }
        }
    }



}
