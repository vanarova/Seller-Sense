namespace SellerSense.Views.SetUp
{
    partial class StartUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUp));
            this.wizardControl1 = new Syncfusion.Windows.Forms.Tools.WizardControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wizardContainer1 = new Syncfusion.Windows.Forms.Tools.WizardContainer();
            this.wizardControlPage1 = new Syncfusion.Windows.Forms.Tools.WizardControlPage(this.components);
            this.wizardControlPage2 = new Syncfusion.Windows.Forms.Tools.WizardControlPage(this.components);
            this.wizardControlPage3 = new Syncfusion.Windows.Forms.Tools.WizardControlPage(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_companyAName = new System.Windows.Forms.TextBox();
            this.textBox_CompanyACode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_CompanyBName = new System.Windows.Forms.TextBox();
            this.textBox_CompanyBCode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label_progress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1.GridBagLayout)).BeginInit();
            this.wizardControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            this.wizardContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControlPage1)).BeginInit();
            this.wizardControlPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControlPage2)).BeginInit();
            this.wizardControlPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControlPage3)).BeginInit();
            this.wizardControlPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            // 
            // 
            // 
            this.wizardControl1.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardControl1.BackButton.Location = new System.Drawing.Point(263, 377);
            this.wizardControl1.BackButton.Name = "backButton";
            this.wizardControl1.BackButton.Text = "<< Back";
            this.wizardControl1.Banner = this.pictureBox1;
            this.wizardControl1.BannerPanel = this.gradientPanel2;
            // 
            // 
            // 
            this.wizardControl1.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardControl1.CancelButton.Location = new System.Drawing.Point(183, 377);
            this.wizardControl1.CancelButton.Name = "cancelButton";
            this.wizardControl1.CancelButton.Text = "Cancel";
            this.wizardControl1.Controls.Add(this.wizardContainer1);
            this.wizardControl1.Controls.Add(this.gradientPanel2);
            this.wizardControl1.Description = this.label2;
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.wizardControl1.FinishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardControl1.FinishButton.Location = new System.Drawing.Point(418, 377);
            this.wizardControl1.FinishButton.Name = "finishButton";
            this.wizardControl1.FinishButton.Text = "Finish";
            this.wizardControl1.FinishButton.Click += new System.EventHandler(this.wizardControl1_FinishButton_Click);
            // 
            // 
            // 
            this.wizardControl1.GridBagLayout.ContainerControl = this.wizardControl1;
            // 
            // 
            // 
            this.wizardControl1.HelpButton.Location = new System.Drawing.Point(498, 377);
            this.wizardControl1.HelpButton.Name = "helpButton";
            this.wizardControl1.HelpButton.Text = "Help";
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            // 
            // 
            // 
            this.wizardControl1.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardControl1.NextButton.Enabled = false;
            this.wizardControl1.NextButton.Location = new System.Drawing.Point(338, 377);
            this.wizardControl1.NextButton.Name = "nextButton";
            this.wizardControl1.NextButton.Text = "Next >>";
            this.wizardControl1.SelectedWizardPage = this.wizardControlPage3;
            this.wizardControl1.Size = new System.Drawing.Size(578, 405);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = this.label1;
            this.wizardControl1.WizardPageContainer = this.wizardContainer1;
            this.wizardControl1.WizardPages = new Syncfusion.Windows.Forms.Tools.WizardControlPage[] {
        this.wizardControlPage1,
        this.wizardControlPage2,
        this.wizardControlPage3};
            this.wizardControl1.Load += new System.EventHandler(this.wizardControl1_Load);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(507, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Controls.Add(this.pictureBox1);
            this.gradientPanel2.Controls.Add(this.label1);
            this.gradientPanel2.Controls.Add(this.label2);
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(578, 70);
            this.gradientPanel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Almost Done!";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Location = new System.Drawing.Point(20, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "This is the description of the Wizard Page";
            // 
            // wizardContainer1
            // 
            this.wizardContainer1.Controls.Add(this.wizardControlPage1);
            this.wizardContainer1.Controls.Add(this.wizardControlPage2);
            this.wizardContainer1.Controls.Add(this.wizardControlPage3);
            this.wizardContainer1.Location = new System.Drawing.Point(0, 70);
            this.wizardContainer1.Name = "wizardContainer1";
            this.wizardContainer1.Size = new System.Drawing.Size(578, 294);
            this.wizardContainer1.TabIndex = 1;
            // 
            // wizardControlPage1
            // 
            this.wizardControlPage1.BackEnabled = false;
            this.wizardControlPage1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wizardControlPage1.Controls.Add(this.tableLayoutPanel1);
            this.wizardControlPage1.Description = "This is the description of the Wizard Page";
            this.wizardControlPage1.FullPage = false;
            this.wizardControlPage1.LayoutName = "Card1";
            this.wizardControlPage1.Location = new System.Drawing.Point(0, 0);
            this.wizardControlPage1.Name = "wizardControlPage1";
            this.wizardControlPage1.NextPage = this.wizardControlPage2;
            this.wizardControlPage1.PreviousPage = null;
            this.wizardControlPage1.Size = new System.Drawing.Size(578, 294);
            this.wizardControlPage1.TabIndex = 0;
            this.wizardControlPage1.Title = "Page Title";
            // 
            // wizardControlPage2
            // 
            this.wizardControlPage2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wizardControlPage2.Controls.Add(this.tableLayoutPanel2);
            this.wizardControlPage2.Description = "This is the description of the Wizard Page";
            this.wizardControlPage2.FullPage = false;
            this.wizardControlPage2.LayoutName = "Card2";
            this.wizardControlPage2.Location = new System.Drawing.Point(0, 0);
            this.wizardControlPage2.Name = "wizardControlPage2";
            this.wizardControlPage2.NextPage = this.wizardControlPage3;
            this.wizardControlPage2.PreviousPage = null;
            this.wizardControlPage2.Size = new System.Drawing.Size(578, 294);
            this.wizardControlPage2.TabIndex = 1;
            this.wizardControlPage2.Title = "Page Title";
            // 
            // wizardControlPage3
            // 
            this.wizardControlPage3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wizardControlPage3.CancelOverFinish = false;
            this.wizardControlPage3.Controls.Add(this.tableLayoutPanel3);
            this.wizardControlPage3.Description = "This is the description of the Wizard Page";
            this.wizardControlPage3.FullPage = false;
            this.wizardControlPage3.LayoutName = "Card3";
            this.wizardControlPage3.Location = new System.Drawing.Point(0, 0);
            this.wizardControlPage3.Name = "wizardControlPage3";
            this.wizardControlPage3.NextEnabled = false;
            this.wizardControlPage3.NextPage = null;
            this.wizardControlPage3.PreviousPage = null;
            this.wizardControlPage3.Size = new System.Drawing.Size(578, 294);
            this.wizardControlPage3.TabIndex = 2;
            this.wizardControlPage3.Title = "Almost Done!";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.16981F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.83019F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_companyAName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_CompanyACode, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.17204F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.82796F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 294);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "First company name :";
            // 
            // textBox_companyAName
            // 
            this.textBox_companyAName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_companyAName.Location = new System.Drawing.Point(166, 117);
            this.textBox_companyAName.Name = "textBox_companyAName";
            this.textBox_companyAName.Size = new System.Drawing.Size(177, 22);
            this.textBox_companyAName.TabIndex = 1;
            this.textBox_companyAName.TextChanged += new System.EventHandler(this.textBox_companyAName_TextChanged);
            // 
            // textBox_CompanyACode
            // 
            this.textBox_CompanyACode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_CompanyACode.Location = new System.Drawing.Point(349, 117);
            this.textBox_CompanyACode.Name = "textBox_CompanyACode";
            this.textBox_CompanyACode.Size = new System.Drawing.Size(174, 22);
            this.textBox_CompanyACode.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.17391F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.82609F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox_CompanyBName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox_CompanyBCode, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.17204F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.82796F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(578, 294);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Second company name:";
            // 
            // textBox_CompanyBName
            // 
            this.textBox_CompanyBName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_CompanyBName.Location = new System.Drawing.Point(183, 117);
            this.textBox_CompanyBName.Name = "textBox_CompanyBName";
            this.textBox_CompanyBName.Size = new System.Drawing.Size(159, 22);
            this.textBox_CompanyBName.TabIndex = 1;
            this.textBox_CompanyBName.TextChanged += new System.EventHandler(this.textBox_CompanyBName_TextChanged);
            // 
            // textBox_CompanyBCode
            // 
            this.textBox_CompanyBCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_CompanyBCode.Location = new System.Drawing.Point(348, 117);
            this.textBox_CompanyBCode.Name = "textBox_CompanyBCode";
            this.textBox_CompanyBCode.Size = new System.Drawing.Size(174, 22);
            this.textBox_CompanyBCode.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.32505F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.67495F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel3.Controls.Add(this.label_progress, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.progressBar1, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.81208F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.18792F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(578, 294);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label_progress
            // 
            this.label_progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_progress.AutoSize = true;
            this.label_progress.Location = new System.Drawing.Point(395, 149);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(85, 16);
            this.label_progress.TabIndex = 0;
            this.label_progress.Text = "Please wait ..";
            this.label_progress.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(106, 116);
            this.progressBar1.MarqueeAnimationSpeed = 40;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(374, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 405);
            this.Controls.Add(this.wizardControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartUp";
            this.Text = "StartUp";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1.GridBagLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.wizardContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControlPage1)).EndInit();
            this.wizardControlPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControlPage2)).EndInit();
            this.wizardControlPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControlPage3)).EndInit();
            this.wizardControlPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.WizardControl wizardControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.WizardContainer wizardContainer1;
        private Syncfusion.Windows.Forms.Tools.WizardControlPage wizardControlPage1;
        private Syncfusion.Windows.Forms.Tools.WizardControlPage wizardControlPage2;
        private Syncfusion.Windows.Forms.Tools.WizardControlPage wizardControlPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_companyAName;
        private System.Windows.Forms.TextBox textBox_CompanyACode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_CompanyBName;
        private System.Windows.Forms.TextBox textBox_CompanyBCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}