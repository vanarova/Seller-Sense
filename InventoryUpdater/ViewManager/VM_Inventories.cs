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
using System.Windows.Forms;
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
            TranslateInvModelToInvView();
        }

        internal void AssignViewManager(InvCntrl invUserControl) {
            _v_invCntrl = invUserControl;
            HandleProductControlEvents();
        }

        private void HandleProductControlEvents()
        {
            _v_invCntrl.importAmazonToolStripMenuItem.Click += (s, e) => { ImportAmazonInv(); };
            _v_invCntrl.importFlipkartToolStripMenuItem.Click += (s, e) => { };
            _v_invCntrl.importSnapdealToolStripMenuItem.Click += (s, e) => { };
            _v_invCntrl.importMeeshoToolStripMenuItem.Click += (s, e) => { };
        }



        private void ImportAmazonInv()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Amazon inv text file|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _m_inventoriesModel.ImportAmazonInventoryFile(openFileDialog.FileName);
                _ssGridView.IsLoading = true;
            }
            else return;
            //AssignAmzInvAndPricesToInvUpdateCollection(() => { DeepRefreshGridAndTakeSnapshots(); });
            AssignAmazonInvAndPricesToInvView();
        
        
        }

        internal void AssignImagesToProducts(Dictionary<string, Image> imgs)
        {
            foreach (var item in _inventoryViewList)
            {
                if (imgs.ContainsKey(item.InHouseCode))
                    item.Image = imgs[item.InHouseCode];

            }
        }

        private void AssignAmazonInvAndPricesToInvView()
        {
            foreach (var amzItem in _m_inventoriesModel._amzImportedInvList._amzInventoryList)
            {
                foreach (var viewItem in _inventoryViewList)
                {
                    if(amzItem.asin == viewItem.AmazonCode)
                    {
                       if(int.TryParse(amzItem.systemQuantity, out int val))
                        viewItem.AmazonSystemCount = val;
                    }
                }
            }
            
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








        //internal void WriteBackInvViewToInvModelAndSave()
        //{
        //    foreach (var p in _inventoryViewList)
        //    {
        //        foreach (var m in _m_product._productEntries)
        //        {
        //            if(p.InHouseCode == m.InHouseCode)
        //            {
        //                m.SnapdealCode = p.SnapdealCode;
        //                m.FlipkartCode = p.FlipkartCode;
        //                m.Notes = p.Notes;
        //                m.Title = p.Title;
        //                m.Description = p.Description;
        //                m.Tag = p.Tag;
        //                m.AmazonCode = p.AmazonCode;
        //                m.MeeshoCode = p.MeeshoCode;
                        
        //            }
        //        }

        //    }
        //    _m_product.SaveMapFile();
        //}


        private void TranslateInvModelToInvView()
        {
            _inventoryViewList = new List<InventoryView>();
            foreach (var item in _m_productModel._productEntries)
            {
                _inventoryViewList.Add(new InventoryView() {
                    InHouseCode = item.InHouseCode,
                    Title = item.Title, Tag = item.Tag, Image = null, AmazonCode = item.AmazonCode, FlipkartCode=item.FlipkartCode,
                    MeeshoCode=item.MeeshoCode,SnapdealCode=item.SnapdealCode
                    });
            }
        }



        internal void SaveInvSnapshot()
        {

            _m_invModel.SaveInvSnapshot();
        }


        internal class InventoryView
        {
            //below values from Product 
            public string InHouseCode { get; set; }
            public Image Image { get; set; }
            public string Title { get; set; }
            public string Tag { get; set; }
            

            //below values fron InvUpdate
            public int? AmazonCount { get; set; }
            public int? AmazonSystemCount { get; set; }
            public int? FlipkartCount { get; set; }
            public int? FlipkartSystemCount { get; set; }
            public int? SnapdealCount { get; set; }
            public int? SnapdealSystemCount { get; set; }
            public int? MeeshoCount { get; set; }
            public int? MeeshoSystemCount { get; set; }
            public int? InHouseCount { get; set; }
            public string Notes { get; set; }

            //below values from Product
            public string AmazonCode { get; set; }
            public string FlipkartCode { get; set; }
            public string SnapdealCode { get; set; }
            public string MeeshoCode { get; set; }
        }

    }
}
