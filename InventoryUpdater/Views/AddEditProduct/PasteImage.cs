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
    public partial class PasteImage : Form
    {
        internal Image _image;
        internal bool _isImg1;
        internal bool _isImg2;
        internal bool _isImg3;
        internal bool _isImg4;

        public PasteImage()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void pasteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetClipboardImage();
        }

        private void GetClipboardImage()
        {
            if (Clipboard.ContainsImage())
            {
                // Get the image from the clipboard
                Image image = Clipboard.GetImage();
                _image = image;
                // Do something with the image (e.g., display it)
                DisplayImage(image);
            }
        }

        private void DisplayImage(Image image)
        {
            pictureBox_display.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_display.Image = image;
            //pictureBox_display.BackgroundImage = image;
            pictureBox_display.ResumeLayout(true);
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            _isImg1 = radioButton_img1.Checked;
            _isImg2 = radioButton_img2.Checked;
            _isImg3 = radioButton_img3.Checked;
            _isImg4 = radioButton_img4.Checked; 
            pictureBox_display.Dispose();
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PasteImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                GetClipboardImage();
            }
        }
    }
}
