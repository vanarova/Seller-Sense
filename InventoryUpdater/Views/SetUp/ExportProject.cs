using System;
using System.Windows.Forms;

namespace SellerSense.Views
{
    public partial class ExportProject : Form
    {
        private string _msg { get; set; }
        public bool IsLog { get; set; }
        public bool IsImgs { get; set; }
        public bool IsSnapshot { get; set; }
        public ExportProject( string msg)
        {
            _msg = msg;
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

        private void ExportProject_Load(object sender, EventArgs e)
        {
            label1.Text = "Exporting Map file as " + _msg + ".zip" +
                ", Do you also want to export below files(s)";
        }
    }
}
