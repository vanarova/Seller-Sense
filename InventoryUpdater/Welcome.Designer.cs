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
            this.btn_products = new System.Windows.Forms.Button();
            this.btn_Reports = new System.Windows.Forms.Button();
            this.btn_Setup = new System.Windows.Forms.Button();
            this.btn_mapping = new System.Windows.Forms.Button();
            this.btn_invUpdate = new System.Windows.Forms.Button();
            this.pbarLoadForms = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblWelcomeButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1283, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tblWelcomeButtons
            // 
            this.tblWelcomeButtons.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tblWelcomeButtons.BackgroundImage")));
            this.tblWelcomeButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tblWelcomeButtons.ColumnCount = 5;
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tblWelcomeButtons.Controls.Add(this.btn_products, 2, 3);
            this.tblWelcomeButtons.Controls.Add(this.btn_Reports, 2, 1);
            this.tblWelcomeButtons.Controls.Add(this.btn_Setup, 1, 1);
            this.tblWelcomeButtons.Controls.Add(this.btn_mapping, 2, 2);
            this.tblWelcomeButtons.Controls.Add(this.btn_invUpdate, 1, 2);
            this.tblWelcomeButtons.Controls.Add(this.pbarLoadForms, 1, 4);
            this.tblWelcomeButtons.Controls.Add(this.label1, 0, 4);
            this.tblWelcomeButtons.Controls.Add(this.comboBox1, 1, 3);
            this.tblWelcomeButtons.Location = new System.Drawing.Point(269, 186);
            this.tblWelcomeButtons.Name = "tblWelcomeButtons";
            this.tblWelcomeButtons.RowCount = 5;
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.06061F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.90909F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblWelcomeButtons.Size = new System.Drawing.Size(740, 330);
            this.tblWelcomeButtons.TabIndex = 0;
            // 
            // btn_products
            // 
            this.btn_products.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_products.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_products.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_products.Location = new System.Drawing.Point(383, 224);
            this.btn_products.Name = "btn_products";
            this.btn_products.Size = new System.Drawing.Size(210, 54);
            this.btn_products.TabIndex = 6;
            this.btn_products.Text = "▶ Open";
            this.btn_products.UseVisualStyleBackColor = false;
            this.btn_products.Click += new System.EventHandler(this.btn_products_Click);
            // 
            // btn_Reports
            // 
            this.btn_Reports.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_Reports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reports.Location = new System.Drawing.Point(383, 56);
            this.btn_Reports.Name = "btn_Reports";
            this.btn_Reports.Size = new System.Drawing.Size(210, 63);
            this.btn_Reports.TabIndex = 4;
            this.btn_Reports.Text = "🗄Reports";
            this.btn_Reports.UseVisualStyleBackColor = false;
            this.btn_Reports.Click += new System.EventHandler(this.btn_Reports_Click);
            // 
            // btn_Setup
            // 
            this.btn_Setup.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_Setup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Setup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Setup.Location = new System.Drawing.Point(167, 56);
            this.btn_Setup.Name = "btn_Setup";
            this.btn_Setup.Size = new System.Drawing.Size(210, 63);
            this.btn_Setup.TabIndex = 3;
            this.btn_Setup.Text = "⛏SetUp";
            this.btn_Setup.UseVisualStyleBackColor = false;
            this.btn_Setup.Click += new System.EventHandler(this.btn_Setup_Click);
            // 
            // btn_mapping
            // 
            this.btn_mapping.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_mapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_mapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mapping.Location = new System.Drawing.Point(383, 125);
            this.btn_mapping.Name = "btn_mapping";
            this.btn_mapping.Size = new System.Drawing.Size(210, 93);
            this.btn_mapping.TabIndex = 1;
            this.btn_mapping.Text = "🏭 Inventory";
            this.btn_mapping.UseVisualStyleBackColor = false;
            this.btn_mapping.Click += new System.EventHandler(this.btn_Inventories_Click);
            // 
            // btn_invUpdate
            // 
            this.btn_invUpdate.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_invUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_invUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_invUpdate.Location = new System.Drawing.Point(167, 125);
            this.btn_invUpdate.Name = "btn_invUpdate";
            this.btn_invUpdate.Size = new System.Drawing.Size(210, 93);
            this.btn_invUpdate.TabIndex = 0;
            this.btn_invUpdate.Text = "🛍 Products";
            this.btn_invUpdate.UseVisualStyleBackColor = false;
            this.btn_invUpdate.Click += new System.EventHandler(this.btn_Products_Click);
            // 
            // pbarLoadForms
            // 
            this.pbarLoadForms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblWelcomeButtons.SetColumnSpan(this.pbarLoadForms, 2);
            this.pbarLoadForms.Location = new System.Drawing.Point(167, 298);
            this.pbarLoadForms.Name = "pbarLoadForms";
            this.pbarLoadForms.Size = new System.Drawing.Size(426, 14);
            this.pbarLoadForms.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbarLoadForms.TabIndex = 2;
            this.pbarLoadForms.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Version 1.0.3.0";
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
            this.comboBox1.Location = new System.Drawing.Point(166, 228);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(212, 45);
            this.comboBox1.TabIndex = 7;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1283, 675);
            this.Controls.Add(this.tblWelcomeButtons);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
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
        private System.Windows.Forms.Button btn_mapping;
        private System.Windows.Forms.Button btn_invUpdate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ProgressBar pbarLoadForms;
        private System.Windows.Forms.Button btn_Reports;
        private System.Windows.Forms.Button btn_Setup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_products;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

