using CommonUtil;
using Decoders;
using SellerSense.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Views.Products
{
    internal partial class ProductMapSKUs : Form
    {
        private M_Product _m_product;
        private Constants.Company _companyCode;
        internal int _assignedCount; // number of SKUs assigned to corresponding asins
        public ProductMapSKUs(M_Product m_product, Constants.Company companyCode)
        {
            _m_product = m_product;
            _companyCode = companyCode;
            InitializeComponent();
        }



        private void Button_LoadInventory_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            MapAmzInv(openFileDialog);
            MapFkInv(openFileDialog);
            MapSpdInv(openFileDialog);

        }

        private void MapSpdInv(OpenFileDialog openFileDialog)
        {
            if (_companyCode == Constants.Company.Snapdeal)
            {
                openFileDialog.Filter = "Snapdeal file|*.xls*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var spd_inv = SnapdealInvDecoder.GetData(openFileDialog.FileName);
                    foreach (var item in spd_inv)
                    {
                        //assign SKU to corresponding asin.
                        var product = _m_product._productEntries.Find(x => !string.IsNullOrWhiteSpace(item.fsn) && !string.IsNullOrWhiteSpace(x.SnapdealCode) && x.SnapdealCode == item.fsn);
                        if (product != null)
                        {
                            product.SnapdealSKU = item.sku;
                            _assignedCount++;
                        }
                    }
                    label_AssignedProductCount.Text = "Assigned Product Count: " + _assignedCount.ToString();


                }
            }
        }

        private void MapFkInv(OpenFileDialog openFileDialog)
        {
            if (_companyCode == Constants.Company.Flipkart)
            {

                openFileDialog.Filter = "Flipkart file|*.xls*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fk_inv = FlipkartInvDecoder.GetDataV2(openFileDialog.FileName, out string error);
                    foreach (var item in fk_inv)
                    {
                        //assign SKU to corresponding asin.
                        var product = _m_product._productEntries.Find(x => !string.IsNullOrWhiteSpace(item.fsn) && !string.IsNullOrWhiteSpace(x.FlipkartCode) && x.FlipkartCode == item.fsn);
                        if (product != null)
                        {
                            product.FlipkartSKU = item.sku;
                            _assignedCount++;
                        }
                    }
                    label_AssignedProductCount.Text = "Assigned Product Count: " + _assignedCount.ToString();


                }
            }
        }

        private void MapAmzInv(OpenFileDialog openFileDialog)
        {
            if (_companyCode == Constants.Company.Amazon)
            {
                openFileDialog.Filter = "Amazon inv text file|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var amz_inv = AmazonInvDecoder.ImportAmazonInventory(openFileDialog.FileName,
                Properties.Resources.amazon_inv_sku, 
                Properties.Resources.amazon_inv_asin, 
                Properties.Resources.amazon_inv_price,
                Properties.Resources.amazon_inv_qty);
                    foreach (var item in amz_inv)
                    {
                        //assign SKU to corresponding asin.
                        var product = _m_product._productEntries.Find(x => !string.IsNullOrWhiteSpace(item.asin) && !string.IsNullOrWhiteSpace(x.AmazonCode) && x.AmazonCode == item.asin);
                        if (product != null)
                        {
                            product.AmazonSKU = item.sku;
                            _assignedCount++;
                        }
                    }
                    label_AssignedProductCount.Text = "Assigned Product Count: " + _assignedCount.ToString();


                }
            }
        }

        private void ProductMapSKUs_Load(object sender, EventArgs e)
        {
            _assignedCount = 0;
        }
    }
}
