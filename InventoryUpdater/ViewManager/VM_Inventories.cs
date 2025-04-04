﻿using CommonUtil;
using Decoders;
using Decoders.Interfaces;
using SellerSense.Helper;
using SellerSense.Model;
using SellerSense.Model.InvUpdate;
using SellerSense.Model.Orders;
using SellerSense.Views;
using SellerSense.Views.Inventories;
using ssViewControls;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CommonUtil.Constants;
//using static SellerSense.Constants;
using static SellerSense.ViewManager.VM_Companies;
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
        internal M_Orders _m_OrdersModel { get; set; }
        internal M_Snapshot _m_invSnapShotModel_Amz { get; set; }
        internal M_Snapshot _m_invSnapShotModel_Fk { get; set; }
        internal M_Snapshot _m_invSnapShotModel_Spd { get; set; }
        internal M_Snapshot _m_invSnapShotModel_Mso { get; set; }
        internal M_Product _m_productModel { get; set; }
        private string _companyCode { get; set; }
        //internal DataSet _invUpdateGridData { get; set; }
        private InvCntrl _v_invCntrl;
        //private Action InvokeUpdateInventoryInAllCompanies;
        private ssGrid.ssGridView<InventoryView> _ssGridView;
        private Action<Object, ListChangedEventArgs> _bindingListChanged;
        internal ObservableCollection<InventoryView> _inventoryViewListBackUp { get; set; }
        internal ObservableCollection<InventoryView> _inventoryViewList { get; set; }
        internal bool _is_filtered = false;
        private VM_Companies.CrossCompanySharedWrapper _crossCompanySharedWrapper;
        private VM_Companies.CrossCompanyEvents _crossCompanyEvents;

        public VM_Inventories(M_External_Inventories inventories, M_Product m_product,
           VM_Companies.CrossCompanySharedWrapper crossCompanySharedWrapper, string companyCode,
            VM_Companies.CrossCompanyEvents crossCompanyEvents)
        {
            _crossCompanyEvents = crossCompanyEvents;
            _companyCode = companyCode;
            _crossCompanySharedWrapper = crossCompanySharedWrapper;
            _m_externalInventoriesModel = inventories;
            _m_OrdersModel = new M_Orders(companyCode);
            _m_productModel = m_product;
            _m_invSnapShotModel_Amz = new M_Snapshot(_companyCode, M_Snapshot.Site.amz);
            _m_invSnapShotModel_Spd = new M_Snapshot(_companyCode, M_Snapshot.Site.spd);
            _m_invSnapShotModel_Fk = new M_Snapshot(_companyCode, M_Snapshot.Site.fk);
            _m_invSnapShotModel_Mso = new M_Snapshot(_companyCode, M_Snapshot.Site.mso);
            TranslateInvModelToInvView();
            //HandleExternalInventoryImportEvents();
            //InvokeUpdateInventoryInAllCompanies = UpdateInventoryInAllCompaniesAction;
            //UpdateInventoryInAllCompaniesAction+=       
            _crossCompanyEvents.CrossCompanySharedInventoryUpdated += (s, e) => { UpdateCrossCompanySharedInvForThisCompany(); };
            //crossCompanyEvents.CrossCompanySharedInventoryUpdated += _crossCompanyEvents_CrossCompanySharedInventoryUpdated;
            //_inventoryViewList.CollectionChanged += (s, e) => { InventoryViewListChanged(e); };
        }




        internal void BindDatagridEvents(SfDataGrid datagrid)
        {
            datagrid.CellDoubleClick += (s, e) =>
            {
                if (datagrid.CurrentCell.Column.MappingName == Constants.MCols.amz_Code)
                    AmazonInvDecoder.OpenProductSearchURL(ssGrid.SyncFusionHelper.GetCellValue(datagrid, datagrid.CurrentCell.RowIndex, datagrid.CurrentCell.ColumnIndex).ToString());
                if (datagrid.CurrentCell.Column.MappingName == Constants.MCols.fK_Code)
                    FlipkartInvDecoder.OpenProductSearchURL(ssGrid.SyncFusionHelper.GetCellValue(datagrid, datagrid.CurrentCell.RowIndex, datagrid.CurrentCell.ColumnIndex).ToString());
                if (datagrid.CurrentCell.Column.MappingName == Constants.MCols.spd_Code)
                    SnapdealInvDecoder.OpenProductSearchURL(ssGrid.SyncFusionHelper.GetCellValue(datagrid, datagrid.CurrentCell.RowIndex, datagrid.CurrentCell.ColumnIndex).ToString());
                if (datagrid.CurrentCell.Column.MappingName == Constants.MCols.mso_Code)
                    MeeshoInvDecoder.OpenProductSearchURL(ssGrid.SyncFusionHelper.GetCellValue(datagrid, datagrid.CurrentCell.RowIndex, datagrid.CurrentCell.ColumnIndex).ToString());
            };

        }



        //private void InventoryViewListChanged(NotifyCollectionChangedEventArgs e)
        //{
        //   if( e.Action == NotifyCollectionChangedAction.Replace)
        //    {
        //        if(_inventoryViewList.Any(x=>!string.IsNullOrEmpty(x.AmazonSystemCount)))
        //            _v_invCntrl.label_amazon.BackColor = Color.LimeGreen;
        //        else _v_invCntrl.label_amazon.BackColor = Color.LightGreen;
        //    }
        //}

        private void TranslateInvModelToInvView()
        {
            _inventoryViewList = new ObservableCollection<InventoryView>();
            foreach (var item in _m_productModel._productEntries)
            {

                var inv = new InventoryView()
                {
                    InHouseCode = item.InHouseCode,
                    Title = item.Title,
                    Tag = item.Tag,
                    Image = null,
                    AmazonCode = item.AmazonCode,
                    FlipkartCode = item.FlipkartCode,
#if IncludeMeesho
                    MeeshoCode = item.MeeshoCode,
#endif                    
                    SnapdealCode = item.SnapdealCode,
                    //CostPrice = item.CostPrice
                };


                inv.PropertyChanged += (s,e) => {

                    ViewPropertyChnageHandler(s as InventoryView,e);
                };

                //binding list source for grid
                _inventoryViewList.Add(inv);

            }
        }



        private void ViewPropertyChnageHandler(InventoryView invViewObj, PropertyChangedEventArgs e)
        {
            //var list = s as BindingList<InventoryView>;

            if (e != null && e.PropertyName == Constants.InventoryViewCols.AmazonCount)
            {
                //if non-numeric value is entered by user.
                //TODO : Enter validation in grid column for numeric input.
                //if (!int.TryParse(list[e.NewIndex].AmazonCount, out int i)) {
                //    (new AlertBox("Wrong Input", "Only numeric values are allowed")).ShowDialog(); return; }

                string asin = invViewObj.AmazonCode;
                var invobj = _m_externalInventoriesModel._amzImportedInvList._amzInventoryList.FirstOrDefault(x => x.asin == asin);
                if (invobj != null)
                {
                    AmzInventoryV1 iamz = new AmzInventoryV1(
                        invobj.sku,
                        invViewObj.AmazonCode,
                        invobj.price,
                        invViewObj.AmazonSystemCount.ToString(),
                        invViewObj.AmazonCount.ToString());

                    if (_m_externalInventoriesModel._amzImportedInvList._amzModifiedInventoryList.Any(x => x.asin == invViewObj.AmazonCode))
                    {
                        var obj = _m_externalInventoriesModel._amzImportedInvList._amzModifiedInventoryList.First(x => x.asin == invViewObj.AmazonCode);
                        if (obj != null)
                            _m_externalInventoriesModel._amzImportedInvList._amzModifiedInventoryList.Remove(obj);
                    }
                    _m_externalInventoriesModel._amzImportedInvList._amzModifiedInventoryList.Add(iamz);
                    //This is important to update inventory for this company first,
                    //then update other companies. Else other company wont reflect changes made in currnt company
                    //UpdateCrossCompanySharedInvForThisCompany();
                    _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();


                    //TODO : composition products functionality is not yet ready.
                    foreach (var item in _inventoryViewList)
                        UpdateComposedChildProducts(item.InHouseCode);
                }
            }
            if (e != null && e.PropertyName == Constants.InventoryViewCols.FlipkartCount)
            {
                ////if non-numeric value is entered by user.
                //if (!int.TryParse(list[e.NewIndex].FlipkartCount, out int i)) { (new AlertBox("Wrong Input", "Only numeric values are allowed")).ShowDialog(); return; }
                string asin = invViewObj.FlipkartCode;
                var invobj = _m_externalInventoriesModel._fkImportedInventoryList._fkInventoryList.FirstOrDefault(x => x.fsn == asin);
                if (invobj != null)
                {
                    string syscount = invViewObj.FlipkartSystemCount;
                    if (syscount == null)
                        syscount = string.Empty;
                    FkInventoryV2 iamz = new FkInventoryV2(
                        invobj.sku,
                        invViewObj.FlipkartCode,
                        invobj.price,
                        syscount,
                        invViewObj.FlipkartCount.ToString());
                    _m_externalInventoriesModel._fkImportedInventoryList._fkUIModifiedInvList.Add(iamz);
                    //UpdateCrossCompanySharedInvForThisCompany();
                    _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
                    //_ssGridView.UpdateBindings();
                    //UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
                }
            }
            if (e != null && e.PropertyName == Constants.InventoryViewCols.SnapdealCount)
            {
                //if non-numeric value is entered by user.
                //if (!int.TryParse(list[e.NewIndex].AmazonCount, out int i)) { (new AlertBox("Wrong Input", "Only numeric values are allowed")).ShowDialog(); return; }
                string asin = invViewObj.SnapdealCode;
                var invobj = _m_externalInventoriesModel._spdImportedInventoryList._spdInventoryList.FirstOrDefault(x => x.fsn == asin);
                if (invobj != null)
                {
                    SpdInventoryV2 iamz = new SpdInventoryV2(
                        invobj.sku,
                        invViewObj.SnapdealCode,
                        invobj.price,
                        invViewObj.SnapdealSystemCount.ToString(),
                        invViewObj.SnapdealCount.ToString());
                    _m_externalInventoriesModel._spdImportedInventoryList._spdUIModifiedInvList.Add(iamz);
                    //UpdateCrossCompanySharedInvForThisCompany();
                    _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
                    //_ssGridView.UpdateBindings();
                    //UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
                }
            }
        }



        //private void _crossCompanyEvents_CrossCompanySharedInventoryUpdated(object sender, EventArgs e)
        //{
        //    _inventoryViewList.ForEach(x => x.InHouseCount =
        //    _crossCompanySharedWrapper._crossCompanyLinkedInventoryCount.GetAllInventoriesFromAllCompanies(x.InHouseCode).ToString());
        //}


        public UserControl AssignView(VM_Company company)
        {
            _ssGridView = new ssGrid.ssGridView<VM_Inventories.InventoryView>(company._inventoriesViewManager._inventoryViewList, HandlessGridViewControlEvents);
            _ssGridView.Dock = DockStyle.Fill;
            
            //HandlessGridViewControlEvents();
            return _ssGridView;
        }

        //private void HandleExternalInventoryImportEvents()
        //{
        //    if (_v_invCntrl == null) return; //Fixed a bug, this was getting called from product screen.
        //    _m_externalInventoriesModel._amzImportedInvList.AmzInventorySet += (list) =>
        //    {   
        //        if (list.Count > 0) _v_invCntrl.label_amazon.BackColor = Color.LimeGreen;
        //        else _v_invCntrl.label_amazon.BackColor = Color.LightGreen;
        //    };
        //    _m_externalInventoriesModel._fkImportedInventoryList.FkInventorySet += (l) =>
        //    {
        //        if (l.Count > 0) _v_invCntrl.label_flipkart.BackColor = Color.LimeGreen;
        //        else _v_invCntrl.label_flipkart.BackColor = Color.LightGreen;
        //    };
        //    _m_externalInventoriesModel._spdImportedInventoryList.SpdInventorySet += (l) =>
        //    {
        //        if (l.Count > 0) _v_invCntrl.label_snapdeal.BackColor = Color.LimeGreen;
        //        else _v_invCntrl.label_snapdeal.BackColor = Color.LightGreen;
        //    };
        //    _m_externalInventoriesModel._msoImportedInventoryList.MsoInventorySet += (l) =>
        //    {
        //        if (l.Count > 0) _v_invCntrl.label_meesho.BackColor = Color.LimeGreen;
        //        else _v_invCntrl.label_meesho.BackColor = Color.LightGreen;
        //    };
        //}

        //Custom init/event, fires when grid control is loaded
        private void HandlessGridViewControlEvents(SfDataGrid grid)
        {
            //attach binding List changed events here
            DisableColumnEditingForSomeColumns(grid);
            grid.Columns[Constants.InventoryViewCols.AmazonOrders].CellStyle.BackColor = Color.Silver;
            grid.Columns[Constants.InventoryViewCols.FlipkartOrders].CellStyle.BackColor = Color.Silver;
            grid.Columns[Constants.InventoryViewCols.SnapdealOrders].CellStyle.BackColor = Color.Silver;

            BindDatagridEvents(grid);
        }


        //internal void SearchTags(bool IsEnable, string textToSearch, BindingList<InventoryView> bindedProducts)
        //{
        //    bindedProducts.Clear();

        //    _inventoryViewList.Where(y => !string.IsNullOrEmpty(y.Tag)).ToList().Where((x) =>
        //    //if(!string.IsNullOrEmpty(x.Tag))
        //    x.Tag.ToLower().Contains(textToSearch.ToLower())).ToList().
        //        ForEach(p => bindedProducts.Add(p)
        //        );
        //}

        //internal void SearchTitle(bool IsEnable, string textToSearch, BindingList<InventoryView> bindedProducts)
        //{
        //    bindedProducts.Clear();
        //    _inventoryViewList.Where(x => x.Title.ToLower().Contains(textToSearch.ToLower())).ToList().
        //        ForEach(p => bindedProducts.Add(p));
        //}

        //private void HighlightCell(DataGridView grid, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (e.Value == null || e.Value is Bitmap) return;
        //    var cellValue = e.Value.ToString(); 
            
        //    if (cellValue != null && Regex.IsMatch(e.Value.ToString(), @"(?<=\.(orders))"))
        //        e.CellStyle.BackColor = Color.Yellow;
        //}

        private void DisableColumnEditingForSomeColumns(SfDataGrid gridview)
        {
            if (gridview == null)
                return;
            try
            {
                foreach (var column in gridview.Columns) {if(column!=null) column.AllowEditing = false; }
                gridview.Columns[Constants.InventoryViewCols.AmazonCount].AllowEditing = true;
                gridview.Columns[Constants.InventoryViewCols.FlipkartCount].AllowEditing = true;
                gridview.Columns[Constants.InventoryViewCols.SnapdealCount].AllowEditing = true;
                
            }
            catch (Exception)
            {
                Logger.Log("Error while diabaling cols", Logger.LogLevel.warning, true);
            }

        }

        internal void AssignViewManager(InvCntrl invUserControl) {
            _v_invCntrl = invUserControl;
            HandleProductControlEvents();
        }

        /// <summary>
        /// <summary>
        /// Hendles events generated by product usecontrol, this is one level up from datagridview usercontrol.
        /// </summary>
        private async void HandleProductControlEvents()
        {
            _v_invCntrl.importAmazonToolStripMenuItem.Click += async (s, e) => {  await ImportAmazonInv();  };
            _v_invCntrl.importFlipkartToolStripMenuItem.Click += async (s, e) => {await ImportFlipkartInv();  };
            _v_invCntrl.importSnapdealToolStripMenuItem.Click += async (s, e) => { await ImportSnapdealInv();  };
            _v_invCntrl.importAmazonFileOnlineToolStripMenuItem.Click += async (s, e) => { await ImportAmazonInv(isOnline:true);  };
            _v_invCntrl.importShelfStockToolStripMenuItem.Click += async (s, e) => { await ImportShelfInv();  };

            
#if IncludeMeesho
            _v_invCntrl.importMeeshoToolStripMenuItem.Click += async (s, e) => { await ImportMeeshoInv(); };
#endif
            _v_invCntrl.exportAllToolStripMenuItem.Click += (s, e) => { ExportAllInventoryUpdateFiles(); };
            _v_invCntrl.sendInvStatusToolStripMenuItem.Click += (s, e) => { SendStockStatusForThisCompany(); };
            _v_invCntrl.importAmazonOrdersToolStripMenuItem.Click += async (s, e) => { await ImportAmazonOrders(); };
            _v_invCntrl.appendAmazonOrdersOnlineToolStripMenuItem.Click += async (s, e) => { await ImportAmazonOrders(isOnline:true); };
            //_v_invCntrl.appendAmazonOrdersToolStripMenuItem.Click += async (s, e) => { await ImportAmazonOrders(true); };
            _v_invCntrl.importFlipkartOrdersToolStripMenuItem.Click += async (s, e) => { await ImportFlipkartOrders(); };
            _v_invCntrl.importSnapdealOrdersToolStripMenuItem.Click += async (s, e) => { await ImportSnapdealOrders(); };
           // _v_invCntrl.ordersToolStripMenuItem.Click += (s, e) => { };
//            _v_invCntrl.sendTotalOrderCountToolStripMenuItem.Click += (s, e) => { SendTotalOrderReport(); };
//            _v_invCntrl.allToolStripMenuItem_lastDay.Click += (s, e) => { 
//                CompareAmz_InvWithCurrentSnapshot();
//                CompareFk_InvWithCurrentSnapshot();
//                CompareSpd_InvWithCurrentSnapshot();
//#if IncludeMeesho
//                CompareMso_InvWithCurrentSnapshot();
//#endif
//            };
//            _v_invCntrl.lastDayToolStripMenuItemAmz.Click += (s, e) => { CompareAmz_InvWithCurrentSnapshot(); };
//            _v_invCntrl.lastDayToolStripMenuItemFk.Click += (s, e) => { CompareFk_InvWithCurrentSnapshot(); };
//            _v_invCntrl.lastDayToolStripMenuItemSpd.Click += (s, e) => { CompareSpd_InvWithCurrentSnapshot(); };
//#if IncludeMeesho
//            _v_invCntrl.lastDayToolStripMenuItemMso.Click += (s, e) => { CompareMso_InvWithCurrentSnapshot(); };
//#endif
//            _v_invCntrl.customDateToolStripMenuItemAmz.Click += (s, e) => {
//                VM_CustomSnapshotDate vm_snap = new VM_CustomSnapshotDate(Company.Amazon, _m_invSnapShotModel_Amz);
//                CustomSnapshotDate cd = new CustomSnapshotDate(vm_snap);
//                cd.ShowDialog();
//                Compare_CustomDateSnapshots(vm_snap.SelectedDate1, vm_snap.SelectedDate2, Constants.Company.Amazon); };

//            _v_invCntrl.customDateToolStripMenuItemFk.Click += (s, e) => {
//                VM_CustomSnapshotDate vm_snap = new VM_CustomSnapshotDate(Company.Flipkart, _m_invSnapShotModel_Fk);
//                CustomSnapshotDate cd = new CustomSnapshotDate(vm_snap);
//                cd.ShowDialog();
//                Compare_CustomDateSnapshots(vm_snap.SelectedDate1, vm_snap.SelectedDate2, Constants.Company.Flipkart);
//            };

//            _v_invCntrl.customDateToolStripMenuItemSpd.Click += (s, e) => {
//                VM_CustomSnapshotDate vm_snap = new VM_CustomSnapshotDate(Company.Snapdeal, _m_invSnapShotModel_Spd);
//                CustomSnapshotDate cd = new CustomSnapshotDate(vm_snap);
//                cd.ShowDialog();
//                Compare_CustomDateSnapshots(vm_snap.SelectedDate1, vm_snap.SelectedDate2, Constants.Company.Snapdeal);
//            };

            _v_invCntrl.splitButton_adv_filter.DropDownItems[0].Click += (s, e) => {
                if (_is_filtered == false) // not filtered, copy original in backup
                    CopyInvListToBackUp();
                else
                { CopyBackUpToInvList(); _is_filtered = false; }
                ObservableCollection<InventoryView> filteredValues = new ObservableCollection<InventoryView>();
                _inventoryViewList.Where(x => x.AmazonOrders!=null && 
                !string.IsNullOrEmpty(x.AmazonOrders.ToLower()) && 
                x.AmazonOrders.ToLower().Length > 0).ToList().ForEach(p => 
                { if (!filteredValues.Contains(p,InventoryView.Comparer)) filteredValues.Add(p); }) ;

                _inventoryViewList.Where(x => x.FlipkartOrders != null &&
                !string.IsNullOrEmpty(x.FlipkartOrders.ToLower()) &&
                x.FlipkartOrders.ToLower().Length > 0).ToList().ForEach(p =>
                { if (!filteredValues.Contains(p, InventoryView.Comparer)) filteredValues.Add(p); });

                _inventoryViewList.Where(x => x.SnapdealOrders != null &&
                !string.IsNullOrEmpty(x.SnapdealOrders.ToLower()) &&
                x.SnapdealOrders.ToLower().Length > 0).ToList().ForEach(p =>
                { if (!filteredValues.Contains(p, InventoryView.Comparer)) filteredValues.Add(p); });
                _inventoryViewList.Clear();

                foreach (var item in filteredValues)
                    _inventoryViewList.Add(item);
                _v_invCntrl.splitButton_adv_filter.DropDownItems[0].Checked = true;
                _v_invCntrl.splitButton_adv_filter.DropDownItems[1].Checked = false;
                _v_invCntrl.splitButton_adv_filter.DropDownItems[2].Checked = false;
                _is_filtered = true;
            };
            _v_invCntrl.splitButton_adv_filter.DropDownItems[1].Click += (s, e) => {
                if (_is_filtered == false) // not filtered, copy original in backup
                    CopyInvListToBackUp();
                else
                { CopyBackUpToInvList(); _is_filtered = false; }

                ObservableCollection<InventoryView> filteredValues = new ObservableCollection<InventoryView>();
                _inventoryViewList.Where(x => string.IsNullOrEmpty(x.AmazonOrders) && string.IsNullOrEmpty(x.FlipkartOrders) 
                && string.IsNullOrEmpty(x.SnapdealOrders)).ToList().ForEach(p =>
                { if (!filteredValues.Contains(p)) filteredValues.Add(p); });
                
                _inventoryViewList.Clear();

                foreach (var item in filteredValues)
                    _inventoryViewList.Add(item);

                _v_invCntrl.splitButton_adv_filter.DropDownItems[0].Checked = false;
                _v_invCntrl.splitButton_adv_filter.DropDownItems[1].Checked = true;
                _v_invCntrl.splitButton_adv_filter.DropDownItems[2].Checked = false;
                _is_filtered = true;
            };

            _v_invCntrl.splitButton_adv_filter.DropDownItems[2].Click += (s, e) =>
            {
                if (_is_filtered == false) // not filtered, copy original in backup
                    CopyInvListToBackUp();
                else
                { CopyBackUpToInvList(); _is_filtered = false; }

                _v_invCntrl.splitButton_adv_filter.DropDownItems[0].Checked = false;
                _v_invCntrl.splitButton_adv_filter.DropDownItems[1].Checked = false;
                _v_invCntrl.splitButton_adv_filter.DropDownItems[2].Checked = true;
            };

            //unmapped products
            //_v_invCntrl.splitButton_adv_filter.DropDownItems[3].Click += (s, e) =>
            //{
            //    CheckForUnmappedAmazonProducts();
            //};

#if IncludeMeesho
            _v_invCntrl.customDateToolStripMenuItemMso.Click += (s, e) => {
                VM_CustomSnapshotDate vm_snap = new VM_CustomSnapshotDate(Company.Meesho, _m_invSnapShotModel_Mso);
                CustomSnapshotDate cd = new CustomSnapshotDate(vm_snap);
                cd.ShowDialog();
                Compare_CustomDateSnapshots(vm_snap.SelectedDate1, vm_snap.SelectedDate2, Constants.Company.Meesho);
            };
#endif

        }

        private void CopyInvListToBackUp()
        {
            if (_inventoryViewList == null || _inventoryViewList.Count == 0)
                return;
            _inventoryViewListBackUp = new ObservableCollection<InventoryView>();
            foreach (var item in _inventoryViewList)
                _inventoryViewListBackUp.Add(item);
        }

        private void CopyBackUpToInvList()
        {
            if (_inventoryViewListBackUp == null || _inventoryViewListBackUp.Count == 0)
                return;
            _inventoryViewList.Clear();
            foreach (var item in _inventoryViewListBackUp)
                _inventoryViewList.Add(item);
        }

        //This method send out of stock items, low inv items etc..
        private void SendStockStatusForThisCompany()
        {
            _crossCompanySharedWrapper.SendCrossCompanyInventoryStatus();
            return;

        }

        private string FormatListItem(string key, string value)
        {
            return (string.Format("{0} {1}", key, value));
        }

        private void SendTotalOrderReport()
        {
            //Send order to telegram
            _crossCompanySharedWrapper.SendCrossCompanyTodaysOrderReport();
        }


        private void ExportAllInventoryUpdateFiles()
        {
            
            _m_invSnapShotModel_Amz.SaveInvSnapshot(_m_externalInventoriesModel._amzImportedInvList._amzInventoryList, 
                _m_externalInventoriesModel._amzImportedInvList._amzModifiedInventoryList,
                saveOnlySystemInventory:false);
            _m_invSnapShotModel_Fk.SaveInvSnapshot(_m_externalInventoriesModel._fkImportedInventoryList._fkInventoryList, 
                _m_externalInventoriesModel._fkImportedInventoryList._fkUIModifiedInvList,
                saveOnlySystemInventory: false);
            _m_invSnapShotModel_Spd.SaveInvSnapshot(_m_externalInventoriesModel._spdImportedInventoryList._spdInventoryList,
                _m_externalInventoriesModel._spdImportedInventoryList._spdUIModifiedInvList,
                saveOnlySystemInventory: false);
#if IncludeMeesho
            _m_invSnapShotModel_Mso.SaveInvSnapshot(_m_externalInventoriesModel._msoImportedInventoryList._msoInventoryList, 
                _m_externalInventoriesModel._msoImportedInventoryList._msoUIModifiedInvList,
                saveOnlySystemInventory: false);
#endif
            //OpenFileDialog folderBrowser = new OpenFileDialog();
            //// Set validate names and check file exists to false otherwise windows will
            //// not let you select "Folder Selection."
            //folderBrowser.ValidateNames = false;
            //folderBrowser.CheckFileExists = false;
            //folderBrowser.CheckPathExists = true;
            //// Always default to Folder Selection.
            //folderBrowser.FileName = "Folder Selection";

            string folderPath = ProjIO.OpenFolderSelectionDialog();
            if (!string.IsNullOrEmpty(folderPath))
            {
                //string folderPath = Path.GetDirectoryName(folder);
                _m_externalInventoriesModel.ExportAmazonInventoryFile(folderPath);
                _m_externalInventoriesModel.ExportFlipkartInventoryFile(folderPath);
                _m_externalInventoriesModel.ExportSnapdealInventoryFile(folderPath);
                _m_externalInventoriesModel.ExportMeeshoInventoryFile(folderPath);

                // ...
            }
        }

        

        //private void DisengageCellEvents()
        //{
        //    _ssGridView.BindingListChanged -= _bindingListChanged;
        //}



        private void UpdateCrossCompanySharedInvForThisCompany()
        {
            //First add all counts to chared inv
            foreach (var item in _inventoryViewList)
            {
                int.TryParse(item.AmazonCount, out int acount);
                int.TryParse(item.FlipkartCount, out int fcount);
                int.TryParse(item.SnapdealCount, out int scount);
#if IncludeMeesho
                int.TryParse(item.MeeshoCount, out int mcount);
#endif
                int.TryParse(item.InHouseCount, out int hcount);
                _crossCompanySharedWrapper._crossCompanyLinkedInventoryCount.AddToSharedInventory(item.InHouseCode, acount, fcount, scount
#if IncludeMeesho
                    ,mcount
#endif
                    );
            }

            foreach (var item in _inventoryViewList)
            {
                //Update and sum counts for this product in all companies
                item.InHouseCount = _crossCompanySharedWrapper.
                    _crossCompanyLinkedInventoryCount.GetAllInventoriesFromAllCompanies(item.InHouseCode).ToString();
            }
        }


        private void UpdateComposedChildProducts(string inHouseCode)
        {
            bool thisIsACompositionProduct = false;int index = 0;
            //Determine, if this inhousecode is a composition product or not.
            var thisProduct = _m_productModel._productEntries.Find(x => x.InHouseCode == inHouseCode);
            if (thisProduct == null)
            { Logger.Log("Cant find product in products list, func: UpdateInhouseInventory", Logger.LogLevel.error, false); return; }
            if (thisProduct != null && thisProduct.LinkedProduct != null && thisProduct.LinkedProduct.Count > 0)
                thisIsACompositionProduct = true;
            if (thisIsACompositionProduct)
            {
                //find child products in bindingList and call func recursively
                            //List<int> childLinkedProducts = new List<int>();
                List<ChildLinkedProducts> childLinkedProducts = new List<ChildLinkedProducts>();
                //var thisItemHasLinkedProducts = _m_productModel._productEntries.Find(x => x.InHouseCode == inHouseCode);
                foreach (var linkedItem in thisProduct.LinkedProduct)
                {
                    for (int i = 0; i < _inventoryViewList.Count; i++)
                    {
                        if (_inventoryViewList[i].InHouseCode == linkedItem.InHouseCode)
                        {
                            int.TryParse(linkedItem.LinkQty, out int linkQty);
                            if(childLinkedProducts.FirstOrDefault(x=>x.IndexInBindingList == i) == null)
                                childLinkedProducts.Add(new ChildLinkedProducts(i, linkQty));
                            //update and cum counts for each child product in all companies.
                            //UpdateInhouseInventory(list, i, linkedItem.InHouseCode, false);
                            break;
                        }
                    }
                }
                int.TryParse(_inventoryViewList[index].InHouseCount, out int p);
                //int.TryParse(list[index]., out int linkQuantity);
                foreach (var childProdIndex in childLinkedProducts)
                {
                    //int.TryParse(childProdIndex.LinkQty, out int linkQuantity);
                    int.TryParse(_inventoryViewList[childProdIndex.IndexInBindingList].InHouseCount, out int c);
                    _inventoryViewList[childProdIndex.IndexInBindingList].InHouseCount = (c + (p * childProdIndex.LinkQty)).ToString();
                }
            }
        }

        private void AddToCommonSharedInvForThisCompany()
        {
            //First add all counts to chared inv
            foreach (var item in _inventoryViewList)
            {
                int.TryParse(item.AmazonCount, out int acount);
                int.TryParse(item.FlipkartCount, out int fcount);
                int.TryParse(item.SnapdealCount, out int scount);
#if IncludeMeesho
                int.TryParse(item.MeeshoCount, out int mcount);
#endif
                int.TryParse(item.InHouseCount, out int hcount);
                _crossCompanySharedWrapper._crossCompanyLinkedInventoryCount.AddToSharedInventory(item.InHouseCode, acount, fcount, scount
#if IncludeMeesho
                    ,mcount
#endif
                    );
            }
            


        }

        private class ChildLinkedProducts
        {
            internal int IndexInBindingList;
            internal int LinkQty;
            public ChildLinkedProducts(int IndexInBindingList, int LinkQty)
            {
                this.IndexInBindingList = IndexInBindingList;
                this.LinkQty = LinkQty;
            }
        }



       



        //Events generated by bindinglist changed event, these events are coming from setter of class: InventoryView properties
        //update underlying collection, when grid changes

        private void EngageCellEvents()
        {
            if (_bindingListChanged == null)
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
                            //This is important to update inventory for this company first,
                            //then update other companies. Else other company wont reflect changes made in currnt company
                            UpdateCrossCompanySharedInvForThisCompany();
                            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
                            foreach (var item in _inventoryViewList)
                                UpdateComposedChildProducts(item.InHouseCode);
                            //UpdateComposedChildProducts(list[e.NewIndex].InHouseCode);
                            _ssGridView.UpdateBindings();
                       //UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
                      
                   }
               }
               if (e != null && e.PropertyDescriptor != null && e.PropertyDescriptor.Name == Constants.InventoryViewCols.FlipkartCount)
               {
                   //if non-numeric value is entered by user.
                   if (!int.TryParse(list[e.NewIndex].FlipkartCount, out int i)) { (new AlertBox("Wrong Input", "Only numeric values are allowed")).ShowDialog(); return; }
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
                            UpdateCrossCompanySharedInvForThisCompany();
                            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
                            _ssGridView.UpdateBindings();
                            //UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
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
                            UpdateCrossCompanySharedInvForThisCompany();
                            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
                            _ssGridView.UpdateBindings();
                            //UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
                        }
               }

