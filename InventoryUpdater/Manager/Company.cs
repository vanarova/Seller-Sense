using Decoders;
using Decoders.Interfaces;
using InventoryUpdater.Helper;
using InventoryUpdater.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

namespace InventoryUpdater
{



    /// <summary>
    /// Drives Model logic
    /// </summary>
    public class Company
    {
        private string Name;
        private string Code;
        internal BaseCodeList _baseCodes { get; set; }
        internal AmzInventoryList _amzImportedInvList { get; set; }
        internal FkInventoryList _fkImportedInventoryList { get; set; }
        internal SpdInventoryList _spdImportedInventoryList { get; set; }
        internal MsoInventoryList _msoImportedInventoryList { get; set; }

        internal Map _map { get; set; }
        internal Model.Inv _inv { get; set; }
        internal DataSet _mapGridData { get; set; }
        internal DataSet _invUpdateGridData { get; set; }
        

        public Company()
        {
            _baseCodes = new BaseCodeList();
            _amzImportedInvList = new AmzInventoryList();
            _fkImportedInventoryList = new FkInventoryList();
            _spdImportedInventoryList = new SpdInventoryList();
            _msoImportedInventoryList = new MsoInventoryList();
            _map = new Map();
        }

        internal void SearchAmzInvCollectionAsync(string keyword,
            Constants.SearchType searchBy,
            Constants.Company companyName,
            Action<List<int>> SendToUI)
        {
            _amzImportedInvList.SearchInvCollectionAsync(keyword, searchBy, companyName, SendToUI);
           
        }


        internal void SearchSpdInvCollectionAsync(string keyword,
            Constants.SearchType searchBy,
            Constants.Company companyName,
            Action<List<int>> SendToUI)
        {
            _spdImportedInventoryList.SearchInvCollectionAsync(keyword, searchBy, companyName, SendToUI);
        }


        internal void SearchMsoInvCollectionAsync(string keyword,
            Constants.SearchType searchBy,
            Constants.Company companyName,
            Action<List<int>> SendToUI)
        {
            _msoImportedInventoryList.SearchInvCollectionAsync(keyword, searchBy, companyName, SendToUI);
        }


        internal void SearchFkInvCollectionAsync(string keyword,
            Constants.SearchType searchBy,
            Constants.Company companyName,
            Action<List<int>> SendToUI)
        {
            _fkImportedInventoryList.SearchInvCollectionAsync(keyword, searchBy, companyName, SendToUI);
        }


        public void ReadSavedMaps()
        {
            //add each read map from file sys
            //Maps.Add(map);
        }

        internal void LoadMapFile(string fileName)
        {

        }

        public void SerializeMaps()
        {
            //save maps to file system
        }

        public void CreateAnEmptyMapWithImportedBaseCodes()
        {
            //BaseCodes codes = ImportBaseCodes();
        }

        internal void ImportBaseInvCodesFile(string fileName)
        {
            _baseCodes.ImportBaseInvCodesFile(fileName);
            _map.CreateAnEmptyMap(_baseCodes);
        }

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

        internal void ShowAmzInvFiller(Image selectedImg,string selectedCode, string selectedTitle, Action<string> AssignSelectedIDToMAP)
        {
            InvFiller inf = new InvFiller(selectedImg, selectedCode, selectedTitle,_amzImportedInvList._amzInventoryList, this);
            inf.ShowDialog();
            AssignSelectedIDToMAP(inf.SelectedID);
        }


        internal void ShowFkInvFiller(Image selectedImg, string selectedCode, string selectedTitle, Action<string> AssignSelectedIDToMAP)
        {
            InvFiller inf = new InvFiller(selectedImg, selectedCode, selectedTitle, _fkImportedInventoryList._fkInventoryList, this);
            inf.ShowDialog();
            AssignSelectedIDToMAP(inf.SelectedID);
        }

        internal void ShowSpdInvFiller(Image selectedImg, string selectedCode, string selectedTitle, Action<string> AssignSelectedIDToMAP)
        {
            InvFiller inf = new InvFiller(selectedImg, selectedCode, selectedTitle, _spdImportedInventoryList._spdInventoryList, this);
            inf.ShowDialog();
            AssignSelectedIDToMAP(inf.SelectedID);
        }


        internal void ShowMsoInvFiller(Image selectedImg, string selectedCode, string selectedTitle, Action<string> AssignSelectedIDToMAP)
        {
            InvFiller inf = new InvFiller(selectedImg, selectedCode, selectedTitle, _msoImportedInventoryList._msoInventoryList, this);
            inf.ShowDialog();
            AssignSelectedIDToMAP(inf.SelectedID);
        }

        //internal void ImportFlipkartInventoryFile(string fileName)
        //{
        //    _fkInventory = FlipkartInvDecoder.GetData(fileName);
        //}

        internal void LoadInvUpdateDataFromUserSuppliedMapFile(string fileName)
        {
            _map.SetLastSavedMapFileAndLoadMap(fileName);
        }

