using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSearch
{
    public partial class Search : Form
    {
        public string _resultCode { get; set; }
        private string _searchPath;
        private List<string> _errors { get; set; }
        private CancellationTokenSource _cancelTokenSrc { get; set; }

        //public List<string> _resultImages { get; set; }

        public Search(string searchPath)
        {
            _searchPath = searchPath;
            
            //_thresholdV = thresholdV;
            InitializeComponent();
        }

        private void InitGrid()
        {
            if (dataGridView_imgSearchResults.Columns.Count == 0)
            {
                DataGridViewCheckBoxColumn cb = new DataGridViewCheckBoxColumn();
                cb.HeaderText = "Select"; cb.Width = 50;
                DataGridViewImageColumn prod = new DataGridViewImageColumn();
                prod.HeaderText = "Product"; prod.Width = 150;
                DataGridViewColumn filePath = new DataGridViewImageColumn();
                filePath.Visible = false; filePath.Name = "FilePath";
                dataGridView_imgSearchResults.Columns.Add(cb);
                dataGridView_imgSearchResults.Columns.Add(prod);
                dataGridView_imgSearchResults.Columns.Add(filePath);
                dataGridView_imgSearchResults.RowHeadersVisible = false;
                dataGridView_imgSearchResults.RowTemplate.Height = 125;
            }
        }


        //TODO : Rename all controls in program : default control name_context  like: button_dosomething
        private void Search_Load(object sender, EventArgs e)
        {
            SearchImageByImage();
            //Bitmap img = GetClipboardImage();
            //if (img != null)
            //{
            //    picBoxSrc.Image = img;
            //    progressBar_imgSearch.Visible = true;
            //    InitGrid();
            //    var progressHandle = new Progress<ImageSearchByImage.progressiveMatchList>();
            //    progressHandle.ProgressChanged += (s, ex) => {
            //        using (var bmpTemp = new Bitmap(ex.fileName))
            //        {
            //            dataGridView_imgSearchResults.Rows.Add(false, new Bitmap(bmpTemp, new Size(125, 125)) as Image); ;
            //        }
            //        if (!string.IsNullOrEmpty(ex.Error))
            //        {
            //            _errors.Add(ex.Error);
            //            label1.Text = "Warning: Some error occured while image search!";
            //        }
            //    };
            //    await ImageSearchByImage.SearchDirForImages(_searchPath, img, numericUpDown_threshold.Value, progressHandle);
            //    progressBar_imgSearch.Visible = false;
            //    //workaround by microsoft to fire checkbox sleect event - cellvaluechanged
            //    dataGridView_imgSearchResults.CellContentClick += (s, ev) => { dataGridView_imgSearchResults.CommitEdit(DataGridViewDataErrorContexts.Commit); };
            //    dataGridView_imgSearchResults.CellValueChanged += DataGridView_imgSearchResults_CellValueChanged;
            //}
        }

        private async void SearchImageByImage()
        {
            Bitmap img = GetClipboardImage();
            if (img != null)
            {
                picBoxSrc.Image = img;
                progressBar_imgSearch.Visible = true;
                InitGrid();
                var progressHandle = new Progress<ImageSearchByImage.progressiveMatchList>();
                progressHandle.ProgressChanged += (s, ex) => {
                    using (var bmpTemp = new Bitmap(ex.fileName))
                    {
                        dataGridView_imgSearchResults.Rows.Add(false, new Bitmap(bmpTemp, new Size(125, 125)) as Image, ex.fileName); ;
                    }
                    if (!string.IsNullOrEmpty(ex.Error))
                    {
                        _errors.Add(ex.Error);
                        label1.Text = "Warning: Some error occured while image search!";
                    }
                };

                //CancellationToken token = new CancellationToken();
                _cancelTokenSrc = new CancellationTokenSource();
                await ImageSearchByImage.SearchDirForImages(_searchPath, img, numericUpDown_threshold.Value, progressHandle, _cancelTokenSrc.Token);
                progressBar_imgSearch.Visible = false;
                //workaround by microsoft to fire checkbox sleect event - cellvaluechanged
                dataGridView_imgSearchResults.CellContentClick += (s, ev) => { dataGridView_imgSearchResults.CommitEdit(DataGridViewDataErrorContexts.Commit); };
                dataGridView_imgSearchResults.CellValueChanged += DataGridView_imgSearchResults_CellValueChanged;
            }
        }

        private void DataGridView_imgSearchResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==0 && (bool)dataGridView_imgSearchResults.SelectedCells[0].Value == true)
            {
                //unselect rest of rows
                foreach (DataGridViewRow row in dataGridView_imgSearchResults.Rows)
                {
                    if(row.Index != e.RowIndex) //except current row, all other rows
                     row.Cells[0].Value = false;
                }
                if (dataGridView_imgSearchResults.SelectedCells[0].OwningRow.Cells["FilePath"].Value != null)
                {
                    _resultCode = dataGridView_imgSearchResults.SelectedCells[0].OwningRow.Cells["FilePath"].Value.ToString();
                    _resultCode = Path.GetFileNameWithoutExtension(_resultCode);
                    //cancel more image search
                    _cancelTokenSrc.Cancel();
                }

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
            //Image img = GetClipboardImage();
            //if (img != null)
            //    picBoxSrc.Image = img;
            dataGridView_imgSearchResults.Rows.Clear();
            SearchImageByImage();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();   
        }


        //class Data
        //{
        //    public bool SelectImage { get; set; }
        //    public Image Image_Found { get; set; }
        //    public string Name { get; set; }
        //}


    }



}
