using CommonUtil;
using Decoders;
using Decoders.Interfaces;
using SellerSense.Helper;
using SellerSense.Model;
using SellerSense.Model.Invoice;
using SellerSense.Views;
using SellerSense.Views.Products;
using ssGrid;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static SellerSense.ViewManager.VM_AddProduct;

namespace SellerSense.ViewManager
{
    //
    /// <summary>
    /// This is view manager class, manages all events and logic for one view tree.
    /// One form with all child user controls, are managed by one view manager, this VM manages product form 
    /// and all child user control forms.
    /// </summary>
    internal class VM_Products
    {
        internal string _name;
        internal string _code;
        internal M_Product _m_product { get; set; }
        internal ObservableCollection<ProductView> _vm_productsView { get; set; }
        private ProductCntrl _v_productCntrl;
        private M_Invoice _m_invoice;
        private ssGridView<ProductView> _v_ssGridViewCntrl;
        //private ssGridView<ProductView> _v_ssGridViewCntrl;
        private SfDataGrid _datagrid;
        //private DataGridView _datagrid;
        private M_External_Inventories _InventoriesModel;
        private Dictionary<string, Image> _images;
        internal CompareProductView _compareProductViews;
        private bool PrestaShopCancelOperation=false;
        
        public enum PrestaShopImportType
        {
            UpdateOnly,
            ImportNewOnly,
            FullSync,
            DeletedUnlisted
        }

        public VM_Products(M_Product m_Product,M_External_Inventories vm_Inventories, string companycode)
        {
            //_images = images;
            _m_invoice = new M_Invoice();
            _code = companycode;
            _InventoriesModel = vm_Inventories;   
            _m_product = m_Product;
            _compareProductViews = new CompareProductView();
            FillFromProductModelToProductsViewWithoutImagesAndHandleUpdateEvents();
            AmazonSPAPI.Init(_code);
        }

        public void AssignViewA(UserControl pcntrl)
        {
            _v_productCntrl = pcntrl as ProductCntrl;
            HandleProductControlEvents();
        }


        #region ProductViewComparer

        //internal bool CompareProductViews(CompareProductView pview) { CompareProductView cmpProducts = new CompareProductView(); return cmpProducts.Compare(pview, pview); }

        internal class CompareProductView : IComparer<ProductView>
        {
            public int Compare(ProductView x, ProductView y)
            {
                if (x.InHouseCode == y.InHouseCode) return 0;
                else return 1;
                        ;
            }
        }

        #endregion

        #region ProductUserControl

        private void HandleProductControlEvents()
        {
                _v_productCntrl.checkBox_InvoiceMode.CheckedChanged += (s, e) =>
                {
                    // col.MappingName = "Quantity"; col.HeaderText = "Qty";
                    
                    if (_v_productCntrl.checkBox_InvoiceMode.Checked)
                    {
                        var col = new GridUnboundColumn()
                        {
                            MappingName = "Quantity",
                            HeaderText = "Qty",
                            MaximumWidth = 100,AllowEditing = true,Expression="0"
                        };
                        //Add TextBox column for invoice
                        _datagrid.Columns.Insert(0, col);
                        
                    }
                    else {
                        var c = _datagrid.Columns.Where(x => x.MappingName == "Quantity").FirstOrDefault();
                        var imgCol = SyncFusionHelper.GetGridColumnIndex(_datagrid, "Quantity");
                        //Image selectedImg = SyncFusionHelper.GetCellValue(_datagrid, 1, imgCol) as Image;
                        string selectedCode = SyncFusionHelper.GetCellValue(_datagrid, 1, imgCol).ToString();

                        if (c!=null)
                        _datagrid.Columns.Remove(c); 
                    }
                };
            _v_productCntrl.sfButton_Invoice.Click += (s, e) => {
                //ProductInvoice inv = new ProductInvoice(_m_product,_m_invoice);
                try
                {
                    ProductInvoice pinv = new ProductInvoice(_m_product, _m_invoice);
                    pinv.ShowDialog();
                    if (pinv.DialogResult == DialogResult.OK)
                    {
                        (string tempDir, string file) = _m_invoice.WriteInvoiceToFile();
                        AlertBox ab = new AlertBox("Invoice ready", $"Your Invoice/Quote file : {file}", null, false, tempDir); ab.ShowDialog();
                    }
                }
                catch (Exception ex) { AlertBox ab = new AlertBox("Error",$"Error accessing excel file. {ex.Message}"); ab.ShowDialog(); }
                //inv.ShowDialog();
            };

            _v_productCntrl.toolStripMenuItem_Save.Click += (s, e) => {
                //WriteBackProductViewToProductsModel();
                SaveModel();
                _v_ssGridViewCntrl._isBindingListDirty = false;
            };
            _v_productCntrl.mapAsinToolStripMenuItem.Click += (s, e) => { OpenInvFiller(Constants.Company.Amazon); };
            _v_productCntrl.mapFSNToolStripMenuItem.Click += (s, e) => { OpenInvFiller(Constants.Company.Flipkart); };
            _v_productCntrl.mapSPDCodeToolStripMenuItem.Click += (s, e) => { OpenInvFiller(Constants.Company.Snapdeal); };

#if IncludeMeesho
            _v_productCntrl.meeshoToolStripMenuItem.Click += (s, e) => { OpenInvFiller(Constants.Company.Meesho); };
#endif

            _v_productCntrl.toolstripitem_Add.Click += (s, e) => { OpenAddEditProductForm(); };
            _v_productCntrl.toolstripitem_Excel.Click += (s, e) => { BulkImportProducts(); };
            _v_productCntrl.toolstripitem_Prestashop.Click += (s, e) => { ImportPrestaShopProducts(); };

            //_v_productCntrl.checkBox_InvoiceMode.CheckedChanged += (s,e) => { };
            _v_productCntrl.sfButton_Invoice.Click += (s,e) => { };

            _v_productCntrl.mapAmzSKUToolStripMenuItem.Click += (s, e) => { OpenProductMapSKUForm(Constants.Company.Amazon); };
            _v_productCntrl.mapFkSKUToolStripMenuItem.Click += (s, e) => { OpenProductMapSKUForm(Constants.Company.Flipkart); };
            _v_productCntrl.mapSpdSKUToolStripMenuItem.Click += (s, e) => { OpenProductMapSKUForm(Constants.Company.Snapdeal); };
        }