        internal bool LoadInvDataFromLastSavedMap()
        {
            _map.LoadLastSavedMap();
            if (!string.IsNullOrWhiteSpace(_map._lastSavedMapFilePath))
                _inv = new Model.Inv(_map);
            else return false;

            return true;
        }

        internal void AssignAmzInvAndPricesToInvUpdateCollection(Action AmazonInvAssigned)
        {
            List<IAmzInventory> amzInvList = new List<IAmzInventory>();
            amzInvList.AddRange(_amzImportedInvList._amzInventoryList);
            //var predicate = new Predicate<string>(pairNumber);
            foreach (var invItem in _inv._invEntries)
            {
                var amzInvItem = amzInvList.Find(amz => amz.asin == invItem.MapEntry.AmzCodeValue);
                if (amzInvItem != null)
                {
                    invItem.AmzSystemInv = Convert.ToInt16(amzInvItem.systemQuantity);
                    invItem.AmzInv = Convert.ToInt16(amzInvItem.sellerQuantity);
                }
            }
            GetInvUpdateGridDataset(() => { AmazonInvAssigned(); });
        }

        internal void AssignFkInvAndPricesToInvUpdateCollection(Action FlipkartInvAssigned)
        {
            List<IFkInventory> fkInvList = new List<IFkInventory>();
            fkInvList.AddRange(_fkImportedInventoryList._fkInventoryList);
            //var predicate = new Predicate<string>(pairNumber);
            foreach (var invItem in _inv._invEntries)
            {
                var fkInvItem = fkInvList.Find(fk => fk.fsn == invItem.MapEntry.FkCodeValue);
                if (fkInvItem != null)
                {
                    invItem.FkSystemInv = Convert.ToInt16(fkInvItem.systemQuantity);
                    invItem.FkInv = Convert.ToInt16(fkInvItem.sellerQuantity);
                }
            }
            GetInvUpdateGridDataset(() => { FlipkartInvAssigned(); });
        }

        internal void AssignSpdInvAndPricesToInvUpdateCollection(Action SnapdealInvAssigned)
        {
            List<ISpdInventory> spdInvList = new List<ISpdInventory>();
            spdInvList.AddRange(_spdImportedInventoryList._spdInventoryList);
            //var predicate = new Predicate<string>(pairNumber);
            foreach (var invItem in _inv._invEntries)
            {
                var fkInvItem = spdInvList.Find(x => x.fsn == invItem.MapEntry.SpdCodeValue);
                if (fkInvItem != null)
                {
                    invItem.SpdSystemInv = Convert.ToInt16(fkInvItem.systemQuantity);
                    invItem.SpdInv = Convert.ToInt16(fkInvItem.sellerQuantity);
                }
            }
            GetInvUpdateGridDataset(() => { SnapdealInvAssigned(); });
        }

        internal void AssignMsoInvAndPricesToInvUpdateCollection(Action MeeshoInvAssigned)
        {
            List<IMsoInventory> msoInvList = new List<IMsoInventory>();
            msoInvList.AddRange(_msoImportedInventoryList._msoInventoryList);
            //var predicate = new Predicate<string>(pairNumber);
            foreach (var invItem in _inv._invEntries)
            {
                var msoInvItem = msoInvList.Find(mso => mso.fsn == invItem.MapEntry.MsoCodeValue);
                if (msoInvItem != null)
                {
                    invItem.MsoSystemInv = Convert.ToInt16(msoInvItem.systemQuantity);
                    invItem.MsoInv = Convert.ToInt16(msoInvItem.sellerQuantity);
                }
            }
            GetInvUpdateGridDataset(() => { MeeshoInvAssigned(); });
        }

        //internal void AssignMsoInvUpdateCollection(Action MeeshoInvAssigned)
        //{
        //    List<IMsoInventory> msoInvList = new List<IMsoInventory>();
        //    msoInvList.AddRange(_msoImportedInventoryList._msoInventoryList);
        //    //var predicate = new Predicate<string>(pairNumber);
        //    foreach (var invItem in _inv._invEntries)
        //    {
        //        var msoInvItem = msoInvList.Find(mso => mso.fsn == invItem.MapEntry.MsoCodeValue);
        //        if (msoInvItem != null)
        //        {
        //            invItem.MsoSystemInv = Convert.ToInt16(msoInvItem.systemQuantity);
        //            invItem.MsoInv = Convert.ToInt16(msoInvItem.sellerQuantity);
        //        }
        //    }
        //    GetInvUpdateGridDataset(() => { MeeshoInvAssigned(); });
        //}

        internal void SaveInvSnapshot()
        {
            
            _inv.SaveInvSnapshot();
        }


