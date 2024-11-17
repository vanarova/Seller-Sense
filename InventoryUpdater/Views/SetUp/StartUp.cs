using CommonUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Views.SetUp
{
    public partial class StartUp : Form
    {
        private SellerSense.ViewManager.VM_Companies _companies;

        public StartUp(SellerSense.ViewManager.VM_Companies companies)
        {
            InitializeComponent();
            _companies = companies;
        }

        private void wizardControl1_Load(object sender, EventArgs e)
        {
            textBox_companyAName.Text = ProjIO.GetUserSetting(Constants.Company1Name);
            textBox_CompanyACode.Text = ProjIO.GetUserSetting(Constants.Company1Code);
            textBox_CompanyBName.Text = ProjIO.GetUserSetting(Constants.Company2Name);
            textBox_CompanyBCode.Text = ProjIO.GetUserSetting(Constants.Company2Code);
        }

        private void textBox_companyAName_TextChanged(object sender, EventArgs e)
        {
            textBox_CompanyACode.Text = SellerSense.ViewManager.VM_Companies.GetRandomCode(textBox_companyAName.Text, 4);
        }

        private void textBox_CompanyBName_TextChanged(object sender, EventArgs e)
        {
            textBox_CompanyBCode.Text = SellerSense.ViewManager.VM_Companies.GetRandomCode(textBox_CompanyBName.Text, 4);

        }

        private bool CreateCompanies(out string error)
        {
            
            error = "";
            if (ProjIO.DoesCompanyCodeExist(textBox_CompanyACode.Text) && ProjIO.DoesCompanyCodeExist(textBox_CompanyBCode.Text))
            { error = "Company with same code exist.";  }
            if (!string.IsNullOrEmpty(textBox_companyAName.Text) && !string.IsNullOrEmpty(textBox_CompanyACode.Text))
                _companies.AddCompany1(textBox_companyAName.Text, textBox_CompanyACode.Text);
            
            if (!string.IsNullOrEmpty(textBox_CompanyBName.Text) && !string.IsNullOrEmpty(textBox_CompanyBCode.Text))
                _companies.AddCompany2(textBox_CompanyBName.Text, textBox_CompanyBCode.Text);
            /// Now load companies from JSON file.
            _companies = new SellerSense.ViewManager.VM_Companies();


            if (_companies._companies != null && _companies._companies[0] != null && _companies._companies[0]._product_Model != null)
                _companies._companies[0]._product_Model.CreateSampleProductMapFile();
            if (_companies._companies != null && _companies._companies[1] != null && _companies._companies[1]._product_Model != null)
                _companies._companies[1]._product_Model.CreateSampleProductMapFile();
            return true;
        }

        private async void wizardControl1_FinishButton_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            label_progress.Visible = true;
            label_progress.Text = "Creating companies";
            await Task.Run(() => {
                Task.Delay(2000).Wait();
                bool iscreated = CreateCompanies(out string error);
                if (!string.IsNullOrEmpty(error))
                    MessageBox.Show(error);
                
            });
            progressBar1.Visible = false;
            label_progress.Visible = false;
            this.Close();
        }



        //private void txtComp1Name_TextChanged(object sender, EventArgs e)
        //{
        //    txtComp1Code.Text = SellerSense.ViewManager.VM_Companies.GetRandomCode(txtComp1Name.Text, 4);
        //}

        //private void txtComp2Name_TextChanged(object sender, EventArgs e)
        //{
        //    txtComp2Code.Text = SellerSense.ViewManager.VM_Companies.GetRandomCode(txtComp2Name.Text, 4);


        //}
    }
}
