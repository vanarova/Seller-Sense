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
    public partial class SingleNumericInputForm : Form
    {
        public string Result { get; set; }
        public SingleNumericInputForm(string FormHeading, string LabelText, string ButtonOkLabel)
        {
            InitializeComponent();
            this.Text = FormHeading;
            label_heading.Text = LabelText;
            button_ok.Text = ButtonOkLabel;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Result = numericUpDown1.Value.ToString();
            this.Close();
        }
    }
}
