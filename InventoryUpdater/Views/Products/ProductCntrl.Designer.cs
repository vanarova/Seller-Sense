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
            this.amazonToolStripMenuItem,
            this.flipkartToolStripMenuItem,
            this.snapdealToolStripMenuItem,
            this.meeshoToolStripMenuItem});
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
            this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
            this.toolStripMenuItem_Save.Size = new System.Drawing.Size(84, 42);
            this.toolStripMenuItem_Save.Text = "Save";
            // 
            // amazonToolStripMenuItem
            // 
            this.amazonToolStripMenuItem.Name = "amazonToolStripMenuItem";
            this.amazonToolStripMenuItem.Size = new System.Drawing.Size(154, 42);
            this.amazonToolStripMenuItem.Text = "Amazon🪄";
            // 
            // flipkartToolStripMenuItem
            // 
            this.flipkartToolStripMenuItem.Name = "flipkartToolStripMenuItem";
            this.flipkartToolStripMenuItem.Size = new System.Drawing.Size(145, 42);
            this.flipkartToolStripMenuItem.Text = "Flipkart🚀";
            // 
            // snapdealToolStripMenuItem
            // 
            this.snapdealToolStripMenuItem.Name = "snapdealToolStripMenuItem";
            this.snapdealToolStripMenuItem.Size = new System.Drawing.Size(165, 42);
            this.snapdealToolStripMenuItem.Text = "Snapdeal👜";
            // 
            // meeshoToolStripMenuItem
            // 
            this.meeshoToolStripMenuItem.Name = "meeshoToolStripMenuItem";
            this.meeshoToolStripMenuItem.Size = new System.Drawing.Size(153, 42);
            this.meeshoToolStripMenuItem.Text = "Meesho🍱";
            // 
            // ProductCntrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProductCntrl";
            this.Size = new System.Drawing.Size(1498, 1066);
            this.Load += new System.EventHandler(this.ProductCntrl_Load);
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
        internal System.Windows.Forms.ToolStripMenuItem amazonToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem flipkartToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem snapdealToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem meeshoToolStripMenuItem;
    }
}
