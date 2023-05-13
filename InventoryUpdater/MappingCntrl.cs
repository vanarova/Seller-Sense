using InventoryUpdater.Model;
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
    public partial class MappingCntrl : UserControl
    {
        public MappingCntrl()
        {
            InitializeComponent();
            //_company = company;
        }

        public MappingCntrl(Company company)
        {
            InitializeComponent();
            _company = company;

            //foreach (ToolStripItem item in fileStrip.Items)
            //{
            //    item.MergeAction = MergeAction.Append;
            //    //item.MergeIndex
            //}
            //fileStrip.ContextMenuStrip.merg

        }

        public Company _company { get; set; }
        private enum _colNames
        {
            Image = 0, Code = 1, Title = 2, AmzCode = 3, FkCode = 4, SpdCode = 5, MsoCode = 6
        }

        //public Mapping()
        //{

        //}

        private void MappingCntrl_Load(object sender, EventArgs e)
        {
            AdjustUI("OnLoad", sender, e);
            //if (string.IsNullOrEmpty(_driver._map._lastSavedMapFilePath))
            //{
            //    MessageBox.Show("No last saved Map file found, please import Map data");
            //    ImportMapFile();
            //}
            //fileStrip.ContextMenu.MergeMenu(this.ParentForm.Menu);

            
            //if (_company._code == "cratialc_PKVV")
            //    fileStrip.Items[0].Text = fileStrip.Items[0].Text + "_CC";
            //else
            //    fileStrip.Items[0].Text = fileStrip.Items[0].Text.Replace("_HE", "");
            
            FillMapGrid();
        }

        


        private void openMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ImportMapFile();
        }

        private void ImportMapFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Inv Map Files|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //FileInfo fi = new FileInfo(openFileDialog.FileName);
                DirectoryInfo di = new DirectoryInfo(openFileDialog.FileName);
                if (di.Parent.GetFiles().Count() > 1)
                {
                    MessageBox.Show("Map file directory is containing more then 1 file, Please create a new directory and place map file in it");
                    return;

                }
                _company._map.SetLastSavedMapFileAndLoadMap(openFileDialog.FileName);
                _company.FillLoadedMapToGridDataset(() => { FillMapGrid(); });

            }



        }

        private void importInvCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBaseInvCodesForAllProducts();
        }

        private void GetBaseInvCodesForAllProducts()
        {
            LoadBaseCodes();

        }


        private void LoadBaseCodes()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Inv Map Files|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                _company.ImportBaseInvCodesFile(openFileDialog.FileName);
            //FillMapGrid();
            //_driver._map.SetLastSavedMapFileAndLoadMap(openFileDialog.FileName);
            _company.FillLoadedMapToGridDataset(() =>
            {
                FillMapGrid();
            });
        }

        private void FillMapGrid()
        {
            AdjustUI("MapGridUISettings");
            if (_company._mapGridData == null || _company._mapGridData.Tables.Count == 0 ||
               _company._mapGridData.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No last saved Map file found, please Open/Import Map file");
                return;
            }
            grdmapGrid.DataSource = _company._mapGridData.Tables[0];
            //for (int i = 0; i < grdmapGrid.Rows.Count; i++)
            //    grdmapGrid.Size(i++);
            grdmapGrid.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grdmapGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            grdmapGrid.Invalidate();
        }

        private void importAmazonInvFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAmzCodes();
        }

        private void LoadAmzCodes()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Amazon inv text file|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _company.ImportAmazonInventoryFile(openFileDialog.FileName);
            }
        }

        private void importFlipkartInvFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFkCodes();
        }



        private void importAmazonInvFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadAmzCodes();
        }

        private void toolStripMenuItemShowAmzInv_Click(object sender, EventArgs e)
        {
            OpenAmzInvFiller();

        }

        private void OpenAmzInvFiller()
        {
            int selectedRow = grdmapGrid.SelectedCells[0].RowIndex;
            Image selectedImg = grdmapGrid[(int)_colNames.Image, selectedRow].Value as Image;
            string selectedCode = grdmapGrid[(int)_colNames.Code, selectedRow].Value.ToString();
            string selectedTitle = grdmapGrid[(int)_colNames.Title, selectedRow].Value.ToString();
            _company.ShowAmzInvFiller(selectedImg, selectedCode, selectedTitle, (id) =>
            {
                //assign map ID
                if (id != null && !string.IsNullOrEmpty(id))
                {
                    grdmapGrid.SelectedCells[0].Value = id;
                    _company._map.MapEntries[grdmapGrid.SelectedCells[0].RowIndex].AmzCodeValue = id;
                    grdmapGrid.SelectedCells[0].Style.BackColor = Color.LightGreen;
                }
            });
        }

        private void OpenFkInvFiller()
        {
            int selectedRow = grdmapGrid.SelectedCells[0].RowIndex;
            Image selectedImg = grdmapGrid[(int)_colNames.Image, selectedRow].Value as Image;
            string selectedCode = grdmapGrid[(int)_colNames.Code, selectedRow].Value.ToString();
            string selectedTitle = grdmapGrid[(int)_colNames.Title, selectedRow].Value.ToString();
            _company.ShowFkInvFiller(selectedImg, selectedCode, selectedTitle, (id) =>
            {
                //assign map ID
                if (id != null && !string.IsNullOrEmpty(id))
                {
                    grdmapGrid.SelectedCells[0].Value = id;
                    _company._map.MapEntries[grdmapGrid.SelectedCells[0].RowIndex].FkCodeValue = id;
                    grdmapGrid.SelectedCells[0].Style.BackColor = Color.LightGreen;
                }
            });
        }


        private void OpenSpdInvFiller()
        {
            int selectedRow = grdmapGrid.SelectedCells[0].RowIndex;
            Image selectedImg = grdmapGrid[(int)_colNames.Image, selectedRow].Value as Image;
            string selectedCode = grdmapGrid[(int)_colNames.Code, selectedRow].Value.ToString();
            string selectedTitle = grdmapGrid[(int)_colNames.Title, selectedRow].Value.ToString();
            _company.ShowSpdInvFiller(selectedImg, selectedCode, selectedTitle, (id) =>
            {
                //assign map ID
                if (id != null && !string.IsNullOrEmpty(id))
                {
                    grdmapGrid.SelectedCells[0].Value = id;
                    _company._map.MapEntries[grdmapGrid.SelectedCells[0].RowIndex].SpdCodeValue = id;
                    grdmapGrid.SelectedCells[0].Style.BackColor = Color.LightGreen;
                }
            });
        }


        private void OpenMsoInvFiller()
        {
            int selectedRow = grdmapGrid.SelectedCells[0].RowIndex;
            Image selectedImg = grdmapGrid[(int)_colNames.Image, selectedRow].Value as Image;
            string selectedCode = grdmapGrid[(int)_colNames.Code, selectedRow].Value.ToString();
            string selectedTitle = grdmapGrid[(int)_colNames.Title, selectedRow].Value.ToString();
            _company.ShowMsoInvFiller(selectedImg, selectedCode, selectedTitle, (id) =>
            {
                //assign map ID
                if (id != null && !string.IsNullOrEmpty(id))
                {
                    grdmapGrid.SelectedCells[0].Value = id;
                    _company._map.MapEntries[grdmapGrid.SelectedCells[0].RowIndex].MsoCodeValue = id;
                    grdmapGrid.SelectedCells[0].Style.BackColor = Color.LightGreen;
                }
            });
        }

        private void toolStripMenuItemShowFkInv_Click(object sender, EventArgs e)
        {
            OpenFkInvFiller();
        }





        private void saveMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void SaveMap()
        {
            _company._map.SaveMapFile();
            //var lastSavedMapFilePath = _company._map.GetLastSavedMapFile();
            //if (lastSavedMapFilePath != null && !string.IsNullOrEmpty(lastSavedMapFilePath))
            //{
            //    _company._map.SaveMapFile();
            //}
            //else
            //{
            //    SaveAs();
            //}
        }

        private void saveAsMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveAs();
        }

        //private void SaveAs()
        //{
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.OverwritePrompt = true; sfd.ValidateNames = true;
        //    sfd.Filter = "Map project/map file|*.json";
        //    sfd.FileName = "Map_project_" + DateTime.Now.Day + "_" + DateTime.Now.Hour
        //            + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
        //    DialogResult result = sfd.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        string mapFilePath = sfd.FileName.Replace(Path.GetExtension(sfd.FileName), "");
        //        if (!Directory.Exists(mapFilePath))
        //            Directory.CreateDirectory(mapFilePath);
        //        string path = Path.Combine(mapFilePath, Path.GetFileName(sfd.FileName));
        //        _company._map.SaveAsMapFile(path);
        //    }
        //}

        private void convertMapFileURLsToLocalImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Map.ConvertJSONHttpImagesToLocalImages();
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred while saving images", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void AdjustUI(string trigger, Object sender = null, Object e = null)
        {
            switch (trigger)
            {
                case "OnLoad":
                    {

                        break;
                    }

                case "GridCellLeaveFocus":
                    {
                        grdmapGrid[0, ((DataGridViewCellEventArgs)e).RowIndex].Style = null;
                        grdmapGrid.InvalidateCell(((DataGridViewCellEventArgs)e).ColumnIndex, ((DataGridViewCellEventArgs)e).RowIndex);
                        break;
                    }
                case "GridCellEnterFocus":
                    {
                        int index = ((DataGridViewCellEventArgs)e).ColumnIndex;
                        importAmazonInvFileToolStripMenuItem1.Enabled = (index == (int)_colNames.AmzCode);
                        importFlipkartInvToolStripMenuItem.Enabled = (index == (int)_colNames.FkCode);
                        importSnapdealInvToolStripMenuItem.Enabled = (index == (int)_colNames.SpdCode);
                        importMeeshoInvToolStripMenuItem.Enabled = (index == (int)_colNames.MsoCode);
                        DataGridViewCellStyle st = new DataGridViewCellStyle();
                        st.Padding = new Padding() { All = 15 };
                        grdmapGrid[0, ((DataGridViewCellEventArgs)e).RowIndex].Style.ApplyStyle(st);
                        break;
                    }
                case "MapGridUISettings":
                    {

                        foreach (DataGridViewColumn column in grdmapGrid.Columns)
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        grdmapGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        //grdmapGrid.Rows[0].Cells["Amazon_Code"].Selected = true;
                        break;
                    }
                default: break;

            }

        }

        private void grdmapGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //AdjustUI("GridCellClicked", sender, e);
        }

        private void importFlipkartInvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFkCodes();
        }

        private void grdmapGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            AdjustUI("GridCellLeaveFocus", sender, e);
        }

        private void grdmapGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AdjustUI("GridCellEnterFocus", sender, e);
        }

        private void importSnapdealInvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSkCodes();
        }

        private void LoadSkCodes()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Snapdeal inv file|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _company.ImportSnapdealInventoryFile(openFileDialog.FileName);
            }
        }

        private void LoadFkCodes()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Flipkart inv file|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _company.ImportFlipkartInventoryFile(openFileDialog.FileName);
            }
        }

        private void LoadMsoCodes()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Meesho inv file|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _company.ImportMeeshoInventoryFile(openFileDialog.FileName);
            }
        }

        private void importMeeshoInvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMsoCodes();
        }

        private void toolStripMenuItemShowSpdInv_Click(object sender, EventArgs e)
        {
            OpenSpdInvFiller();
        }

        private void toolStripMenuItemShowMsoInv_Click(object sender, EventArgs e)
        {
            OpenMsoInvFiller();
        }

        private void grdmapGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //find selected row's code
            var entry = _company._map.MapEntries.Find(x => x.BaseCodeValue == grdmapGrid.SelectedCells[0].OwningRow.Cells[Constants.MCols.Code].Value.ToString());
            entry.Notes = grdmapGrid.SelectedCells[0].OwningRow.Cells[Constants.MCols.notes].Value.ToString();
            entry.Title = grdmapGrid.SelectedCells[0].OwningRow.Cells[Constants.MCols.Title].Value.ToString();
        }

        private void importMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportMapFile();
        }

        //private void toolStripMenuItemShowMsoInv_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void toolStripMenuItemShowSpdInv_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void toolStripMenuItemShowFkInv_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void toolStripMenuItemShowAmzInv_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void importSnapdealInvToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void importMeeshoInvToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void importFlipkartInvToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void importAmazonInvFileToolStripMenuItem1_Click_1(object sender, EventArgs e)
        //{

        //}
    }
}
