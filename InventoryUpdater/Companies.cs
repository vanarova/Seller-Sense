using InventoryUpdater.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryUpdater
{
    internal partial class Companies : Form
    {
        private InventoryUpdater.Manager.Companies _companies;
        public Companies(InventoryUpdater.Manager.Companies companies)
        {
            _companies = companies;
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string error;
            bool iscreated = CreateCompanies(out error);
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
            if (_companies.DoesCompanyCodeExist(txtComp1Code.Text) || _companies.DoesCompanyCodeExist(txtComp2Code.Text))
            { error = "Company with same code exist."; return false; }
            if(!string.IsNullOrEmpty(txtComp1Name.Text) && !string.IsNullOrEmpty(txtComp1Code.Text))
                _companies.AddCompany1(txtComp1Name.Text, txtComp1Code.Text);
            if (!string.IsNullOrEmpty(txtComp2Name.Text) && !string.IsNullOrEmpty(txtComp2Code.Text))
                _companies.AddCompany2(txtComp2Name.Text, txtComp2Code.Text);
            return true;
        }

        private void txtComp1Name_TextChanged(object sender, EventArgs e)
        {
           txtComp1Code.Text = InventoryUpdater.Manager.Companies.GetRandomCode(txtComp1Name.Text, 4);
        }

        private void txtComp2Name_TextChanged(object sender, EventArgs e)
        {
            txtComp2Code.Text = InventoryUpdater.Manager.Companies.GetRandomCode(txtComp2Name.Text, 4);


        }

        private void Companies_Load(object sender, EventArgs e)
        {
            txtWorkSpaceLocation.Text = ProjIO.GetUserSetting(Constants.WorkspaceDir);
            if(string.IsNullOrEmpty(txtWorkSpaceLocation.Text))
                txtWorkSpaceLocation.Text = ProjIO.DefaultWorkspaceLocation();
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
    }
}
