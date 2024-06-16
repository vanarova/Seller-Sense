using CommonUtil;
//using Google.Cloud.Firestore;
using Newtonsoft.Json;
using SellerSense.Helper;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense
{
    public partial class Registration :  SfForm
    {

        // private string k = "s23df5898d4e4455beer8eg7831t3178";
        // private string LicDetails;
        // public Registration()
        // {
        //     InitializeComponent();
        //     LicDetails = LoadUserLicDetails();
        //     this.Style.TitleBar.Height = 45;
        //     FontFamily fontFamily = new FontFamily("Calibri");
        //     Font font = new Font(
        //        fontFamily,
        //        24,
        //        FontStyle.Regular,
        //        GraphicsUnit.Pixel);
        //     this.Style.TitleBar.ForeColor = Color.White;
        //     this.Style.TitleBar.Font = font;

        //     this.Style.TitleBar.BackColor = Constants.Theme.BorderColor;
        //     this.Style.Border.Color = Constants.Theme.BorderColor;
        //     this.Style.InactiveBorder.Color = Constants.Theme.BorderColor;
        //     this.Style.Border.Width = Constants.Theme.MainFormBorderWidth;
        //     this.Style.InactiveBorder.Width = Constants.Theme.MainFormBorderWidth;
        // }

         private async void button_ok_Click(object sender, EventArgs e)
         {
        //     bool error = (!string.IsNullOrEmpty(errorProvider_lastName.GetError(textBox_lastName)))
        //         && (!string.IsNullOrEmpty(errorProvider_firstName.GetError(textBox_firstName)))
        //          && (!string.IsNullOrEmpty(errorProvider_companyName.GetError(textBox_companyName)))
        //           && (!string.IsNullOrEmpty(errorProvider_contactNo.GetError(textBox_contactNo)))
        //            && (!string.IsNullOrEmpty(errorProvider_EMail.GetError(textBox_Email)))
        //            && (!string.IsNullOrEmpty(errorProvider_BillingAddress.GetError(textBox_Address)));
        //     error = string.IsNullOrWhiteSpace(textBox_lastName.Text) ||
        //         string.IsNullOrWhiteSpace(textBox_firstName.Text) ||
        //         string.IsNullOrWhiteSpace(textBox_contactNo.Text) ||
        //         string.IsNullOrWhiteSpace(textBox_companyName.Text) ||
        //         string.IsNullOrWhiteSpace(textBox_Email.Text) ||
        //         string.IsNullOrWhiteSpace(textBox_Address.Text);
        //     if (error)
        //         label_msg.Text = "Please fill all fields in correct format && press Ok";
        //     else
        //     {
        //         AllSubControls(this).OfType<TextBox>().ToList()
        //             .ForEach(o => o.Enabled = false);
        //         progressBar_Register.Visible = true;
        //         label_connecting.Visible = true;
        //         Register();
        //         await Delay(3000);
        //         progressBar_Register.Visible = false;
        //         label_connecting.Visible = false;
        //         //this.Close();

        //     }
         }

        // private async Task<bool> Verify()
        // {
        //     Identity.RegistrationHelper registerationVerifyObj = await Identity.RegistrationHelper.Verify();
        //     if (registerationVerifyObj == null)
        //         return false;
        //     if (string.Equals(registerationVerifyObj.ContactFirstName, textBox_firstName.Text) &&
        //         string.Equals(registerationVerifyObj.Email, textBox_Email.Text) &&
        //         string.Equals(registerationVerifyObj.BusinessName, textBox_companyName.Text)
        //         )
        //     { return true; }
        //     else return false;
        // }

        // private async void Register()
        // {
        //     Identity.RegistrationHelper registerationHelper = new Identity.RegistrationHelper();
        //     registerationHelper.ContactFirstName = textBox_firstName.Text;
        //     registerationHelper.ContactLastName = textBox_lastName.Text;
        //     registerationHelper.ContactNumber = textBox_contactNo.Text;
        //     registerationHelper.BusinessName = textBox_companyName.Text;
        //     registerationHelper.Address = textBox_Address.Text;
        //     registerationHelper.Email = textBox_Email.Text;
        //     try
        //     {
        //         Identity.RegistrationHelper.Register(registerationHelper);
        //         await Delay(3000);
        //         var result = await Verify();
        //         //Here call verify
        //         if (result)
        //         {
        //             label_status.Visible = true;
        //             label_status.Text = "License request received successfully. Please wait for verification.";
        //             string sjson= JsonConvert.SerializeObject(registerationHelper);
        //             string ejson= En.EncryptString(k,sjson);
        //             SetUserLicDetails(ejson);
        //         }
        //         else
        //         {
        //             label_status.Visible = true;
        //             label_status.ForeColor = Color.Blue;
        //             label_status.Text = "Error receiving license request.";
        //         }
        //         //label_status.Visible = 
        //     }catch (Exception ex)
        //     {
        //         label_status.Visible = true;
        //         label_status.ForeColor = Color.Blue;
        //         label_status.Text = "Error receiving license request.";
        //     }
        // }


        // public async Task Delay(int secs)
        // {
        //     await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
        //     {
        //         Console.WriteLine("Start");
        //         await Task.Delay(secs);
        //         Console.WriteLine("Done");
        //     });
        //     Console.WriteLine("All done");
        // }


        // private void EnableLicInfoButton()
        // {
        //     //button_licInfo.Enabled = true;
        // }


        // private static IEnumerable<Control> AllSubControls(Control control)
        //     => Enumerable.Repeat(control, 1)
        //.Union(control.Controls.OfType<Control>()
        //                       .SelectMany(AllSubControls)
        //      );



         private void button_cancel_Click(object sender, EventArgs e)
         {
        //     this.Close();
         }

         private void textBox_firstName_Validated(object sender, EventArgs e)
         {
        //     if (RequiredAndTextOnly(textBox_firstName.Text))
        //         errorProvider_firstName.SetError(textBox_firstName, String.Empty);
        //     else
        //         errorProvider_firstName.SetError(textBox_firstName, "Only alphabets are allowed");
         }

        // private bool RequiredAndTextOnly(string text)
        // {
        //     if(string.IsNullOrEmpty(text))
        //         return false;
        //     Regex regex = new Regex("^[a-zA-Z]+$");
        //     bool match = regex.IsMatch(text);
        //     if (!match)
        //         return false;
        //     return true;
        // }

        // private static bool IsValidEmail(string email)
        // {
        //     // Define the regular expression pattern for a simple email validation
        //     string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        //     // Create a Regex object
        //     Regex regex = new Regex(pattern);

        //     // Use the IsMatch method to test the email against the pattern
        //     return regex.IsMatch(email);
        // }

         //private static bool IsValidNumericWithPlusAndSpace(string input)
         //{

        //     string pattern = "^[+\\d\\s]+$";
        //     Regex regex = new Regex(pattern);

        //     return regex.IsMatch(input);
         //}

         private void textBox_lastName_Validated(object sender, EventArgs e)
        {
        //     if (RequiredAndTextOnly(textBox_lastName.Text))
        //         errorProvider_lastName.SetError(textBox_lastName, String.Empty);
        //     else
        //         errorProvider_lastName.SetError(textBox_lastName, "Only alphabets are allowed");
         }

         private void textBox_companyName_Validated(object sender, EventArgs e)
        {
        //     if (RequiredAndTextOnly(textBox_companyName.Text))
        //         errorProvider_companyName.SetError(textBox_companyName, String.Empty);
        //     else
        //         errorProvider_companyName.SetError(textBox_companyName, "Only alphabets are allowed");
         }

         private void textBox_contactNo_Validated(object sender, EventArgs e)
         {
        //     if(IsValidNumericWithPlusAndSpace(textBox_contactNo.Text))
        //         errorProvider_contactNo.SetError(textBox_contactNo, String.Empty);
        //     else
        //         errorProvider_contactNo.SetError(textBox_contactNo, "Only numbers and + are allowed");
         }

         private void textBox_Email_Validated(object sender, EventArgs e)
         {
        //     if (IsValidEmail(textBox_Email.Text))
        //         errorProvider_EMail.SetError(textBox_Email, String.Empty);
        //     else
        //         errorProvider_EMail.SetError(textBox_Email, "Only valid email address are allowed");
         }

         private void textBox_Address_Validated(object sender, EventArgs e)
         {
        //     if (textBox_Address.Text.Length>0)
        //         errorProvider_BillingAddress.SetError(textBox_Address, String.Empty);
        //     else
        //         errorProvider_BillingAddress.SetError(textBox_Address, "Billing address required.");
         }

         private void button_licInfo_Click(object sender, EventArgs e)
         {

         }

         private void Registration_Load(object sender, EventArgs e)
         {
        //     if (!string.IsNullOrEmpty(LicDetails))
        //     {
        //         AllSubControls(this).OfType<TextBox>().ToList()
        //             .ForEach(o => o.Enabled = false);
        //         AllSubControls(this).OfType<Button>().ToList()
        //             .ForEach(o => o.Enabled = false);
        //         FillFormData(LicDetails);
        //     }
        //     //DisableAllControls();
         }

        // private void FillFormData(string LicDetails)
        // {
        //     Identity.RegistrationHelper reg = JsonConvert.DeserializeObject<Identity.RegistrationHelper>(LicDetails);
        //     textBox_firstName.Text = reg.ContactFirstName;
        //     textBox_lastName.Text = reg.ContactLastName;
        //     textBox_contactNo.Text = reg.ContactNumber;
        //     textBox_companyName.Text = reg.BusinessName;
        //     textBox_Address.Text = reg.Address;
        //         textBox_Email.Text=reg.Email;


        // }

        // private string LoadUserLicDetails()
        // {
        //    string ejson = ProjIO.GetUserSetting("lic");
        //     if (string.IsNullOrEmpty(ejson))
        //         return string.Empty;
        //    string json = En.DecryptString(k, ejson);
        //    return json;
        // }

        // private void SetUserLicDetails(string licValue)
        // {
        //     licValue = En.EncryptString(k, licValue);
        //     ProjIO.SaveUserSetting("lic",licValue);
        // }

        private void progressBar_Register_Click(object sender, EventArgs e)
        {

        }
    }
}
