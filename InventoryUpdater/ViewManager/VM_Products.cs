using Decoders;
using SellerSense.Model;
using SellerSense.Model.Product;
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

namespace SellerSense.ViewModelManager
{
    internal class VM_Products
    {
        internal string _name;
        internal string _code;

        internal M_Product _productModel { get; set; }
        internal List<ProductView> _productsView { get; set; }
        
        //internal Dictionary<string, Image> _imgs;

        public VM_Products(M_Product map)
        {
            _productModel = map;
            TranslateProductModelToProductsView();
            //_productGridData = new M_Products(map._mapEntries);
            //_name = name;
            //_code = code;
        }

        internal void WriteBackProductViewToProductsModelAndSave()
        {
            foreach (var p in _productsView)
            {
                foreach (var m in _productModel._productEntries)
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
                //_productsView.Add(new ProductView(
                //    item.InHouseCode,
                //    null, item.Title,
                //    item.Description,
                //    item.Tag,
                //    item.AmazonCode,
                //    item.FlipkartCode,
                //    item.SnapdealCode,
                //    item.MeeshoCode,
                //    item.Notes));

            }
            _productModel.SaveMapFile();
        }

        private void TranslateProductModelToProductsView()
        {
            _productsView = new List<ProductView>();
            foreach (var item in _productModel._productEntries)
            {
                //Image timg = null;
                //if (_imgs.ContainsKey(item.Image))
                //    timg = _imgs[item.Image];

                _productsView.Add(new ProductView(
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
    

    /// Start - Event handlers for data grid view


    internal void OnControlLoadHandler(DataGridView datagrid)
        {
            //datagrid.CellValueChanged += (s, e) => {
            //    _isBindingListDirty = true; 

            //};

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

        //internal void BindingListChanged(object blist, ListChangedEventArgs e)
        //{
        //    if(e.OldIndex>0 && e.NewIndex>0 && e.OldIndex == e.NewIndex) //item changed, no insertion or deletion
        //    {
        //        //_productModel.SaveMapFile();
        //        //_productModel._productEntries.FirstOrDefault(
        //        //    x => x.InHouseCode == (blist as BindingList<ProductView>)[e.NewIndex].InHouseCode);
        //    }
        //}


        private void grdmapGrid_KeyDown(DataGridView datagrid, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {//Delet only if, selected cell's column name is a code/////
                bool amzCol = datagrid.SelectedCells[0].OwningColumn.Name == Constants.PCols.AmazonCode;
                bool spdCol = datagrid.SelectedCells[0].OwningColumn.Name == Constants.PCols.SnapDealCode;
                bool fkCol = datagrid.SelectedCells[0].OwningColumn.Name == Constants.PCols.FlipkartCode;
                bool msoCol = datagrid.SelectedCells[0].OwningColumn.Name == Constants.PCols.MeeshoCode;
                //bool titleCol = datagrid.SelectedCells[0].OwningColumn.Name == Constants.PCols.AmazonCode;

                //TODO : Move below business logic in VM - viewmodel layer.
                //TODO : Add Notes col also.. for deletion, in below code
                if (amzCol || spdCol || fkCol || msoCol )//|| titleCol)
                {
                    datagrid.SelectedCells[0].Value = string.Empty;
                  var r_item =  _productModel._productEntries.FirstOrDefault(i=>i.InHouseCode == datagrid.SelectedCells[0].OwningRow.Cells[Constants.PCols.BaseCodeValue].Value.ToString());
                    
                    //M_Map.MapEntry r_item = _productGridData.products.FirstOrDefault
                    //   (it => it.BaseCodeValue == datagrid.SelectedCells[0].OwningRow.Cells[Constants.ICols.Code].Value.ToString());
                    if (amzCol)
                        r_item.AmazonCode = String.Empty;
                    if (spdCol)
                        r_item.SnapdealCode = String.Empty;
                    if (fkCol)
                        r_item.FlipkartCode = String.Empty;
                    if (msoCol)
                        r_item.MeeshoCode = String.Empty;
                    //if (titleCol)
                    //    r_item.Title = String.Empty;
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
            {
                System.Windows.Forms.DataGridViewCellStyle l_objDGVCS = new System.Windows.Forms.DataGridViewCellStyle();
                //System.Drawing.Font l_objFont = new System.Drawing.Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline);
                //l_objDGVCS.Font = l_objFont;
                l_objDGVCS.ForeColor = Color.Blue;
                return l_objDGVCS;
            }
        }

        internal void SearchTags(bool IsEnable, string textToSearch, BindingList<VM_Products.ProductView> bindedProducts)
        {
            bindedProducts.Clear();

            _productsView.Where(y=> !string.IsNullOrEmpty(y.Tag)).ToList().Where((x) => 
            //if(!string.IsNullOrEmpty(x.Tag))
            x.Tag.ToLower().Contains(textToSearch.ToLower())).ToList().
                ForEach(p => bindedProducts.Add(p)
                );
        }

        internal void SearchTitle(bool IsEnable, string textToSearch, BindingList<VM_Products.ProductView> bindedProducts)
        {
            bindedProducts.Clear();
            _productsView.Where(x => x.Title.ToLower().Contains(textToSearch.ToLower())).ToList().
                ForEach(p=> bindedProducts.Add(p));
        }

        internal void ResetBindings(bool IsEnable)
        {

        }

        /// End - Event handlers for data grid view


        internal void AssignImagesToProducts(Dictionary<string, Image> imgs)
        {
            foreach (var item in _productsView)
            {
                if (imgs.ContainsKey(item.InHouseCode))
                    item.Image = imgs[item.InHouseCode];

            }
        }


        //This class is used to filter product properties, only those, which are shown to user are kept in this class.
        //It is filled by iterating on Product model, any changes will be saved back into product model.
        internal class ProductView  //:INotifyPropertyChanged
        {
            public string InHouseCode { get; set; }
            public Image Image { get; set; }
            public string Title { get; set; }
            public string Tag { get; set; }
            public string Description { get; set; }
            public string AmazonCode { get; set; }
            public string FlipkartCode { get; set; }
            public string SnapdealCode { get; set; }
            public string MeeshoCode { get; set; }
            public string Notes { get; set; }


            //public event PropertyChangedEventHandler PropertyChanged;

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
                //this.Id = Guid.NewGuid();
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






        //internal Dictionary<string, Image> LoadImages()
        //{
        //    //TODO : Remove background worker
        //    BackgroundWorker bg = new BackgroundWorker();

        //    bg.WorkerReportsProgress = true;
        //    bg.DoWork += (sender, doWorkEventArgs) =>
        //    {
        //        Dictionary<string,Image> imgs = Helper.ProjIO.LoadAllImagesAndDownSize75x75(_map._lastSavedMapImageDirectory);
        //    };
        //    bg.RunWorkerCompleted += (s, ev) =>
        //    {

        //    };
        //    bg.RunWorkerAsync();
        //}
    }

   

}
