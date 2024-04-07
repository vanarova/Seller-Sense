using SellerSense.ViewManager;
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
    public partial class PaymentsView : UserControl
    {
        private VM_Company _company { get; set; }

        public PaymentsView(VM_Company company)
        {
            InitializeComponent();
            _company = company;
        }

        private void button_FkHelp_Click(object sender, EventArgs e)
        {
            (new Docs.Help(Docs.Constants.HelpTopic.FkPayment)).ShowDialog();
        }

        private void button_AmzHelp_Click(object sender, EventArgs e)
        {
            (new Docs.Help(Docs.Constants.HelpTopic.AnzPayment)).ShowDialog();
        }

        private void button_SpdHelp_Click(object sender, EventArgs e)
        {
            (new Docs.Help(Docs.Constants.HelpTopic.SpdPayment)).ShowDialog();
        }
    }
}
