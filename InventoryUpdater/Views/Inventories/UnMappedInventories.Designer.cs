namespace SellerSense.Views.Inventories
{
    partial class UnMappedInventories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnMappedInventories));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sfButton_Close = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButton_Export = new Syncfusion.WinForms.Controls.SfButton();
            this.listBox_Inv = new System.Windows.Forms.ListBox();
            this.listBox_InHouse = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_title_SiteCodes = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.210918F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.78909F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBox_Inv, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBox_InHouse, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_title_SiteCodes, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.62619F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.40038F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.82922F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.14421F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 527);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.sfButton_Close);
            this.flowLayoutPanel1.Controls.Add(this.sfButton_Export);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(246, 466);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(336, 58);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // sfButton_Close
            // 
            this.sfButton_Close.AccessibleName = "Button";
            this.sfButton_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton_Close.Location = new System.Drawing.Point(237, 3);
            this.sfButton_Close.Name = "sfButton_Close";
            this.sfButton_Close.Size = new System.Drawing.Size(96, 41);
            this.sfButton_Close.TabIndex = 0;
            this.sfButton_Close.Text = "Close";
            this.sfButton_Close.Click += new System.EventHandler(this.sfButton_Close_Click);
            // 
            // sfButton_Export
            // 
            this.sfButton_Export.AccessibleName = "Button";
            this.sfButton_Export.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton_Export.Location = new System.Drawing.Point(25, 3);
            this.sfButton_Export.Name = "sfButton_Export";
            this.sfButton_Export.Size = new System.Drawing.Size(206, 41);
            this.sfButton_Export.TabIndex = 1;
            this.sfButton_Export.Text = "Export product codes";
            this.sfButton_Export.Click += new System.EventHandler(this.sfButton_Export_Click);
            // 
            // listBox_Inv
            // 
            this.listBox_Inv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Inv.FormattingEnabled = true;
            this.listBox_Inv.ItemHeight = 16;
            this.listBox_Inv.Location = new System.Drawing.Point(298, 98);
            this.listBox_Inv.Name = "listBox_Inv";
            this.listBox_Inv.Size = new System.Drawing.Size(284, 362);
            this.listBox_Inv.TabIndex = 3;
            // 
            // listBox_InHouse
            // 
            this.listBox_InHouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_InHouse.FormattingEnabled = true;
            this.listBox_InHouse.ItemHeight = 16;
            this.listBox_InHouse.Location = new System.Drawing.Point(18, 98);
            this.listBox_InHouse.Name = "listBox_InHouse";
            this.listBox_InHouse.Size = new System.Drawing.Size(274, 362);
            this.listBox_InHouse.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unmapped in-house product code(s)";
            // 
            // label_title_SiteCodes
            // 
            this.label_title_SiteCodes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_title_SiteCodes.AutoSize = true;
            this.label_title_SiteCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title_SiteCodes.Location = new System.Drawing.Point(304, 24);
            this.label_title_SiteCodes.Name = "label_title_SiteCodes";
            this.label_title_SiteCodes.Size = new System.Drawing.Size(271, 32);
            this.label_title_SiteCodes.TabIndex = 1;
            this.label_title_SiteCodes.Text = "Unmapped product codes in imported inventory file";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(400, 67);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(182, 16);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "How to fix unmapped codes ?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(56, 67);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(236, 16);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Is unmapped in-house code an issue ?";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // UnMappedInventories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 531);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnMappedInventories";
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Unmapped Inventories";
            this.Load += new System.EventHandler(this.UnMappedInventories_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.WinForms.Controls.SfButton sfButton_Close;
        private System.Windows.Forms.Label label_title_SiteCodes;
        private System.Windows.Forms.Label label2;
        private Syncfusion.WinForms.Controls.SfButton sfButton_Export;
        private System.Windows.Forms.ListBox listBox_Inv;
        private System.Windows.Forms.ListBox listBox_InHouse;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}