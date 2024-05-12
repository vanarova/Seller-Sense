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
using Syncfusion.Windows.Forms;
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

        public bool IsLoading { set { progressBar_Search.Visible = value; } }
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

        /// <summary>
        /// Specifies the ColumnChooser control.
        /// </summary>
        private Syncfusion.WinForms.DataGrid.Interactivity.ColumnChooser columnChooser;

        /// <summary>
        /// Specifies the column chooser pop up.
        /// </summary>
        private Syncfusion.WinForms.DataGrid.Interactivity.ColumnChooserPopup columnChooserPopup;


        public int PageSize { set { sfDataPager1.PageSize = value; } }

        public ssGridView(ObservableCollection<T> data, bool allowGrouping = false)
        {
            _data = data;
            InitializeComponent();
            InitGridUI();
            sfDataGrid.AllowGrouping = allowGrouping;
            sfDataGrid.ShowGroupDropArea = allowGrouping;
            //sfDataGrid2.DetailsViewLoading += (s, ev) => { DataBindingComplete?.Invoke(sfDataGrid2, ev); };
        }

        public ssGridView(ObservableCollection<T> data,Action<SfDataGrid> BindEvents, bool allowGrouping = false)
        {
            _data = data;
            InitializeComponent();
            sfDataGrid.AllowGrouping = allowGrouping;
            sfDataGrid.ShowGroupDropArea = allowGrouping;
            InitGridUI();
            BindEvents(sfDataGrid);
        }

        private void InitGridUI()
        {
            sfDataGrid.RowHeight = 70;
            sfDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            sfDataGrid.AllowResizingColumns = true;
            sfDataGrid.AutoGenerateColumns = true;
            sfDataGrid.AllowFiltering = true;
            comboBox_PageSize.Items.Add(10);
            comboBox_PageSize.Items.Add(20);
            comboBox_PageSize.Items.Add(50);
            comboBox_PageSize.Items.Add(100);
            comboBox_PageSize.Items.Add(200);
            
            columnChooser = new Syncfusion.WinForms.DataGrid.Interactivity.ColumnChooser(sfDataGrid);
            columnChooser.Location = new Point((int)DpiAware.LogicalToDeviceUnits(40), (int)DpiAware.LogicalToDeviceUnits(140));
            columnChooserPopup = new Syncfusion.WinForms.DataGrid.Interactivity.ColumnChooserPopup(sfDataGrid);

            comboBox_PageSize.SelectedIndexChanged += (s, e) => { 
                sfDataPager1.PageSize = Convert.ToInt32(comboBox_PageSize.SelectedItem.ToString());
                sfDataGrid.Invalidate();
            };

            splitButton_Export.DropDownItems[0].Click += (s, e) => { ssGrid.HelperExcel.ExportAllRecordsToExcel(sfDataGrid, e); };
            splitButton_Export.DropDownItems[1].Click += (s, e) => { ssGrid.HelperPDF.ExportToPDF(sfDataGrid, e); };


            sfButton_ColumnChooser.Click += (s, e) => { columnChooserPopup.Show(); };
        }

        public void ExportGridAsExcel()
        {
            PageSize = 2000; //Max products to download.
            ssGrid.HelperExcel.ExportAllRecordsToExcel(sfDataGrid, null);
        }

        private void ssGridView_Load(object sender, EventArgs e)
        {
            
            sfDataGrid.DataSource = _data;
            // Set the data source for the SfDataPager.
            //SfDataPager sfDataPager1 = new SfDataPager();
            sfDataPager1.DataSource = _data;
            sfDataPager1.PageSize = 10;
            sfDataGrid.DataSource = sfDataPager1.PagedSource;
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
