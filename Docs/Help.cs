
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Docs
{
    public partial class Help : SfForm
    {
        public Help(Constants.HelpTopic helpTopic)
        {
            InitializeComponent();
            this.Style.TitleBar.ForeColor = Color.White;
            this.Style.TitleBar.BackColor = Constants.Theme.BorderColor;
            this.Style.Border.Color = Constants.Theme.BorderColor;
            this.Style.InactiveBorder.Color = Constants.Theme.BorderColor;
            this.Style.Border.Width = Constants.Theme.BorderWidth;
            this.Style.InactiveBorder.Width = Constants.Theme.BorderWidth;
            this.tabControlAdv1.ActiveTabColor = Constants.Theme.BorderColor;
            this.tabControlAdv1.ActiveTabForeColor = Color.White;



            if (helpTopic == Constants.HelpTopic.Welcome)
                LoadWelcomeHelp();
            if (helpTopic == Constants.HelpTopic.FkPayment)
                LoadFkPaymentHelp();
            if (helpTopic == Constants.HelpTopic.AnzPayment)
                LoadAmzPaymentHelp();
            if (helpTopic == Constants.HelpTopic.SpdPayment)
                LoadSpdPaymentHelp();
            if (helpTopic == Constants.HelpTopic.Orders)
                LoadOrdersHelp();
        }

        private void LoadWelcomeHelp()
        {
            tabPageAdv1.Text = "Welcome";
            WebBrowser wb1 = new WebBrowser();
            tabPageAdv1.Controls.Add(wb1);
            wb1.Dock = DockStyle.Fill;
            
            var embed = "<html><head>" +
               "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
               "</head><body>" +
               "<iframe width=\"{1}\" height=\"{2}\" src=\"{0}\"" +
               "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
               "</body></html>";
            var url = "https://www.youtube.com/embed/L6ZgzJKfERM/controls=1&autohide=2";
            wb1.DocumentText = string.Format(embed, url,wb1.Width-40, wb1.Height-40);
        }

        private void LoadFkPaymentHelp()
        {
            tabControlAdv1.Font = new Font(new FontFamily("Segoe UI"), 9f);
         
            //step 1
            tabPageAdv1.Text = "Step 1";
            tabPageAdv1.Font = new Font(new FontFamily("Segoe UI"), 9f);
            LoadPicInTabPage(tabPageAdv1, @"Images\help\fk1.png");

            //step 2
            Syncfusion.Windows.Forms.Tools.TabPageAdv page = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            tabControlAdv1.TabPages.Add(page);
            page.Text = "Step 2";
            LoadPicInTabPage(page, @"Images\help\fk2.png");
        }


        private void LoadAmzPaymentHelp()
        {
            

            tabControlAdv1.Font = new Font(new FontFamily("Segoe UI"), 9f);

            //step 1
            tabPageAdv1.Text = "Step 1";
            tabPageAdv1.Font = new Font(new FontFamily("Segoe UI"), 9f);
            LoadPicInTabPage(tabPageAdv1, @"Images\help\AmzPay1.png");
        }

        private void LoadSpdPaymentHelp()
        {
            tabControlAdv1.Font = new Font(new FontFamily("Segoe UI"), 9f);

            //step 1
            tabPageAdv1.Text = "Step 1";
            tabPageAdv1.Font = new Font(new FontFamily("Segoe UI"), 9f);
            LoadPicInTabPage(tabPageAdv1, @"Images\help\SpdPayment1.png");
        }

        private void OpenHelpPage(string id)
        {
            try {
                var p = System.IO.Path.GetFullPath(Assembly.GetExecutingAssembly().Location);
                System.IO.DirectoryInfo dinfo = new System.IO.DirectoryInfo(p);
                string installation_dir = dinfo.FullName;
                string helpHtml = System.IO.Path.Combine(installation_dir, "SellerSenseHelp.html");
                Process.Start("explorer.exe", helpHtml + id);
            }
            catch { MessageBox.Show("Error opening help page."); }
        }

        private void LoadOrdersHelp()
        {
            OpenHelpPage("?#AmzOrders");
            label1.Text = "Help topics:";
            tabControlAdv1.Font = new Font(new FontFamily("Segoe UI"), 9f);

            // 1
            tabPageAdv1.Text = "Load Amazon Orders";
            tabPageAdv1.Font = new Font(new FontFamily("Segoe UI"), 9f);
            LoadPicInTabPage(tabPageAdv1, @"Images\help\AmzOrders.png");


            // 2
            Syncfusion.Windows.Forms.Tools.TabPageAdv page = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            tabControlAdv1.TabPages.Add(page);
            page.Text = "Load Flipkart Orders";
            LoadPicInTabPage(page, @"Images\help\FkOrders1.png");


            // 3
            Syncfusion.Windows.Forms.Tools.TabPageAdv page3 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            tabControlAdv1.TabPages.Add(page3);
            page3.Text = "Load Snapdeal Orders";
            LoadPicInTabPage(page3, @"Images\help\SpdOrders.png");
        }





        private void LoadPicInTabPage(Syncfusion.Windows.Forms.Tools.TabPageAdv page, string src)
        {
            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Dock = DockStyle.Fill;
            pic.Image = Image.FromFile(src);
            page.Controls.Add(pic);
        }

        private void sfButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
