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

        internal void SaveInvSnapshot(IList<Decoders.Interfaces.IAmzInventory> _amzInventoryList)
        {
            if (_invSnapshotEntries.Count > 0)
                _invSnapshotEntries.Clear();
            foreach (var item in _amzInventoryList)
            {
                _invSnapshotEntries.Add(new InvSnapshotEntry()
                {
                    Sku = item.sku,
                    InvSysCount = item.systemQuantity,
                    asin = item.asin
                });
            }
            SerializeInvSnapshot();
        }



        internal void SaveInvSnapshot(IList<Decoders.Interfaces.IFkInventoryV2> _fkInventoryList)
        {
            if(_invSnapshotEntries.Count > 0)
                _invSnapshotEntries.Clear();
            foreach (var item in _fkInventoryList)
            {
                _invSnapshotEntries.Add(new InvSnapshotEntry()
                {
                    Sku = item.sku,
                    InvSysCount = item.systemQuantity,
                    asin = item.fsn
                });
            }
            SerializeInvSnapshot();
        }


        internal void SaveInvSnapshot(IList<Decoders.Interfaces.ISpdInventory> _spdInventoryList)
        {
            if (_invSnapshotEntries.Count > 0)
                _invSnapshotEntries.Clear();
            foreach (var item in _spdInventoryList)
            {
                _invSnapshotEntries.Add(new InvSnapshotEntry()
                {
                    Sku = item.sku,
                    InvSysCount = item.systemQuantity,
                    asin = item.fsn
                });
            }
            SerializeInvSnapshot();
        }


        internal void SaveInvSnapshot(IList<Decoders.Interfaces.IMsoInventory> _msoInventoryList)
        {
            if (_invSnapshotEntries.Count > 0)
                _invSnapshotEntries.Clear();
            foreach (var item in _msoInventoryList)
            {
                _invSnapshotEntries.Add(new InvSnapshotEntry()
                {
                    Sku = item.sku,
                    InvSysCount = item.systemQuantity,
                    asin = item.fsn
                });
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
            if (!Directory.Exists(snapShotDir))
                Directory.CreateDirectory(snapShotDir);

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
            GetSortedSnapshotsList();
            if (_sortedSnapShorts!=null && _sortedSnapShorts.Count > 0)
            {
                int day = 1; 
                var yesterday = DateTime.Today.AddDays(-day);
                DateTime minYesterdaysSnps=yesterday;
                bool notFound = true;
                while (notFound)
                {
                    if (day > 7)
                    { notFound = true;break; }
                    var yesterdaysSnps = _sortedSnapShorts.Select(x => x.Key).
                        Where(d => d > yesterday && d < DateTime.Today);
                    day = day + 1;
                    if (yesterdaysSnps == null || yesterdaysSnps.Count() == 0)
                        yesterday = DateTime.Today.AddDays(-day);
                    else
                    { notFound = false;
                        minYesterdaysSnps = yesterdaysSnps.Min();
                    }                }
                if (notFound)
                { MessageBox.Show("No inventory snapshot found for last 7 days, company:"+ _companyCode,"Info", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    return string.Empty; }
                return _sortedSnapShorts[minYesterdaysSnps];
            }
            else return String.Empty;
        }


        private string GetCsutomDayInvSnapshotFileName(DateTime customDate)
        {
            GetSortedSnapshotsList();
            if (_sortedSnapShorts != null && _sortedSnapShorts.Count > 0)
            {
                DateTime customSnpshot = _sortedSnapShorts.Select(x => x.Key).
                    Where(d => d == customDate).FirstOrDefault();
                if (customSnpshot != null)
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
