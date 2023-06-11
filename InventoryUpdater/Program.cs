using SellerSense.Helper;
using SellerSense.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Logger logger = new FileLogger();
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //throw new InvalidOperationException("Testing");
                Application.Run(new Welcome());
            }
            catch (Exception e)
            {
                logger.Log(e.Message, Logger.LogLevel.fatal, true);
                AlertBox abox = new AlertBox("Error","Unexpected Error occurred, application cant be recovered, " +
                    "restart required. If problem persists, send logs to customer support, logs location :[]"); //TODO : assign logs location
                abox.ShowDialog();
                Application.Exit();
            }
           
        }
    }
}