        private void OpenProductMapSKUForm(Constants.Company comp)
        {
            ProductMapSKUs pMap = new ProductMapSKUs(_m_product, comp);
            pMap.ShowDialog();
            _m_product.SaveMapFile();
        }


        private void BulkImportProducts()
        {
            Action ExportProductForEditing= () => { _v_ssGridViewCntrl.ExportGridAsExcel(); };
            ImportProductExcel csvDialog = new ImportProductExcel(_m_product, ExportProductForEditing);
            csvDialog.ShowDialog();
            if (csvDialog.DialogResult != DialogResult.OK)
                return;
            int importedCount = 0;

            // Edit existing product
            if (csvDialog != null && csvDialog.EditProducts != null && csvDialog.Mode == ImportProductExcel.ImportMode.Edit)
            {
                foreach (var iprod in csvDialog.EditProducts)
                {
                    var isThisCodeAvailable = _m_product._productEntries.FirstOrDefault(x => x.InHouseCode == iprod.InHouseCode);
                    if (isThisCodeAvailable != null)
                    {
                        EditProductFromImportedProductList(iprod);
                        _m_product.SaveMapFile();
                    }
                }
            }

            
            // Insert new product
            if (csvDialog !=null && csvDialog.NewProducts != null && csvDialog.Mode == ImportProductExcel.ImportMode.Add)
            {
                foreach (var iprod in csvDialog.NewProducts)
                {
                    if (_m_product._productEntries.Count(x => x.InHouseCode == iprod.InHouseCode) > 1)
                    {
                        new AlertBox("Error", $" Multiple codes found for code : {iprod.InHouseCode}, " +
                            $"{importedCount} products imported, Please correct input file, aborting now..").ShowDialog();
                        return;
                    }
                   
                    importedCount++;
                    //string Image2Path = string.Empty, Image3Path = string.Empty, Image4Path = string.Empty, primaryImagePath = String.Empty;
                    Image img = Image.FromFile(iprod.Image);
                    Image img2=null; Image img3=null; Image img4 =null;
                    if (!string.IsNullOrEmpty(iprod.ImageAlt1))
                        img2 = Image.FromFile(iprod.ImageAlt1);
                    if (!string.IsNullOrEmpty(iprod.ImageAlt2))
                        img3 = Image.FromFile(iprod.ImageAlt2);
                    if (!string.IsNullOrEmpty(iprod.ImageAlt3))
                        img4 = Image.FromFile(iprod.ImageAlt3);
                   string i1= _m_product.SaveImage(img, iprod.InHouseCode, overwrite: true);

                    //TODO : remove image numbers and add as another parameter to function, pass numbers, this func is used multiple times.
                    string img2_name = iprod.InHouseCode + "_2";
                    string img3_name = iprod.InHouseCode + "_3";
                    string img4_name = iprod.InHouseCode + "_4";

                   string i2 = _m_product.SaveImage(img2, img2_name, overwrite: true);
                   string i3 = _m_product.SaveImage(img3, img3_name, overwrite: true);
                   string i4 = _m_product.SaveImage(img4, img4_name, overwrite: true);
                    
                    //(_, var imgc) = ProjIO.LoadImageAndDownSize75x75(iprod.Image);
                    var prod = new M_Product.ProductEntry(iprod.InHouseCode, String.Empty, iprod.Title,
                        String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, iprod.Tag, iprod.Description)
                    {
                        Image = Path.GetFileName(i1),
                        ImageAlt1 = Path.GetFileName(i2),
                        ImageAlt2 = Path.GetFileName(i3),
                        ImageAlt3 = Path.GetFileName(i4),
                        MRP = iprod.MRP,
                        Tag = iprod.Tag,
                        SellingPrice = iprod.SellingPrice,
                        CostPrice = iprod.CostPrice,
                        Weight = iprod.Weight,
                        WeightAfterPackaging = iprod.WeightAfterPackaging,
                        DimensionsBeforePackaging = iprod.DimensionsBeforePackaging,
                        DimensionsAfterPackaging = iprod.DimensionsAfterPackaging
                    };
                    _m_product._productEntries.Add(prod);
                }
                //UpdateProductModelToProductsViewWithoutImages();
                AddNewProductFromProductModelToProductView();
                _m_product.SaveMapFile();
            }

            
        }

        private void EditProductFromImportedProductList(IEditProduct iprod)
        {
            //Update view
            var p = _vm_productsView.FirstOrDefault(x => x.InHouseCode == iprod.InHouseCode);
            p.Title = iprod.Title;
            p.Tag = iprod.Tag;
            p.CostPrice = iprod.CostPrice;
            p.Description = iprod.Description;
            p.AmazonCode = iprod.AmazonCode;
            p.FlipkartCode = iprod.FlipkartCode;
            p.SnapdealCode = iprod.SnapdealCode;
            p.Notes = iprod.Notes;

            //Update product collection as well.
            var prod = _m_product._productEntries.FirstOrDefault(x => x.InHouseCode == iprod.InHouseCode);
            prod.Title =  iprod.Title;
            prod.Tag = iprod.Tag;
            prod.MRP = iprod.MRP;
            prod.SellingPrice = iprod.SellingPrice;
            prod.CostPrice = iprod.CostPrice;
            prod.Weight = iprod.Weight;
            prod.WeightAfterPackaging = iprod.WeightAfterPackaging;
            prod.DimensionsBeforePackaging = iprod.DimensionsBeforePackaging;
            prod.DimensionsAfterPackaging = iprod.DimensionsAfterPackaging;
            prod.Description = iprod.Description;
            prod.AmazonCode = iprod.AmazonCode;
            prod.AmazonSKU = iprod.AmazonSKU;
            prod.FlipkartCode = iprod.FlipkartCode;
            prod.FlipkartSKU = iprod.FlipkartSKU;
            prod.SnapdealCode = iprod.SnapdealCode;
            prod.SnapdealSKU = iprod.SnapdealSKU;
            //prod.MeeshoCode = iprod.MeeshoCode;
            prod.Notes = iprod.Notes;
        }

        private void OpenAddEditProductForm()
        {
            AddProduct _v_addproduct = new AddProduct(false);
            VM_AddProduct vm_addProduct = new VM_AddProduct(_v_addproduct, _m_product);
            if(_v_addproduct.ShowDialog() == DialogResult.OK)
            {
                Translate_AddEditProductObj_ToProduct_AndRefreshProductViewList(vm_addProduct.AddProductViewBindingObj, IsAddNewProduct:true);
                AddNewProductFromProductModelToProductView();
                _m_product.SaveMapFile();
            }
        }

      

