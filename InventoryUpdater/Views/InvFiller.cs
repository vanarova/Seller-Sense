using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Decoders.Interfaces;
using InventoryUpdater.ViewModelManager;

namespace SellerSense
{
    public partial class InvFiller : Form
    {
        public VM_Company _company { get; set; }
        public Constants.Company _companyConst { get; set; }
        public IList<IAmzInventory> _amzInventory { get; set; }
        public IList<IFkInventory> _fkInventory { get; set; }
        public IList<ISpdInventory> _spdInventory { get; set; }
        public IList<IMsoInventory> _msoInventory { get; set; }
        public string SelectedID { get; set; }
        //private Image _img;
        //private string _code;
        //private string _title;
        public InvFiller()
        {
            InitializeComponent();
        }

        public InvFiller(Image selectedImg, string selectedCode, string selectedTitle,IList<IAmzInventory> amzInv, VM_Company company)
        {
            InitializeComponent();
            selectedImgBox.Image = selectedImg;
            lbl_Code.Text = selectedCode;
            lbl_title.Text = selectedTitle;
            _amzInventory = amzInv;
            _company = company;
            _companyConst = Constants.Company.Amazon;
        }


        public InvFiller(Image selectedImg, string selectedCode, string selectedTitle, IList<IFkInventory> fkinv, VM_Company company)
        {
            InitializeComponent();
            selectedImgBox.Image = selectedImg;
            lbl_Code.Text = selectedCode;
            lbl_title.Text = selectedTitle;
            _fkInventory = fkinv;
            _company = company;
            _companyConst = Constants.Company.Flipkart;
        }

        public InvFiller(Image selectedImg, string selectedCode, string selectedTitle, IList<ISpdInventory> spdinv, VM_Company company)
        {
            InitializeComponent();
            selectedImgBox.Image = selectedImg;
            lbl_Code.Text = selectedCode;
            lbl_title.Text = selectedTitle;
            _spdInventory = spdinv;
            _company = company;
            _companyConst= Constants.Company.Snapdeal;
        }

        public InvFiller(Image selectedImg, string selectedCode, string selectedTitle, IList<IMsoInventory> msoinv, VM_Company company)
        {
            InitializeComponent();
            selectedImgBox.Image = selectedImg;
            lbl_Code.Text = selectedCode;
            lbl_title.Text = selectedTitle;
            _msoInventory = msoinv;
            _company = company;
            _companyConst = Constants.Company.Meesho;
        }

        private void InvFiller_Load(object sender, EventArgs e)
        {
            if (_amzInventory!=null)
                grd_InvData.DataSource = _amzInventory;

            if (_fkInventory != null)
                grd_InvData.DataSource = _fkInventory;

            if (_spdInventory != null)
                grd_InvData.DataSource = _spdInventory;

            if (_msoInventory != null)
                grd_InvData.DataSource = _msoInventory;
        }

        private void txt_CompanyId_TextChanged(object sender, EventArgs e)
        {
            if (_amzInventory != null)
                SearchAmzInvList();
            if (_fkInventory != null)
                SearchFkInvList();
            if (_spdInventory != null)
                SearchSpdInvList();
            if (_msoInventory != null)
                SearchMsoInvList();
        }



        private async void SearchMsoInvList()
        {
            Task<List<int>> t = _company._inventories.SearchMsoInvCollectionAsync(txt_CompanyId.Text,
                            Constants.SearchType.ByCompanyId,
                            _companyConst);
            //(iList) =>
            //{ //call back
            await t;
            List<int> iList = t.Result;
            if (grd_InvData.DataSource != null)
            {
                grd_InvData.DataSource = null;
                grd_InvData.DataBindings.Clear();
            }

            grd_InvData.Rows.Clear();
            grd_InvData.Columns.Add("name", "name");
            grd_InvData.Columns.Add("fsn", "fsn");
            grd_InvData.Columns.Add("price", "price");
            grd_InvData.Columns.Add("systemQuantity", "quantity");


            iList.ForEach((i) =>
            {
                grd_InvData.Rows.Add(_msoInventory[i].name, _msoInventory[i].fsn,
                    _msoInventory[i].price, _msoInventory[i].systemQuantity);
            });
        //});
        }

        private async void SearchSpdInvList()
        {
            Task<List<int>> t = _company._inventories.SearchSpdInvCollectionAsync(txt_CompanyId.Text,
                            Constants.SearchType.ByCompanyId,
                            _companyConst);
            await t;
            List<int> iList = t.Result;
            //(iList) =>
            //{ //call back
            if (grd_InvData.DataSource != null)
            {
                grd_InvData.DataSource = null;
                grd_InvData.DataBindings.Clear();
            }

            grd_InvData.Rows.Clear();
            grd_InvData.Columns.Add("name", "name");
            grd_InvData.Columns.Add("fsn", "fsn");
            grd_InvData.Columns.Add("price", "price");
            grd_InvData.Columns.Add("systemQuantity", "quantity");


            iList.ForEach((i) =>
            {
                grd_InvData.Rows.Add(_spdInventory[i].name, _spdInventory[i].fsn,
                    _spdInventory[i].price, _spdInventory[i].systemQuantity);
            });
                           // });
        }



