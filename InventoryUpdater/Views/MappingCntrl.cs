using Decoders;
using InventoryUpdater.ViewModelManager;
using SellerSense.Helper;
using SellerSense.Model;
using SellerSense.Views;
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
    public partial class MappingCntrl : UserControl
    {
        Logger _logger;
        //private bool _convertCodesToLinks;
        //public MappingCntrl()
        //{
        //    InitializeComponent();
        //    //_company = company;
        //}

        public MappingCntrl(VM_Company company)
        {
            InitializeComponent();
            _company = company;
            _logger = new FileLogger(company._code);
            grdmapGrid.MultiSelect = false;
            //foreach (ToolStripItem item in fileStrip.Items)
            //{
            //    item.MergeAction = MergeAction.Append;
            //    //item.MergeIndex
            //}
            //fileStrip.ContextMenuStrip.merg

        }

        public VM_Company _company { get; set; }
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
            //try
            //{
                FillMapGrid();
           
        }

        


        private void openMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ImportMapFile();
        }

        private void ImportMapFile()
        {
            //throw new Exception("test");
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
                _company._mapping._map.SetLastSavedMapFileAndLoadMap(openFileDialog.FileName);
                _company._mapping.FillLoadedMapToGridDataset(() => { FillMapGrid(); });

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
            {
                _company._inventories.ImportBaseInvCodesFile(openFileDialog.FileName);
                _company.CreateAnEmptyMapWithImportedBaseCodes();
            }
            //FillMapGrid();
            //_driver._map.SetLastSavedMapFileAndLoadMap(openFileDialog.FileName);
            _company._mapping.FillLoadedMapToGridDataset(() =>
            {
                FillMapGrid();
            });
        }

        private void FillMapGrid()
        {
            try
            {
                AdjustUI("MapGridUISettings");
                if (_company._mapping._mapGridData == null || _company._mapping._mapGridData.Tables.Count == 0 ||
                   _company._mapping._mapGridData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No last saved Map file found, please Open/Import Map file");
                    return;
                }
                grdmapGrid.DataSource = _company._mapping._mapGridData.Tables[0];
                //for (int i = 0; i < grdmapGrid.Rows.Count; i++)
                //    grdmapGrid.Size(i++);
                //grdmapGrid.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdmapGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                //grdmapGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //grdmapGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdmapGrid.Invalidate();


            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message, Logger.LogLevel.error);
                (new AlertBox("Error", "Error occured for company:"
                    + _company._name + ", For further assitance, Export error logs and contact support.")).ShowDialog();

            }
        }

        private void importAmazonInvFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // LoadAmzCodes();
        }

        //private void LoadAmzCodes()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Amazon inv text file|*.txt";
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        _company._inventories.ImportAmazonInventoryFile(openFileDialog.FileName);
        //    }
        //}

        private void importFlipkartInvFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LoadFkCodes();
        }



        private void importAmazonInvFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //LoadAmzCodes();
        }

        private void toolStripMenuItemShowAmzInv_Click(object sender, EventArgs e)
        {
            //OpenAmzInvFiller();
            OpenInvFiller(Constants.Company.Amazon);

        }

        private void OpenInvFiller(Constants.Company company)
        {
            int selectedRow = grdmapGrid.SelectedCells[0].RowIndex;
            Image selectedImg = grdmapGrid[(int)_colNames.Image, selectedRow].Value as Image;
            string selectedCode = grdmapGrid[(int)_colNames.Code, selectedRow].Value.ToString();
            string selectedTitle = grdmapGrid[(int)_colNames.Title, selectedRow].Value.ToString();

            InvFiller inf = new InvFiller(company, selectedImg, selectedCode, selectedTitle, _company);
            inf.ShowDialog();
            //assign map ID
            if (inf.SelectedID != null && !string.IsNullOrEmpty(inf.SelectedID))
            {
                grdmapGrid.SelectedCells[0].Value = inf.SelectedID;
                _company._mapping._map._mapEntries[grdmapGrid.SelectedCells[0].RowIndex].AmzCodeValue = inf.SelectedID;
                grdmapGrid.SelectedCells[0].Style.BackColor = Color.LightGreen;
            }
        }

        //private void OpenAmzInvFiller()
        //{
        //    int selectedRow = grdmapGrid.SelectedCells[0].RowIndex;
        //    Image selectedImg = grdmapGrid[(int)_colNames.Image, selectedRow].Value as Image;
        //    string selectedCode = grdmapGrid[(int)_colNames.Code, selectedRow].Value.ToString();
        //    string selectedTitle = grdmapGrid[(int)_colNames.Title, selectedRow].Value.ToString();

        //    InvFiller inf = new InvFiller(selectedImg, selectedCode, selectedTitle, _company._inventories._amzImportedInvList._amzInventoryList, _company);
        //    inf.ShowDialog();
        //    //assign map ID
        //    if (inf.SelectedID != null && !string.IsNullOrEmpty(inf.SelectedID))
        //    {
        //        grdmapGrid.SelectedCells[0].Value = inf.SelectedID;
        //        _company._mapping._map._mapEntries[grdmapGrid.SelectedCells[0].RowIndex].AmzCodeValue = inf.SelectedID;
        //        grdmapGrid.SelectedCells[0].Style.BackColor = Color.LightGreen;
        //    }
        //}

        //private void OpenFkInvFiller()
        //{
        //    int selectedRow = grdmapGrid.SelectedCells[0].RowIndex;
        //    Image selectedImg = grdmapGrid[(int)_colNames.Image, selectedRow].Value as Image;
        //    string selectedCode = grdmapGrid[(int)_colNames.Code, selectedRow].Value.ToString();
        //    string selectedTitle = grdmapGrid[(int)_colNames.Title, selectedRow].Value.ToString();

        //    InvFiller inf = new InvFiller(selectedImg, selectedCode, selectedTitle, _company._inventories._fkImportedInventoryList._fkInventoryList, _company);
        //    inf.ShowDialog();
        //    //assign map ID
        //    if (inf.SelectedID != null && !string.IsNullOrEmpty(inf.SelectedID))
        //    {
        //        grdmapGrid.SelectedCells[0].Value = inf.SelectedID;
        //        _company._mapping._map._mapEntries[grdmapGrid.SelectedCells[0].RowIndex].FkCodeValue = inf.SelectedID;
        //        grdmapGrid.SelectedCells[0].Style.BackColor = Color.LightGreen;
        //    }
        //}


        //private void OpenSpdInvFiller()
        //{
        //    int selectedRow = grdmapGrid.SelectedCells[0].RowIndex;
        //    Image selectedImg = grdmapGrid[(int)_colNames.Image, selectedRow].Value as Image;
        //    string selectedCode = grdmapGrid[(int)_colNames.Code, selectedRow].Value.ToString();
        //    string selectedTitle = grdmapGrid[(int)_colNames.Title, selectedRow].Value.ToString();

        //    InvFiller inf = new InvFiller(selectedImg, selectedCode, selectedTitle, _company._inventories._spdImportedInventoryList._spdInventoryList, _company);
        //    inf.ShowDialog();
        //    //assign map ID
        //    if (inf.SelectedID != null && !string.IsNullOrEmpty(inf.SelectedID))
        //    {
        //        grdmapGrid.SelectedCells[0].Value = inf.SelectedID;
        //        _company._mapping._map._mapEntries[grdmapGrid.SelectedCells[0].RowIndex].SpdCodeValue = inf.SelectedID;
        //        grdmapGrid.SelectedCells[0].Style.BackColor = Color.LightGreen;
        //    }
        //}


        //private void OpenMsoInvFiller()
        //{
        //    int selectedRow = grdmapGrid.SelectedCells[0].RowIndex;
        //    Image selectedImg = grdmapGrid[(int)_colNames.Image, selectedRow].Value as Image;
        //    string selectedCode = grdmapGrid[(int)_colNames.Code, selectedRow].Value.ToString();
        //    string selectedTitle = grdmapGrid[(int)_colNames.Title, selectedRow].Value.ToString();

        //    InvFiller inf = new InvFiller(selectedImg, selectedCode, selectedTitle, _company._inventories._msoImportedInventoryList._msoInventoryList, _company);
        //    inf.ShowDialog();
        //    //assign map ID
        //    if (inf.SelectedID != null && !string.IsNullOrEmpty(inf.SelectedID))
        //    {
        //        grdmapGrid.SelectedCells[0].Value = inf.SelectedID;
        //        _company._mapping._map._mapEntries[grdmapGrid.SelectedCells[0].RowIndex].MsoCodeValue = inf.SelectedID;
        //        grdmapGrid.SelectedCells[0].Style.BackColor = Color.LightGreen;
        //    }
        //}

        private void toolStripMenuItemShowFkInv_Click(object sender, EventArgs e)
        {
            OpenInvFiller(Constants.Company.Flipkart);
            //OpenFkInvFiller();
        }





        private void saveMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void SaveMap()
        {
            _company._mapping._map.SaveMapFile();
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
                M_Map.ConvertJSONHttpImagesToLocalImages();
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
                        toolStripMenuItemShowAmzInv.Enabled = (index == (int)_colNames.AmzCode);
                        toolStripMenuItemShowFkInv.Enabled = (index == (int)_colNames.FkCode);
                        toolStripMenuItemShowSpdInv.Enabled = (index == (int)_colNames.SpdCode);
                        toolStripMenuItemShowMsoInv.Enabled = (index == (int)_colNames.MsoCode);
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
            //LoadFkCodes();
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
            //LoadSkCodes();
        }

        //private void LoadSkCodes()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Snapdeal inv file|*.xlsx";
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        _company._inventories.ImportSnapdealInventoryFile(openFileDialog.FileName);
        //    }
        //}

        //private void LoadFkCodes()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Flipkart inv file|*.xls";
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        _company._inventories.ImportFlipkartInventoryFile(openFileDialog.FileName);
        //    }
        //}

        //private void LoadMsoCodes()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Meesho inv file|*.xlsx";
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        _company._inventories.ImportMeeshoInventoryFile(openFileDialog.FileName);
        //    }
        //}

        private void importMeeshoInvToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // LoadMsoCodes();
        }

        private void toolStripMenuItemShowSpdInv_Click(object sender, EventArgs e)
        {
            OpenInvFiller(Constants.Company.Snapdeal);
        }

        private void toolStripMenuItemShowMsoInv_Click(object sender, EventArgs e)
        {
            OpenInvFiller(Constants.Company.Meesho);
        }

        private void grdmapGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //find selected row's code
            var entry = _company._mapping._map._mapEntries.Find(x => x.BaseCodeValue == grdmapGrid.SelectedCells[0].OwningRow.Cells[Constants.MCols.Code].Value.ToString());
            entry.Notes = grdmapGrid.SelectedCells[0].OwningRow.Cells[Constants.MCols.notes].Value.ToString();
            entry.Title = grdmapGrid.SelectedCells[0].OwningRow.Cells[Constants.MCols.Title].Value.ToString();
        }

        private void importMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
                ImportMapFile();
            
           
        }

       

        private void toolStripTxtSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTxtSearchBox.Text.Length >= 2 && !toolStripTxtSearchBox.Text.Equals("Search Code"))
            {
                SearchDataGridForCode(toolStripTxtSearchBox.Text);
            }
        }

        private void SearchDataGridForCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return;
            for (int r = 0; r < grdmapGrid.Rows.Count; r++)
            {
                if (grdmapGrid[1, r].Value != null && //#index dependent
                                                      // code + title
                    (grdmapGrid[1, r].Value.ToString().ToLower() + grdmapGrid[2, r].Value.ToString().ToLower()).
                    Contains(code.ToLower()))
                {
                    grdmapGrid.FirstDisplayedScrollingRowIndex = r;
                    break;
                }
            }
        }

        private void toolStripTxtSearchBox_Enter(object sender, EventArgs e)
        {
            toolStripTxtSearchBox.Text = String.Empty;
        }

        private void toolStripTxtSearchBox_Leave(object sender, EventArgs e)
        {
            toolStripTxtSearchBox.Text = "Search Code";
        }

        private void grdmapGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        /// <summary>  
        /// This function is use to get hyperlink style .  
        /// </summary>  
        /// <returns></returns>  
        private DataGridViewCellStyle GetHyperLinkStyleForGridCell()
        {
            // Set the Font and Uderline into the Content of the grid cell .  
            {
                DataGridViewCellStyle l_objDGVCS = new DataGridViewCellStyle();
                //System.Drawing.Font l_objFont = new System.Drawing.Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline);
                //l_objDGVCS.Font = l_objFont;
                l_objDGVCS.ForeColor = Color.Blue;
                return l_objDGVCS;
            }
        }

        private void grdmapGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdmapGrid.Columns[Constants.MCols.amz_Code].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            grdmapGrid.Columns[Constants.MCols.fK_Code].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            grdmapGrid.Columns[Constants.MCols.spd_Code].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            grdmapGrid.Columns[Constants.MCols.mso_Code].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            grdmapGrid.RowHeadersVisible = false;
        }

        private void toolStripTxtSearchBox_Click(object sender, EventArgs e)
        {

        }

        private void grdmapGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (grdmapGrid.CurrentCell.OwningColumn.Name == Constants.MCols.amz_Code)
                AmazonInvDecoder.OpenProductSearchURL(grdmapGrid.CurrentCell.EditedFormattedValue.ToString());
            if (grdmapGrid.CurrentCell.OwningColumn.Name == Constants.MCols.fK_Code)
                FlipkartInvDecoder.OpenProductSearchURL(grdmapGrid.CurrentCell.EditedFormattedValue.ToString());
            if (grdmapGrid.CurrentCell.OwningColumn.Name == Constants.MCols.spd_Code)
                SnapdealInvDecoder.OpenProductSearchURL(grdmapGrid.CurrentCell.EditedFormattedValue.ToString());
            if (grdmapGrid.CurrentCell.OwningColumn.Name == Constants.MCols.mso_Code)
                MeeshoInvDecoder.OpenProductSearchURL(grdmapGrid.CurrentCell.EditedFormattedValue.ToString());
        }

        private void grdmapGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {//Delet only if, selected cell's column name is a code/////
                bool amzCol = grdmapGrid.SelectedCells[0].OwningColumn.Name == Constants.MCols.amz_Code;
                bool spdCol = grdmapGrid.SelectedCells[0].OwningColumn.Name == Constants.MCols.spd_Code;
                bool fkCol = grdmapGrid.SelectedCells[0].OwningColumn.Name == Constants.MCols.fK_Code;
                bool msoCol = grdmapGrid.SelectedCells[0].OwningColumn.Name == Constants.MCols.mso_Code;
                bool titleCol = grdmapGrid.SelectedCells[0].OwningColumn.Name == Constants.MCols.Title;
                
                //TODO : Move below business logic in VM - viewmodel layer.
                //TODO : Add Notes col also.. for deletion, in below code
                if (amzCol || spdCol || fkCol || msoCol || titleCol)
                {
                    grdmapGrid.SelectedCells[0].Value = string.Empty;
                    M_Map.MapEntry r_item = _company._mapping._map._mapEntries.FirstOrDefault
                       (it => it.BaseCodeValue == grdmapGrid.SelectedCells[0].OwningRow.Cells[Constants.ICols.Code].Value.ToString());
                    if (amzCol)
                        r_item.AmzCodeValue = String.Empty;
                    if (spdCol)
                        r_item.SpdCodeValue = String.Empty;
                    if(fkCol)
                        r_item.FkCodeValue = String.Empty;
                    if (msoCol)
                        r_item.MsoCodeValue = String.Empty;
                    if (titleCol)
                        r_item.Title = String.Empty;
                }
                e.SuppressKeyPress = true;
            }
        }

        private void grdmapGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grdmapGrid.SelectedCells[0].OwningColumn.Name == Constants.ICols.Title)
            {
                M_Map.MapEntry r_item = _company._mapping._map._mapEntries.FirstOrDefault
                    (it => it.BaseCodeValue == grdmapGrid.SelectedCells[0].OwningRow.Cells[Constants.ICols.Code].Value.ToString());
                if (r_item != null)
                    r_item.Title = grdmapGrid.SelectedCells[0].OwningRow.Cells[Constants.ICols.Title].Value.ToString();

            }
            if (grdmapGrid.SelectedCells[0].OwningColumn.Name == Constants.ICols.notes)
            {
                M_Map.MapEntry r_item = _company._mapping._map._mapEntries.FirstOrDefault
                    (it => it.BaseCodeValue == grdmapGrid.SelectedCells[0].OwningRow.Cells[Constants.ICols.Code].Value.ToString());
                if (r_item != null)
                    r_item.Notes = grdmapGrid.SelectedCells[0].OwningRow.Cells[Constants.ICols.notes].Value.ToString();

            }
        }

        private void toolStripMenuItemImgSearch_Click(object sender, EventArgs e)
        {
            (bool doExist, string imgDir) = ProjIO.GetCompanyImageDirIfExist(_company._code);
            if (doExist)
            {
                ImageSearch.Search search = new ImageSearch.Search(imgDir);
                search.FormClosed += (s, ev) => { SearchDataGridForCode(search._resultCode); };
                search.ShowDialog();

            }
        }

        //private void toolStripMenuItemLinks_Click(object sender, EventArgs e)
        //{
        //    _convertCodesToLinks = !_convertCodesToLinks;
        //    if (_convertCodesToLinks)
        //    { toolStripMenuItemLinks.ForeColor = Color.Black;  }
        //    else
        //    { toolStripMenuItemLinks.ForeColor = Color.Blue; }

        //}


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
