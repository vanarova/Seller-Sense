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

namespace SellerSense.Model
{

    internal class M_Map
    {
        public List<MapEntry> _mapEntries { get; set; }
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

        public M_Map(string companyCode)
        {
            _companyCode = companyCode;
            _mapEntries = new List<MapEntry>();
            LoadLastSavedMap();
        }

      

        public void CreateAnEmptyMap(M_BaseCodeList baseCodeList) {
            foreach (var item in baseCodeList.codes)
            {
                _mapEntries.Add(new MapEntry(item.BaseCodeValue, item.Image, item.Title, String.Empty, String.Empty,string.Empty, string.Empty, string.Empty));
            }
        }

        public void ImportMap(string json) {

           
            //MapEntries = JsonConvert.DeserializeObject<List<MapEntry>>(json);
        }

        public void SerializeMap(string fileName) { 
           string json = JsonConvert.SerializeObject(_mapEntries, Formatting.Indented);
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
                _mapEntries =  JsonConvert.DeserializeObject<List<MapEntry>>(txt);
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
            _mapEntries = JsonConvert.DeserializeObject<List<MapEntry>>(txt);
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
            List<MapEntry> jobj = JsonConvert.DeserializeObject<List<MapEntry>>(jsonText);
            foreach (var item in jobj)
            {
                item.Image = SaveImage(item.Image, item.BaseCodeValue, lastSavedFilePath);
                
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


        internal class MapEntry
        {
            //Mark pubic, required for JSON serialization
            //internal Guid Id { get; set; }
            public string BaseCodeValue { get; set; }
            public string Image { get; set; }
            public string Title { get; set; }
            public string AmzCodeValue { get; set; }
            public string FkCodeValue { get; set; }
            public string SpdCodeValue { get; set; }
            public string MsoCodeValue { get; set; }
            public string Notes { get; set; }


            public MapEntry(string baseCodeValue, string img, string title,
                string amzInventory, string fkCodeValue,string spdCodeValue,
                string msoCodeValue, string notes)
            {
                //this.Id = Guid.NewGuid();
                this.BaseCodeValue = baseCodeValue;
                this.Image = img;
                this.Title = title;
                this.FkCodeValue = fkCodeValue;
                this.SpdCodeValue = spdCodeValue;
                this.MsoCodeValue = msoCodeValue;
                this.AmzCodeValue = amzInventory;
                this.Notes = notes;
                
                
            }

        }
    }


}
