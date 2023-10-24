using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgSearch
{
    public partial class ImageSearch : Form
    {
        public ImageSearch()
        {
            InitializeComponent();
        }

        private void ImageSearch_Load(object sender, EventArgs e)
        {
            Image img = GetClipboardImage();
            if(img != null)
                picBoxSrc.Image = img;
        }

        public System.Drawing.Image GetClipboardImage()
        {
            System.Drawing.Image returnImage = null;
            if (Clipboard.ContainsImage())
               returnImage = Clipboard.GetImage();
            return returnImage;
        }
    }
}