        internal void GetInvUpdateGridDataset(Action DataSetLoaded)
        {
            BackgroundWorker bg = new BackgroundWorker();
            DataSet ds = new DataSet(); ds.Tables.Add("t");

            ds.Tables[0].Columns.Add(Constants.ICols.Image, typeof(Image));
            ds.Tables[0].Columns.Add(Constants.ICols.Code);
            ds.Tables[0].Columns.Add(Constants.ICols.Title);
            ds.Tables[0].Columns.Add(Constants.ICols.stock);
            ds.Tables[0].Columns.Add(Constants.ICols.acode);
            ds.Tables[0].Columns.Add(Constants.ICols.acount);
            ds.Tables[0].Columns.Add(Constants.ICols.asyscount);
            ds.Tables[0].Columns.Add(Constants.ICols.fcode);
            ds.Tables[0].Columns.Add(Constants.ICols.fcount);
            ds.Tables[0].Columns.Add(Constants.ICols.fsyscount);
            ds.Tables[0].Columns.Add(Constants.ICols.scode);
            ds.Tables[0].Columns.Add(Constants.ICols.scount);
            ds.Tables[0].Columns.Add(Constants.ICols.sSyscount);
            ds.Tables[0].Columns.Add(Constants.ICols.mcode);
            ds.Tables[0].Columns.Add(Constants.ICols.mcount);
            ds.Tables[0].Columns.Add(Constants.ICols.msyscount);
            ds.Tables[0].Columns.Add(Constants.ICols.notes);
            ds.Tables[0].Columns[Constants.ICols.Code].ReadOnly = true;
            ds.Tables[0].Columns[Constants.ICols.Title].ReadOnly = true;
            ds.Tables[0].Columns[Constants.ICols.acode].ReadOnly = true;
            ds.Tables[0].Columns[Constants.ICols.fcode].ReadOnly = true;
            ds.Tables[0].Columns[Constants.ICols.scode].ReadOnly = true;
            ds.Tables[0].Columns[Constants.ICols.mcode].ReadOnly = true;

            bg.WorkerReportsProgress = true;
            bg.DoWork += (sender, doWorkEventArgs) =>
            {
                _inv._invEntries.ForEach((x) =>
                {
                    Image img = null; Image timg = null;
                    if(File.Exists(Path.Combine(_map._lastSavedMapImageDirectory, x.MapEntry.Image)))
                     img = Image.FromFile(Path.Combine(_map._lastSavedMapImageDirectory, x.MapEntry.Image));
                    if(img!=null)
                     timg = (Image)(new Bitmap(img, new Size(75, 75)));
                    ds.Tables[0].Rows.Add(timg,
                        x.MapEntry.BaseCodeValue,
                        x.MapEntry.Title,
                        x.WarehouseInv,
                        x.MapEntry.AmzCodeValue,
                        x.AmzInv, x.AmzSystemInv,
                        x.MapEntry.FkCodeValue,
                        x.FkInv,x.FkSystemInv,
                        x.MapEntry.SpdCodeValue,
                        x.SpdInv, x.SpdSystemInv,
                        x.MapEntry.MsoCodeValue,
                        x.MsoInv, x.MsoSystemInv,
                        x.Notes);
                });

            };
            bg.RunWorkerCompleted += (s, ev) => {
                _invUpdateGridData = ds;
                DataSetLoaded();
            };
            bg.RunWorkerAsync();
            //return ds;
        }

        internal void FillLoadedMapToGridDataset(Action DataSetLoaded)
        {
            //this.WindowState = FormWindowState.Minimized;
            BackgroundWorker bg = new BackgroundWorker();
            DataSet ds = new DataSet(); ds.Tables.Add("t");
            ds.Tables[0].Columns.Add(Constants.MCols.Image, typeof(Image));
            ds.Tables[0].Columns.Add(Constants.MCols.Code);
            ds.Tables[0].Columns.Add(Constants.MCols.Title);
            ds.Tables[0].Columns.Add(Constants.MCols.amz_Code);
            ds.Tables[0].Columns.Add(Constants.MCols.fK_Code);
            ds.Tables[0].Columns.Add(Constants.MCols.spd_Code);
            ds.Tables[0].Columns.Add(Constants.MCols.mso_Code);
            ds.Tables[0].Columns.Add(Constants.MCols.notes);

            bg.WorkerReportsProgress = true;
            bg.DoWork += (sender, doWorkEventArgs) =>
            {
                _map.MapEntries.ForEach((x) =>
                {
                    Image img = null; Image timg = null;
                    if (File.Exists(Path.Combine(_map._lastSavedMapImageDirectory, x.Image)))
                    {
                        img = Image.FromFile(Path.Combine(_map._lastSavedMapImageDirectory, x.Image));
                        timg = (Image)(new Bitmap(img, new Size(75, 75)));
                    }
                    DataRow dr = ds.Tables[0].Rows.Add(timg, x.BaseCodeValue, x.Title, x.AmzCodeValue, x.FkCodeValue, x.SpdCodeValue, x.MsoCodeValue, x.Notes);
                });
            };
            bg.RunWorkerCompleted += (s, ev) => {
                _mapGridData = ds;
                DataSetLoaded();
            };
            bg.RunWorkerAsync();
            //return ds;
        }



    }


}
