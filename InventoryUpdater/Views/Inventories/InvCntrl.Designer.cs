namespace SellerSense
{
    partial class InvCntrl
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
            this.toolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.importAmazonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFlipkartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSnapdealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMeeshoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_compare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.withPreviousInventoryUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysCompareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onceCompareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.fileStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.fileStrip, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545455F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.45454F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1498, 1066);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // fileStrip
            // 
            this.fileStrip.AllowMerge = false;
            this.fileStrip.BackColor = System.Drawing.Color.Lavender;
            this.fileStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.fileStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fileStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Save,
            this.toolStripMenuItem_compare});
            this.fileStrip.Location = new System.Drawing.Point(0, 0);
            this.fileStrip.MinimumSize = new System.Drawing.Size(0, 23);
            this.fileStrip.Name = "fileStrip";
            this.fileStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.fileStrip.Size = new System.Drawing.Size(1498, 48);
            this.fileStrip.TabIndex = 9;
            this.fileStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem_Save
            // 
            this.toolStripMenuItem_Save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importAmazonToolStripMenuItem,
            this.importFlipkartToolStripMenuItem,
            this.importSnapdealToolStripMenuItem,
            this.importMeeshoToolStripMenuItem,
            this.exportAllToolStripMenuItem});
            this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
            this.toolStripMenuItem_Save.Size = new System.Drawing.Size(179, 42);
            this.toolStripMenuItem_Save.Text = "Inventory File";
            // 
            // importAmazonToolStripMenuItem
            // 
            this.importAmazonToolStripMenuItem.Name = "importAmazonToolStripMenuItem";
            this.importAmazonToolStripMenuItem.Size = new System.Drawing.Size(363, 44);
            this.importAmazonToolStripMenuItem.Text = "Import Amazon🪄";
            // 
            // importFlipkartToolStripMenuItem
            // 
            this.importFlipkartToolStripMenuItem.Name = "importFlipkartToolStripMenuItem";
            this.importFlipkartToolStripMenuItem.Size = new System.Drawing.Size(363, 44);
            this.importFlipkartToolStripMenuItem.Text = "Import Flipkart 🚀";
            // 
            // importSnapdealToolStripMenuItem
            // 
            this.importSnapdealToolStripMenuItem.Name = "importSnapdealToolStripMenuItem";
            this.importSnapdealToolStripMenuItem.Size = new System.Drawing.Size(363, 44);
            this.importSnapdealToolStripMenuItem.Text = "Import Snapdeal 👜";
            // 
            // importMeeshoToolStripMenuItem
            // 
            this.importMeeshoToolStripMenuItem.Name = "importMeeshoToolStripMenuItem";
            this.importMeeshoToolStripMenuItem.Size = new System.Drawing.Size(363, 44);
            this.importMeeshoToolStripMenuItem.Text = "Import Meesho 🍱";
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(363, 44);
            this.exportAllToolStripMenuItem.Text = "Export All 🡽";
            // 
            // toolStripMenuItem_compare
            // 
            this.toolStripMenuItem_compare.Checked = true;
            this.toolStripMenuItem_compare.CheckOnClick = true;
            this.toolStripMenuItem_compare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem_compare.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.withPreviousInventoryUpdateToolStripMenuItem});
            this.toolStripMenuItem_compare.Name = "toolStripMenuItem_compare";
            this.toolStripMenuItem_compare.Size = new System.Drawing.Size(131, 42);
            this.toolStripMenuItem_compare.Text = "Compare";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(477, 6);
            // 
            // withPreviousInventoryUpdateToolStripMenuItem
            // 
            this.withPreviousInventoryUpdateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysCompareToolStripMenuItem,
            this.onceCompareToolStripMenuItem});
            this.withPreviousInventoryUpdateToolStripMenuItem.Name = "withPreviousInventoryUpdateToolStripMenuItem";
            this.withPreviousInventoryUpdateToolStripMenuItem.Size = new System.Drawing.Size(480, 44);
            this.withPreviousInventoryUpdateToolStripMenuItem.Text = "with previous inventory update";
            // 
            // alwaysCompareToolStripMenuItem
            // 
            this.alwaysCompareToolStripMenuItem.Checked = true;
            this.alwaysCompareToolStripMenuItem.CheckOnClick = true;
            this.alwaysCompareToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alwaysCompareToolStripMenuItem.Name = "alwaysCompareToolStripMenuItem";
            this.alwaysCompareToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.alwaysCompareToolStripMenuItem.Text = "Always";
            // 
            // onceToolStripMenuItem
            // 
            this.onceCompareToolStripMenuItem.Name = "onceToolStripMenuItem";
            this.onceCompareToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.onceCompareToolStripMenuItem.Text = "Once";
            // 
            // InvCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InvCntrl";
            this.Size = new System.Drawing.Size(1498, 1066);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.fileStrip.ResumeLayout(false);
            this.fileStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip fileStrip;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Save;
        internal System.Windows.Forms.ToolStripMenuItem importAmazonToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem importFlipkartToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem importSnapdealToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem importMeeshoToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_compare;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem withPreviousInventoryUpdateToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem alwaysCompareToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem onceCompareToolStripMenuItem;
    }
}
