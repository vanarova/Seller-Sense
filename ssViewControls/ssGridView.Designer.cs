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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.button_Last = new System.Windows.Forms.Button();
            this.textBox_Tag = new System.Windows.Forms.TextBox();
            this.button_Back = new System.Windows.Forms.Button();
            this.label_PageNumbers = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_isDirty = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 12;
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
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Title, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Last, 10, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Tag, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Back, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_PageNumbers, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_isDirty, 0, 1);
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
            this.button_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_Refresh.Location = new System.Drawing.Point(770, 583);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(2);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(53, 45);
            this.button_Refresh.TabIndex = 10;
            this.button_Refresh.Text = "🔄";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // dataGridView_data
            // 
            this.dataGridView_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView_data, 12);
            this.dataGridView_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_data.Location = new System.Drawing.Point(2, 2);
            this.dataGridView_data.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_data.Name = "dataGridView_data";
            this.dataGridView_data.RowHeadersWidth = 82;
            this.dataGridView_data.RowTemplate.Height = 33;
            this.dataGridView_data.Size = new System.Drawing.Size(932, 577);
            this.dataGridView_data.TabIndex = 2;
            this.dataGridView_data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_data_CellContentClick);
            this.dataGridView_data.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_data_CellFormatting);
            // 
            // progressBar_Search
            // 
            this.progressBar_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Search.Location = new System.Drawing.Point(28, 583);
            this.progressBar_Search.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar_Search.Name = "progressBar_Search";
            this.progressBar_Search.Size = new System.Drawing.Size(68, 45);
            this.progressBar_Search.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar_Search.TabIndex = 3;
            // 
            // button_Next
            // 
            this.button_Next.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Next.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button_Next.Location = new System.Drawing.Point(669, 586);
            this.button_Next.Margin = new System.Windows.Forms.Padding(2);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(38, 39);
            this.button_Next.TabIndex = 1;
            this.button_Next.Text = "⮞";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // button_First
            // 
            this.button_First.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_First.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button_First.Location = new System.Drawing.Point(516, 586);
            this.button_First.Margin = new System.Windows.Forms.Padding(2);
            this.button_First.Name = "button_First";
            this.button_First.Size = new System.Drawing.Size(57, 39);
            this.button_First.TabIndex = 5;
            this.button_First.Text = "⮜⮜";
            this.button_First.UseVisualStyleBackColor = true;
            this.button_First.Click += new System.EventHandler(this.button_First_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 595);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search :";
            // 
            // textBox_Title
            // 
            this.textBox_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Title.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Title.ForeColor = System.Drawing.Color.DimGray;
            this.textBox_Title.Location = new System.Drawing.Point(309, 590);
            this.textBox_Title.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(101, 30);
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
            this.button_Last.Location = new System.Drawing.Point(711, 586);
            this.button_Last.Margin = new System.Windows.Forms.Padding(2);
            this.button_Last.Name = "button_Last";
            this.button_Last.Size = new System.Drawing.Size(55, 39);
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
            this.textBox_Tag.Location = new System.Drawing.Point(414, 590);
            this.textBox_Tag.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Tag.Name = "textBox_Tag";
            this.textBox_Tag.Size = new System.Drawing.Size(98, 30);
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
            this.button_Back.Location = new System.Drawing.Point(577, 586);
            this.button_Back.Margin = new System.Windows.Forms.Padding(2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(37, 39);
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
            this.label_PageNumbers.Location = new System.Drawing.Point(618, 595);
            this.label_PageNumbers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PageNumbers.Name = "label_PageNumbers";
            this.label_PageNumbers.Size = new System.Drawing.Size(47, 20);
            this.label_PageNumbers.TabIndex = 9;
            this.label_PageNumbers.Text = "0 of 0";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.Location = new System.Drawing.Point(100, 583);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 45);
            this.button1.TabIndex = 11;
            this.button1.Text = "Image Search 🖼";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel_isDirty
            // 
            this.panel_isDirty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel_isDirty.Location = new System.Drawing.Point(3, 584);
            this.panel_isDirty.Name = "panel_isDirty";
            this.panel_isDirty.Size = new System.Drawing.Size(20, 43);
            this.panel_isDirty.TabIndex = 12;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.TextBox textBox_Tag;
        private System.Windows.Forms.Label label_PageNumbers;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_isDirty;
    }
}
