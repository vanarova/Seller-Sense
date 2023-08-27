using Microsoft.WindowsAPICodePack.Dialogs;
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
    internal partial class ProductListing : Form
    {
        private ViewManager.VM_Companies _companiesMgr;

        private List<ProductCntrl> _productCntrlList;


        public ProductListing(ViewManager.VM_Companies companies)
        {
            InitializeComponent();
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
                    company._productsViewManager.AssignViewAManager(pcntrl);
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
