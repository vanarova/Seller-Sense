using SellerSense.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.ViewModelManager
{
    internal class VM_Inventories
    {
        internal BaseCodeList _baseCodes { get; set; }
        internal AmzInventoryList _amzImportedInvList { get; set; }
        internal FkInventoryList _fkImportedInventoryList { get; set; }
        internal SpdInventoryList _spdImportedInventoryList { get; set; }
        internal MsoInventoryList _msoImportedInventoryList { get; set; }

        public VM_Inventories()
        {
            _baseCodes = new BaseCodeList();
            _amzImportedInvList = new AmzInventoryList();
            _fkImportedInventoryList = new FkInventoryList();
            _spdImportedInventoryList = new SpdInventoryList();
            _msoImportedInventoryList = new MsoInventoryList();
        }

    }
}
