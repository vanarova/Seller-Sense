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
            Syncfusion.Windows.Forms.Tools.SplitButtonRenderer splitButtonRenderer1 = new Syncfusion.Windows.Forms.Tools.SplitButtonRenderer();
            this.splitButton_adv_filter = new Syncfusion.Windows.Forms.Tools.SplitButton();
            this.toolstripitem1 = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            this.toolstripitem2 = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            this.toolstripitem3 = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fileStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.importAmazonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importAmazonFileOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFlipkartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSnapdealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importShelfStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkProductsWhichAreSoldAsAPackageWhoseInventoriesReducesincreasesTogetherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendTotalOrderCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendInvStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importAmazonOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendAmazonOrdersOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFlipkartOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSnapdealOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label_Help = new System.Windows.Forms.Label();
            this.label_meesho = new System.Windows.Forms.Label();
            this.label_snapdeal = new System.Windows.Forms.Label();
            this.label_flipkart = new System.Windows.Forms.Label();
            this.label_amazon = new System.Windows.Forms.Label();
            this.progressBar_Invload = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.fileStrip.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitButton_adv_filter
            // 
            this.splitButton_adv_filter.BeforeTouchSize = new System.Drawing.Size(75, 28);
            this.splitButton_adv_filter.DropDownItems.Add(this.toolstripitem1);
            this.splitButton_adv_filter.DropDownItems.Add(this.toolstripitem2);
            this.splitButton_adv_filter.DropDownItems.Add(this.toolstripitem3);
            this.splitButton_adv_filter.DropDownPosition = Syncfusion.Windows.Forms.Tools.Position.Top;
            this.splitButton_adv_filter.ForeColor = System.Drawing.Color.Black;
            this.splitButton_adv_filter.IsButtonChecked = true;
            this.splitButton_adv_filter.Location = new System.Drawing.Point(28, 6);
            this.splitButton_adv_filter.Margin = new System.Windows.Forms.Padding(4);
            this.splitButton_adv_filter.MinimumSize = new System.Drawing.Size(75, 28);
            this.splitButton_adv_filter.Name = "splitButton_adv_filter";
            splitButtonRenderer1.SplitButton = this.splitButton_adv_filter;
            this.splitButton_adv_filter.Renderer = splitButtonRenderer1;
            this.splitButton_adv_filter.ShowDropDownOnButtonClick = true;
            this.splitButton_adv_filter.Size = new System.Drawing.Size(75, 28);
            this.splitButton_adv_filter.TabIndex = 18;
            this.splitButton_adv_filter.Text = "View";
            // 
            // toolstripitem1
            // 
            this.toolstripitem1.Name = "toolstripitem1";
            this.toolstripitem1.Size = new System.Drawing.Size(32, 19);
            this.toolstripitem1.Text = "Products with orders";
            // 
            // toolstripitem2
            // 
            this.toolstripitem2.Name = "toolstripitem2";
            this.toolstripitem2.Size = new System.Drawing.Size(32, 19);
            this.toolstripitem2.Text = "Products without orders";
            // 
            // toolstripitem3
            // 
            this.toolstripitem3.Name = "toolstripitem3";
            this.toolstripitem3.Size = new System.Drawing.Size(32, 19);
            this.toolstripitem3.Text = "All Products";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.fileStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545455F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.45455F));
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
            this.toolStripMenuItem_Save,
            this.linkToolStripMenuItem,
            this.sendTotalOrderCountToolStripMenuItem,
            this.sendInvStatusToolStripMenuItem,
            this.ordersToolStripMenuItem});
            this.fileStrip.Location = new System.Drawing.Point(0, 0);
            this.fileStrip.MinimumSize = new System.Drawing.Size(0, 15);
            this.fileStrip.Name = "fileStrip";
            this.fileStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.fileStrip.Size = new System.Drawing.Size(574, 31);
            this.fileStrip.TabIndex = 9;
            this.fileStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem_Save
            // 
            this.toolStripMenuItem_Save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importAmazonToolStripMenuItem,
            this.importAmazonFileOnlineToolStripMenuItem,
            this.importFlipkartToolStripMenuItem,
            this.importSnapdealToolStripMenuItem,
            this.importShelfStockToolStripMenuItem,
            this.exportAllToolStripMenuItem});
            this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
            this.toolStripMenuItem_Save.Size = new System.Drawing.Size(111, 27);
            this.toolStripMenuItem_Save.Text = "Inventory File";
            // 
            // importAmazonToolStripMenuItem
            // 
            this.importAmazonToolStripMenuItem.Name = "importAmazonToolStripMenuItem";
            this.importAmazonToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.importAmazonToolStripMenuItem.Text = "Import Amazon File🪄";
            // 
            // importAmazonFileOnlineToolStripMenuItem
            // 
            this.importAmazonFileOnlineToolStripMenuItem.Name = "importAmazonFileOnlineToolStripMenuItem";
            this.importAmazonFileOnlineToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.importAmazonFileOnlineToolStripMenuItem.Text = "Import Amazon File Online";
            // 
            // importFlipkartToolStripMenuItem
            // 
            this.importFlipkartToolStripMenuItem.Name = "importFlipkartToolStripMenuItem";
            this.importFlipkartToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.importFlipkartToolStripMenuItem.Text = "Import Flipkart File 🚀";
            // 
            // importSnapdealToolStripMenuItem
            // 
            this.importSnapdealToolStripMenuItem.Name = "importSnapdealToolStripMenuItem";
            this.importSnapdealToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.importSnapdealToolStripMenuItem.Text = "Import Snapdeal File 👜";
            // 
            // importShelfStockToolStripMenuItem
            // 
            this.importShelfStockToolStripMenuItem.Name = "importShelfStockToolStripMenuItem";
            this.importShelfStockToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.importShelfStockToolStripMenuItem.Text = "Import Shelf Stock ❖";
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.exportAllToolStripMenuItem.Text = "Export All 🡽";
            // 
            // linkToolStripMenuItem
            // 
            this.linkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linkProductsWhichAreSoldAsAPackageWhoseInventoriesReducesincreasesTogetherToolStripMenuItem});
            this.linkToolStripMenuItem.Name = "linkToolStripMenuItem";
            this.linkToolStripMenuItem.Size = new System.Drawing.Size(49, 27);
            this.linkToolStripMenuItem.Text = "Link";
            // 
            // linkProductsWhichAreSoldAsAPackageWhoseInventoriesReducesincreasesTogetherToolStripMenuItem
            // 
            this.linkProductsWhichAreSoldAsAPackageWhoseInventoriesReducesincreasesTogetherToolStripMenuItem.Name = "linkProductsWhichAreSoldAsAPackageWhoseInventoriesReducesincreasesTogetherToolStr" +
    "ipMenuItem";
            this.linkProductsWhichAreSoldAsAPackageWhoseInventoriesReducesincreasesTogetherToolStripMenuItem.Size = new System.Drawing.Size(676, 26);
            this.linkProductsWhichAreSoldAsAPackageWhoseInventoriesReducesincreasesTogetherToolStripMenuItem.Text = "Link products which are sold as a package, whose inventories reduces/increases to" +
    "gether";
            // 
            // sendTotalOrderCountToolStripMenuItem
            // 
            this.sendTotalOrderCountToolStripMenuItem.Name = "sendTotalOrderCountToolStripMenuItem";
            this.sendTotalOrderCountToolStripMenuItem.Size = new System.Drawing.Size(104, 27);
            this.sendTotalOrderCountToolStripMenuItem.Text = "Order Count";
            // 
            // sendInvStatusToolStripMenuItem
            // 
            this.sendInvStatusToolStripMenuItem.Name = "sendInvStatusToolStripMenuItem";
            this.sendInvStatusToolStripMenuItem.Size = new System.Drawing.Size(86, 27);
            this.sendInvStatusToolStripMenuItem.Text = "Inv Status";
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importAmazonOrdersToolStripMenuItem,
            this.appendAmazonOrdersOnlineToolStripMenuItem,
            this.importFlipkartOrdersToolStripMenuItem,
            this.importSnapdealOrdersToolStripMenuItem});
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(67, 27);
            this.ordersToolStripMenuItem.Text = "Orders";
            // 
            // importAmazonOrdersToolStripMenuItem
            // 
            this.importAmazonOrdersToolStripMenuItem.Name = "importAmazonOrdersToolStripMenuItem";
            this.importAmazonOrdersToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.importAmazonOrdersToolStripMenuItem.Text = "Append Amazon Orders";
            // 
            // appendAmazonOrdersOnlineToolStripMenuItem
            // 
            this.appendAmazonOrdersOnlineToolStripMenuItem.Name = "appendAmazonOrdersOnlineToolStripMenuItem";
            this.appendAmazonOrdersOnlineToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.appendAmazonOrdersOnlineToolStripMenuItem.Text = "Append Amazon Orders Online";
            // 
            // importFlipkartOrdersToolStripMenuItem
            // 
            this.importFlipkartOrdersToolStripMenuItem.Name = "importFlipkartOrdersToolStripMenuItem";
            this.importFlipkartOrdersToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.importFlipkartOrdersToolStripMenuItem.Text = "Append Flipkart Orders";
            // 
            // importSnapdealOrdersToolStripMenuItem
            // 
            this.importSnapdealOrdersToolStripMenuItem.Name = "importSnapdealOrdersToolStripMenuItem";
            this.importSnapdealOrdersToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.importSnapdealOrdersToolStripMenuItem.Text = "Append Snapdeal Orders";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label_Help);
            this.flowLayoutPanel1.Controls.Add(this.label_meesho);
            this.flowLayoutPanel1.Controls.Add(this.label_snapdeal);
            this.flowLayoutPanel1.Controls.Add(this.label_flipkart);
            this.flowLayoutPanel1.Controls.Add(this.label_amazon);
            this.flowLayoutPanel1.Controls.Add(this.splitButton_adv_filter);
            this.flowLayoutPanel1.Controls.Add(this.progressBar_Invload);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(575, 1);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(423, 29);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // label_Help
            // 
            this.label_Help.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Help.AutoSize = true;
            this.label_Help.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Help.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Help.Location = new System.Drawing.Point(396, 9);
            this.label_Help.Name = "label_Help";
            this.label_Help.Size = new System.Drawing.Size(18, 22);
            this.label_Help.TabIndex = 5;
            this.label_Help.Text = "?";
            this.label_Help.Click += new System.EventHandler(this.label_Help_Click);
            // 
            // label_meesho
            // 
            this.label_meesho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_meesho.AutoSize = true;
            this.label_meesho.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label_meesho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_meesho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_meesho.Location = new System.Drawing.Point(327, 9);
            this.label_meesho.Name = "label_meesho";
            this.label_meesho.Size = new System.Drawing.Size(63, 22);
            this.label_meesho.TabIndex = 0;
            this.label_meesho.Text = "Meesho";
            // 
            // label_snapdeal
            // 
            this.label_snapdeal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_snapdeal.AutoSize = true;
            this.label_snapdeal.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label_snapdeal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_snapdeal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_snapdeal.Location = new System.Drawing.Point(248, 9);
            this.label_snapdeal.Name = "label_snapdeal";
            this.label_snapdeal.Size = new System.Drawing.Size(73, 22);
            this.label_snapdeal.TabIndex = 1;
            this.label_snapdeal.Text = "Snapdeal";
            // 
            // label_flipkart
            // 
            this.label_flipkart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_flipkart.AutoSize = true;
            this.label_flipkart.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label_flipkart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_flipkart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_flipkart.Location = new System.Drawing.Point(182, 9);
            this.label_flipkart.Name = "label_flipkart";
            this.label_flipkart.Size = new System.Drawing.Size(60, 22);
            this.label_flipkart.TabIndex = 2;
            this.label_flipkart.Text = "Flipkart";
            // 
            // label_amazon
            // 
            this.label_amazon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_amazon.AutoSize = true;
            this.label_amazon.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label_amazon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_amazon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_amazon.Location = new System.Drawing.Point(110, 9);
            this.label_amazon.Name = "label_amazon";
            this.label_amazon.Size = new System.Drawing.Size(66, 22);
            this.label_amazon.TabIndex = 3;
            this.label_amazon.Text = "Amazon";
            // 
            // progressBar_Invload
            // 
            this.progressBar_Invload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Invload.Location = new System.Drawing.Point(355, 40);
            this.progressBar_Invload.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar_Invload.MarqueeAnimationSpeed = 200;
            this.progressBar_Invload.Name = "progressBar_Invload";
            this.progressBar_Invload.Size = new System.Drawing.Size(60, 23);
            this.progressBar_Invload.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar_Invload.TabIndex = 19;
            this.progressBar_Invload.Visible = false;
            // 
            // InvCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InvCntrl";
            this.Size = new System.Drawing.Size(999, 682);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.fileStrip.ResumeLayout(false);
            this.fileStrip.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

#endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip fileStrip;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Save;
        internal System.Windows.Forms.ToolStripMenuItem importAmazonToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem importFlipkartToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem importSnapdealToolStripMenuItem;
#if IncludeMeesho
        internal System.Windows.Forms.ToolStripMenuItem importMeeshoToolStripMenuItem;
#endif
        internal System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkProductsWhichAreSoldAsAPackageWhoseInventoriesReducesincreasesTogetherToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label_Help;
        internal System.Windows.Forms.Label label_meesho;
        internal System.Windows.Forms.Label label_snapdeal;
        internal System.Windows.Forms.Label label_flipkart;
        internal System.Windows.Forms.Label label_amazon;
        internal System.Windows.Forms.ToolStripMenuItem sendTotalOrderCountToolStripMenuItem;
#if IncludeMeesho
        internal System.Windows.Forms.ToolStripMenuItem meeshoInventoryToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem lastDayToolStripMenuItemMso;
        internal System.Windows.Forms.ToolStripMenuItem customDateToolStripMenuItemMso;
#endif
        internal System.Windows.Forms.ToolStripMenuItem sendInvStatusToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem importAmazonOrdersToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem importFlipkartOrdersToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem importSnapdealOrdersToolStripMenuItem;
        internal Syncfusion.Windows.Forms.Tools.SplitButton splitButton_adv_filter;
        internal Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem1;
        internal Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem2;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem3;
        internal System.Windows.Forms.ToolStripMenuItem importAmazonFileOnlineToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem appendAmazonOrdersOnlineToolStripMenuItem;
        internal System.Windows.Forms.ProgressBar progressBar_Invload;
        internal System.Windows.Forms.ToolStripMenuItem importShelfStockToolStripMenuItem;
    }
}
