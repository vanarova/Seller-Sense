namespace InventoryUpdater
{
    partial class InvFiller
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
            this.tbl_Inv = new System.Windows.Forms.TableLayoutPanel();
            this.grd_InvData = new System.Windows.Forms.DataGridView();
            this.txt_CompanyId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedImgBox = new System.Windows.Forms.PictureBox();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.tbl_Inv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_InvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_Inv
            // 
            this.tbl_Inv.ColumnCount = 5;
            this.tbl_Inv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.916432F));
            this.tbl_Inv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.41226F));
            this.tbl_Inv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.37047F));
            this.tbl_Inv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.91644F));
            this.tbl_Inv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.3844F));
            this.tbl_Inv.Controls.Add(this.grd_InvData, 0, 2);
            this.tbl_Inv.Controls.Add(this.txt_CompanyId, 3, 1);
            this.tbl_Inv.Controls.Add(this.label1, 2, 1);
            this.tbl_Inv.Controls.Add(this.selectedImgBox, 1, 0);
            this.tbl_Inv.Controls.Add(this.lbl_Code, 2, 0);
            this.tbl_Inv.Controls.Add(this.lbl_title, 3, 0);
            this.tbl_Inv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_Inv.Location = new System.Drawing.Point(0, 0);
            this.tbl_Inv.Name = "tbl_Inv";
            this.tbl_Inv.RowCount = 3;
            this.tbl_Inv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.22222F));
            this.tbl_Inv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.111111F));
            this.tbl_Inv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.52778F));
            this.tbl_Inv.Size = new System.Drawing.Size(600, 720);
            this.tbl_Inv.TabIndex = 0;
            // 
            // grd_InvData
            // 
            this.grd_InvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Inv.SetColumnSpan(this.grd_InvData, 5);
            this.grd_InvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_InvData.Location = new System.Drawing.Point(3, 171);
            this.grd_InvData.Name = "grd_InvData";
            this.grd_InvData.RowHeadersWidth = 51;
            this.grd_InvData.RowTemplate.Height = 24;
            this.grd_InvData.Size = new System.Drawing.Size(594, 546);
            this.grd_InvData.TabIndex = 0;
            this.grd_InvData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_InvData_CellEndEdit);
            // 
            // txt_CompanyId
            // 
            this.txt_CompanyId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CompanyId.Location = new System.Drawing.Point(312, 135);
            this.txt_CompanyId.Name = "txt_CompanyId";
            this.txt_CompanyId.Size = new System.Drawing.Size(173, 22);
            this.txt_CompanyId.TabIndex = 2;
            this.txt_CompanyId.TextChanged += new System.EventHandler(this.txt_CompanyId_TextChanged);
            this.txt_CompanyId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_CompanyId_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "ASIN/FSN/SIN";
            // 
            // selectedImgBox
            // 
            this.selectedImgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedImgBox.Location = new System.Drawing.Point(62, 3);
            this.selectedImgBox.Name = "selectedImgBox";
            this.selectedImgBox.Size = new System.Drawing.Size(164, 118);
            this.selectedImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selectedImgBox.TabIndex = 5;
            this.selectedImgBox.TabStop = false;
            // 
            // lbl_Code
            // 
            this.lbl_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.Location = new System.Drawing.Point(232, 54);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(74, 16);
            this.lbl_Code.TabIndex = 6;
            this.lbl_Code.Text = "-";
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(312, 54);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(173, 16);
            this.lbl_title.TabIndex = 7;
            this.lbl_title.Text = "-";
            // 
            // InvFiller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 720);
            this.Controls.Add(this.tbl_Inv);
            this.Name = "InvFiller";
            this.Text = "Search Inventory File";
            this.Load += new System.EventHandler(this.InvFiller_Load);
            this.tbl_Inv.ResumeLayout(false);
            this.tbl_Inv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_InvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImgBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl_Inv;
        private System.Windows.Forms.DataGridView grd_InvData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_CompanyId;
        private System.Windows.Forms.PictureBox selectedImgBox;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.Label lbl_title;
    }
}