        private void AddNewProductFromProductModelToProductView()
        {
            //Update, For existing items
            foreach (var product in _m_product._productEntries)
            {
                var productViewItem = _vm_productsView.Where(x => x.InHouseCode == product.InHouseCode).FirstOrDefault();
                //For new Item
                if (productViewItem== null)
                { 
                    (_,Image img) = ProjIO.LoadImageUsingFileNameAndDownSize75x75(product.Image, _code);
                    var prod = new ProductView(product.InHouseCode, img,
                    product.Title, product.Tag, product.Description, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    _vm_productsView.Add(prod);
                }
            }

            
        }

        private void Translate_AddEditProductObj_ToProduct_AndRefreshProductViewList(VM_AddProduct.AddProductView addProductView, bool IsAddNewProduct)
        {
            if (IsAddNewProduct) // add new product
            {
                string Image2Path = string.Empty, Image3Path = string.Empty, Image4Path = string.Empty, primaryImagePath = String.Empty;
                // validation for this and other images happens in VM_AddProdiuct class.
                SaveImages(addProductView,ref primaryImagePath,  ref Image2Path, ref Image3Path, ref Image4Path);
                if (string.IsNullOrEmpty(primaryImagePath))
                    return;
                
                //(_, var img) = ProjIO.LoadImageAndDownSize75x75(primaryImagePath);

                var prod = new M_Product.ProductEntry(addProductView.InHouseCode, String.Empty, addProductView.Name,
                    String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, addProductView.Tag, addProductView.Description)
                {
                    Image = Path.GetFileName(primaryImagePath),
                    ImageAlt1 = Path.GetFileName(Image2Path),
                    ImageAlt2 = Path.GetFileName(Image3Path),
                    ImageAlt3 = Path.GetFileName(Image4Path),
                    MRP = addProductView.MRP,
                    Tag = addProductView.Tag,
                    SellingPrice = addProductView.SellingPrice,
                    CostPrice = addProductView.CostPrice,
                    Weight = addProductView.Weight,
                    WeightAfterPackaging = addProductView.WeightAfterPackaging,
                    DimensionsBeforePackaging = addProductView.DimensionBeforePackaging,
                    DimensionsAfterPackaging = addProductView.DimensionAfterPackaging
                };
                _m_product._productEntries.Add(prod);

            }
            else  //edit product
            {
               
                string Image2Path = string.Empty, Image3Path = string.Empty, Image4Path = string.Empty, primaryImagePath = String.Empty;
                
                SaveImages(addProductView, ref primaryImagePath, ref Image2Path, ref Image3Path, ref Image4Path);
                var pEntry = _m_product._productEntries.Find(x => x.InHouseCode == addProductView.InHouseCode);
                if(pEntry != null)
                {
                    (bool img1, bool img2, bool img3, bool img4) = addProductView.GetDirtyImages();
                    pEntry.Title = addProductView.Name;
                    pEntry.Description = addProductView.Description;
                    pEntry.Tag = addProductView.Tag;
                    pEntry.DimensionsAfterPackaging = addProductView.DimensionAfterPackaging;
                    pEntry.DimensionsBeforePackaging = addProductView.DimensionBeforePackaging;
                    pEntry.Weight = addProductView.Weight;
                    pEntry.WeightAfterPackaging = addProductView.WeightAfterPackaging;
                    pEntry.MRP = addProductView.MRP;
                    pEntry.SellingPrice = addProductView.SellingPrice;
                    pEntry.CostPrice = addProductView.CostPrice;
                    if(img1 && !string.IsNullOrEmpty(primaryImagePath))
                        pEntry.Image = Path.GetFileName(primaryImagePath);
                    if (img2 && !string.IsNullOrEmpty(Image2Path))
                        pEntry.ImageAlt1 = Path.GetFileName(Image2Path);
                    if (img3 && !string.IsNullOrEmpty(Image3Path))
                        pEntry.ImageAlt2 = Path.GetFileName(Image3Path);
                    if (img4 && !string.IsNullOrEmpty(Image4Path))
                        pEntry.ImageAlt3 = Path.GetFileName(Image4Path);
                }
                //FillFromProductModelToProductsViewWithoutImages();
                UpdateProductModelToProductsViewWithoutImages();
            }
        }

        private void SaveImages(VM_AddProduct.AddProductView addProductView, ref string primaryImagePath,
            ref string Image2Path, ref string Image3Path, ref string Image4Path)
        {
            (bool img1, bool img2, bool img3, bool img4) = addProductView.GetDirtyImages();
            //SAVE IMAGE ONLY, IF NEW PRODUCT ENTRY OR IN EDIT MODE, IF IMAGE IS DIRTY
            if (img1 || !addProductView.EditMode)
                primaryImagePath = _m_product.SaveImage(addProductView.PrimaryImage, addProductView.InHouseCode, overwrite: true);
            if (addProductView.Image2 != null && (img2 || !addProductView.EditMode))
                Image2Path = _m_product.SaveImage(addProductView.Image2, addProductView.InHouseCode + "_2", overwrite: true); //overwrite image, in case of edit mode
            if (addProductView.Image3 != null && (img3 || !addProductView.EditMode))
                Image3Path = _m_product.SaveImage(addProductView.Image3, addProductView.InHouseCode + "_3", overwrite: true);
            if (addProductView.Image4 != null && (img4 || !addProductView.EditMode))
                Image4Path = _m_product.SaveImage(addProductView.Image4, addProductView.InHouseCode + "_4", overwrite: true);
        }

      



        
        private void OpenInvFiller(Constants.Company company)
        {
            //var cells = _datagrid.GetSelectedCells();
           
            int selectedRow = _datagrid.CurrentCell.RowIndex;
            var data = _datagrid.GetRecordEntryAtRowIndex(_datagrid.CurrentCell.RowIndex);
            string inhouseCode = ((data as Syncfusion.Data.RecordEntry).Data as ProductView).InHouseCode;
            
            //int selectedRow = _datagrid.SelectedCells[0].RowIndex;
            //Syncfusion.Data.NodeEntry record = _datagrid.GetRecordEntryAtRowIndex(selectedRow);
            //_datagrid.View.Records.GetItemAt(selectedRow);
            var imgCol = SyncFusionHelper.GetGridColumnIndex(_datagrid, Constants.PCols.Image);
            var codeCol = SyncFusionHelper.GetGridColumnIndex(_datagrid, Constants.PCols.InHouseCode);
            var titleCol = SyncFusionHelper.GetGridColumnIndex(_datagrid, Constants.PCols.Title);
            Image selectedImg = SyncFusionHelper.GetCellValue(_datagrid, selectedRow, imgCol) as Image;
            string selectedCode = SyncFusionHelper.GetCellValue(_datagrid, selectedRow, codeCol).ToString();
            string selectedTitle = SyncFusionHelper.GetCellValue(_datagrid, selectedRow, titleCol).ToString();
            //_datagrid.Columns[_datagrid.CurrentCell.ColumnIndex]
            
            InvFiller inf = new InvFiller(company, selectedImg, selectedCode, selectedTitle, _InventoriesModel);
            inf.ShowDialog();
            //assign map ID
            if (inf.SelectedID != null && !string.IsNullOrEmpty(inf.SelectedID))
            {
                //_vm_productsView[_datagrid.CurrentCell.RowIndex][_datagrid.CurrentCell.ColumnIndex] = inf.SelectedID;
                //var productEntry = _m_product._productEntries.Find(x => x.InHouseCode == inhouseCode);
                var viewItem = _vm_productsView.Where(x => x.InHouseCode == inhouseCode).FirstOrDefault();
                //productEntry.
                if (_datagrid.CurrentCell.Column.MappingName == Constants.PCols.AmazonCode)
                    viewItem.AmazonCode = inf.SelectedID;  //Update in view also, so that, we dont need to sync between Model and view.
                if (_datagrid.CurrentCell.Column.MappingName == Constants.PCols.FlipkartCode)
                    viewItem.FlipkartCode = inf.SelectedID;  //Update in view also, so that, we dont need to sync between Model and view.
                if (_datagrid.CurrentCell.Column.MappingName == Constants.PCols.SnapDealCode)
                    viewItem.SnapdealCode = inf.SelectedID;  //Update in view also, so that, we dont need to sync between Model and view.
                
                _v_ssGridViewCntrl._isBindingListDirty = true;
            }
        }




        #endregion ProductUserControl


        #region ssGridViewUserControl

        public ssGrid.ssGridView<VM_Products.ProductView> CreateAndManageView_ProductGridUserControl()
        {
            _v_ssGridViewCntrl = new ssGrid.ssGridView<VM_Products.ProductView>(_vm_productsView, HandlessGridViewControlEvents);
            _v_ssGridViewCntrl.Dock = DockStyle.Fill;
            //_v_ssGridViewCntrl = ssGrid as ssGridView<ProductView>;
            //HandlessGridViewControlEvents();
            return _v_ssGridViewCntrl;
        }

        private void HandlessGridViewControlEvents(SfDataGrid grid)
        {
            BindDatagridEvents(grid);
            
        }

       
        //Edit button clicked on product grid.
        private void _v_ssGridViewCntrl_OnGridButtonClicked(object sender, Syncfusion.WinForms.DataGrid.Events.CellButtonClickEventArgs e)//
        {
            int code_col_Index =  SyncFusionHelper.GetGridColumnIndex(_datagrid, Constants.PCols.InHouseCode);
            string inhouseCode = SyncFusionHelper.GetCellValue(_datagrid, e.RowIndex, code_col_Index).ToString();
            if (!string.IsNullOrEmpty(inhouseCode))
            {
                var prod = _m_product._productEntries.Find(x => x.InHouseCode == inhouseCode);
                if (prod == null)
                {
                    new AlertBox("Info", "Product doesn't exist, Please press refresh button to refresh data grid..", isError: false).ShowDialog();
                    return;
                }
                AddProduct _v_addproduct = new AddProduct(true);
                VM_AddProduct vm_addProduct = new VM_AddProduct(_v_addproduct,_m_product, prod, _images, _code);
                if (_v_addproduct.ShowDialog() == DialogResult.OK)
                {
                    if (vm_addProduct.MarkedForDeletion)
                        RemoveMarkedProduct(prod);
                    else
                        Translate_AddEditProductObj_ToProduct_AndRefreshProductViewList(vm_addProduct.AddProductViewBindingObj, IsAddNewProduct: false);
                    //WriteBackProductViewToProductsModelAndSave();
                    _m_product.SaveMapFile();
                }
            }
        }

        private void RemoveMarkedProduct( M_Product.ProductEntry product)
        {
            var itemToDel = _vm_productsView.Where(x => x.InHouseCode == product.InHouseCode).FirstOrDefault();
            _m_product.DeleteProductImage(product.Image);
            _m_product.DeleteProductImage(product.ImageAlt1);
            _m_product.DeleteProductImage(product.ImageAlt2);
            _m_product.DeleteProductImage(product.ImageAlt3);
            if (itemToDel != null)
                _vm_productsView.Remove(itemToDel);
            _m_product._productEntries.Remove(product);
            _v_ssGridViewCntrl.Invalidate();

        }

        internal void WriteBackProductViewToProductsModel()
        {
            foreach (var p in _vm_productsView)
            {
                foreach (var m in _m_product._productEntries)
                {
                    if(p.InHouseCode == m.InHouseCode)
                    {
                        
                        m.SnapdealCode = p.SnapdealCode;
                        m.FlipkartCode = p.FlipkartCode;
                        m.Notes = p.Notes;
                        m.Title = p.Title;
                        m.Description = p.Description;
                        m.Tag = p.Tag;
                        m.AmazonCode = p.AmazonCode;
#if IncludeMeesho
                        m.MeeshoCode = p.MeeshoCode;
#endif
                        
                    }
                }

            }
           // _m_product.SaveMapFile();
        }


        internal void SaveModel()
        {
            _m_product.SaveMapFile();
        }

        //updates all properties witout images, images are pre-loaded, so cant be updated, 
        //Todo : Develop a mechanism to add/delete images in pre-loaded images, so that any changes in collection can refresh images also,. and user dont 
        // need to close and re-open form.
        private void UpdateProductModelToProductsViewWithoutImages()
        {
            //_vm_productsView = new ObservableCollection<ProductView>();
            foreach (var item in _m_product._productEntries)
            {
                foreach (var _v_item in _vm_productsView)
                {
                    if(item.InHouseCode == _v_item.InHouseCode)
                    {
                        _v_item.CostPrice = item.CostPrice;
                        _v_item.Description = item.Description;
                        _v_item.Tag = item.Tag;
                        _v_item.Notes = item.Notes;
                        _v_item.Title = item.Title;
                    }
                }
                
            }
        }


        private void UpdateProductViewFromProductsModelWithoutImages()
        {
            //_vm_productsView = new ObservableCollection<ProductView>();
            foreach (var v_item in _vm_productsView) 
            {
                foreach (var _m_item in _m_product._productEntries)
                {
                    if (v_item.InHouseCode == _m_item.InHouseCode)
                    {
                        _m_item.CostPrice = v_item.CostPrice;
                        _m_item.Description = v_item.Description;
                        _m_item.Tag = v_item.Tag;
                        _m_item.Notes = v_item.Notes;
                        _m_item.Title = v_item.Title;
                    }
                }

            }
        }

        private void FillFromProductModelToProductsViewWithoutImagesAndHandleUpdateEvents()
        {
            _vm_productsView = new ObservableCollection<ProductView>();
            foreach (var item in _m_product._productEntries)
            {
                var prod =
                new ProductView(
                    item.InHouseCode,
                    null, item.Title,
                    item.Tag,
                    item.Description,
                    item.AmazonCode,
                    item.FlipkartCode,
                    item.SnapdealCode,
                    item.MeeshoCode,
                    item.Notes);

                // Imp: this event handles all updates in _vm_productsView collection
                prod.PropertyChanged += (s, e) => { 
                    //UpdateProductModelToProductsViewWithoutImages();
                    _v_ssGridViewCntrl._isBindingListDirty = true;
                    WriteBackProductViewToProductsModel();
                };
                _vm_productsView.Add(prod);


            }

            //This event, will handles only add/remove from observable collection, for property updates, above propertyChanged event will fire.
            _vm_productsView.CollectionChanged += (sender, e) => {
                _v_ssGridViewCntrl._isBindingListDirty = true;
            };
        }


#region Event handlers for data grid view


        internal void BindDatagridEvents(SfDataGrid datagrid)
        {
            this._datagrid = datagrid;

            //datagrid.KeyDown += (s, e) => { grdmapGrid_KeyDown(datagrid, e); };

            datagrid.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete)
                {//Delete only if, selected cell's column name is a code/////
                 //var cells = _datagrid.GetSelectedCells();
                    bool amzCol = _datagrid.CurrentCell.Column.MappingName == Constants.PCols.AmazonCode;
                    bool spdCol = _datagrid.CurrentCell.Column.MappingName == Constants.PCols.SnapDealCode;
                    bool fkCol = _datagrid.CurrentCell.Column.MappingName == Constants.PCols.FlipkartCode;
                    bool msoCol = _datagrid.CurrentCell.Column.MappingName == Constants.PCols.MeeshoCode;

                    //TODO : Add Notes col also.. for deletion, in below code
                    if (amzCol || spdCol || fkCol || msoCol)//|| titleCol)
                    {
                        //datagrid.SelectedCells[0].Value = string.Empty;
                        _vm_productsView[_datagrid.CurrentCell.RowIndex][_datagrid.CurrentCell.ColumnIndex] = string.Empty;
                    }
                    e.SuppressKeyPress = true;
                }
            };

