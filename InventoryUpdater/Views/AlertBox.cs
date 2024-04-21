using SellerSense.Helper;
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
        private string _title { get; set; }
        private bool _isError { get; set; }
        private string _msg { get; set; }
        private string _link { get; set; }
        private string _button_ok_text;
        private string _button_cancel_text;
        private Exception ex;
        public DialogResult dialogResult;

        public AlertBox(string title, string msg, Exception ex = null, 
            bool isError = true, string link= "", string button_ok_text = ""
            ,string button_cancel_text = "")
        {
            _title = title;
            _msg = msg;
            _link = link;
            _isError = isError;
            this.ex = ex;
            _button_ok_text = button_ok_text;
            _button_cancel_text = button_cancel_text;
            InitializeComponent();
        }

        private void AlertBox_Load(object sender, EventArgs e)
        {
            lblTitle.Text = _title; 
            if (_isError)
                pictureBox2.Image = SellerSense.Properties.Resources._1138px_OOjs_UI_icon_alert_warning_black_svg;
            else
                pictureBox2.Image = SellerSense.Properties.Resources.Information;
            lnkLabelClick.Visible = !string.IsNullOrEmpty(_link);
            button_SendError.Visible = _isError;
            button_ExportLog.Visible = _isError;
            if (!string.IsNullOrEmpty(_button_ok_text))
                button_OK.Text = _button_ok_text;
            if (!string.IsNullOrEmpty(_button_cancel_text))
            {
                button_Cancel.Text = _button_cancel_text;
                button_Cancel.Visible = true;
            }
            txt_msg.Text = _msg;
            if (!string.IsNullOrEmpty(_link))
            {
                lnkLabelClick.Text = "Click here to open..";
                lnkLabelClick.LinkClicked += (s, ev) => { System.Diagnostics.Process.Start(_link); };
            }
        }

        //private void LnkLabelClick_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.OK;
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                  string logDir =  await ProjIO.ExportAllLogs(folderBrowserDialog.SelectedPath);
                    MessageBox.Show("Logs exported : " + logDir, "Info"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting logs, Please contact/search support forum, to manually copy logs", "Error"
                        ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              

            }
            //ProjIO.ExportAllLogs()
        }



        private void button_SendError_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/vanarova/Seller-Sense/issues");
            //if (ex != null)
            // FrBase.Messenger.WriteErrData(ex.Message + "; Inner Ex: " + ex.InnerException + "; Stack :" + ex.StackTrace);
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
