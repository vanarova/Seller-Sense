using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model
{
    internal class M_FkInventoryList
    {
        internal IList<IFkInventory> _fkInventoryList { get; set; }
        internal IList<IFkInventory> _fkUIModifiedInvList { get; set; } //collects user modifications rows only, leave unmodifed rows.

        public M_FkInventoryList()
        {
            _fkInventoryList = new List<IFkInventory>();
            _fkUIModifiedInvList = new List<IFkInventory>();    
        }

        internal Task<List<int>> SearchInvCollectionTask(string keyword,
     Constants.SearchType searchBy,
     Constants.Company companyName)
        {
            List<int> slist = new List<int>();
            Task<List<int>> t = Task<List<int>>.Run(() => { 
                int i = 0;
                if (companyName == Constants.Company.Flipkart)
                {
                    foreach (var item in _fkInventoryList)
                    {
                        if (searchBy == Constants.SearchType.ByCompanyId && item.fsn.Contains(keyword))
                            slist.Add(i);
                        //if (searchBy == Constants.SearchType.ByUserId && item.sku.Contains(keyword))
                        //    slist.Add(i);
                        i++;
                    }
                }
                return slist;
            });
            return t;
        }

        // internal void SearchInvCollectionAsync(string keyword,
        //Constants.SearchType searchBy,
        //Constants.Company companyName,
        //Action<List<int>> SendToUI)
        // {
        //     if(_fkInventoryList==null || _fkInventoryList.Count==0)
        //         return;
        //     BackgroundWorker bg = new BackgroundWorker();
        //     List<int> slist = new List<int>();
        //     bg.WorkerReportsProgress = true;
        //     bg.DoWork += (sender, doWorkEventArgs) => {
        //         int i = 0;
        //         if (companyName == Constants.Company.Flipkart)
        //         {
        //             foreach (var item in _fkInventoryList)
        //             {
        //                 if (searchBy == Constants.SearchType.ByCompanyId && item.fsn.Contains(keyword))
        //                     slist.Add(i);
        //                 //if (searchBy == Constants.SearchType.ByUserId && item.sku.Contains(keyword))
        //                 //    slist.Add(i);
        //                 i++;
        //             }
        //         }
        //         bg.ReportProgress(0, slist);
        //     };
        //     bg.ProgressChanged += (sender, progressChangedEventArgs) => {
        //         SendToUI(slist);
        //     };
        //     bg.RunWorkerAsync();
        // }

    }
}
