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

namespace SellerSense.Views.Payments
{
    public partial class Payments : SfForm
    {
        private ViewManager.VM_Companies _companiesMgr;
        private List<PaymentsView> _paymentCntrlList;


        public Payments(ViewManager.VM_Companies companies)
        {
            InitializeComponent();
            this.Style.Border.Color = Color.DeepSkyBlue;
            this.Style.InactiveBorder.Color = Color.DeepSkyBlue;
            this.Style.Border.Width = 2;
            this.Style.InactiveBorder.Width = 2;
            _companiesMgr = companies;
            CreateTabControls();
        }



        private void CreateTabControls()
        {
            tabControl1.TabPages.Clear(); int i = 0;
            _paymentCntrlList = new List<PaymentsView>();

            foreach (var company in _companiesMgr._companies)
            {
                if (company != null)
                {
                    tabControl1.TabPages.Add(company._name);
                    var icntrl = new PaymentsView(company);
                    company._paymentsViewManager.AssignView(icntrl);
                    _paymentCntrlList.Add(icntrl);
                    _paymentCntrlList[i].Dock = DockStyle.Fill;
                    tabControl1.TabPages[i].Controls.Add(_paymentCntrlList[i]);
                    i++;
                }
            }
        }
    }
}