        private async void SearchFkInvList()
        {
           Task<List<int>> t = _company._inventories.SearchFkInvCollectionTask(txt_CompanyId.Text,
                            Constants.SearchType.ByCompanyId,
                            _companyConst);
            await t;
            List<int> iList = t.Result;
            if (grd_InvData.DataSource != null)
            {
                grd_InvData.DataSource = null;
                grd_InvData.DataBindings.Clear();
            }

            grd_InvData.Rows.Clear();
            grd_InvData.Columns.Add("name", "name");
            grd_InvData.Columns.Add("fsn", "fsn");
            grd_InvData.Columns.Add("price", "price");
            grd_InvData.Columns.Add("systemQuantity", "quantity");


            iList.ForEach((i) =>
            {
                grd_InvData.Rows.Add(_fkInventory[i].name, _fkInventory[i].fsn,
                    _fkInventory[i].price, _fkInventory[i].systemQuantity);
            });
                           
        }


        //private void SearchFkInvList()
        //{
        //    _company.SearchFkInvCollectionAsync(txt_CompanyId.Text,
        //                    Constants.SearchType.ByCompanyId,
        //                    _companyConst,
        //                    (iList) =>
        //                    { //call back
        //                        if (grd_InvData.DataSource != null)
        //                        {
        //                            grd_InvData.DataSource = null;
        //                            grd_InvData.DataBindings.Clear();
        //                        }

        //                        grd_InvData.Rows.Clear();
        //                        grd_InvData.Columns.Add("name", "name");
        //                        grd_InvData.Columns.Add("fsn", "fsn");
        //                        grd_InvData.Columns.Add("price", "price");
        //                        grd_InvData.Columns.Add("systemQuantity", "quantity");


        //                        iList.ForEach((i) =>
        //                        {
        //                            grd_InvData.Rows.Add(_fkInventory[i].name, _fkInventory[i].fsn,
        //                                _fkInventory[i].price, _fkInventory[i].systemQuantity);
        //                        });
        //                    });
        //}

        //private void SearchAmzInvList()
        //{
        //    _company.SearchAmzInvCollectionAsync(txt_CompanyId.Text,
        //                    Constants.SearchType.ByCompanyId,
        //                    _companyConst,
        //                    (Action<List<int>>)((iList) =>
        //                    { //call back
        //                        if (grd_InvData.DataSource != null)
        //                        {
        //                            grd_InvData.DataSource = null;
        //                            grd_InvData.DataBindings.Clear();
        //                        }

        //                        grd_InvData.Rows.Clear();
        //                        grd_InvData.Columns.Add("sku", "sku");
        //                        grd_InvData.Columns.Add("asin", "asin");
        //                        grd_InvData.Columns.Add("price", "price");
        //                        grd_InvData.Columns.Add("quantity", "quantity");


        //                        iList.ForEach((Action<int>)((i) =>
        //                        {
        //                            grd_InvData.Rows.Add(_amzInventory[i].sku, _amzInventory[i].asin,
        //                                _amzInventory[i].price, (object)_amzInventory[(int)i].sellerQuantity);
        //                        }));
        //                    }));
        //}


        //private async void SearchAmzInvList()
        //{
        //    Task<List<int>> t = _company.SearchAmzInvCollectionAsync(txt_CompanyId.Text,
        //                    Constants.SearchType.ByCompanyId,
        //                    _companyConst);
        //    await t;
        //    List<int> iList = t.Result;

        //    if (grd_InvData.DataSource != null)
        //    {
        //        grd_InvData.DataSource = null;
        //        grd_InvData.DataBindings.Clear();
        //    }

        //    grd_InvData.Rows.Clear();
        //    grd_InvData.Columns.Add("sku", "sku");
        //    grd_InvData.Columns.Add("asin", "asin");
        //    grd_InvData.Columns.Add("price", "price");
        //    grd_InvData.Columns.Add("quantity", "quantity");


        //    iList.ForEach((Action<int>)((i) =>
        //    {
        //        grd_InvData.Rows.Add(_amzInventory[i].sku, _amzInventory[i].asin,
        //            _amzInventory[i].price, (object)_amzInventory[(int)i].sellerQuantity);
        //    }));
        //}



        private async void SearchAmzInvList()
        {
            Task<List<int>> t = _company._inventories.SearchAmzInvCollectionAsync(txt_CompanyId.Text,
                            Constants.SearchType.ByCompanyId,
                            _companyConst);
            await t;
            List<int> iList = t.Result;

            if (grd_InvData.DataSource != null)
            {
                grd_InvData.DataSource = null;
                grd_InvData.DataBindings.Clear();
            }

            grd_InvData.Rows.Clear();
            grd_InvData.Columns.Clear();
            grd_InvData.Columns.Add("sku", "sku");
            grd_InvData.Columns.Add("asin", "asin");
            grd_InvData.Columns.Add("price", "price");
            grd_InvData.Columns.Add("quantity", "quantity");
            grd_InvData.Invalidate();

            iList.ForEach((Action<int>)((i) =>
            {
                grd_InvData.Rows.Add(_amzInventory[i].sku, _amzInventory[i].asin,
                    _amzInventory[i].price, (object)_amzInventory[(int)i].sellerQuantity);
            }));
        }



        private void txt_SKUTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void grd_InvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

    

        private void txt_CompanyId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //
                if(_companyConst == Constants.Company.Amazon)
                    SelectedID = grd_InvData[1, 0].Value.ToString(); //second column is asin for amazon.
                if (_companyConst == Constants.Company.Flipkart)
                    SelectedID = grd_InvData[1, 0].Value.ToString(); //fsn
                if (_companyConst == Constants.Company.Snapdeal)
                    SelectedID = grd_InvData[1, 0].Value.ToString();
                if (_companyConst == Constants.Company.Meesho)
                    SelectedID = grd_InvData[1, 0].Value.ToString();  

                e.SuppressKeyPress = true;
                this.Close();
            }
        }
    }
}
