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
        //public List<string> _resultImages { get; set; }

        public Search(string searchPath)
        {
            _searchPath = searchPath;
            //_thresholdV = thresholdV;
            InitializeComponent();
        }
        //TODO : Rename all controls in program : default control name_context  like: button_dosomething
        private  async void Search_Load(object sender, EventArgs e)
        {
            Bitmap img = GetClipboardImage();
            if (img != null)
            {
                picBoxSrc.Image = img;
                progressBar_imgSearch.Visible = true;
                var progressHandle = new Progress<ImageSearchByImage.progressiveMatchList>();
                progressHandle.ProgressChanged += (s, ex) => {
                    DataGridViewRow dr = new DataGridViewRow();
                    //dr.
                    dataGridView_imgSearchResults.Rows.Add(false,ex.fileName, ex.Error);
                };
                await ImageSearchByImage.SearchDirForImages(_searchPath, img, numericUpDown_threshold.Value, progressHandle);
                progressBar_imgSearch.Visible = false;

                //_resultImages = await ImageSearchByImage.SearchDirForImages(_searchPath, img);
            }
        }

        public Bitmap GetClipboardImage()
        {
            Bitmap returnImage = null;
            if (Clipboard.ContainsImage())
                returnImage = Clipboard.GetImage() as Bitmap;
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
