namespace InventoryUpdater
{
    partial class Mapping
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdmapGrid = new System.Windows.Forms.DataGridView();
            this.fileStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importInvCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFlipkartInvFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importAmazonInvFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSnapdealInvFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMeeshoInvFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertMapFileURLsToLocalImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importAmazonInvFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowAmzInv = new System.Windows.Forms.ToolStripMenuItem();
            this.importFlipkartInvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowFkInv = new System.Windows.Forms.ToolStripMenuItem();
            this.importSnapdealInvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowSpdInv = new System.Windows.Forms.ToolStripMenuItem();
            this.importMeeshoInvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowMsoInv = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdmapGrid)).BeginInit();
            this.fileStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.grdmapGrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.489796F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.5102F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1294, 735);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdmapGrid
            // 
            this.grdmapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdmapGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdmapGrid.Location = new System.Drawing.Point(3, 36);
            this.grdmapGrid.MultiSelect = false;
            this.grdmapGrid.Name = "grdmapGrid";
            this.grdmapGrid.RowHeadersWidth = 51;
            this.grdmapGrid.RowTemplate.Height = 24;
            this.grdmapGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdmapGrid.Size = new System.Drawing.Size(1288, 696);
            this.grdmapGrid.TabIndex = 4;
            this.grdmapGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdmapGrid_CellEndEdit);
            this.grdmapGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdmapGrid_CellEnter);
            this.grdmapGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdmapGrid_CellLeave);
            this.grdmapGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdmapGrid_CellMouseDown);
            // 
            // fileStrip
            // 
            this.fileStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.fileStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fileStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.importAmazonInvFileToolStripMenuItem1,
            this.toolStripMenuItemShowAmzInv,
            this.importFlipkartInvToolStripMenuItem,
            this.toolStripMenuItemShowFkInv,
            this.importSnapdealInvToolStripMenuItem,
            this.toolStripMenuItemShowSpdInv,
            this.importMeeshoInvToolStripMenuItem,
            this.toolStripMenuItemShowMsoInv});
            this.fileStrip.Location = new System.Drawing.Point(0, 0);
            this.fileStrip.MinimumSize = new System.Drawing.Size(0, 15);
            this.fileStrip.Name = "fileStrip";
            this.fileStrip.Size = new System.Drawing.Size(790, 31);
            this.fileStrip.TabIndex = 5;
            this.fileStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMapFileToolStripMenuItem,
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
            this.openMapFileToolStripMenuItem.Name = "openMapFileToolStripMenuItem";
            this.openMapFileToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.openMapFileToolStripMenuItem.Text = "Open Map File";
            this.openMapFileToolStripMenuItem.Click += new System.EventHandler(this.openMapFileToolStripMenuItem_Click);
            // 
            // saveMapFileToolStripMenuItem
            // 
            this.saveMapFileToolStripMenuItem.Name = "saveMapFileToolStripMenuItem";
            this.saveMapFileToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.saveMapFileToolStripMenuItem.Text = "Save Map File";
            this.saveMapFileToolStripMenuItem.Click += new System.EventHandler(this.saveMapFileToolStripMenuItem_Click);
            // 
            // saveAsMapFileToolStripMenuItem
            // 
            this.saveAsMapFileToolStripMenuItem.Name = "saveAsMapFileToolStripMenuItem";
            this.saveAsMapFileToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.saveAsMapFileToolStripMenuItem.Text = "Save As Map File";
            this.saveAsMapFileToolStripMenuItem.Click += new System.EventHandler(this.saveAsMapFileToolStripMenuItem_Click);
            // 
            // importInvCodesToolStripMenuItem
            // 
            this.importInvCodesToolStripMenuItem.Name = "importInvCodesToolStripMenuItem";
            this.importInvCodesToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.importInvCodesToolStripMenuItem.Text = "Import Inv Codes";
            this.importInvCodesToolStripMenuItem.Click += new System.EventHandler(this.importInvCodesToolStripMenuItem_Click);
            // 
            // importFlipkartInvFileToolStripMenuItem
            // 
            this.importFlipkartInvFileToolStripMenuItem.Name = "importFlipkartInvFileToolStripMenuItem";
            this.importFlipkartInvFileToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.importFlipkartInvFileToolStripMenuItem.Text = "Import Flipkart Inv File";
            this.importFlipkartInvFileToolStripMenuItem.Click += new System.EventHandler(this.importFlipkartInvFileToolStripMenuItem_Click);
            // 
            // importAmazonInvFileToolStripMenuItem
            // 
            this.importAmazonInvFileToolStripMenuItem.Name = "importAmazonInvFileToolStripMenuItem";
            this.importAmazonInvFileToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.importAmazonInvFileToolStripMenuItem.Text = "Import Amazon Inv File";
            this.importAmazonInvFileToolStripMenuItem.Click += new System.EventHandler(this.importAmazonInvFileToolStripMenuItem_Click);
            // 
            // importSnapdealInvFileToolStripMenuItem
            // 
            this.importSnapdealInvFileToolStripMenuItem.Name = "importSnapdealInvFileToolStripMenuItem";
            this.importSnapdealInvFileToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.importSnapdealInvFileToolStripMenuItem.Text = "Import Snapdeal Inv File";
            // 
            // importMeeshoInvFileToolStripMenuItem
            // 
            this.importMeeshoInvFileToolStripMenuItem.Name = "importMeeshoInvFileToolStripMenuItem";
            this.importMeeshoInvFileToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.importMeeshoInvFileToolStripMenuItem.Text = "Import Meesho Inv File";
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertMapFileURLsToLocalImagesToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // convertMapFileURLsToLocalImagesToolStripMenuItem
            // 
            this.convertMapFileURLsToLocalImagesToolStripMenuItem.Name = "convertMapFileURLsToLocalImagesToolStripMenuItem";
            this.convertMapFileURLsToLocalImagesToolStripMenuItem.Size = new System.Drawing.Size(347, 26);
            this.convertMapFileURLsToLocalImagesToolStripMenuItem.Text = "Convert Map File URLsTo Local Images";
            this.convertMapFileURLsToLocalImagesToolStripMenuItem.Click += new System.EventHandler(this.convertMapFileURLsToLocalImagesToolStripMenuItem_Click);
            // 
            // importAmazonInvFileToolStripMenuItem1
            // 
            this.importAmazonInvFileToolStripMenuItem1.Enabled = false;
            this.importAmazonInvFileToolStripMenuItem1.Name = "importAmazonInvFileToolStripMenuItem1";
            this.importAmazonInvFileToolStripMenuItem1.Size = new System.Drawing.Size(150, 27);
            this.importAmazonInvFileToolStripMenuItem1.Text = "Import Amazon Inv";
            this.importAmazonInvFileToolStripMenuItem1.Click += new System.EventHandler(this.importAmazonInvFileToolStripMenuItem1_Click);
            // 
            // toolStripMenuItemShowAmzInv
            // 
            this.toolStripMenuItemShowAmzInv.BackColor = System.Drawing.Color.Silver;
            this.toolStripMenuItemShowAmzInv.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemShowAmzInv.Name = "toolStripMenuItemShowAmzInv";
            this.toolStripMenuItemShowAmzInv.Size = new System.Drawing.Size(36, 27);
            this.toolStripMenuItemShowAmzInv.Text = "^";
            this.toolStripMenuItemShowAmzInv.Click += new System.EventHandler(this.toolStripMenuItemShowAmzInv_Click);
            // 
            // importFlipkartInvToolStripMenuItem
            // 
            this.importFlipkartInvToolStripMenuItem.Enabled = false;
            this.importFlipkartInvToolStripMenuItem.Name = "importFlipkartInvToolStripMenuItem";
            this.importFlipkartInvToolStripMenuItem.Size = new System.Drawing.Size(144, 27);
            this.importFlipkartInvToolStripMenuItem.Text = "Import Flipkart Inv";
            this.importFlipkartInvToolStripMenuItem.Click += new System.EventHandler(this.importFlipkartInvToolStripMenuItem_Click);
            // 
            // toolStripMenuItemShowFkInv
            // 
            this.toolStripMenuItemShowFkInv.BackColor = System.Drawing.Color.Silver;
            this.toolStripMenuItemShowFkInv.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItemShowFkInv.Name = "toolStripMenuItemShowFkInv";
            this.toolStripMenuItemShowFkInv.Size = new System.Drawing.Size(36, 27);
            this.toolStripMenuItemShowFkInv.Text = "^";
            this.toolStripMenuItemShowFkInv.Click += new System.EventHandler(this.toolStripMenuItemShowFkInv_Click);
            // 
            // importSnapdealInvToolStripMenuItem
            // 
            this.importSnapdealInvToolStripMenuItem.Name = "importSnapdealInvToolStripMenuItem";
            this.importSnapdealInvToolStripMenuItem.Size = new System.Drawing.Size(157, 27);
            this.importSnapdealInvToolStripMenuItem.Text = "Import Snapdeal Inv";
            this.importSnapdealInvToolStripMenuItem.Click += new System.EventHandler(this.importSnapdealInvToolStripMenuItem_Click);
            // 
            // toolStripMenuItemShowSpdInv
            // 
            this.toolStripMenuItemShowSpdInv.Name = "toolStripMenuItemShowSpdInv";
            this.toolStripMenuItemShowSpdInv.Size = new System.Drawing.Size(33, 27);
            this.toolStripMenuItemShowSpdInv.Text = "^";
            this.toolStripMenuItemShowSpdInv.Click += new System.EventHandler(this.toolStripMenuItemShowSpdInv_Click);
            // 
            // importMeeshoInvToolStripMenuItem
            // 
            this.importMeeshoInvToolStripMenuItem.Name = "importMeeshoInvToolStripMenuItem";
            this.importMeeshoInvToolStripMenuItem.Size = new System.Drawing.Size(147, 27);
            this.importMeeshoInvToolStripMenuItem.Text = "Import Meesho Inv";
            this.importMeeshoInvToolStripMenuItem.Click += new System.EventHandler(this.importMeeshoInvToolStripMenuItem_Click);
            // 
            // toolStripMenuItemShowMsoInv
            // 
            this.toolStripMenuItemShowMsoInv.Name = "toolStripMenuItemShowMsoInv";
            this.toolStripMenuItemShowMsoInv.Size = new System.Drawing.Size(33, 27);
            this.toolStripMenuItemShowMsoInv.Text = "^";
            this.toolStripMenuItemShowMsoInv.Click += new System.EventHandler(this.toolStripMenuItemShowMsoInv_Click);
            // 
            // Mapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 735);
            this.Controls.Add(this.fileStrip);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "Mapping";
            this.Text = "Mapping";
            this.Load += new System.EventHandler(this.Mapping_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdmapGrid)).EndInit();
            this.fileStrip.ResumeLayout(false);
            this.fileStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView grdmapGrid;
        private System.Windows.Forms.MenuStrip fileStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importInvCodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFlipkartInvFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importAmazonInvFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSnapdealInvFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMeeshoInvFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importAmazonInvFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowAmzInv;
        private System.Windows.Forms.ToolStripMenuItem importFlipkartInvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowFkInv;
        private System.Windows.Forms.ToolStripMenuItem saveAsMapFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertMapFileURLsToLocalImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSnapdealInvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowSpdInv;
        private System.Windows.Forms.ToolStripMenuItem importMeeshoInvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowMsoInv;
    }
}