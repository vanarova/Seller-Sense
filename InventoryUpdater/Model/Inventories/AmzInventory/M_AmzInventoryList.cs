using Common;
using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model
{
    internal class M_AmzInventoryList
    {
        private IList<IAmzInventory> _m_amzInvList;
        internal IList<IAmzInventory> _amzInventoryList { get { return _m_amzInvList; } set { _m_amzInvList = value; /*AmzInventorySet?.Invoke(_m_amzInvList);*/ } }
        internal IList<IAmzInventory> _amzModifiedInventoryList { get; set; }
        //internal event Action<IList<IAmzInventory>> AmzInventorySet;

        //internal event Action AmzIncChanged;

        public M_AmzInventoryList()
        {
            _amzInventoryList = new List<IAmzInventory>();
            _amzModifiedInventoryList = new List<IAmzInventory>();
        }

       // internal void SearchInvCollectionAsync(string keyword,
       //Constants.SearchType searchBy,
       //Constants.Company companyName,
       //Action<List<int>> SendToUI)
       // {
       //     if(_amzInventoryList==null || _amzInventoryList.Count==0)
       //         return;
       //     BackgroundWorker bg = new BackgroundWorker();
       //     List<int> slist = new List<int>();
       //     //bg.WorkerReportsProgress = true;
       //     bg.DoWork += (sender, doWorkEventArgs) => {
       //         int i = 0;
       //         if (companyName == Constants.Company.Amazon)
       //         {
       //             foreach (var item in _amzInventoryList)
       //             {
       //                 if (searchBy == Constants.SearchType.ByCompanyId && item.asin.Contains(keyword))
       //                     slist.Add(i);
       //                 if (searchBy == Constants.SearchType.ByUserId && item.sku.Contains(keyword))
       //                     slist.Add(i);
       //                 i++;
       //             }
       //         }
       //         //bg.ReportProgress(0, slist);
       //     };
       //     bg.RunWorkerCompleted += (sender, progressChangedEventArgs) => {
       //         SendToUI(slist);
       //     };
       //     bg.RunWorkerAsync();
       // }


     //   internal Task<List<int>> SearchInvCollectionAsync(string keyword,
     //Constants.SearchType searchBy,
     //Constants.Company companyName)
     //   {
     //       List<int> slist = new List<int>();
     //       Task<List<int>> t = Task<List<int>>.Run(async delegate { //this async delegate create a new Task internally
     //           int i = 0;
     //           if (companyName == Constants.Company.Amazon)
     //           {
     //               foreach (var item in _amzInventoryList)
     //               {
     //                   if (searchBy == Constants.SearchType.ByCompanyId && item.asin.Contains(keyword))
     //                       slist.Add(i);
     //                   if (searchBy == Constants.SearchType.ByUserId && item.sku.Contains(keyword))
     //                       slist.Add(i);
     //                   i++;
     //               }
     //           }
     //           await Task.Delay(TimeSpan.FromSeconds(1.5)); //this will work only with async delegate
     //           return slist;
     //       });
     //       return t;
     //   }


        internal Task<List<int>> SearchInvCollectionAsync(string keyword,
      Constants.SearchType searchBy,
      Constants.Company companyName)
        {
            List<int> slist = new List<int>();
            Task<List<int>> t = Task<List<int>>.Run(() =>    //async () => //make async, coz of delay
            {
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
                //await Task.Delay(2000); //added delay, have to make action async
                return slist;
            });
            return t;
        }

        //  internal  Task<List<int>> RSearchInvCollectionAsync(string keyword,
        //Constants.SearchType searchBy,
        //Constants.Company companyName)
        //  {
        //      List<int> slist = new List<int>();
        //      Task<List<int>> t = Task<List<int>>.Run(async () =>    //async () => //make async, coz of delay
        //      {
        //          int i = 0;
        //          if (companyName == Constants.Company.Amazon)
        //          {
        //              foreach (var item in _amzInventoryList)
        //              {
        //                  if (searchBy == Constants.SearchType.ByCompanyId && item.asin.Contains(keyword))
        //                      slist.Add(i);
        //                  if (searchBy == Constants.SearchType.ByUserId && item.sku.Contains(keyword))
        //                      slist.Add(i);
        //                  i++;
        //              }
        //          }
        //          await Task.Delay(2000); //added delay, have to make action async
        //          return slist;
        //      });
        //      return t;
        //  }

    }
}
