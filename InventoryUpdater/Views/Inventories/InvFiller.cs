﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Decoders.Interfaces;
using SellerSense.ViewManager;
using SellerSense.Model;
using CommonUtil;

namespace SellerSense
{
    public partial class InvFiller : Form
    {
        internal M_External_Inventories _m_Inventories_Model { get; set; }
        public Constants.Company _companyType { get; set; }
        public IList<IAmzInventory> _amzInventory { get; set; }
        public IList<IFkInventoryV2> _fkInventory { get; set; }
        public IList<ISpdInventory> _spdInventory { get; set; }
        public IList<IMsoInventory> _msoInventory { get; set; }
        public string SelectedID { get; set; }

        public InvFiller()
        {
            InitializeComponent();
        }

        internal InvFiller(Constants.Company company, Image selectedImg, 
            string selectedCode, string selectedTitle, M_External_Inventories inv)
        {
            InitializeComponent();
            _companyType = company;
            selectedImgBox.Image = selectedImg;
            lbl_Code.Text = selectedCode;
            lbl_title.Text = selectedTitle;
            _m_Inventories_Model = inv;
            if (Screen.PrimaryScreen.WorkingArea.Height/2 < 1300)
                this.Height = 1300;
            switch (company)
            {
                case Constants.Company.Amazon:
                    btn_loadInvFile.Text = "Load Amazon inv file";
                    btn_loadInvFile.Click += (s, e) => { LoadAmzCodes(); };
                    break;
                case Constants.Company.Flipkart:
                    btn_loadInvFile.Text = "Load Flipkart inv file";
                    btn_loadInvFile.Click += (s, e) => { LoadFkCodes(); };
                    break;
                case Constants.Company.Snapdeal:
                    btn_loadInvFile.Text = "Load Snapdeal inv file";
                    btn_loadInvFile.Click += (s, e) => { LoadSkCodes(); };
                    break;
                case Constants.Company.Meesho:
                    btn_loadInvFile.Text = "Load Meesho inv file";
                    btn_loadInvFile.Click += (s, e) => { LoadMsoCodes(); };
                    break;
                default:
                    break;
            }
        }

        private void RefreshGrid()
        {
            grd_InvData.DataSource = null;
            if (_m_Inventories_Model._amzImportedInvList._amzInventoryList.Count > 0)
                _amzInventory = _m_Inventories_Model._amzImportedInvList._amzInventoryList;


            if (_amzInventory != null)
                grd_InvData.DataSource = _amzInventory;

            if (_fkInventory != null)
                grd_InvData.DataSource = _fkInventory;

            if (_spdInventory != null)
                grd_InvData.DataSource = _spdInventory;

            if (_msoInventory != null)
                grd_InvData.DataSource = _msoInventory;
        }

        internal InvFiller(Image selectedImg, string selectedCode, 
            string selectedTitle,IList<IAmzInventory> amzInv, M_External_Inventories vm_Inventories)
        {
            InitializeComponent();
            selectedImgBox.Image = selectedImg;
            lbl_Code.Text = selectedCode;
            lbl_title.Text = selectedTitle;
            _amzInventory = amzInv;
            this._m_Inventories_Model = vm_Inventories;
        }


        internal InvFiller(Image selectedImg, string selectedCode, 
            string selectedTitle, IList<IFkInventoryV2> fkinv, M_External_Inventories vm_Inventories)
        {
            InitializeComponent();
            selectedImgBox.Image = selectedImg;
            lbl_Code.Text = selectedCode;
            lbl_title.Text = selectedTitle;
            _fkInventory = fkinv;
            this._m_Inventories_Model = vm_Inventories;
        }

        internal InvFiller(Image selectedImg, string selectedCode, 
            string selectedTitle, IList<ISpdInventory> spdinv, M_External_Inventories vm_Inventories)
        {
            InitializeComponent();
            selectedImgBox.Image = selectedImg;
            lbl_Code.Text = selectedCode;
            lbl_title.Text = selectedTitle;
            _spdInventory = spdinv;
            this._m_Inventories_Model = vm_Inventories;
        }

        internal InvFiller(Image selectedImg, string selectedCode, 
            string selectedTitle, IList<IMsoInventory> msoinv, M_External_Inventories vm_Inventories)
        {
            InitializeComponent();
            selectedImgBox.Image = selectedImg;
            lbl_Code.Text = selectedCode;
            lbl_title.Text = selectedTitle;
            _msoInventory = msoinv;
            this._m_Inventories_Model = vm_Inventories;
        }

