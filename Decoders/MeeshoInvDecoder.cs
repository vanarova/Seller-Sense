using Decoders.Interfaces;
using Ganss.Excel;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders
{
    public static class MeeshoInvDecoder
    {
        private static ExcelMapper _exm;
        private static string _invMeeshoFileName;
        private static IEnumerable<MsoInv> _invMeeshoUnModified;
        private static List<IMsoInventory> _invMeesho;


        public static void OpenProductSearchURL(string productId)
        {
            System.Diagnostics.Process.Start("https://www.meesho.com/na/p/" + productId);
        }

        public static List<IMsoInventory> GetData(string excelFile)
        {
            if (_invMeesho == null || _invMeesho.Count == 0)
            {
                _invMeeshoFileName = excelFile;
                _exm = new ExcelMapper(excelFile) { HeaderRow = true };
                _invMeeshoUnModified = _exm.Fetch<MsoInv>();

                //var otems = new ExcelMapper(excelFile) { HeaderRow = false }.Fetch<FkInv>();
                _invMeesho = _invMeeshoUnModified.ToList<IMsoInventory>();
                _invMeesho.RemoveAt(0);

                //List<FkInv> fkInvs = otems.ToList();
                //fkInvs.ForEach(x => x.quantity = "10");
                //exm.Save<FkInv>("fk_modified", fkInvs, 0, true);

                //_invSnapdeal.RemoveAt(0); //remove first 2 rows, headers
                //_invFlipkart.RemoveAt(1);
                //_invFlipkart.RemoveAt(2);
                return _invMeesho;
            }
            else return _invMeesho;
        }


        public static void SaveAllData(IList<IMsoInventory> UIModifiedInvList, string dirPath)
        {
            string fileName = "";
            if (_invMeeshoUnModified != null && _invMeeshoUnModified.Count() > 0)
            {
                List<MsoInv> msoInvs = new List<MsoInv>();
                foreach (IMsoInventory item in _invMeeshoUnModified)
                    msoInvs.Add(item as MsoInv);

                foreach (var pristineInvItem in msoInvs)
                {
                    foreach (var modifiedInvItem in UIModifiedInvList)
                    {
                        if (pristineInvItem.fsn == modifiedInvItem.fsn)
                            pristineInvItem.sellerQuantity = modifiedInvItem.sellerQuantity;
                    }
                }
                fileName = Path.Combine(dirPath, "Modified_" + Path.GetFileName(_invMeeshoFileName));

                _exm.Save<MsoInv>(fileName, msoInvs, 0, true);
            }
        }



    }


    class MsoInv : IMsoInventory
    {
        [Column(4)]
        public string sku { get; set; }
        [Column(6)]
        public string fsn { get; set; }
        [Column(0)]
        public string price { get; set; }
        [Column(10)]
        public string systemQuantity { get; set; }
        [Column(11)]
        public string sellerQuantity { get; set; }
    }


}
