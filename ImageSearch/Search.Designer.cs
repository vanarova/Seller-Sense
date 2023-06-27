namespace ImageSearch
{
    partial class Search
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picBoxSrc = new System.Windows.Forms.PictureBox();
            this.btn_pasteImg = new System.Windows.Forms.Button();
            this.dataGridView_imgSearchResults = new System.Windows.Forms.DataGridView();
            this.btn_close = new System.Windows.Forms.Button();
            this.progressBar_imgSearch = new System.Windows.Forms.ProgressBar();
            this.numericUpDown_threshold = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_imgSearchResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_threshold)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.90909F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.875F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.840909F));
            this.tableLayoutPanel1.Controls.Add(this.picBoxSrc, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_imgSearchResults, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_pasteImg, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.progressBar_imgSearch, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn_close, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_threshold, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.976906F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.79562F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.81044F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.405218F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.83645F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.175366F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 490);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // picBoxSrc
            // 
            this.picBoxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxSrc.InitialImage = global::ImageSearch.Properties.Resources.pasteImage;
            this.picBoxSrc.Location = new System.Drawing.Point(23, 17);
            this.picBoxSrc.Name = "picBoxSrc";
            this.picBoxSrc.Size = new System.Drawing.Size(281, 262);
            this.picBoxSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxSrc.TabIndex = 0;
            this.picBoxSrc.TabStop = false;
            // 
            // btn_pasteImg
            // 
            this.btn_pasteImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_pasteImg.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pasteImg.Location = new System.Drawing.Point(23, 285);
            this.btn_pasteImg.Name = "btn_pasteImg";
            this.btn_pasteImg.Size = new System.Drawing.Size(281, 57);
            this.btn_pasteImg.TabIndex = 2;
            this.btn_pasteImg.Text = "Paste Image && Search";
            this.btn_pasteImg.UseVisualStyleBackColor = true;
            this.btn_pasteImg.Click += new System.EventHandler(this.btn_pasteImg_Click);
            // 
            // dataGridView_imgSearchResults
            // 
            this.dataGridView_imgSearchResults.AllowUserToAddRows = false;
            this.dataGridView_imgSearchResults.AllowUserToDeleteRows = false;
            this.dataGridView_imgSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView_imgSearchResults, 2);
            this.dataGridView_imgSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_imgSearchResults.Location = new System.Drawing.Point(310, 17);
            this.dataGridView_imgSearchResults.Name = "dataGridView_imgSearchResults";
            this.dataGridView_imgSearchResults.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView_imgSearchResults, 2);
            this.dataGridView_imgSearchResults.RowTemplate.Height = 24;
            this.dataGridView_imgSearchResults.Size = new System.Drawing.Size(463, 354);
            this.dataGridView_imgSearchResults.TabIndex = 3;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(652, 423);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(121, 47);
            this.btn_close.TabIndex = 4;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // progressBar_imgSearch
            // 
            this.progressBar_imgSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_imgSearch.Location = new System.Drawing.Point(23, 385);
            this.progressBar_imgSearch.MarqueeAnimationSpeed = 20;
            this.progressBar_imgSearch.Name = "progressBar_imgSearch";
            this.progressBar_imgSearch.Size = new System.Drawing.Size(281, 23);
            this.progressBar_imgSearch.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar_imgSearch.TabIndex = 5;
            this.progressBar_imgSearch.Visible = false;
            // 
            // numericUpDown_threshold
            // 
            this.numericUpDown_threshold.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericUpDown_threshold.DecimalPlaces = 1;
            this.numericUpDown_threshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_threshold.Location = new System.Drawing.Point(682, 386);
            this.numericUpDown_threshold.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.numericUpDown_threshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_threshold.Name = "numericUpDown_threshold";
            this.numericUpDown_threshold.Size = new System.Drawing.Size(91, 22);
            this.numericUpDown_threshold.TabIndex = 6;
            this.numericUpDown_threshold.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(23, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = ".";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Adjust threshold 0-1 (Higher value for strict search) : ";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Search";
            this.Text = "Image Search by Image";
            this.Load += new System.EventHandler(this.Search_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_imgSearchResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_threshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picBoxSrc;
        private System.Windows.Forms.Button btn_pasteImg;
        private System.Windows.Forms.DataGridView dataGridView_imgSearchResults;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ProgressBar progressBar_imgSearch;
        private System.Windows.Forms.NumericUpDown numericUpDown_threshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}