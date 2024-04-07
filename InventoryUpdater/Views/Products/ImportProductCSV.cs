using Decoders;
using Decoders.Interfaces;
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
    public partial class ImportProductCSV : Form
    {
        public string CSVFileName { get; set; }
        public IList<IProduct> Products;
        public ImportProductCSV()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            CSVFileName = string.Empty;
            this.Close();
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            CSVFileName = openFileDialog1.FileName;
            if (!string.IsNullOrEmpty(CSVFileName))
            {
                textBox_fileName.Text = CSVFileName;
                Products = ProductDecoder.ImportProducts(CSVFileName, out string error, out string validationErrors);
                if (!string.IsNullOrEmpty(error))
                    new AlertBox("Error", error, null, true, "", "", "").ShowDialog();
                if (!string.IsNullOrEmpty(validationErrors))
                {
                    textBox_CSVResults.Text = validationErrors;
                    if (Products != null && Products.Count > 0)
                        Products.Clear();
                }
                else
                    textBox_CSVResults.Text = "File Import Success!!";
            }
        }

        private void button_Cancel_Click_1(object sender, EventArgs e)
        {
            if(Products!=null && Products.Count>0)
                Products.Clear();
            this.Close();
        }
    }
}