            datagrid.CurrentCellActivated += (s, e) =>
            {
               
                _v_productCntrl.amazonToolStripMenuItem.Enabled = _datagrid.CurrentCell.Column.MappingName == Constants.PCols.AmazonCode;
                _v_productCntrl.flipkartToolStripMenuItem.Enabled = _datagrid.CurrentCell.Column.MappingName == Constants.PCols.FlipkartCode;
                _v_productCntrl.snapdealToolStripMenuItem.Enabled = _datagrid.CurrentCell.Column.MappingName == Constants.PCols.SnapDealCode;
#if IncludeMeesho
                _v_productCntrl.meeshoToolStripMenuItem.Enabled = datagrid.SelectedCells?[0].OwningColumn.Name == Constants.PCols.MeeshoCode;
#endif
            };


            datagrid.CellDoubleClick += (s, e) =>
            {
                if (_datagrid.CurrentCell.Column.MappingName == Constants.MCols.amz_Code)
                    AmazonInvDecoder.OpenProductSearchURL(SyncFusionHelper.GetCellValue(_datagrid, _datagrid.CurrentCell.RowIndex, _datagrid.CurrentCell.ColumnIndex).ToString());
                if (_datagrid.CurrentCell.Column.MappingName == Constants.MCols.fK_Code)
                    FlipkartInvDecoder.OpenProductSearchURL(SyncFusionHelper.GetCellValue(_datagrid, _datagrid.CurrentCell.RowIndex, _datagrid.CurrentCell.ColumnIndex).ToString());
                if (_datagrid.CurrentCell.Column.MappingName == Constants.MCols.spd_Code)
                    SnapdealInvDecoder.OpenProductSearchURL(SyncFusionHelper.GetCellValue(_datagrid, _datagrid.CurrentCell.RowIndex, _datagrid.CurrentCell.ColumnIndex).ToString());
                if (_datagrid.CurrentCell.Column.MappingName == Constants.MCols.mso_Code)
                    MeeshoInvDecoder.OpenProductSearchURL(SyncFusionHelper.GetCellValue(_datagrid, _datagrid.CurrentCell.RowIndex, _datagrid.CurrentCell.ColumnIndex).ToString());
            };

