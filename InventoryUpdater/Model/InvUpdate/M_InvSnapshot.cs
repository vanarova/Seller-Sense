using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace SellerSense.Model
{
    //internal class M_InvSnapshot
    //{
    //    internal List<InvSnapshotEntry> _invSnapshotEntries { get; set; }
    //    internal List<InvSnapshotEntry> _invLastSavedSnapshotEntries { get; set; }
    //    internal string LastSavedSnapshotFileName;
    //    internal M_Product _m_ProductModel { get; set; }
    //    const string _snapshotDir = Constants.Snapshots;
    //    static private string _fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".json";
    //    private SortedList<double, string> _sortedSnapShorts;

    //    //static private string _fileName = string.Format("{0}-{1}-{2}_{3}-{4}-{5}.json", DateTime.Now.Year.ToString(),
    //    //    DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), DateTime.Now.Hour.ToString(),
    //    //    DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString());


    //    public M_InvSnapshot(M_Product m_productModel)
    //    {
    //        this._m_ProductModel = m_productModel;
    //        //this._m_ProductModel.LoadLastSavedMap();
    //        _invSnapshotEntries = new List<InvSnapshotEntry>();
    //        //m_productModel._productEntries.ForEach(e =>
    //        //{
    //        //    _invSnapshotEntries.Add(new InvSnapshotEntry() { MapEntry = e });
    //        //});
    //        //inventories._fkImportedInventoryList
    //    }

    //    internal void SaveInvSnapshot()
    //    {
    //        SerializeInv(_m_ProductModel._lastSavedMapDirectory);
    //    }

    //    private void GetLastSavedSnapshots()
    //    {
    //        string snapShotDir = Path.Combine(_m_ProductModel._lastSavedMapDirectory, _snapshotDir);
    //        if (!Directory.Exists(snapShotDir))
    //            return;
    //        _sortedSnapShorts = new SortedList<double,string>();    
    //        foreach (var item in Directory.GetFiles(snapShotDir))
    //        {
    //           string fileName= Path.GetFileNameWithoutExtension(item).Trim();
    //            fileName = fileName.Replace(".json","");
    //            bool result = DateTime.TryParseExact(fileName, "yyyy-MM-dd_HH-mm-ss",CultureInfo.InvariantCulture, DateTimeStyles.None,out DateTime dt);
    //            if (result)
    //            {
    //                TimeSpan t = DateTime.Now - dt;
    //                _sortedSnapShorts.Add(t.TotalMinutes, item);
    //            }
    //        }
    //        if(_sortedSnapShorts.Count > 0)  
    //            LastSavedSnapshotFileName = _sortedSnapShorts.Values[0];
    //    }

    //    internal void DeSerializeLastInvSnapshot() //This method cant be called from constructor, coz snapshots are saved at a later stage, while user edits inventory
    //    {
    //        GetLastSavedSnapshots();

    //        if (!string.IsNullOrEmpty(LastSavedSnapshotFileName))
    //        {
    //            string json = File.ReadAllText(LastSavedSnapshotFileName);
    //            _invLastSavedSnapshotEntries= JsonConvert.DeserializeObject<List<InvSnapshotEntry>>(json);
    //        }
    //    }


    //    internal (List<InvSnapshotEntry>, List<InvSnapshotEntry>) DeSerializeLastTwoInvSnapshots() 
    //    {
    //        GetLastSavedSnapshots();
    //        if (_sortedSnapShorts != null && _sortedSnapShorts.Count >= 2)
    //        {
    //            var result1 = new List<InvSnapshotEntry>();
    //            var result2 = new List<InvSnapshotEntry>();
    //            var LastSavedSnapshotFileName = _sortedSnapShorts.Values[0];
    //            var LastToLastSavedSnapshotFileName = _sortedSnapShorts.Values[1];

    //            if (!string.IsNullOrEmpty(LastSavedSnapshotFileName))
    //            {
    //                string json = File.ReadAllText(LastSavedSnapshotFileName);
    //                result1 = JsonConvert.DeserializeObject<List<InvSnapshotEntry>>(json);
    //            }
    //            if (!string.IsNullOrEmpty(LastToLastSavedSnapshotFileName))
    //            {
    //                string json = File.ReadAllText(LastToLastSavedSnapshotFileName);
    //                result2 = JsonConvert.DeserializeObject<List<InvSnapshotEntry>>(json);
    //            }
    //            return (result1, result2);
    //        }else
    //        { return default; }
    //    }

    //    private void SerializeInv(string dirName)
    //    {
    //        string snapShotDir = Path.Combine(dirName, _snapshotDir);
    //        if (!Directory.Exists(snapShotDir))
    //            Directory.CreateDirectory(snapShotDir);

    //        string fileName = Path.Combine(snapShotDir, _fileName);
    //        string json = JsonConvert.SerializeObject(_invSnapshotEntries, Formatting.Indented);
    //        File.WriteAllText(fileName, json);
    //        //DeSerializeInv();
    //    }



    //}

    //internal class InvSnapshotEntry
    //{
    //    //short names are used to reduce file size
       
    //    public string ICode { get; set; }
        
    //   public string AInv { get; set; }
    //   public string ASystemInv { get; set; }
    //   public string FInv { get; set; }    
    //   public string FSystemInv { get; set; }    
    //   public string SInv { get; set; }
    //   public string SSystemInv { get; set; }
    //   public string MInv { get; set; }
    //   public string MSystemInv { get; set; }
    //   public string IInv { get; set; }
    //   public string Notes { get; set; }

    //    public string ACode { get; set; }
    //    public string FCode { get; set; }
    //    public string SCode { get; set; }
    //    public string MCode { get; set; }
    //}
}