        private void InvFiller_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            //if (_amzInventory!=null)
            //    grd_InvData.DataSource = _amzInventory;

            //if (_fkInventory != null)
            //    grd_InvData.DataSource = _fkInventory;

            //if (_spdInventory != null)
            //    grd_InvData.DataSource = _spdInventory;

            //if (_msoInventory != null)
            //    grd_InvData.DataSource = _msoInventory;
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

        private void LoadAmzCodes()
        {
            DialogResult r = DialogResult.None;
            if (_m_Inventories_Model._amzImportedInvList != null &&
                _m_Inventories_Model._amzImportedInvList._amzInventoryList != null &&
                _m_Inventories_Model._amzImportedInvList._amzInventoryList.Count > 0)
            { r = MessageBox.Show("Inventory list is already loaded, do you want to re-load ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information); }
            if (r == DialogResult.Yes || r == DialogResult.None)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Amazon inv text file|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _m_Inventories_Model.ImportAmazonInventoryFile(openFileDialog.FileName);
                    _amzInventory = _m_Inventories_Model._amzImportedInvList._amzInventoryList;
                    RefreshGrid();
                }
            }
        }

        private void LoadSkCodes()
        {
            DialogResult r = DialogResult.None;
            if (_m_Inventories_Model._spdImportedInventoryList != null &&
                _m_Inventories_Model._spdImportedInventoryList._spdInventoryList != null &&
                _m_Inventories_Model._spdImportedInventoryList._spdInventoryList.Count > 0)
            { r = MessageBox.Show("Inventory list is already loaded, do you want to re-load ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information); }
            if (r == DialogResult.Yes || r == DialogResult.None)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Snapdeal inv file|*.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _m_Inventories_Model.ImportSnapdealInventoryFile(openFileDialog.FileName);
                    _spdInventory = _m_Inventories_Model._spdImportedInventoryList._spdInventoryList;
                    RefreshGrid();
                }
            }
        }

        private void LoadFkCodes()
        {
            DialogResult r = DialogResult.None;
            if (_m_Inventories_Model._fkImportedInventoryList != null &&
                _m_Inventories_Model._fkImportedInventoryList._fkInventoryList != null &&
                _m_Inventories_Model._fkImportedInventoryList._fkInventoryList.Count > 0)
            { r = MessageBox.Show("Inventory list is already loaded, do you want to re-load ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information); }
            if (r == DialogResult.Yes || r == DialogResult.None)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Flipkart inv file|*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _m_Inventories_Model.ImportFlipkartInventoryFile(openFileDialog.FileName);
                    _fkInventory = _m_Inventories_Model._fkImportedInventoryList._fkInventoryList;
                    RefreshGrid();
                }
            }
        }

        private void LoadMsoCodes()
        {
            DialogResult r = DialogResult.None;
            if (_m_Inventories_Model._msoImportedInventoryList != null &&
                _m_Inventories_Model._msoImportedInventoryList._msoInventoryList != null &&
                _m_Inventories_Model._msoImportedInventoryList._msoInventoryList.Count > 0)
            { r = MessageBox.Show("Inventory list is already loaded, do you want to re-load ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information); }
            if (r == DialogResult.Yes || r == DialogResult.None)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Meesho inv file|*.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _m_Inventories_Model.ImportMeeshoInventoryFile(openFileDialog.FileName);
                    _msoInventory = _m_Inventories_Model._msoImportedInventoryList._msoInventoryList;
                    RefreshGrid();
                }
            }
        }

