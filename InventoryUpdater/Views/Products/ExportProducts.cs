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
    public partial class ExportProducts : Form
    {
        public bool IncludePrimaryImages { get { return checkBox_ExportPrimaryImages.Checked; } }
        public bool IncludeSecImages { get { return checkBox_ExportSecondaryImages.Checked; } }
        public bool IncludePrices { get { return checkBox_ExportPrices.Checked; } }

        private bool _exportTelegram;
        public bool ExportTelegram { get { return _exportTelegram; } }

        private bool _exportPDF;
        public bool ExportPDF { get { return _exportPDF; } }

        private bool _exportCSV;
        public bool ExportCSV { get { return _exportCSV; } }

        public ExportProducts()
        {
            InitializeComponent();
            _exportTelegram = false;
            _exportPDF = false;
            _exportCSV = false;
        }

        private void button_ExportToTelegram_Click(object sender, EventArgs e)
        {
            _exportTelegram = true; Close();
        }

        private void button_ExportPDF_Click(object sender, EventArgs e)
        {
            _exportPDF = true; Close();
        }

        private void button_ExportToCSV_Click(object sender, EventArgs e)
        {
            _exportCSV = true; Close();
        }
    }
}
