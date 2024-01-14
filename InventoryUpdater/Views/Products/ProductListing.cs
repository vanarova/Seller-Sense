using Microsoft.WindowsAPICodePack.Dialogs;
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

namespace SellerSense
{
    internal partial class ProductListing : SfForm
    {
        private ViewManager.VM_Companies _companiesMgr;

        private List<ProductCntrl> _productCntrlList;


        public ProductListing(ViewManager.VM_Companies companies)
        {
            InitializeComponent();
            this.Style.TitleBar.ForeColor = Color.White;
            this.Style.TitleBar.BackColor = Constants.Theme.BorderColor;
            this.Style.Border.Color = Constants.Theme.BorderColor;
            this.Style.InactiveBorder.Color = Constants.Theme.BorderColor;
            this.Style.Border.Width = Constants.Theme.BorderWidth;
            this.Style.InactiveBorder.Width = Constants.Theme.BorderWidth;
            _companiesMgr = companies;
            CreateTabControls();
        }


        private void CreateTabControls()
        {
            tabControl1.TabPages.Clear(); int i = 0;
            _productCntrlList = new List<ProductCntrl>();

            foreach (var company in _companiesMgr._companies)
            {
                if (company != null)
                {
                    tabControl1.TabPages.Add(company._name);
                    var pcntrl = new ProductCntrl(company);
                    company._productsViewManager.AssignViewA(pcntrl);
                    _productCntrlList.Add(pcntrl);
                    _productCntrlList[i].Dock = DockStyle.Fill;
                    tabControl1.TabPages[i].Controls.Add(_productCntrlList[i]);
                    i++;
                }
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        

    }
}
