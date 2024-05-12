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

        private static ExcelMapper _importExm;
        private static ExcelMapper _exportExm;
        private static List<INewProduct> prods;
        private static List<IEditProduct> editProds;
        private static string validationErrors;
        //private enum RequiredFields { InHouseCode, Image, Title, MRP, SellingPrice, CostPrice, Weight };

        public static IList<INewProduct> ImportNewProducts(string fileName, out string error, out string validationErrors)
        {
            IEnumerable<INewProduct> iprods;
            error = string.Empty;
            try
            {
                _importExm = new ExcelMapper(fileName);
                iprods = _importExm.Fetch<NewProduct>();
            }
            catch (Exception e) { error = e.Message; validationErrors = string.Empty;  return new List<INewProduct>(); }

            prods = iprods.ToList<INewProduct>();
            //prods.RemoveAt(0); //remove 2nd header row.
            validationErrors = ValidateNewProds();
            return prods;
        }

        public static IList<IEditProduct> ImportProductsForEdit(string fileName, out string error, out string validationErrors)
        {
            IEnumerable<IEditProduct> iprods;
            error = string.Empty;
            try
            {
                _importExm = new ExcelMapper(fileName);
                iprods = _importExm.Fetch<EditProduct>();
            }
            catch (Exception e) { error = e.Message; validationErrors = string.Empty; return new List<IEditProduct>(); }

            editProds = iprods.ToList<IEditProduct>();
            validationErrors = ValidateEditProds();
            return editProds;
        }

        public static string ExportProductsForEdit(IList<IEditProduct> prods, string folderPath)
        {
            string fileName = "Products_" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx";
            string path = Path.Combine(folderPath, fileName);
            _exportExm = new ExcelMapper();
            _exportExm.Save(path, prods);
            return path;
        }

        public static string ExportSampleProductTemplate(string folderPath)
        {
            string fileName = "Products_" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx";
            string path = Path.Combine(folderPath, fileName);
            INewProduct prod = CreateNewProduct();
            prod = InsertSampleData(prod);
            IList<INewProduct> prods = new List<INewProduct>();
            prods.Add(prod);
            _exportExm = new ExcelMapper();
            _exportExm.Save(path, prods);
            return path;
        }

        public static INewProduct CreateNewProduct()
        {
            return new NewProduct();
        }

        public static IEditProduct CreateNewEditProduct()
        {
            return new EditProduct();
        }

        private static INewProduct InsertSampleData(INewProduct Product)
        {
            //Product.MRP = "";
            //Product.Title = "";
            Product.InHouseCode = "xyz";
            Product.Image = "c:\\Images\\img1.jpg";
            Product.ImageAlt1 = "c:\\Images\\img2.jpg";
            Product.ImageAlt2 = "c:\\Images\\img3.jpg";
            Product.ImageAlt3 = "c:\\Images\\img4.jpg";
            Product.Title = "Sample";
            Product.Tag = "Sample Search Tag";
            Product.MRP = "1000";
            Product.SellingPrice = "800";
            Product.CostPrice = "500";
            Product.Weight = "200";
            Product.WeightAfterPackaging = "250";
            Product.DimensionsBeforePackaging = "10x10x10";
            Product.DimensionsAfterPackaging = "15x15x15";
            Product.Description = "Sample";
            Product.AmazonCode = "ASIN_CODE";
            Product.AmazonSKU = "SKU_CODE";
            Product.FlipkartCode = "FSN_CODE";
            Product.FlipkartSKU = "FK_SKU";
            Product.SnapdealCode = "SUPC_CODE";
            Product.SnapdealSKU = "SNP_SKU_CODE";
            //Product.MeeshoCode = "";
            Product.Notes = "";

            return Product;
        }


        private static string ValidateEditProds()
        {
            StringBuilder errors = new StringBuilder();
            //Required fields check.
            foreach (var item in editProds)
            {
                if (string.IsNullOrEmpty(item.InHouseCode)) errors.AppendLine("InHouseCode is empty, for one or more records");
                if (string.IsNullOrEmpty(item.Title)) errors.AppendLine("Title is empty, for one or more records");
                if (string.IsNullOrEmpty(item.MRP)) errors.AppendLine("MRP is empty, for one or more records");
                if (string.IsNullOrEmpty(item.SellingPrice)) errors.AppendLine("SellingPrice is empty, for one or more records");
                if (string.IsNullOrEmpty(item.CostPrice)) errors.AppendLine("CostPrice is empty, for one or more records");
                if (string.IsNullOrEmpty(item.Weight)) errors.AppendLine("Weight is empty, for one or more records");
            }

            return errors.ToString();
        }

        private static string ValidateNewProds()
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


        class NewProduct : INewProduct
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
            public string Notes { get; set; }
        }


        class EditProduct : IEditProduct
        {
            public string InHouseCode { get; set; }
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
            public string FlipkartSKU { get; set; }
            public string SnapdealCode { get; set; }
            public string SnapdealSKU { get; set; }
            public string Notes { get; set; }
        }
    }
}
