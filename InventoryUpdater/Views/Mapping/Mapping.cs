using SellerSense.Helper;
using SellerSense.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SellerSense
{
    internal partial class Mapping : Form
    {
        //public TabControl _tab { get; set; }
        private List<MappingCntrl> _mappingCntrlList;
        internal ViewModelManager.VM_Companies _companiesMgr;
        
        //public Company _company { get; set; }
        //private enum _colNames
        //{
        //    Image=0,Code=1,Title=2, AmzCode=3,FkCode=4, SpdCode=5, MsoCode=6
        //}

        //public Mapping(Company company)
        //{
        //    InitializeComponent();
        //    _company = company;
        //}

        public Mapping(ViewModelManager.VM_Companies companies)
        {
            InitializeComponent();
            //_mappingCntrlList = ctrls;
            this._companiesMgr = companies;
            CreateTabControls();
            
            //tabControl1.TabPages.Add(_companiesMgr._companies[0]._name); //show default page
            //tabControl1.TabPages[0].Controls.Add(_mappingCntrlList[0]);
            //tabControl1.TabPages.Add();
            //this.Controls.Add(_mappingCntrlList[0]); //test with one tab

            //_company = company;
        }

        private void CreateTabControls()
        {
            tabControl1.TabPages.Clear(); int i = 0;
            _mappingCntrlList = new List<MappingCntrl>();
            //{
            //List<MappingCntrl> mpc = new List<MappingCntrl>();
            
            foreach (var company in _companiesMgr._companies)
            {
                if (company != null)
                {
                    tabControl1.TabPages.Add(company._name);
                    _mappingCntrlList.Add(new MappingCntrl(company));
                    _mappingCntrlList[i].Dock = DockStyle.Fill;
                    tabControl1.TabPages[i].Controls.Add(_mappingCntrlList[i]);
                    i++;
                }
            }
        }


        private void Mapping_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            //foreach (ToolStripItem item in menuStrip1.Items)
            //{
            //    item.MergeAction = MergeAction.Append;
            //    //item.MergeIndex
            //}
        }

       

    }
}
