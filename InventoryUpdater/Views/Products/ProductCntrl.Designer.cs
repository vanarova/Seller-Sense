namespace SellerSense
{
    partial class ProductCntrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCntrl));
            this.splitButton1 = new Syncfusion.Windows.Forms.Tools.SplitButton();
            this.toolstripitem_Prestashop = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            this.toolstripitem_Excel = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            this.toolstripitem_Add = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fileStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.amazonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapAsinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapAmzSKUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipkartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapFSNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapFkSKUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snapdealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapSPDCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapSpdSKUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label_help = new System.Windows.Forms.Label();
            this.sfButton_Invoice = new Syncfusion.WinForms.Controls.SfButton();
            this.checkBox_InvoiceMode = new System.Windows.Forms.CheckBox();
            this.toolstripitem_csv = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            this.toolstripitem_pdf = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            this.tableLayoutPanel1.SuspendLayout();
            this.fileStrip.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitButton1
            // 
            this.splitButton1.BackColor = System.Drawing.SystemColors.Control;
            this.splitButton1.BeforeTouchSize = new System.Drawing.Size(105, 24);
            this.splitButton1.DropDownItems.Add(this.toolstripitem_Prestashop);
            this.splitButton1.DropDownItems.Add(this.toolstripitem_Excel);
            this.splitButton1.DropDownItems.Add(this.toolstripitem_Add);
            this.splitButton1.DropDownPosition = Syncfusion.Windows.Forms.Tools.Position.Bottom;
            this.splitButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitButton1.ForeColor = System.Drawing.Color.Black;
            this.splitButton1.Location = new System.Drawing.Point(397, 2);
            this.splitButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitButton1.MinimumSize = new System.Drawing.Size(38, 12);
            this.splitButton1.Name = "splitButton1";
            splitButtonRenderer1.SplitButton = this.splitButton1;
            this.splitButton1.Renderer = splitButtonRenderer1;
            this.splitButton1.ShowDropDownOnButtonClick = false;
            this.splitButton1.Size = new System.Drawing.Size(105, 24);
            this.splitButton1.TabIndex = 6;
            this.splitButton1.Text = "Add / Import";
            this.splitButton1.ThemeName = "Default";
            // 
            // toolstripitem_Prestashop
            // 
            this.toolstripitem_Prestashop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolstripitem_Prestashop.Name = "toolstripitem_Prestashop";
            this.toolstripitem_Prestashop.Size = new System.Drawing.Size(32, 19);
            this.toolstripitem_Prestashop.Text = "Import From Prestashop";
            // 
            // toolstripitem_Excel
            // 
            this.toolstripitem_Excel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolstripitem_Excel.Name = "toolstripitem_Excel";
            this.toolstripitem_Excel.Size = new System.Drawing.Size(32, 19);
            this.toolstripitem_Excel.Text = "Excel Import";
            // 
            // toolstripitem_Add
            // 
            this.toolstripitem_Add.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolstripitem_Add.Name = "toolstripitem_Add";
            this.toolstripitem_Add.Size = new System.Drawing.Size(32, 19);
            this.toolstripitem_Add.Text = "Add Product";
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(796, 407);
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
            this.amazonToolStripMenuItem,
            this.flipkartToolStripMenuItem,
            this.snapdealToolStripMenuItem});
            this.fileStrip.Location = new System.Drawing.Point(0, 0);
            this.fileStrip.MinimumSize = new System.Drawing.Size(0, 12);
            this.fileStrip.Name = "fileStrip";
            this.fileStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.fileStrip.Size = new System.Drawing.Size(273, 32);
            this.fileStrip.TabIndex = 9;
            this.fileStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem_Save
            // 
            this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
            this.toolStripMenuItem_Save.Size = new System.Drawing.Size(43, 28);
            this.toolStripMenuItem_Save.Text = "Save";
            // 
            // amazonToolStripMenuItem
            // 
            this.amazonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapAsinToolStripMenuItem,
            this.mapAmzSKUToolStripMenuItem});
            this.amazonToolStripMenuItem.Name = "amazonToolStripMenuItem";
            this.amazonToolStripMenuItem.Size = new System.Drawing.Size(75, 28);
            this.amazonToolStripMenuItem.Text = "Amazon🪄";
            // 
            // mapAsinToolStripMenuItem
            // 
            this.mapAsinToolStripMenuItem.Name = "mapAsinToolStripMenuItem";
            this.mapAsinToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.mapAsinToolStripMenuItem.Text = "Map Asin";
            // 
            // mapAmzSKUToolStripMenuItem
            // 
            this.mapAmzSKUToolStripMenuItem.Name = "mapAmzSKUToolStripMenuItem";
            this.mapAmzSKUToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.mapAmzSKUToolStripMenuItem.Text = "Map SKU";
            // 
            // flipkartToolStripMenuItem
            // 
            this.flipkartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapFSNToolStripMenuItem,
            this.mapFkSKUToolStripMenuItem});
            this.flipkartToolStripMenuItem.Name = "flipkartToolStripMenuItem";
            this.flipkartToolStripMenuItem.Size = new System.Drawing.Size(70, 28);
            this.flipkartToolStripMenuItem.Text = "Flipkart🚀";
            // 
            // mapFSNToolStripMenuItem
            // 
            this.mapFSNToolStripMenuItem.Name = "mapFSNToolStripMenuItem";
            this.mapFSNToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.mapFSNToolStripMenuItem.Text = "Map FSN";
            // 
            // mapFkSKUToolStripMenuItem
            // 
            this.mapFkSKUToolStripMenuItem.Name = "mapFkSKUToolStripMenuItem";
            this.mapFkSKUToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.mapFkSKUToolStripMenuItem.Text = "Map SKU";
            // 
            // snapdealToolStripMenuItem
            // 
            this.snapdealToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapSPDCodeToolStripMenuItem,
            this.mapSpdSKUToolStripMenuItem});
            this.snapdealToolStripMenuItem.Name = "snapdealToolStripMenuItem";
            this.snapdealToolStripMenuItem.Size = new System.Drawing.Size(79, 28);
            this.snapdealToolStripMenuItem.Text = "Snapdeal👜";
            // 
            // mapSPDCodeToolStripMenuItem
            // 
            this.mapSPDCodeToolStripMenuItem.Name = "mapSPDCodeToolStripMenuItem";
            this.mapSPDCodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mapSPDCodeToolStripMenuItem.Text = "Map SPD Code";
            // 
            // mapSpdSKUToolStripMenuItem
            // 
            this.mapSpdSKUToolStripMenuItem.Name = "mapSpdSKUToolStripMenuItem";
            this.mapSpdSKUToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mapSpdSKUToolStripMenuItem.Text = "Map SKU";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label_help);
            this.flowLayoutPanel1.Controls.Add(this.splitButton1);
            this.flowLayoutPanel1.Controls.Add(this.sfButton_Invoice);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_InvoiceMode);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(273, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(523, 32);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // label_help
            // 
            this.label_help.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_help.AutoSize = true;
            this.label_help.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_help.Location = new System.Drawing.Point(506, 4);
            this.label_help.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_help.Name = "label_help";
            this.label_help.Size = new System.Drawing.Size(15, 19);
            this.label_help.TabIndex = 1;
            this.label_help.Text = "?";
            this.label_help.Click += new System.EventHandler(this.label_help_Click);
            // 
            // sfButton_Invoice
            // 
            this.sfButton_Invoice.AccessibleName = "Button";
            this.sfButton_Invoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sfButton_Invoice.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton_Invoice.Location = new System.Drawing.Point(303, 6);
            this.sfButton_Invoice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sfButton_Invoice.Name = "sfButton_Invoice";
            this.sfButton_Invoice.Size = new System.Drawing.Size(90, 15);
            this.sfButton_Invoice.TabIndex = 8;
            this.sfButton_Invoice.Text = "Create Invoice";
            // 
            // checkBox_InvoiceMode
            // 
            this.checkBox_InvoiceMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_InvoiceMode.AutoSize = true;
            this.checkBox_InvoiceMode.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_InvoiceMode.Location = new System.Drawing.Point(201, 4);
            this.checkBox_InvoiceMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_InvoiceMode.Name = "checkBox_InvoiceMode";
            this.checkBox_InvoiceMode.Size = new System.Drawing.Size(98, 19);
            this.checkBox_InvoiceMode.TabIndex = 7;
            this.checkBox_InvoiceMode.Text = "Invoice Mode";
            this.checkBox_InvoiceMode.UseVisualStyleBackColor = true;
            // 
            // toolstripitem_csv
            // 
            this.toolstripitem_csv.Image = ((System.Drawing.Image)(resources.GetObject("toolstripitem_csv.Image")));
            this.toolstripitem_csv.Name = "toolstripitem_csv";
            this.toolstripitem_csv.Size = new System.Drawing.Size(32, 19);
            this.toolstripitem_csv.Text = "CSV";
            // 
            // toolstripitem_pdf
            // 
            this.toolstripitem_pdf.Image = ((System.Drawing.Image)(resources.GetObject("toolstripitem_pdf.Image")));
            this.toolstripitem_pdf.Name = "toolstripitem_pdf";
            this.toolstripitem_pdf.Size = new System.Drawing.Size(32, 19);
            this.toolstripitem_pdf.Text = "PDF";
            // 
            // ProductCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProductCntrl";
            this.Size = new System.Drawing.Size(796, 407);
            this.Load += new System.EventHandler(this.ProductCntrl_Load);
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
        internal System.Windows.Forms.ToolStripMenuItem amazonToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem flipkartToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem snapdealToolStripMenuItem;
#if IncludeMeesho
        internal System.Windows.Forms.ToolStripMenuItem meeshoToolStripMenuItem;
#endif
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label_help;
        internal System.Windows.Forms.ToolStripMenuItem mapAsinToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mapAmzSKUToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mapFSNToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mapFkSKUToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mapSPDCodeToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mapSpdSKUToolStripMenuItem;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem_csv;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem_pdf;
        private Syncfusion.Windows.Forms.Tools.SplitButton splitButton1;
        internal Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem_Prestashop;
        internal Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem_Excel;
        internal Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem_Add;
        internal Syncfusion.WinForms.Controls.SfButton sfButton_Invoice;
        internal System.Windows.Forms.CheckBox checkBox_InvoiceMode;
    }
}
