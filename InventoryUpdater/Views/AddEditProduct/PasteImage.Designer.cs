namespace SellerSense.Views.AddEditProduct
{
    partial class PasteImage
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_display = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_img4 = new System.Windows.Forms.RadioButton();
            this.radioButton_img3 = new System.Windows.Forms.RadioButton();
            this.radioButton_img2 = new System.Windows.Forms.RadioButton();
            this.radioButton_img1 = new System.Windows.Forms.RadioButton();
            this.button_Ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_display)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.727924F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.20525F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.66826F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.398569F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_display, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Ok, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_cancel, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.0303F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.48485F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.28125F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1063, 660);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(615, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paste image here ( Mouse right click OR Cntrl + v ):";
            // 
            // pictureBox_display
            // 
            this.pictureBox_display.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_display.Location = new System.Drawing.Point(63, 89);
            this.pictureBox_display.Name = "pictureBox_display";
            this.pictureBox_display.Size = new System.Drawing.Size(591, 446);
            this.pictureBox_display.TabIndex = 1;
            this.pictureBox_display.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(238, 48);
            // 
            // pasteImageToolStripMenuItem
            // 
            this.pasteImageToolStripMenuItem.Name = "pasteImageToolStripMenuItem";
            this.pasteImageToolStripMenuItem.Size = new System.Drawing.Size(237, 44);
            this.pasteImageToolStripMenuItem.Text = "Paste Image";
            this.pasteImageToolStripMenuItem.Click += new System.EventHandler(this.pasteImageToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.radioButton_img4);
            this.groupBox1.Controls.Add(this.radioButton_img3);
            this.groupBox1.Controls.Add(this.radioButton_img2);
            this.groupBox1.Controls.Add(this.radioButton_img1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(671, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 390);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose image index";
            // 
            // radioButton_img4
            // 
            this.radioButton_img4.AutoSize = true;
            this.radioButton_img4.Location = new System.Drawing.Point(21, 267);
            this.radioButton_img4.Name = "radioButton_img4";
            this.radioButton_img4.Size = new System.Drawing.Size(144, 41);
            this.radioButton_img4.TabIndex = 3;
            this.radioButton_img4.Text = "Image 4";
            this.radioButton_img4.UseVisualStyleBackColor = true;
            // 
            // radioButton_img3
            // 
            this.radioButton_img3.AutoSize = true;
            this.radioButton_img3.Location = new System.Drawing.Point(21, 204);
            this.radioButton_img3.Name = "radioButton_img3";
            this.radioButton_img3.Size = new System.Drawing.Size(144, 41);
            this.radioButton_img3.TabIndex = 2;
            this.radioButton_img3.Text = "Image 3";
            this.radioButton_img3.UseVisualStyleBackColor = true;
            // 
            // radioButton_img2
            // 
            this.radioButton_img2.AutoSize = true;
            this.radioButton_img2.Location = new System.Drawing.Point(21, 140);
            this.radioButton_img2.Name = "radioButton_img2";
            this.radioButton_img2.Size = new System.Drawing.Size(144, 41);
            this.radioButton_img2.TabIndex = 1;
            this.radioButton_img2.Text = "Image 2";
            this.radioButton_img2.UseVisualStyleBackColor = true;
            // 
            // radioButton_img1
            // 
            this.radioButton_img1.AutoSize = true;
            this.radioButton_img1.Checked = true;
            this.radioButton_img1.Location = new System.Drawing.Point(21, 80);
            this.radioButton_img1.Name = "radioButton_img1";
            this.radioButton_img1.Size = new System.Drawing.Size(144, 41);
            this.radioButton_img1.TabIndex = 0;
            this.radioButton_img1.TabStop = true;
            this.radioButton_img1.Text = "Image 1";
            this.radioButton_img1.UseVisualStyleBackColor = true;
            // 
            // button_Ok
            // 
            this.button_Ok.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ok.Location = new System.Drawing.Point(660, 541);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(276, 84);
            this.button_Ok.TabIndex = 3;
            this.button_Ok.Text = "Ok";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.Location = new System.Drawing.Point(429, 541);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(225, 84);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // PasteImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 660);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PasteImage";
            this.Text = "PasteImage";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasteImage_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_display)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_display;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_img4;
        private System.Windows.Forms.RadioButton radioButton_img3;
        private System.Windows.Forms.RadioButton radioButton_img2;
        private System.Windows.Forms.RadioButton radioButton_img1;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pasteImageToolStripMenuItem;
    }
}