using Common;
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

            this.Style.TitleBar.ForeColor = Color.White;
            this.Style.TitleBar.BackColor = Constants.Theme.BorderColor;
            this.Style.Border.Color = Constants.Theme.BorderColor;
            this.Style.InactiveBorder.Color = Constants.Theme.BorderColor;
            this.Style.Border.Width = Constants.Theme.BorderWidth;
            this.Style.InactiveBorder.Width = Constants.Theme.BorderWidth;
        }

        private void Updates_Load(object sender, EventArgs e)
        {
           
        }

        private async void button_install_Click(object sender, EventArgs e)
        {
            progressBar_update.Visible = true;
            
            button_install.Enabled = false;
            label_status.Visible = true;
            label_status.Text = "Downloading installer..";
            //Environment.GetFolderPath(Environment.SpecialFolder.)
            string tempPath = Path.Combine(System.IO.Path.GetTempPath(), "SellerSense");
            if(!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            string tempFileDownloadPath = Path.Combine(tempPath, "SS.msi");
            await CheckUpdates.DownloadSetup(donloadVersion, tempFileDownloadPath);
            label_status.Text = "Application will now close..";

            await Task.Delay(4000);
            CheckUpdates.RunSetUp(tempFileDownloadPath);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
