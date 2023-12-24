namespace SellerSense.Views
{
    partial class MessagePopBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessagePopBox));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_Action1 = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.richTextBox_Message = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.26756F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.73244F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.Controls.Add(this.button_cancel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_ok, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Action1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox_Message, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.40187F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.598131F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(741, 557);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_ok.Location = new System.Drawing.Point(613, 517);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(105, 32);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_Action1
            // 
            this.button_Action1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Action1.Location = new System.Drawing.Point(3, 517);
            this.button_Action1.Name = "button_Action1";
            this.button_Action1.Size = new System.Drawing.Size(157, 32);
            this.button_Action1.TabIndex = 2;
            this.button_Action1.Text = "Text";
            this.button_Action1.UseVisualStyleBackColor = true;
            this.button_Action1.Click += new System.EventHandler(this.button_Action1_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_cancel.Location = new System.Drawing.Point(493, 517);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(105, 32);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // richTextBox_Message
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBox_Message, 3);
            this.richTextBox_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Message.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_Message.Name = "richTextBox_Message";
            this.richTextBox_Message.Size = new System.Drawing.Size(735, 503);
            this.richTextBox_Message.TabIndex = 5;
            this.richTextBox_Message.Text = "";
            // 
            // MessagePopBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 557);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MessagePopBox";
            this.Text = "Info";
            this.Load += new System.EventHandler(this.MessagePopBox_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_Action1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.RichTextBox richTextBox_Message;
    }
}