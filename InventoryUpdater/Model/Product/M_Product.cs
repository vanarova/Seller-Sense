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

namespace SellerSense.Model
{

    internal class M_Product
    {
        public List<ProductEntry> _productEntries { get; set; }
        private string _companyCode;
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
            //string lastSavedFileName = GetLastSavedMapFile();
            //MapEntries = JsonConvert.DeserializeObject<List<MapEntry>>(json);

            if (!string.IsNullOrEmpty(_lastSavedMapFilePath) &&  File.Exists(_lastSavedMapFilePath))
            {
                string txt = File.ReadAllText(_lastSavedMapFilePath); //create separate function for file IO
                //JObject jobj = JObject.Parse(txt);
                _productEntries =  JsonConvert.DeserializeObject<List<ProductEntry>>(txt);
                //string json = JsonConvert.SerializeObject(MapEntries, Formatting.Indented);
                //foreach (var item in jobj.Property("Inventory").Values())
                //{
                //    if (AppVersion.Ver == AppVersion.Number.V1)
                //        codes.Add(item.ToObject<BaseCodeV1>());
                //    else if (AppVersion.Ver == AppVersion.Number.V2)
                //        codes.Add(item.ToObject<BaseCodeV2>());

                //}
                //_map.CreateAnEmptyMap(_baseCodes);
            }
        }

        internal void SaveMapFile()
        {
            SerializeMap(_lastSavedMapFilePath);
        }

        //internal void SaveAsMapFile(string mapFileTxt)
        //{
        //    SerializeMap(_lastSavedMapFilePath);
        //}

        //internal void SaveAsMapFile(string fileName)
        //{
        //    //_lastSavedMapFilePath = fileName;
        //    ProjIO.SaveUserSetting("LastSavedMapFilePath", _lastSavedMapFilePath);
        //    SerializeMap(fileName);
        //}



        internal void SetLastSavedMapFileAndLoadMap(string fileName)
        {

            string txt = File.ReadAllText(fileName);
            _productEntries = JsonConvert.DeserializeObject<List<ProductEntry>>(txt);
            SaveMapFile();
            //_lastSavedMapFilePath = fileName;
            //ProjIO.SaveUserSetting("LastSavedMapFilePath", _lastSavedMapFilePath);
            //LoadLastSavedMap();
        }


        //internal string GetLastSavedMapFile()
        //{
        //    _lastSavedMapFilePath = ProjIO.GetUserSetting("LastSavedMapFilePath");
        //    return _lastSavedMapFilePath;
        //}

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


        private static string SaveImage(string imageURL, string title, string lastSavedFilePath)
        {
            Uri u = new Uri(imageURL);
            string imageFilePath = "";
            lastSavedFilePath = Path.GetDirectoryName(lastSavedFilePath);
            string ext = u.LocalPath.Substring(u.LocalPath.LastIndexOf('/')).Replace("/", "").Trim();
            ext = ext.Substring(ext.LastIndexOf('.'));
            if (!Directory.Exists(Path.Combine(lastSavedFilePath, Constants.Imgs)))
                Directory.CreateDirectory(Path.Combine(lastSavedFilePath, Constants.Imgs));

            using (WebClient client = new WebClient())
            {
                imageFilePath = Path.Combine(lastSavedFilePath, Constants.Imgs, title + ext);
                client.DownloadFile(u, imageFilePath);
                return (title + ext);
            }
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
            public string Description { get; set; }
            public string AmazonCode { get; set; }
            public string FlipkartCode { get; set; }
            public string SnapdealCode { get; set; }
            public string MeeshoCode { get; set; }
            public string Notes { get; set; }


            public ProductEntry(string baseCodeValue, string img, string title,
                string amzInventory, string fkCodeValue,string spdCodeValue,
                string msoCodeValue, string notes, string tag, string desc)
            {
                //this.Id = Guid.NewGuid();
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
                
                
                
            }

        }
    }


}
