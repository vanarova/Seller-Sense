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
#if IncludeMeesho
            this.meeshoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
#endif
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label_help = new System.Windows.Forms.Label();
            this.button_AddProduct = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.fileStrip.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(749, 554);
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
            this.snapdealToolStripMenuItem
#if IncludeMeesho
            ,this.meeshoToolStripMenuItem
#endif
            });
            this.fileStrip.Location = new System.Drawing.Point(0, 0);
            this.fileStrip.MinimumSize = new System.Drawing.Size(0, 12);
            this.fileStrip.Name = "fileStrip";
            this.fileStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.fileStrip.Size = new System.Drawing.Size(346, 24);
            this.fileStrip.TabIndex = 9;
            this.fileStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem_Save
            // 
            this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
            this.toolStripMenuItem_Save.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItem_Save.Text = "Save";
            // 
            // amazonToolStripMenuItem
            // 
            this.amazonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapAsinToolStripMenuItem,
            this.mapAmzSKUToolStripMenuItem});
            this.amazonToolStripMenuItem.Name = "amazonToolStripMenuItem";
            this.amazonToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
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
            this.flipkartToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
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
            this.snapdealToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.snapdealToolStripMenuItem.Text = "Snapdeal👜";
            // 
            // mapSPDCodeToolStripMenuItem
            // 
            this.mapSPDCodeToolStripMenuItem.Name = "mapSPDCodeToolStripMenuItem";
            this.mapSPDCodeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.mapSPDCodeToolStripMenuItem.Text = "Map SPD Code";
            // 
            // mapSpdSKUToolStripMenuItem
            // 
            this.mapSpdSKUToolStripMenuItem.Name = "mapSpdSKUToolStripMenuItem";
            this.mapSpdSKUToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.mapSpdSKUToolStripMenuItem.Text = "Map SKU";
            // 
            // meeshoToolStripMenuItem
            // 
#if IncludeMeesho
            this.meeshoToolStripMenuItem.Name = "meeshoToolStripMenuItem";
            this.meeshoToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.meeshoToolStripMenuItem.Text = "Meesho🍱";
#endif
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label_help);
            this.flowLayoutPanel1.Controls.Add(this.button_AddProduct);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(346, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(403, 24);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // label_help
            // 
            this.label_help.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_help.AutoSize = true;
            this.label_help.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_help.Location = new System.Drawing.Point(386, 2);
            this.label_help.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_help.Name = "label_help";
            this.label_help.Size = new System.Drawing.Size(15, 19);
            this.label_help.TabIndex = 1;
            this.label_help.Text = "?";
            // 
            // button_AddProduct
            // 
            this.button_AddProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_AddProduct.AutoSize = true;
            this.button_AddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_AddProduct.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.button_AddProduct.Location = new System.Drawing.Point(303, 0);
            this.button_AddProduct.Margin = new System.Windows.Forms.Padding(0);
            this.button_AddProduct.Name = "button_AddProduct";
            this.button_AddProduct.Size = new System.Drawing.Size(81, 24);
            this.button_AddProduct.TabIndex = 2;
            this.button_AddProduct.Text = "Add Product";
            this.button_AddProduct.UseVisualStyleBackColor = true;
            // 
            // ProductCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductCntrl";
            this.Size = new System.Drawing.Size(749, 554);
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
        internal System.Windows.Forms.Button button_AddProduct;
        internal System.Windows.Forms.ToolStripMenuItem mapAsinToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mapAmzSKUToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mapFSNToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mapFkSKUToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mapSPDCodeToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mapSpdSKUToolStripMenuItem;
    }
}
