using Decoders.Interfaces;
using SellerSense.Model;
using ssViewControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SellerSense.ViewManager.VM_Products;

namespace SellerSense.ViewManager
{
    internal class VM_Inventories
    {
        internal M_Inventories _m_inventoriesModel { get; set; }
        internal M_InvUpdate _m_invModel { get; set; }
        internal M_Product _m_productModel { get; set; }
        internal DataSet _invUpdateGridData { get; set; }
        private InvCntrl _v_invCntrl;
        private ssGridView<InventoryView> _ssGridView;
        internal List<InventoryView> _inventoryViewList { get; set; }
        public VM_Inventories(M_Inventories inventories, M_Product m_product)
        {
            _m_inventoriesModel = inventories;
            _m_productModel = m_product;
        }

        internal void AssignViewManager(InvCntrl invUserControl) {
            _v_invCntrl = invUserControl;
            //HandleProductControlEvents();
        }

        internal void AssignViewManager(ssGridView<InventoryView> ssGrid)
        {
            _ssGridView = ssGrid;
            //HandlessGridViewControlEvents();
        }

        internal bool LoadInvDataFromLastSavedMap()
        {
            _m_productModel.LoadLastSavedMap();
            if (!string.IsNullOrWhiteSpace(_m_productModel._lastSavedMapFilePath))
                _m_invModel = new M_InvUpdate(_m_productModel);
            else return false;

            return true;
        }

        internal void AssignAmzInvAndPricesToInvUpdateCollection(Action AmazonInvAssigned)
        {
            List<IAmzInventory> amzInvList = new List<IAmzInventory>();
            amzInvList.AddRange(_m_inventoriesModel._amzImportedInvList._amzInventoryList);
            //var predicate = new Predicate<string>(pairNumber);
            foreach (var invItem in _m_invModel._invEntries)
            {
                var amzInvItem = amzInvList.Find(amz => amz.asin == invItem.MapEntry.AmazonCode);
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
            fkInvList.AddRange(_m_inventoriesModel._fkImportedInventoryList._fkInventoryList);
            //var predicate = new Predicate<string>(pairNumber);
            foreach (var invItem in _m_invModel._invEntries)
            {
                var fkInvItem = fkInvList.Find(fk => fk.fsn == invItem.MapEntry.FlipkartCode);
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
            spdInvList.AddRange(_m_inventoriesModel._spdImportedInventoryList._spdInventoryList);
            //var predicate = new Predicate<string>(pairNumber);
            foreach (var invItem in _m_invModel._invEntries)
            {
                var fkInvItem = spdInvList.Find(x => x.fsn == invItem.MapEntry.SnapdealCode);
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
            msoInvList.AddRange(_m_inventoriesModel._msoImportedInventoryList._msoInventoryList);
            //var predicate = new Predicate<string>(pairNumber);
            foreach (var invItem in _m_invModel._invEntries)
            {
                var msoInvItem = msoInvList.Find(mso => mso.fsn == invItem.MapEntry.MeeshoCode);
                if (msoInvItem != null)
                {
                    invItem.MsoSystemInv = Convert.ToInt16(msoInvItem.systemQuantity);
                    invItem.MsoInv = Convert.ToInt16(msoInvItem.sellerQuantity);
                }
            }
            GetInvUpdateGridDataset(() => { MeeshoInvAssigned(); });
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
                Dictionary<string, Image> imgs = Helper.ProjIO.LoadAllImagesAndDownSize75x75(_m_productModel._lastSavedMapImageDirectory);

                _m_invModel._invEntries.ForEach((x) =>
                {
                    Image timg = imgs.Where(i => Path.GetFileName(i.Key) == x.MapEntry.Image).FirstOrDefault().Value;

                    //Image img = null; Image timg = null;
                    //if (File.Exists(Path.Combine(_map._lastSavedMapImageDirectory, x.MapEntry.Image))) //TODO : move IO operation in another class
                    //    img = Image.FromFile(Path.Combine(_map._lastSavedMapImageDirectory, x.MapEntry.Image));
                    //if (img != null)
                    //    timg = new Bitmap(img, new Size(75, 75));


                    ds.Tables[0].Rows.Add(timg,
                        x.MapEntry.InHouseCode,
                        x.MapEntry.Title,
                        x.WarehouseInv,
                        x.MapEntry.AmazonCode,
                        x.AmzInv, x.AmzSystemInv,
                        x.MapEntry.FlipkartCode,
                        x.FkInv, x.FkSystemInv,
                        x.MapEntry.SnapdealCode,
                        x.SpdInv, x.SpdSystemInv,
                        x.MapEntry.MeeshoCode,
                        x.MsoInv, x.MsoSystemInv,
                        x.Notes);
                });

            };
            bg.RunWorkerCompleted += (s, ev) =>
            {
                _invUpdateGridData = ds;
                DataSetLoaded();
            };
            bg.RunWorkerAsync();
            //return ds;
        }


        internal void SaveInvSnapshot()
        {

            _m_invModel.SaveInvSnapshot();
        }


        internal class InventoryView
        {

        }

    }
}