        private async void SearchMsoInvList()
        {
            Task<List<int>> t = _m_Inventories_Model.SearchMsoInvCollectionAsync(txt_CompanyId.Text,
                            Constants.SearchType.ByCompanyId,
                            _companyType);
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
                grd_InvData.Rows.Add(_msoInventory[i].sku, _msoInventory[i].fsn,
                    _msoInventory[i].price, _msoInventory[i].systemQuantity);
            });
        //});
        }

        private async void SearchSpdInvList()
        {
            Task<List<int>> t = _m_Inventories_Model.SearchSpdInvCollectionAsync(txt_CompanyId.Text,
                            Constants.SearchType.ByCompanyId,
                            _companyType);
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
                grd_InvData.Rows.Add(_spdInventory[i].sku, _spdInventory[i].fsn,
                    _spdInventory[i].price, _spdInventory[i].systemQuantity);
            });
                           // });
        }



        private async void SearchFkInvList()
        {
           Task<List<int>> t = _m_Inventories_Model.SearchFkInvCollectionTask(txt_CompanyId.Text,
                            Constants.SearchType.ByCompanyId,
                            _companyType);
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
                grd_InvData.Rows.Add(_fkInventory[i].sku, _fkInventory[i].fsn,
                    _fkInventory[i].price, _fkInventory[i].systemQuantity);
            });
                           
        }



        private async void SearchAmzInvList()
        {
            Task<List<int>> t = _m_Inventories_Model.SearchAmzInvCollectionAsync(txt_CompanyId.Text,
                            Constants.SearchType.ByCompanyId,
                            _companyType);
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
                if(_companyType == Constants.Company.Amazon)
                    SelectedID = grd_InvData[1, 0].Value.ToString(); //second column is asin for amazon.
                if (_companyType == Constants.Company.Flipkart)
                    SelectedID = grd_InvData[1, 0].Value.ToString(); //fsn
                if (_companyType == Constants.Company.Snapdeal)
                    SelectedID = grd_InvData[1, 0].Value.ToString();
                if (_companyType == Constants.Company.Meesho)
                    SelectedID = grd_InvData[1, 0].Value.ToString();  

                e.SuppressKeyPress = true;
                this.Close();
            }
           
        }

        private void btn_loadInvFile_Click(object sender, EventArgs e)
        {

        }

        private void btn_MapViaCode_Click(object sender, EventArgs e)
        {
            if (_companyType == Constants.Company.Amazon)
                SelectedID = grd_InvData[1, 0].Value.ToString(); //second column is asin for amazon.
            if (_companyType == Constants.Company.Flipkart)
                SelectedID = grd_InvData[1, 0].Value.ToString(); //fsn
            if (_companyType == Constants.Company.Snapdeal)
                SelectedID = grd_InvData[1, 0].Value.ToString();
            if (_companyType == Constants.Company.Meesho)
                SelectedID = grd_InvData[1, 0].Value.ToString();

            this.Close();
        }

        private async void btn_MapViaScrapping_Click(object sender, EventArgs e)
        {
            lbl_URLMappedValue.Text = await Scrap(_companyType, txtbox_URL.Text);
            lbl_Error.Visible = string.IsNullOrEmpty(lbl_URLMappedValue.Text);
        }

        private async Task<string> Scrap(Constants.Company company, string url)
        {
            string result = string.Empty;
            switch (company)
            {
                case Constants.Company.Amazon:
                     result = Decoders.AmazonInvDecoder.GetProductIdFromURL(url);
                     break;
                case Constants.Company.Flipkart:
                    result = Decoders.FlipkartInvDecoder.GetProductIdFromURL(url);
                    break;
                case Constants.Company.Snapdeal:
                    progressBar1.Visible = true;
                    result = await Decoders.SnapdealInvDecoder.GetProductIdFromURLAsync(url);
                    progressBar1.Visible = false;
                    break;
                case Constants.Company.Meesho:
                    break;
                default:
                    break;
            }
            //return Task.FromResult(result);
            return result;
        }

        private void CompletedLoadAsync()
        {
            progressBar1.Visible = false;
        }

        private void btn_MapViaURLAccept_Click(object sender, EventArgs e)
        {
            SelectedID = lbl_URLMappedValue.Text;
            //if (_companyType == Constants.Company.Amazon)
            //    SelectedID = grd_InvData[1, 0].Value.ToString(); //second column is asin for amazon.
            //if (_companyType == Constants.Company.Flipkart)
            //    SelectedID = grd_InvData[1, 0].Value.ToString(); //fsn
            //if (_companyType == Constants.Company.Snapdeal)
            //    SelectedID = grd_InvData[1, 0].Value.ToString();
            //if (_companyType == Constants.Company.Meesho)
            //    SelectedID = grd_InvData[1, 0].Value.ToString();

            this.Close();
        }

        //TODO Change all label fonts to, search all and replace all ("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    }
}
