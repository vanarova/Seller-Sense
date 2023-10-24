using Decoders;
using SellerSense.Views.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.ViewManager
{
    internal class VM_Payments
    {
        private PaymentsView _v_PaymentsCntrl;
        internal void AssignViewManager(PaymentsView invUserControl)
        {
            _v_PaymentsCntrl = invUserControl;
            HandleProductControlEvents();
        }

        private void HandleProductControlEvents()
        {
            _v_PaymentsCntrl.button_Load_Amz_Payments.Click += (s, e) => {
                AmazonPaymentsDecoder.ImportAmazonPayments("");


            };
            _v_PaymentsCntrl.button_Load_Fkp_Payments.Click += (s, e) => { };
            _v_PaymentsCntrl.button_Load_Snp_Payments.Click += (s, e) => { };
            _v_PaymentsCntrl.button_Load_Meesho_Payments.Click += (s, e) => { };
        }
    }
}
