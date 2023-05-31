using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Views
{
    public partial class AlertBox : Form
    {
        public string _msg { get; set; }
        public AlertBox(string msg)
        {
            _msg = msg;
            InitializeComponent();
        }

        private void AlertBox_Load(object sender, EventArgs e)
        {
            txt_msg.Text = _msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
