﻿using Decoders.Interfaces;
using Ganss.Excel;
using HtmlAgilityPack;
using NPOI.SS.Formula.Functions;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Decoders
{
    public static class SnapdealInvDecoder
    {
        private static ExcelMapper _exm;
        private static List<ISpdInventory> _invSnapdeal;
        private static string _invSnapdealFileName;
        private static IEnumerable<SkInv> _invSnapdealUnModified;


        public static void OpenProductSearchURL(string productId)
        {
            System.Diagnostics.Process.Start("https://www.snapdeal.com/search?keyword=" + productId);
        }

        public static string GetProductIdFromURL(string url)
        {
            if (string.IsNullOrEmpty(url))
                return default(string);
            string result = string.Empty;
            HtmlWeb web = new HtmlWeb();

            HtmlAgilityPack.HtmlDocument page = web.Load(url);
            HtmlNodeCollection nodes = page.DocumentNode.SelectNodes("//li[@id='highlightSupc']/span[@class='h-content']");
            if (nodes != null && nodes.Count > 0) 
                result = nodes[0].InnerText.Replace("SUPC:", "").Trim();
            
            return result;
        }


        public static  Task<string> GetProductIdFromURLAsync(string url)
        {
          return  Task<string>.Run(() => {
                if (string.IsNullOrEmpty(url))
                    return default(string);
                string result = string.Empty;
                HtmlWeb web = new HtmlWeb();

                HtmlAgilityPack.HtmlDocument page = web.Load(url);
                HtmlNodeCollection nodes = page.DocumentNode.SelectNodes("//li[@id='highlightSupc']/span[@class='h-content']");
                if (nodes != null && nodes.Count > 0)
                    result = nodes[0].InnerText.Replace("SUPC:", "").Trim();
                
                return result;
            });
            
        }

        public static List<ISpdInventory> GetData(string excelFile)
        {
            //if (_invSnapdeal == null || _invSnapdeal.Count == 0)
            //{
                _invSnapdealFileName = excelFile;
                _exm = new ExcelMapper(excelFile) { HeaderRow = true };
                _invSnapdealUnModified = _exm.Fetch<SkInv>();

                //var otems = new ExcelMapper(excelFile) { HeaderRow = false }.Fetch<FkInv>();
                _invSnapdeal = _invSnapdealUnModified.ToList<ISpdInventory>();
                return _invSnapdeal;
           // }
            //else return _invSnapdeal;

        }

        public static void SaveAllData(IList<ISpdInventory> UIModifiedInvList, string dirPath)
        {
            string fileName = "";
            if (_invSnapdealUnModified != null && _invSnapdealUnModified.Count() > 0)
            {
                List<SkInv> skInvs = new List<SkInv>();
                foreach (ISpdInventory item in _invSnapdealUnModified)
                    skInvs.Add(item as SkInv);

                foreach (var pristineInvItem in skInvs)
                {
                    foreach (var modifiedInvItem in UIModifiedInvList)
                    {
                        if (pristineInvItem.fsn == modifiedInvItem.fsn)
                            pristineInvItem.sellerQuantity = modifiedInvItem.sellerQuantity;
                    }
                }
                fileName = Path.Combine(dirPath, "Modified_" + Path.GetFileName(_invSnapdealFileName));

                _exm.Save<SkInv>(fileName, skInvs, 0, true);
            }
        }


        //This class is mapped to Snapdeal inventory report.
        class SkInv : ISpdInventory
        {
            const int nam = 2; //make a separate config file for mapping cols
            [Column(nam)]
            public string sku { get; set; }
            [Column(1)]
            public string fsn { get; set; }
            [Column(7)]
            public string price { get; set; }
            [Column(5)]
            public string systemQuantity { get; set; }
            [Column(6)]
            public string sellerQuantity { get; set; }
        }


    }
}
