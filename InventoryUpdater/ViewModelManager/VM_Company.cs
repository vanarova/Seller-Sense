using Decoders;
using Decoders.Interfaces;
using SellerSense.Helper;
using SellerSense.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using SellerSense.ViewModelManager;
using SellerSense;

namespace InventoryUpdater.ViewModelManager
{

    /// <summary>
    /// Drives Model logic
    /// </summary>
    public class VM_Company
    {
        internal string _name;
        internal string _code;
        internal VM_Inventories _inventories { get; set; }
        internal VM_InvUpdate _invUpdate { get; set; }
        internal VM_Map _mapping { get; set; }


        public VM_Company(string name, string code)
        {
            _name = name;
            _code = code;
            _inventories = new VM_Inventories();
            _mapping = new VM_Map(_name, _code);
            _invUpdate = new VM_InvUpdate(_inventories, _mapping._map);
        }




        public void CreateAnEmptyMapWithImportedBaseCodes()
        {
            _mapping._map.CreateAnEmptyMap(_inventories._baseCodes);
        }




        internal void LoadInvUpdateDataFromUserSuppliedMapFile(string fileName)
        {
            _mapping._map.SetLastSavedMapFileAndLoadMap(fileName);
        }

       



    }


}
