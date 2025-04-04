﻿namespace SellerSense.Views
{
    partial class ExportProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportProject));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chk_error = new System.Windows.Forms.CheckBox();
            this.chk_snapshot = new System.Windows.Forms.CheckBox();
            this.chk_img = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.360134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.63987F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.Controls.Add(this.chk_error, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chk_snapshot, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chk_img, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_ok, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.28409F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.34091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.90909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.19318F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.98864F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(556, 225);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chk_error
            // 
            this.chk_error.AutoSize = true;
            this.chk_error.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_error.Location = new System.Drawing.Point(27, 60);
            this.chk_error.Name = "chk_error";
            this.chk_error.Size = new System.Drawing.Size(153, 24);
            this.chk_error.TabIndex = 0;
            this.chk_error.Text = "Error/ Debug Logs";
            this.chk_error.UseVisualStyleBackColor = true;
            // 
            // chk_snapshot
            // 
            this.chk_snapshot.AutoSize = true;
            this.chk_snapshot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_snapshot.Location = new System.Drawing.Point(27, 129);
            this.chk_snapshot.Name = "chk_snapshot";
            this.chk_snapshot.Size = new System.Drawing.Size(350, 24);
            this.chk_snapshot.TabIndex = 2;
            this.chk_snapshot.Text = "Snapshots (This includes past inventory updates)";
            this.chk_snapshot.UseVisualStyleBackColor = true;
            // 
            // chk_img
            // 
            this.chk_img.AutoSize = true;
            this.chk_img.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_img.Location = new System.Drawing.Point(27, 94);
            this.chk_img.Name = "chk_img";
            this.chk_img.Size = new System.Drawing.Size(393, 24);
            this.chk_img.TabIndex = 1;
            this.chk_img.Text = "Images (This will considerably increase export file size)";
            this.chk_img.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Exporting Map file, Do you also want to export below files(s)";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(457, 165);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(84, 41);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // ExportProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 225);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportProject";
            this.Text = "Export Company";
            this.Load += new System.EventHandler(this.ExportProject_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chk_error;
        private System.Windows.Forms.CheckBox chk_img;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.CheckBox chk_snapshot;
    }
}