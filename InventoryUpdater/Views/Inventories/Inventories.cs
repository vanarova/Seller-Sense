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

namespace SellerSense.Views.Inventories
{
    internal partial class Inventories : SfForm
    {

        private ViewManager.VM_Companies _companiesMgr;
        private List<InvCntrl> _invCntrlList;

        public Inventories(ViewManager.VM_Companies companies)
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
            _invCntrlList = new List<InvCntrl>();

            foreach (var company in _companiesMgr._companies)
            {
                if (company != null)
                {
                    tabControl1.TabPages.Add(company._name);
                    var icntrl = new InvCntrl(company);
                    company._inventoriesViewManager.AssignViewManager(icntrl);
                    _invCntrlList.Add(icntrl);
                    _invCntrlList[i].Dock = DockStyle.Fill;
                    tabControl1.TabPages[i].Controls.Add(_invCntrlList[i]);
                    i++;
                }
            }
        }
    }
}
