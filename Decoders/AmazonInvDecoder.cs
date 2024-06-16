using CommonUtil;
using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;


namespace Decoders
{
    public static class AmazonInvDecoder
    {
        private static ObservableCollection<IAmzInventory> _amvInventoryUnmodified;
        private static string _invAmazonFileName;
        private static string _invAmazonFileNameFromAPI;
        //private static ResourceManager resourceManager =
        //    new ResourceManager("Resources.Mappings", Assembly.Load("CommonUtil"));
        private static readonly string[] _colsToExport = {
            "sku",
            "price",
            "minimum-seller-allowed-price",
            "maximum-seller-allowed-price",
            "quantity", "leadtime-to-ship",
            "fulfillment-channel",
            "merchant_shipping_group_name"};

      

        public static void OpenProductSearchURL(string productId)
        {
            //System.Diagnostics.Process.Start("https://www.amazon.in/s?k=" + productId);
            System.Diagnostics.Process.Start("https://www.amazon.in/dp/" + productId);
        }

        public static string GetProductIdFromURL(string url)
        {
            string result = string.Empty;
            string pattern = @"dp\/([A-Z0-9]+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(url);
            if (match.Success)
                result = match.Groups[1].Value.Replace("dp/", "").Replace("/", "");
            return result;
        }

        //public static ObservableCollection<IAmzInventory> ImportAmazonInventory(string fileName)
        //{
        //    //var s = resourceManager.GetString("amazon_inv_asin");
        //   // if (_amvInventoryUnmodified == null || _amvInventoryUnmodified.Count==0)
        //   //  {
        //        _invAmazonFileName = fileName;
        //        _amvInventoryUnmodified = new ObservableCollection<IAmzInventory>();
        //        var lines = File.ReadAllLines(fileName);
        //        for (var i = 0; i < lines.Length; i += 1)
        //        {
        //            var line = lines[i].Split('\t');
        //            _amvInventoryUnmodified.Add(new AmazonInventory(line[0], line[1], line[2], line[3]));
        //        }
        //        _amvInventoryUnmodified.RemoveAt(0); // remove header
        //        return _amvInventoryUnmodified;
        //}



        public static ObservableCollection<IAmzInventory> ImportAmazonInventory(string fileName,
            string sku, string asin, string price, string sellerQuantity)
        {
            _invAmazonFileName = fileName;
            _amvInventoryUnmodified = new ObservableCollection<IAmzInventory>();
            var lines = File.ReadAllLines(fileName);
            for (var i = 0; i < lines.Length; i += 1)
            {
                var line = lines[i].Split('\t');
                _amvInventoryUnmodified.Add(new AmazonInventory(line[Convert.ToInt16(sku)], 
                    line[Convert.ToInt16(asin)], line[Convert.ToInt16(price)], line[Convert.ToInt16(sellerQuantity)]));
            }
            _amvInventoryUnmodified.RemoveAt(0); // remove header
            return _amvInventoryUnmodified;
        }


        //public static ObservableCollection<IAmzInventory> TransformAndImportAmazonInvFromAPI(string src_fileName,
        //    string sku, string asin, string price, string sellerQuantity)
        //{
        //    _invAmazonFileNameFromAPI = src_fileName;
        //    _amvInventoryUnmodified = new ObservableCollection<IAmzInventory>();
        //    var lines = File.ReadAllLines(src_fileName);
            
        //    for (var i = 0; i < lines.Length; i += 1)
        //    {
        //        var line = lines[i].Split('\t');
        //        _amvInventoryUnmodified.Add(new AmazonInventory(line[Convert.ToInt16(sku)],
        //            line[Convert.ToInt16(asin)], line[Convert.ToInt16(price)], line[Convert.ToInt16(sellerQuantity)]));
        //    }
        //    _amvInventoryUnmodified.RemoveAt(0); // remove header
        //    return _amvInventoryUnmodified;
        //}

        public static void SaveAllData(IList<IAmzInventory> UIModifiedInvList, string dirPath)
        {
            string fileName = string.Empty;
            string colHeaders = string.Empty;
            
            if (_amvInventoryUnmodified != null && _amvInventoryUnmodified.Count() > 0)
            {
                fileName = Path.Combine(dirPath, "Modified_" + Path.GetFileName(_invAmazonFileName));
                using (StreamWriter fw = new StreamWriter(fileName))
                {
                    //header
                    foreach (var item in _colsToExport)
                    {
                        if (string.IsNullOrEmpty(colHeaders))
                            colHeaders = item;
                        else
                            colHeaders = colHeaders + "\t" + item;
                    }
                    fw.WriteLine(colHeaders.ToString());
                    foreach (var item in UIModifiedInvList)
                    {
                        string row = item.sku + "\t" + item.price + "\t" + "\t" + "\t" + item.sellerQuantity;
                        fw.WriteLine(row.ToString());
                    }
                }
                //List<FkInv> fkInvs = new List<FkInv>();
                //foreach (IFkInventory item in _invFlipkartUnModified)
                //    fkInvs.Add(item as FkInv);

                //foreach (var pristineInvItem in fkInvs)
                //{
                //    foreach (var modifiedInvItem in UIModifiedInvList)
                //    {
                //        if (pristineInvItem.fsn == modifiedInvItem.fsn)
                //            pristineInvItem.sellerQuantity = modifiedInvItem.sellerQuantity;
                //    }
                //}
                

                //_exm.Save<FkInv>(fileName, fkInvs, 0, true);
            }
        }


    }


    class AmazonInventory : IAmzInventory
    {
        public string sku { get; set; }
        public string asin { get; set; }
        public string price { get; set; }
        public string sellerQuantity { get; set; }
        //public string sellerQuantity { get; set; }
        public string systemQuantity { get; set; }

        public AmazonInventory(string sku, string asin, string price, string quantity)
        {
            this.sku = sku;
            this.asin = asin;
            this.price = price;
            this.systemQuantity = quantity;
        }

        public AmazonInventory(string sku, string asin, string price, string quantity, string sellerQuantity)
        {
            this.sku = sku;
            this.asin = asin;
            this.price = price;
            this.sellerQuantity = quantity;
            //this.sellerQuantity = sellerQuantity;
            this.systemQuantity = sellerQuantity;
        }
    }

}
