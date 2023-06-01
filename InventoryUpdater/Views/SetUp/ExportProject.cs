using System;
using System.Windows.Forms;

namespace SellerSense.Views
{
    public partial class ExportProject : Form
    {
        public bool IsLog { get; set; }
        public bool IsImgs { get; set; }
        public bool IsSnapshot { get; set; }
        public ExportProject()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            IsLog = chk_error.Checked;
            IsImgs = chk_img.Checked;
            IsSnapshot = chk_snapshot.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
