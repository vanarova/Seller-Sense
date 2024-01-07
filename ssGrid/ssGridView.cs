using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimitiveExt;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataPager;

//SF GRID

namespace ssGrid
{
    public partial class ssGridView<T> : UserControl
    {
        /// <summary> Partial list, contains data for one page at a time. </summary>
        //private SortableBindingList<T> _bindeddata = new SortableBindingList<T>();
        ObservableCollection<T> _data;

        //public event Action<SfDataGrid> OnControlLoad;
        //public event Action<SfDataGrid, Syncfusion.WinForms.DataGrid.Events.DataSourceChangedEventArgs> DataBindingComplete;
        public bool IsLoading { set { progressBar_Search.Visible = value; } }
        private int _currentPageNumber_backingField;
        //private int _currentPageNumber
        //{
        //    get { return _currentPageNumber_backingField; }
        //    set { _currentPageNumber_backingField = value; UpdateBindings(); }
        //}
        private bool _isBindingListDirtyValue = false;
        public bool _isBindingListDirty
        {
            get { return _isBindingListDirtyValue; }
            set
            {
                _isBindingListDirtyValue = value;
                if (value)
                    panel_isDirty.BackColor = Color.Red;
                else
                    panel_isDirty.BackColor = Color.Transparent;
            }
        }

        public ssGridView(ObservableCollection<T> data)
        {
            _data = data;
            InitializeComponent();
            InitGridUI();
            //sfDataGrid2.DetailsViewLoading += (s, ev) => { DataBindingComplete?.Invoke(sfDataGrid2, ev); };
        }

        public ssGridView(ObservableCollection<T> data,Action<SfDataGrid> BindEvents)
        {
            _data = data;
            InitializeComponent();
            InitGridUI();
            BindEvents(sfDataGrid2);
        }

        private void InitGridUI()
        {
            sfDataGrid2.RowHeight = 70;
            sfDataGrid2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            sfDataGrid2.AllowResizingColumns = true;
            sfDataGrid2.AutoGenerateColumns = true;
            sfDataGrid2.AllowFiltering = true;
        }

        private void ssGridView_Load(object sender, EventArgs e)
        {
            
            sfDataGrid2.DataSource = _data;
            // Set the data source for the SfDataPager.
            //SfDataPager sfDataPager1 = new SfDataPager();
            sfDataPager1.DataSource = _data;
            sfDataPager1.PageSize = 10;
            sfDataGrid2.DataSource = sfDataPager1.PagedSource;
            Application.DoEvents();
        }

        public void UpdateBindings()
        { 
        }

        public void ClearBindingListRows()
        {
            //_bindeddata.Clear();
        }

        //private void sfDataGrid2_DetailsViewLoading(object sender, Syncfusion.WinForms.DataGrid.Events.DetailsViewLoadingAndUnloadingEventArgs e)
        //{
            
        //}

        //private void sfDataGrid2_DataSourceChanged(object sender, Syncfusion.WinForms.DataGrid.Events.DataSourceChangedEventArgs e)
        //{
        //    //OnControlLoad?.Invoke(sfDataGrid2);
        //    //DataBindingComplete?.Invoke(sfDataGrid2, e);
        //}

        public void SetInfoLabel(string text)
        {
            label_info.Text = text;
        }
    }
}
