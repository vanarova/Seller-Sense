namespace SellerSense
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tblWelcomeButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Reports = new System.Windows.Forms.Button();
            this.btn_Setup = new System.Windows.Forms.Button();
            this.btn_Inv = new System.Windows.Forms.Button();
            this.btn_Product = new System.Windows.Forms.Button();
            this.pbarLoadForms = new System.Windows.Forms.ProgressBar();
            this.label_version = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblWelcomeButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(962, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tblWelcomeButtons
            // 
            this.tblWelcomeButtons.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tblWelcomeButtons.BackgroundImage")));
            this.tblWelcomeButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tblWelcomeButtons.ColumnCount = 5;
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tblWelcomeButtons.Controls.Add(this.btn_Open, 2, 3);
            this.tblWelcomeButtons.Controls.Add(this.btn_Reports, 2, 1);
            this.tblWelcomeButtons.Controls.Add(this.btn_Setup, 1, 1);
            this.tblWelcomeButtons.Controls.Add(this.btn_Inv, 2, 2);
            this.tblWelcomeButtons.Controls.Add(this.btn_Product, 1, 2);
            this.tblWelcomeButtons.Controls.Add(this.pbarLoadForms, 1, 4);
            this.tblWelcomeButtons.Controls.Add(this.label_version, 0, 4);
            this.tblWelcomeButtons.Controls.Add(this.comboBox1, 1, 3);
            this.tblWelcomeButtons.Location = new System.Drawing.Point(202, 151);
            this.tblWelcomeButtons.Margin = new System.Windows.Forms.Padding(2);
            this.tblWelcomeButtons.Name = "tblWelcomeButtons";
            this.tblWelcomeButtons.RowCount = 5;
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.06061F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.90909F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblWelcomeButtons.Size = new System.Drawing.Size(555, 268);
            this.tblWelcomeButtons.TabIndex = 0;
            // 
            // btn_Open
            // 
            this.btn_Open.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_Open.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Open.Location = new System.Drawing.Point(287, 181);
            this.btn_Open.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(158, 45);
            this.btn_Open.TabIndex = 6;
            this.btn_Open.Text = "▶ Open";
            this.btn_Open.UseVisualStyleBackColor = false;
            this.btn_Open.Click += new System.EventHandler(this.btn_products_Click);
            // 
            // btn_Reports
            // 
            this.btn_Reports.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_Reports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reports.Location = new System.Drawing.Point(287, 45);
            this.btn_Reports.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Reports.Name = "btn_Reports";
            this.btn_Reports.Size = new System.Drawing.Size(158, 52);
            this.btn_Reports.TabIndex = 4;
            this.btn_Reports.Text = "🗄Payments";
            this.btn_Reports.UseVisualStyleBackColor = false;
            this.btn_Reports.Click += new System.EventHandler(this.btn_Reports_Click);
            // 
            // btn_Setup
            // 
            this.btn_Setup.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_Setup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Setup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Setup.Location = new System.Drawing.Point(125, 45);
            this.btn_Setup.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Setup.Name = "btn_Setup";
            this.btn_Setup.Size = new System.Drawing.Size(158, 52);
            this.btn_Setup.TabIndex = 3;
            this.btn_Setup.Text = "⛏SetUp";
            this.btn_Setup.UseVisualStyleBackColor = false;
            this.btn_Setup.Click += new System.EventHandler(this.btn_Setup_Click);
            // 
            // btn_Inv
            // 
            this.btn_Inv.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_Inv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Inv.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Inv.Location = new System.Drawing.Point(287, 101);
            this.btn_Inv.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Inv.Name = "btn_Inv";
            this.btn_Inv.Size = new System.Drawing.Size(158, 76);
            this.btn_Inv.TabIndex = 1;
            this.btn_Inv.Text = "🏭 Inventory";
            this.btn_Inv.UseVisualStyleBackColor = false;
            this.btn_Inv.Click += new System.EventHandler(this.btn_Inventories_Click);
            // 
            // btn_Product
            // 
            this.btn_Product.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_Product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Product.Location = new System.Drawing.Point(125, 101);
            this.btn_Product.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Product.Name = "btn_Product";
            this.btn_Product.Size = new System.Drawing.Size(158, 76);
            this.btn_Product.TabIndex = 0;
            this.btn_Product.Text = "🛍 Products";
            this.btn_Product.UseVisualStyleBackColor = false;
            this.btn_Product.Click += new System.EventHandler(this.btn_Products_Click);
            // 
            // pbarLoadForms
            // 
            this.pbarLoadForms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblWelcomeButtons.SetColumnSpan(this.pbarLoadForms, 2);
            this.pbarLoadForms.Location = new System.Drawing.Point(125, 242);
            this.pbarLoadForms.Margin = new System.Windows.Forms.Padding(2);
            this.pbarLoadForms.Name = "pbarLoadForms";
            this.pbarLoadForms.Size = new System.Drawing.Size(320, 11);
            this.pbarLoadForms.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbarLoadForms.TabIndex = 2;
            this.pbarLoadForms.Visible = false;
            // 
            // label_version
            // 
            this.label_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(2, 255);
            this.label_version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(78, 13);
            this.label_version.TabIndex = 5;
            this.label_version.Text = "Version 0.0.0.0";
            this.label_version.Click += new System.EventHandler(this.label_version_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Materials",
            "Attendance",
            "Tasks"});
            this.comboBox1.Location = new System.Drawing.Point(125, 184);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(158, 38);
            this.comboBox1.TabIndex = 7;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(962, 548);
            this.Controls.Add(this.tblWelcomeButtons);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Welcome";
            this.Text = "Seller-Sense";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.SizeChanged += new System.EventHandler(this.Welcome_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Welcome_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Welcome_KeyPress);
            this.tblWelcomeButtons.ResumeLayout(false);
            this.tblWelcomeButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblWelcomeButtons;
        private System.Windows.Forms.Button btn_Inv;
        private System.Windows.Forms.Button btn_Product;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ProgressBar pbarLoadForms;
        private System.Windows.Forms.Button btn_Reports;
        private System.Windows.Forms.Button btn_Setup;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