#if IncludeMeesho
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
                            UpdateCrossCompanySharedInvForThisCompany();
                            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate(); 
                            _ssGridView.UpdateBindings();
                        }
                 
               }
#endif

           };
            }

            //_ssGridView.BindingListChanged += _bindingListChanged;
        }


        private async Task ResetAllBindings()
        {
            //DisengageCellEvents();
            _ssGridView.ClearBindingListRows();
            
            _ssGridView.IsLoading = true;
            await AssignAmazonInvAndPricesToInvView();
            await AssignFlipkartInvAndPricesToInvView();
            await AssignSnapdealInvAndPricesToInvView();
#if IncludeMeesho
            await AssignMeeshoInvAndPricesToInvView();
#endif
            _ssGridView.IsLoading = false;
            _ssGridView.UpdateBindings();
            //EngageCellEvents();
        }


        private async Task ImportAmazonOrders(bool isOnline = false)
        {
            _v_invCntrl.progressBar_Invload.Visible = true;
            //DisengageCellEvents();
            //_ssGridView.ClearBindingListRows();
            SingleNumericInputForm invDays = new SingleNumericInputForm("Order Parameters", "Get orders for number of days :", "Ok");
            invDays.ShowDialog();
            if (isOnline) { await _m_OrdersModel.GetAmazonOrderOnlineVia_API(invDays.Result); }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Amazon order text file|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    await _m_OrdersModel.GetAmzOrders(openFileDialog.FileName);
                else return;
            }
            _ssGridView.IsLoading = true;
            await AssignAmazonOrdersToInvView();
            CheckForUnmappedAmazonProductsFromImportedOrders();
            _ssGridView.IsLoading = false;
            _ssGridView.UpdateBindings();
            _v_invCntrl.progressBar_Invload.Visible = false;
        }

        private async Task ImportFlipkartOrders()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Flipkart order file|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                await _m_OrdersModel.GetFkOrders(openFileDialog.FileName);
            else return;
            _ssGridView.IsLoading = true;
            await AssignFkOrdersToInvView();
            CheckForUnmappedFlipkartProductsFromImportedOrders();
            _ssGridView.IsLoading = false;
            _ssGridView.UpdateBindings();
        }

        private async Task ImportSnapdealOrders()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Snapdeal order file|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                await _m_OrdersModel.GetSpdOrders(openFileDialog.FileName);
            else return;
            _ssGridView.IsLoading = true;
            await AssignSnapdealOrdersToInvView();
            CheckForUnmappedSnapdealProductsFromImportedOrders();
            _ssGridView.IsLoading = false;
            _ssGridView.UpdateBindings();
        }


        private Task AssignFkOrdersToInvView()
        {
            return Task.Run(() =>
            {
                foreach (var fkItem in _m_OrdersModel._fkOrders)
                {
                    foreach (var viewItem in _inventoryViewList)
                    {
                        if (!string.IsNullOrWhiteSpace(viewItem.FlipkartCode) && !string.IsNullOrWhiteSpace(fkItem.fsn) &&
                        fkItem.fsn.Trim().ToLower() == viewItem.FlipkartCode.Trim().ToLower()
                        && int.TryParse(fkItem.qty, out int val))
                        {
                            string sval = string.Empty;
                            if (val != 0) sval = Convert.ToString(val);
                            if (string.IsNullOrEmpty(viewItem.FlipkartOrders))
                                viewItem.FlipkartOrders = sval;
                            else
                            {
                                int.TryParse(sval, out int ival);
                                int.TryParse(viewItem.FlipkartOrders, out int vorder);
                                viewItem.FlipkartOrders = (ival + vorder).ToString();
                            }

                        }
                    }
                }
               
            });
        }


        private Task AssignSnapdealOrdersToInvView()
        {
            return Task.Run(() =>
            {
                foreach (var spdItem in _m_OrdersModel._spdOrders)
                {
                    foreach (var viewItem in _inventoryViewList)
                    {
                        if (!string.IsNullOrWhiteSpace(viewItem.SnapdealCode) && !string.IsNullOrWhiteSpace(spdItem.SUPC) &&
                        spdItem.SUPC.Trim().ToLower() == viewItem.SnapdealCode.Trim().ToLower())
                        {
                            if (string.IsNullOrEmpty(viewItem.SnapdealOrders))
                                viewItem.SnapdealOrders = 1.ToString();
                            else
                            {
                                int.TryParse(viewItem.AmazonOrders, out int vorder);
                                viewItem.SnapdealOrders = (1 + vorder).ToString();
                            }

                        }
                    }
                }
               
            });
        }

        private Task AssignAmazonOrdersToInvView()
        {
            return Task.Run(() =>
            {
                foreach (var amzItem in _m_OrdersModel._amzOrders)
                {
                    foreach (var viewItem in _inventoryViewList)
                    {
                        if (!string.IsNullOrWhiteSpace(viewItem.AmazonCode) && !string.IsNullOrWhiteSpace(amzItem.asin) &&
                        amzItem.asin.Trim().ToLower() == viewItem.AmazonCode.Trim().ToLower()
                        && int.TryParse(amzItem.qty, out int val))
                        {
                            string sval = string.Empty;
                            if (val != 0) sval = Convert.ToString(val);
                            if(string.IsNullOrEmpty(viewItem.AmazonOrders))
                                viewItem.AmazonOrders = sval;
                            else
                            {
                                int.TryParse(sval, out int ival);
                                int.TryParse(viewItem.AmazonOrders, out int vorder);
                                viewItem.AmazonOrders = (ival + vorder).ToString();
                            }
                            
                        }
                    }
                }

                
            });
        }



        private async Task ImportShelfInv()
        {
            _v_invCntrl.progressBar_Invload.Visible = true;
            //DisengageCellEvents();
            _ssGridView.ClearBindingListRows();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Shelf stock text file|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                _m_externalInventoriesModel.ImportShelfInventoryFile(openFileDialog.FileName);
            else return;

            _ssGridView.IsLoading = true;
            await AssignShelfInvAndPricesToInvView();
            _ssGridView.IsLoading = false;
            //UpdateCrossCompanySharedInvForThisCompany();
            //below event will call all inv update functions in all companies
            //_crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
            _ssGridView.UpdateBindings();
            //_m_invSnapShotModel_Amz.SaveInvSnapshot(_m_externalInventoriesModel._amzImportedInvList._amzInventoryList, null, saveOnlySystemInventory: true);
            _v_invCntrl.progressBar_Invload.Visible = false;

        }


        private async Task ImportAmazonInv(bool isOnline = false)
        {
            _v_invCntrl.progressBar_Invload.Visible = true;
            //DisengageCellEvents();
            _ssGridView.ClearBindingListRows();
            if (isOnline) {await _m_externalInventoriesModel.ImportAmazonInventoryFileOnlineAPI(); }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Amazon inv text file|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    _m_externalInventoriesModel.ImportAmazonInventoryFile(openFileDialog.FileName);
                else return;
            }
            _ssGridView.IsLoading = true;
            await AssignAmazonInvAndPricesToInvView();
            _ssGridView.IsLoading = false;
            UpdateCrossCompanySharedInvForThisCompany();
            //below event will call all inv update functions in all companies
            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
            _ssGridView.UpdateBindings();
            _m_invSnapShotModel_Amz.SaveInvSnapshot(_m_externalInventoriesModel._amzImportedInvList._amzInventoryList,null, saveOnlySystemInventory:true);

            foreach (var item in _inventoryViewList)
                UpdateComposedChildProducts(item.InHouseCode);

            CheckForUnmappedAmazonProducts();

            //Update indicator labels
            if (_inventoryViewList.Any(x => !string.IsNullOrEmpty(x.AmazonSystemCount)))
                _v_invCntrl.label_amazon.BackColor = Color.LimeGreen;
            else _v_invCntrl.label_amazon.BackColor = Color.LightGreen;
            _v_invCntrl.progressBar_Invload.Visible = false;
            //EngageCellEvents();
            //foreach (var item in list)
            //{
            //    _ssGridView.li
            //}
            //UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
        }


        private void CheckForUnmappedAmazonProductsFromImportedOrders()
        {
            List<string> unmappedInv = new List<string>();
            string label = "Codes found in Orders, which are not mapped";
            foreach (var amzItem in _m_OrdersModel._amzOrders)
            {
                var item = _inventoryViewList.FirstOrDefault(x => x.AmazonCode == amzItem.asin);
                if (item == null)
                    unmappedInv.Add(amzItem.asin);
            }
            
            UnMappedInventories uinv = new UnMappedInventories(Constants.Company.Amazon.ToString(), new List<string>(), unmappedInv, label);
            uinv.ShowDialog();
        }

        private void CheckForUnmappedFlipkartProductsFromImportedOrders()
        {
            List<string> unmappedInv = new List<string>();
            string label = "Codes found in Orders, which are not mapped";
            foreach (var fkItem in _m_OrdersModel._fkOrders)
            {
                var item = _inventoryViewList.FirstOrDefault(x => x.FlipkartCode == fkItem.fsn);
                if (item == null)
                    unmappedInv.Add(fkItem.fsn);
            }

            UnMappedInventories uinv = new UnMappedInventories(Constants.Company.Flipkart.ToString(), new List<string>(), unmappedInv, label);
            uinv.ShowDialog();
        }

        private void CheckForUnmappedSnapdealProductsFromImportedOrders()
        {
            List<string> unmappedInv = new List<string>();
            string label = "Codes found in Orders, which are not mapped";
            foreach (var spdItem in _m_OrdersModel._spdOrders)
            {
                var item = _inventoryViewList.FirstOrDefault(x => x.SnapdealCode == spdItem.SUPC);
                if (item == null)
                    unmappedInv.Add(spdItem.SUPC);
            }

            UnMappedInventories uinv = new UnMappedInventories(Constants.Company.Snapdeal.ToString(), new List<string>(), unmappedInv, label);
            uinv.ShowDialog();
        }

        private void CheckForUnmappedAmazonProducts()
        {
            List<string> unmappedInv = new List<string>();
            List<string> unmappedInhouseCodes = new List<string>();

            foreach (var amzItem in _m_externalInventoriesModel._amzImportedInvList._amzInventoryList)
            {
                var item=_inventoryViewList.FirstOrDefault(x => x.AmazonCode == amzItem.asin);
                if(item==null)
                    unmappedInv.Add(amzItem.asin);
            }
            foreach (var viewItem in _inventoryViewList)
            {
                var item = _m_externalInventoriesModel._amzImportedInvList._amzInventoryList.FirstOrDefault(
                    x => x.asin == viewItem.AmazonCode);
                if (item == null)
                    unmappedInhouseCodes.Add(viewItem.InHouseCode);
            }
            UnMappedInventories uinv = new UnMappedInventories(Constants.Company.Amazon.ToString(),unmappedInhouseCodes,unmappedInv);
            uinv.ShowDialog();
        }



        private void CheckForUnmappedFlipkartProducts()
        {
            List<string> unmappedInv = new List<string>();
            List<string> unmappedInhouseCodes = new List<string>();

            foreach (var fItem in _m_externalInventoriesModel._fkImportedInventoryList._fkInventoryList)
            {
                var item = _inventoryViewList.FirstOrDefault(x => x.FlipkartCode == fItem.fsn);
                if (item == null)
                    unmappedInv.Add(fItem.fsn);
            }
            foreach (var viewItem in _inventoryViewList)
            {
                var item = _m_externalInventoriesModel._fkImportedInventoryList._fkInventoryList.FirstOrDefault(
                    x => x.fsn == viewItem.FlipkartCode);
                if (item == null)
                    unmappedInhouseCodes.Add(viewItem.InHouseCode);
            }
            UnMappedInventories uinv = new UnMappedInventories(Constants.Company.Flipkart.ToString(), unmappedInhouseCodes, unmappedInv);
            uinv.ShowDialog();
        }



        private void CheckForUnmappedSnapdealProducts()
        {
            List<string> unmappedInv = new List<string>();
            List<string> unmappedInhouseCodes = new List<string>();

            foreach (var fItem in _m_externalInventoriesModel._spdImportedInventoryList._spdInventoryList)
            {
                var item = _inventoryViewList.FirstOrDefault(x => x.SnapdealCode == fItem.fsn);
                if (item == null)
                    unmappedInv.Add(fItem.fsn);
            }
            foreach (var viewItem in _inventoryViewList)
            {
                var item = _m_externalInventoriesModel._spdImportedInventoryList._spdInventoryList.FirstOrDefault(
                    x => x.fsn == viewItem.SnapdealCode);
                if (item == null)
                    unmappedInhouseCodes.Add(viewItem.InHouseCode);
            }
            UnMappedInventories uinv = new UnMappedInventories(Constants.Company.Snapdeal.ToString(), unmappedInhouseCodes, unmappedInv);
            uinv.ShowDialog();
        }

        private async Task ImportFlipkartInv()
        {
            //DisengageCellEvents();
            _ssGridView.ClearBindingListRows();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Flipkart inv file|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                _m_externalInventoriesModel.ImportFlipkartInventoryFile(openFileDialog.FileName);
            else return;
            _ssGridView.IsLoading = true;
            await AssignFlipkartInvAndPricesToInvView();
            _ssGridView.IsLoading = false;
            UpdateCrossCompanySharedInvForThisCompany();
            //below event will call all inv update functions in all companies
            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
            _ssGridView.UpdateBindings();
            _m_invSnapShotModel_Fk.SaveInvSnapshot(_m_externalInventoriesModel._fkImportedInventoryList._fkInventoryList,null, saveOnlySystemInventory:true);

            foreach (var item in _inventoryViewList)
                UpdateComposedChildProducts(item.InHouseCode);
            // EngageCellEvents() ;
            CheckForUnmappedFlipkartProducts();


            //Update indicator labels
            if (_inventoryViewList.Any(x => !string.IsNullOrEmpty(x.FlipkartSystemCount)))
                _v_invCntrl.label_flipkart.BackColor = Color.LimeGreen;
            else _v_invCntrl.label_flipkart.BackColor = Color.LightGreen;

        }

        private async Task ImportSnapdealInv()
        {
            //DisengageCellEvents();
            _ssGridView.ClearBindingListRows();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Snapdeal inv file|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                _m_externalInventoriesModel.ImportSnapdealInventoryFile(openFileDialog.FileName);
            else return;
            _ssGridView.IsLoading = true;
            await AssignSnapdealInvAndPricesToInvView();
            _ssGridView.IsLoading = false;
            UpdateCrossCompanySharedInvForThisCompany();
            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
            _ssGridView.UpdateBindings();
            _m_invSnapShotModel_Spd.SaveInvSnapshot(_m_externalInventoriesModel._spdImportedInventoryList._spdInventoryList,null, saveOnlySystemInventory: true);


            foreach (var item in _inventoryViewList)
                UpdateComposedChildProducts(item.InHouseCode);

            CheckForUnmappedSnapdealProducts();


            //Update indicator labels
            if (_inventoryViewList.Any(x => !string.IsNullOrEmpty(x.SnapdealSystemCount)))
                _v_invCntrl.label_snapdeal.BackColor = Color.LimeGreen;
            else _v_invCntrl.label_snapdeal.BackColor = Color.LightGreen;
            //EngageCellEvents();
        }

