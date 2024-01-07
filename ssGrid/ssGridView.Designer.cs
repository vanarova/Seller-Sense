namespace ssGrid
{
    partial class ssGridView<T>
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
            this.sfDataGrid2 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.sfDataPager1 = new Syncfusion.WinForms.DataPager.SfDataPager();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_isDirty = new System.Windows.Forms.Panel();
            this.label_info = new System.Windows.Forms.Label();
            this.progressBar_Search = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sfDataGrid2
            // 
            this.sfDataGrid2.AccessibleName = "Table";
            this.sfDataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid2.AutoExpandGroups = true;
            this.sfDataGrid2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.tableLayoutPanel1.SetColumnSpan(this.sfDataGrid2, 5);
            this.sfDataGrid2.Location = new System.Drawing.Point(4, 5);
            this.sfDataGrid2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sfDataGrid2.Name = "sfDataGrid2";
            this.sfDataGrid2.RowHeight = 21;
            this.sfDataGrid2.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Extended;
            this.sfDataGrid2.ShowGroupDropArea = true;
            this.sfDataGrid2.Size = new System.Drawing.Size(702, 523);
            this.sfDataGrid2.TabIndex = 1;
            this.sfDataGrid2.Text = "sfDataGrid2";
            // 
            // sfDataPager1
            // 
            this.sfDataPager1.AccessibleName = "DataPager";
            this.sfDataPager1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataPager1.CanOverrideStyle = true;
            this.sfDataPager1.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.sfDataPager1.Location = new System.Drawing.Point(3, 536);
            this.sfDataPager1.Name = "sfDataPager1";
            this.sfDataPager1.Size = new System.Drawing.Size(370, 45);
            this.sfDataPager1.TabIndex = 3;
            this.sfDataPager1.Text = "sfDataPager1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.sfDataGrid2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sfDataPager1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_isDirty, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_info, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBar_Search, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 584);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel_isDirty
            // 
            this.panel_isDirty.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel_isDirty.Location = new System.Drawing.Point(680, 540);
            this.panel_isDirty.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_isDirty.Name = "panel_isDirty";
            this.panel_isDirty.Size = new System.Drawing.Size(12, 36);
            this.panel_isDirty.TabIndex = 13;
            // 
            // label_info
            // 
            this.label_info.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(697, 552);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(10, 13);
            this.label_info.TabIndex = 15;
            this.label_info.Text = "-";
            // 
            // progressBar_Search
            // 
            this.progressBar_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Search.Location = new System.Drawing.Point(575, 547);
            this.progressBar_Search.Name = "progressBar_Search";
            this.progressBar_Search.Size = new System.Drawing.Size(100, 23);
            this.progressBar_Search.TabIndex = 16;
            // 
            // ssGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ssGridView";
            this.Size = new System.Drawing.Size(710, 584);
            this.Load += new System.EventHandler(this.ssGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid2;
        private Syncfusion.WinForms.DataPager.SfDataPager sfDataPager1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_isDirty;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.ProgressBar progressBar_Search;
    }
}
