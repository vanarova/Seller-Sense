namespace SellerSense
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
            this.btn_loadInvFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbox_URL = new System.Windows.Forms.TextBox();
            this.btn_MapViaScrapping = new System.Windows.Forms.Button();
            this.lbl_URLMappedValue = new System.Windows.Forms.Label();
            this.btn_MapViaCode = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_MapViaURLAccept = new System.Windows.Forms.Button();
            this.tbl_Inv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_InvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_Inv
            // 
            this.tbl_Inv.BackColor = System.Drawing.Color.Lavender;
            this.tbl_Inv.ColumnCount = 6;
            this.tbl_Inv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.35922F));
            this.tbl_Inv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.96602F));
            this.tbl_Inv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.41262F));
            this.tbl_Inv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.27184F));
            this.tbl_Inv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.05502F));
            this.tbl_Inv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.713936F));
            this.tbl_Inv.Controls.Add(this.grd_InvData, 0, 5);
            this.tbl_Inv.Controls.Add(this.txt_CompanyId, 3, 1);
            this.tbl_Inv.Controls.Add(this.label1, 2, 1);
            this.tbl_Inv.Controls.Add(this.selectedImgBox, 1, 0);
            this.tbl_Inv.Controls.Add(this.lbl_Code, 2, 0);
            this.tbl_Inv.Controls.Add(this.lbl_title, 3, 0);
            this.tbl_Inv.Controls.Add(this.btn_loadInvFile, 1, 1);
            this.tbl_Inv.Controls.Add(this.label5, 0, 1);
            this.tbl_Inv.Controls.Add(this.label2, 0, 2);
            this.tbl_Inv.Controls.Add(this.label3, 0, 3);
            this.tbl_Inv.Controls.Add(this.txtbox_URL, 1, 3);
            this.tbl_Inv.Controls.Add(this.btn_MapViaCode, 4, 1);
            this.tbl_Inv.Controls.Add(this.btn_MapViaScrapping, 4, 3);
            this.tbl_Inv.Controls.Add(this.label4, 2, 4);
            this.tbl_Inv.Controls.Add(this.lbl_URLMappedValue, 0, 0);
            this.tbl_Inv.Controls.Add(this.btn_MapViaURLAccept, 4, 4);
            this.tbl_Inv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_Inv.Location = new System.Drawing.Point(0, 0);
            this.tbl_Inv.Name = "tbl_Inv";
            this.tbl_Inv.RowCount = 6;
            this.tbl_Inv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.40746F));
            this.tbl_Inv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.424779F));
            this.tbl_Inv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.171934F));
            this.tbl_Inv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.321252F));
            this.tbl_Inv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.814467F));
            this.tbl_Inv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.84146F));
            this.tbl_Inv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl_Inv.Size = new System.Drawing.Size(824, 791);
            this.tbl_Inv.TabIndex = 0;
            // 
            // grd_InvData
            // 
            this.grd_InvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Inv.SetColumnSpan(this.grd_InvData, 6);
            this.grd_InvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_InvData.Location = new System.Drawing.Point(3, 296);
            this.grd_InvData.Name = "grd_InvData";
            this.grd_InvData.RowHeadersWidth = 51;
            this.grd_InvData.RowTemplate.Height = 24;
            this.grd_InvData.Size = new System.Drawing.Size(818, 492);
            this.grd_InvData.TabIndex = 0;
            this.grd_InvData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_InvData_CellEndEdit);
            // 
            // txt_CompanyId
            // 
            this.txt_CompanyId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CompanyId.Location = new System.Drawing.Point(487, 151);
            this.txt_CompanyId.Name = "txt_CompanyId";
            this.txt_CompanyId.Size = new System.Drawing.Size(194, 22);
            this.txt_CompanyId.TabIndex = 2;
            this.txt_CompanyId.TextChanged += new System.EventHandler(this.txt_CompanyId_TextChanged);
            this.txt_CompanyId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_CompanyId_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(378, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ASIN/FSN/SIN";
            // 
            // selectedImgBox
            // 
            this.selectedImgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedImgBox.Location = new System.Drawing.Point(487, 3);
            this.selectedImgBox.Name = "selectedImgBox";
            this.selectedImgBox.Size = new System.Drawing.Size(194, 139);
            this.selectedImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selectedImgBox.TabIndex = 5;
            this.selectedImgBox.TabStop = false;
            // 
            // lbl_Code
            // 
            this.lbl_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.Location = new System.Drawing.Point(687, 64);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(101, 16);
            this.lbl_Code.TabIndex = 6;
            this.lbl_Code.Text = "-";
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(794, 64);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(27, 16);
            this.lbl_title.TabIndex = 7;
            this.lbl_title.Text = "-";
            // 
            // btn_loadInvFile
            // 
            this.btn_loadInvFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_loadInvFile.Location = new System.Drawing.Point(179, 148);
            this.btn_loadInvFile.Name = "btn_loadInvFile";
            this.btn_loadInvFile.Size = new System.Drawing.Size(175, 29);
            this.btn_loadInvFile.TabIndex = 8;
            this.btn_loadInvFile.Text = "Load";
            this.btn_loadInvFile.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Map via unique code";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 31);
            this.label2.TabIndex = 13;
            this.label2.Text = "or";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Map via URL";
            // 
            // txtbox_URL
            // 
            this.txtbox_URL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_Inv.SetColumnSpan(this.txtbox_URL, 3);
            this.txtbox_URL.Location = new System.Drawing.Point(179, 223);
            this.txtbox_URL.Name = "txtbox_URL";
            this.txtbox_URL.Size = new System.Drawing.Size(502, 22);
            this.txtbox_URL.TabIndex = 15;
            // 
            // btn_MapViaScrapping
            // 
            this.btn_MapViaScrapping.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_MapViaScrapping.Location = new System.Drawing.Point(687, 220);
            this.btn_MapViaScrapping.Name = "btn_MapViaScrapping";
            this.btn_MapViaScrapping.Size = new System.Drawing.Size(101, 27);
            this.btn_MapViaScrapping.TabIndex = 16;
            this.btn_MapViaScrapping.Text = "Go";
            this.btn_MapViaScrapping.UseVisualStyleBackColor = true;
            this.btn_MapViaScrapping.Click += new System.EventHandler(this.btn_MapViaScrapping_Click);
            // 
            // lbl_URLMappedValue
            // 
            this.lbl_URLMappedValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_URLMappedValue.AutoSize = true;
            this.tbl_Inv.SetColumnSpan(this.lbl_URLMappedValue, 3);
            this.lbl_URLMappedValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_URLMappedValue.Location = new System.Drawing.Point(3, 62);
            this.lbl_URLMappedValue.Name = "lbl_URLMappedValue";
            this.lbl_URLMappedValue.Size = new System.Drawing.Size(15, 20);
            this.lbl_URLMappedValue.TabIndex = 17;
            this.lbl_URLMappedValue.Text = "-";
            // 
            // btn_MapViaCode
            // 
            this.btn_MapViaCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_MapViaCode.Location = new System.Drawing.Point(687, 149);
            this.btn_MapViaCode.Name = "btn_MapViaCode";
            this.btn_MapViaCode.Size = new System.Drawing.Size(101, 27);
            this.btn_MapViaCode.TabIndex = 18;
            this.btn_MapViaCode.Text = "Map";
            this.btn_MapViaCode.UseVisualStyleBackColor = true;
            this.btn_MapViaCode.Click += new System.EventHandler(this.btn_MapViaCode_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Product Code: ";
            // 
            // btn_MapViaURLAccept
            // 
            this.btn_MapViaURLAccept.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_MapViaURLAccept.Location = new System.Drawing.Point(687, 260);
            this.btn_MapViaURLAccept.Name = "btn_MapViaURLAccept";
            this.btn_MapViaURLAccept.Size = new System.Drawing.Size(101, 27);
            this.btn_MapViaURLAccept.TabIndex = 20;
            this.btn_MapViaURLAccept.Text = "Map";
            this.btn_MapViaURLAccept.UseVisualStyleBackColor = true;
            this.btn_MapViaURLAccept.Click += new System.EventHandler(this.btn_MapViaURLAccept_Click);
            // 
            // InvFiller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(824, 791);
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
        private System.Windows.Forms.Button btn_loadInvFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbox_URL;
        private System.Windows.Forms.Label lbl_URLMappedValue;
        private System.Windows.Forms.Button btn_MapViaCode;
        private System.Windows.Forms.Button btn_MapViaScrapping;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_MapViaURLAccept;
    }
}