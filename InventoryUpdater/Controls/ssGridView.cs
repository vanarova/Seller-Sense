using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Controls
{
    public partial class ssGridView : UserControl
    {
        private int _currentPageNumber { get; set; }
        private int _TotalRowsInDataSet { get; set; }

        public ssGridView()
        {
            InitializeComponent();
        }

        private void button_First_Click(object sender, EventArgs e)
        {
            _currentPageNumber = 0;
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            _currentPageNumber--;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            _currentPageNumber++;
        }

        private void button_Last_Click(object sender, EventArgs e)
        {
            //_currentPageNumber=
        }
    }
}
