using SellerSense.Helper;
using SellerSense.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ///Logger logger = new FileLogger();
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //Log level is hard coded here, this value is written in json file, and reset any user setting done in last run
                //If you dont want to reset logging level, then try to read logging level from config json, if not found, execute below line.
                //Also change tooltip value
                Logger.SetLoggerLevel_LogAboveThisLevelOnly(Logger.LogLevel.info);

                //Evaluate Telegram setting, this will set telegram  logging bool variable
                Logger.IsTelegramLogEnabled();

#if  DebugWithNoGlobalExeceptions
                // Add the event handler for handling UI thread exceptions to the event.
                if (!System.Diagnostics.Debugger.IsAttached)
                    Application.ThreadException += new ThreadExceptionEventHandler(Form1_UIThreadException);


                // Set the unhandled exception mode to force all Windows Forms errors
                // to go through our handler.
                if (!System.Diagnostics.Debugger.IsAttached)
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                // Add the event handler for handling non-UI thread exceptions to the event. 
                if (!System.Diagnostics.Debugger.IsAttached)
                    AppDomain.CurrentDomain.UnhandledException += new
                UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
#endif
                //throw new InvalidOperationException("Testing");
                Application.Run(new Welcome());
            }
            catch (Exception e)
            {
                string logLocation = "";
                try
                { logLocation = ProjIO.GetUserSetting(Constants.WorkspaceDir); }
                catch (Exception) { }
                
                 Logger.Log(e.Message, Logger.LogLevel.fatal, true);
                AlertBox abox = new AlertBox("Error","Unexpected Error occurred, application cant be recovered, " +
                    "restart required. If problem persists, send logs to customer support, logs location : " + logLocation); //TODO : assign logs location
                abox.ShowDialog();
                Application.Exit();
            }
           
        }


        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        // NOTE: This exception cannot be kept from terminating the application - it can only
        // log the event, and inform the user about it.
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
               
                Exception ex = (Exception)e.ExceptionObject;
                string errorMsg = "An application error occurred. Please contact the adminstrator " +
                    "with the following information:\n\n";
                //Logger logger = new FileLogger();
                Logger.Log(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace, Logger.LogLevel.fatal, true);
                AlertBox abox = new AlertBox("Error", "Unexpected Error occurred, application cant be recovered, " +
                    "restart required. If problem persists, send logs to customer support, Setup > Export All > Select Logs"); //TODO : assign logs location
                abox.ShowDialog();
                //// Since we can't prevent the app from terminating, log this to the event log.
                //if (!EventLog.SourceExists("ThreadException"))
                //{
                //    EventLog.CreateEventSource("ThreadException", "Application");
                //}

                //// Create an EventLog instance and assign its source.
                //EventLog myLog = new EventLog();
                //myLog.Source = "ThreadException";
                //myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error",
                        "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }


        //// Creates the error message and displays it.
        //private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        //{
        //    string errorMsg = "An application error occurred. Please contact the adminstrator " +
        //        "with the following information:\n\n";
        //    errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
        //    return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
        //        MessageBoxIcon.Stop);
        //}

        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        private static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                //result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
                string errorMsg =  t.Exception.Message + "\n\nStack Trace:\n" + t.Exception.StackTrace;
                //Logger logger = new FileLogger();
                Logger.Log(errorMsg, Logger.LogLevel.fatal, true);
                AlertBox abox = new AlertBox("Error", "Unexpected Error occurred, application cant be recovered, " +
                    "restart required. If problem persists, send logs to customer support, Setup > Export All > Select Logs"); //TODO : assign logs location
                abox.ShowDialog();
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }


    }
}
