using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Controls
{


    internal partial class ssGridView<T> : UserControl
    {
        private int _currentPageNumber_backingField;
        private int _currentPageNumber { 
            get { return _currentPageNumber_backingField; }
            set { _currentPageNumber_backingField = value; UpdateBindings(); } 
        }
        //This action can be subscribed, outside this control, by parent control etc..
        //bool is to diable events
        private bool _EN = true; //set to false to disable all events.
        internal event Action<DataGridView> DataBindingComplete;
        internal event Action<bool> SearchCodeTriggered;
        internal event Action<bool> SearchTagTriggered;
        internal event Action<bool> ResetBindingsAfterSearchTriggered;
        
        private int _pageSize { get; set; }
        private int _lastPageNumber { get; set; }
        private int _TotalRowsInDataSet { get; set; }
        private List<T> _data = new List<T>();
        private BindingList<T> _bindeddata = new BindingList<T>();
        private Dictionary<string, Image> _imgs { get; set; }
        internal ssGridView(List<T> data, Dictionary<string, Image> imgs)
        {
            this._imgs = imgs;
            _data = data;
            _TotalRowsInDataSet = _data.Count;
            _pageSize = 100;
            _lastPageNumber = _TotalRowsInDataSet/_pageSize;
            InitializeComponent();
        }

        private void ssGridView_Load(object sender, EventArgs e)
        {
            AdjustUI();
            dataGridView_data.DataSource = _bindeddata;
            UpdateBindings();
            
        }

        private void AdjustUI()
        {
            dataGridView_data.AutoGenerateColumns = true;
            dataGridView_data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        }

        private void UpdateBindings()
        {
            _bindeddata.Clear();
            _data.Skip(_pageSize * _currentPageNumber).Take(_pageSize).ToList().ForEach(x=>_bindeddata.Add(x));
            label_PageNumbers.Text =_pageSize.ToString() + " rows, page: " + _currentPageNumber.ToString() + " of " + _lastPageNumber.ToString();

            //Dictionary<string, Image> imgs = Helper.ProjIO.LoadAllImagesAndDownSize75x75(_imgDir);
            //_map._mapEntries.ForEach((x) =>
            //{
            //    Image timg = imgs.Where(i => Path.GetFileName(i.Key) == x.Image).FirstOrDefault().Value;
            //    DataRow dr = ds.Tables[0].Rows.Add(timg, x.BaseCodeValue, x.Title, x.AmzCodeValue, x.FkCodeValue, x.SpdCodeValue, x.MsoCodeValue, x.Notes);
            //});

        }



        private void button_First_Click(object sender, EventArgs e)
        {
            _currentPageNumber = 0;
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            _currentPageNumber--;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            _currentPageNumber++;
        }

        private void button_Last_Click(object sender, EventArgs e)
        {
            _currentPageNumber = _lastPageNumber;
        }

        private void dataGridView_data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //var imgKey = _bindeddata[1].ToString();
            //if (dataGridView_data.Columns[e.ColumnIndex].Name == "Image")
            //{
            //    e.Value = _imgs[imgKey];
            //    e.FormattingApplied = true;
            //}
        }

        private void dataGridView_data_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dataGridView_data.Columns[Constants.MCols.amz_Code].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            //dataGridView_data.Columns[Constants.MCols.fK_Code].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            //dataGridView_data.Columns[Constants.MCols.spd_Code].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            //dataGridView_data.Columns[Constants.MCols.mso_Code].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            //dataGridView_data.RowHeadersVisible = false;
            if(DataBindingComplete!= null)
                DataBindingComplete(dataGridView_data);
        }

        /// <summary>  
        /// This function is use to get hyperlink style .  
        /// </summary>  
        /// <returns></returns>  
        private DataGridViewCellStyle GetHyperLinkStyleForGridCell()
        {
            // Set the Font and Uderline into the Content of the grid cell .  
            {
                DataGridViewCellStyle l_objDGVCS = new DataGridViewCellStyle();
                l_objDGVCS.ForeColor = Color.Blue;
                return l_objDGVCS;
            }
        }

        private void textBox_Code_Enter(object sender, EventArgs e)
        {
            textBox_Code.Text = "";
        }

        private void textBox_Code_Leave(object sender, EventArgs e)
        {
            textBox_Code.Text = "Code";
        }

        private void textBox_Title_Enter(object sender, EventArgs e)
        {
            textBox_Title.Text = "";
        }

        private void textBox_Title_Leave(object sender, EventArgs e)
        {
            textBox_Title.Text = "Title/Name";

        }

        private void textBox_Title_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Title.Text.Length >= 2 && !textBox_Title.Text.Equals("Tag"))
            {
                _bindeddata.Clear();
                if(SearchTagTriggered != null)
                    SearchTagTriggered(_EN);
                UpdateBindings();

            }else if (string.IsNullOrEmpty(textBox_Title.Text))
            {

                if (ResetBindingsAfterSearchTriggered != null) 
                    ResetBindingsAfterSearchTriggered(_EN);
            }
        }

        private void textBox_Code_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Code.Text.Length >= 2 && !textBox_Code.Text.Equals("Code"))
            {
                _bindeddata.Clear();
                if (SearchCodeTriggered != null)
                    SearchCodeTriggered(_EN);
                UpdateBindings();
            }
            else if (string.IsNullOrEmpty(textBox_Code.Text))
            {
                if(ResetBindingsAfterSearchTriggered!= null)
                    ResetBindingsAfterSearchTriggered(_EN);
            }
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            _EN = false; //disable all events
            textBox_Code.Text = String.Empty; //this fires event
            textBox_Title.Text = String.Empty;
            if (ResetBindingsAfterSearchTriggered != null)
                ResetBindingsAfterSearchTriggered(_EN);
            UpdateBindings();
            _EN = true; //enable back
        }
    }
}
