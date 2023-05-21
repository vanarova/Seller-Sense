using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model
{
    internal class SpdInventoryList
    {
        internal IList<ISpdInventory> _spdInventoryList { get; set; }
        internal IList<ISpdInventory> _spdUIModifiedInvList { get; set; } //collects user modifications


        public SpdInventoryList()
        {
            _spdInventoryList = new List<ISpdInventory>();
            _spdUIModifiedInvList = new List<ISpdInventory>();
        }


        internal Task<List<int>> SearchInvCollectionAsync(string keyword,
     Constants.SearchType searchBy,
     Constants.Company companyName)
        {
            List<int> slist = new List<int>();
            Task<List<int>> t = Task<List<int>>.Run(()=>{
                int i = 0;
                if (companyName == Constants.Company.Snapdeal)
                {
                    foreach (var item in _spdInventoryList)
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
        //     if(_spdInventoryList==null || _spdInventoryList.Count==0)
        //         return;
        //     BackgroundWorker bg = new BackgroundWorker();
        //     List<int> slist = new List<int>();
        //     bg.WorkerReportsProgress = true;
        //     bg.DoWork += (sender, doWorkEventArgs) => {
        //         int i = 0;
        //         if (companyName == Constants.Company.Snapdeal)
        //         {
        //             foreach (var item in _spdInventoryList)
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
