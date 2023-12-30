using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataPager;

namespace ssGrid
{
    public partial class ssGridView<T> : UserControl
    {
        /// <summary> Partial list, contains data for one page at a time. </summary>
        //private SortableBindingList<T> _bindeddata = new SortableBindingList<T>();
        List<T> _data;
        public ssGridView(List<T> data, bool showSearchCntrls = false,
            bool showSelectButton = false, string tagLabel = default, string titleLabel = default)
        {
            _data = data;
            InitializeComponent();
        }

        private void ssGridView_Load(object sender, EventArgs e)
        {
            
            sfDataGrid2.DataSource = _data;
            // Set the data source for the SfDataPager.
            //SfDataPager sfDataPager1 = new SfDataPager();
            sfDataPager1.DataSource = _data;
            sfDataPager1.PageSize = 10;
            sfDataGrid2.DataSource = sfDataPager1.PagedSource;
        }
    }
}
