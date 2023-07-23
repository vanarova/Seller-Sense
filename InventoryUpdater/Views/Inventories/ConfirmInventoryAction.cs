using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Views.Inventories
{
    public partial class ConfirmInventoryAction : Form
    {
        public bool AmazonChecked { get { return checkBox_amazon.Checked; } }
        public bool FlipkartChecked { get { return checkBox_flipkart.Checked; } }
        public bool SnapdealChecked { get { return checkBox_snapdeal.Checked; } }
        public bool MeeshoChecked { get { return checkBox_meesho.Checked; } }

        public ConfirmInventoryAction()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
