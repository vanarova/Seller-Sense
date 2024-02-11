using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updates
{
    public partial class Updates :  SfForm
    {
        private string donloadVersion;
        public Updates(string donloadVersion)
        {
            this.donloadVersion = donloadVersion;
            InitializeComponent();
        }

        private void Updates_Load(object sender, EventArgs e)
        {
           
        }

        private async void button_install_Click(object sender, EventArgs e)
        {
            progressBar_update.Visible = true;
            label_status.Visible = true;
            label_status.Text = "Downloading installer..";
            //Environment.GetFolderPath(Environment.SpecialFolder.)
            string tempPath = Path.Combine(System.IO.Path.GetTempPath(), "SellerSense");
            if(!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            string tempFileDownloadPath = Path.Combine(tempPath, "SS.msi");
            await CheckUpdates.DownloadSetup(donloadVersion, tempFileDownloadPath);
            CheckUpdates.RunSetUp(tempFileDownloadPath);
        }
    }
}
