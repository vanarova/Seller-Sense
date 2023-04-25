using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater.Model
{
    internal class Inv
    {
        internal List<InvEntry> _invEntries { get; set; }
        internal Map _map { get; set; }
        const string _snapshotDir = "Snapshots";
        static private string _fileName = DateTime.Now.Year.ToString()
                + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()+ ".json";


        public Inv(Map map)
        {
            _map = map;
            _invEntries = new List<InvEntry>();
            map.MapEntries.ForEach(e =>
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
       public Map.MapEntry MapEntry { get; set; }
       public int? AmzInv { get; set; }
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
