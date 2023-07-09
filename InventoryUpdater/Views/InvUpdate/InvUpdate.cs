using Microsoft.WindowsAPICodePack.Dialogs;
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
    internal partial class InvUpdate : Form
    {
        private ViewManager.VM_Companies _companiesMgr; //TODO Change to CompaniesMgr

        private List<InvUpdateCntrl> _invUpdateCntrlList;


        public InvUpdate(ViewManager.VM_Companies companies)
        {
            InitializeComponent();
            _companiesMgr = companies;
            CreateTabControls();
        }


        private void CreateTabControls()
        {
            tabControl1.TabPages.Clear(); int i = 0;
            _invUpdateCntrlList = new List<InvUpdateCntrl>();
            //{
            //List<MappingCntrl> mpc = new List<MappingCntrl>();

            foreach (var company in _companiesMgr._companies)
            {
                if (company != null)
                {
                    tabControl1.TabPages.Add(company._name);
                    _invUpdateCntrlList.Add(new InvUpdateCntrl(company));
                    _invUpdateCntrlList[i].Dock = DockStyle.Fill;
                    tabControl1.TabPages[i].Controls.Add(_invUpdateCntrlList[i]);
                    i++;
                }
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }


        //private Company _company { get; set; }

        //public InvUpdate(Company company)
        //{
        //    InitializeComponent();
        //    _company = company;
        //    //_companiesMgr = companies; 

        //}


        //private void AdjustUI(string trigger, Object sender = null, Object e = null)
        //{
        //    switch (trigger)
        //    {
        //        case "OnLoad":
        //            {
        //                break;
        //            }
        //        case "MapGridUISettings":
        //            {
        //                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
        //                imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch; ;
        //                imgCol.Width = 100; imgCol.Name = "Image";

        //                foreach (DataGridViewColumn column in grdInvUpdate.Columns)
        //                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
        //                grdInvUpdate.SelectionMode = DataGridViewSelectionMode.CellSelect;
        //                //grdInvUpdate.Rows[0].Cells["Amazon_Code"].Selected = true;
        //                break;
        //            }
        //        default: break;

        //    }

        //}

        //private void FillInvGrid()
        //{
        //    if (_company._map.MapEntries == null || _company._map.MapEntries.Count == 0)
        //        return;


        //    grdInvUpdate.DataSource = _company._invUpdateGridData.Tables[0];
        //    //for (int i = 0; i < grdmapGrid.Rows.Count; i++)
        //    //    grdmapGrid.Size(i++);
        //    grdInvUpdate.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //    grdInvUpdate.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        //    grdInvUpdate.Invalidate();

        //}

        //private void InvUpdate_Load(object sender, EventArgs e)
        //{
        //    AdjustUI("MapGridUISettings");
        //    if (_company.LoadInvDataFromLastSavedMap())
        //    {  FillInvGrid(); }
        //    else
        //    {
        //        OpenFileDialog openFileDialog = new OpenFileDialog();
        //        openFileDialog.Filter = "Inv Map Files|*.json";
        //        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            _company.LoadInvUpdateDataFromUserSuppliedMapFile(openFileDialog.FileName);
        //            FillInvGrid();
        //        }
        //    }
        //}

        //private void RefreshGrid()
        //{
        //    _company.AssignAmzInvAndPricesToInvUpdateCollection(() => {
        //        _company.SaveInvSnapshot();
        //        FillInvGrid();
        //        pbar_Loading.Visible = false;
        //    });
        //    _company.AssignFkInvAndPricesToInvUpdateCollection(() => {
        //        _company.SaveInvSnapshot();
        //        FillInvGrid();
        //        pbar_Loading.Visible = false;
        //    });
        //    _company.AssignSpdInvAndPricesToInvUpdateCollection(() => {
        //        _company.SaveInvSnapshot();
        //        FillInvGrid();
        //        pbar_Loading.Visible = false;
        //    });
        //    _company.AssignMsoInvAndPricesToInvUpdateCollection(() => {
        //        _company.SaveInvSnapshot();
        //        FillInvGrid();
        //        pbar_Loading.Visible = false;
        //    });

        //}


        //private void btn_exportAllInv_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog folderBrowser = new OpenFileDialog();
        //    // Set validate names and check file exists to false otherwise windows will
        //    // not let you select "Folder Selection."
        //    folderBrowser.ValidateNames = false;
        //    folderBrowser.CheckFileExists = false;
        //    folderBrowser.CheckPathExists = true;
        //    // Always default to Folder Selection.
        //    folderBrowser.FileName = "Folder Selection";
        //    if (folderBrowser.ShowDialog() == DialogResult.OK)
        //    {
        //        string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
        //        _company.ExportAmazonInventoryFile(folderPath);
        //        _company.ExportFlipkartInventoryFile(folderPath);
        //        _company.ExportSnapdealInventoryFile(folderPath);
        //        _company.ExportMeeshoInventoryFile(folderPath);

        //        // ...
        //    }


        //}

        //private void grdInvUpdate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{


        //    //var entry = _driver._fkInventoryList._fkInventoryList.Find(x => x.BaseCodeValue == grdmapGrid.SelectedCells[0].OwningRow.Cells["Code"].Value.ToString());
        //    //entry.Notes = grdmapGrid.SelectedCells[0].OwningRow.Cells["Notes"].Value.ToString();
        //}

        //private void amazonInventoryFileToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Amazon inv text file|*.txt";
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        _company.ImportAmazonInventoryFile(openFileDialog.FileName);
        //        pbar_Loading.Visible = true;
        //    }
        //    else return;
        //    //_driver.AssignAmzInvAndPricesToInvUpdateCollection();
        //    RefreshGrid();
        //}

        //private void flipkartInventoryFileToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Flipkart inv text file|*.xls";
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        _company.ImportFlipkartInventoryFile(openFileDialog.FileName);
        //        pbar_Loading.Visible = true;
        //    }
        //    else return;
        //    //_driver.AssignFkInvAndPricesToInvUpdateCollection(() => { RefreshGrid(); });
        //    RefreshGrid();
        //}

        //private void snapdealInventoryFileToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Snapdeal inv text file|*.xlsx";
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        _company.ImportSnapdealInventoryFile(openFileDialog.FileName);
        //        pbar_Loading.Visible = true;
        //    }
        //    else return;
        //    //_driver.AssignSpdInvAndPricesToInvUpdateCollection(() => { RefreshGrid(); });
        //    RefreshGrid();
        //}

        //private void meeshoInventoryFileToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Meesho inv text file|*.xlsx";
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        _company.ImportMeeshoInventoryFile(openFileDialog.FileName); 
        //        pbar_Loading.Visible = true;
        //    }
        //    else return;
        //    //_driver.AssignMsoInvAndPricesToInvUpdateCollection(() => { RefreshGrid(); });
        //    RefreshGrid();
        //}

        //private void grdInvUpdate_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{

        //    if (grdInvUpdate.SelectedCells[0].OwningColumn.Name == Constants.ICols.notes)
        //    {
        //        foreach (var item in _company._inv._invEntries)
        //        {
        //            if (item.MapEntry.BaseCodeValue == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.Code].Value.ToString())
        //            {
        //                item.Notes = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.notes].Value.ToString();
        //                //_driver._amzImportedInvList._amzModifiedInventoryList.Add(item);

        //                _company.SaveInvSnapshot();
        //            }
        //        }
        //    }

        //    if (_company._amzImportedInvList._amzInventoryList != null && grdInvUpdate.SelectedCells[0].OwningColumn.Name == Constants.ICols.acount)
        //    {
        //        foreach (var item in _company._amzImportedInvList._amzInventoryList)
        //        {
        //            if (item.asin == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.acode].Value.ToString())
        //            {
        //                item.sellerQuantity = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.acount].Value.ToString();
        //                _company._amzImportedInvList._amzModifiedInventoryList.Add(item);
        //                _company.SaveInvSnapshot();
        //            }
        //        }
        //    }

        //    if (_company._fkImportedInventoryList._fkInventoryList != null && grdInvUpdate.SelectedCells[0].OwningColumn.Name == Constants.ICols.fcount )
        //    {
        //        foreach (var item in _company._fkImportedInventoryList._fkInventoryList)
        //        {
        //            if (item.fsn == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.fcode].Value.ToString())
        //            {
        //                item.sellerQuantity = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.fcount].Value.ToString();
        //                _company._fkImportedInventoryList._fkUIModifiedInvList.Add(item);
        //                _company.SaveInvSnapshot();
        //            }
        //        }
        //    }

        //    if (_company._spdImportedInventoryList._spdInventoryList != null && grdInvUpdate.SelectedCells[0].OwningColumn.Name == Constants.ICols.scount)
        //    {
        //        foreach (var item in _company._spdImportedInventoryList._spdInventoryList)
        //        {
        //            if (item.fsn == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.scode].Value.ToString())
        //            {
        //                item.sellerQuantity = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.scount].Value.ToString();
        //                _company._spdImportedInventoryList._spdUIModifiedInvList.Add(item);
        //                _company.SaveInvSnapshot();
        //            }
        //        }
        //    }

        //    if (_company._msoImportedInventoryList._msoInventoryList != null && grdInvUpdate.SelectedCells[0].OwningColumn.Name == Constants.ICols.mcount)
        //    {
        //        foreach (var item in _company._msoImportedInventoryList._msoInventoryList)
        //        {
        //            if (item.fsn == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.mcode].Value.ToString())
        //            {
        //                item.sellerQuantity = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.mcount].Value.ToString();
        //                _company._msoImportedInventoryList._msoUIModifiedInvList.Add(item);
        //                _company.SaveInvSnapshot();
        //            }
        //        }
        //    }

        //}
    }
}
