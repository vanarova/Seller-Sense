using Decoders;
using InventoryUpdater.ViewModelManager;
using SellerSense.Helper;
using System;
using System.Windows.Forms;
using ssViewControls;

namespace SellerSense
{
    public partial class ProductCntrl : UserControl
    {
        Logger _logger;
        public VM_Company _company { get; set; }

        public ProductCntrl(VM_Company company)
        {
            InitializeComponent();
            _company = company;
            _logger = new FileLogger(company._code);

            // Add a child control, custom control using datagridview
            var frm = new ssGridView<Model.Product.M_Product>(company._products._productGridData.products,
                company._images);
            frm.Dock = DockStyle.Fill;
            // Events of child control
            frm.DataBindingComplete += _company._products.DataGridDataBindingComplete;
            frm.SearchTitleTriggered += _company._products.SearchTitle;
            frm.SearchTagTriggered += _company._products.SearchTags;
            frm.ResetBindingsAfterSearchTriggered += _company._products.ResetBindings;

            tableLayoutPanel1.Controls.Add(
                //sending list of M_Product
                frm , 0,1);

        }

        

        private void ProductCntrl_Load(object sender, EventArgs e)
        {
            
           
        }

        
        

        private void toolStripMenuItemImgSearch_Click(object sender, EventArgs e)
        {
            //(bool doExist, string imgDir) = ProjIO.GetCompanyImageDirIfExist(_company._code);
            //if (doExist)
            //{
            //    ImageSearch.Search search = new ImageSearch.Search(imgDir);
            //    search.FormClosed += (s, ev) => { SearchDataGridForCode(search._resultCode); };
            //    search.ShowDialog();

            //}
        }

       

    }
}
