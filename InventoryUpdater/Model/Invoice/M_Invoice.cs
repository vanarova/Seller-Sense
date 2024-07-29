using Decoders;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model.Invoice
{
    public class M_Invoice
    {
        public Dictionary<string, string> LineQty = new Dictionary<string, string>();

        public string ShipTo { get; set; }
        public string BillTo { get; set; }
        public string InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public string Quotation { get; set; }
        public List<LineItem> LineItems { get; set; }
        //public string AdditionalItem { get; set; }
        //public string Qty { get; set; }
        //public string Price { get; set; }

        public string Comments { get; set; }
        public string RefNo { get; set; }

        public class LineItem
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Quantity { get; set; }
            public string Price { get; set; }
        }

        public M_Invoice()
        {
            LineItems = new List<LineItem>();   
        }

        public (string,string) WriteInvoiceToFile() {

            //InvoiceTemplateFile
            string tempInvoice = Path.Combine(Path.GetTempPath(), "Invoices");
            if (!Directory.Exists(tempInvoice)) Directory.CreateDirectory(tempInvoice);
            string tempInvFile = Path.Combine(tempInvoice, DateTime.Now.ToFileTimeUtc().ToString() + ".xls");
            if(LineQty.Count > 24)
                File.Copy(Path.Combine(CommonUtil.ProjIO.DefaultWorkspaceLocation(),CommonUtil.Constants.InvoiceTemplateFileXL), tempInvFile, true);
            else
                File.Copy(Path.Combine(CommonUtil.ProjIO.DefaultWorkspaceLocation(), CommonUtil.Constants.InvoiceTemplateFile), tempInvFile, true);

            int startLine = 16;
            foreach (var item in LineItems)
            {
                InvoiceDecoder.UpdateCell(tempInvFile, $"B{startLine}:B{startLine}", item.Code);
                InvoiceDecoder.UpdateCell(tempInvFile, $"C{startLine}:D{startLine}", item.Name);
                InvoiceDecoder.UpdateCell(tempInvFile, $"E{startLine}:E{startLine}", item.Quantity);
                InvoiceDecoder.UpdateCell(tempInvFile, $"G{startLine}:G{startLine}", Convert.ToInt16(item.Price));

                startLine++;
            }

            InvoiceDecoder.UpdateCell(tempInvFile, "B8:C12", BillTo);
            InvoiceDecoder.UpdateCell(tempInvFile, "D8:E12", ShipTo);
            InvoiceDecoder.UpdateCell(tempInvFile, "H10:H10", RefNo);
            InvoiceDecoder.UpdateCell(tempInvFile, "H9:H9", Date.ToShortDateString());
            InvoiceDecoder.UpdateCell(tempInvFile, "B43:E47", Comments);
            InvoiceDecoder.UpdateCell(tempInvFile, "H8:H8", InvoiceID);

            return (tempInvoice, tempInvFile);
            //InvoiceDecoder.UpdateCell("C:\\Users\\VarunBansal\\Downloads\\Test.xls", "A1:A1", "10");
            //InvoiceDecoder.UpdateCell("C:\\Users\\VarunBansal\\Downloads\\Test.xls", "D1:D1", 100);

        }
    }
}
