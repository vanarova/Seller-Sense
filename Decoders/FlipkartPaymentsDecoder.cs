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
    public static class FlipkartPaymentsDecoder
    {
        private static ExcelMapper _exm;
        private static string _invFlipkartFileName;
        private static IEnumerable<IFkPayments> _paymentFlipkart;

        
       

        public static List<IFkPayments> GetPayments(string excelFile, out string error)
        {

            error = string.Empty; List<IFkPayments> _pmtFlipkart;
            _invFlipkartFileName = excelFile;
            try
            {
                _exm = new ExcelMapper(excelFile) { HeaderRowNumber=1, MinRowNumber =3};
                _paymentFlipkart = _exm.Fetch<FkPayments>("Orders");
            }
            catch (Exception e) { error = e.Message; return new List<IFkPayments>(); }
           
            _pmtFlipkart = _paymentFlipkart.ToList<IFkPayments>();
            //_pmtFlipkart.RemoveAt(0); //remove first 2 rows, headers
            return _pmtFlipkart;
        }
    
    }

   

    class FkPayments : IFkPayments
    {

        [Column("Order ID")]
        public string orderId {get; set; }
        [Column("Order item ID")]
        public string orderItemId {get; set; }
        [Column("Seller SKU")]
        public string sku { get; set; }
        [Column(4)]         //[Column("Bank Settlement Value (Rs.) = SUM(I:Q)")] //Header is having complex values, not reading..due to \n in header
        public string bankSettlementValue { get; set; }
        [Column(63)]         //[Column("Input GST + TCS Credits (Rs.)\n[GST + TCS]")]
        public string return_type { get; set; }
        [Column(6)]
        public string tds { get; set; }
        [Column(10)]
        public string saleAmount { get; set; }
        [Column(11)]
        public string totalOfferAmt { get; set; }
        [Column(12)]
        public string myShare { get; set; }
        [Column(13)]
        public string customerAddonAmt { get; set; }
        [Column(14)] //[Column("Marketplace Fee (Rs.)")]
        public string marketplaceFee { get; set; }
        [Column(56)]
        public string orderDate { get; set; }
        [Column(15)]
        public string taxes { get; set; }
        [Column(60)]
        public string quantity { get; set; }


        //[Column("")]
        //public string commisionRate {get; set; }
        //[Column("")]
        //public string commisionFee {get; set; }
        //[Column("")]
        //public string fixedFee {get; set; }
        //[Column("")]
        //public string collectionFee {get; set; }
        //[Column("")]
        //public string pickAndPackFee {get; set; }
        //[Column("")]
        //public string shipmentFee {get; set; }
        //[Column("")]
        //public string reverseShipmentFee {get; set; }

    }





}
