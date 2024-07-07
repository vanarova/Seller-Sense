using Decoders.Interfaces;
using Decoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellerSense.Helper;

namespace SellerSense.Model.Orders
{
    public class M_Orders
    {

        internal List<IAmzOrders> _amzOrders { get; set; }
        internal List<IFkOrders> _fkOrders { get; set; }
        internal List<ISpdOrders> _spdOrders { get; set; }
        private string _companyCode;

        public M_Orders(string companyCode)
        {
            _companyCode = companyCode;
            _amzOrders = new List<IAmzOrders>();
        }

        public Task GetAmzOrders(string fileName)
        {
            return Task.Run(() =>
            {
                IList<IAmzOrders> amzOrdersIList = AmazonOrdersDecoder.ImportAmazonOrders(fileName);
                //List<IAmzPayments> _amzPayments = new List<IAmzPayments>();
                _amzOrders = amzOrdersIList.ToList<IAmzOrders>();
            });
        }

        public async Task GetAmazonOrderOnlineVia_API(string days)
        {
            //var result = await AmazonSPAPI.CreateReport_GET_MERCHANT_LISTINGS_ALL_DATA();
            var result = await AmazonSPAPI.CreateReport_ORDERS(days);
            IList<IAmzOrders> amzOrdersIList = AmazonOrdersDecoder.ImportAmazonOrdersFromAPI(result);
            _amzOrders = amzOrdersIList.ToList<IAmzOrders>();
            //Debugger.Log(0,"",result);

        }


        public Task GetFkOrders(string fileName)
        {
            return Task.Run(() =>
            {
                IList<IFkOrders> fkOrdersIList = FlipkartOrdersDecoder.ImportFlipkartOrders(fileName);
                _fkOrders = fkOrdersIList.ToList();
            });
        }

        public Task GetSpdOrders(string fileName)
        {
            return Task.Run(() =>
            {
                IList<ISpdOrders> spdOrdersIList = SnapdealOrdersDecoder.ImportSnapdealOrders(fileName);
                _spdOrders = spdOrdersIList.ToList();
            });
        }

        //internal Task GetFkPayments(string fileName)
        //{
        //    return Task.Run(() =>
        //    {
        //        IList<IFkPayments> fkPaymentsIList = FlipkartPaymentsDecoder.GetPayments(fileName, out string error);
        //        if (!string.IsNullOrEmpty(error))
        //            Logger.Log(error, Logger.LogLevel.error, false);
        //        _fkPayments = fkPaymentsIList.ToList<IFkPayments>();
        //    });
        //}

        //internal Task GetSpdPayments(string fileName)
        //{
        //    return Task.Run(() =>
        //    {
        //        IList<ISpdPayments> spdPaymentsIList = SnapdealPaymentsDecoder.GetPayments(fileName, out string error);
        //        if (!string.IsNullOrEmpty(error))
        //            Logger.Log(error, Logger.LogLevel.error, false);
        //        _spdPayments = spdPaymentsIList.ToList<ISpdPayments>();
        //    });
        //}

    }
}
