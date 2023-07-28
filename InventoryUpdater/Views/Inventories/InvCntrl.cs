using Decoders;
using SellerSense.ViewManager;
using SellerSense.Helper;
using System;
using System.Windows.Forms;
using ssViewControls;
using SellerSense.ViewManager;
using System.IO;

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
            tableLayoutPanel1.SetColumnSpan(cntrlGridView, 2);
        }

        

        private void toolStripMenuItemImgSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog folderBrowser = new OpenFileDialog();
            //// Set validate names and check file exists to false otherwise windows will
            //// not let you select "Folder Selection."
            //folderBrowser.ValidateNames = false;
            //folderBrowser.CheckFileExists = false;
            //folderBrowser.CheckPathExists = true;
            //// Always default to Folder Selection.
            //folderBrowser.FileName = "Folder Selection";
            //if (folderBrowser.ShowDialog() == DialogResult.OK)
            //{
            //    string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
            //    _company._inventoriesModel.ExportAmazonInventoryFile(folderPath);
            //    _company._inventoriesModel.ExportFlipkartInventoryFile(folderPath);
            //    _company._inventoriesModel.ExportSnapdealInventoryFile(folderPath);
            //    _company._inventoriesModel.ExportMeeshoInventoryFile(folderPath);

            //    // ...
            //}
        }

        
    }
}
