using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssViewControls
{

    /// <summary>
    /// Story:
    /// This view is created by using grid and other form controls, grid is binded with a binding list
    /// This binding list contains 1 page at a time. Another collection in this page contains full list including all pages.
    /// Paging is implemented in this view, For all other logic a view manager is responsible.
    /// All the events are handled by view manager class : VM_[Class name]
    /// This view is used at multiple places in different forms, each managed by respective view managers
    /// </summary>
    /// <typeparam name="T">Type of class, used for binding data in grid</typeparam>

    public partial  class ssGridView<T> : UserControl
    {
        private int _currentPageNumber_backingField;
        private int _currentPageNumber { 
            get { return _currentPageNumber_backingField; }
            set { _currentPageNumber_backingField = value; UpdateBindings(); } 
        }
        private bool _isBindingListDirtyValue = false;
        public bool _isBindingListDirty { get { return _isBindingListDirtyValue; } 
            set {  
                _isBindingListDirtyValue = value;
                if(value)
                    panel_isDirty.BackColor = Color.Red;
                else
                    panel_isDirty.BackColor = Color.Transparent;
            }
        }

        
        private const string _tag = "Tag", _title = "Title";
        //This action can be subscribed, outside this control, by parent control etc..
        //bool is to diable events
        private bool _EN = true; //set to false to disable all events.
        public event Action<bool, string, BindingList<T>> SearchTitleTriggered;
        public event Action<bool,string, BindingList<T>> SearchTagTriggered;
        public event Action<bool> ResetBindingsAfterSearchTriggered;
        public event Action<DataGridView> OnControlLoad;
        
        private int _pageSize { get; set; }
        private int _lastPageNumber { get; set; }
        private int _TotalRowsInDataSet { get; set; }

        /// <summary> full data list, contains all records </summary>
        private List<T> _data;

        /// <summary> Partial list, contains data for one page at a time. </summary>
        private BindingList<T> _bindeddata = new BindingList<T>();

        public ssGridView(List<T> data)
        {
            _data = new List<T>();
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
            OnControlLoad?.Invoke(dataGridView_data);
            dataGridView_data.CellValueChanged += (s, ev) => { _isBindingListDirty = true;
                
            };
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

       
        private void textBox_Code_Enter(object sender, EventArgs e)
        {
            textBox_Title.Text = "";
        }

        private void textBox_Code_Leave(object sender, EventArgs e)
        {
            textBox_Title.Text = _title;
        }

        private void textBox_Title_Enter(object sender, EventArgs e)
        {
            textBox_Tag.Text = "";
        }

        private void textBox_Title_Leave(object sender, EventArgs e)
        {
            textBox_Tag.Text = _tag;

        }

        private void textBox_Tag_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Tag.Text.Length >= 2 && !textBox_Tag.Text.Equals(_tag))
            {
                _bindeddata.Clear();
                SearchTagTriggered?.Invoke(_EN,textBox_Tag.Text, _bindeddata);
            }
        }

        private void textBox_Title_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Title.Text.Length >= 2 && !textBox_Title.Text.Equals(_title))
            {
                _bindeddata.Clear();
                SearchTitleTriggered?.Invoke(_EN, textBox_Title.Text, _bindeddata);
            }
            
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            _EN = false; //disable all events
            textBox_Title.Text = _title; //to stop this text_changed event
            textBox_Tag.Text = _tag;
            ResetBindingsAfterSearchTriggered?.Invoke(_EN);
            UpdateBindings();
            _EN = true; //enable back events
        }
    }
}
