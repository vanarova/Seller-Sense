using Decoders.Interfaces;
using Ganss.Excel;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Decoders
{
    public static class SnapdealPaymentsDecoder
    {
        private static ExcelMapper _exm;
        private static string _snapdealFileName;
        private static IEnumerable<ISpdPayments> _paymentSnapdeal;

        
       

        public static List<ISpdPayments> GetPayments(string excelFile, out string error)
        {

            error = string.Empty; List<ISpdPayments> _pmtFlipkart;
            _snapdealFileName = excelFile;
            try
            {
                _exm = new ExcelMapper(excelFile) { HeaderRowNumber=2, MinRowNumber =3};
            }
            catch (Exception e) { error = e.Message; return new List<ISpdPayments>(); }
            _paymentSnapdeal = _exm.Fetch<SpdPayments>("Transactions Report");
            _pmtFlipkart = _paymentSnapdeal.ToList<ISpdPayments>();
            //_pmtFlipkart.RemoveAt(0); //remove first 2 rows, headers
            return _pmtFlipkart;
        }
    
    }



    class SpdPayments : ISpdPayments
    {

        //[Column("Order ID")]
        //public string orderId {get; set; }
        //[Column("Order item ID")]
        //public string orderItemId {get; set; }
        //[Column("Seller SKU")]
        //public string sku { get; set; }
        //[Column(3)]         //[Column("Bank Settlement Value (Rs.) = SUM(I:Q)")] //Header is having complex values, not reading..due to \n in header
        //public string bankSettlementValue { get; set; }
        //[Column(4)]         //[Column("Input GST + TCS Credits (Rs.)\n[GST + TCS]")]
        //public string gst_tcs_Credits { get; set; }
        //[Column(5)]
        //public string tds { get; set; }
        //[Column(9)]
        //public string saleAmount { get; set; }
        //[Column(10)]
        //public string totalOfferAmt { get; set; }
        //[Column("My share (Rs.)")]
        //public string myShare { get; set; }
        //[Column("Customer Add-ons Amount (Rs.)")]
        //public string customerAddonAmt { get; set; }
        //[Column(13)] //[Column("Marketplace Fee (Rs.)")]
        //public string marketplaceFee { get; set; }
        //[Column("Taxes (Rs.)")]
        //public string taxes { get; set; }

        
        [Column("Transaction Date")]
        public string transactionDate { get; set; }
        [Column("Type")]
        public string type { get; set; }
        [Column("Transaction ID")]
        public string transactionId { get; set; }
        [Column("SKU")]
        public string sku { get; set; }
        [Column("Invoice Number")]
        public string invoiceNumber { get; set; }
        [Column("Web Sale Price")]
        public string webSalePrice { get; set; }
        [Column("Payment Received By Snapdeal")]
        public string paymentReceicedBySpd { get; set; }
        [Column("Commission")]
        public string commission { get; set; }
        [Column("NetPayable")]
        public string netPayable { get; set; }
    }





}
