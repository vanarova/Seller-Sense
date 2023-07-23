using AngleSharp.Common;
using Decoders.Interfaces;
using Newtonsoft.Json;
using SellerSense.ViewManager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SellerSense.Model
{
    internal class M_InvSnapshot
    {
        internal List<InvSnapshotEntry> _invSnapshotEntries { get; set; }
        internal List<InvSnapshotEntry> _invLastSavedSnapshotEntries { get; set; }
        internal string LastSavedSnapshotFileName;
        internal M_Product _m_ProductModel { get; set; }
        const string _snapshotDir = Constants.Snapshots;
        static private string _fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".json";
        //static private string _fileName = string.Format("{0}-{1}-{2}_{3}-{4}-{5}.json", DateTime.Now.Year.ToString(),
        //    DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), DateTime.Now.Hour.ToString(),
        //    DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString());


        public M_InvSnapshot(M_Product m_productModel)
        {
            this._m_ProductModel = m_productModel;
            //this._m_ProductModel.LoadLastSavedMap();
            _invSnapshotEntries = new List<InvSnapshotEntry>();
            //m_productModel._productEntries.ForEach(e =>
            //{
            //    _invSnapshotEntries.Add(new InvSnapshotEntry() { MapEntry = e });
            //});
            //inventories._fkImportedInventoryList
        }

        internal void SaveInvSnapshot()
        {
            SerializeInv(_m_ProductModel._lastSavedMapDirectory);
        }

        private void GetLastSavedSnapshot()
        {
            string snapShotDir = Path.Combine(_m_ProductModel._lastSavedMapDirectory, _snapshotDir);
            SortedList<double,string> sortedSnapShorts = new SortedList<double,string>();    
            foreach (var item in Directory.GetFiles(snapShotDir))
            {
               string fileName= Path.GetFileNameWithoutExtension(item).Trim();
                fileName = fileName.Replace(".json","");
                bool result = DateTime.TryParseExact(fileName, "yyyy-MM-dd_HH-mm-ss",CultureInfo.InvariantCulture, DateTimeStyles.None,out DateTime dt);
                if (result)
                {
                    TimeSpan t = DateTime.Now - dt;
                    sortedSnapShorts.Add(t.TotalMinutes, item);
                }
            }
            if(sortedSnapShorts.Count > 0)  
                LastSavedSnapshotFileName =sortedSnapShorts.Values[0];
        }

        internal void DeSerializeLastInvSnapshot()
        {
            GetLastSavedSnapshot();

            if (!string.IsNullOrEmpty(LastSavedSnapshotFileName))
            {
                string json = File.ReadAllText(LastSavedSnapshotFileName);
                _invLastSavedSnapshotEntries= JsonConvert.DeserializeObject<List<InvSnapshotEntry>>(json);
            }
        }

        private void SerializeInv(string dirName)
        {
            string snapShotDir = Path.Combine(dirName, _snapshotDir);
            if (!Directory.Exists(snapShotDir))
                Directory.CreateDirectory(snapShotDir);

            string fileName = Path.Combine(snapShotDir, _fileName);
            string json = JsonConvert.SerializeObject(_invSnapshotEntries, Formatting.Indented);
            File.WriteAllText(fileName, json);
            //DeSerializeInv();
        }



    }

    internal class InvSnapshotEntry
    {
        //short names are used to reduce file size
       
        public string ICode { get; set; }
        
       public string AInv { get; set; }
       public string ASystemInv { get; set; }
       public string FInv { get; set; }    
       public string FSystemInv { get; set; }    
       public string SInv { get; set; }
       public string SSystemInv { get; set; }
       public string MInv { get; set; }
       public string MSystemInv { get; set; }
       public string IInv { get; set; }
       public string Notes { get; set; }

        public string ACode { get; set; }
        public string FCode { get; set; }
        public string SCode { get; set; }
        public string MCode { get; set; }
    }
}
