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
using SellerSense.ViewManager;
using SellerSense;

namespace SellerSense.ViewManager
{

    /// <summary>
    /// Drives Model logic
    /// </summary>
    public class VM_Company
    {
        internal string _name;
        internal string _code;
        internal M_Inventories _inventoriesModel { get; set; }
        internal VM_Inventories _inventoriesViewManager { get; set; }
        internal VM_Map _mapping { get; set; }
        internal VM_Products _productViewManager { get; set; }
        internal Dictionary<string, Image> _images;

        public VM_Company(string name, string code)
        {
            _name = name;
            _code = code;
            _inventoriesModel = new M_Inventories();
            _mapping = new VM_Map(_name, _code);
            _inventoriesViewManager = new VM_Inventories(_inventoriesModel, _mapping._map);
            _productViewManager = new VM_Products(_mapping._map,_inventoriesModel);
        }


        public void CreateAnEmptyMapWithImportedBaseCodes()
        {
            _mapping._map.CreateAnEmptyMap(_inventoriesModel._baseCodes);
        }


        internal void LoadInvUpdateDataFromUserSuppliedMapFile(string fileName)
        {
            _mapping._map.SetLastSavedMapFileAndLoadMap(fileName);
        }

        internal Task<Dictionary<string, Image>> LoadImages()
        {
            if (_images == null)
            {
                _images = new Dictionary<string, Image>();
                return ProjIO.LoadAllImagesAndDownSize75x75Async(_mapping._map._lastSavedMapImageDirectory);
            }
            else return Task.FromResult(_images);
        }


    }


}
