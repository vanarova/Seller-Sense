using Decoders;
using Newtonsoft.Json.Linq;
using PrimitiveExt;
using SellerSense.Helper;
using SellerSense.Model;
using SellerSense.Views;
using SellerSense.Views.Products;
using ssViewControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.ViewManager
{
    //
    /// <summary>
    /// This is view manager class, manages all events and logic for one view tree.
    /// One form with all child user controls, are managed by one view manager, this VM manages product form 
    /// and all child user control forms.
    /// </summary>
    internal class VM_Products:IManageTwoUserControls
    {
        internal string _name;
        internal string _code;
        internal M_Product _m_product { get; set; }
        internal List<ProductView> _vm_productsView { get; set; }
        private ProductCntrl _v_productCntrl;
        private ssGridView<ProductView> _v_ssGridViewCntrl;
        private DataGridView _datagrid;
        private M_External_Inventories _InventoriesModel;
        private Dictionary<string, Image> _images;
        internal CompareProductView _compareProductViews;

        public VM_Products(M_Product m_Product,M_External_Inventories vm_Inventories, string companycode)
        {
            //_images = images;
            _code = companycode;
            _InventoriesModel = vm_Inventories;   
            _m_product = m_Product;
            _compareProductViews = new CompareProductView();
            FillFromProductModelToProductsViewWithoutImages();
        }

        public void AssignViewAManager(UserControl pcntrl)
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
            _v_productCntrl.toolStripMenuItem_Save.Click += (s, e) => {
                WriteBackProductViewToProductsModelAndSave();
                _v_ssGridViewCntrl._isBindingListDirty = false;
            };
            _v_productCntrl.amazonToolStripMenuItem.Click += (s, e) => { OpenInvFiller(Constants.Company.Amazon); };
            _v_productCntrl.flipkartToolStripMenuItem.Click += (s, e) => { OpenInvFiller(Constants.Company.Flipkart); };
            _v_productCntrl.snapdealToolStripMenuItem.Click += (s, e) => { OpenInvFiller(Constants.Company.Snapdeal); };
            _v_productCntrl.meeshoToolStripMenuItem.Click += (s, e) => { OpenInvFiller(Constants.Company.Meesho); };
            _v_productCntrl.button_AddProduct.Click += (s, e) => { OpenAddEditProductForm(); };
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
                //AddNewProductInProductModel();
                //FillFromProductModelToProductsView();
                //WriteBackProductViewToProductsModelAndSave();
            }
        }

      

        private void AddNewProductFromProductModelToProductView()
        {
            //Update, For existing items
            foreach (var product in _m_product._productEntries)
            {
                var productViewItem = _vm_productsView.Find(x => x.InHouseCode == product.InHouseCode);
                //For new Item
                if (productViewItem== null)
                { 
                    (_,Image img) = ProjIO.LoadImageUsingFileNameAndDownSize75x75(product.Image, _code);
                    var prod = new ProductView(product.InHouseCode, img,
                    product.Title, product.Tag, product.Description, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    //prod.AddInvisibleColumnsFields(product.Image, product.ImageAlt1, product.ImageAlt2, product.ImageAlt3,
                    //product.MRP, product.SellingPrice, product.Weight, product.WeightAfterPackaging, product.DimensionsAfterPackaging,
                    //product.DimensionsBeforePackaging);
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
                (_, var img) = ProjIO.LoadImageAndDownSize75x75(primaryImagePath);

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
                    if(img1 && !string.IsNullOrEmpty(primaryImagePath))
                        pEntry.Image = Path.GetFileName(primaryImagePath);
                    if (img2 && !string.IsNullOrEmpty(Image2Path))
                        pEntry.ImageAlt1 = Path.GetFileName(Image2Path);
                    if (img3 && !string.IsNullOrEmpty(Image3Path))
                        pEntry.ImageAlt2 = Path.GetFileName(Image3Path);
                    if (img4 && !string.IsNullOrEmpty(Image4Path))
                        pEntry.ImageAlt3 = Path.GetFileName(Image4Path);
                }
                FillFromProductModelToProductsViewWithoutImages();
            }
        }

        private void SaveImages(VM_AddProduct.AddProductView addProductView, ref string primaryImagePath,
            ref string Image2Path, ref string Image3Path, ref string Image4Path)
        {
            (bool img1, bool img2, bool img3, bool img4) = addProductView.GetDirtyImages();
            //SAVE IMAGE ONLY, IF NEW PRODUCT ENTRY OR IN EDIT MODE, IF IMAGE IS DIRTY
            if (img1 || !addProductView.EditMode)
                primaryImagePath = _m_product.SaveImage(addProductView.PrimaryImage, addProductView.InHouseCode, overwrite: addProductView.EditMode);
            if (addProductView.Image2 != null && (img2 || !addProductView.EditMode))
                Image2Path = _m_product.SaveImage(addProductView.Image2, addProductView.InHouseCode + "_2", overwrite: addProductView.EditMode); //overwrite image, in case of edit mode
            if (addProductView.Image3 != null && (img3 || !addProductView.EditMode))
                Image3Path = _m_product.SaveImage(addProductView.Image3, addProductView.InHouseCode + "_3", overwrite: addProductView.EditMode);
            if (addProductView.Image4 != null && (img4 || !addProductView.EditMode))
                Image4Path = _m_product.SaveImage(addProductView.Image4, addProductView.InHouseCode + "_4", overwrite: addProductView.EditMode);
        }

      



        
        private void OpenInvFiller(Constants.Company company)
        {
            int selectedRow = _datagrid.SelectedCells[0].RowIndex;
            //_productModel._productEntries.FirstOrDefault()
            Image selectedImg = _datagrid[Constants.PCols.Image, selectedRow].Value as Image;
            string selectedCode = _datagrid[Constants.PCols.InHouseCode, selectedRow].Value.ToString();
            string selectedTitle = _datagrid[Constants.PCols.Title, selectedRow].Value.ToString();

            InvFiller inf = new InvFiller(company, selectedImg, selectedCode, selectedTitle, _InventoriesModel);
            inf.ShowDialog();
            //assign map ID
            if (inf.SelectedID != null && !string.IsNullOrEmpty(inf.SelectedID))
            {
                _datagrid.SelectedCells[0].Value = inf.SelectedID;
                _datagrid.SelectedCells[0].Style.BackColor = Color.LightGreen;
            }
        }


        #endregion ProductUserControl


        #region ssGridViewUserControl

        public void AssignViewBManager(UserControl ssGrid)
        {
            _v_ssGridViewCntrl = ssGrid as ssGridView<ProductView>;
            HandlessGridViewControlEvents();
        }

        private void HandlessGridViewControlEvents()
        {
            _v_ssGridViewCntrl.SearchTitleTriggered += SearchTitle;
            _v_ssGridViewCntrl.SearchTagTriggered += SearchTags;
            _v_ssGridViewCntrl.ResetBindings += ResetBindings;
            _v_ssGridViewCntrl.OnControlLoad += OnControlLoadHandler;
            _v_ssGridViewCntrl.OnGridButtonClicked += _v_ssGridViewCntrl_OnGridButtonClicked; ;
            _v_ssGridViewCntrl.SelectedRowsActionButtonClicked += _v_ssGridViewCntrl_OnGridButtonActionSelectedClicked;
        }

        private void _v_ssGridViewCntrl_OnGridButtonActionSelectedClicked(EventList<ProductView> toExportList)
        {
            ExportProducts exportProducts = new ExportProducts();
            string message = string.Empty;
            exportProducts.FormClosed += (s, e) => {
                if (!exportProducts.ExportTelegram)
                    return;
                foreach (var item in toExportList)
                {
                    message = item.InHouseCode + " " + item.Title;
                    if (exportProducts.IncludePrices)
                    {
                        var prod = _m_product._productEntries.Find(x => x.InHouseCode == item.InHouseCode);
                        if (prod != null) { message = message + " Rs: " + prod.SellingPrice; }
                    }
                    if (exportProducts.IncludePrimaryImages)
                    {
                       (string filePath, string fileName)= ProjIO.GetImageFilePath(_code, item.InHouseCode);
                        Logger.TelegramMedia(filePath, fileName, message,Logger.LogLevel.info, _code);
                    }
                    else
                    {
                        Logger.Telegram(message);
                    }
                    //if (exportProducts.IncludePrimaryImages)
                    //    Logger.Log(item., Logger.LogLevel.info, false);
                   
                       
                }
            };
            exportProducts.ShowDialog();
            //below code may not be needed..
            //DataGridViewRow[] rowsSelected = new DataGridViewRow[grid.SelectedRows.Count];
            //grid.SelectedRows.CopyTo(rowsSelected, 0);
            //here dialog shud be able to handle all selected rows in all pages
            //open dialog and select export options and send msg to telegram.
        }

        private void _v_ssGridViewCntrl_OnGridButtonClicked(DataGridView grid, int rowIndex, int colIndex)
        {
            string inhouseCode = grid.Rows[rowIndex].Cells[Constants.PCols.InHouseCode].Value.ToString();
            if (!string.IsNullOrEmpty(inhouseCode))
            {
                var prod = _m_product._productEntries.Find(x => x.InHouseCode == inhouseCode);
                if (prod == null)
                    return;
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
            var itemToDel = _vm_productsView.Find(x => x.InHouseCode == product.InHouseCode);
            _m_product.DeleteProductImage(product.Image);
            _m_product.DeleteProductImage(product.ImageAlt1);
            _m_product.DeleteProductImage(product.ImageAlt2);
            _m_product.DeleteProductImage(product.ImageAlt3);
            if (itemToDel != null)
                _vm_productsView.Remove(itemToDel);
            _m_product._productEntries.Remove(product);
            _v_ssGridViewCntrl.Invalidate();

        }

        internal void WriteBackProductViewToProductsModelAndSave()
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
                        m.MeeshoCode = p.MeeshoCode;
                        
                    }
                }

            }
            _m_product.SaveMapFile();
        }

        

        private void FillFromProductModelToProductsViewWithoutImages()
        {
            _vm_productsView = new List<ProductView>();
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
               
                _vm_productsView.Add(prod);


            }
        }


        #region Event handlers for data grid view


        internal void OnControlLoadHandler(DataGridView datagrid)
        {
            this._datagrid = datagrid;
            datagrid.CellEnter += (s, e) =>
            {
                if (datagrid.SelectedCells.Count <= 0)
                    return;
                _v_productCntrl.amazonToolStripMenuItem.Enabled = datagrid.SelectedCells?[0].OwningColumn.Name == Constants.PCols.AmazonCode;
                _v_productCntrl.flipkartToolStripMenuItem.Enabled = datagrid.SelectedCells?[0].OwningColumn.Name == Constants.PCols.FlipkartCode;
                _v_productCntrl.snapdealToolStripMenuItem.Enabled = datagrid.SelectedCells?[0].OwningColumn.Name == Constants.PCols.SnapDealCode;
                _v_productCntrl.meeshoToolStripMenuItem.Enabled = datagrid.SelectedCells?[0].OwningColumn.Name == Constants.PCols.MeeshoCode;
            };

            datagrid.DataBindingComplete += (s, e) =>
            {
                SetHyperlinks(datagrid);
                AddEditButton(datagrid);
            };

            datagrid.CellMouseDoubleClick += (s, e) => {
                OpenLink(datagrid);
            };

            datagrid.KeyDown += (s, e) => { grdmapGrid_KeyDown(datagrid, e); };
        }

       
        private void grdmapGrid_KeyDown(DataGridView datagrid, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {//Delet only if, selected cell's column name is a code/////
                bool amzCol = datagrid.SelectedCells[0].OwningColumn.Name == Constants.PCols.AmazonCode;
                bool spdCol = datagrid.SelectedCells[0].OwningColumn.Name == Constants.PCols.SnapDealCode;
                bool fkCol = datagrid.SelectedCells[0].OwningColumn.Name == Constants.PCols.FlipkartCode;
                bool msoCol = datagrid.SelectedCells[0].OwningColumn.Name == Constants.PCols.MeeshoCode;

                //TODO : Add Notes col also.. for deletion, in below code
                if (amzCol || spdCol || fkCol || msoCol )//|| titleCol)
                {
                    datagrid.SelectedCells[0].Value = string.Empty;
                    
                }
                e.SuppressKeyPress = true;
            }
        }

        private void OpenLink(DataGridView datagrid)
        {
            if (datagrid.CurrentCell.OwningColumn.Name == Constants.MCols.amz_Code)
                AmazonInvDecoder.OpenProductSearchURL(datagrid.CurrentCell.EditedFormattedValue.ToString());
            if (datagrid.CurrentCell.OwningColumn.Name == Constants.MCols.fK_Code)
                FlipkartInvDecoder.OpenProductSearchURL(datagrid.CurrentCell.EditedFormattedValue.ToString());
            if (datagrid.CurrentCell.OwningColumn.Name == Constants.MCols.spd_Code)
                SnapdealInvDecoder.OpenProductSearchURL(datagrid.CurrentCell.EditedFormattedValue.ToString());
            if (datagrid.CurrentCell.OwningColumn.Name == Constants.MCols.mso_Code)
                MeeshoInvDecoder.OpenProductSearchURL(datagrid.CurrentCell.EditedFormattedValue.ToString());
        }

        private void AddEditButton(DataGridView gridView)
        {
            Padding newPadding = new Padding(2, 30, 2, 20);
            FontFamily fontFamily = new FontFamily("Segoe UI");
            Font font = new Font(
               fontFamily,
               10,
               FontStyle.Regular,
               GraphicsUnit.Point);
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit";
            editButtonColumn.Text = "\uD83D\uDD8D";// "\u270E"; //"\u2713";
            editButtonColumn.UseColumnTextForButtonValue = true;
            editButtonColumn.Width = 40;
            editButtonColumn.DefaultCellStyle.Font = font;
            editButtonColumn.DefaultCellStyle.Padding = newPadding;
            int columnIndex = 0;
            if (gridView.Columns["Edit"] == null)
            {
                gridView.Columns.Insert(columnIndex, editButtonColumn);
            }
        }

        private void SetHyperlinks(System.Windows.Forms.DataGridView gridView)
        {
            gridView.Columns[Constants.PCols.AmazonCode].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            gridView.Columns[Constants.PCols.FlipkartCode].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            gridView.Columns[Constants.PCols.SnapDealCode].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            gridView.Columns[Constants.PCols.MeeshoCode].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            //gridView.RowHeadersVisible = false;
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
            

            //bacling fields
            private string _inHouseCode;
            public string InHouseCode { get { return _inHouseCode; } set { _inHouseCode = value; } }
            private Image _image;
            public Image Image { get { return _image; } set { _image = value; } }
            private string _title;
            public string Title { get { return _title; } set { _title = value; } }
            private string _tag;
            public string Tag { get { return _tag; } set { _tag = value; } }
            private string _desc;
            public string Description { get { return _desc; } set { _desc = value; } }
            private string _amzCode;
            public string AmazonCode { get { return _amzCode; } set { _amzCode = value; } }
            private string _fkCode;
            public string FlipkartCode { get { return _fkCode; } set { _fkCode = value; } }
            private string _spdCode;
            public string SnapdealCode { get { return _spdCode; } set{ _spdCode = value; } }
            private string _msoCode;
            public string MeeshoCode { get { return _msoCode; } set { _msoCode = value; } }
            private string _notes;
            public string Notes { get { return _notes; } set { _notes = value; } }

            ////optional columns, added on users request only
            //private string _itemWeight;
            //public string ItemWeight   {   get { return _itemWeight; }  set { _itemWeight = value; }
            //}


            public event PropertyChangedEventHandler PropertyChanged;

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
                this.MeeshoCode = msoCodeValue;
                this.AmazonCode = amzInventory;
                this.Notes = notes;
            }
        }

        #endregion ssGridViewUserControl

    }



}
