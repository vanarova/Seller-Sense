﻿using Amazon.Auth.AccessControlPolicy;
using CommonUtil;
using Decoders;
using Decoders.Interfaces;
using SellerSense.Helper;
using SellerSense.Model;
using SellerSense.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model
{
    //consolidated inventory model class..
    internal class M_External_Inventories
    {
       
        internal M_BaseCodeList _baseCodes { get; set; }
        internal M_Shelf_InventoryList _shelfInvList { get; set; }
        internal M_AmzInventoryList _amzImportedInvList { get; set; }
        internal M_FkInventoryList _fkImportedInventoryList   {get; set;}
        internal M_SpdInventoryList _spdImportedInventoryList {get; set;}
        internal M_MsoInventoryList _msoImportedInventoryList { get; set; }


        public M_External_Inventories()
        {
            _baseCodes = new M_BaseCodeList();
            _amzImportedInvList = new M_AmzInventoryList();
            _shelfInvList = new M_Shelf_InventoryList();
            _fkImportedInventoryList = new M_FkInventoryList();
            _spdImportedInventoryList = new M_SpdInventoryList();
            _msoImportedInventoryList = new M_MsoInventoryList();
        }

        internal System.Threading.Tasks.Task<List<int>> SearchAmzInvCollectionAsync(string keyword,
           Constants.SearchType searchBy,
           Constants.Company companyName)
        {
            return _amzImportedInvList.SearchInvCollectionAsync(keyword, searchBy, companyName);

        }

        internal Task<List<int>> SearchSpdInvCollectionAsync(string keyword,
           Constants.SearchType searchBy,
           Constants.Company companyName)
        {
            return _spdImportedInventoryList.SearchInvCollectionAsync(keyword, searchBy, companyName);
        }


        internal Task<List<int>> SearchMsoInvCollectionAsync(string keyword,
            Constants.SearchType searchBy,
            Constants.Company companyName)
        {
            return _msoImportedInventoryList.SearchInvCollectionAsync(keyword, searchBy, companyName);
        }


        internal Task<List<int>> SearchFkInvCollectionTask(string keyword,
            Constants.SearchType searchBy,
            Constants.Company companyName)
        {
            return _fkImportedInventoryList.SearchInvCollectionTask(keyword, searchBy, companyName);
        }


        internal void ImportBaseInvCodesFile(string fileName)
        {
            _baseCodes.ImportBaseInvCodesFile(fileName);
        }


        internal void ImportShelfInventoryFile(string fileName)
        {
            if (_shelfInvList._shelfInventoryList.Count > 0)
                _shelfInvList._shelfInventoryList.Clear();
            _shelfInvList._shelfInventoryList = ShelfInventoryDecorder.ImportShelfInventory(fileName);
            //_amzImportedInvList._amzInventoryList = AmazonInvDecoder.ImportAmazonInventory(fileName);
        }

        internal void ImportAmazonInventoryFile(string fileName)
        {
            if (_amzImportedInvList._amzInventoryList.Count > 0) 
                _amzImportedInvList._amzInventoryList.Clear();
            _amzImportedInvList._amzInventoryList = AmazonInvDecoder.ImportAmazonInventory(fileName,
                Properties.Resources.amazon_inv_sku, Properties.Resources.amazon_inv_asin, Properties.Resources.amazon_inv_price,
                Properties.Resources.amazon_inv_qty);
            //_amzImportedInvList._amzInventoryList = AmazonInvDecoder.ImportAmazonInventory(fileName);
        }

        internal async Task ImportAmazonInventoryFileOnlineAPI()
        {
            if (_amzImportedInvList._amzInventoryList.Count > 0)
                _amzImportedInvList._amzInventoryList.Clear();
            string fileName = await AmazonSPAPI.CreateReport_GET_MERCHANT_LISTINGS_ALL_DATA();
            _amzImportedInvList._amzInventoryList = AmazonInvDecoder.ImportAmazonInventory(fileName,
                Properties.Resources.amazon_api_inv_sku, Properties.Resources.amazon_api_inv_asin, Properties.Resources.amazon_api_inv_price,
                Properties.Resources.amazon_api_inv_qty);
        }

        internal void ImportFlipkartInventoryFile(string fileName)
        {
            if (_fkImportedInventoryList._fkInventoryList.Count > 0)
            _fkImportedInventoryList._fkInventoryList.Clear();
            //List<IFkInventoryV2> _fkInventoryListV2  = FlipkartInvDecoder.GetDataV2(fileName, out string errorV2);
            _fkImportedInventoryList._fkInventoryList = FlipkartInvDecoder.GetDataV2(fileName, out string error);
            if (!string.IsNullOrEmpty(error)) { AlertBox ab = new AlertBox("Error accessing inventory file", 
                "Error accessing inventory file, Please check file might be open in another software or it is locked/ in-accesible",isError: true);
                ab.ShowDialog();
            }
        }


        internal void ExportAmazonInventoryFile(string dirPath)
        {
            AmazonInvDecoder.SaveAllData(_amzImportedInvList._amzModifiedInventoryList, dirPath);
        }

        internal void ExportFlipkartInventoryFile(string dirPath)
        {
            FlipkartInvDecoder.SaveAllData(_fkImportedInventoryList._fkUIModifiedInvList, dirPath);
        }

        internal void ImportSnapdealInventoryFile(string fileName)
        {
            if (_spdImportedInventoryList._spdInventoryList.Count > 0)
                _spdImportedInventoryList._spdInventoryList.Clear();    
            _spdImportedInventoryList._spdInventoryList = SnapdealInvDecoder.GetData(fileName);
        }

        internal void ExportSnapdealInventoryFile(string dirPath)
        {
            SnapdealInvDecoder.SaveAllData(_spdImportedInventoryList._spdUIModifiedInvList, dirPath);
        }

        internal void ImportMeeshoInventoryFile(string fileName)
        {
            if (_msoImportedInventoryList._msoInventoryList.Count > 0)
                _msoImportedInventoryList._msoInventoryList.Clear();
            _msoImportedInventoryList._msoInventoryList = MeeshoInvDecoder.GetData(fileName);
        }

        internal void ExportMeeshoInventoryFile(string dirPath)
        {
            MeeshoInvDecoder.SaveAllData(_msoImportedInventoryList._msoUIModifiedInvList, dirPath);
        }



    }
}
