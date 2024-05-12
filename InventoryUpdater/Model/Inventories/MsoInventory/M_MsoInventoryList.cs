using Common;
using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model
{
    internal class M_MsoInventoryList
    {
        private IList<IMsoInventory> _m_msoInventoryList { get; set; }
        internal IList<IMsoInventory> _msoInventoryList { get { return _m_msoInventoryList; } set { _m_msoInventoryList = value; /*MsoInventorySet?.Invoke(_m_msoInventoryList);*/ } }
        internal IList<IMsoInventory> _msoUIModifiedInvList { get; set; }
        //internal event Action<IList<IMsoInventory>> MsoInventorySet;

        public M_MsoInventoryList()
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
