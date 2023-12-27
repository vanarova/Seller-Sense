namespace ssViewControls
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
            this.label_search = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.button_Last = new System.Windows.Forms.Button();
            this.textBox_Tag = new System.Windows.Forms.TextBox();
            this.button_Back = new System.Windows.Forms.Button();
            this.label_PageNumbers = new System.Windows.Forms.Label();
            this.button_ActionSelected = new System.Windows.Forms.Button();
            this.panel_isDirty = new System.Windows.Forms.Panel();
            this.label_info = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 13;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.button_Refresh, 11, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_data, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar_Search, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Next, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_First, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_search, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Title, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Last, 10, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Tag, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Back, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_PageNumbers, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_ActionSelected, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_isDirty, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_info, 12, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(702, 512);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_Refresh.Location = new System.Drawing.Point(593, 473);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(2);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(40, 37);
            this.button_Refresh.TabIndex = 10;
            this.button_Refresh.Text = "🔄";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // dataGridView_data
            // 
            this.dataGridView_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView_data, 13);
            this.dataGridView_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_data.Location = new System.Drawing.Point(2, 2);
            this.dataGridView_data.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_data.Name = "dataGridView_data";
            this.dataGridView_data.RowHeadersWidth = 82;
            this.dataGridView_data.RowTemplate.Height = 33;
            this.dataGridView_data.Size = new System.Drawing.Size(699, 467);
            this.dataGridView_data.TabIndex = 2;
            this.dataGridView_data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_data_CellClick);
            this.dataGridView_data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_data_CellContentClick);
            this.dataGridView_data.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_data_CellEnter);
            this.dataGridView_data.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_data_CellFormatting);
            this.dataGridView_data.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_data_CellMouseDoubleClick);
            this.dataGridView_data.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_data_CellValidated);
            this.dataGridView_data.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_data_CellValueChanged);
            this.dataGridView_data.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_data_DataBindingComplete);
            this.dataGridView_data.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_data_KeyDown);
            // 
            // progressBar_Search
            // 
            this.progressBar_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Search.Location = new System.Drawing.Point(21, 473);
            this.progressBar_Search.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar_Search.Name = "progressBar_Search";
            this.progressBar_Search.Size = new System.Drawing.Size(51, 37);
            this.progressBar_Search.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar_Search.TabIndex = 3;
            // 
            // button_Next
            // 
            this.button_Next.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Next.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button_Next.Location = new System.Drawing.Point(516, 475);
            this.button_Next.Margin = new System.Windows.Forms.Padding(2);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(28, 32);
            this.button_Next.TabIndex = 1;
            this.button_Next.Text = "⮞";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // button_First
            // 
            this.button_First.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_First.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button_First.Location = new System.Drawing.Point(397, 475);
            this.button_First.Margin = new System.Windows.Forms.Padding(2);
            this.button_First.Name = "button_First";
            this.button_First.Size = new System.Drawing.Size(43, 32);
            this.button_First.TabIndex = 5;
            this.button_First.Text = "⮜⮜";
            this.button_First.UseVisualStyleBackColor = true;
            this.button_First.Click += new System.EventHandler(this.button_First_Click);
            // 
            // label_search
            // 
            this.label_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_search.AutoSize = true;
            this.label_search.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_search.Location = new System.Drawing.Point(186, 484);
            this.label_search.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_search.Name = "label_search";
            this.label_search.Size = new System.Drawing.Size(48, 15);
            this.label_search.TabIndex = 6;
            this.label_search.Text = "Search :";
            // 
            // textBox_Title
            // 
            this.textBox_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Title.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Title.ForeColor = System.Drawing.Color.DimGray;
            this.textBox_Title.Location = new System.Drawing.Point(238, 478);
            this.textBox_Title.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(77, 26);
            this.textBox_Title.TabIndex = 7;
            this.textBox_Title.Text = "Title";
            this.textBox_Title.TextChanged += new System.EventHandler(this.textBox_Title_TextChanged);
            this.textBox_Title.Enter += new System.EventHandler(this.textBox_Code_Enter);
            this.textBox_Title.Leave += new System.EventHandler(this.textBox_Code_Leave);
            // 
            // button_Last
            // 
            this.button_Last.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Last.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button_Last.Location = new System.Drawing.Point(548, 475);
            this.button_Last.Margin = new System.Windows.Forms.Padding(2);
            this.button_Last.Name = "button_Last";
            this.button_Last.Size = new System.Drawing.Size(41, 32);
            this.button_Last.TabIndex = 4;
            this.button_Last.Text = "⮞⮞";
            this.button_Last.UseVisualStyleBackColor = true;
            this.button_Last.Click += new System.EventHandler(this.button_Last_Click);
            // 
            // textBox_Tag
            // 
            this.textBox_Tag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Tag.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Tag.ForeColor = System.Drawing.Color.DimGray;
            this.textBox_Tag.Location = new System.Drawing.Point(319, 478);
            this.textBox_Tag.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Tag.Name = "textBox_Tag";
            this.textBox_Tag.Size = new System.Drawing.Size(74, 26);
            this.textBox_Tag.TabIndex = 8;
            this.textBox_Tag.Text = "Tag";
            this.textBox_Tag.TextChanged += new System.EventHandler(this.textBox_Tag_TextChanged);
            this.textBox_Tag.Enter += new System.EventHandler(this.textBox_Title_Enter);
            this.textBox_Tag.Leave += new System.EventHandler(this.textBox_Title_Leave);
            // 
            // button_Back
            // 
            this.button_Back.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_Back.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button_Back.Location = new System.Drawing.Point(444, 475);
            this.button_Back.Margin = new System.Windows.Forms.Padding(2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(28, 32);
            this.button_Back.TabIndex = 0;
            this.button_Back.Text = "⮜";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // label_PageNumbers
            // 
            this.label_PageNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PageNumbers.AutoSize = true;
            this.label_PageNumbers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PageNumbers.Location = new System.Drawing.Point(476, 484);
            this.label_PageNumbers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PageNumbers.Name = "label_PageNumbers";
            this.label_PageNumbers.Size = new System.Drawing.Size(36, 15);
            this.label_PageNumbers.TabIndex = 9;
            this.label_PageNumbers.Text = "0 of 0";
            // 
            // button_ActionSelected
            // 
            this.button_ActionSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ActionSelected.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button_ActionSelected.Location = new System.Drawing.Point(76, 473);
            this.button_ActionSelected.Margin = new System.Windows.Forms.Padding(2);
            this.button_ActionSelected.Name = "button_ActionSelected";
            this.button_ActionSelected.Size = new System.Drawing.Size(106, 37);
            this.button_ActionSelected.TabIndex = 11;
            this.button_ActionSelected.Text = "0 Selected ⇱";
            this.button_ActionSelected.UseVisualStyleBackColor = true;
            this.button_ActionSelected.Click += new System.EventHandler(this.button_ActionSelected_Click);
            // 
            // panel_isDirty
            // 
            this.panel_isDirty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel_isDirty.Location = new System.Drawing.Point(2, 474);
            this.panel_isDirty.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_isDirty.Name = "panel_isDirty";
            this.panel_isDirty.Size = new System.Drawing.Size(15, 35);
            this.panel_isDirty.TabIndex = 12;
            // 
            // label_info
            // 
            this.label_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(638, 485);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(62, 13);
            this.label_info.TabIndex = 13;
            this.label_info.Text = "-";
            // 
            // ssGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ssGridView";
            this.Size = new System.Drawing.Size(702, 512);
            this.Load += new System.EventHandler(this.ssGridView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).EndInit();
            this.ResumeLayout(false);

        }

        private void DataGridView_data_GotFocus(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.DataGridView dataGridView_data;
        private System.Windows.Forms.ProgressBar progressBar_Search;
        private System.Windows.Forms.Button button_Last;
        private System.Windows.Forms.Button button_First;
        private System.Windows.Forms.Label label_search;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.TextBox textBox_Tag;
        private System.Windows.Forms.Label label_PageNumbers;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Button button_ActionSelected;
        private System.Windows.Forms.Panel panel_isDirty;
        private System.Windows.Forms.Label label_info;
    }
}
