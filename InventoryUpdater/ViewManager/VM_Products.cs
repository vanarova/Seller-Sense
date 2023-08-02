using Decoders;
using Newtonsoft.Json.Linq;
using SellerSense.Helper;
using SellerSense.Model;
using SellerSense.Views;
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
        internal List<ProductView> _vm_productsView { get; set; }
        private ProductCntrl _v_productCntrl;
        private ssGridView<ProductView> _v_ssGridViewCntrl;
        private DataGridView _datagrid;
        private M_External_Inventories _InventoriesModel;

        public VM_Products(M_Product m_Product,M_External_Inventories vm_Inventories)
        {
            _InventoriesModel = vm_Inventories;   
            _m_product = m_Product;
            TranslateProductModelToProductsView();
        }

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
            AddProduct _v_addproduct = new AddProduct();
            VM_AddProduct vm_addProduct = new VM_AddProduct(_v_addproduct);
            if(_v_addproduct.ShowDialog() == DialogResult.OK)
            {
                 Translate_AddEditProductObj_ToProduct_AndRefreshProductViewList(vm_addProduct.AddProductViewBindingObj);
            }
        }

        private void Translate_AddEditProductObj_ToProduct_AndRefreshProductViewList(VM_AddProduct.AddProductView addProductView)
        {
            string Image2Path = string.Empty, Image3Path = string.Empty, Image4Path = string.Empty;
            string primaryImagePath = _m_product.SaveImage(addProductView.PrimaryImage, addProductView.InHouseCode);
            if(addProductView.Image2!=null)
                Image2Path = _m_product.SaveImage(addProductView.Image2, addProductView.InHouseCode);
            if (addProductView.Image3 != null)
                Image3Path = _m_product.SaveImage(addProductView.Image3, addProductView.InHouseCode);
            if (addProductView.Image4 != null)
                Image4Path = _m_product.SaveImage(addProductView.Image4, addProductView.InHouseCode);
            if (string.IsNullOrEmpty(primaryImagePath))
                return;
             (_, var img) = ProjIO.LoadImageAndDownSize75x75(primaryImagePath);
            ProductView view = new ProductView(addProductView.InHouseCode,img, addProductView.Name
                , addProductView.Tag, addProductView.Description, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            view.AddInvisibleColumnsFields(primaryImagePath, Image2Path, Image3Path, Image4Path, addProductView.MRP,
                addProductView.SellingPrice, addProductView.Weight, addProductView.WeightAfterPackaging,
                addProductView.DimensionAfterPackaging, addProductView.DimensionBeforePackaging);
            _vm_productsView.Add(view);
            
        }

        internal void AssignViewManager(ProductCntrl pcntrl)
        {
            _v_productCntrl =pcntrl;
            HandleProductControlEvents();
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

        internal void AssignViewManager(ssGridView<ProductView> ssGrid)
        {
            _v_ssGridViewCntrl = ssGrid;
            HandlessGridViewControlEvents();
        }

        private void HandlessGridViewControlEvents()
        {
            _v_ssGridViewCntrl.SearchTitleTriggered += SearchTitle;
            _v_ssGridViewCntrl.SearchTagTriggered += SearchTags;
            _v_ssGridViewCntrl.ResetBindings += ResetBindings;
            _v_ssGridViewCntrl.OnControlLoad += OnControlLoadHandler;
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

        private void TranslateProductModelToProductsView()
        {
            _vm_productsView = new List<ProductView>();
            foreach (var item in _m_product._productEntries)
            {
                _vm_productsView.Add(new ProductView(
                    item.InHouseCode,
                    null, item.Title,
                    item.Tag,
                    item.Description,
                    item.AmazonCode,
                    item.FlipkartCode,
                    item.SnapdealCode,
                    item.MeeshoCode,
                    item.Notes));
            }
        }


# region Event handlers for data grid view


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
                    //var r_item =  _m_product._productEntries.FirstOrDefault(i=>i.InHouseCode == datagrid.SelectedCells[0].OwningRow.Cells[Constants.PCols.BaseCodeValue].Value.ToString());
                    //if (r_item!=null && amzCol)
                    //    r_item.AmazonCode = String.Empty;
                    //if (r_item != null && spdCol)
                    //    r_item.SnapdealCode = String.Empty;
                    //if (r_item != null && fkCol)
                    //    r_item.FlipkartCode = String.Empty;
                    //if (r_item != null && msoCol)
                    //    r_item.MeeshoCode = String.Empty;
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
            gridView.RowHeadersVisible = false;
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
            foreach (var item in _vm_productsView)
            {
                if (imgs.ContainsKey(item.InHouseCode))
                    item.Image = imgs[item.InHouseCode];

            }
        }




        //This class is used to filter product properties, only those, which are shown to user are kept in this class.
        //It is filled by iterating on Product model, any changes will be saved back into product model.
        internal class ProductView :INotifyPropertyChanged
        {
            //Below are invisible columns, marked as private, private fields are not visible while binding to datagrid.
            private string PrimaryImage;
            private string Image2;
            private string Image3;
            private string Image4;
            private string MRP;
            private string SellingPrice;
            private string Weight;
            private string WeightAfterPackaging;
            private string DimensionsAfterPackaging;
            private string DimensionsBeforePackaging;


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

            public event PropertyChangedEventHandler PropertyChanged;

            // This method is called by the Set accessor of each property.  
            // The CallerMemberName attribute that is applied to the optional propertyName  
            // parameter causes the property name of the caller to be substituted as an argument.  
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            internal void AddInvisibleColumnsFields(string primaryImage,string  image2,string image3,string image4,
                string mrp, string sellingPrice, string weight,string weightAfterPackaging, string dimensionsAfterPackaging,
                string dimensionsBeforePackaging)
            { 
                PrimaryImage = primaryImage;
                Image2 = image2;
                Image3 = image3;
                Image4 = image4;
                MRP = mrp;
                SellingPrice = sellingPrice;
                Weight = weight;
                WeightAfterPackaging = weightAfterPackaging;
                DimensionsAfterPackaging = dimensionsAfterPackaging;
                DimensionsBeforePackaging = dimensionsBeforePackaging;

            }

            //// This method is called by the Set accessor of each property.  
            //// The CallerMemberName attribute that is applied to the optional propertyName  
            //// parameter causes the property name of the caller to be substituted as an argument.  
            //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            //{
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //}

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
