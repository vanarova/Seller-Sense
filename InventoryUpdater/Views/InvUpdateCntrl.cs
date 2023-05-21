using InventoryUpdater.ViewModelManager;
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
    public partial class InvUpdateCntrl : UserControl
    {
        public InvUpdateCntrl()
        {
            InitializeComponent();
        }



        //private Manager.Companies _companiesMgr; //TODO Change to CompaniesMgr

        private VM_Company _company { get; set; }

        public InvUpdateCntrl(VM_Company company)
        {
            InitializeComponent();
            _company = company;
            //_companiesMgr = companies; 

        }


        private void AdjustUI(string trigger, Object sender = null, Object e = null)
        {
            switch (trigger)
            {
                case "OnLoad":
                    {
                        break;
                    }
                case "MapGridUISettings":
                    {
                        DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch; ;
                        imgCol.Width = 100; imgCol.Name = "Image";

                        foreach (DataGridViewColumn column in grdInvUpdate.Columns)
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        grdInvUpdate.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        //grdInvUpdate.Rows[0].Cells["Amazon_Code"].Selected = true;
                        break;
                    }
                default: break;

            }

        }

        private void FillInvGrid()
        {
            if (_company._mapping._map._mapEntries == null || _company._mapping._map._mapEntries.Count == 0)
                return;

            grdInvUpdate.DataSource = _company._invUpdate._invUpdateGridData.Tables[0];
            //for (int i = 0; i < grdmapGrid.Rows.Count; i++)
            //    grdmapGrid.Size(i++);
            grdInvUpdate.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grdInvUpdate.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            grdInvUpdate.Invalidate();

        }

        private void InvUpdateCntrl_Load(object sender, EventArgs e)
        {
            AdjustUI("MapGridUISettings");
            if (_company._invUpdate.LoadInvDataFromLastSavedMap())
            { FillInvGrid(); }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Inv Map Files|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _company.LoadInvUpdateDataFromUserSuppliedMapFile(openFileDialog.FileName);
                    FillInvGrid();
                }
            }
        }

        private void RefreshGrid()
        {
            _company._invUpdate.AssignAmzInvAndPricesToInvUpdateCollection(() => {
                _company._invUpdate.SaveInvSnapshot();
                FillInvGrid();
                pbar_Loading.Visible = false;
            });
            _company._invUpdate.AssignFkInvAndPricesToInvUpdateCollection(() => {
                _company._invUpdate.SaveInvSnapshot();
                FillInvGrid();
                pbar_Loading.Visible = false;
            });
            _company._invUpdate.AssignSpdInvAndPricesToInvUpdateCollection(() => {
                _company._invUpdate.SaveInvSnapshot();
                FillInvGrid();
                pbar_Loading.Visible = false;
            });
            _company._invUpdate.AssignMsoInvAndPricesToInvUpdateCollection(() => {
                _company._invUpdate.SaveInvSnapshot();
                FillInvGrid();
                pbar_Loading.Visible = false;
            });

        }


        private void btn_exportSllInv_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                _company._inventories.ExportAmazonInventoryFile(folderPath);
                _company._inventories.ExportFlipkartInventoryFile(folderPath);
                _company._inventories.ExportSnapdealInventoryFile(folderPath);
                _company._inventories.ExportMeeshoInventoryFile(folderPath);

                // ...
            }


        }

        private void grdInvUpdate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


            //var entry = _driver._fkInventoryList._fkInventoryList.Find(x => x.BaseCodeValue == grdmapGrid.SelectedCells[0].OwningRow.Cells["Code"].Value.ToString());
            //entry.Notes = grdmapGrid.SelectedCells[0].OwningRow.Cells["Notes"].Value.ToString();
        }

        private void amazonInventoryFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Amazon inv text file|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _company._inventories.ImportAmazonInventoryFile(openFileDialog.FileName);
                pbar_Loading.Visible = true;
            }
            else return;
            //_driver.AssignAmzInvAndPricesToInvUpdateCollection();
            RefreshGrid();
        }

        private void flipkartInventoryFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Flipkart inv text file|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _company._inventories.ImportFlipkartInventoryFile(openFileDialog.FileName);
                pbar_Loading.Visible = true;
            }
            else return;
            //_driver.AssignFkInvAndPricesToInvUpdateCollection(() => { RefreshGrid(); });
            RefreshGrid();
        }

        private void snapdealInventoryFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Snapdeal inv text file|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _company._inventories.ImportSnapdealInventoryFile(openFileDialog.FileName);
                pbar_Loading.Visible = true;
            }
            else return;
            //_driver.AssignSpdInvAndPricesToInvUpdateCollection(() => { RefreshGrid(); });
            RefreshGrid();
        }

        private void meeshoInventoryFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Meesho inv text file|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _company._inventories.ImportMeeshoInventoryFile(openFileDialog.FileName);
                pbar_Loading.Visible = true;
            }
            else return;
            //_driver.AssignMsoInvAndPricesToInvUpdateCollection(() => { RefreshGrid(); });
            RefreshGrid();
        }

        private void grdInvUpdate_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (grdInvUpdate.SelectedCells[0].OwningColumn.Name == Constants.ICols.notes)
            {
                foreach (var item in _company._invUpdate._inv._invEntries)
                {
                    if (item.MapEntry.BaseCodeValue == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.Code].Value.ToString())
                    {
                        item.Notes = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.notes].Value.ToString();
                        //_driver._amzImportedInvList._amzModifiedInventoryList.Add(item);

                        _company._invUpdate.SaveInvSnapshot();
                    }
                }
            }

            if (_company._inventories._amzImportedInvList._amzInventoryList != null && grdInvUpdate.SelectedCells[0].OwningColumn.Name == Constants.ICols.acount)
            {
                foreach (var item in _company._inventories._amzImportedInvList._amzInventoryList)
                {
                    if (item.asin == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.acode].Value.ToString())
                    {
                        item.sellerQuantity = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.acount].Value.ToString();
                        _company._inventories._amzImportedInvList._amzModifiedInventoryList.Add(item);
                        _company._invUpdate.SaveInvSnapshot();
                    }
                }
            }

            if (_company._inventories._fkImportedInventoryList._fkInventoryList != null && grdInvUpdate.SelectedCells[0].OwningColumn.Name == Constants.ICols.fcount)
            {
                foreach (var item in _company._inventories._fkImportedInventoryList._fkInventoryList)
                {
                    if (item.fsn == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.fcode].Value.ToString())
                    {
                        item.sellerQuantity = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.fcount].Value.ToString();
                        _company._inventories._fkImportedInventoryList._fkUIModifiedInvList.Add(item);
                        _company._invUpdate.SaveInvSnapshot();
                    }
                }
            }

            if (_company._inventories._spdImportedInventoryList._spdInventoryList != null && grdInvUpdate.SelectedCells[0].OwningColumn.Name == Constants.ICols.scount)
            {
                foreach (var item in _company._inventories._spdImportedInventoryList._spdInventoryList)
                {
                    if (item.fsn == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.scode].Value.ToString())
                    {
                        item.sellerQuantity = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.scount].Value.ToString();
                        _company._inventories._spdImportedInventoryList._spdUIModifiedInvList.Add(item);
                        _company._invUpdate.SaveInvSnapshot();
                    }
                }
            }

            if (_company._inventories._msoImportedInventoryList._msoInventoryList != null && grdInvUpdate.SelectedCells[0].OwningColumn.Name == Constants.ICols.mcount)
            {
                foreach (var item in _company._inventories._msoImportedInventoryList._msoInventoryList)
                {
                    if (item.fsn == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.mcode].Value.ToString())
                    {
                        item.sellerQuantity = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.mcount].Value.ToString();
                        _company._inventories._msoImportedInventoryList._msoUIModifiedInvList.Add(item);
                        _company._invUpdate.SaveInvSnapshot();
                    }
                }
            }

        }

        //private void btn_exportSllInv_Click(object sender, EventArgs e)
        //{

        //}

        //private void InvUpdateCntrl_Load(object sender, EventArgs e)
        //{

        //}
    }
}
