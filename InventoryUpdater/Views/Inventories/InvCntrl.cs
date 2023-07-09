using Decoders;
using SellerSense.ViewManager;
using SellerSense.Helper;
using System;
using System.Windows.Forms;
using ssViewControls;
using SellerSense.ViewManager;

namespace SellerSense
{
    public partial class InvCntrl : UserControl
    {
        Logger _logger;
        private VM_Company _company { get; set; }
        private ssGridView<VM_Inventories.InventoryView> cntrlGridView;

        public InvCntrl(VM_Company company)
        {
            InitializeComponent();
            _company = company;
            _logger = new FileLogger(company._code);
            
            // Add a child control, custom control using datagridview
            cntrlGridView = new ssGridView<VM_Inventories.InventoryView>(company._inventoriesViewManager._inventoryViewList);
            cntrlGridView.Dock = DockStyle.Fill;
            company._inventoriesViewManager.AssignViewManager(cntrlGridView);

            tableLayoutPanel1.Controls.Add(
                //sending list of M_Product
                cntrlGridView, 0,1);

        }

        
             
        

        private void toolStripMenuItemImgSearch_Click(object sender, EventArgs e)
        {
            
        }

      
    }
}