            datagrid.CellClick += (s, e) =>
            {
                int count = 0;
                for (int i = 0; i < _vm_productsView.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(_vm_productsView[i][e.DataColumn.ColumnIndex]))
                        count++;
                }
                _v_ssGridViewCntrl.SetInfoLabel("Count: " + count.ToString());
            };

           

            // Add button Column
            _datagrid.Columns.Insert(0, new GridButtonColumn()
            {
                MappingName = "Edit",
                HeaderText = "Edit", DefaultButtonText = "✒",
                MaximumWidth = 40,MinimumWidth = 40,
                AllowDefaultButtonText = true, AllowHeaderTextWithImage = true
                //,Image = SystemIcons.Hand.ToBitmap(),
            });

            datagrid.CellButtonClick += _v_ssGridViewCntrl_OnGridButtonClicked;
            
            datagrid.QueryUnboundColumnInfo += (s, e) => {
                var r = ((ProductView)e.Record);
                string val;
                //e.Column.MappingName
                if (e.UnboundAction == UnboundActions.QueryData)
                {
                    _m_invoice.LineQty.TryGetValue(r.InHouseCode, out val);
                    e.Value = val==null?"0":val;
                }
                
                if (e.UnboundAction == UnboundActions.CommitData)
                    _m_invoice.LineQty.Add(r.InHouseCode, e.Value.ToString());
            };
        }

        //private Dictionary<string, string> LineQty =new Dictionary<string, string>(); //move this to a class


        private void grdmapGrid_KeyDown(Object datagrid, KeyEventArgs e)
        {

        }

        private void OpenLink(SfDataGrid datagrid)
        {

        }

        private void AddEditButton(SfDataGrid gridView)
        {

          
        }

        private void SetHyperlinks(SfDataGrid gridView)
        {
            
        }

        /// <summary>  
        /// This function is use to get hyperlink style .  
        /// </summary>  
        /// <returns></returns>  
        private System.Windows.Forms.DataGridViewCellStyle GetHyperLinkStyleForGridCell()
        {
            // Set the Font and Uderline into the Content of the grid cell .  
            System.Windows.Forms.DataGridViewCellStyle l_objDGVCS = new System.Windows.Forms.DataGridViewCellStyle();
            l_objDGVCS.ForeColor = Color.Blue;
            return l_objDGVCS;
        }

        internal void SearchTags(bool IsEnable, string textToSearch, BindingList<VM_Products.ProductView> bindedProducts)
        {
            bindedProducts.Clear();

            _vm_productsView.Where(y=> !string.IsNullOrEmpty(y.Tag)).ToList().Where((x) => 
            //if(!string.IsNullOrEmpty(x.Tag))
            x.Tag.ToLower().Contains(textToSearch.ToLower())).ToList().
                ForEach(p => bindedProducts.Add(p)
                );
        }

        internal void SearchTitle(bool IsEnable, string textToSearch, BindingList<VM_Products.ProductView> bindedProducts)
        {
            bindedProducts.Clear();
            _vm_productsView.Where(x => x.Title.ToLower().Contains(textToSearch.ToLower())).ToList().
                ForEach(p=> bindedProducts.Add(p));
        }

        internal void ResetBindings(bool IsEnable)
        {
            _v_ssGridViewCntrl.ClearBindingListRows();
            _v_ssGridViewCntrl.UpdateBindings();
        }

