using SellerSense.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SellerSense.Views;
using System.Drawing.Imaging;
using Common;
using System.Windows.Forms;
using MS.WindowsAPICodePack.Internal;

namespace SellerSense.Model
{

    internal class M_Product
    {
        public List<ProductEntry> _productEntries { get; set; }
        internal string _companyCode;
        //private string _mapFilePath;
        //private const string _imageDir = "imgs";
        internal string _lastSavedMapFilePath { 
            get { return Path.Combine(_workspace,_companyCode, Constants.MapFileName); } 
            //set { _mapFilePath = value; } 
        }
        public string _workspace { get { return ProjIO.GetUserSetting(Constants.WorkspaceDir); } }
        internal string _lastSavedMapImageDirectory { get { 
                return Path.Combine(Path.GetDirectoryName(_lastSavedMapFilePath), Constants.Imgs);
         } }


        
    

    internal string _lastSavedMapDirectory
        {
            get { return Path.Combine(_workspace, _companyCode); }
        }

        public M_Product(string companyCode)
        {
            _companyCode = companyCode;
            _productEntries = new List<ProductEntry>();
            LoadLastSavedMap();
        }

      

        public void CreateAnEmptyMap(M_BaseCodeList baseCodeList) {
            foreach (var item in baseCodeList.codes)
            {
                _productEntries.Add(new ProductEntry(item.BaseCodeValue, item.Image, item.Title, String.Empty,
                    String.Empty,string.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
            }
        }

        public void ImportMap(string json) {

           
            //MapEntries = JsonConvert.DeserializeObject<List<MapEntry>>(json);
        }

        public void SerializeMap(string fileName) { 
            string json = JsonConvert.SerializeObject(_productEntries, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public  void LoadLastSavedMap()
        {
            if (!string.IsNullOrEmpty(_lastSavedMapFilePath) &&  File.Exists(_lastSavedMapFilePath))
            {
                string txt = File.ReadAllText(_lastSavedMapFilePath); //create separate function for file IO
                _productEntries =  JsonConvert.DeserializeObject<List<ProductEntry>>(txt);
            }
        }

        internal void SaveMapFile()
        {
            SerializeMap(_lastSavedMapFilePath);
        }


        internal void SetLastSavedMapFileAndLoadMap(string fileName)
        {

            string txt = File.ReadAllText(fileName);
            _productEntries = JsonConvert.DeserializeObject<List<ProductEntry>>(txt);
            SaveMapFile();
        }


        
        internal static void ConvertJSONHttpImagesToLocalImages()
        {
            string lastSavedFilePath = ProjIO.GetUserSetting("LastSavedMapFilePath");
            string jsonText = File.ReadAllText(lastSavedFilePath);
            List<ProductEntry> jobj = JsonConvert.DeserializeObject<List<ProductEntry>>(jsonText);
            foreach (var item in jobj)
            {
                item.Image = SaveImage(item.Image, item.InHouseCode, lastSavedFilePath);
                
            }
            string json = JsonConvert.SerializeObject(jobj);
            string est = Path.GetExtension(lastSavedFilePath);
            string newFilePath = lastSavedFilePath.Replace(est, "_1" + est);
            File.WriteAllText(newFilePath, json);
        }


        //internal bool ChecKProductImageExists(Image img, string imageNameWithoutExtension)
        //{
        //    string imageName = imageNameWithoutExtension + ".jpg";
        //    string lastSavedFilePath = Path.Combine(_workspace, _companyCode);
        //    string destinationDirPath = Path.Combine(lastSavedFilePath, Constants.Imgs);
        //    string destinationImagePath = Path.Combine(destinationDirPath, imageName);
        //    if (File.Exists(destinationImagePath))
        //    {
        //        (new AlertBox("Error", 
        //            "Image with this in-house code already exists, please change inhouse code and try again",
        //            null, isError:false,"", "Replace","Cancel")).ShowDialog();
        //        return true;
        //    }
        //    return false;
        //}

        internal bool RemoveExistingProductImage(string inHouseCode)
        {
            string jpgImageName = inHouseCode + ".jpg";
            string jpegImageName = inHouseCode + ".jpeg";
            string pngImageName = inHouseCode + ".png";
            string lastSavedFilePath = Path.Combine(_workspace, _companyCode);
            if (!Directory.Exists(lastSavedFilePath)) return false;

            string destinationDirPath = Path.Combine(lastSavedFilePath, Constants.Imgs);
            try
            {
                if (!Directory.Exists(destinationDirPath))
                    return false;
                
                if(File.Exists(Path.Combine(destinationDirPath, jpgImageName)))
                    File.Delete(Path.Combine(destinationDirPath, jpgImageName));

                if (File.Exists(Path.Combine(destinationDirPath, jpegImageName)))
                    File.Delete(Path.Combine(destinationDirPath, jpegImageName));

                if (File.Exists(Path.Combine(destinationDirPath, pngImageName)))
                    File.Delete(Path.Combine(destinationDirPath, pngImageName));
            }
            catch (Exception dx)
            {
                throw new IOException($"IO exception, {dx.Message}");
            }
            
            return true;
        }


            internal string SaveImage(Image img, string imageNameWithoutExtension, bool overwrite = false)
        {
            string result = null;
            if (img == null) return String.Empty;
            if (String.IsNullOrEmpty(imageNameWithoutExtension))
                goto ret;
            try
            {
                string imageName = imageNameWithoutExtension + ".jpg";
                string lastSavedFilePath = Path.Combine(_workspace, _companyCode);
                if (!Directory.Exists(lastSavedFilePath))
                { result = null; goto ret; }
                string destinationDirPath = Path.Combine(lastSavedFilePath, Constants.Imgs);
                try
                {
                    if (!Directory.Exists(destinationDirPath))
                        Directory.CreateDirectory(destinationDirPath);
                }
            catch (Exception dx)
            {
                throw new IOException($"IO exception, {dx.Message}");
            }
            string destinationImagePath = Path.Combine(destinationDirPath, imageName);
                if (File.Exists(destinationImagePath) && overwrite == false)
                {
                   DialogResult dr =  (new AlertBox("Error", "Image with this in-house code already exists, Do you want to replace image?", isError:true)).ShowDialog();
                   if(dr!= DialogResult.OK)
                     result = null; goto ret;
                }
                else if (File.Exists(destinationImagePath) && overwrite == true)
                {
                    File.Delete(destinationImagePath);
                    img.Save(destinationImagePath, ImageFormat.Jpeg);
                    result = ResizeBelow1000x1000(img, destinationImagePath);
                }
                else if (!File.Exists(destinationImagePath))
                {
                    img.Save(destinationImagePath, ImageFormat.Jpeg);
                    result = ResizeBelow1000x1000(img, destinationImagePath);
                }
            }
            catch (Exception e)
            {
                (new AlertBox("Error", e.Message, isError: true)).ShowDialog();
                result = null;
            }

            ret:
            if (result == null)
                (new AlertBox("Image not saved", "Image not saved, please try again, if error persists, contact support", isError: true)).ShowDialog();
            return result;

        }

        private static string ResizeBelow1000x1000(Image img, string destinationImagePath)
        {
            string result;
            int w = img.Width; int h = img.Height;
            img.Dispose();
            if (File.Exists(destinationImagePath) && (w > 1000 || h > 1000))
            {
                Image rimg = ProjIO.ResizeImage(1000, 1000, destinationImagePath);
                rimg.Save(destinationImagePath, ImageFormat.Jpeg); rimg.Dispose();
            }
            result = destinationImagePath;
            return result;
        }

        private static string SaveImage(string imageURL, string title, string lastSavedFilePath)
        {
            Uri u = new Uri(imageURL);
            string imageFilePath = "";
            lastSavedFilePath = Path.GetDirectoryName(lastSavedFilePath);
            string ext = u.LocalPath.Substring(u.LocalPath.LastIndexOf('/')).Replace("/", "").Trim();
            ext = ext.Substring(ext.LastIndexOf('.'));
            try { 
            if (!Directory.Exists(Path.Combine(lastSavedFilePath, Constants.Imgs)))
                Directory.CreateDirectory(Path.Combine(lastSavedFilePath, Constants.Imgs));
            }
            catch (Exception dx)
            {
                throw new IOException($"IO exception, {dx.Message}");
            }
            using (WebClient client = new WebClient())
            {
                imageFilePath = Path.Combine(lastSavedFilePath, Constants.Imgs, title + ext);
                client.DownloadFile(u, imageFilePath);
                return (title + ext);
            }
        }

        internal  void DeleteProductImage(string imgName)
        {
            if (string.IsNullOrEmpty(imgName))
                return;
            try
            {
                string lastSavedFilePath = Path.Combine(_workspace, _companyCode);
                if (!Directory.Exists(lastSavedFilePath))
                {
                    (new AlertBox("Error", "Seller-Sense or company directory not found.",isError: true)).ShowDialog();
                    return;
                }
                string destinationDirPath = Path.Combine(lastSavedFilePath, Constants.Imgs);
                File.Delete(Path.Combine(destinationDirPath, imgName));
            }
            catch (Exception)
            {
                (new AlertBox("Error", "Error removing image, it might be open in another program or locked.", isError: true)).ShowDialog();
            }
           
        }

        internal class LinkedProduct
        {
            public string InHouseCode { get; set; }
            public string LinkQty { get; set; }
        }

        internal class ProductEntry
        {
            //Mark pubic, required for JSON serialization
            //internal Guid Id { get; set; }
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
            public string FlipkartSKU { get; set; }
            public string SnapdealCode { get; set; }
            public string SnapdealSKU { get; set; }
            public string MeeshoCode { get; set; }
            public string Notes { get; set; }
            public List<LinkedProduct> LinkedProduct {get; set;}

            //public ProductEntry()  { }

            public ProductEntry(string baseCodeValue, string img, string title,
                string amzInventory, string fkCodeValue,string spdCodeValue,
                string msoCodeValue, string notes, string tag, string desc, LinkedProduct linkedProd = null)
            {
                this.InHouseCode = baseCodeValue;
                this.Image = img;
                this.Title = title;
                this.Tag = tag;
                this.Description = desc;
                this.FlipkartCode = fkCodeValue;
                this.SnapdealCode = spdCodeValue;
                this.MeeshoCode = msoCodeValue;
                this.AmazonCode = amzInventory;
                this.Notes = notes;
                if(linkedProd == null)
                    LinkedProduct = new List<LinkedProduct>();
            }

            public bool IsComposedOfLinkedProducts()
            {
                if (LinkedProduct != null && LinkedProduct.Count > 0)
                    return true;
                else
                    return false;
            }

        }
    }


}
