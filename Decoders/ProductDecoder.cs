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
    public class ProductDecoder
    {

        private static ExcelMapper _exm;
        private static List<IProduct> prods;
        private static string validationErrors;
        //private enum RequiredFields { InHouseCode, Image, Title, MRP, SellingPrice, CostPrice, Weight };

        public static IList<IProduct> ImportProducts(string fileName, out string error, out string validationErrors)
        {
            IEnumerable<IProduct> iprods;
            error = string.Empty;
            try
            {
                _exm = new ExcelMapper(fileName);
                iprods = _exm.Fetch<Product>();
            }
            catch (Exception e) { error = e.Message; validationErrors = string.Empty;  return new List<IProduct>(); }

            prods = iprods.ToList<IProduct>();
            prods.RemoveAt(0); //remove 2nd header row.
            validationErrors = Validate();
            return prods;
        }

        private static string Validate()
        {
            StringBuilder errors = new StringBuilder();
            //Required fields check.
            foreach (var item in prods)
            {
                if (string.IsNullOrEmpty(item.InHouseCode)) errors.AppendLine("InHouseCode is empty, for one or more records");
                if (string.IsNullOrEmpty(item.Image)) errors.AppendLine("Image is empty, for one or more records");
                if (string.IsNullOrEmpty(item.Title)) errors.AppendLine("Title is empty, for one or more records");
                if (string.IsNullOrEmpty(item.MRP)) errors.AppendLine("MRP is empty, for one or more records");
                if (string.IsNullOrEmpty(item.SellingPrice)) errors.AppendLine("SellingPrice is empty, for one or more records");
                if (string.IsNullOrEmpty(item.CostPrice)) errors.AppendLine("CostPrice is empty, for one or more records");
                if (string.IsNullOrEmpty(item.Weight)) errors.AppendLine("Weight is empty, for one or more records");
                if (!File.Exists(item.Image)) errors.AppendLine("Primary image file path is invalid, for one or more records");
                if (!string.IsNullOrEmpty(item.ImageAlt1) && !File.Exists(item.ImageAlt1)) errors.AppendLine("ImageAlt1 file path is invalid, for one or more records");
                if (!string.IsNullOrEmpty(item.ImageAlt2) && !File.Exists(item.ImageAlt2)) errors.AppendLine("ImageAlt2 file path is invalid, for one or more records");
                if (!string.IsNullOrEmpty(item.ImageAlt3) && !File.Exists(item.ImageAlt3)) errors.AppendLine("ImageAlt3 file path is invalid, for one or more records");
            }

            return errors.ToString();
        }


        class Product : IProduct
        {
            public string InHouseCode { get; set; }
            public string Image { get; set; }
            public string ImageAlt1 { get; set; }
            public string ImageAlt2 { get; set; }
            public string ImageAlt3 { get; set; }
            public string Title { get; set; }
            public string Tag { get; set; }
            public string MRP { get; set; }
            public string SellingPrice { get; set; }
            public string CostPrice { get; set; }
            public string Weight { get; set; }
            public string WeightAfterPackaging { get; set; }
            public string DimensionsBeforePackaging { get; set; }
            public string DimensionsAfterPackaging { get; set; }
            public string Description { get; set; }
            public string AmazonCode { get; set; }
            public string AmazonSKU { get; set; }
            public string FlipkartCode { get; set; }
            public string FlipkartSKU  { get; set; }
            public string SnapdealCode { get; set; }
            public string SnapdealSKU  { get; set; }
            public string MeeshoCode { get; set; }
            public string Notes { get; set; }
            public string LinkedInHouseCode { get; set; }
            public string LinkItemQty { get; set; }
        }
    }
}
