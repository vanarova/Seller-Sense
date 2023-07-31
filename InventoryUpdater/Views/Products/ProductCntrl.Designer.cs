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
            this.flipkartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snapdealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meeshoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
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
            this.amazonToolStripMenuItem,
            this.flipkartToolStripMenuItem,
            this.snapdealToolStripMenuItem,
            this.meeshoToolStripMenuItem});
            this.fileStrip.Location = new System.Drawing.Point(0, 0);
            this.fileStrip.MinimumSize = new System.Drawing.Size(0, 15);
            this.fileStrip.Name = "fileStrip";
            this.fileStrip.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.fileStrip.Size = new System.Drawing.Size(456, 30);
            this.fileStrip.TabIndex = 9;
            this.fileStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem_Save
            // 
            this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
            this.toolStripMenuItem_Save.Size = new System.Drawing.Size(54, 26);
            this.toolStripMenuItem_Save.Text = "Save";
            // 
            // amazonToolStripMenuItem
            // 
            this.amazonToolStripMenuItem.Name = "amazonToolStripMenuItem";
            this.amazonToolStripMenuItem.Size = new System.Drawing.Size(99, 26);
            this.amazonToolStripMenuItem.Text = "Amazon🪄";
            // 
            // flipkartToolStripMenuItem
            // 
            this.flipkartToolStripMenuItem.Name = "flipkartToolStripMenuItem";
            this.flipkartToolStripMenuItem.Size = new System.Drawing.Size(93, 26);
            this.flipkartToolStripMenuItem.Text = "Flipkart🚀";
            // 
            // snapdealToolStripMenuItem
            // 
            this.snapdealToolStripMenuItem.Name = "snapdealToolStripMenuItem";
            this.snapdealToolStripMenuItem.Size = new System.Drawing.Size(106, 26);
            this.snapdealToolStripMenuItem.Text = "Snapdeal👜";
            // 
            // meeshoToolStripMenuItem
            // 
            this.meeshoToolStripMenuItem.Name = "meeshoToolStripMenuItem";
            this.meeshoToolStripMenuItem.Size = new System.Drawing.Size(96, 26);
            this.meeshoToolStripMenuItem.Text = "Meesho🍱";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label_help);
            this.flowLayoutPanel1.Controls.Add(this.button_AddProduct);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(456, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(543, 30);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // label_help
            // 
            this.label_help.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_help.AutoSize = true;
            this.label_help.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_help.Location = new System.Drawing.Point(522, 3);
            this.label_help.Name = "label_help";
            this.label_help.Size = new System.Drawing.Size(18, 23);
            this.label_help.TabIndex = 1;
            this.label_help.Text = "?";
            // 
            // button_AddProduct
            // 
            this.button_AddProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_AddProduct.AutoSize = true;
            this.button_AddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_AddProduct.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.button_AddProduct.Location = new System.Drawing.Point(413, 0);
            this.button_AddProduct.Margin = new System.Windows.Forms.Padding(0);
            this.button_AddProduct.Name = "button_AddProduct";
            this.button_AddProduct.Size = new System.Drawing.Size(106, 30);
            this.button_AddProduct.TabIndex = 2;
            this.button_AddProduct.Text = "Add Product";
            this.button_AddProduct.UseVisualStyleBackColor = true;
            // 
            // ProductCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProductCntrl";
            this.Size = new System.Drawing.Size(999, 682);
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
        internal System.Windows.Forms.ToolStripMenuItem meeshoToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label_help;
        internal System.Windows.Forms.Button button_AddProduct;
    }
}
