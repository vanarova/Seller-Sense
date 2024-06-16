using CommonUtil;
using SellerSense.Model.InvUpdate;
using SellerSense.Views.Inventories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.ViewManager
{
    internal class VM_CustomSnapshotDate : IManageForm
    {
        CustomSnapshotDate _v_CustomSnapshotDate;
        Constants.Company _site;
        private M_Snapshot _m_Snapshot;
        public DateTime SelectedDate1 { get; set; }
        public DateTime SelectedDate2 { get; set; }

        public void AssignView(Form view)
        {
            _v_CustomSnapshotDate = view as CustomSnapshotDate;
            HandleViewEvents();
        }

        public VM_CustomSnapshotDate(Constants.Company site, M_Snapshot m_Snapshot)
        {
            _m_Snapshot = m_Snapshot;
            _site = site;
        }

        private void HandleViewEvents()
        {
            _v_CustomSnapshotDate.Load += (s, e) => {
                _v_CustomSnapshotDate.comboBox_Site.DataSource = System.Enum.GetValues(typeof(Constants.Company));
                _v_CustomSnapshotDate.comboBox_Site.SelectedItem = _site;
                var alldates = _m_Snapshot.GetAllSnapshotDates();
                List<string> strDates1 = alldates.Select(x=>x.ToString()).ToList<string>();
                List<string> strDates2 = alldates.Select(x=>x.ToString()).ToList<string>();
                _v_CustomSnapshotDate.comboBox_InvDates1.DataSource = strDates1;
                _v_CustomSnapshotDate.comboBox_InvDates2.DataSource = strDates2;
            };
            
                _v_CustomSnapshotDate.button_Cancel.Click += (s,e) => { _v_CustomSnapshotDate.Close(); };
                _v_CustomSnapshotDate.button_OK.Click += (s,e) => {
                   bool r1 = DateTime.TryParse(_v_CustomSnapshotDate.comboBox_InvDates1.SelectedItem.ToString(), out DateTime date1);
                   bool r2 = DateTime.TryParse(_v_CustomSnapshotDate.comboBox_InvDates1.SelectedItem.ToString(), out DateTime date2);
                    if (r1 == false || r2 == false)
                        return;
                    SelectedDate1 = date1;
                    SelectedDate2 = date2;
                    _v_CustomSnapshotDate.Close(); 
            };


        }

        
    }
}
