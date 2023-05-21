using Decoders;
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


        //internal void ImportBaseInvCodesFile(string fileName)
        //{
        //    _baseCodes.ImportBaseInvCodesFile(fileName);
        //    _map.CreateAnEmptyMap(_baseCodes);
        //}

        internal void ImportAmazonInventoryFile(string fileName)
        {
            _amzImportedInvList._amzInventoryList = AmazonInvDecoder.ImportAmazonInventory(fileName);
        }

        internal void ImportFlipkartInventoryFile(string fileName)
        {
            _fkImportedInventoryList._fkInventoryList = FlipkartInvDecoder.GetData(fileName);
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
            _spdImportedInventoryList._spdInventoryList = SnapdealInvDecoder.GetData(fileName);
        }

        internal void ExportSnapdealInventoryFile(string dirPath)
        {
            SnapdealInvDecoder.SaveAllData(_spdImportedInventoryList._spdUIModifiedInvList, dirPath);
        }

        internal void ImportMeeshoInventoryFile(string fileName)
        {
            _msoImportedInventoryList._msoInventoryList = MeeshoInvDecoder.GetData(fileName);
        }

        internal void ExportMeeshoInventoryFile(string dirPath)
        {
            MeeshoInvDecoder.SaveAllData(_msoImportedInventoryList._msoUIModifiedInvList, dirPath);
        }



    }
}
