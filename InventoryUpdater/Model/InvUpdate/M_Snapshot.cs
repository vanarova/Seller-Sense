﻿using CommonUtil;
using Newtonsoft.Json;
using SellerSense.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Model.InvUpdate
{
    internal class M_Snapshot
    {
        private string _companyCode;
        private List<InvSnapshotEntry> _invSnapshotEntries;
        private SortedList<DateTime, string> _sortedSnapShorts;
        private Site _siteCode;
        internal enum Site
        {
            amz,fk,spd,mso
        }

        public M_Snapshot(string companyCode, Site siteCode)
        {
            _companyCode = companyCode;
            _invSnapshotEntries = new List<InvSnapshotEntry>();
            _siteCode = siteCode;
        }

        internal void SaveInvSnapshot(IList<Decoders.Interfaces.IAmzInventory> _amzInventoryList,
            IList<Decoders.Interfaces.IAmzInventory> _amzModifiedInventoryList,
            bool saveOnlySystemInventory = true)
        {
            bool isModified = false;
            if (_invSnapshotEntries.Count > 0)
                _invSnapshotEntries.Clear();
            foreach (var item in _amzInventoryList)
            {
                if (saveOnlySystemInventory)
                {
                    _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = item.systemQuantity, asin = item.asin });
                }
                else
                {
                    isModified = false;
                    foreach (var mitem in _amzModifiedInventoryList)
                    {
                        if(string.Equals(mitem.asin.Trim(),item.asin.Trim(),StringComparison.InvariantCultureIgnoreCase)) //TODO override string compare operator for whole seller sense, create own equals()
                        {
                            //[BL] if user modifed inventory, then save user inv. Else save system inventory
                            isModified = true;
                            _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = mitem.sellerQuantity, asin = item.asin });
                            break;
                        }
                    }
                    if(!isModified)
                        _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = item.systemQuantity, asin = item.asin });
                }
            }
            //TODO : Dont duplicate snapshots and save more files, if previous snapshot matches with current snapshot, discard saving.
            SerializeInvSnapshot();
        }



        internal void SaveInvSnapshot(IList<Decoders.Interfaces.IFkInventoryV2> _fkInventoryList,
            IList<Decoders.Interfaces.IFkInventoryV2> _fkModifiedInventoryList,
            bool saveOnlySystemInventory = true)
        {
            bool isModified = false;
            if (_invSnapshotEntries.Count > 0)
                _invSnapshotEntries.Clear();
            foreach (var item in _fkInventoryList)
            {
                if (saveOnlySystemInventory)
                {
                    _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = item.systemQuantity, asin = item.fsn });
                }
                else
                {
                    isModified = false;
                    foreach (var mitem in _fkModifiedInventoryList)
                    {
                        if (string.Equals(mitem.fsn.Trim(), item.fsn.Trim(), StringComparison.InvariantCultureIgnoreCase)) //TODO override string compare operator for whole seller sense, create own equals()
                        {
                            //[BL] if user modifed inventory, then save user inv. Else save system inventory
                            isModified = true;
                            _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = mitem.sellerQuantity, asin = item.fsn });
                            break;
                        }
                    }
                    if (!isModified)
                        _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = item.systemQuantity, asin = item.fsn });
                }
            }
            SerializeInvSnapshot();
        }


        internal void SaveInvSnapshot(IList<Decoders.Interfaces.ISpdInventory> _spdInventoryList,
            IList<Decoders.Interfaces.ISpdInventory> _spdModifiedInventoryList,
            bool saveOnlySystemInventory = true)
        {
            bool isModified = false;
            if (_invSnapshotEntries.Count > 0)
                _invSnapshotEntries.Clear();
            foreach (var item in _spdInventoryList)
            {
                if (saveOnlySystemInventory)
                {
                    _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = item.systemQuantity, asin = item.fsn });
                }
                else
                {
                    isModified = false;
                    foreach (var mitem in _spdModifiedInventoryList)
                    {
                        if (string.Equals(mitem.fsn.Trim(), item.fsn.Trim(), StringComparison.InvariantCultureIgnoreCase)) //TODO override string compare operator for whole seller sense, create own equals()
                        {
                            //[BL] if user modifed inventory, then save user inv. Else save system inventory
                            isModified = true;
                            _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = mitem.sellerQuantity, asin = item.fsn });
                            break;
                        }
                    }
                    if (!isModified)
                        _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = item.systemQuantity, asin = item.fsn });
                }
            }
            SerializeInvSnapshot();
        }


        internal void SaveInvSnapshot(IList<Decoders.Interfaces.IMsoInventory> _msoInventoryList,
            IList<Decoders.Interfaces.IMsoInventory> _msoModifiedInventoryList,
            bool saveOnlySystemInventory = true)
        {
            bool isModified = false;
            if (_invSnapshotEntries.Count > 0)
                _invSnapshotEntries.Clear();
            foreach (var item in _msoInventoryList)
            {
                if (saveOnlySystemInventory)
                {
                    _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = item.systemQuantity, asin = item.fsn });
                }
                else
                {
                    isModified = false;
                    foreach (var mitem in _msoModifiedInventoryList)
                    {
                        if (string.Equals(mitem.fsn.Trim(), item.fsn.Trim(), StringComparison.InvariantCultureIgnoreCase)) //TODO override string compare operator for whole seller sense, create own equals()
                        {
                            //[BL] if user modifed inventory, then save user inv. Else save system inventory
                            isModified = true;
                            _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = mitem.sellerQuantity, asin = item.fsn });
                            break;
                        }
                    }
                    if (!isModified)
                        _invSnapshotEntries.Add(new InvSnapshotEntry() { Sku = item.sku, InvSysCount = item.systemQuantity, asin = item.fsn });
                }
            }
            SerializeInvSnapshot();
        }

        internal void SerializeInvSnapshot()
        {
           (bool exist, string companyDir) = ProjIO.GetCompanyMapDirIfExist(_companyCode);
            if (!exist)
            {
                Logger.Log("Error saving inventory snapshot.", Logger.LogLevel.error, false);
                return;
            }
            string snapShotDir = Path.Combine(companyDir, Constants.Snapshots, _siteCode.ToString());
            try { 
            if (!Directory.Exists(snapShotDir))
                Directory.CreateDirectory(snapShotDir);
            }
            catch (Exception dx)
            {
                throw new IOException($"IO exception, {dx.Message}");
            }

            string fileName = Path.Combine(snapShotDir, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".json");
            string json = JsonConvert.SerializeObject(_invSnapshotEntries, Formatting.Indented);
            File.WriteAllText(fileName, json);
            //DeSerializeInv();
        }

        internal IList<InvSnapshotEntry> GetCustomDayInvSnapshot(DateTime customDate)
        {
            string customSnapshotFileName = GetCsutomDayInvSnapshotFileName(customDate);
            if (string.IsNullOrEmpty(customSnapshotFileName))
                return default;
            if (!string.IsNullOrEmpty(customSnapshotFileName))
            {
                string json = File.ReadAllText(customSnapshotFileName);
                return JsonConvert.DeserializeObject<List<InvSnapshotEntry>>(json);
            }
            else return default;
        }

        internal IList<InvSnapshotEntry> GetLastDayInvSnapshot()
        {
            //List<InvSnapshotEntry> invSnapshotEntries = new List<InvSnapshotEntry>();
            string LastSavedSnapshotFileName = GetLastDayInvSnapshotFileName();
            if (string.IsNullOrEmpty(LastSavedSnapshotFileName))
                return default;
            if (!string.IsNullOrEmpty(LastSavedSnapshotFileName))
            {
                string json = File.ReadAllText(LastSavedSnapshotFileName);
                return JsonConvert.DeserializeObject<List<InvSnapshotEntry>>(json);
            }else return default;
        }


        internal IList<InvSnapshotEntry> GetTodaysLastSavedInvSnapshot()
        {
            //List<InvSnapshotEntry> invSnapshotEntries = new List<InvSnapshotEntry>();
            string LastSavedSnapshotFileName = GetTodaysLastSavedInvSnapshotFileName();
            if (string.IsNullOrEmpty(LastSavedSnapshotFileName))
                return default;
            if (!string.IsNullOrEmpty(LastSavedSnapshotFileName))
            {
                string json = File.ReadAllText(LastSavedSnapshotFileName);
                return JsonConvert.DeserializeObject<List<InvSnapshotEntry>>(json);
            }
            else return default;
        }


        private string GetTodaysLastSavedInvSnapshotFileName()
        {
            //var today = DateTime.Today;
            //SortedList<
            GetSortedSnapshotsList();
            if (_sortedSnapShorts != null && _sortedSnapShorts.Count > 0)
            {
                var todaySnps = _sortedSnapShorts.Select(x => x.Key).
                        Where(d =>  (DateTime.Today.Date == d.Date)).ToList<DateTime>();
                //SortedList<DateTime> sortaedList = todaySnps.OrderByDescending(x => x.Date);
                if(todaySnps.Count>0)
                    return _sortedSnapShorts[todaySnps[todaySnps.Count-1]];
                else
                    return string.Empty;
            }
            else return String.Empty;
        }


        private string GetLastDayInvSnapshotFileName()
        {
            try
            {
                GetSortedSnapshotsList();
                if (_sortedSnapShorts != null && _sortedSnapShorts.Count > 0)
                {
                    DateTime lastImportSnps = default(DateTime);
                    int prevDay = 1;
                    bool found = false;
                    while (!found)
                    {
                        if (prevDay > Constants.MaxHistoryDaysToKeepSnapshots)
                            break;
                        var lastImportDay = DateTime.Today.AddDays(-prevDay);
                        var lastImportSnpsList = _sortedSnapShorts.Select(x => x.Key).
                            Where(d => d > lastImportDay && d < DateTime.Today);
                        if (lastImportSnpsList.Any())
                            lastImportSnps = lastImportSnpsList.Min();
                        if (lastImportSnps != default(DateTime) &&
                            lastImportSnps < DateTime.Today.AddDays(-Constants.MaxHistoryDaysToKeepSnapshots))
                            return String.Empty;
                        if (lastImportSnps == default(DateTime))
                            prevDay++;
                        else
                            found = true;
                    }
                    if (lastImportSnps != default(DateTime))
                        return _sortedSnapShorts[lastImportSnps];
                    else
                        return String.Empty;

                }
                else return String.Empty;
            }
            catch (Exception e)  { throw e; }
        }


        private string GetCsutomDayInvSnapshotFileName(DateTime customDate)
        {
            GetSortedSnapshotsList();
            if (_sortedSnapShorts != null && _sortedSnapShorts.Count > 0)
            {
                DateTime customSnpshot = _sortedSnapShorts.Select(x => x.Key).
                    Where(d => d == customDate).FirstOrDefault();
                if (customSnpshot != null && _sortedSnapShorts.ContainsKey(customSnpshot))
                    return _sortedSnapShorts[customSnpshot];
            }
           
            MessageBox.Show("No inventory snapshot found for this date", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); 
            return String.Empty; 
        }


        private void GetSortedSnapshotsList()
        {
            (bool exist, string companyDir) = ProjIO.GetCompanyMapDirIfExist(_companyCode);
            if (!exist)
            {
                Logger.Log("Error getting inventory snapshot.", Logger.LogLevel.error, false);
                return;
            }
            string snapShotDir = Path.Combine(companyDir, Constants.Snapshots, _siteCode.ToString());
            if (!Directory.Exists(snapShotDir))
                return;
            _sortedSnapShorts = new SortedList<DateTime, string>();
            foreach (var item in Directory.GetFiles(snapShotDir))
            {
                string fileName = Path.GetFileNameWithoutExtension(item).Trim();
                fileName = fileName.Replace(".json", "");
                bool result = DateTime.TryParseExact(fileName, "yyyy-MM-dd_HH-mm-ss", 
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt);
                if (result && !_sortedSnapShorts.ContainsKey(dt))
                {
                    //TimeSpan t = DateTime.Now - dt;
                    _sortedSnapShorts.Add(dt, item);
                }
            }
            //if (_sortedSnapShorts.Count > 0)
            //    LastSavedSnapshotFileName = _sortedSnapShorts.Values[0];
        }

        internal IList<DateTime> GetAllSnapshotDates()
        {
            GetSortedSnapshotsList();
            return _sortedSnapShorts.Keys.Select(x => x).ToList();
        }


    }



    internal class InvSnapshotEntry
    {
        //short names are used to reduce file size
        public string Sku { get; set; }
        public string asin { get; set; }
        public string InvSysCount { get; set; }

    }

}
