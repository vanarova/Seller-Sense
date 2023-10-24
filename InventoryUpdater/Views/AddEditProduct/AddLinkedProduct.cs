using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Views.AddEditProduct
{
    public partial class AddLinkedProduct : UserControl
    {
        private string _inHouseCode;
        private string _linkQty;

        public AddLinkedProduct(string InhouseCode)
        {
            InitializeComponent();
            _inHouseCode = InhouseCode; textBox_inhouseCode.Text = InhouseCode;
        }

        public AddLinkedProduct(string InhouseCode, string linkQty)
        {
            InitializeComponent();
            _inHouseCode = InhouseCode; textBox_inhouseCode.Text = InhouseCode;
            _linkQty = linkQty; textBox_LinkQty.Text = linkQty;
        }
    }
}
