using SellerSense.ViewManager;
using ssViewControls;
using System;
using System.Windows.Forms;

namespace SellerSense
{
    public partial class ProductCntrl : UserControl
    {
        //Logger _logger;
        public VM_Company _company { get; set; }
        private ssGrid.ssGridView<VM_Products.ProductView> cntrlGridView;

        public ProductCntrl(VM_Company company)
        {
            InitializeComponent();
            _company = company;
            //_logger = new FileLogger(company._code);

            // Add a child control, custom control using datagridview
            //cntrlGridView = new ssGrid.ssGridView<VM_Products.ProductView>();
            //cntrlGridView.Dock = DockStyle.Fill;
            ssGrid.ssGridView<VM_Products.ProductView> cntrlGridView = company._productsViewManager.CreateAndManageView_ProductGridUserControl();

            // Events of child control
            //cntrlGridView.SearchTitleTriggered += _company._products.SearchTitle;
            //cntrlGridView.SearchTagTriggered += _company._products.SearchTags;
            //cntrlGridView.ResetBindingsAfterSearchTriggered += _company._products.ResetBindings;
            //cntrlGridView.OnControlLoad += _company._products.OnControlLoadHandler;

            tableLayoutPanel1.Controls.Add(
                //sending list of M_Product
                cntrlGridView, 0,1);
            tableLayoutPanel1.SetColumnSpan(cntrlGridView, 2);

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
