using InventoryUpdater.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater.Model
{

    internal class Map
    {
        public List<MapEntry> MapEntries { get; set; }
        private const string _imageDir = "imgs";
        internal string _lastSavedMapFilePath { get; set; }
        internal string _lastSavedMapImageDirectory { get { 
                return Path.Combine(Path.GetDirectoryName(_lastSavedMapFilePath), _imageDir);
         } }

        internal string _lastSavedMapDirectory
        {  get { return Path.GetDirectoryName(_lastSavedMapFilePath); }
        }

        public Map()
        {
            MapEntries = new List<MapEntry>();
           
        }

      

        public void CreateAnEmptyMap(BaseCodeList baseCodeList) {
            foreach (var item in baseCodeList.codes)
            {
                MapEntries.Add(new MapEntry(item.BaseCodeValue, item.Image, item.Title, String.Empty, String.Empty,string.Empty, string.Empty, string.Empty));
            }
        }

        public void ImportMap(string json) {

           
            //MapEntries = JsonConvert.DeserializeObject<List<MapEntry>>(json);
        }

        public void SerializeMap(string fileName) { 
           string json = JsonConvert.SerializeObject(MapEntries, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public  void LoadLastSavedMap()
        {
            string lastSavedFileName = GetLastSavedMapFile();
            //MapEntries = JsonConvert.DeserializeObject<List<MapEntry>>(json);

            if (!string.IsNullOrEmpty(lastSavedFileName) &&  File.Exists(lastSavedFileName))
            {
                string txt = File.ReadAllText(lastSavedFileName); //create separate function for file IO
                //JObject jobj = JObject.Parse(txt);
                MapEntries =  JsonConvert.DeserializeObject<List<MapEntry>>(txt);
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

        internal void SaveAsMapFile(string fileName)
        {
            _lastSavedMapFilePath = fileName;
            ProjIO.SaveUserSetting("LastSavedMapFilePath", _lastSavedMapFilePath);
            SerializeMap(fileName);
        }



        internal void SetLastSavedMapFileAndLoadMap(string fileName)
        {
            _lastSavedMapFilePath = fileName;
            ProjIO.SaveUserSetting("LastSavedMapFilePath", _lastSavedMapFilePath);
            LoadLastSavedMap();
        }


        internal string GetLastSavedMapFile()
        {
            _lastSavedMapFilePath = ProjIO.GetUserSetting("LastSavedMapFilePath");
            return _lastSavedMapFilePath;
        }

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
            if (!Directory.Exists(Path.Combine(lastSavedFilePath, _imageDir)))
                Directory.CreateDirectory(Path.Combine(lastSavedFilePath, _imageDir));

            using (WebClient client = new WebClient())
            {
                imageFilePath = Path.Combine(lastSavedFilePath, _imageDir, title + ext);
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
