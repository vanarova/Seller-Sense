using Decoders.Interfaces;
using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders
{
    public static class InvoiceDecoder
    {
        private static ExcelMapper _exm;
        public static void SaveAllData(IList<IInvoiceData> invoiceList, IInvoiceClient clientDetails, string dirPath)
        {
            string fileName = "";
            if (invoiceList != null && invoiceList.Count > 0)
            {
                List<InvoiceData> invoiceSheet = new List<InvoiceData>();
                foreach (IInvoiceData item in invoiceList)
                {
                    var t = new InvoiceData();
                    t.ItemName = item.ItemName;


                    t.Name = clientDetails.Name;
                    //fill all
                }

                
                //invoiceSheet.Add(item as InvoiceData);
                fileName = Path.Combine(dirPath, "Invoice_" + DateTime.Now.ToFileTimeUtc());

                _exm.Save<InvoiceData>(fileName, invoiceSheet, 0, true);
            }
        }
    }

    class InvoiceData : IInvoiceData, IInvoiceClient
    {
        [Column(1)]
        public string Name { get; set; }
        [Column(2)]
        public string Address { get; set; }
        [Column(3)]
        public string TaxNo { get; set; }

        [Column(4)]
        public string Count { get; set; }
        [Column(5)]
        public string ItemName { get; set; }
        [Column(6)]
        public string ItemQty { get; set; }
        [Column(7)]
        public string ItemPrice { get; set; }
        
    }
}
