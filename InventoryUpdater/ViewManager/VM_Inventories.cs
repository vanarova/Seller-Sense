using Decoders.Interfaces;
using SellerSense.Helper;
using SellerSense.Model;
using SellerSense.Model.InvUpdate;
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
using static SellerSense.ViewManager.VM_Companies;
using static SellerSense.ViewManager.VM_Company;
using static SellerSense.ViewManager.VM_Products;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SellerSense.ViewManager
{
    /// <summary>
    /// view manager for inventory form hierarchy, handles events and binding for all usercontrols in Inventories form
    /// </summary>
    internal partial class VM_Inventories :IManageUserControl
    {
        internal M_External_Inventories _m_externalInventoriesModel { get; set; }
        internal M_Snapshot _m_invSnapShotModel_Amz { get; set; }
        internal M_Snapshot _m_invSnapShotModel_Fk { get; set; }
        internal M_Snapshot _m_invSnapShotModel_Spd { get; set; }
        internal M_Snapshot _m_invSnapShotModel_Mso { get; set; }
        internal M_Product _m_productModel { get; set; }
        private string _companyCode { get; set; }
        //internal DataSet _invUpdateGridData { get; set; }
        private InvCntrl _v_invCntrl;
        //private Action InvokeUpdateInventoryInAllCompanies;
        private ssGridView<InventoryView> _ssGridView;
        private Action<Object, ListChangedEventArgs> _bindingListChanged;
        internal List<InventoryView> _inventoryViewList { get; set; }
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
            _m_productModel = m_product;
            _m_invSnapShotModel_Amz = new M_Snapshot(_companyCode, M_Snapshot.Site.amz);
            _m_invSnapShotModel_Spd = new M_Snapshot(_companyCode, M_Snapshot.Site.spd);
            _m_invSnapShotModel_Fk = new M_Snapshot(_companyCode, M_Snapshot.Site.fk);
            _m_invSnapShotModel_Mso = new M_Snapshot(_companyCode, M_Snapshot.Site.mso);
            TranslateInvModelToInvView();
            HandleExternalInventoryImportEvents();
            //InvokeUpdateInventoryInAllCompanies = UpdateInventoryInAllCompaniesAction;
            //UpdateInventoryInAllCompaniesAction+=       
            _crossCompanyEvents.CrossCompanySharedInventoryUpdated += (s, e) => { UpdateInvForThisCompany(); };
            //crossCompanyEvents.CrossCompanySharedInventoryUpdated += _crossCompanyEvents_CrossCompanySharedInventoryUpdated;
        }

        //This event handler is called for all companies, updates inv list, this is subscribed by each company in its CTOR
        //private void _crossCompanyLinkedInventoryCount_UpdateInventoryInAllCompanies(VM_Companies s, EventArgs e)
        //{
        //    UpdateInvForThisCompany();
        //}

        private void TranslateInvModelToInvView()
        {
            _inventoryViewList = new List<InventoryView>();
            foreach (var item in _m_productModel._productEntries)
            {
                //binding list source for grid
                _inventoryViewList.Add(new InventoryView()
                {
                    InHouseCode = item.InHouseCode,
                    Title = item.Title,
                    Tag = item.Tag,
                    Image = null,
                    AmazonCode = item.AmazonCode,
                    FlipkartCode = item.FlipkartCode,
                    MeeshoCode = item.MeeshoCode,
                    SnapdealCode = item.SnapdealCode
                });

            }
        }

        //private void _crossCompanyEvents_CrossCompanySharedInventoryUpdated(object sender, EventArgs e)
        //{
        //    _inventoryViewList.ForEach(x => x.InHouseCount =
        //    _crossCompanySharedWrapper._crossCompanyLinkedInventoryCount.GetAllInventoriesFromAllCompanies(x.InHouseCode).ToString());
        //}
    

        public void AssignViewManager(UserControl ssGrid)
        {
            _ssGridView = ssGrid as ssGridView<InventoryView>;
            
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
                gridview.Columns["AmazonOrders"].DefaultCellStyle.BackColor = Color.Silver;
                gridview.Columns["FlipkartOrders"].DefaultCellStyle.BackColor = Color.Silver;
                gridview.Columns["SnapdealOrders"].DefaultCellStyle.BackColor = Color.Silver;
                gridview.Columns["MeeshoOrders"].DefaultCellStyle.BackColor = Color.Silver;
            };
            //_ssGridView.OnCellFormatting += (gridview,e) => { HighlightCell(gridview,e); };
            _ssGridView.ResetBindings += async (e) => {await ResetAllBindings(); };
            _ssGridView.SearchTitleTriggered += SearchTitle;
            _ssGridView.SearchTagTriggered += SearchTags;
            //_ssGridView.OnCellFormatting
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

        //private void HighlightCell(DataGridView grid, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (e.Value == null || e.Value is Bitmap) return;
        //    var cellValue = e.Value.ToString(); 
            
        //    if (cellValue != null && Regex.IsMatch(e.Value.ToString(), @"(?<=\.(orders))"))
        //        e.CellStyle.BackColor = Color.Yellow;
        //}

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
            _v_invCntrl.sendTotalOrderCountToolStripMenuItem.Click += (s, e) => { SendTotalOrderReport(); };
            _v_invCntrl.allToolStripMenuItem_lastDay.Click += (s, e) => { 
                CompareAmz_LastDayInvWithSnapshot();
                CompareFk_LastDayInvWithSnapshot();
                CompareSpd_LastDayInvWithSnapshot();
                CompareMso_LastDayInvWithSnapshot();
            };
            _v_invCntrl.lastDayToolStripMenuItemAmz.Click += (s, e) => { CompareAmz_LastDayInvWithSnapshot(); };
            _v_invCntrl.lastDayToolStripMenuItemFk.Click += (s, e) => { CompareFk_LastDayInvWithSnapshot(); };
            _v_invCntrl.lastDayToolStripMenuItemSpd.Click += (s, e) => { CompareSpd_LastDayInvWithSnapshot(); };
            _v_invCntrl.lastDayToolStripMenuItemMso.Click += (s, e) => { CompareMso_LastDayInvWithSnapshot(); };
            //_v_invCntrl.withPreviousInventoryUpdateToolStripMenuItem.Click += async (s, e) => {
            //    //if (((ToolStripMenuItem)s).Checked)
            //    //    LoadSnapshotAndUpdateBindingListWithComparisons();
            //    //else
            //    //   await ResetAllBindings();
            //};


        }


        private void SendTotalOrderReport()
        {
            //Send order to telegram
            //int orders = _crossCompanySharedWrapper.GetCrossCompanyTodaysOrderReport().TotalOrders_Today.TotalOrder;
            var orders = _crossCompanySharedWrapper.GetCrossCompanyTodaysOrderReport().TotalOrders_Today;
            Logger.TelegramLog(Environment.NewLine +
                "Total orders today: " + orders.TotalOrder + Environment.NewLine +
                "Company: " + orders.CompanyA.Company + Environment.NewLine +
                "Amazon: " + orders.CompanyA.AmzOrderCount + Environment.NewLine +
                "Flipkart: " + orders.CompanyA.FkOrderCount + Environment.NewLine +
                "Snapdeal: " + orders.CompanyA.SpdOrderCount + Environment.NewLine +
                "Meesho: " + orders.CompanyA.MsoOrderCount + Environment.NewLine +
                "Company: " + orders.CompanyB.Company + Environment.NewLine +
                "Amazon: " + orders.CompanyB.AmzOrderCount + Environment.NewLine +
                "Flipkart: " + orders.CompanyB.FkOrderCount + Environment.NewLine +
                "Snapdeal: " + orders.CompanyB.SpdOrderCount + Environment.NewLine +
                "Meesho: " + orders.CompanyB.MsoOrderCount + Environment.NewLine 
                , Logger.LogLevel.info);
        }

        //private void _crossCompanyLinkedInventoryCount_SharedInventoryUpdated(object sender, EventArgs e)
        //{
        //    _inventoryViewList.ForEach(x => x.InHouseCount =
        //    _crossCompanyLinkedInventoryCount.GetAllInventoriesFromAllCompanies(x.InHouseCode).ToString()) ;
        //}

        private void ExportAllInventoryUpdateFiles()
        {
            //_m_invSnapShotModel_Amz.SerializeInvSnapshot();

           
                
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


        private void UpdateInhouseInventory(BindingList<InventoryView> list,int index, string inHouseCode, bool updateLinkedProds = true)
        {
            bool thisIsACompositionProduct = false;
            //update inhouse inv, changing property will trigger inhouse setter, and will update inhouse count in other companies
            if (string.IsNullOrWhiteSpace(list[index].InHouseCount)) list[index].InHouseCount = "0";
            int.TryParse(list[index].AmazonCount, out int acount);
            int.TryParse(list[index].FlipkartCount, out int fcount);
            int.TryParse(list[index].SnapdealCount, out int scount);
            int.TryParse(list[index].MeeshoCount, out int mcount);
            int.TryParse(list[index].InHouseCount, out int hcount);

            
            _crossCompanySharedWrapper._crossCompanyLinkedInventoryCount.AddToSharedInventory(inHouseCode, acount, fcount, scount, mcount);
           
            //Update and sum counts for this product in all companies
            list[index].InHouseCount = _crossCompanySharedWrapper.
                _crossCompanyLinkedInventoryCount.GetAllInventoriesFromAllCompanies(inHouseCode).ToString();


            ////Here calculate inventory for Composition products,,
            ///Add inventory for all parent products for composed-in products. Thats it.

            //Determine, if this inhousecode is a composition product or not.
            var thisProduct = _m_productModel._productEntries.Find(x => x.InHouseCode == inHouseCode);
            if (thisProduct == null)
            { Logger.Log("Cant find product in products list, func: UpdateInhouseInventory", Logger.LogLevel.error, false); return;  }
            if (thisProduct != null && thisProduct.LinkedProduct != null && thisProduct.LinkedProduct.Count > 0)
                thisIsACompositionProduct = true;

            if (updateLinkedProds)
            {
                if (!thisIsACompositionProduct)
                {
                    //First update inventory for parent product, who is having, this function's input product as linked product
                    foreach (var parentProduct in _m_productModel._productEntries)
                    {
                        if (parentProduct.LinkedProduct != null && parentProduct.LinkedProduct.Count > 0)
                        {
                            var thisLinkProductFoundInAnotherProduct = parentProduct.LinkedProduct.Find(x => x.InHouseCode == inHouseCode);
                            if (thisLinkProductFoundInAnotherProduct != null)
                            {
                                int.TryParse(thisLinkProductFoundInAnotherProduct.LinkQty, out int linkQuantity);
                                //find parent product in bindingList and call func recursively
                                int indexOfParentProductInBindingList = -1;
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i].InHouseCode == parentProduct.InHouseCode)
                                    { indexOfParentProductInBindingList = i; break; }
                                }
                                if (indexOfParentProductInBindingList > -1)
                                {
                                    //update and sum parents count
                                    UpdateInhouseInventory(list, indexOfParentProductInBindingList, parentProduct.InHouseCode, false);
                                    //update and sum child component, is already done in begining of this function.
                                    int.TryParse(list[index].InHouseCount, out int c);
                                    int.TryParse(list[indexOfParentProductInBindingList].InHouseCount, out int p);
                                    //sum child + parents inv counts 
                                    list[index].InHouseCount = (c + (p * linkQuantity)).ToString();
                                }
                            }
                            ////list[index].InHouseCount= list[index].InHouseCount + item.inhou
                        }
                    }
                }

                if (thisIsACompositionProduct)
                {
                    //If child product of this product is having linked products:
                    var thisItemHasLinkedProducts = _m_productModel._productEntries.Find(x => x.InHouseCode == inHouseCode);
                    if (thisItemHasLinkedProducts != null && thisItemHasLinkedProducts.LinkedProduct != null
                        && thisItemHasLinkedProducts.LinkedProduct.Count > 0)
                    {

                        //find child products in bindingList and call func recursively
                        //List<int> childLinkedProducts = new List<int>();
                        List<ChildLinkedProducts> childLinkedProducts = new List<ChildLinkedProducts>();
                        foreach (var linkedItem in thisItemHasLinkedProducts.LinkedProduct)
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i].InHouseCode == linkedItem.InHouseCode)
                                {
                                    int.TryParse(linkedItem.LinkQty, out int linkQty);
                                    childLinkedProducts.Add(new ChildLinkedProducts(i, linkQty));
                                    //update and cum counts for each child product in all companies.
                                    UpdateInhouseInventory(list, i, linkedItem.InHouseCode, false);
                                    break; 
                                }
                            }
                        }
                        int.TryParse(list[index].InHouseCount, out int p);
                        //int.TryParse(list[index]., out int linkQuantity);
                        foreach (var childProdIndex in childLinkedProducts)
                        {
                            //int.TryParse(childProdIndex.LinkQty, out int linkQuantity);
                            int.TryParse(list[childProdIndex.IndexInBindingList].InHouseCount, out int c);
                            list[childProdIndex.IndexInBindingList].InHouseCount = (c  + (p*childProdIndex.LinkQty)).ToString();
                        }

                        //if (indexOfProductInBindingList > -1)
                        //{ 

                        //}

                    }
                }
            }

           

        }


        private void UpdateInvForThisCompany()
        {
            //First add all counts to chared inv
            foreach (var item in _inventoryViewList)
            {
                int.TryParse(item.AmazonCount, out int acount);
                int.TryParse(item.FlipkartCount, out int fcount);
                int.TryParse(item.SnapdealCount, out int scount);
                int.TryParse(item.MeeshoCount, out int mcount);
                int.TryParse(item.InHouseCount, out int hcount);
                _crossCompanySharedWrapper._crossCompanyLinkedInventoryCount.AddToSharedInventory(item.InHouseCode, acount, fcount, scount, mcount);
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
                int.TryParse(item.MeeshoCount, out int mcount);
                int.TryParse(item.InHouseCount, out int hcount);
                _crossCompanySharedWrapper._crossCompanyLinkedInventoryCount.AddToSharedInventory(item.InHouseCode, acount, fcount, scount, mcount);
            }
            //update inhouse inv, changing property will trigger inhouse setter, and will update inhouse count in other companies
            //if (string.IsNullOrWhiteSpace(invViewList[index].InHouseCount)) invViewList[index].InHouseCount = "0";
            //int.TryParse(invViewList[index].AmazonCount, out int acount);
            //int.TryParse(invViewList[index].FlipkartCount, out int fcount);
            //int.TryParse(invViewList[index].SnapdealCount, out int scount);
            //int.TryParse(invViewList[index].MeeshoCount, out int mcount);
            //int.TryParse(invViewList[index].InHouseCount, out int hcount);


            ///_crossCompanySharedWrapper._crossCompanyLinkedInventoryCount.AddToSharedInventory(inHouseCode, acount, fcount, scount, mcount);

           

            //_crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdated();
            ////Update and sum counts for this product in all companies
            //invViewList[index].InHouseCount = _crossCompanySharedWrapper.
            //    _crossCompanyLinkedInventoryCount.GetAllInventoriesFromAllCompanies(inHouseCode).ToString();


            ////Here calculate inventory for Composition products,,
            ///Add inventory for all parent products for composed-in products. Thats it.

            //Determine, if this inhousecode is a composition product or not.
            //var thisProduct = _m_productModel._productEntries.Find(x => x.InHouseCode == inHouseCode);
            //if (thisProduct == null)
            //{ Logger.Log("Cant find product in products list, func: UpdateInhouseInventory", Logger.LogLevel.error, false); return; }
            //if (thisProduct != null && thisProduct.LinkedProduct != null && thisProduct.LinkedProduct.Count > 0)
            //    thisIsACompositionProduct = true;

            //if (updateLinkedProds)
            //{
            //    //if (!thisIsACompositionProduct)
            //    //{
            //    //    //First update inventory for parent product, who is having, this function's input product as linked product
            //    //    foreach (var parentProduct in _m_productModel._productEntries)
            //    //    {
            //    //        if (parentProduct.LinkedProduct != null && parentProduct.LinkedProduct.Count > 0)
            //    //        {
            //    //            var thisLinkProductFoundInAnotherProduct = parentProduct.LinkedProduct.Find(x => x.InHouseCode == inHouseCode);
            //    //            if (thisLinkProductFoundInAnotherProduct != null)
            //    //            {
            //    //                int.TryParse(thisLinkProductFoundInAnotherProduct.LinkQty, out int linkQuantity);
            //    //                //find parent product in bindingList and call func recursively
            //    //                int indexOfParentProductInBindingList = -1;
            //    //                for (int i = 0; i < list.Count; i++)
            //    //                {
            //    //                    if (list[i].InHouseCode == parentProduct.InHouseCode)
            //    //                    { indexOfParentProductInBindingList = i; break; }
            //    //                }
            //    //                if (indexOfParentProductInBindingList > -1)
            //    //                {
            //    //                    //update and sum parents count
            //    //                    UpdateInhouseInventory(list, indexOfParentProductInBindingList, parentProduct.InHouseCode, false);
            //    //                    //update and sum child component, is already done in begining of this function.
            //    //                    int.TryParse(list[index].InHouseCount, out int c);
            //    //                    int.TryParse(list[indexOfParentProductInBindingList].InHouseCount, out int p);
            //    //                    //sum child + parents inv counts 
            //    //                    list[index].InHouseCount = (c + (p * linkQuantity)).ToString();
            //    //                }
            //    //            }
            //    //            ////list[index].InHouseCount= list[index].InHouseCount + item.inhou
            //    //        }
            //    //    }
            //    //}

            //    //if (thisIsACompositionProduct)
            //    //{
            //    //    //If child product of this product is having linked products:
            //    //    var thisItemHasLinkedProducts = _m_productModel._productEntries.Find(x => x.InHouseCode == inHouseCode);
            //    //    if (thisItemHasLinkedProducts != null && thisItemHasLinkedProducts.LinkedProduct != null
            //    //        && thisItemHasLinkedProducts.LinkedProduct.Count > 0)
            //    //    {

            //    //        //find child products in bindingList and call func recursively
            //    //        //List<int> childLinkedProducts = new List<int>();
            //    //        List<ChildLinkedProducts> childLinkedProducts = new List<ChildLinkedProducts>();
            //    //        foreach (var linkedItem in thisItemHasLinkedProducts.LinkedProduct)
            //    //        {
            //    //            for (int i = 0; i < list.Count; i++)
            //    //            {
            //    //                if (list[i].InHouseCode == linkedItem.InHouseCode)
            //    //                {
            //    //                    int.TryParse(linkedItem.LinkQty, out int linkQty);
            //    //                    childLinkedProducts.Add(new ChildLinkedProducts(i, linkQty));
            //    //                    //update and cum counts for each child product in all companies.
            //    //                    UpdateInhouseInventory(list, i, linkedItem.InHouseCode, false);
            //    //                    break;
            //    //                }
            //    //            }
            //    //        }
            //    //        int.TryParse(list[index].InHouseCount, out int p);
            //    //        //int.TryParse(list[index]., out int linkQuantity);
            //    //        foreach (var childProdIndex in childLinkedProducts)
            //    //        {
            //    //            //int.TryParse(childProdIndex.LinkQty, out int linkQuantity);
            //    //            int.TryParse(list[childProdIndex.IndexInBindingList].InHouseCount, out int c);
            //    //            list[childProdIndex.IndexInBindingList].InHouseCount = (c + (p * childProdIndex.LinkQty)).ToString();
            //    //        }

            //    //        //if (indexOfProductInBindingList > -1)
            //    //        //{ 

            //    //        //}

            //    //    }
            //    //}
            //}



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
                            UpdateInvForThisCompany();
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
                            UpdateInvForThisCompany();
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
                            UpdateInvForThisCompany();
                            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
                            _ssGridView.UpdateBindings();
                            //UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
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
                            UpdateInvForThisCompany();
                            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate(); 
                            _ssGridView.UpdateBindings();
                        }
                 
                   //UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
               }
           };
            }

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
            //below event will call all inv update functions in all companies
            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
            _ssGridView.UpdateBindings();
            _m_invSnapShotModel_Amz.SaveInvSnapshot(_m_externalInventoriesModel._amzImportedInvList._amzInventoryList);
            
            EngageCellEvents();
            //foreach (var item in list)
            //{
            //    _ssGridView.li
            //}
            //UpdateInhouseInventory(list, e.NewIndex, list[e.NewIndex].InHouseCode);
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
            //below event will call all inv update functions in all companies
            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
            _ssGridView.UpdateBindings();
            _m_invSnapShotModel_Fk.SaveInvSnapshot(_m_externalInventoriesModel._fkImportedInventoryList._fkInventoryList);
            
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
            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
            _ssGridView.UpdateBindings();
            _m_invSnapShotModel_Spd.SaveInvSnapshot(_m_externalInventoriesModel._spdImportedInventoryList._spdInventoryList);
            
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
            _crossCompanyEvents.InvokeCrossCompanySharedInventoryUpdate();
            _ssGridView.UpdateBindings();
            _m_invSnapShotModel_Mso.SaveInvSnapshot(_m_externalInventoriesModel._msoImportedInventoryList._msoInventoryList);
            
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
            private string _snpOrders;
            private string _amazonSystemCount;
            private string _amazonOrders;
            private string _flipkartSystemCount;
            private string _flipkartOrders;
            private string _meeshoSystemCount;
            private string _meeshoOrders;
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
