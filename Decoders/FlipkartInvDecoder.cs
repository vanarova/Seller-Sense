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
        private static List<IFkInventory> _invFlipkart;
        private static string _invFlipkartFileName;
        private static IEnumerable<FkInv> _invFlipkartUnModified;

        public static void OpenProductSearchURL(string productId)
        {
            System.Diagnostics.Process.Start("https://www.flipkart.com/na/p/na?pid=" + productId);
        }

        public static string GetProductIdFromURL(string url)
        {
            Uri myUri = new Uri(url);
            return HttpUtility.ParseQueryString(myUri.Query).Get("pid");
        }

        public static List<IFkInventory> GetData(string excelFile)
        {
            if (_invFlipkart == null)
            {
                _invFlipkartFileName = excelFile;
                _exm = new ExcelMapper(excelFile) { HeaderRow=true};
                _invFlipkartUnModified = _exm.Fetch<FkInv>();
                
                //var otems = new ExcelMapper(excelFile) { HeaderRow = false }.Fetch<FkInv>();
                _invFlipkart = _invFlipkartUnModified.ToList<IFkInventory>();

                _invFlipkart.RemoveAt(0); //remove first 2 rows, headers
                return _invFlipkart;
            }else return _invFlipkart;
        }

        public static void SaveAllData(IList<IFkInventory> UIModifiedInvList, string dirPath)
        {
            string fileName = "";
            if (_invFlipkartUnModified != null && _invFlipkartUnModified.Count() > 0)
            {
                List<FkInv> fkInvs = new List<FkInv>();
                foreach (IFkInventory item in _invFlipkartUnModified)
                    fkInvs.Add(item as FkInv);

                foreach (var pristineInvItem in fkInvs)
                {
                    foreach (var modifiedInvItem in UIModifiedInvList)
                    {
                        if (pristineInvItem.fsn == modifiedInvItem.fsn)
                            pristineInvItem.sellerQuantity = modifiedInvItem.sellerQuantity;
                    }
                }
                fileName = Path.Combine(dirPath, "Modified_"+ Path.GetFileName(_invFlipkartFileName));
               
                _exm.Save<FkInv>(fileName, fkInvs, 0, true);
            }
        }

    
    }


    //This class is mapped to flipkart inventory report.
    class FkInv : IFkInventory
    {
        [Column(1)]
        public string name { get; set; }
        [Column(5)]
        public string fsn { get; set; }
        [Column(10)]
        public string price { get; set; }
        [Column(14)]
        public string systemQuantity { get; set; }
        [Column(15)]
        public string sellerQuantity { get; set; }
    }


}
