using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSearch
{
    public partial class Search : Form
    {
        public string _resultCode { get; set; }
        private string _searchPath;
        private List<Data> _dataList { get; set; }

        public Search(string searchPath)
        {
            _searchPath = searchPath;
            InitializeComponent();
        }
        //TODO : Rename all controls in program : default control name_context  like: button_dosomething
        private void Search_Load(object sender, EventArgs e)
        {
            Image img = GetClipboardImage();
            if (img != null)
            {
                picBoxSrc.Image = img;

            }
        }

        public System.Drawing.Image GetClipboardImage()
        {
            System.Drawing.Image returnImage = null;
            if (Clipboard.ContainsImage())
                returnImage = Clipboard.GetImage();
            return returnImage;
        }

        private void btn_pasteImg_Click(object sender, EventArgs e)
        {
            Image img = GetClipboardImage();
            if (img != null)
                picBoxSrc.Image = img;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();   
        }


        class Data
        {
            public bool SelectImage { get; set; }
            public Image Image_Found { get; set; }
            public string Name { get; set; }
        }


    }



}
