using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decoders.Interfaces;

namespace SellerSense.Model
{
    internal class M_Shelf_InventoryList
    {
        private IList<IShelfInventory> _m_shelfInvList;
        internal IList<IShelfInventory> _shelfInventoryList { get { return _m_shelfInvList; } set { _m_shelfInvList = value;  } }

        public M_Shelf_InventoryList()
        {
            _shelfInventoryList = new List<IShelfInventory>();
        }
    }
}
