namespace SellerSense.Views.Products
{
    partial class ExportProducts
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
            this.checkBox_ExportPrimaryImages = new System.Windows.Forms.CheckBox();
            this.checkBox_ExportSecondaryImages = new System.Windows.Forms.CheckBox();
            this.button_ExportCSV = new System.Windows.Forms.Button();
            this.button_ExportPDF = new System.Windows.Forms.Button();
            this.button_ExportToTelegram = new System.Windows.Forms.Button();
            this.checkBox_ExportPrices = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.230848F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.86415F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.97336F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.06326F));
            this.tableLayoutPanel1.Controls.Add(this.checkBox_ExportPrimaryImages, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_ExportSecondaryImages, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_ExportCSV, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button_ExportPDF, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.button_ExportToTelegram, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_ExportPrices, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.74926F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.14159F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(842, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBox_ExportPrimaryImages
            // 
            this.checkBox_ExportPrimaryImages.AutoSize = true;
            this.checkBox_ExportPrimaryImages.Checked = true;
            this.checkBox_ExportPrimaryImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBox_ExportPrimaryImages, 2);
            this.checkBox_ExportPrimaryImages.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ExportPrimaryImages.Location = new System.Drawing.Point(55, 69);
            this.checkBox_ExportPrimaryImages.Name = "checkBox_ExportPrimaryImages";
            this.checkBox_ExportPrimaryImages.Size = new System.Drawing.Size(324, 41);
            this.checkBox_ExportPrimaryImages.TabIndex = 3;
            this.checkBox_ExportPrimaryImages.Text = "Include Primary Images";
            this.checkBox_ExportPrimaryImages.UseVisualStyleBackColor = true;
            // 
            // checkBox_ExportSecondaryImages
            // 
            this.checkBox_ExportSecondaryImages.AutoSize = true;
            this.checkBox_ExportSecondaryImages.Checked = true;
            this.checkBox_ExportSecondaryImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBox_ExportSecondaryImages, 2);
            this.checkBox_ExportSecondaryImages.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ExportSecondaryImages.Location = new System.Drawing.Point(55, 150);
            this.checkBox_ExportSecondaryImages.Name = "checkBox_ExportSecondaryImages";
            this.checkBox_ExportSecondaryImages.Size = new System.Drawing.Size(357, 41);
            this.checkBox_ExportSecondaryImages.TabIndex = 4;
            this.checkBox_ExportSecondaryImages.Text = "Include Secondary Images";
            this.checkBox_ExportSecondaryImages.UseVisualStyleBackColor = true;
            // 
            // button_ExportCSV
            // 
            this.button_ExportCSV.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ExportCSV.Location = new System.Drawing.Point(55, 337);
            this.button_ExportCSV.Name = "button_ExportCSV";
            this.button_ExportCSV.Size = new System.Drawing.Size(219, 73);
            this.button_ExportCSV.TabIndex = 1;
            this.button_ExportCSV.Text = "Export CSV";
            this.button_ExportCSV.UseVisualStyleBackColor = true;
            this.button_ExportCSV.Click += new System.EventHandler(this.button_ExportToCSV_Click);
            // 
            // button_ExportPDF
            // 
            this.button_ExportPDF.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ExportPDF.Location = new System.Drawing.Point(280, 337);
            this.button_ExportPDF.Name = "button_ExportPDF";
            this.button_ExportPDF.Size = new System.Drawing.Size(195, 73);
            this.button_ExportPDF.TabIndex = 0;
            this.button_ExportPDF.Text = "Export PDF";
            this.button_ExportPDF.UseVisualStyleBackColor = true;
            this.button_ExportPDF.Click += new System.EventHandler(this.button_ExportPDF_Click);
            // 
            // button_ExportToTelegram
            // 
            this.button_ExportToTelegram.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ExportToTelegram.Location = new System.Drawing.Point(481, 337);
            this.button_ExportToTelegram.Name = "button_ExportToTelegram";
            this.button_ExportToTelegram.Size = new System.Drawing.Size(295, 73);
            this.button_ExportToTelegram.TabIndex = 2;
            this.button_ExportToTelegram.Text = "Export To Telegram";
            this.button_ExportToTelegram.UseVisualStyleBackColor = true;
            this.button_ExportToTelegram.Click += new System.EventHandler(this.button_ExportToTelegram_Click);
            // 
            // checkBox_ExportPrices
            // 
            this.checkBox_ExportPrices.AutoSize = true;
            this.checkBox_ExportPrices.Checked = true;
            this.checkBox_ExportPrices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBox_ExportPrices, 2);
            this.checkBox_ExportPrices.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ExportPrices.Location = new System.Drawing.Point(55, 232);
            this.checkBox_ExportPrices.Name = "checkBox_ExportPrices";
            this.checkBox_ExportPrices.Size = new System.Drawing.Size(210, 41);
            this.checkBox_ExportPrices.TabIndex = 5;
            this.checkBox_ExportPrices.Text = "Include Prices";
            this.checkBox_ExportPrices.UseVisualStyleBackColor = true;
            // 
            // ExportProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportProducts";
            this.Text = "Export Products";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_ExportPDF;
        private System.Windows.Forms.Button button_ExportCSV;
        private System.Windows.Forms.Button button_ExportToTelegram;
        private System.Windows.Forms.CheckBox checkBox_ExportPrimaryImages;
        private System.Windows.Forms.CheckBox checkBox_ExportSecondaryImages;
        private System.Windows.Forms.CheckBox checkBox_ExportPrices;
    }
}