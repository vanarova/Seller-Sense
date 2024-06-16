using CommonUtil;
using SellerSense.Helper;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Views.Products
{
    public partial class PrestaShopSync :  SfForm
    {
        public string SiteURL { get; set; }
        public string SiteAccessKey { get; set; }

        public PrestaShopSync()
        {
            InitializeComponent();
            this.Style.TitleBar.ForeColor = Color.White;
            this.Style.TitleBar.BackColor = Constants.Theme.BorderColor;
            this.Style.Border.Color = Constants.Theme.BorderColor;
            this.Style.InactiveBorder.Color = Constants.Theme.BorderColor;
            this.Style.Border.Width = Constants.Theme.BorderWidth;
            this.Style.InactiveBorder.Width = Constants.Theme.BorderWidth;

            textBox_URL.Enabled = false;
            textBox_Key.Enabled = false;
            textBox_URL.Text = ProjIO.GetUserSetting(Constants.PrestasopSiteURL);
            SiteURL = textBox_URL.Text;
            textBox_Key.Text = ProjIO.GetUserSetting(Constants.PrestasopSiteAccessKey);
            SiteAccessKey = textBox_Key.Text;
        }
    }
}
