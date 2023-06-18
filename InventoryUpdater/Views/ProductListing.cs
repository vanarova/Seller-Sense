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
    internal partial class ProjectListing : Form
    {
        private ViewModelManager.VM_Companies _companiesMgr;

        private List<InvUpdateCntrl> _invUpdateCntrlList;


        public ProjectListing(ViewModelManager.VM_Companies companies)
        {
            InitializeComponent();
            _companiesMgr = companies;
            CreateTabControls();
        }


        private void CreateTabControls()
        {
            tabControl1.TabPages.Clear(); int i = 0;
            _invUpdateCntrlList = new List<InvUpdateCntrl>();

            foreach (var company in _companiesMgr._companies)
            {
                if (company != null)
                {
                    tabControl1.TabPages.Add(company._name);
                    _invUpdateCntrlList.Add(new InvUpdateCntrl(company));
                    _invUpdateCntrlList[i].Dock = DockStyle.Fill;
                    tabControl1.TabPages[i].Controls.Add(_invUpdateCntrlList[i]);
                    i++;
                }
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
