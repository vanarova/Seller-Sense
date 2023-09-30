using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot;
using static TelegramBot.Messenger;

namespace SellerSense.Helper
{
    internal static class Logger
    {
       internal enum LogLevel
        {
            warning =0, error = 1, fatal = 2, debug = 3, info = 4
        }

        private static string _botToken;
        private static long _chatId;
        private static string _mapDirPath;
        private static string _globalLogPath;
        private const string logFileName = Constants.logFileName;
        private static Messenger.LogDepth _TelegramlogDepth;
        private static LogLevel _logLevel;

        static Logger()
        {
            _TelegramlogDepth = Messenger.LogDepth.LogAllActions; /// if no log depth is set, use this value.
            _logLevel = LogLevel.info;
            

            _globalLogPath = ProjIO.DefaultWorkspaceLocation();

            _botToken = ProjIO.GetUserSetting(Constants.TelegramSettings.BotID.ToString());
            bool success = long.TryParse(ProjIO.GetUserSetting(Constants.TelegramSettings.ChatID.ToString()), out long chatid);
            _chatId = chatid;
            if (!success)
            { Log("Telegram Chat id is empty.", LogLevel.warning, true); }

//#if DEBUG
//            _botToken = "6690932378:AAEqzJfgbgUNic4S30aSkdXdStoz8eB8574";
//            _chatId = -889985488;
//#endif
        }

        internal static void SetTelegramLogDepth_LogAboveThisLevelOnly(Messenger.LogDepth logdepth)
        {
            _TelegramlogDepth = logdepth;
        }

        internal static void SetLoggerLevel_LogAboveThisLevelOnly(LogLevel logdepth)
        {
            _logLevel = logdepth;
        }

        internal static void SetTelegramSettings(string botToken,long chatId)
        { _botToken = botToken; _chatId = chatId;  }
 
        internal static async void TelegramLog(string message, LogLevel logLevel, string companyCode = "")
        {
            if(string.IsNullOrEmpty(_botToken) || _chatId == 0)
                return;
            if ((int)_logLevel < (int)logLevel)
                return;
            var logMessage = $"[{DateTime.Now}] [{logLevel.ToString()}] {message}";
            await Messenger.SendTelegramMessage(_botToken, _chatId, logMessage, _TelegramlogDepth);
        }


        internal static async void Telegram(string message)
        {
            if (string.IsNullOrEmpty(_botToken) || _chatId == 0)
                return;
            
            await Messenger.SendTelegramMessage(_botToken, _chatId, message, _TelegramlogDepth);
        }

        internal static async void TelegramMedia(string filePath,string fileName, string message,
            LogLevel logLevel, string companyCode = "")
        {
            if (string.IsNullOrEmpty(_botToken) || _chatId == 0)
                return;
            if ((int)_logLevel < (int)logLevel)
                return;
            
            await Messenger.SendTelegramImage(_botToken, _chatId,message, filePath, fileName, _TelegramlogDepth);
           
        }

        internal static async Task TelegramDocument(string filePath, string fileName,
           LogLevel logLevel, string companyCode = "")
        {
            if (string.IsNullOrEmpty(_botToken) || _chatId == 0)
                return;
            if ((int)_logLevel < (int)logLevel)
                return;

            await Messenger.SendTelegramFile(_botToken, _chatId,  filePath, fileName, _TelegramlogDepth);

        }



        internal static void Log(string companyCode, string message, LogLevel logLevel)
        {
            if ((int)_logLevel < (int)logLevel)
                return;
            (_, _mapDirPath) = ProjIO.GetCompanyMapDirIfExist(companyCode);
            var logMessage = $"[{DateTime.Now}] [{logLevel.ToString()}] {message}";
            using (var writer = File.AppendText(Path.Combine(_mapDirPath, logFileName)))
            {
                writer.WriteLine(logMessage);
            }
        }

        internal static void Log(string message, LogLevel logLevel, bool IsApplicationLevelError)
        {
            if ((int)_logLevel < (int)logLevel)
                return;
            var logMessage = $"[{DateTime.Now}] [{logLevel.ToString()}] {message}";
            using (var writer = File.AppendText(Path.Combine(_globalLogPath, logFileName)))
            {
                writer.WriteLine(logMessage);
            }
        }

    }


   
       
   









//    internal abstract class Logger
//    {
//        internal abstract void Log(string message, LogLevel logLevel);
//        internal abstract void Log(string message, LogLevel logLevel, bool IsApplicationLevelError);

//        internal enum LogLevel
//        {
//            warning = 0, error = 1, fatal = 2, debug = 3, info = 4
//        }
//    }


//    internal class FileLogger : Logger
//    {
//        private readonly string _mapDirPath;
//        private readonly string _globalLogPath;
//        private const string logFileName = Constants.logFileName;

//        public FileLogger(string companyCode)
//        {
//            (_, _mapDirPath) = ProjIO.GetCompanyMapDirIfExist(companyCode);
//        }

//        public FileLogger()
//        {
//            _globalLogPath = ProjIO.DefaultWorkspaceLocation();
//        }

//        internal override void Log(string message, LogLevel logLevel)
//        {
//            var logMessage = $"[{DateTime.Now}] [{logLevel.ToString()}] {message}";
//            using (var writer = File.AppendText(Path.Combine(_mapDirPath, logFileName)))
//            {
//                writer.WriteLine(logMessage);
//            }
//        }

//        internal override void Log(string message, LogLevel logLevel, bool IsApplicationLevelError)
//        {
//            var logMessage = $"[{DateTime.Now}] [{logLevel.ToString()}] {message}";
//#if DEBUG
//            if (!string.IsNullOrEmpty(_mapDirPath)) //check to avoid wrong calls of log method
//                throw new InvalidOperationException("Application level log is called when _mapDirPath is not empty");
//#endif
//            using (var writer = File.AppendText(Path.Combine(_globalLogPath, logFileName)))
//            {
//                writer.WriteLine(logMessage);
//            }
//        }
//    }

}
