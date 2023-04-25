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
    public partial class Mapping : Form
    {
        public Driver _driver { get; set; }
        private enum _colNames
        {
            Image=0,Code=1,Title=2, AmzCode=3,FkCode=4, SpdCode=5, MsoCode=6
        }

        public Mapping(Driver driver)
        {
            InitializeComponent();
            _driver = driver;
        }


        private void Mapping_Load(object sender, EventArgs e)
        {
            AdjustUI("OnLoad", sender, e);
            
            FillMapGrid();
        }

        private void openMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
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
                _driver.ImportBaseInvCodesFile(openFileDialog.FileName);
            //FillMapGrid();
            _driver.GetMappingGridDataset(() =>
            {
                FillMapGrid();
            });
        }

        private void FillMapGrid()
        {
            AdjustUI("MapGridUISettings");
            grdmapGrid.DataSource = _driver._mapGridData.Tables[0];
            //for (int i = 0; i < grdmapGrid.Rows.Count; i++)
            //    grdmapGrid.Size(i++);
            grdmapGrid.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grdmapGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            grdmapGrid.Invalidate();
        }

        //private void FillMapGrid()
        //{
        //    this.WindowState = FormWindowState.Minimized;
        //    BackgroundWorker bg = new BackgroundWorker();
        //    DataSet ds = new DataSet(); ds.Tables.Add("t");
        //    ds.Tables[0].Columns.Add("Image", typeof(Image));
        //    ds.Tables[0].Columns.Add("Code");
        //    ds.Tables[0].Columns.Add("Title");
        //    ds.Tables[0].Columns.Add("Amazon_Code");
        //    ds.Tables[0].Columns.Add("FK_Code");
        //    ds.Tables[0].Columns.Add("Spd_Code");
        //    ds.Tables[0].Columns.Add("Mso_Code");
        //    ds.Tables[0].Columns.Add("Notes");

        //    bg.WorkerReportsProgress = true;
        //    bg.DoWork += (sender, doWorkEventArgs) =>
        //    {
        //        _driver._map.MapEntries.ForEach((x) =>
        //        {
        //            Image img = Image.FromFile(Path.Combine(_driver._map._lastSavedMapImageDirectory, x.Image));
        //            Image timg = (Image)(new Bitmap(img, new Size(75, 75)));
        //            DataRow dr = ds.Tables[0].Rows.Add(timg, x.BaseCodeValue, x.Title, x.AmzCodeValue, x.FkCodeValue, x.SpdCodeValue, x.MsoCodeValue, x.Notes);
        //        });
        //    };
        //    bg.RunWorkerCompleted += (s, ev) => {
        //        AdjustUI("MapGridUISettings");
        //        grdmapGrid.DataSource = ds.Tables[0];
        //        //for (int i = 0; i < grdmapGrid.Rows.Count; i++)
        //        //    grdmapGrid.Size(i++);
        //        grdmapGrid.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //        grdmapGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        //        grdmapGrid.Invalidate();
        //        this.WindowState = FormWindowState.Minimized;
        //        //this.Visible = true;
        //    };
        //    bg.RunWorkerAsync();
        //    //return ds;
        //}

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
                _driver.ImportAmazonInventoryFile(openFileDialog.FileName);
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
            _driver.ShowAmzInvFiller(selectedImg, selectedCode, selectedTitle, (id) =>
            {
                //assign map ID
                if (id != null && !string.IsNullOrEmpty(id))
                {
                    grdmapGrid.SelectedCells[0].Value = id;
                    _driver._map.MapEntries[grdmapGrid.SelectedCells[0].RowIndex].AmzCodeValue = id;
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
            _driver.ShowFkInvFiller(selectedImg, selectedCode, selectedTitle, (id) =>
            {
                //assign map ID
                if (id != null && !string.IsNullOrEmpty(id))
                {
                    grdmapGrid.SelectedCells[0].Value = id;
                    _driver._map.MapEntries[grdmapGrid.SelectedCells[0].RowIndex].FkCodeValue = id;
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
            _driver.ShowSpdInvFiller(selectedImg, selectedCode, selectedTitle, (id) =>
            {
                //assign map ID
                if (id != null && !string.IsNullOrEmpty(id))
                {
                    grdmapGrid.SelectedCells[0].Value = id;
                    _driver._map.MapEntries[grdmapGrid.SelectedCells[0].RowIndex].SpdCodeValue = id;
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
            _driver.ShowMsoInvFiller(selectedImg, selectedCode, selectedTitle, (id) =>
            {
                //assign map ID
                if (id != null && !string.IsNullOrEmpty(id))
                {
                    grdmapGrid.SelectedCells[0].Value = id;
                    _driver._map.MapEntries[grdmapGrid.SelectedCells[0].RowIndex].MsoCodeValue = id;
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
            var lastSavedMapFilePath = _driver._map.GetLastSavedMapFile();
            if (lastSavedMapFilePath != null && !string.IsNullOrEmpty(lastSavedMapFilePath))
            {
                _driver._map.SaveMapFile();
            }
            else
            {
                SaveAs();
            }
        }

        private void saveAsMapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.OverwritePrompt = true; sfd.ValidateNames = true;
            sfd.Filter = "Map project/map file|*.json";
            sfd.FileName = "Map_project_" + DateTime.Now.Day + "_" + DateTime.Now.Hour
                    + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            DialogResult result = sfd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string mapFilePath = sfd.FileName.Replace(Path.GetExtension(sfd.FileName), "");
                if (!Directory.Exists(mapFilePath))
                    Directory.CreateDirectory(mapFilePath);
                string path = Path.Combine(mapFilePath, Path.GetFileName(sfd.FileName));
                _driver._map.SaveAsMapFile(path);
            }
        }

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
                        importAmazonInvFileToolStripMenuItem1.Enabled = (index== (int)_colNames.AmzCode);
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
                        //DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                        //imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch; ;
                        //imgCol.Width = 100; imgCol.Name = "Image";
                        ////grdmapGrid.Columns.se
                        //grdmapGrid.RowTemplate.Height = 100;
                        //grdmapGrid.Columns.Add(imgCol);
                        //grdmapGrid.Columns.Add("Code", "Code");
                        //grdmapGrid.Columns.Add("Title", "Title");
                        //grdmapGrid.Columns.Add("Amazon_Code", "Amazon_Code");
                        //grdmapGrid.Columns.Add("FK_Code", "FK_Code");
                        //grdmapGrid.Columns.Add("Spd_Code", "Snapdeal Code");
                        //grdmapGrid.Columns.Add("Mso_Code", "Meesho Code");
                        //grdmapGrid.Columns.Add("Notes", "Notes");
                        //grdmapGrid.Columns["Code"].ReadOnly = true;
                        //grdmapGrid.Columns["Title"].ReadOnly = true;
                        //grdmapGrid.Columns["Amazon_Code"].ReadOnly = true;
                        //grdmapGrid.Columns["FK_Code"].ReadOnly = true;
                        
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
                _driver.ImportSnapdealInventoryFile(openFileDialog.FileName);
            }
        }

        private void LoadFkCodes()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Flipkart inv file|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _driver.ImportFlipkartInventoryFile(openFileDialog.FileName);
            }
        }

        private void LoadMsoCodes()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Meesho inv file|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _driver.ImportMeeshoInventoryFile(openFileDialog.FileName);
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
            var entry = _driver._map.MapEntries.Find(x => x.BaseCodeValue == grdmapGrid.SelectedCells[0].OwningRow.Cells["Code"].Value.ToString());
            entry.Notes = grdmapGrid.SelectedCells[0].OwningRow.Cells["Notes"].Value.ToString();
            //_driver._map.MapEntries[grdmapGrid.SelectedCells[0].RowIndex].Notes = grdmapGrid.SelectedCells[0].Value.ToString();
        }

        //private void Mapping_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //   // this.Parent.
        //}
    }
}
