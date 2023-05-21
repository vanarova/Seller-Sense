using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater.Model
{
    internal class MsoInventoryList
    {
        internal IList<IMsoInventory> _msoInventoryList { get; set; }
        internal IList<IMsoInventory> _msoUIModifiedInvList { get; set; }

        public MsoInventoryList()
        {
            _msoUIModifiedInvList = new List<IMsoInventory>();
            _msoInventoryList = new List<IMsoInventory>();
        }

        internal Task<List<int>> SearchInvCollectionAsync(string keyword,
       Constants.SearchType searchBy,
       Constants.Company companyName)
        {
            List<int> slist = new List<int>();
            Task<List<int>> t = Task<List<int>>.Run(() => {
                int i = 0;
                if (companyName == Constants.Company.Meesho)
                {
                    foreach (var item in _msoInventoryList)
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

    }
}
