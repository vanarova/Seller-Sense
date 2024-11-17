using AngleSharp.Dom.Events;
using CommonUtil;

using SellerSense.Helper;
using SellerSense.Views;
using Syncfusion.WinForms.Controls;
//using SellerSense.Views.SetUp;
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
    internal partial class SetUp : SfForm
    {
        private string _map1File;
        private string _map2File;
        private string _map3File;
        private string _map4File;
        private string _map5File;
        private SellerSense.ViewManager.VM_Companies _companies;
        public SetUp(SellerSense.ViewManager.VM_Companies companies)
        {
            this.Style.TitleBar.ForeColor = Color.White;
            this.Style.TitleBar.BackColor = Constants.Theme.BorderColor;
            this.Style.Border.Color = Constants.Theme.BorderColor;
            this.Style.InactiveBorder.Color = Constants.Theme.BorderColor;
            this.Style.Border.Width = Constants.Theme.BorderWidth;
            this.Style.InactiveBorder.Width = Constants.Theme.BorderWidth;
            _companies = companies;
            InitializeComponent();
            
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //string error;
            //bool iscreated = CreateCompanies(out error);
            //if (!string.IsNullOrEmpty(error))
            //    MessageBox.Show(error);

       

            //lbl_Error.Text = error;
            //if (iscreated)
            //{ AdjustUI("CompaniesCreated");
            //this.Close(); }

        }

       

        //private void AdjustUI(string key)
        //{
        //    switch (key)
        //    {
        //        //case "CompaniesCreated":
        //        //    txtComp1Name.Enabled = false; txtComp2Name.Enabled = false;
        //        //    //txtComp3Name.Enabled = false; txtComp4Name.Enabled = false; txtComp5Name.Enabled = false;
        //        //    btn_changeLoc.Enabled = false;
        //        //    break;

        //        case "Reset":
        //            txtComp1Name.Enabled = true; txtComp2Name.Enabled = true;
        //            //disable for now
        //            //txtComp3Name.Enabled = true; txtComp4Name.Enabled = true;
        //            //txtComp5Name.Enabled = true;
        //            txtComp1Name.Text = ""; //txtComp3Name.Text = ""; txtComp5Name.Text = "";
        //            txtComp2Name.Text = ""; //txtComp4Name.Text = "";
        //            txtComp1Code.Text = ""; //txtComp3Code.Text = ""; txtComp5Code.Text = "";
        //            txtComp2Code.Text = "";// txtComp4Code.Text = "";
                    
        //            btn_changeLoc.Enabled = true;
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //private bool CreateCompanies(out string error)
        //{
        //    error = "" ;
        //    if (ProjIO.DoesCompanyCodeExist(txtComp1Code.Text) && ProjIO.DoesCompanyCodeExist(txtComp2Code.Text))
        //    { error = "Company with same code exist."; return false; }
        //    if(!ProjIO.DoesCompanyCodeExist(txtComp1Code.Text) && 
        //        !string.IsNullOrEmpty(txtComp1Name.Text) && !string.IsNullOrEmpty(txtComp1Code.Text))
        //        _companies.AddCompany1(txtComp1Name.Text, txtComp1Code.Text);
        //    if (!ProjIO.DoesCompanyCodeExist(txtComp2Code.Text) && !string.IsNullOrEmpty(txtComp2Name.Text) && !string.IsNullOrEmpty(txtComp2Code.Text))
        //        _companies.AddCompany2(txtComp2Name.Text, txtComp2Code.Text);
        //    return true;
        //}

        private void txtComp1Name_TextChanged(object sender, EventArgs e)
        {
           //txtComp1Code.Text = SellerSense.ViewManager.VM_Companies.GetRandomCode(txtComp1Name.Text, 4);
        }

        private void txtComp2Name_TextChanged(object sender, EventArgs e)
        {
            //txtComp2Code.Text = SellerSense.ViewManager.VM_Companies.GetRandomCode(txtComp2Name.Text, 4);


        }

        private void SetUp_Load(object sender, EventArgs e)
        {
            //Views.Products.Products tf = new Views.Products.Products();
            //tf.ShowDialog();
            txtComp1Name.Enabled = false; txtComp2Name.Enabled = false;
            if (!string.IsNullOrEmpty(ProjIO.GetUserSetting(Constants.WorkspaceDir)))
                txtWorkSpaceLocation.Text = ProjIO.GetUserSetting(Constants.WorkspaceDir);
            else
                txtWorkSpaceLocation.Text = ProjIO.DefaultWorkspaceLocation();
            LoadCompanyLabelTexts();
            pbar.Visible = false;
            label_Amz_CompA.Text = txtComp1Name.Text;
            ProjIO.SaveUserSetting(Constants.AmazonCompACode, ProjIO.GetUserSetting(Constants.Company1Code));
            label_Amz_CompanyB.Text = txtComp2Name.Text;
            ProjIO.SaveUserSetting(Constants.AmazonCompBCode, ProjIO.GetUserSetting(Constants.Company2Code));

            //textBox_amz_asin.Text = Mapping.AmazonInvColumnMapping.amazon_inv_report_asin;
            //textBox_amz_sku.Text = Mapping.AmazonInvColumnMapping.amazon_inv_report_sku;
            //textBox_amz_price.Text = Mapping.AmazonInvColumnMapping.amazon_inv_report_price;
            //textBox_amz_qty.Text = Mapping.AmazonInvColumnMapping.amazon_inv_report_sellerQuantity;

            //Properties.Resources.

            comboBox_LoggingLevel.DataSource = Enum.GetValues(typeof(Logger.LogLevel));
            //Default logger depth is set in program.cs, get tht value and assgin.
            comboBox_LoggingLevel.SelectedItem = Logger.GetLogLevel();

            comboBox_LoggingLevel.SelectedIndexChanged += (s, ev) =>
            {
                var val = (Logger.LogLevel)comboBox_LoggingLevel.SelectedItem;
                Logger.SetLoggerLevel_LogAboveThisLevelOnly(val);
            };

            PrestaShopSettings();
            AmazonSettings();

        }


        private void LoadCompanyLabelTexts()
        {
            txtComp1Name.Text = ProjIO.GetUserSetting(Constants.Company1Name);
            txtComp1Code.Text = ProjIO.GetUserSetting(Constants.Company1Code);
            txtComp2Name.Text = ProjIO.GetUserSetting(Constants.Company2Name);
            txtComp2Code.Text = ProjIO.GetUserSetting(Constants.Company2Code);
        }

        private void PrestaShopSettings()
        {
            //PrestaShop
            textBox_site.Text = ProjIO.GetUserSetting(Constants.PrestasopSiteURL);
            textBox_key.Text = ProjIO.GetUserSetting(Constants.PrestasopSiteAccessKey);
            textBox_site.TextChanged += (s, ev) =>
            {
                ProjIO.SaveUserSetting(Constants.PrestasopSiteURL, textBox_site.Text);
                ProjIO.SaveUserSetting(Constants.PrestasopSiteAccessKey, textBox_key.Text);
            };
            textBox_key.TextChanged += (s, ev) =>
            {
                ProjIO.SaveUserSetting(Constants.PrestasopSiteURL, textBox_site.Text);
                ProjIO.SaveUserSetting(Constants.PrestasopSiteAccessKey, textBox_key.Text);
            };
        }


        private void AmazonSettings()
        {
            //label_Amz_CompA.Text = ProjIO.GetUserSetting(Constants.AmazonCompACode);
            textBox_CompanyA_Key.Text = ProjIO.GetUserSetting(Constants.AmazonCompAKey);
            textBox_CompanyA_Secret.Text = ProjIO.GetUserSetting(Constants.AmazonCompASecret);
            textBox_CompanyA_Token.Text = ProjIO.GetUserSetting(Constants.AmazonCompASecret);
            
            //label_Amz_CompanyB.Text = ProjIO.GetUserSetting(Constants.AmazonCompBCode);
            textBox_CompanyB_Key.Text = ProjIO.GetUserSetting(Constants.AmazonCompBKey);
            textBox_CompanyB_Secret.Text = ProjIO.GetUserSetting(Constants.AmazonCompBSecret);
            textBox_CompanyB_Token.Text = ProjIO.GetUserSetting(Constants.AmazonCompBSecret);

            textBox_CompanyA_Key.TextChanged += (s, ev) =>  SaveAmzSettings(); 
            textBox_CompanyA_Secret.TextChanged += (s, ev) =>  SaveAmzSettings();
            textBox_CompanyA_Token.TextChanged += (s, ev) =>  SaveAmzSettings();
            
            textBox_CompanyB_Key.TextChanged += (s, ev) => SaveAmzSettings();
            textBox_CompanyB_Secret.TextChanged += (s, ev) => SaveAmzSettings();
            textBox_CompanyB_Token.TextChanged += (s, ev) => SaveAmzSettings();

            void SaveAmzSettings()
            {
                ProjIO.SaveUserSetting(Constants.AmazonCompAKey, textBox_CompanyA_Key.Text);
                ProjIO.SaveUserSetting(Constants.AmazonCompASecret, textBox_CompanyA_Secret.Text);
                ProjIO.SaveUserSetting(Constants.AmazonCompAToken, textBox_CompanyA_Token.Text);
                ProjIO.SaveUserSetting(Constants.AmazonCompBKey, textBox_CompanyB_Key.Text);
                ProjIO.SaveUserSetting(Constants.AmazonCompBSecret, textBox_CompanyB_Secret.Text);
                ProjIO.SaveUserSetting(Constants.AmazonCompBToken, textBox_CompanyB_Token.Text);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            //AdjustUI("Reset");
        }

        private void txtComp3Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComp4Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_ImportMap1_Click(object sender, EventArgs e)
        {
            ImportMapAndImages(txtComp1Code.Text);

        }

        private void btn_ImportMap2_Click(object sender, EventArgs e)
        {
            ImportMapAndImages(txtComp2Code.Text);
        }

        private void btn_emailSetup_Click(object sender, EventArgs e)
        {
            EmailSetup email = new EmailSetup();
            email.ShowDialog();
        }

      
        
        private async void ExportMap(string mapCode, bool exportLog, bool exportImgs, bool exportSnapshots)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                pbar.Visible = true;
                await ProjIO.ExportMap(mapCode, folderBrowserDialog.SelectedPath, exportLog, exportImgs, exportSnapshots,
                     () =>
                     {  // In case file already exists in target dir
                         (new AlertBox("Error", "File with same name exists in target directory, please choose another directory.")).ShowDialog();
                     },

                     () =>
                     {
                        //File exported
                         (new AlertBox("Info", "Exported file : " + mapCode + ".zip", isError: false)).ShowDialog(); ;
                     }
                     );
                pbar.Visible = false;
            }
        }


        private void ExportAllMaps(string mapCode1, string mapCode2, string mapCode3, string mapCode4, string mapCode5,
            bool exportLog, bool exportImgs, bool exportSnapshots, bool exportViaTelegram)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                pbar.Visible = true;
                ProjIO.ExportAllMaps(mapCode1, mapCode2, mapCode3, mapCode4, mapCode5,
                    folderBrowserDialog.SelectedPath, exportLog, exportImgs, exportSnapshots, exportViaTelegram,
                     (zipFile) => {
                         //ExportToTelegram(zipFile);
                         pbar.Visible = false;
                         (new AlertBox("Info", "Exported file : " + zipFile + ". Click below link to open.", isError: false, link:zipFile)).ShowDialog(); ; }
                    );


            }
        }

       

     

        private void ImportMapAndImages(string mapCode)
        {
           
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Project file|*.zip";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _map1File = openFileDialog.FileName;
                ProjIO.ImportMapAndImages(openFileDialog.FileName, mapCode, () => { },
                    (msg) => {
                        if (DialogResult.Yes == MessageBox.Show(msg, "File exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                            return true;
                        else
                            return false;
                    }, // file exists
                    (msg) => { MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); });//result
            }
            else return;
           
        }


        private void btn_exportMap1_Click(object sender, EventArgs e)
        {
            ExportProject(txtComp1Code.Text);
        }

        private void btn_exportMap2_Click(object sender, EventArgs e)
        {
            ExportProject(txtComp2Code.Text);
        }

        //private void btn_exportMap3_Click(object sender, EventArgs e)
        //{
        //    ExportProject(txtComp3Code.Text);
        //}

        //private void btn_exportMap4_Click(object sender, EventArgs e)
        //{
        //    ExportProject(txtComp4Code.Text);
        //}

        //private void btn_exportMap5_Click(object sender, EventArgs e)
        //{
        //    ExportProject(txtComp5Code.Text);
        //}

        private void ExportProject(string companyCode)
        {
            if(string.IsNullOrEmpty(companyCode))
                return;
            ExportProject ep = new ExportProject(companyCode);
            if (ep.ShowDialog() == DialogResult.OK)
            {
                ExportMap(companyCode, ep.IsLog, ep.IsImgs, ep.IsSnapshot);
            }
        }

        private void btn_ExportAll_Click(object sender, EventArgs e)
        {
            ExportProject ep = new ExportProject("");
            if (ep.ShowDialog() == DialogResult.OK)
            {
                ExportAllMaps(txtComp1Code.Text, txtComp2Code.Text, String.Empty, String.Empty, String.Empty,
                ep.IsLog, ep.IsImgs, ep.IsSnapshot, ep.IsTelegranExport
                );
            }
        }

        private void button_telegramSetup_Click(object sender, EventArgs e)
        {
            //TelegramSetup tSetp = new TelegramSetup(new ViewManager.VM_TelegramSetup());
            //tSetp.ShowDialog();
        }

        private void checkBox_TelegramLogging_CheckedChanged(object sender, EventArgs e)
        {
            //if(checkBox_TelegramLogging.Checked)
            //    Logger.EnableTelegramLogging();
            //else
            //    Logger.DisableTelegramLogging();
        }

        private void button_Amz_save_Click(object sender, EventArgs e)
        {
            //Mapping.AmazonInvColumnMapping.amazon_inv_report_asin = textBox_amz_asin.Text;
            //Mapping.AmazonInvColumnMapping.amazon_inv_report_sku = textBox_amz_sku.Text;
            //Mapping.AmazonInvColumnMapping.amazon_inv_report_price = textBox_amz_price.Text;
            //Mapping.AmazonInvColumnMapping.amazon_inv_report_sellerQuantity = textBox_amz_qty.Text;
            
        }

        private void button_launchStartUp_Click(object sender, EventArgs e)
        {
            var start = new Views.SetUp.StartUp(_companies);
            start.ShowDialog();

            LoadCompanyLabelTexts(); 
        }

       
    }
}
