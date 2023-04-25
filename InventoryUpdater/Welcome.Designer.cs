namespace InventoryUpdater
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
            this.tblWelcomeButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btn_mapping = new System.Windows.Forms.Button();
            this.btn_invUpdate = new System.Windows.Forms.Button();
            this.pbarLoadForms = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tblWelcomeButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblWelcomeButtons
            // 
            this.tblWelcomeButtons.ColumnCount = 4;
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWelcomeButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tblWelcomeButtons.Controls.Add(this.btn_mapping, 2, 1);
            this.tblWelcomeButtons.Controls.Add(this.btn_invUpdate, 1, 1);
            this.tblWelcomeButtons.Controls.Add(this.pbarLoadForms, 1, 2);
            this.tblWelcomeButtons.Location = new System.Drawing.Point(269, 186);
            this.tblWelcomeButtons.Name = "tblWelcomeButtons";
            this.tblWelcomeButtons.RowCount = 3;
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33112F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33443F));
            this.tblWelcomeButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33445F));
            this.tblWelcomeButtons.Size = new System.Drawing.Size(668, 274);
            this.tblWelcomeButtons.TabIndex = 0;
            // 
            // btn_mapping
            // 
            this.btn_mapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_mapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mapping.Location = new System.Drawing.Point(338, 94);
            this.btn_mapping.Name = "btn_mapping";
            this.btn_mapping.Size = new System.Drawing.Size(204, 85);
            this.btn_mapping.TabIndex = 1;
            this.btn_mapping.Text = "Mapping";
            this.btn_mapping.UseVisualStyleBackColor = true;
            this.btn_mapping.Click += new System.EventHandler(this.btn_mapping_Click);
            // 
            // btn_invUpdate
            // 
            this.btn_invUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_invUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_invUpdate.Location = new System.Drawing.Point(128, 94);
            this.btn_invUpdate.Name = "btn_invUpdate";
            this.btn_invUpdate.Size = new System.Drawing.Size(204, 85);
            this.btn_invUpdate.TabIndex = 0;
            this.btn_invUpdate.Text = "Inventory Update";
            this.btn_invUpdate.UseVisualStyleBackColor = true;
            this.btn_invUpdate.Click += new System.EventHandler(this.btn_invUpdate_Click);
            // 
            // pbarLoadForms
            // 
            this.pbarLoadForms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblWelcomeButtons.SetColumnSpan(this.pbarLoadForms, 2);
            this.pbarLoadForms.Location = new System.Drawing.Point(128, 221);
            this.pbarLoadForms.Name = "pbarLoadForms";
            this.pbarLoadForms.Size = new System.Drawing.Size(414, 14);
            this.pbarLoadForms.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbarLoadForms.TabIndex = 2;
            this.pbarLoadForms.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1199, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 658);
            this.Controls.Add(this.tblWelcomeButtons);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Welcome";
            this.Text = "Inventory Updater";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.SizeChanged += new System.EventHandler(this.Welcome_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Welcome_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Welcome_KeyPress);
            this.tblWelcomeButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblWelcomeButtons;
        private System.Windows.Forms.Button btn_mapping;
        private System.Windows.Forms.Button btn_invUpdate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ProgressBar pbarLoadForms;
    }
}

