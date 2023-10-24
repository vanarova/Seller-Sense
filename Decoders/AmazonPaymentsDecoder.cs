using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders
{
    public class AmazonPaymentsDecoder
    {

        private static ObservableCollection<IAmzPayments> _amvPaymentsUnmodified;
        private static string _paymentsAmazonFileName;
        private static readonly string[] _colsToExport = {
            "order-id",
            "shipment-id",
            "amount-type",
            "amount-description",
            "amount",
            "posted-date-time",
            "order-item-code",
            "sku",
            "quantity-purchased"};



        public static ObservableCollection<IAmzPayments> ImportAmazonPayments(string fileName)
        {
            _paymentsAmazonFileName = fileName;
            _amvPaymentsUnmodified = new ObservableCollection<IAmzPayments>();
            var lines = File.ReadAllLines(fileName);
            for (var i = 0; i < lines.Length; i += 1)
            {
                var line = lines[i].Split('\t');
                _amvPaymentsUnmodified.Add(new AmazonPayments(line[0], line[3], line[5], 
                    line[6], line[7], line[10], line[11], line[14], line[15]));
            }
            _amvPaymentsUnmodified.RemoveAt(0); // remove header
            _amvPaymentsUnmodified.RemoveAt(1); // remove second row, contains total payment received etc
            return _amvPaymentsUnmodified;
        }


        class AmazonPayments : IAmzPayments
        {

            public string orderId { get; set; }
            public string shipmentId { get; set; }
            public string amountType { get; set; }
            public string amountDesc { get; set; }
            public string amount { get; set; }
            public string postedDateTime { get; set; }
            public string orderItemCode { get; set; }
            public string sku { get; set; }
            public string quantityPurchased { get; set; }

            public AmazonPayments(string orderId, string shipmentId, string amountType, 
                string amountDesc, string amount, string postedDateTime, string orderItemCode, 
                string sku, string quantityPurchased)
            {
                this.orderId = orderId;
                this.shipmentId = shipmentId;
                this.amountType = amountType;
                this.amountDesc = amountDesc;
                this.amount = amount;
                this.postedDateTime = postedDateTime;
                this.orderItemCode = orderItemCode;
                this.sku = sku;
                this.quantityPurchased = quantityPurchased;
            }



            //public string sku { get; set; }
            //public string asin { get; set; }
            //public string price { get; set; }
            //public string sellerQuantity { get; set; }
            ////public string sellerQuantity { get; set; }
            //public string systemQuantity { get; set; }

            //public AmazonInventory(string sku, string asin, string price, string quantity)
            //{
            //    this.sku = sku;
            //    this.asin = asin;
            //    this.price = price;
            //    this.systemQuantity = quantity;
            //}

            //public AmazonInventory(string sku, string asin, string price, string quantity, string sellerQuantity)
            //{
            //    this.sku = sku;
            //    this.asin = asin;
            //    this.price = price;
            //    this.sellerQuantity = quantity;
            //    //this.sellerQuantity = sellerQuantity;
            //    this.systemQuantity = sellerQuantity;
            //}

        }

    }
}
