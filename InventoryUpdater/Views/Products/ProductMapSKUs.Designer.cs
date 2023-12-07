namespace SellerSense.Views.Products
{
    partial class ProductMapSKUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductMapSKUs));
            this.label1 = new System.Windows.Forms.Label();
            this.button_LoadInventory = new System.Windows.Forms.Button();
            this.label_AssignedProductCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(721, 115);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // button_LoadAmzInventory
            // 
            this.button_LoadInventory.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LoadInventory.Location = new System.Drawing.Point(222, 274);
            this.button_LoadInventory.Name = "button_LoadAmzInventory";
            this.button_LoadInventory.Size = new System.Drawing.Size(356, 59);
            this.button_LoadInventory.TabIndex = 1;
            this.button_LoadInventory.Text = "Load Latest Inventory File && Assign SKUs";
            this.button_LoadInventory.UseVisualStyleBackColor = true;
            this.button_LoadInventory.Click += new System.EventHandler(this.Button_LoadInventory_Click);
            // 
            // label_AssignedProductCount
            // 
            this.label_AssignedProductCount.AutoSize = true;
            this.label_AssignedProductCount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AssignedProductCount.Location = new System.Drawing.Point(40, 195);
            this.label_AssignedProductCount.Name = "label_AssignedProductCount";
            this.label_AssignedProductCount.Size = new System.Drawing.Size(211, 23);
            this.label_AssignedProductCount.TabIndex = 2;
            this.label_AssignedProductCount.Text = "Assigned Products Count: ";
            // 
            // ProductMapSKUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 379);
            this.Controls.Add(this.label_AssignedProductCount);
            this.Controls.Add(this.button_LoadInventory);
            this.Controls.Add(this.label1);
            this.Name = "ProductMapSKUs";
            this.Text = "ProductMapSKUs";
            this.Load += new System.EventHandler(this.ProductMapSKUs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_LoadInventory;
        private System.Windows.Forms.Label label_AssignedProductCount;
    }
}