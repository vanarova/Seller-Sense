using Decoders;
using Decoders.Interfaces;
using SellerSense.Helper;
using SellerSense.Model;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Views.Products
{
    internal partial class ImportProductExcel : SfForm
    {
        public string CSVFileName { get; set; }
        public IList<INewProduct> NewProducts;
        public IList<IEditProduct> EditProducts;
        private M_Product _m_product;
        public ImportMode Mode;
        //public Action ExportProductsForBulkEdit;
        public enum ImportMode
        {
            Add, Edit
        }

        public ImportProductExcel(M_Product m_Product, Action exportProductsForBulkEdit)
        {
            InitializeComponent();
            _m_product = m_Product;
            //ExportProductsForBulkEdit = exportProductsForBulkEdit;
            //Mode = new ImportMode();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            CSVFileName = string.Empty;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Mode = ImportMode.Add;
            this.Close();
        }

        private void buttonBulkEdit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Mode = ImportMode.Edit;
            this.Close();
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = String.Empty;
            DialogResult res = openFileDialog1.ShowDialog();
            CSVFileName = openFileDialog1.FileName;
            if (res == DialogResult.OK && !string.IsNullOrEmpty(CSVFileName))
            {
                textBox_fileName.Text = CSVFileName;
                NewProducts = ProductDecoder.ImportNewProducts(CSVFileName, out string error, out string validationErrors);
                if (!string.IsNullOrEmpty(error))
                    new AlertBox("Error", error, null, true, "", "", "").ShowDialog();
                if (!string.IsNullOrEmpty(validationErrors))
                {
                    textBox_CSVResults.Text = validationErrors;
                    if (NewProducts != null && NewProducts.Count > 0)
                        NewProducts.Clear();
                }
                else if (NewProducts.Count > 0)
                    textBox_CSVResults.Text = "File Import Success!!" + Environment.NewLine +
                        NewProducts.Count + " products inserted.";
            }
        }

        private void button_EditBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = String.Empty;
            DialogResult res = openFileDialog1.ShowDialog();
            CSVFileName = openFileDialog1.FileName;
            if (res == DialogResult.OK &&  !string.IsNullOrEmpty(CSVFileName))
            {
                textBox_fileName.Text = CSVFileName;
                EditProducts = ProductDecoder.ImportProductsForEdit(CSVFileName, out string error, out string validationErrors);
                if (!string.IsNullOrEmpty(error))
                    new AlertBox("Error", error, null, true, "", "", "").ShowDialog();
                if (!string.IsNullOrEmpty(validationErrors))
                {
                    textBox_EditResults.Text = validationErrors;
                    if (EditProducts != null && EditProducts.Count > 0)
                        EditProducts.Clear();
                }
                else if (EditProducts.Count > 0)
                {
                    textBox_EditResults.Text = "File Import Success!!" + Environment.NewLine +
                        EditProducts.Count + " products edited.";

                }
            }
        }

        private void button_Cancel_Click_1(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            if (NewProducts != null && NewProducts.Count > 0)
                NewProducts.Clear();
            this.Close();
        }


        //Make this async
        private void linkLabel_downloadProducts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string folder = ProjIO.OpenFolderSelectionDialog();
            if (!string.IsNullOrEmpty(folder))
            {
                string filePath = ProductDecoder.ExportSampleProductTemplate(folder);
                (new AlertBox("Info", "Exported file : " + filePath, isError: false)).ShowDialog();
            }
        }

        private void button_Cancel_Edit_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void linkLabel_DownloadEditProducts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string folder = ProjIO.OpenFolderSelectionDialog();
            if (!string.IsNullOrEmpty(folder))
            {
                string folderPath = Path.GetDirectoryName(folder);
                List<IEditProduct> products = new List<IEditProduct>();
                foreach (var mprod in _m_product._productEntries)
                {
                    IEditProduct product = ProductDecoder.CreateNewEditProduct();
                    product.InHouseCode = mprod.InHouseCode;
                    //product.Image = mprod.Image;
                    //product.ImageAlt1 = mprod.ImageAlt1;
                    //product.ImageAlt2 = mprod.ImageAlt2;
                    //product.ImageAlt3 = mprod.ImageAlt3;
                    product.Title = mprod.Title;
                    product.Tag = mprod.Tag;
                    product.MRP = mprod.MRP;
                    product.SellingPrice = mprod.SellingPrice;
                    product.CostPrice = mprod.CostPrice;
                    product.Weight = mprod.Weight;
                    product.WeightAfterPackaging = mprod.WeightAfterPackaging;
                    product.DimensionsBeforePackaging = mprod.DimensionsBeforePackaging;
                    product.DimensionsAfterPackaging = mprod.DimensionsAfterPackaging;
                    product.Description = mprod.Description;
                    product.AmazonCode = mprod.AmazonCode;
                    product.AmazonSKU = mprod.AmazonSKU;
                    product.FlipkartCode = mprod.FlipkartCode;
                    product.FlipkartSKU = mprod.FlipkartSKU;
                    product.SnapdealCode = mprod.SnapdealCode;
                    product.SnapdealSKU = mprod.SnapdealSKU;
                    //product.MeeshoCode = mprod.MeeshoCode;
                    product.Notes = mprod.Notes;
                    products.Add(product);
                }
                string filePath = ProductDecoder.ExportProductsForEdit(products, folder);
                (new AlertBox("Info", "Exported file : " + filePath, isError: false)).ShowDialog();
            }
        }

    
    }
}
