namespace SellerSense.Views
{
    partial class AddProduct
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
            this.propertyGrid_AddProduct = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_editImages = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkBox_markForDeletion = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid_AddProduct
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.propertyGrid_AddProduct, 4);
            this.propertyGrid_AddProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid_AddProduct.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyGrid_AddProduct.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid_AddProduct.Name = "propertyGrid_AddProduct";
            this.propertyGrid_AddProduct.Size = new System.Drawing.Size(705, 619);
            this.propertyGrid_AddProduct.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.67058F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.81716F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.73699F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.63773F));
            this.tableLayoutPanel1.Controls.Add(this.button_editImages, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid_AddProduct, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_ok, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_cancel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_markForDeletion, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.31905F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.680945F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(711, 677);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button_editImages
            // 
            this.button_editImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button_editImages.Enabled = false;
            this.button_editImages.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_editImages.Location = new System.Drawing.Point(299, 628);
            this.button_editImages.Name = "button_editImages";
            this.button_editImages.Size = new System.Drawing.Size(168, 46);
            this.button_editImages.TabIndex = 4;
            this.button_editImages.Text = "🌄 Edit Images";
            this.button_editImages.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ok.Location = new System.Drawing.Point(630, 628);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(78, 46);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "Ok";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.Location = new System.Drawing.Point(511, 628);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(113, 46);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // checkBox_markForDeletion
            // 
            this.checkBox_markForDeletion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_markForDeletion.AutoSize = true;
            this.checkBox_markForDeletion.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_markForDeletion.Location = new System.Drawing.Point(15, 636);
            this.checkBox_markForDeletion.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.checkBox_markForDeletion.Name = "checkBox_markForDeletion";
            this.checkBox_markForDeletion.Size = new System.Drawing.Size(244, 29);
            this.checkBox_markForDeletion.TabIndex = 3;
            this.checkBox_markForDeletion.Text = "Mark this product deletion";
            this.checkBox_markForDeletion.UseVisualStyleBackColor = true;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 677);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddProduct";
            this.Text = "Add/Edit Product";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PropertyGrid propertyGrid_AddProduct;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Button button_cancel;
        internal System.Windows.Forms.Button button_ok;
        internal System.Windows.Forms.CheckBox checkBox_markForDeletion;
        internal System.Windows.Forms.Button button_editImages;
    }
}