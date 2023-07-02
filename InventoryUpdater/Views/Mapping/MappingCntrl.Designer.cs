namespace SellerSense
{
    partial class MappingCntrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fileStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importInvCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFlipkartInvFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importAmazonInvFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSnapdealInvFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMeeshoInvFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertMapFileURLsToLocalImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowAmzInv = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowFkInv = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowSpdInv = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowMsoInv = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTxtSearchBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImgSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.grdmapGrid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.fileStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdmapGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.fileStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdmapGrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545455F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.45454F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(999, 682);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // fileStrip
            // 
            this.fileStrip.AllowMerge = false;
            this.fileStrip.BackColor = System.Drawing.Color.Lavender;
            this.fileStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fileStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItemShowAmzInv,
            this.toolStripMenuItemShowFkInv,
            this.toolStripMenuItemShowSpdInv,
            this.toolStripMenuItemShowMsoInv,
            this.toolStripTxtSearchBox,
            this.toolStripMenuItem1,
            this.toolStripMenuItemImgSearch});
            this.fileStrip.Location = new System.Drawing.Point(0, 0);
            this.fileStrip.MinimumSize = new System.Drawing.Size(0, 15);
            this.fileStrip.Name = "fileStrip";
            this.fileStrip.Size = new System.Drawing.Size(999, 31);
            this.fileStrip.TabIndex = 9;
            this.fileStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMapFileToolStripMenuItem,
            this.importMapFileToolStripMenuItem,
            this.saveMapFileToolStripMenuItem,
            this.saveAsMapFileToolStripMenuItem,
            this.importInvCodesToolStripMenuItem,
            this.importFlipkartInvFileToolStripMenuItem,
            this.importAmazonInvFileToolStripMenuItem,
            this.importSnapdealInvFileToolStripMenuItem,
            this.importMeeshoInvFileToolStripMenuItem,
            this.utilitiesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 27);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openMapFileToolStripMenuItem
            // 
            this.openMapFileToolStripMenuItem.Enabled = false;
            this.openMapFileToolStripMenuItem.Name = "openMapFileToolStripMenuItem";
            this.openMapFileToolStripMenuItem.Size = new System.Drawing.Size(376, 26);
            this.openMapFileToolStripMenuItem.Text = "Create workspace";
            // 
            // importMapFileToolStripMenuItem
            // 
            this.importMapFileToolStripMenuItem.Enabled = false;
            this.importMapFileToolStripMenuItem.Name = "importMapFileToolStripMenuItem";
            this.importMapFileToolStripMenuItem.Size = new System.Drawing.Size(376, 26);
            this.importMapFileToolStripMenuItem.Text = "Import Map File (Change to Project (imgs))";
            // 
            // saveMapFileToolStripMenuItem
            // 
            this.saveMapFileToolStripMenuItem.Name = "saveMapFileToolStripMenuItem";
            this.saveMapFileToolStripMenuItem.Size = new System.Drawing.Size(376, 26);
            this.saveMapFileToolStripMenuItem.Text = "Save Map File";
            this.saveMapFileToolStripMenuItem.Click += new System.EventHandler(this.saveMapFileToolStripMenuItem_Click);
            // 
            // saveAsMapFileToolStripMenuItem
            // 
            this.saveAsMapFileToolStripMenuItem.Enabled = false;
            this.saveAsMapFileToolStripMenuItem.Name = "saveAsMapFileToolStripMenuItem";
            this.saveAsMapFileToolStripMenuItem.Size = new System.Drawing.Size(376, 26);
            this.saveAsMapFileToolStripMenuItem.Text = "Save As Map File";
            // 
            // importInvCodesToolStripMenuItem
            // 
            this.importInvCodesToolStripMenuItem.Enabled = false;
            this.importInvCodesToolStripMenuItem.Name = "importInvCodesToolStripMenuItem";
            this.importInvCodesToolStripMenuItem.Size = new System.Drawing.Size(376, 26);
            this.importInvCodesToolStripMenuItem.Text = "Import Inv Codes";
            // 
            // importFlipkartInvFileToolStripMenuItem
            // 
            this.importFlipkartInvFileToolStripMenuItem.Enabled = false;
            this.importFlipkartInvFileToolStripMenuItem.Name = "importFlipkartInvFileToolStripMenuItem";
            this.importFlipkartInvFileToolStripMenuItem.Size = new System.Drawing.Size(376, 26);
            this.importFlipkartInvFileToolStripMenuItem.Text = "Import Flipkart Inv File";
            this.importFlipkartInvFileToolStripMenuItem.Visible = false;
            // 
            // importAmazonInvFileToolStripMenuItem
            // 
            this.importAmazonInvFileToolStripMenuItem.Enabled = false;
            this.importAmazonInvFileToolStripMenuItem.Name = "importAmazonInvFileToolStripMenuItem";
            this.importAmazonInvFileToolStripMenuItem.Size = new System.Drawing.Size(376, 26);
            this.importAmazonInvFileToolStripMenuItem.Text = "Import Amazon Inv File";
            this.importAmazonInvFileToolStripMenuItem.Visible = false;
            // 
            // importSnapdealInvFileToolStripMenuItem
            // 
            this.importSnapdealInvFileToolStripMenuItem.Enabled = false;
            this.importSnapdealInvFileToolStripMenuItem.Name = "importSnapdealInvFileToolStripMenuItem";
            this.importSnapdealInvFileToolStripMenuItem.Size = new System.Drawing.Size(376, 26);
            this.importSnapdealInvFileToolStripMenuItem.Text = "Import Snapdeal Inv File";
            this.importSnapdealInvFileToolStripMenuItem.Visible = false;
            // 
            // importMeeshoInvFileToolStripMenuItem
            // 
            this.importMeeshoInvFileToolStripMenuItem.Enabled = false;
            this.importMeeshoInvFileToolStripMenuItem.Name = "importMeeshoInvFileToolStripMenuItem";
            this.importMeeshoInvFileToolStripMenuItem.Size = new System.Drawing.Size(376, 26);
            this.importMeeshoInvFileToolStripMenuItem.Text = "Import Meesho Inv File";
            this.importMeeshoInvFileToolStripMenuItem.Visible = false;
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertMapFileURLsToLocalImagesToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Enabled = false;
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(376, 26);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // convertMapFileURLsToLocalImagesToolStripMenuItem
            // 
            this.convertMapFileURLsToLocalImagesToolStripMenuItem.Name = "convertMapFileURLsToLocalImagesToolStripMenuItem";
            this.convertMapFileURLsToLocalImagesToolStripMenuItem.Size = new System.Drawing.Size(347, 26);
            this.convertMapFileURLsToLocalImagesToolStripMenuItem.Text = "Convert Map File URLsTo Local Images";
            // 
            // toolStripMenuItemShowAmzInv
            // 
            this.toolStripMenuItemShowAmzInv.BackColor = System.Drawing.Color.Cornsilk;
            this.toolStripMenuItemShowAmzInv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripMenuItemShowAmzInv.Name = "toolStripMenuItemShowAmzInv";
            this.toolStripMenuItemShowAmzInv.Size = new System.Drawing.Size(110, 27);
            this.toolStripMenuItemShowAmzInv.Text = "Amazon🪄";
            this.toolStripMenuItemShowAmzInv.Click += new System.EventHandler(this.toolStripMenuItemShowAmzInv_Click);
            // 
            // toolStripMenuItemShowFkInv
            // 
            this.toolStripMenuItemShowFkInv.BackColor = System.Drawing.Color.Cornsilk;
            this.toolStripMenuItemShowFkInv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripMenuItemShowFkInv.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripMenuItemShowFkInv.Name = "toolStripMenuItemShowFkInv";
            this.toolStripMenuItemShowFkInv.Size = new System.Drawing.Size(102, 27);
            this.toolStripMenuItemShowFkInv.Text = "Flipkart🚀";
            this.toolStripMenuItemShowFkInv.Click += new System.EventHandler(this.toolStripMenuItemShowFkInv_Click);
            // 
            // toolStripMenuItemShowSpdInv
            // 
            this.toolStripMenuItemShowSpdInv.BackColor = System.Drawing.Color.Cornsilk;
            this.toolStripMenuItemShowSpdInv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripMenuItemShowSpdInv.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripMenuItemShowSpdInv.Name = "toolStripMenuItemShowSpdInv";
            this.toolStripMenuItemShowSpdInv.Size = new System.Drawing.Size(117, 27);
            this.toolStripMenuItemShowSpdInv.Text = "Snapdeal👜";
            this.toolStripMenuItemShowSpdInv.Click += new System.EventHandler(this.toolStripMenuItemShowSpdInv_Click);
            // 
            // toolStripMenuItemShowMsoInv
            // 
            this.toolStripMenuItemShowMsoInv.BackColor = System.Drawing.Color.Cornsilk;
            this.toolStripMenuItemShowMsoInv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripMenuItemShowMsoInv.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripMenuItemShowMsoInv.Name = "toolStripMenuItemShowMsoInv";
            this.toolStripMenuItemShowMsoInv.Size = new System.Drawing.Size(107, 27);
            this.toolStripMenuItemShowMsoInv.Text = "Meesho🍱";
            this.toolStripMenuItemShowMsoInv.Click += new System.EventHandler(this.toolStripMenuItemShowMsoInv_Click);
            // 
            // toolStripTxtSearchBox
            // 
            this.toolStripTxtSearchBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTxtSearchBox.ForeColor = System.Drawing.Color.Gray;
            this.toolStripTxtSearchBox.Margin = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStripTxtSearchBox.Name = "toolStripTxtSearchBox";
            this.toolStripTxtSearchBox.Size = new System.Drawing.Size(150, 27);
            this.toolStripTxtSearchBox.Text = "Search Code/ Title";
            this.toolStripTxtSearchBox.Enter += new System.EventHandler(this.toolStripTxtSearchBox_Enter);
            this.toolStripTxtSearchBox.Leave += new System.EventHandler(this.toolStripTxtSearchBox_Leave);
            this.toolStripTxtSearchBox.TextChanged += new System.EventHandler(this.toolStripTxtSearchBox_TextChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(14, 27);
            // 
            // toolStripMenuItemImgSearch
            // 
            this.toolStripMenuItemImgSearch.BackColor = System.Drawing.Color.Cornsilk;
            this.toolStripMenuItemImgSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripMenuItemImgSearch.Name = "toolStripMenuItemImgSearch";
            this.toolStripMenuItemImgSearch.Size = new System.Drawing.Size(156, 27);
            this.toolStripMenuItemImgSearch.Text = "Image Search ⛳";
            this.toolStripMenuItemImgSearch.Click += new System.EventHandler(this.toolStripMenuItemImgSearch_Click);
            // 
            // grdmapGrid
            // 
            this.grdmapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdmapGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdmapGrid.Location = new System.Drawing.Point(3, 34);
            this.grdmapGrid.MultiSelect = false;
            this.grdmapGrid.Name = "grdmapGrid";
            this.grdmapGrid.RowHeadersWidth = 51;
            this.grdmapGrid.RowTemplate.Height = 24;
            this.grdmapGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdmapGrid.Size = new System.Drawing.Size(993, 645);
            this.grdmapGrid.TabIndex = 4;
            this.grdmapGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdmapGrid_CellContentClick);
            this.grdmapGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdmapGrid_CellContentDoubleClick);
            this.grdmapGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdmapGrid_CellEnter);
            this.grdmapGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdmapGrid_CellLeave);
            this.grdmapGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdmapGrid_CellValueChanged);
            this.grdmapGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdmapGrid_DataBindingComplete);
            this.grdmapGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdmapGrid_KeyDown);
            // 
            // MappingCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MappingCntrl";
            this.Size = new System.Drawing.Size(999, 682);
            this.Load += new System.EventHandler(this.MappingCntrl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.fileStrip.ResumeLayout(false);
            this.fileStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdmapGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView grdmapGrid;
        private System.Windows.Forms.MenuStrip fileStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMapFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMapFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importInvCodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFlipkartInvFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importAmazonInvFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSnapdealInvFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMeeshoInvFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertMapFileURLsToLocalImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowAmzInv;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowFkInv;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowSpdInv;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowMsoInv;
        private System.Windows.Forms.ToolStripTextBox toolStripTxtSearchBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImgSearch;
    }
}
