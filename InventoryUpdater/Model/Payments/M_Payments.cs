using Decoders;
using Decoders.Interfaces;
using SellerSense.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model.Payments
{

    internal class M_Payments
    {
        internal List<IAmzPayments> _amzPayments { get; set; }
        internal List<IFkPayments> _fkPayments { get; set; }
        internal List<ISpdPayments> _spdPayments { get; set; }
        private string _companyCode;

        public M_Payments(string companyCode)
        {
            _companyCode = companyCode;
            _amzPayments = new List<IAmzPayments>();
        }

        internal Task GetAmzPayments(string fileName)
        {
            return Task.Run(() =>
            {
                IList<IAmzPayments> amzPaymentsIList = AmazonPaymentsDecoder.ImportAmazonPayments(fileName);
            //List<IAmzPayments> _amzPayments = new List<IAmzPayments>();
            _amzPayments = amzPaymentsIList.ToList<IAmzPayments>();
            });
        }

        internal Task GetFkPayments(string fileName)
        {
            return Task.Run(() =>
            {
                IList<IFkPayments> fkPaymentsIList = FlipkartPaymentsDecoder.GetPayments(fileName, out string error);
            if(!string.IsNullOrEmpty(error))
                Logger.Log(error, Logger.LogLevel.error, false);
            _fkPayments = fkPaymentsIList.ToList<IFkPayments>();
            });
        }

        internal Task GetSpdPayments(string fileName)
        {
            return Task.Run(() =>
            {
                IList<ISpdPayments> spdPaymentsIList = SnapdealPaymentsDecoder.GetPayments(fileName, out string error);
                if (!string.IsNullOrEmpty(error))
                    Logger.Log(error, Logger.LogLevel.error, false);
                _spdPayments = spdPaymentsIList.ToList<ISpdPayments>();
            });
        }


        //internal class AmzPayments
        //{
        //   internal string OrderId { get; set; }
        //   internal string ShipmentId { get; set; }
        //   internal string AmountType { get; set; }
        //   internal string AmountDesc { get; set; }
        //   internal string Amount { get; set; }
        //   internal string PostedDateTime { get; set; }
        //   internal string OrderItemCode { get; set; }
        //   internal string Sku { get; set; }
        //    internal string QuantityPurchased { get; set; }
        //}

    }
}
