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
using System.CodeDom;
using System.Linq;

namespace SellerSense.ViewManager
{

    /// <summary>
    /// Drives Model logic
    /// </summary>
    public class VM_Company
    {
        internal string _name;
        internal string _code;
        internal M_External_Inventories _inventoriesModel { get; set; }
        internal VM_Inventories _inventoriesViewManager { get; set; }
        internal VM_Payments _paymentsViewManager { get; set; }
        internal VM_Products _productsViewManager { get; set; }
        internal M_Product _product_Model;
        internal Dictionary<string, Image> _images;
        //internal VM_Companies.CrossCompanyLinkedInventoryCount _crossCompanyLinkedInventoryCount;
        //internal VM_Companies.CrossCompanyEvents _crossCompanyEvents;

        public VM_Company(string name, string code, 
            VM_Companies.CrossCompanySharedWrapper crossCompanySharedWrapper, 
            VM_Companies.CrossCompanyEvents _crossCompanyEvents)
        {
            _name = name;
            _code = code;
            //_crossCompanyEvents = crossCompanyEvents;
            //_crossCompanyLinkedInventoryCount = crossCompanyLinkedInventoryCount;
            _inventoriesModel = new M_External_Inventories();
            _product_Model = new M_Product(_code);
            _paymentsViewManager = new VM_Payments();
            _inventoriesViewManager = new VM_Inventories(_inventoriesModel, _product_Model,
                crossCompanySharedWrapper, _code, _crossCompanyEvents);
            _productsViewManager = new VM_Products(_product_Model, _inventoriesModel, _code);
        }


        internal Task<Dictionary<string, Image>> LoadImages()
        {
            if (_images == null)
            {
                _images = new Dictionary<string, Image>();
                return ProjIO.LoadAllImagesAndDownSize75x75Async(_product_Model._lastSavedMapImageDirectory);
            }
            else return Task.FromResult(_images);
        }



        //// Represents linked inhouse inventory, stores individual inv counts from all vendors in all companies.
        //// Then used to update inhouse inventory column, shows user total all inventory asssigned to 
        //// all vendors.
        //internal class CrossCompanyLinkedInventoryCount
        //{
        //    internal CrossCompanyLinkedInventoryCount(string companyCode)   {
        //        linkedInv = new Dictionary<string, LinkedInventoryList>{{ companyCode, new LinkedInventoryList() }};
        //    }
        //    //<company code, linkedCompany>
        //    internal Dictionary<string, LinkedInventoryList>  linkedInv { get; set; }
        //    internal int GetTotalInventoryCountForAllCompanies(string inhouseCode)
        //    { int total = 0;
        //        foreach (var comp in linkedInv)
        //        {
        //            var prod = comp.Value.FindProduct(inhouseCode);
        //            if (prod != null)
        //                total = total + prod.AmzCount + prod.SnpCount + prod.FkCount + prod.MesshoCount;
        //        }
        //        return total;
        //    }

        //    internal class LinkedInventoryList
        //    {
        //        internal LinkedInventoryList() { LinkedInventoryCounts = new List<LinkedProductInventory>(); }
        //        internal List<LinkedProductInventory> LinkedInventoryCounts { get; set; }
        //        internal LinkedProductInventory FindProduct(string inhouseCode)
        //        {
        //           return LinkedInventoryCounts.FirstOrDefault(x => x.LinkedInhouseCode == inhouseCode);
        //        }
               
        //        internal class LinkedProductInventory
        //        {
        //            internal string LinkedInhouseCode { get; set; }
        //            internal int AmzCount { get; set; }
        //            internal int FkCount { get; set; }
        //            internal int SnpCount { get; set; }
        //            internal int MesshoCount { get; set; }
        //        }
        //    }

        //}



    }


}
