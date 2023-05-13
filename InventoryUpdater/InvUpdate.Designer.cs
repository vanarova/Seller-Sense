namespace InventoryUpdater
{
    partial class InvUpdate
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.importAmazonInvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amazonInventoryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipkartInventoryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snapdealInventoryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meeshoInventoryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grdInvUpdate = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_exportSllInv = new System.Windows.Forms.Button();
            this.pbar_Loading = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvUpdate)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importAmazonInvToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(226, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // importAmazonInvToolStripMenuItem
            // 
            this.importAmazonInvToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.amazonInventoryFileToolStripMenuItem,
            this.flipkartInventoryFileToolStripMenuItem,
            this.snapdealInventoryFileToolStripMenuItem,
            this.meeshoInventoryFileToolStripMenuItem});
            this.importAmazonInvToolStripMenuItem.Name = "importAmazonInvToolStripMenuItem";
            this.importAmazonInvToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.importAmazonInvToolStripMenuItem.Text = "Import";
            // 
            // amazonInventoryFileToolStripMenuItem
            // 
            this.amazonInventoryFileToolStripMenuItem.Name = "amazonInventoryFileToolStripMenuItem";
            this.amazonInventoryFileToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.amazonInventoryFileToolStripMenuItem.Text = "Amazon Inventory File";
            //this.amazonInventoryFileToolStripMenuItem.Click += new System.EventHandler(this.amazonInventoryFileToolStripMenuItem_Click);
            // 
            // flipkartInventoryFileToolStripMenuItem
            // 
            this.flipkartInventoryFileToolStripMenuItem.Name = "flipkartInventoryFileToolStripMenuItem";
            this.flipkartInventoryFileToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.flipkartInventoryFileToolStripMenuItem.Text = "Flipkart Inventory File";
            //this.flipkartInventoryFileToolStripMenuItem.Click += new System.EventHandler(this.flipkartInventoryFileToolStripMenuItem_Click);
            // 
            // snapdealInventoryFileToolStripMenuItem
            // 
            this.snapdealInventoryFileToolStripMenuItem.Name = "snapdealInventoryFileToolStripMenuItem";
            this.snapdealInventoryFileToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.snapdealInventoryFileToolStripMenuItem.Text = "Snapdeal Inventory File";
            //this.snapdealInventoryFileToolStripMenuItem.Click += new System.EventHandler(this.snapdealInventoryFileToolStripMenuItem_Click);
            // 
            // meeshoInventoryFileToolStripMenuItem
            // 
            this.meeshoInventoryFileToolStripMenuItem.Name = "meeshoInventoryFileToolStripMenuItem";
            this.meeshoInventoryFileToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.meeshoInventoryFileToolStripMenuItem.Text = "Meesho Inventory File";
            //this.meeshoInventoryFileToolStripMenuItem.Click += new System.EventHandler(this.meeshoInventoryFileToolStripMenuItem_Click);
            // 
            // grdInvUpdate
            // 
            this.grdInvUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.grdInvUpdate, 6);
            this.grdInvUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInvUpdate.Location = new System.Drawing.Point(3, 46);
            this.grdInvUpdate.Name = "grdInvUpdate";
            this.grdInvUpdate.RowHeadersWidth = 51;
            this.grdInvUpdate.RowTemplate.Height = 24;
            this.grdInvUpdate.Size = new System.Drawing.Size(1230, 689);
            this.grdInvUpdate.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.71521F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.51133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.Controls.Add(this.grdInvUpdate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_exportSllInv, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbar_Loading, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.962059F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.03794F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1236, 738);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(813, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search : ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(881, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 22);
            this.textBox1.TabIndex = 3;
            // 
            // btn_exportSllInv
            // 
            this.btn_exportSllInv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exportSllInv.Location = new System.Drawing.Point(712, 3);
            this.btn_exportSllInv.Name = "btn_exportSllInv";
            this.btn_exportSllInv.Size = new System.Drawing.Size(95, 37);
            this.btn_exportSllInv.TabIndex = 4;
            this.btn_exportSllInv.Text = "Export All";
            this.btn_exportSllInv.UseVisualStyleBackColor = true;
            // 
            // pbar_Loading
            // 
            this.pbar_Loading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbar_Loading.Location = new System.Drawing.Point(1130, 13);
            this.pbar_Loading.Name = "pbar_Loading";
            this.pbar_Loading.Size = new System.Drawing.Size(103, 17);
            this.pbar_Loading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbar_Loading.TabIndex = 5;
            this.pbar_Loading.Visible = false;
            // 
            // InvUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 738);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InvUpdate";
            this.Text = "InvUpdate";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvUpdate)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importAmazonInvToolStripMenuItem;
        private System.Windows.Forms.DataGridView grdInvUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_exportSllInv;
        private System.Windows.Forms.ToolStripMenuItem amazonInventoryFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipkartInventoryFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem snapdealInventoryFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meeshoInventoryFileToolStripMenuItem;
        private System.Windows.Forms.ProgressBar pbar_Loading;
    }
}