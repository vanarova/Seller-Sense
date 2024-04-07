using SellerSense.ViewManager;
using ssViewControls;
using System;
using System.Windows.Forms;

namespace SellerSense
{
    public partial class InvCntrl : UserControl
    {
        //Logger _logger;
        private VM_Company _company { get; set; }
        private ssGrid.ssGridView<VM_Inventories.InventoryView> cntrlGridView;

        public InvCntrl(VM_Company company)
        {
            InitializeComponent();
            _company = company;
            //_logger = new FileLogger(company._code);

            // Add a child control, custom control using datagridview
            //cntrlGridView = new ssGrid.ssGridView<VM_Inventories.InventoryView>(company._inventoriesViewManager._inventoryViewList);
            //cntrlGridView.Dock = DockStyle.Fill;
            cntrlGridView = company._inventoriesViewManager.AssignView(company) as ssGrid.ssGridView<VM_Inventories.InventoryView>;

            tableLayoutPanel1.Controls.Add(
                //sending list of M_Product
                cntrlGridView, 0,1);
            tableLayoutPanel1.SetColumnSpan(cntrlGridView, 2);
        }

        

        private void toolStripMenuItemImgSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void label_Help_Click(object sender, EventArgs e)
        {
            (new Docs.Help(Docs.Constants.HelpTopic.Orders)).ShowDialog();
        }
    }
}
