using Decoders.Interfaces;
using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
//using Microsoft.Office.Interop.Excel;
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

        public static string UpdateCell(string filePath,string cell, string value)
        {
            ///string filePath = @"C:\Users\VarunBansal\Downloads\Test.xls";
            // Connection string for Excel 97-2003 format (.xls)
            string connectionString = $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={filePath};Extended Properties=""Excel 8.0;HDR=NO;""";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string updateCommandText = $"UPDATE [Invoice${cell}] SET F1 = '{value}'";
                //string updateCommandText = $"UPDATE [Invoice$A1:A1] SET F1 = 'New Value'";
                using (OleDbCommand updateCommand = new OleDbCommand(updateCommandText, connection))
                    // Execute the update command
                    updateCommand.ExecuteNonQuery();
                return default;
            }
        }

        public static string UpdateCell(string filePath, string cell, float value)
        {
            ///string filePath = @"C:\Users\VarunBansal\Downloads\Test.xls";
            // Connection string for Excel 97-2003 format (.xls)
            string connectionString = $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={filePath};Extended Properties=""Excel 8.0;HDR=NO;""";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string updateCommandText = $"UPDATE [Invoice${cell}] SET F1 = {value}";
                //string updateCommandText = $"UPDATE [Invoice$A1:A1] SET F1 = 'New Value'";
                using (OleDbCommand updateCommand = new OleDbCommand(updateCommandText, connection))
                    // Execute the update command
                    updateCommand.ExecuteNonQuery();
                return default;
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
