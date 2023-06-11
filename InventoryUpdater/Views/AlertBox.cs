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

        public AlertBox(string title, string msg, bool isError = true, string link= "")
        {
            _title = title;
            _msg = msg;
            _link = link;
            _isError = isError;
            InitializeComponent();
        }

        private void AlertBox_Load(object sender, EventArgs e)
        {
            lblTitle.Text = _title; 
            if (_isError)
                pictureBox2.Image = Image.FromFile("Images\\1138px-OOjs_UI_icon_alert-warning-black.svg.png");
            else
                pictureBox2.Image = Image.FromFile("Images\\Information.png");
            lnkLabelClick.Visible = !string.IsNullOrEmpty(_link);
            button2.Visible = _isError;
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
            this.Close();
        }
    }
}
