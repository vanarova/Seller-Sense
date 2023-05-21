using AngleSharp.Dom.Events;
using SellerSense.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense
{
    internal partial class SetUp : Form
    {
        private string _map1File;
        private string _map2File;
        private string _map3File;
        private string _map4File;
        private string _map5File;
        private SellerSense.Manager.Companies _companies;
        public SetUp(SellerSense.Manager.Companies companies)
        {
            _companies = companies;
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string error;
            bool iscreated = CreateCompanies(out error);
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(error);

            if(!string.IsNullOrEmpty(_map1File))
                ProjIO.ImportMap(_map1File, txtComp1Code.Text);
            if (!string.IsNullOrEmpty(_map2File))
                ProjIO.ImportMap(_map2File, txtComp2Code.Text);
            if (!string.IsNullOrEmpty(_map3File))
                ProjIO.ImportMap(_map3File, txtComp3Code.Text);
            if (!string.IsNullOrEmpty(_map4File))
                ProjIO.ImportMap(_map4File, txtComp4Code.Text);
            if (!string.IsNullOrEmpty(_map5File))
                ProjIO.ImportMap(_map5File, txtComp5Code.Text);

            lbl_Error.Text = error;
            if (iscreated)
            { AdjustUI("CompaniesCreated");
            this.Close(); }

        }

       

        private void AdjustUI(string key)
        {
            switch (key)
            {
                case "CompaniesCreated":
                    txtComp1Name.Enabled = false; txtComp2Name.Enabled = false;
                    txtComp3Name.Enabled = false; txtComp4Name.Enabled = false; txtComp5Name.Enabled = false;
                    btn_changeLoc.Enabled = false;
                    break;

                case "Reset":
                    txtComp1Name.Enabled = true; txtComp2Name.Enabled = true;
                    //disable for now
                    //txtComp3Name.Enabled = true; txtComp4Name.Enabled = true;
                    //txtComp5Name.Enabled = true;
                    txtComp1Name.Text = ""; txtComp3Name.Text = ""; txtComp5Name.Text = "";
                    txtComp2Name.Text = ""; txtComp4Name.Text = "";
                    txtComp1Code.Text = ""; txtComp3Code.Text = ""; txtComp5Code.Text = "";
                    txtComp2Code.Text = ""; txtComp4Code.Text = "";
                    
                    btn_changeLoc.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private bool CreateCompanies(out string error)
        {
            error = "" ;
            if (_companies.DoesCompanyCodeExist(txtComp1Code.Text) && _companies.DoesCompanyCodeExist(txtComp2Code.Text))
            { error = "Company with same code exist."; return false; }
            if(!_companies.DoesCompanyCodeExist(txtComp1Code.Text) && 
                !string.IsNullOrEmpty(txtComp1Name.Text) && !string.IsNullOrEmpty(txtComp1Code.Text))
                _companies.AddCompany1(txtComp1Name.Text, txtComp1Code.Text);
            if (!_companies.DoesCompanyCodeExist(txtComp2Code.Text) && !string.IsNullOrEmpty(txtComp2Name.Text) && !string.IsNullOrEmpty(txtComp2Code.Text))
                _companies.AddCompany2(txtComp2Name.Text, txtComp2Code.Text);
            return true;
        }

        private void txtComp1Name_TextChanged(object sender, EventArgs e)
        {
           txtComp1Code.Text = SellerSense.Manager.Companies.GetRandomCode(txtComp1Name.Text, 4);
        }

        private void txtComp2Name_TextChanged(object sender, EventArgs e)
        {
            txtComp2Code.Text = SellerSense.Manager.Companies.GetRandomCode(txtComp2Name.Text, 4);


        }

        private void SetUp_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ProjIO.GetUserSetting(Constants.WorkspaceDir)))
                txtWorkSpaceLocation.Text = ProjIO.GetUserSetting(Constants.WorkspaceDir);
            else
                txtWorkSpaceLocation.Text = ProjIO.DefaultWorkspaceLocation();
            txtComp1Name.Text = ProjIO.GetUserSetting(Constants.Company1Name);
            txtComp1Code.Text = ProjIO.GetUserSetting(Constants.Company1Code);
            txtComp2Name.Text = ProjIO.GetUserSetting(Constants.Company2Name);
            txtComp2Code.Text = ProjIO.GetUserSetting(Constants.Company2Code);
            //if (string.IsNullOrEmpty(txtWorkSpaceLocation.Text))
            //    txtWorkSpaceLocation.Text = ProjIO.DefaultWorkspaceLocation();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            AdjustUI("Reset");
        }

        private void txtComp3Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComp4Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_ImportMap1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtComp1Code.Text))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Inventory file|map.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _map1File = openFileDialog.FileName;
                    //ProjIO.ImportMap(openFileDialog.FileName, txtComp1Code.Text);
                }
                else return;
            }

        }

        private void btn_ImportMap2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtComp1Code.Text))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Inventory file|map.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _map2File = openFileDialog.FileName;
                    //ProjIO.ImportMap(openFileDialog.FileName, txtComp2Code.Text);
                }
                else return;
            }
        }

        private void btn_emailSetup_Click(object sender, EventArgs e)
        {
            EmailSetup email = new EmailSetup();
            email.ShowDialog();
        }
    }
}