#if IncludeMeesho
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
            UpdateCrossCompanySharedInvForThisCompany();
            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
            _ssGridView.UpdateBindings();
            _m_invSnapShotModel_Mso.SaveInvSnapshot(_m_externalInventoriesModel._msoImportedInventoryList._msoInventoryList,null, saveOnlySystemInventory: true);

            EngageCellEvents();
        }
#endif

        internal void AssignImagesToProducts(Dictionary<string, Image> imgs)
        {
            foreach (var item in _inventoryViewList)
            {
                if (imgs.ContainsKey(item.InHouseCode))
                    item.Image = imgs[item.InHouseCode];

            }
        }



        private Task AssignShelfInvAndPricesToInvView()
        {
            return Task.Run(() =>
            {
                foreach (var shelfItem in _m_externalInventoriesModel._shelfInvList._shelfInventoryList)
                {
                    foreach (var viewItem in _inventoryViewList)
                    {
                        if (!string.IsNullOrWhiteSpace(shelfItem.inHouseCode) && !string.IsNullOrWhiteSpace(viewItem.InHouseCode) &&
                        shelfItem.inHouseCode.Trim().ToLower() == viewItem.InHouseCode.Trim().ToLower()
                        && int.TryParse(shelfItem.shelfCount, out int val))
                        {
                            string sval = string.Empty;
                            if (val != 0) sval = Convert.ToString(val);
                            viewItem.ShelfCount = sval;
                            //viewItem.AmazonCount = sval;

                            //update snapshot as well
                            //var snapshotObj = _m_invSnapShotModel._invSnapshotEntries.FirstOrDefault(x => x.ACode == viewItem.AmazonCode);
                            //if (snapshotObj != null)
                            //{
                            //    snapshotObj.AInv = viewItem.AmazonCount;
                            //    snapshotObj.ASystemInv = viewItem.AmazonSystemCount;
                            //}
                        }
                    }
                }


            });


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
                            //var snapshotObj = _m_invSnapShotModel._invSnapshotEntries.FirstOrDefault(x => x.ACode == viewItem.AmazonCode);
                            //if (snapshotObj != null)
                            //{
                            //    snapshotObj.AInv = viewItem.AmazonCount;
                            //    snapshotObj.ASystemInv = viewItem.AmazonSystemCount;
                            //}
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


#if IncludeMeesho
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

#endif




        #region Amazon-SPAPI

       
//         try
//            {
//                LWAAuthorizationCredentials lwaAuthorizationCredentials = new LWAAuthorizationCredentials
//                {
//                    ClientId = "amzn1.application-oa2-client.******************",
//                    ClientSecret = "***********************************",
//                    RefreshToken = "Atzr|***********************************",
//                    Endpoint = new Uri("https://api.amazon.com/auth/o2/token")
//                };
//        SellersApi sellersApi = new SellersApi.Builder()
//            .SetLWAAuthorizationCredentials(lwaAuthorizationCredentials)
//            .Build();

//        GetMarketplaceParticipationsResponse result = sellersApi.GetMarketplaceParticipations();
//        Console.WriteLine(result.ToJson());
//            }
//            catch (LWAException e)
//            {
//                Console.WriteLine("LWA Exception when calling SellersApi#getMarketplaceParticipations");
//                Console.WriteLine(e.getErrorCode());
//                Console.WriteLine(e.getErrorMessage());
//                Console.WriteLine(e.Message);
//            }
//            catch (ApiException e)
//            {
//    Console.WriteLine("Exception when calling SellersApi#getMarketplaceParticipations");
//    Console.WriteLine(e.Message);
//}



#endregion



internal class InventoryView : INotifyPropertyChanged
        {
            private string _amazonCount;
            private string _snpSystemCount;
            private string _snpOrders;
            private string _amazonSystemCount;
            private string _amazonOrders;
            private string _flipkartSystemCount;
            private string _flipkartOrders;
#if IncludeMeesho
            private string _meeshoSystemCount;
            private string _meeshoOrders;
#endif
            private string _flipkartCount;
            private string _snapdealCount;
#if IncludeMeesho
            private string _meeshoCount;
#endif
            private string _inhouseCount;
            private string _shelfCount;
            private string _notes;

            //below values from Product 
            public string InHouseCode { get; set; }
            private Image _image;
            public Image Image { get { return _image; } set { _image = value; } }
            public byte[] DisplayImage { get { return ImageToByteArray(_image); } }
            public string Title { get; set; }
            public string Tag { get; set; }


            //below values fron InvUpdate
            public string InHouseCount
            {
                get { return _inhouseCount; }
                set { if (value != this._inhouseCount) { _inhouseCount = value; NotifyPropertyChanged(); } }
            }

            public string ShelfCount
            {
                get { return _shelfCount; }
                set { if (value != this._shelfCount) { _shelfCount = value; NotifyPropertyChanged(); } }
            }


            public int OrdersCount
            {
                get {
                    int.TryParse(AmazonOrders, out int aOrders);
                    int.TryParse(FlipkartOrders, out int fOrders);
                    int.TryParse(SnapdealOrders, out int sOrders);
                    int tOrders = aOrders + fOrders + sOrders;
                    return tOrders; 
                }
                //set { if (value != this._ordersCount) { _ordersCount = value; NotifyPropertyChanged(); } }
            }

            public string AmazonCount { 
                get { return _amazonCount; } 
                set { if (value != this._amazonCount) { _amazonCount = value; NotifyPropertyChanged(); } } 
            }

            public string AmazonSystemCount
            {
                get { return _amazonSystemCount; }
                set { if (value != this._amazonSystemCount) { _amazonSystemCount = value; NotifyPropertyChanged(); } }
            }

            public string AmazonOrders {
                get { return _amazonOrders; }
                set { if (value != this._amazonOrders) { _amazonOrders = value; NotifyPropertyChanged(); } }
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

            public string FlipkartOrders
            {
                get { return _flipkartOrders; }
                set { if (value != this._flipkartOrders) { _flipkartOrders = value; NotifyPropertyChanged(); } }
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

            public string SnapdealOrders
            {
                get { return _snpOrders; }
                set { if (value != this._snpOrders) { _snpOrders = value; NotifyPropertyChanged(); } }
            }

#if IncludeMeesho
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

            public string MeeshoOrders
            {
                get { return _meeshoOrders; }
                set { if (value != this._meeshoOrders) { _meeshoOrders = value; NotifyPropertyChanged(); } }
            }
#endif

            public string Notes
            {
                get { return _notes; }
                set { if (value != this._notes) { _notes = value; NotifyPropertyChanged(); } }
            }

            //below values from Product
            public string AmazonCode { get; set; }
            public string FlipkartCode { get; set; }
            public string SnapdealCode { get; set; }
            //public string CostPrice { get; set; }
            //public string Profit { get {
            //        int.TryParse(AmazonOrders, out int aorder);
            //        int.TryParse(FlipkartOrders, out int forder);
            //        int.TryParse(SnapdealOrders, out int sorder);
            //        int.TryParse(CostPrice, out int cost);
            //        float totalCost = cost * (aorder + forder + sorder);
            //        float totalsale = 
            //        return "";
            //    } }
#if IncludeMeesho
            public string MeeshoCode { get; set; }
#endif
            public event PropertyChangedEventHandler PropertyChanged;

            // This method is called by the Set accessor of each property.  
            // The CallerMemberName attribute that is applied to the optional propertyName  
            // parameter causes the property name of the caller to be substituted as an argument.  
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            private byte[] ImageToByteArray(System.Drawing.Image imageIn)
            {
                if (imageIn == null) { return default(byte[]); }
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }


            private sealed class InvEqualityComparer : IEqualityComparer<InventoryView>
            {
                public bool Equals(InventoryView x, InventoryView y)
                {
                    return (String.Equals(x.InHouseCode, y.InHouseCode));
                }

                public int GetHashCode(InventoryView obj)
                {
                    return (obj.InHouseCode != null ? obj.InHouseCode.GetHashCode() : 0);
                }
            }
            public static IEqualityComparer<InventoryView> Comparer { get; } = new InvEqualityComparer();


        }

    } 
}
