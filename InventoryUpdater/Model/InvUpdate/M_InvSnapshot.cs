using Decoders.Interfaces;
using Newtonsoft.Json;
using SellerSense.ViewManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model
{
    internal class M_InvSnapshot
    {
        internal List<InvSnapshotEntry> _invSnapshotEntries { get; set; }
        internal M_Product _m_ProductModel { get; set; }
        const string _snapshotDir = Constants.Snapshots;
        static private string _fileName = DateTime.Now.Year.ToString()
                + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()+ ".json";


        public M_InvSnapshot(M_Product m_productModel, M_External_Inventories inventories=null)
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

        private void SerializeInv(string dirName)
        {
            string snapShotDir = Path.Combine(dirName, _snapshotDir);
            if (!Directory.Exists(snapShotDir))
                Directory.CreateDirectory(snapShotDir);

            string fileName = Path.Combine(snapShotDir, _fileName);
            string json = JsonConvert.SerializeObject(_invSnapshotEntries, Formatting.Indented);
            File.WriteAllText(fileName, json);
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
