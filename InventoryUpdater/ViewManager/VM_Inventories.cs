using Decoders.Interfaces;
using SellerSense.Model;
using SellerSense.Views;
using SellerSense.Views.Inventories;
using ssViewControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SellerSense.Constants;
using static SellerSense.ViewManager.VM_Company;
using static SellerSense.ViewManager.VM_Products;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SellerSense.ViewManager
{
    /// <summary>
    /// view manager for inventory form hierarchy, handles events and binding for all usercontrols in Inventories form
    /// </summary>
    internal partial class VM_Inventories
    {
        internal M_External_Inventories _m_externalInventoriesModel { get; set; }
        internal M_InvSnapshot _m_invSnapShotModel { get; set; }
        internal M_Product _m_productModel { get; set; }
        private string _companyCode { get; set; }
        //internal DataSet _invUpdateGridData { get; set; }
        private InvCntrl _v_invCntrl;
        private ssGridView<InventoryView> _ssGridView;
        private Action<Object, ListChangedEventArgs> _bindingListChanged;
        internal List<InventoryView> _inventoryViewList { get; set; }
        private CrossCompanyLinkedInventoryCount _crossCompanyLinkedInventoryCount;

        public VM_Inventories(M_External_Inventories inventories, M_Product m_product,
            CrossCompanyLinkedInventoryCount crossCompanyLinkedInventoryCount, string companyCode)
        {
            _companyCode = companyCode;
            _crossCompanyLinkedInventoryCount = crossCompanyLinkedInventoryCount;
            _m_externalInventoriesModel = inventories;
            _m_productModel = m_product;
            LoadInvSnapshotDataFromLastSavedMap();
            TranslateInvModelToInvView();
            HandleExternalInventoryImportEvents();
        }

        internal void AssignViewManager(ssGridView<InventoryView> ssGrid)
        {
            _ssGridView = ssGrid;
            
            HandlessGridViewControlEvents();
            
        }

        private void HandleExternalInventoryImportEvents()
        {
            _m_externalInventoriesModel._amzImportedInvList.AmzInventorySet += (list) =>
            {   
                if (list.Count > 0) _v_invCntrl.label_amazon.BackColor = Color.LimeGreen;
                else _v_invCntrl.label_amazon.BackColor = Color.LightGreen;
            };
            _m_externalInventoriesModel._fkImportedInventoryList.FkInventorySet += (l) =>
            {
                if (l.Count > 0) _v_invCntrl.label_flipkart.BackColor = Color.LimeGreen;
                else _v_invCntrl.label_flipkart.BackColor = Color.LightGreen;
            };
            _m_externalInventoriesModel._spdImportedInventoryList.SpdInventorySet += (l) =>
            {
                if (l.Count > 0) _v_invCntrl.label_snapdeal.BackColor = Color.LimeGreen;
                else _v_invCntrl.label_snapdeal.BackColor = Color.LightGreen;
            };
            _m_externalInventoriesModel._msoImportedInventoryList.MsoInventorySet += (l) =>
            {
                if (l.Count > 0) _v_invCntrl.label_meesho.BackColor = Color.LimeGreen;
                else _v_invCntrl.label_meesho.BackColor = Color.LightGreen;
            };
        }

        //Custom event, fires when grid control is loaded
        private void HandlessGridViewControlEvents()
        {//attach binding List changed events here
            _ssGridView.OnControlLoad += (gridview) => { 
                DisengageCellEvents();  EngageCellEvents(); DisableColumnEditingForSomeColumns(gridview);
                
            };
            _ssGridView.OnCellFormatting += (gridview,e) => { HighlightCell(gridview,e); };
            _ssGridView.ResetBindings += (e) => { ResetAllBindings(); };
            _ssGridView.SearchTitleTriggered += SearchTitle;
            _ssGridView.SearchTagTriggered += SearchTags;
        }


        internal void SearchTags(bool IsEnable, string textToSearch, BindingList<InventoryView> bindedProducts)
        {
            bindedProducts.Clear();

            _inventoryViewList.Where(y => !string.IsNullOrEmpty(y.Tag)).ToList().Where((x) =>
            //if(!string.IsNullOrEmpty(x.Tag))
            x.Tag.ToLower().Contains(textToSearch.ToLower())).ToList().
                ForEach(p => bindedProducts.Add(p)
                );
        }

        internal void SearchTitle(bool IsEnable, string textToSearch, BindingList<InventoryView> bindedProducts)
        {
            bindedProducts.Clear();
            _inventoryViewList.Where(x => x.Title.ToLower().Contains(textToSearch.ToLower())).ToList().
                ForEach(p => bindedProducts.Add(p));
        }

        private void HighlightCell(DataGridView grid, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value is Bitmap) return;
            var cellValue = e.Value.ToString(); 
            if (cellValue != null && Regex.IsMatch(e.Value.ToString(), @"orders:\d.*\|.*"))
                e.CellStyle.BackColor = Color.Yellow;
        }

        private void DisableColumnEditingForSomeColumns(DataGridView gridview)
        {
            foreach (DataGridViewColumn column in gridview.Columns) { column.ReadOnly = true; }
            gridview.Columns[Constants.InventoryViewCols.AmazonCount].ReadOnly = false;
            gridview.Columns[Constants.InventoryViewCols.FlipkartCount].ReadOnly = false;
            gridview.Columns[Constants.InventoryViewCols.SnapdealCount].ReadOnly = false;
            gridview.Columns[Constants.InventoryViewCols.MeeshoCount].ReadOnly = false;
        }

        internal void AssignViewManager(InvCntrl invUserControl) {
            _v_invCntrl = invUserControl;
            HandleProductControlEvents();
        }

        /// <summary>
        /// Hendles events generated by product usecontrol, this is one level up from datagridview usercontrol.
        /// </summary>
        private async void HandleProductControlEvents()
        {
            _v_invCntrl.importAmazonToolStripMenuItem.Click += async (s, e) => {  await ImportAmazonInv();  };
            _v_invCntrl.importFlipkartToolStripMenuItem.Click += async (s, e) => {await ImportFlipkartInv();  };
            _v_invCntrl.importSnapdealToolStripMenuItem.Click += async (s, e) => { await ImportSnapdealInv();  };
            _v_invCntrl.importMeeshoToolStripMenuItem.Click += async (s, e) => { await ImportMeeshoInv(); };
            _v_invCntrl.exportAllToolStripMenuItem.Click += (s, e) => { ExportAllInventoryUpdateFiles(); };
            
            _v_invCntrl.withPreviousInventoryUpdateToolStripMenuItem.Click += (s, e) => {
                if (((ToolStripMenuItem)s).Checked)
                    LoadSnapshotAndUpdateBindingListWithComparisons();
                else
                    ResetAllBindings();
            };
        }

       

        private void ExportAllInventoryUpdateFiles()
        {
            _m_invSnapShotModel.SaveInvSnapshot();
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                _m_externalInventoriesModel.ExportAmazonInventoryFile(folderPath);
                _m_externalInventoriesModel.ExportFlipkartInventoryFile(folderPath);
                _m_externalInventoriesModel.ExportSnapdealInventoryFile(folderPath);
                _m_externalInventoriesModel.ExportMeeshoInventoryFile(folderPath);

                // ...
            }
        }

        


        private void DisengageCellEvents()
        {
            _ssGridView.BindingListChanged -= _bindingListChanged;
        }


        private void UpdateInhouseInventory(BindingList<InventoryView> list,int index, string inHouseCode)
        {
            //update inhouse inv, changing property will trigger inhouse setter, and will update inhouse count in other companies
            if (string.IsNullOrWhiteSpace(list[index].InHouseCount)) list[index].InHouseCount = "0";
            int.TryParse(list[index].AmazonCount, out int acount);
            int.TryParse(list[index].FlipkartCount, out int fcount);
            int.TryParse(list[index].SnapdealCount, out int scount);
            int.TryParse(list[index].MeeshoCount, out int mcount);
            int.TryParse(list[index].InHouseCount, out int hcount);

            //_crossCompanyLinkedInventoryCount.Company1.LinkedInventoryCounts
            var item = _crossCompanyLinkedInventoryCount.linkedInv[_companyCode].FindProduct(inHouseCode);
            if (item != null)
            { item.AmzCount = acount; item.FkCount = fcount; item.SnpCount = scount; item.MesshoCount = mcount; }
            else
            {
                _crossCompanyLinkedInventoryCount.linkedInv[_companyCode].
                    LinkedInventoryCounts.Add(
                new CrossCompanyLinkedInventoryCount.LinkedInventoryList.LinkedProductInventory() 
                { AmzCount=acount, FkCount=fcount, SnpCount=scount, MesshoCount=mcount, LinkedInhouseCode=inHouseCode });
            }
            list[index].InHouseCount = _crossCompanyLinkedInventoryCount.GetTotalInventoryCountForAllCompanies(inHouseCode).ToString();
        }

        //Events generated by bindinglist changed event, these events are coming from setter of class: InventoryView properties
        //update underlying collection, when grid changes

        private void EngageCellEvents()
        {
           _bindingListChanged = (s, e) => {
               var list = s as BindingList<InventoryView>;
               
               if (e != null && e.PropertyDescriptor != null && e.PropertyDescriptor.Name == Constants.InventoryViewCols.AmazonCount)
               {
                   //if non-numeric value is entered by user.
                   if (!int.TryParse(list[e.NewIndex].AmazonCount, out int i)) { (new AlertBox("Wrong Input","Only numeric values are allowed")).ShowDialog();  return; }
                   
                   string asin = list[e.NewIndex].AmazonCode;
                   var invobj = _m_externalInventoriesModel._amzImportedInvList._amzInventoryList.FirstOrDefault(x => x.asin == asin);
                   if (invobj != null)
                   {
                       AmzInventoryV1 iamz = new AmzInventoryV1(
                           invobj.sku,
                           list[e.NewIndex].AmazonCode,
                           invobj.price,
                           list[e.NewIndex].AmazonSystemCount.ToString(),
                           list[e.NewIndex].AmazonCount.ToString());
                       _m_externalInventoriesModel._amzImportedInvList._amzModifiedInventoryList.Add(iamz);
                       //Update snapshot collection as well..
                       var snapshotObj =_m_invSnapShotModel._invSnapshotEntries.FirstOrDefault(x => x.ACode == invobj.asin);
                       if(snapshotObj != null)
                       {
                           snapshotObj.AInv = list[e.NewIndex].AmazonCount.ToString();
                           snapshotObj.ASystemInv = list[e.NewIndex].AmazonSystemCount.ToString();
                       }
                       UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
                       ////update inhouse inv, changing property will trigger inhouse setter, and will update inhouse count in other companies
                       //if(string.IsNullOrWhiteSpace(list[e.NewIndex].InHouseCount)) list[e.NewIndex].InHouseCount = "0";
                       //int.TryParse(list[e.NewIndex].AmazonCount, out int acount);
                       //int.TryParse(list[e.NewIndex].FlipkartCount, out int fcount);
                       //int.TryParse(list[e.NewIndex].SnapdealCount, out int scount);
                       //int.TryParse(list[e.NewIndex].MeeshoCount, out int mcount);
                       //list[e.NewIndex].InHouseCount = (acount+ fcount + scount + mcount).ToString();
                   }
               }
               if (e != null && e.PropertyDescriptor != null && e.PropertyDescriptor.Name == Constants.InventoryViewCols.FlipkartCount)
               {
                   //if non-numeric value is entered by user.
                   if (!int.TryParse(list[e.NewIndex].AmazonCount, out int i)) { (new AlertBox("Wrong Input", "Only numeric values are allowed")).ShowDialog(); return; }
                   string asin = list[e.NewIndex].FlipkartCode;
                   var invobj = _m_externalInventoriesModel._fkImportedInventoryList._fkInventoryList.FirstOrDefault(x => x.fsn == asin);
                   if (invobj != null)
                   {
                       FkInventoryV2 iamz = new FkInventoryV2(
                           invobj.sku,
                           list[e.NewIndex].FlipkartCode,
                           invobj.price,
                           list[e.NewIndex].FlipkartSystemCount.ToString(),
                           list[e.NewIndex].FlipkartCount.ToString());
                       _m_externalInventoriesModel._fkImportedInventoryList._fkUIModifiedInvList.Add(iamz);

                       var snapshotObj = _m_invSnapShotModel._invSnapshotEntries.FirstOrDefault(x => x.FCode == invobj.fsn);
                       if (snapshotObj != null)
                       {
                           snapshotObj.FInv = list[e.NewIndex].FlipkartCount.ToString();
                           snapshotObj.FSystemInv = list[e.NewIndex].FlipkartSystemCount.ToString();
                       }
                       UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
                       ////update inhouse inv, changing property will trigger inhouse setter, and will update inhouse count in other companies
                       //if (string.IsNullOrWhiteSpace(list[e.NewIndex].InHouseCount)) list[e.NewIndex].InHouseCount = "0";
                       //list[e.NewIndex].InHouseCount = (int.Parse(list[e.NewIndex].InHouseCount) + int.Parse(list[e.NewIndex].FlipkartCount)).ToString();
                   }
               }
               if (e != null && e.PropertyDescriptor != null && e.PropertyDescriptor.Name == Constants.InventoryViewCols.SnapdealCount)
               {
                   //if non-numeric value is entered by user.
                   if (!int.TryParse(list[e.NewIndex].AmazonCount, out int i)) { (new AlertBox("Wrong Input", "Only numeric values are allowed")).ShowDialog(); return; }
                   string asin = list[e.NewIndex].SnapdealCode;
                   var invobj = _m_externalInventoriesModel._spdImportedInventoryList._spdInventoryList.FirstOrDefault(x => x.fsn == asin);
                   if (invobj != null)
                   {
                       SpdInventoryV2 iamz = new SpdInventoryV2(
                           invobj.sku,
                           list[e.NewIndex].SnapdealCode,
                           invobj.price,
                           list[e.NewIndex].SnapdealSystemCount.ToString(),
                           list[e.NewIndex].SnapdealCount.ToString());
                       _m_externalInventoriesModel._spdImportedInventoryList._spdUIModifiedInvList.Add(iamz);

                       var snapshotObj = _m_invSnapShotModel._invSnapshotEntries.FirstOrDefault(x => x.SCode == invobj.fsn);
                       if (snapshotObj != null)
                       {
                           snapshotObj.SInv = list[e.NewIndex].SnapdealCount.ToString();
                           snapshotObj.SSystemInv = list[e.NewIndex].SnapdealSystemCount.ToString();
                       }
                       UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
                       //update inhouse inv, changing property will trigger inhouse setter, and will update inhouse count in other companies
                       //if (string.IsNullOrWhiteSpace(list[e.NewIndex].InHouseCount)) list[e.NewIndex].InHouseCount = "0";
                       //list[e.NewIndex].InHouseCount = (int.Parse(list[e.NewIndex].InHouseCount) + int.Parse(list[e.NewIndex].SnapdealCount)).ToString();
                   }
               }
               if (e != null && e.PropertyDescriptor != null && e.PropertyDescriptor.Name == Constants.InventoryViewCols.MeeshoCount)
               {
                   //if non-numeric value is entered by user.
                   if (!int.TryParse(list[e.NewIndex].AmazonCount, out int i)) { (new AlertBox("Wrong Input", "Only numeric values are allowed")).ShowDialog(); return; }
                   string asin = list[e.NewIndex].MeeshoCode;
                   var invobj = _m_externalInventoriesModel._msoImportedInventoryList._msoInventoryList.FirstOrDefault(x => x.fsn == asin);
                   if (invobj != null)
                   {
                       MsoInventoryV2 iamz = new MsoInventoryV2(
                           invobj.sku,
                           list[e.NewIndex].MeeshoCode,
                           invobj.price,
                           list[e.NewIndex].MeeshoSystemCount.ToString(),
                           list[e.NewIndex].MeeshoCount.ToString());
                       _m_externalInventoriesModel._msoImportedInventoryList._msoUIModifiedInvList.Add(iamz);
                   }

                   var snapshotObj = _m_invSnapShotModel._invSnapshotEntries.FirstOrDefault(x => x.MCode == invobj.fsn);
                   if (snapshotObj != null)
                   {
                       snapshotObj.MInv = list[e.NewIndex].MeeshoCount.ToString();
                       snapshotObj.MSystemInv = list[e.NewIndex].MeeshoSystemCount.ToString();
                   }
                   UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
                   ////update inhouse inv, changing property will trigger inhouse setter, and will update inhouse count in other companies
                   //if (string.IsNullOrWhiteSpace(list[e.NewIndex].InHouseCount)) list[e.NewIndex].InHouseCount = "0";
                   //list[e.NewIndex].InHouseCount = (int.Parse(list[e.NewIndex].InHouseCount) + int.Parse(list[e.NewIndex].MeeshoCount)).ToString();
               }
           };
            _ssGridView.BindingListChanged += _bindingListChanged;
        }


        private async Task ResetAllBindings()
        {
            DisengageCellEvents();
            _ssGridView.ClearBindingListRows();
            
            _ssGridView.IsLoading = true;
            await AssignAmazonInvAndPricesToInvView();
            await AssignFlipkartInvAndPricesToInvView();
            await AssignSnapdealInvAndPricesToInvView();
            await AssignMeeshoInvAndPricesToInvView();

            _ssGridView.IsLoading = false;
            _ssGridView.UpdateBindings();
            EngageCellEvents();
        }

        private async Task ImportAmazonInv()
        {
            DisengageCellEvents();
            _ssGridView.ClearBindingListRows();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Amazon inv text file|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                _m_externalInventoriesModel.ImportAmazonInventoryFile(openFileDialog.FileName);
            else return;
            _ssGridView.IsLoading = true;
            await AssignAmazonInvAndPricesToInvView();
            _ssGridView.IsLoading = false;
            _ssGridView.UpdateBindings();
            EngageCellEvents();
        }

        private async Task ImportFlipkartInv()
        {
            DisengageCellEvents();
            _ssGridView.ClearBindingListRows();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Flipkart inv file|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                _m_externalInventoriesModel.ImportFlipkartInventoryFile(openFileDialog.FileName);
            else return;
            _ssGridView.IsLoading = true;
            await AssignFlipkartInvAndPricesToInvView();
            _ssGridView.IsLoading = false;
            _ssGridView.UpdateBindings();
            EngageCellEvents() ;    
        }

        private async Task ImportSnapdealInv()
        {
            DisengageCellEvents();
            _ssGridView.ClearBindingListRows();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Snapdeal inv file|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                _m_externalInventoriesModel.ImportSnapdealInventoryFile(openFileDialog.FileName);
            else return;
            _ssGridView.IsLoading = true;
            await AssignSnapdealInvAndPricesToInvView();
            _ssGridView.IsLoading = false;
            _ssGridView.UpdateBindings();
            EngageCellEvents();
        }

        private async Task ImportMeeshoInv()
        {
            DisengageCellEvents();
            _ssGridView.ClearBindingListRows();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Meesho inv file|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                _m_externalInventoriesModel.ImportMeeshoInventoryFile(openFileDialog.FileName);
            else return;
            _ssGridView.IsLoading = true;
            await AssignMeeshoInvAndPricesToInvView();
            _ssGridView.IsLoading = false;
            _ssGridView.UpdateBindings();
            EngageCellEvents();
        }


        internal void AssignImagesToProducts(Dictionary<string, Image> imgs)
        {
            foreach (var item in _inventoryViewList)
            {
                if (imgs.ContainsKey(item.InHouseCode))
                    item.Image = imgs[item.InHouseCode];

            }
        }

        private Task AssignAmazonInvAndPricesToInvView()
        {
           return Task.Run(() =>
            {
                foreach (var amzItem in _m_externalInventoriesModel._amzImportedInvList._amzInventoryList)
                {
                    foreach (var viewItem in _inventoryViewList)
                    {
                        if (!string.IsNullOrWhiteSpace(viewItem.AmazonCode) && !string.IsNullOrWhiteSpace(amzItem.asin) &&
                        amzItem.asin.Trim().ToLower() == viewItem.AmazonCode.Trim().ToLower() 
                        && int.TryParse(amzItem.systemQuantity, out int val))
                        {
                            string sval = string.Empty;
                            if(val!=0) sval = Convert.ToString(val);
                            viewItem.AmazonSystemCount = sval;
                            viewItem.AmazonCount = sval;

                            //update snapshot as well
                            var snapshotObj = _m_invSnapShotModel._invSnapshotEntries.FirstOrDefault(x => x.ACode == viewItem.AmazonCode);
                            if (snapshotObj != null)
                            {
                                snapshotObj.AInv = viewItem.AmazonCount;
                                snapshotObj.ASystemInv = viewItem.AmazonSystemCount;
                            }
                        }
                    }
                }

                
            });


        }

        private Task AssignFlipkartInvAndPricesToInvView()
        {
            return Task.Run(() =>
            {
                foreach (var fkItem in _m_externalInventoriesModel._fkImportedInventoryList._fkInventoryList)
                {
                    foreach (var viewItem in _inventoryViewList)
                    {
                        if (fkItem.fsn == viewItem.FlipkartCode && int.TryParse(fkItem.systemQuantity, out int val))
                        {
                            string sval = string.Empty;
                            if (val != 0) sval = Convert.ToString(val);
                            viewItem.FlipkartSystemCount = sval;
                            viewItem.FlipkartCount = sval;
                        }
                    }
                }
            });

        }

        private Task AssignSnapdealInvAndPricesToInvView()
        {
            return Task.Run(() =>
            {
                foreach (var spdItem in _m_externalInventoriesModel._spdImportedInventoryList._spdInventoryList)
                {
                    foreach (var viewItem in _inventoryViewList)
                    {
                        if (spdItem.fsn == viewItem.SnapdealCode && int.TryParse(spdItem.systemQuantity, out int val))
                        {
                            string sval = string.Empty;
                            if (val != 0) sval = Convert.ToString(val);
                            viewItem.SnapdealSystemCount = sval;
                            viewItem.SnapdealCount = sval;
                        }
                    }
                }
            });

        }

        private Task AssignMeeshoInvAndPricesToInvView()
        {
            return Task.Run(() =>
            {
                foreach (var msoItem in _m_externalInventoriesModel._msoImportedInventoryList._msoInventoryList)
                {
                    foreach (var viewItem in _inventoryViewList)
                    {
                        if (msoItem.fsn == viewItem.MeeshoCode && int.TryParse(msoItem.systemQuantity, out int val))
                        {
                            string sval = string.Empty;
                            if (val != 0) sval = Convert.ToString(val);
                            viewItem.MeeshoSystemCount = sval;
                            viewItem.MeeshoCount = sval;
                        }
                    }
                }
            });
        }


       
        

        internal class InventoryView : INotifyPropertyChanged
        {
            private string _amazonCount;
            private string _snpSystemCount;
            private string _amazonSystemCount;
            private string _flipkartSystemCount;
            private string _meeshoSystemCount;
            private string _flipkartCount;
            private string _snapdealCount;
            private string _meeshoCount;
            private string _inhouseCount;
            private string _notes;

            //private bool _pin;
            //private bool _highlightV1;

            //below values from Product 
            public string InHouseCode { get; set; }
            public Image Image { get; set; }
            public string Title { get; set; }
            public string Tag { get; set; }

            //internal void PinThisCell() {          }
            //internal void PinThisCell() { }

            //below values fron InvUpdate
            public string InHouseCount
            {
                get { return _inhouseCount; }
                set { if (value != this._inhouseCount) { _inhouseCount = value; NotifyPropertyChanged(); } }
            }
            public string AmazonCount { 
                get { return _amazonCount; } 
                set { if (value != this._amazonCount) { _amazonCount = value; NotifyPropertyChanged(); } } 
            }
            public string AmazonSystemCount {
                get { return _amazonSystemCount; }
                set { if (value != this._amazonSystemCount) { _amazonSystemCount = value; NotifyPropertyChanged(); } }
            }
            public string FlipkartCount
            {
                get { return _flipkartCount; }
                set { if (value != this._flipkartCount) { _flipkartCount = value; NotifyPropertyChanged(); } }
            }
            public string FlipkartSystemCount
            {
                get { return _flipkartSystemCount; }
                set { if (value != this._flipkartSystemCount) { _flipkartSystemCount = value; NotifyPropertyChanged(); } }
            }
            public string SnapdealCount
            {
                get { return _snapdealCount; }
                set { if (value != this._snapdealCount) { _snapdealCount = value; NotifyPropertyChanged(); } }
            }
            public string SnapdealSystemCount
            {
                get { return _snpSystemCount; }
                set { if (value != this._snpSystemCount) { _snpSystemCount = value; NotifyPropertyChanged(); } }
            }
            public string MeeshoCount
            {
                get { return _meeshoCount; }
                set { if (value != this._meeshoCount) { _meeshoCount = value; NotifyPropertyChanged(); } }
            }
            public string MeeshoSystemCount
            {
                get { return _meeshoSystemCount; }
                set { if (value != this._meeshoSystemCount) { _meeshoSystemCount = value; NotifyPropertyChanged(); } }
            }
            
            public string Notes
            {
                get { return _notes; }
                set { if (value != this._notes) { _notes = value; NotifyPropertyChanged(); } }
            }

            //below values from Product
            public string AmazonCode { get; set; }
            public string FlipkartCode { get; set; }
            public string SnapdealCode { get; set; }
            public string MeeshoCode { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;

            // This method is called by the Set accessor of each property.  
            // The CallerMemberName attribute that is applied to the optional propertyName  
            // parameter causes the property name of the caller to be substituted as an argument.  
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            //public string[] ModifiedFields { get; set; }
        }

    } 
}
