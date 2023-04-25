using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater.Model
{
    internal class AmzInventoryList
    {
        internal IList<IAmzInventory> _amzInventoryList { get; set; }


        internal void SearchInvCollectionAsync(string keyword,
       Constants.SearchType searchBy,
       Constants.Company companyName,
       Action<List<int>> SendToUI)
        {
            if(_amzInventoryList==null || _amzInventoryList.Count==0)
                return;
            BackgroundWorker bg = new BackgroundWorker();
            List<int> slist = new List<int>();
            bg.WorkerReportsProgress = true;
            bg.DoWork += (sender, doWorkEventArgs) => {
                int i = 0;
                if (companyName == Constants.Company.Amazon)
                {
                    foreach (var item in _amzInventoryList)
                    {
                        if (searchBy == Constants.SearchType.ByCompanyId && item.asin.Contains(keyword))
                            slist.Add(i);
                        if (searchBy == Constants.SearchType.ByUserId && item.sku.Contains(keyword))
                            slist.Add(i);
                        i++;
                    }
                }
                bg.ReportProgress(0, slist);
            };
            bg.ProgressChanged += (sender, progressChangedEventArgs) => {
                SendToUI(slist);
            };
            bg.RunWorkerAsync();
        }

    }
}
