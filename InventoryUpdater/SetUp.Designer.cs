namespace InventoryUpdater
{
    partial class SetUp
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
            this.btn_baseMapGen = new System.Windows.Forms.Button();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.btn_Go = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Admin = new System.Windows.Forms.Panel();
            this.txt_htmlFile = new System.Windows.Forms.TextBox();
            this.btn_JSONExport_NoFormat = new System.Windows.Forms.Button();
            this.btnJsonExport = new System.Windows.Forms.Button();
            this.pnl_Admin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_baseMapGen
            // 
            this.btn_baseMapGen.Location = new System.Drawing.Point(20, 19);
            this.btn_baseMapGen.Name = "btn_baseMapGen";
            this.btn_baseMapGen.Size = new System.Drawing.Size(162, 63);
            this.btn_baseMapGen.TabIndex = 0;
            this.btn_baseMapGen.Text = "Gen base map json from out html file from scrapper";
            this.btn_baseMapGen.UseVisualStyleBackColor = true;
            this.btn_baseMapGen.Visible = false;
            this.btn_baseMapGen.Click += new System.EventHandler(this.btn_baseMapGen_Click);
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(136, 41);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(300, 22);
            this.txt_pwd.TabIndex = 1;
            // 
            // btn_Go
            // 
            this.btn_Go.Location = new System.Drawing.Point(442, 41);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(49, 24);
            this.btn_Go.TabIndex = 2;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pwd:";
            // 
            // pnl_Admin
            // 
            this.pnl_Admin.Controls.Add(this.txt_htmlFile);
            this.pnl_Admin.Controls.Add(this.btn_JSONExport_NoFormat);
            this.pnl_Admin.Controls.Add(this.btnJsonExport);
            this.pnl_Admin.Controls.Add(this.btn_baseMapGen);
            this.pnl_Admin.Location = new System.Drawing.Point(34, 121);
            this.pnl_Admin.Name = "pnl_Admin";
            this.pnl_Admin.Size = new System.Drawing.Size(739, 298);
            this.pnl_Admin.TabIndex = 4;
            // 
            // txt_htmlFile
            // 
            this.txt_htmlFile.Location = new System.Drawing.Point(320, 180);
            this.txt_htmlFile.Name = "txt_htmlFile";
            this.txt_htmlFile.Size = new System.Drawing.Size(404, 22);
            this.txt_htmlFile.TabIndex = 3;
            this.txt_htmlFile.Visible = false;
            // 
            // btn_JSONExport_NoFormat
            // 
            this.btn_JSONExport_NoFormat.Location = new System.Drawing.Point(499, 208);
            this.btn_JSONExport_NoFormat.Name = "btn_JSONExport_NoFormat";
            this.btn_JSONExport_NoFormat.Size = new System.Drawing.Size(225, 63);
            this.btn_JSONExport_NoFormat.TabIndex = 2;
            this.btn_JSONExport_NoFormat.Text = "Write JSON Object from BaseMap, Remove price formatting";
            this.btn_JSONExport_NoFormat.UseVisualStyleBackColor = true;
            this.btn_JSONExport_NoFormat.Visible = false;
            this.btn_JSONExport_NoFormat.Click += new System.EventHandler(this.btn_JSONExport_NoFormat_Click);
            // 
            // btnJsonExport
            // 
            this.btnJsonExport.Location = new System.Drawing.Point(320, 208);
            this.btnJsonExport.Name = "btnJsonExport";
            this.btnJsonExport.Size = new System.Drawing.Size(173, 63);
            this.btnJsonExport.TabIndex = 1;
            this.btnJsonExport.Text = "Write JSON Object from BaseMap";
            this.btnJsonExport.UseVisualStyleBackColor = true;
            this.btnJsonExport.Visible = false;
            this.btnJsonExport.Click += new System.EventHandler(this.btnJsonExport_Click);
            // 
            // SuperAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_Admin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Go);
            this.Controls.Add(this.txt_pwd);
            this.Name = "SuperAdmin";
            this.Text = "SuperAdmin";
            this.pnl_Admin.ResumeLayout(false);
            this.pnl_Admin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_baseMapGen;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_Admin;
        private System.Windows.Forms.Button btnJsonExport;
        private System.Windows.Forms.Button btn_JSONExport_NoFormat;
        private System.Windows.Forms.TextBox txt_htmlFile;
    }
}