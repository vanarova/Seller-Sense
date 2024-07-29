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
    public static class FlipkartInvDecoder
    {
        private static ExcelMapper _exm;
        //private static List<IFkInventoryV1> _invFlipkart;
        private static string _invFlipkartFileName;
        private static IEnumerable<FkInvV1> _invFlipkartUnModifiedV1;
        private static IEnumerable<FkInvV2> _invFlipkartUnModifiedV2;

        public static void OpenProductSearchURL(string productId)
        {
            System.Diagnostics.Process.Start("https://www.flipkart.com/na/p/na?pid=" + productId);
        }

        public static string GetProductIdFromURL(string url)
        {
            if(string.IsNullOrEmpty(url))
                return default(string);
            Uri myUri = new Uri(url);
            return HttpUtility.ParseQueryString(myUri.Query).Get("pid");
        }

        public static List<IFkInventoryV2> GetDataV2(string excelFile, out string error)
        {

            error = string.Empty; List<IFkInventoryV2> _invFlipkart;
            _invFlipkartFileName = excelFile;
            try
            {
                _exm = new ExcelMapper(excelFile) { HeaderRow = true };
            }
            catch (Exception e) { error = e.Message; return new List<IFkInventoryV2>(); }
            _invFlipkartUnModifiedV2 = _exm.Fetch<FkInvV2>();
            _invFlipkart = _invFlipkartUnModifiedV2.ToList<IFkInventoryV2>();
            _invFlipkart.RemoveAt(0); //remove first 2 rows, headers
            return _invFlipkart;
        }

        public static List<IFkInventoryV1> GetDataV1(string excelFile, out string error)
        {
            error = string.Empty; List<IFkInventoryV1> _invFlipkart;
            _invFlipkartFileName = excelFile;
            try
            {
                _exm = new ExcelMapper(excelFile) { HeaderRow = true };
            }
            catch (Exception e) { error = e.Message; return new List<IFkInventoryV1>(); }
            _invFlipkartUnModifiedV1 = _exm.Fetch<FkInvV1>();
            _invFlipkart = _invFlipkartUnModifiedV1.ToList<IFkInventoryV1>();
            _invFlipkart.RemoveAt(0); //remove first 2 rows, headers
            return _invFlipkart;
        }



        public static void SaveAllData(IList<IFkInventoryV2> UIModifiedInvList, string dirPath)
        {
            string fileName = "";
            if (_invFlipkartUnModifiedV2 != null && _invFlipkartUnModifiedV2.Count() > 0)
            {
                List<FkInvV2> fkInvs = new List<FkInvV2>();
                foreach (IFkInventoryV2 item in _invFlipkartUnModifiedV2)
                    fkInvs.Add(item as FkInvV2);

                foreach (var pristineInvItem in fkInvs)
                {
                    foreach (var modifiedInvItem in UIModifiedInvList)
                    {
                        if (pristineInvItem.fsn == modifiedInvItem.fsn)
                            pristineInvItem.sellerQuantity = modifiedInvItem.sellerQuantity;
                    }
                }
                fileName = Path.Combine(dirPath, "Modified_" + Path.GetFileName(_invFlipkartFileName));

                _exm.Save<FkInvV2>(fileName, fkInvs, 0, true);
            }
        }



        public static void SaveAllData(IList<IFkInventoryV1> UIModifiedInvList, string dirPath)
        {
            string fileName = "";
            if (_invFlipkartUnModifiedV1 != null && _invFlipkartUnModifiedV1.Count() > 0)
            {
                List<FkInvV1> fkInvs = new List<FkInvV1>();
                foreach (IFkInventoryV1 item in _invFlipkartUnModifiedV1)
                    fkInvs.Add(item as FkInvV1);

                foreach (var pristineInvItem in fkInvs)
                {
                    foreach (var modifiedInvItem in UIModifiedInvList)
                    {
                        if (pristineInvItem.fsn == modifiedInvItem.fsn)
                            pristineInvItem.sellerQuantity = modifiedInvItem.sellerQuantity;
                    }
                }
                fileName = Path.Combine(dirPath, "Modified_"+ Path.GetFileName(_invFlipkartFileName));
               
                _exm.Save<FkInvV1>(fileName, fkInvs, 0, true);
            }
        }

    
    }


    //This class is mapped to flipkart inventory report.
    class FkInvV1 : IFkInventoryV1
    {
        [Column(2)]
        public string sku { get; set; }
        [Column(5)]
        public string fsn { get; set; }
        [Column(11)]
        public string price { get; set; }
        [Column(15)]
        public string systemQuantity { get; set; }
        [Column(16)]
        public string sellerQuantity { get; set; }
    }

    class FkInvV2 : IFkInventoryV2
    {
        [Column("Seller SKU Id")]
        public string sku { get; set; }
        [Column("Flipkart Serial Number")]
        public string fsn { get; set; }
        [Column("Your Selling Price")]
        public string price { get; set; }
        [Column("System Stock count")]
        public string systemQuantity { get; set; }
        [Column("Your Stock Count")]
        public string sellerQuantity { get; set; }
    }





}
