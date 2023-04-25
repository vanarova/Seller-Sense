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

namespace InventoryUpdater
{
    public partial class InvUpdate : Form
    {
        private Driver _driver { get; set; }

        public InvUpdate(Driver driver)
        {
            InitializeComponent();
            _driver = driver;

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
            if (_driver._map.MapEntries == null || _driver._map.MapEntries.Count == 0)
                return;


            grdInvUpdate.DataSource = _driver._invUpdateGridData.Tables[0];
            //for (int i = 0; i < grdmapGrid.Rows.Count; i++)
            //    grdmapGrid.Size(i++);
            grdInvUpdate.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grdInvUpdate.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            grdInvUpdate.Invalidate();
                        
        }

        private void InvUpdate_Load(object sender, EventArgs e)
        {
            AdjustUI("MapGridUISettings");
            if (_driver.LoadInvDataFromLastSavedMap())
            {  FillInvGrid(); }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Inv Map Files|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _driver.LoadInvUpdateDataFromUserSuppliedMapFile(openFileDialog.FileName);
                    FillInvGrid();
                }
            }
        }

        private void RefreshGrid()
        {
            _driver.AssignFkInvAndPricesToInvUpdateCollection(() => {
                _driver.SaveInvSnapshot();
                FillInvGrid();
                pbar_Loading.Visible = false;
            });
            _driver.AssignSpdInvAndPricesToInvUpdateCollection(() => {
                _driver.SaveInvSnapshot();
                FillInvGrid();
                pbar_Loading.Visible = false;
            });
            _driver.AssignMsoInvAndPricesToInvUpdateCollection(() => {
                _driver.SaveInvSnapshot();
                FillInvGrid();
                pbar_Loading.Visible = false;
            });
            
        }

       
        private void btn_exportAllInv_Click(object sender, EventArgs e)
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
                _driver.ExportFlipkartInventoryFile(folderPath);
                
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
                _driver.ImportAmazonInventoryFile(openFileDialog.FileName);
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
                _driver.ImportFlipkartInventoryFile(openFileDialog.FileName);
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
                _driver.ImportSnapdealInventoryFile(openFileDialog.FileName);
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
                _driver.ImportMeeshoInventoryFile(openFileDialog.FileName); 
                pbar_Loading.Visible = true;
            }
            else return;
            //_driver.AssignMsoInvAndPricesToInvUpdateCollection(() => { RefreshGrid(); });
            RefreshGrid();
        }

        private void grdInvUpdate_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_driver._fkImportedInventoryList._fkInventoryList != null)
            {
                foreach (var item in _driver._fkImportedInventoryList._fkInventoryList)
                {
                    if (item.fsn == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.fcode].Value.ToString())
                    {
                        item.sellerQuantity = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.fcount].Value.ToString();
                        _driver._fkImportedInventoryList._fkUIModifiedInvList.Add(item);
                        _driver.SaveInvSnapshot();
                    }
                }
            }

            if (_driver._spdImportedInventoryList._spdInventoryList != null)
            {
                foreach (var item in _driver._spdImportedInventoryList._spdInventoryList)
                {
                    if (item.fsn == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.scode].Value.ToString())
                    {
                        item.sellerQuantity = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.scount].Value.ToString();
                        _driver._spdImportedInventoryList._spdUIModifiedInvList.Add(item);
                        _driver.SaveInvSnapshot();
                    }
                }
            }

            if (_driver._msoImportedInventoryList._msoInventoryList != null)
            {
                foreach (var item in _driver._msoImportedInventoryList._msoInventoryList)
                {
                    if (item.fsn == grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.mcode].Value.ToString())
                    {
                        item.sellerQuantity = grdInvUpdate.SelectedCells[0].OwningRow.Cells[Constants.ICols.mcount].Value.ToString();
                        _driver._msoImportedInventoryList._msoUIModifiedInvList.Add(item);
                        _driver.SaveInvSnapshot();
                    }
                }
            }

        }
    }
}
