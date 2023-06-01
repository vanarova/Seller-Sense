using Decoders.Interfaces;
using Newtonsoft.Json;
using SellerSense.ViewModelManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model
{
    internal class M_InvUpdate
    {
        internal List<InvEntry> _invEntries { get; set; }
        internal M_Map _map { get; set; }
        const string _snapshotDir = Constants.Snapshots;
        static private string _fileName = DateTime.Now.Year.ToString()
                + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()+ ".json";


        public M_InvUpdate(M_Map map, VM_Inventories inventories=null)
        {
            _map = map;
            _invEntries = new List<InvEntry>();
            map._mapEntries.ForEach(e =>
            {
                _invEntries.Add(new InvEntry() { MapEntry = e });
            });
        }

        internal void SaveInvSnapshot()
        {
            SerializeInv(_map._lastSavedMapDirectory);
        }

        private void SerializeInv(string dirName)
        {
            string snapShotDir = Path.Combine(dirName, _snapshotDir);
            if (!Directory.Exists(snapShotDir))
                Directory.CreateDirectory(snapShotDir);

            string fileName = Path.Combine(snapShotDir, _fileName);
            string json = JsonConvert.SerializeObject(_invEntries, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }



    }

    internal class InvEntry
    {
       public M_Map.MapEntry MapEntry { get; set; }
       public int? AmzInv { get; set; }
       public int? AmzSystemInv { get; set; }
       public int? FkInv { get; set; }    
       public int? FkSystemInv { get; set; }    
       public int? SpdInv { get; set; }
       public int? SpdSystemInv { get; set; }
       public int? MsoInv { get; set; }
       public int? MsoSystemInv { get; set; }
       public int? WarehouseInv { get; set; }
       public string Notes { get; set; }
       public bool Selected { get; set; }
    }
}