#endregion Event handlers for data grid view


        internal void AssignImagesToProducts(Dictionary<string, Image> imgs)
        {
            try
            {
                _images = imgs;
               
                foreach (var item in _vm_productsView)
                {
                    if (imgs.ContainsKey(item.InHouseCode))
                        item.Image = imgs[item.InHouseCode];
                }
            }
            catch(Exception e) {
                Logger.Log("Not able to assign image, AssignImagesToProducts()", Logger.LogLevel.error, false);
            }

        }



        //This class is used to filter product properties, only those, which are shown to user are kept in this class.
        //It is filled by iterating on Product model, any changes will be saved back into product model.
        internal class ProductView :INotifyPropertyChanged
        {
            //indexer to return sequence of properties in this class
            public string this[int index]
            {
                get
                {
                    string val="";
                    switch (index)
                    {
                        case Constants.FixedColumnsProductGrid + 0:
                            val = _inHouseCode; break;
                        case Constants.FixedColumnsProductGrid + 1:
                            val = string.Empty; break;
                        case Constants.FixedColumnsProductGrid + 2:
                            val = _title; break;
                        case Constants.FixedColumnsProductGrid + 3:
                            val = _tag; break;
                        case Constants.FixedColumnsProductGrid + 4:
                            val = _desc; break;
                        case Constants.FixedColumnsProductGrid + 5:
                            val = _amzCode; break;
                        case Constants.FixedColumnsProductGrid + 6:
                            val = _fkCode; break;
                        case Constants.FixedColumnsProductGrid + 7:
                            val = _spdCode; break;
#if IncludeMeesho
                        case Constants.FixedColumnsProductGrid + 8:
                            val = _msoCode; break;
                        case Constants.FixedColumnsProductGrid + 9:
                            val = _notes; break;
                        case Constants.FixedColumnsProductGrid + 10:
                            val = _costPrice; break;
#else
                        case Constants.FixedColumnsProductGrid + 8:
                            val = _notes; break;
                        case Constants.FixedColumnsProductGrid + 9:
                            val = _costPrice; break;
#endif
                        default:
                            break;
                    }
                    return val;
                }

                set
                {
                    //string val = "";
                    switch (index)
                    {
                        case Constants.FixedColumnsProductGrid + 0:
                            _inHouseCode= value; break;
                        case Constants.FixedColumnsProductGrid + 1:
                             break;
                        case Constants.FixedColumnsProductGrid + 2:
                             _title = value; break;
                        case Constants.FixedColumnsProductGrid + 3:
                             _tag = value; break;
                        case Constants.FixedColumnsProductGrid + 4:
                             _desc = value; break;
                        case Constants.FixedColumnsProductGrid + 5:
                             _amzCode = value; break;
                        case Constants.FixedColumnsProductGrid + 6:
                             _fkCode = value; break;
                        case Constants.FixedColumnsProductGrid + 7:
                             _spdCode = value; break;
#if IncludeMeesho
                        case Constants.FixedColumnsProductGrid + 8:
                             _msoCode= value; break;
                        case Constants.FixedColumnsProductGrid + 9:
                             _notes= value; break;
                        case Constants.FixedColumnsProductGrid + 10:
                             _costPrice= value; break;
#else
                        case Constants.FixedColumnsProductGrid + 8:
                             _notes = value; break;
                        case Constants.FixedColumnsProductGrid + 9:
                             _costPrice = value; break;
#endif
                        default:
                            break;
                    }
                    //return val;
                }
            }

            //bacling fields
            private string _inHouseCode;
            public string InHouseCode { get { return _inHouseCode; } set { _inHouseCode = value; NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Constants.PCols.InHouseCode)); 
                } }
            private Image _image;
            public Image Image { get { return _image; } set { _image = value; } }
            public byte[] DisplayImage { get { return ImageToByteArray(_image); }  }
            private string _title;
            public string Title { get { return _title; } set { _title = value; NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Constants.PCols.Title)); 
                } }
            private string _tag;
            public string Tag { get { return _tag; } set { _tag = value; NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Constants.PCols.Tag));
                    } }
            private string _desc;
            public string Description { get { return _desc; } set { _desc = value; NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Constants.PCols.Description)); 
                } }
            private string _amzCode;
            public string AmazonCode { get { return _amzCode; } set { _amzCode = value; NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Constants.PCols.AmazonCode)); 
                } }
            private string _fkCode;
            public string FlipkartCode { get { return _fkCode; } set { _fkCode = value; NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Constants.PCols.FlipkartCode));
                } }
            private string _spdCode;
            public string SnapdealCode { get { return _spdCode; } set{ _spdCode = value; NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Constants.PCols.SnapDealCode)); 
                } }
            private string _msoCode;
