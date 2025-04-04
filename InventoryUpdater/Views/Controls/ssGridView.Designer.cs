﻿namespace SellerSense.Controls
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.dataGridView_data = new System.Windows.Forms.DataGridView();
            this.progressBar_Search = new System.Windows.Forms.ProgressBar();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_First = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Code = new System.Windows.Forms.TextBox();
            this.button_Last = new System.Windows.Forms.Button();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.button_Back = new System.Windows.Forms.Button();
            this.label_PageNumbers = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.button_Refresh, 10, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_data, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar_Search, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Next, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_First, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Code, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Last, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Title, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Back, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_PageNumbers, 7, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(936, 630);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Refresh.Location = new System.Drawing.Point(777, 589);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(2);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(53, 39);
            this.button_Refresh.TabIndex = 10;
            this.button_Refresh.Text = "🔄";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // dataGridView_data
            // 
            this.dataGridView_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView_data, 11);
            this.dataGridView_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_data.Location = new System.Drawing.Point(2, 2);
            this.dataGridView_data.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_data.Name = "dataGridView_data";
            this.dataGridView_data.RowHeadersWidth = 82;
            this.dataGridView_data.RowTemplate.Height = 33;
            this.dataGridView_data.Size = new System.Drawing.Size(932, 583);
            this.dataGridView_data.TabIndex = 2;
            this.dataGridView_data.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_data_CellFormatting);
            this.dataGridView_data.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_data_DataBindingComplete);
            // 
            // progressBar_Search
            // 
            this.progressBar_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Search.Location = new System.Drawing.Point(2, 599);
            this.progressBar_Search.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar_Search.Name = "progressBar_Search";
            this.progressBar_Search.Size = new System.Drawing.Size(100, 18);
            this.progressBar_Search.TabIndex = 3;
            // 
            // button_Next
            // 
            this.button_Next.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Next.Location = new System.Drawing.Point(621, 589);
            this.button_Next.Margin = new System.Windows.Forms.Padding(2);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(74, 39);
            this.button_Next.TabIndex = 1;
            this.button_Next.Text = "Next >";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // button_First
            // 
            this.button_First.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_First.Location = new System.Drawing.Point(423, 589);
            this.button_First.Margin = new System.Windows.Forms.Padding(2);
            this.button_First.Name = "button_First";
            this.button_First.Size = new System.Drawing.Size(74, 39);
            this.button_First.TabIndex = 5;
            this.button_First.Text = "<< First";
            this.button_First.UseVisualStyleBackColor = true;
            this.button_First.Click += new System.EventHandler(this.button_First_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 600);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search :";
            // 
            // textBox_Code
            // 
            this.textBox_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Code.ForeColor = System.Drawing.Color.DimGray;
            this.textBox_Code.Location = new System.Drawing.Point(179, 597);
            this.textBox_Code.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.Size = new System.Drawing.Size(101, 22);
            this.textBox_Code.TabIndex = 7;
            this.textBox_Code.Text = "Code";
            this.textBox_Code.TextChanged += new System.EventHandler(this.textBox_Code_TextChanged);
            this.textBox_Code.Enter += new System.EventHandler(this.textBox_Code_Enter);
            this.textBox_Code.Leave += new System.EventHandler(this.textBox_Code_Leave);
            // 
            // button_Last
            // 
            this.button_Last.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Last.Location = new System.Drawing.Point(699, 589);
            this.button_Last.Margin = new System.Windows.Forms.Padding(2);
            this.button_Last.Name = "button_Last";
            this.button_Last.Size = new System.Drawing.Size(74, 39);
            this.button_Last.TabIndex = 4;
            this.button_Last.Text = "Last >>";
            this.button_Last.UseVisualStyleBackColor = true;
            this.button_Last.Click += new System.EventHandler(this.button_Last_Click);
            // 
            // textBox_Title
            // 
            this.textBox_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Title.ForeColor = System.Drawing.Color.DimGray;
            this.textBox_Title.Location = new System.Drawing.Point(284, 597);
            this.textBox_Title.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(135, 22);
            this.textBox_Title.TabIndex = 8;
            this.textBox_Title.Text = "Tag";
            this.textBox_Title.TextChanged += new System.EventHandler(this.textBox_Title_TextChanged);
            this.textBox_Title.Enter += new System.EventHandler(this.textBox_Title_Enter);
            this.textBox_Title.Leave += new System.EventHandler(this.textBox_Title_Leave);
            // 
            // button_Back
            // 
            this.button_Back.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_Back.Location = new System.Drawing.Point(501, 589);
            this.button_Back.Margin = new System.Windows.Forms.Padding(2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(74, 39);
            this.button_Back.TabIndex = 0;
            this.button_Back.Text = "< Back";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // label_PageNumbers
            // 
            this.label_PageNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PageNumbers.AutoSize = true;
            this.label_PageNumbers.Location = new System.Drawing.Point(579, 600);
            this.label_PageNumbers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PageNumbers.Name = "label_PageNumbers";
            this.label_PageNumbers.Size = new System.Drawing.Size(38, 16);
            this.label_PageNumbers.TabIndex = 9;
            this.label_PageNumbers.Text = "0 of 0";
            // 
            // ssGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ssGridView";
            this.Size = new System.Drawing.Size(936, 630);
            this.Load += new System.EventHandler(this.ssGridView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.DataGridView dataGridView_data;
        private System.Windows.Forms.ProgressBar progressBar_Search;
        private System.Windows.Forms.Button button_Last;
        private System.Windows.Forms.Button button_First;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Code;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.Label label_PageNumbers;
        private System.Windows.Forms.Button button_Refresh;
    }
}
