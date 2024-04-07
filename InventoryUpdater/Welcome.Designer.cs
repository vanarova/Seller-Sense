using Syncfusion.WinForms.Controls;

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
            this.tblWelcomeButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Reports = new System.Windows.Forms.Button();
            this.btn_Setup = new System.Windows.Forms.Button();
            this.btn_Inv = new System.Windows.Forms.Button();
            this.btn_Product = new System.Windows.Forms.Button();
            this.pbarLoadForms = new System.Windows.Forms.ProgressBar();
            this.label_version = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label_Registration = new System.Windows.Forms.Label();
            this.label_news = new System.Windows.Forms.Label();
            this.label_help = new System.Windows.Forms.Label();
            this.tblWelcomeButtons.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tblWelcomeButtons.Controls.Add(this.btn_Open, 2, 3);
            this.tblWelcomeButtons.Controls.Add(this.btn_Reports, 2, 1);
            this.tblWelcomeButtons.Controls.Add(this.btn_Setup, 1, 1);
            this.tblWelcomeButtons.Controls.Add(this.btn_Inv, 2, 2);
            this.tblWelcomeButtons.Controls.Add(this.btn_Product, 1, 2);
            this.tblWelcomeButtons.Controls.Add(this.pbarLoadForms, 1, 4);
            this.tblWelcomeButtons.Controls.Add(this.label_version, 0, 4);
            this.tblWelcomeButtons.Controls.Add(this.comboBox1, 1, 3);
            this.tblWelcomeButtons.Controls.Add(this.flowLayoutPanel1, 3, 4);
            this.tblWelcomeButtons.Controls.Add(this.label_help, 4, 0);
            this.tblWelcomeButtons.Location = new System.Drawing.Point(269, 186);
            this.tblWelcomeButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblWelcomeButtons.Name = "tblWelcomeButtons";
            this.tblWelcomeButtons.RowCount = 5;
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.06061F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.90909F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblWelcomeButtons.Size = new System.Drawing.Size(740, 330);
            this.tblWelcomeButtons.TabIndex = 0;
            // 
            // btn_Open
            // 
            this.btn_Open.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_Open.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Open.Location = new System.Drawing.Point(383, 223);
            this.btn_Open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(210, 56);
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
            this.btn_Reports.Location = new System.Drawing.Point(383, 55);
            this.btn_Reports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Reports.Name = "btn_Reports";
            this.btn_Reports.Size = new System.Drawing.Size(210, 65);
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
            this.btn_Setup.Location = new System.Drawing.Point(167, 55);
            this.btn_Setup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Setup.Name = "btn_Setup";
            this.btn_Setup.Size = new System.Drawing.Size(210, 65);
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
            this.btn_Inv.Location = new System.Drawing.Point(383, 124);
            this.btn_Inv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Inv.Name = "btn_Inv";
            this.btn_Inv.Size = new System.Drawing.Size(210, 95);
            this.btn_Inv.TabIndex = 1;
            this.btn_Inv.Text = "🏭 Inventory";
            this.btn_Inv.UseVisualStyleBackColor = false;
            this.btn_Inv.Click += new System.EventHandler(this.btn_Inventories_Click);
            // 
            // btn_Product
            // 
            this.btn_Product.AccessibleName = "Button";
            this.btn_Product.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_Product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Product.Location = new System.Drawing.Point(167, 124);
            this.btn_Product.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Product.Name = "btn_Product";
            this.btn_Product.Size = new System.Drawing.Size(210, 95);
            this.btn_Product.TabIndex = 0;
            this.btn_Product.Text = "🛍 Products";
            this.btn_Product.UseVisualStyleBackColor = false;
            this.btn_Product.Click += new System.EventHandler(this.btn_Products_Click);
            // 
            // pbarLoadForms
            // 
            this.pbarLoadForms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblWelcomeButtons.SetColumnSpan(this.pbarLoadForms, 2);
            this.pbarLoadForms.Location = new System.Drawing.Point(167, 298);
            this.pbarLoadForms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbarLoadForms.Name = "pbarLoadForms";
            this.pbarLoadForms.Size = new System.Drawing.Size(426, 14);
            this.pbarLoadForms.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbarLoadForms.TabIndex = 2;
            this.pbarLoadForms.Visible = false;
            // 
            // label_version
            // 
            this.label_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_version.AutoSize = true;
            this.label_version.Location = new System.Drawing.Point(3, 314);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(93, 16);
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
            this.comboBox1.Location = new System.Drawing.Point(167, 228);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(210, 45);
            this.comboBox1.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tblWelcomeButtons.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.label_Registration);
            this.flowLayoutPanel1.Controls.Add(this.label_news);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(652, 284);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(85, 43);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // label_Registration
            // 
            this.label_Registration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Registration.AutoSize = true;
            this.label_Registration.BackColor = System.Drawing.Color.GreenYellow;
            this.label_Registration.Location = new System.Drawing.Point(3, 27);
            this.label_Registration.Name = "label_Registration";
            this.label_Registration.Size = new System.Drawing.Size(74, 16);
            this.label_Registration.TabIndex = 8;
            this.label_Registration.Text = "Registered";
            this.label_Registration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_Registration.Click += new System.EventHandler(this.label_Registration_Click);
            // 
            // label_news
            // 
            this.label_news.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_news.AutoSize = true;
            this.label_news.BackColor = System.Drawing.Color.Gold;
            this.label_news.Location = new System.Drawing.Point(36, 11);
            this.label_news.Name = "label_news";
            this.label_news.Size = new System.Drawing.Size(41, 16);
            this.label_news.TabIndex = 9;
            this.label_news.Text = "News";
            this.label_news.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_news.Click += new System.EventHandler(this.label_news_Click);
            // 
            // label_help
            // 
            this.label_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_help.AutoSize = true;
            this.label_help.Location = new System.Drawing.Point(691, 0);
            this.label_help.Name = "label_help";
            this.label_help.Size = new System.Drawing.Size(46, 16);
            this.label_help.TabIndex = 10;
            this.label_help.Text = "Help ?";
            this.label_help.Click += new System.EventHandler(this.label_help_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1282, 673);
            this.Controls.Add(this.tblWelcomeButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconSize = new System.Drawing.Size(32, 32);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Welcome";
            this.Style.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Seller-Sense";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.SizeChanged += new System.EventHandler(this.Welcome_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Welcome_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Welcome_KeyPress);
            this.tblWelcomeButtons.ResumeLayout(false);
            this.tblWelcomeButtons.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblWelcomeButtons;
        private System.Windows.Forms.Button btn_Inv;
        private System.Windows.Forms.Button btn_Product;
        private System.Windows.Forms.ProgressBar pbarLoadForms;
        private System.Windows.Forms.Button btn_Reports;
        private System.Windows.Forms.Button btn_Setup;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_Registration;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label_news;
        private System.Windows.Forms.Label label_help;
    }
}

