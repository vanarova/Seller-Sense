namespace SellerSense.Controls
{
    partial class ssGridView
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
            this.dataGridView_data = new System.Windows.Forms.DataGridView();
            this.progressBar_Search = new System.Windows.Forms.ProgressBar();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.button_First = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Code = new System.Windows.Forms.TextBox();
            this.button_Last = new System.Windows.Forms.Button();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_data, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar_Search, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Next, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_First, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Code, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Last, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Title, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Back, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 7, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1404, 985);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView_data
            // 
            this.dataGridView_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView_data, 10);
            this.dataGridView_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_data.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_data.Name = "dataGridView_data";
            this.dataGridView_data.RowHeadersWidth = 82;
            this.dataGridView_data.RowTemplate.Height = 33;
            this.dataGridView_data.Size = new System.Drawing.Size(1398, 912);
            this.dataGridView_data.TabIndex = 2;
            // 
            // progressBar_Search
            // 
            this.progressBar_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Search.Location = new System.Drawing.Point(3, 937);
            this.progressBar_Search.Name = "progressBar_Search";
            this.progressBar_Search.Size = new System.Drawing.Size(150, 28);
            this.progressBar_Search.TabIndex = 3;
            // 
            // button_Next
            // 
            this.button_Next.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Next.Location = new System.Drawing.Point(945, 921);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(111, 61);
            this.button_Next.TabIndex = 1;
            this.button_Next.Text = "Next >";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // button_Back
            // 
            this.button_Back.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_Back.Location = new System.Drawing.Point(756, 921);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(111, 61);
            this.button_Back.TabIndex = 0;
            this.button_Back.Text = "< Back";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // button_First
            // 
            this.button_First.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_First.Location = new System.Drawing.Point(639, 921);
            this.button_First.Name = "button_First";
            this.button_First.Size = new System.Drawing.Size(111, 61);
            this.button_First.TabIndex = 5;
            this.button_First.Text = "<< First";
            this.button_First.UseVisualStyleBackColor = true;
            this.button_First.Click += new System.EventHandler(this.button_First_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 939);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search :";
            // 
            // textBox_Code
            // 
            this.textBox_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Code.Location = new System.Drawing.Point(277, 936);
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.Size = new System.Drawing.Size(150, 31);
            this.textBox_Code.TabIndex = 7;
            this.textBox_Code.Text = "Code";
            // 
            // button_Last
            // 
            this.button_Last.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Last.Location = new System.Drawing.Point(1062, 921);
            this.button_Last.Name = "button_Last";
            this.button_Last.Size = new System.Drawing.Size(111, 61);
            this.button_Last.TabIndex = 4;
            this.button_Last.Text = "Last >>";
            this.button_Last.UseVisualStyleBackColor = true;
            this.button_Last.Click += new System.EventHandler(this.button_Last_Click);
            // 
            // textBox_Title
            // 
            this.textBox_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Title.Location = new System.Drawing.Point(433, 936);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(200, 31);
            this.textBox_Title.TabIndex = 8;
            this.textBox_Title.Text = "Title/Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(873, 939);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "0 of 0";
            // 
            // ssGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ssGridView";
            this.Size = new System.Drawing.Size(1404, 985);
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
        private System.Windows.Forms.Label label2;
    }
}
