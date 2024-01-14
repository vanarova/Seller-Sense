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
            Syncfusion.Windows.Forms.Tools.SplitButtonRenderer splitButtonRenderer1 = new Syncfusion.Windows.Forms.Tools.SplitButtonRenderer();
            this.splitButton_Export = new Syncfusion.Windows.Forms.Tools.SplitButton();
            this.sfDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.sfDataPager1 = new Syncfusion.WinForms.DataPager.SfDataPager();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_isDirty = new System.Windows.Forms.Panel();
            this.comboBox_PageSize = new System.Windows.Forms.ComboBox();
            this.label_info = new System.Windows.Forms.Label();
            this.progressBar_Search = new System.Windows.Forms.ProgressBar();
            this.sfButton_ColumnChooser = new Syncfusion.WinForms.Controls.SfButton();
            this.toolstripitemCSV = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            this.toolstripitemPDF = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitButton_Export
            // 
            this.splitButton_Export.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.splitButton_Export.DropDownItems.Add(this.toolstripitemCSV);
            this.splitButton_Export.DropDownItems.Add(this.toolstripitemPDF);
            this.splitButton_Export.DropDownPosition = Syncfusion.Windows.Forms.Tools.Position.Top;
            this.splitButton_Export.ForeColor = System.Drawing.Color.Black;
            this.splitButton_Export.Location = new System.Drawing.Point(127, 5);
            this.splitButton_Export.MinimumSize = new System.Drawing.Size(75, 23);
            this.splitButton_Export.Name = "splitButton_Export";
            splitButtonRenderer1.SplitButton = this.splitButton_Export;
            this.splitButton_Export.Renderer = splitButtonRenderer1;
            this.splitButton_Export.ShowDropDownOnButtonClick = true;
            this.splitButton_Export.Size = new System.Drawing.Size(75, 23);
            this.splitButton_Export.TabIndex = 16;
            this.splitButton_Export.Text = "Export";
            // 
            // sfDataGrid
            // 
            this.sfDataGrid.AccessibleName = "Table";
            this.sfDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid.AutoExpandGroups = true;
            this.sfDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.tableLayoutPanel1.SetColumnSpan(this.sfDataGrid, 5);
            this.sfDataGrid.Location = new System.Drawing.Point(4, 5);
            this.sfDataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sfDataGrid.Name = "sfDataGrid";
            this.sfDataGrid.RowHeight = 21;
            this.sfDataGrid.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Extended;
            this.sfDataGrid.ShowGroupDropArea = true;
            this.sfDataGrid.Size = new System.Drawing.Size(776, 532);
            this.sfDataGrid.TabIndex = 1;
            this.sfDataGrid.Text = "sfDataGrid2";
            // 
            // sfDataPager1
            // 
            this.sfDataPager1.AccessibleName = "DataPager";
            this.sfDataPager1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataPager1.CanOverrideStyle = true;
            this.sfDataPager1.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.sfDataPager1.Location = new System.Drawing.Point(3, 546);
            this.sfDataPager1.Name = "sfDataPager1";
            this.sfDataPager1.Size = new System.Drawing.Size(370, 34);
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
            this.tableLayoutPanel1.Controls.Add(this.sfDataGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sfDataPager1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 584);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Controls.Add(this.panel_isDirty);
            this.flowLayoutPanel1.Controls.Add(this.comboBox_PageSize);
            this.flowLayoutPanel1.Controls.Add(this.sfButton_ColumnChooser);
            this.flowLayoutPanel1.Controls.Add(this.splitButton_Export);
            this.flowLayoutPanel1.Controls.Add(this.label_info);
            this.flowLayoutPanel1.Controls.Add(this.progressBar_Search);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(379, 545);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(402, 36);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // panel_isDirty
            // 
            this.panel_isDirty.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel_isDirty.Location = new System.Drawing.Point(4, 5);
            this.panel_isDirty.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_isDirty.Name = "panel_isDirty";
            this.panel_isDirty.Size = new System.Drawing.Size(12, 29);
            this.panel_isDirty.TabIndex = 13;
            // 
            // comboBox_PageSize
            // 
            this.comboBox_PageSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_PageSize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_PageSize.FormattingEnabled = true;
            this.comboBox_PageSize.ItemHeight = 17;
            this.comboBox_PageSize.Location = new System.Drawing.Point(21, 7);
            this.comboBox_PageSize.Name = "comboBox_PageSize";
            this.comboBox_PageSize.Size = new System.Drawing.Size(65, 25);
            this.comboBox_PageSize.TabIndex = 0;
            this.comboBox_PageSize.Text = "Rows:";
            // 
            // label_info
            // 
            this.label_info.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(208, 13);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(10, 13);
            this.label_info.TabIndex = 15;
            this.label_info.Text = "-";
            // 
            // progressBar_Search
            // 
            this.progressBar_Search.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.progressBar_Search.Location = new System.Drawing.Point(224, 10);
            this.progressBar_Search.Name = "progressBar_Search";
            this.progressBar_Search.Size = new System.Drawing.Size(70, 18);
            this.progressBar_Search.TabIndex = 16;
            // 
            // sfButton_ColumnChooser
            // 
            this.sfButton_ColumnChooser.AccessibleName = "Button";
            this.sfButton_ColumnChooser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sfButton_ColumnChooser.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton_ColumnChooser.Location = new System.Drawing.Point(92, 8);
            this.sfButton_ColumnChooser.Name = "sfButton_ColumnChooser";
            this.sfButton_ColumnChooser.Size = new System.Drawing.Size(29, 22);
            this.sfButton_ColumnChooser.Style.Image = global::ssGrid.Properties.Resources.Bootstrap_grid_fill_icon;
            this.sfButton_ColumnChooser.TabIndex = 1;
            // 
            // toolstripitemCSV
            // 
            this.toolstripitemCSV.Image = global::ssGrid.Properties.Resources.exc;
            this.toolstripitemCSV.Name = "toolstripitemCSV";
            this.toolstripitemCSV.Size = new System.Drawing.Size(32, 19);
            this.toolstripitemCSV.Text = "Excel";
            // 
            // toolstripitemPDF
            // 
            this.toolstripitemPDF.Image = global::ssGrid.Properties.Resources.pdf;
            this.toolstripitemPDF.Name = "toolstripitemPDF";
            this.toolstripitemPDF.Size = new System.Drawing.Size(32, 19);
            this.toolstripitemPDF.Text = "PDF";
            // 
            // ssGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ssGridView";
            this.Size = new System.Drawing.Size(784, 584);
            this.Load += new System.EventHandler(this.ssGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid;
        private Syncfusion.WinForms.DataPager.SfDataPager sfDataPager1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_isDirty;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.ProgressBar progressBar_Search;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox_PageSize;
        private Syncfusion.WinForms.Controls.SfButton sfButton_ColumnChooser;
        private Syncfusion.Windows.Forms.Tools.SplitButton splitButton_Export;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem_csv;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem_pdf;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitemCSV;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitemPDF;
    }
}