#if IncludeMeesho
            public string MeeshoCode { get { return _msoCode; } set { _msoCode = value; } }
#endif
            private string _notes;
            public string Notes { get { return _notes; } set { _notes = value; NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Constants.PCols.Notes)); 
                } }

            //optional columns, added on users request only
            private string _costPrice;
            public string CostPrice {  get { return _costPrice; } set { _costPrice = value; NotifyPropertyChanged();
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Constants.PCols.CostPrice)); 
                } }


            public event PropertyChangedEventHandler PropertyChanged;

            private byte[] ImageToByteArray(System.Drawing.Image imageIn)
            {
                if (imageIn == null) { return default(byte[]); }
                try
                {
                    MemoryStream ms = new MemoryStream();
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    return ms.ToArray();
                }catch { return default(byte[]); }
            }


            // This method is called by the Set accessor of each property.  
            // The CallerMemberName attribute that is applied to the optional propertyName  
            // parameter causes the property name of the caller to be substituted as an argument.  
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }


            public ProductView(string baseCodeValue, Image img, string title, string tag, string desc,
                string amzInventory, string fkCodeValue, string spdCodeValue,
                string msoCodeValue, string notes)
            {
                this.InHouseCode = baseCodeValue;
                this.Image = img;
                this.Title = title;
                this.Tag = tag;
                this.Description = desc;
                this.FlipkartCode = fkCodeValue;
                this.SnapdealCode = spdCodeValue;
#if IncludeMeesho
                this.MeeshoCode = msoCodeValue; 
#endif
                this.AmazonCode = amzInventory;
                this.Notes = notes;
            }
        }

        #endregion ssGridViewUserControl


        #region Prestashop

        private void ImportPrestaShopProducts()
        {
            PrestaShopSync presta = new PrestaShopSync();

            presta.button_DeleteUnlisted.Click += async (s, e) =>
            {
                StartUIPrestaProcess(presta);
                await UpdateProductsFromPresta(presta, PrestaShopImportType.DeletedUnlisted);
                ResetUIPrestaProcess(presta);
            };
            presta.button_FullSync.Click +=async (s, e) => {
                StartUIPrestaProcess(presta);
                await UpdateProductsFromPresta(presta, PrestaShopImportType.FullSync);
                ResetUIPrestaProcess(presta);
            };
            presta.button_UpdateOnly.Click += async (s, e) => {
                StartUIPrestaProcess(presta);
                await UpdateProductsFromPresta(presta, PrestaShopImportType.UpdateOnly); ResetUIPrestaProcess(presta);
            };
            presta.button_ImportOnly.Click += async (s, e) => { StartUIPrestaProcess(presta);
               await UpdateProductsFromPresta(presta, PrestaShopImportType.ImportNewOnly);
                ResetUIPrestaProcess(presta);
            };
            presta.button_HelpAccessKey.Click += (s, e) => { };
            presta.button_Stop.Click += (s, e) => {
                StoppingUIPrestaProcess(presta);
                  };
            presta.button_HelpPrestaURL.Click += (s, e) => { };
            presta.textBox_msg.TextChanged += (s, e) => {
                presta.textBox_msg.Focus();
                presta.textBox_msg.SelectionStart = presta.textBox_msg.Text.Length;
                presta.textBox_msg.ScrollToCaret();
            };
            presta.ShowDialog();
        }

        private void StartUIPrestaProcess(PrestaShopSync presta) {
            presta.progressBar_PrestaImport.Visible = true;
            presta.button_Stop.Visible = true; presta.CloseButtonVisible = false;
        }
        private void StoppingUIPrestaProcess(PrestaShopSync presta) 
        { presta.button_Stop.Text = "Please wait.."; presta.button_Stop.Enabled = false; PrestaShopCancelOperation = true; }

        private void ResetUIPrestaProcess(PrestaShopSync presta) { presta.button_Stop.Enabled = true; 
            presta.button_Stop.Text = "Stop"; presta.progressBar_PrestaImport.Visible = false;
            presta.button_Stop.Visible = false; PrestaShopCancelOperation = false; presta.CloseButtonVisible = true;
        }

        private async Task UpdateProductsFromPresta(PrestaShopSync presta, PrestaShopImportType importType)
        {
            string url = presta.SiteURL;        // "https://craftialcurve.com";
            string key = presta.SiteAccessKey;  // "LJRHJRHZX64C458CB3FFAXYNA32DNRZP";
            XmlDocument reponse = await PrestashopRestAPI.Prestashop_Get_xml(url, "/api/products", key);
            if (reponse == null) return;
            XmlNode products = reponse.SelectSingleNode("prestashop/products");
            if (products == null) return;
            if(importType == PrestaShopImportType.DeletedUnlisted)
                DeleteSellerSenseItemIfNotAvailableInPrestashop(presta, products);

            foreach (XmlNode item in products.ChildNodes)
            {
                if (PrestaShopCancelOperation)
                    break;
                if (item.Name == "product")
                {
                    Debugger.Log(0, "", item.Attributes["id"].Value);
                    presta.textBox_msg.Text = presta.textBox_msg.Text + "Prestashop product Id:" 
                        + item.Attributes["id"].Value + ", Searching reference.." + Environment.NewLine;
                    string method = "/api/products/" + item.Attributes["id"].Value;
                    XmlDocument prod = await PrestashopRestAPI.Prestashop_Get_xml(url, method, key);
                    if (prod != null)
                    {
                        XmlNode product = prod.SelectSingleNode("prestashop/product");
                        string reference = prod.SelectSingleNode("prestashop/product/reference").InnerText;
                        string name = prod.SelectSingleNode("prestashop/product/name").InnerText;
                        string description = prod.SelectSingleNode("prestashop/product/description").InnerText;
                        string shortDescription = prod.SelectSingleNode("prestashop/product/description_short").InnerText;
                        string price = prod.SelectSingleNode("prestashop/product/price").InnerText;
                        XmlNode imgLink = prod.SelectSingleNode("prestashop/product/id_default_image");

                        Debugger.Log(0, "info", reference);
                        
                        switch (importType)
                        {
                            case PrestaShopImportType.UpdateOnly:
                                Image img = await PrestashopRestAPI.Prestashop_Get_image(imgLink.Attributes["xlink:href"].Value, "", key);
                                if(img!=default(Image))
                                   UpdateInHouseListingFromPresta(presta, name, description, reference, shortDescription, img);
                                else
                                    presta.textBox_msg.Text = presta.textBox_msg.Text + "Image Error, Skipping:"
                                    + item.Attributes["id"].Value  + Environment.NewLine;
                                break;
                            case PrestaShopImportType.ImportNewOnly:
                                var prd =  _m_product._productEntries.FirstOrDefault(x => x.InHouseCode == reference);
                                if (prd == null) {
                                    Image imgA = await PrestashopRestAPI.Prestashop_Get_image(imgLink.Attributes["xlink:href"].Value, "", key);
                                    if (imgA != default(Image))
                                    {
                                        prd = new M_Product.ProductEntry(reference, "", "", "", "", "", "", "", "", "");
                                        CreateProductFromPrestashopAndUpdateView(presta, name, description, reference, shortDescription, imgA, prd);
                                        _m_product._productEntries.Add(prd);
                                    }
                                    else
                                        presta.textBox_msg.Text = presta.textBox_msg.Text + "Image Error, Skipping:"
                                        + item.Attributes["id"].Value + Environment.NewLine;
                                    
                                }
                                break;
                            case PrestaShopImportType.FullSync:
                                var prodi = _m_product._productEntries.FirstOrDefault(x => x.InHouseCode == reference);
                                if (prodi == null)
                                {
                                    Image imgA = await PrestashopRestAPI.Prestashop_Get_image(imgLink.Attributes["xlink:href"].Value, "", key);
                                    if (imgA != default(Image))
                                    {
                                        prodi = new M_Product.ProductEntry(reference, "", "", "", "", "", "", "", "", "");
                                        CreateProductFromPrestashopAndUpdateView(presta, name, description, reference, shortDescription, imgA, prodi);
                                        _m_product._productEntries.Add(prodi);
                                    }
                                    else
                                        presta.textBox_msg.Text = presta.textBox_msg.Text + "Image Error, Skipping:"
                                        + item.Attributes["id"].Value + Environment.NewLine;
                                }
                                else
                                {
                                    Image imge = await PrestashopRestAPI.Prestashop_Get_image(imgLink.Attributes["xlink:href"].Value, "", key);
                                    if (imge != default(Image))
                                    {
                                        UpdateInHouseListingFromPresta(presta, name, description, reference, shortDescription, imge);
                                    }
                                    else
                                        presta.textBox_msg.Text = presta.textBox_msg.Text + "Error, Skipping:"
                                        + item.Attributes["id"].Value + Environment.NewLine;
                                }
                                break;
                            //case PrestaShopImportType.DeletedUnlisted:
                            //    DeleteSellerSenseItemIfNotAvailableInPrestashop(reference);
                            //    break;
                            default:
                                return;
                        }
                    }
                }
                //TODO : When scrapping, disable window close button, coz closing window is not stopping scrapping. send cancelling token with stop button
            }

            
        }

        private async void DeleteSellerSenseItemIfNotAvailableInPrestashop(PrestaShopSync presta, XmlNode products)
        {
            //go throw all products from prestashop,
            //create a list, after compare this list with local seller sense list,
            // delete items which are present in local list, but not present in prestashop list.

            List<string> prestaReferences = new List<string>();
            List<string> MarkDeleteCodes = new List<string>();
            foreach (XmlNode item in products.ChildNodes)
            {
                if (PrestaShopCancelOperation)
                    break;
                if (item.Name == "product")
                {
                    string method = "/api/products/" + item.Attributes["id"].Value;
                    XmlDocument prod = await PrestashopRestAPI.Prestashop_Get_xml(presta.SiteURL, method, presta.SiteAccessKey);
                    if (prod != null)
                    {
                        XmlNode product = prod.SelectSingleNode("prestashop/product");
                        string reference = prod.SelectSingleNode("prestashop/product/reference").InnerText;
                        prestaReferences.Add(reference);
                        //string name = prod.SelectSingleNode("prestashop/product/name").InnerText;
                    }
                }
                foreach (var prod in _m_product._productEntries)
                {
                    var foundProdCode = prestaReferences.FirstOrDefault(x => x == prod.InHouseCode);
                    if (foundProdCode == null)
                    { MarkDeleteCodes.Add(prod.InHouseCode); }
                }
            }

            foreach (var item in MarkDeleteCodes)
            {
                var prod = _m_product._productEntries.FirstOrDefault(x => x.InHouseCode==item); 
                if (prod != null)
                    _m_product._productEntries.Remove(prod);
                _m_product.SaveMapFile();
            }
        }

        private void UpdateInHouseListingFromPresta(PrestaShopSync presta,string name,string description, string reference,
            string shortDescription, Image img)
        {
            foreach (var inHouseItem in _m_product._productEntries)
            {
                if (inHouseItem.InHouseCode == reference)
                {
                    CreateProductFromPrestashopAndUpdateView(presta, name, description, reference, shortDescription, img, inHouseItem);

                    //presta.textBox_msg.Refresh();
                }
            }
        }

        private void CreateProductFromPrestashopAndUpdateView(PrestaShopSync presta, string name, string description, 
            string reference, string shortDescription, Image img, M_Product.ProductEntry inHouseItem)
        {
            presta.textBox_msg.Text = presta.textBox_msg.Text + "Adding/Updating InHouse product:" + reference;
            var viewItem = _vm_productsView.FirstOrDefault(x => x.InHouseCode == reference);
            if (viewItem != null)
            {
                viewItem.Title = HTMLToJSON.EscJSONChar(name);
                viewItem.Description = HTMLToJSON.EscJSONChar(description);
                viewItem.Tag = HTMLToJSON.EscJSONChar(shortDescription);
                viewItem.Image = img;
            }
            _m_product.RemoveExistingProductImage(inHouseItem.InHouseCode);

            inHouseItem.Title = HTMLToJSON.EscJSONChar(name);
            inHouseItem.Description = HTMLToJSON.EscJSONChar(description);
            inHouseItem.Tag = HTMLToJSON.EscJSONChar(shortDescription);
            var path = _m_product.SaveImage(img, inHouseItem.InHouseCode, overwrite: true);
            inHouseItem.Image = Path.GetFileName(path);
            _m_product.SaveMapFile();
            presta.textBox_msg.Text = presta.textBox_msg.Text + "- Done" + Environment.NewLine;
        }


        #endregion


    }



}
