using Google.Cloud.Firestore;
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

        private string k = "s23df5898d4e4455beer8eg7831t3178";
        private string LicDetails;
        public Registration()
        {
            InitializeComponent();
            LicDetails = LoadUserLicDetails();
            this.Style.TitleBar.Height = 45;
            FontFamily fontFamily = new FontFamily("Calibri");
            Font font = new Font(
               fontFamily,
               24,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            this.Style.TitleBar.ForeColor = Color.White;
            this.Style.TitleBar.Font = font;

            this.Style.TitleBar.BackColor = Constants.Theme.BorderColor;
            this.Style.Border.Color = Constants.Theme.BorderColor;
            this.Style.InactiveBorder.Color = Constants.Theme.BorderColor;
            this.Style.Border.Width = Constants.Theme.MainFormBorderWidth;
            this.Style.InactiveBorder.Width = Constants.Theme.MainFormBorderWidth;
        }

        private async void button_ok_Click(object sender, EventArgs e)
        {
            bool error = (!string.IsNullOrEmpty(errorProvider_lastName.GetError(textBox_lastName)))
                && (!string.IsNullOrEmpty(errorProvider_firstName.GetError(textBox_firstName)))
                 && (!string.IsNullOrEmpty(errorProvider_companyName.GetError(textBox_companyName)))
                  && (!string.IsNullOrEmpty(errorProvider_contactNo.GetError(textBox_contactNo)))
                   && (!string.IsNullOrEmpty(errorProvider_EMail.GetError(textBox_Email)))
                   && (!string.IsNullOrEmpty(errorProvider_BillingAddress.GetError(textBox_Address)));
            error = string.IsNullOrWhiteSpace(textBox_lastName.Text) ||
                string.IsNullOrWhiteSpace(textBox_firstName.Text) ||
                string.IsNullOrWhiteSpace(textBox_contactNo.Text) ||
                string.IsNullOrWhiteSpace(textBox_companyName.Text) ||
                string.IsNullOrWhiteSpace(textBox_Email.Text) ||
                string.IsNullOrWhiteSpace(textBox_Address.Text);
            if (error)
                label_msg.Text = "Please fill all fields in correct format && press Ok";
            else
            {
                AllSubControls(this).OfType<TextBox>().ToList()
                    .ForEach(o => o.Enabled = false);
                progressBar_Register.Visible = true;
                label_connecting.Visible = true;
                Register();
                await Delay(3000);
                progressBar_Register.Visible = false;
                label_connecting.Visible = false;
                //this.Close();

            }
        }

        private async Task<bool> Verify()
        {
            Identity.RegistrationHelper registerationVerifyObj = await Identity.RegistrationHelper.Verify();
            if (registerationVerifyObj == null)
                return false;
            if (string.Equals(registerationVerifyObj.ContactFirstName, textBox_firstName.Text) &&
                string.Equals(registerationVerifyObj.Email, textBox_Email.Text) &&
                string.Equals(registerationVerifyObj.BusinessName, textBox_companyName.Text)
                )
            { return true; }
            else return false;
        }
        
        private async void Register()
        {
            Identity.RegistrationHelper registerationHelper = new Identity.RegistrationHelper();
            registerationHelper.ContactFirstName = textBox_firstName.Text;
            registerationHelper.ContactLastName = textBox_lastName.Text;
            registerationHelper.ContactNumber = textBox_contactNo.Text;
            registerationHelper.BusinessName = textBox_companyName.Text;
            registerationHelper.Address = textBox_Address.Text;
            registerationHelper.Email = textBox_Email.Text;
            try
            {
                Identity.RegistrationHelper.Register(registerationHelper);
                await Delay(3000);
                var result = await Verify();
                //Here call verify
                if (result)
                {
                    label_status.Visible = true;
                    label_status.Text = "License request received successfully. Please wait for verification.";
                    string sjson= JsonConvert.SerializeObject(registerationHelper);
                    string ejson= En.EncryptString(k,sjson);
                    SetUserLicDetails(ejson);
                }
                else
                {
                    label_status.Visible = true;
                    label_status.ForeColor = Color.Blue;
                    label_status.Text = "Error receiving license request.";
                }
                //label_status.Visible = 
            }catch (Exception ex)
            {
                label_status.Visible = true;
                label_status.ForeColor = Color.Blue;
                label_status.Text = "Error receiving license request.";
            }
        }

        //private static string Base64Decode(string base64EncodedData)
        //{
        //    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        //    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        //}

        //private static string Base64Encode(string plainText)
        //{
        //    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        //    return System.Convert.ToBase64String(plainTextBytes);
        //}

        //private async Task GetLInfoAsync()
        //{
        //    string encoded = "eyAidHlwZSI6ICJzZXJ2aWNlX2FjY291bnQiLCAgInByb2plY3RfaWQiOiAic2VsbGVyIC0gc2Vuc2UgLSBsaWNlbnNlIiwgICJwcml2YXRlX2tleV9pZCI6ICI2YzljNTBlOTk2MjA1YWU0NDU0NmI5YzZlNjY0MjU0N2UyMTJmNDdlIiwgICJwcml2YXRlX2tleSI6ICItLS0tLUJFR0lOIFBSSVZBVEUgS0VZLS0tLS1cbk1JSUV2UUlCQURBTkJna3Foa2lHOXcwQkFRRUZBQVNDQktjd2dnU2pBZ0VBQW9JQkFRREtTczE3emcrQ3oyY0FcbkJZTG1sTUFDSGdReng5eXBWcDQyeFdWSW4rend0bEFIeTl4R2c2VS90aGVNMG9YYXZVR0ZoYmJkYzdoa0pPdUhcblA1cFo2dXFBVllWNWpOa0UyVnltMmVyVURLbVJkRmZQSTFCaW9lM0RQRHJPSm1LZkw4TFpBankrNjlZd21sMzJcbldwbjN4NUFuMStUR3dsYit5cmV3K0lKMGJ5V29LazQwZzVrWmtKVUFZblEwOGtRWmpJVWFxaVljWmI2SnRHNUhcbklOZ2YwT092U1ZYVEVWazNPdXRHVjhhZG1oSHhpbUwyanlJcDJYb09uQVpoYVB6ZlJzM2gyZTcwMVN6dEhOWlFcbjU1QmQzdERCenl3T1J4MUZyREZLWkVjbEZPaXY3Z1BjZHA1eUV0NXFKTUpPYkY2S0dYNHI0UUFHTmdjQXg5T2VcblhiMWtodmFSQWdNQkFBRUNnZ0VBQi8vdUtUY21kWUVsa09wMjRTN1kyc0NVZ0paMjFVYkMwQlpOYllJL0Nzd2ZcbjVUWUljSXl1VTFNY2NtNEZHM2ZNWkhjTHFxMWp5V2lOSEtLdEZFRWFLOC90L01iL1VrMzArRGR5RGhlUDJWdmpcbktOS3NBREdJZ3pYeG1xTkpsME5ha28zQVNKblBsU21XbllwYTBFSFc0MTk2R1dyWUtVQnJwQnJJd0dsZ2tTcEVcbm1YQ3BYKzlmZWFoTmRqYjYyNE5JNG5oQ3RtZGtsTlRlK05rdzdER3kycTJRbGV5ZER4cDFyQVBnMnFLdnlXK2VcbjNHK3VYc0puU1piNGVYd0E3ZVdHbklVVFdTbk1YOVNmTmVRbzNrYTJObFJxRHhPNDA0SlpUd0tnaDRwdEh4dTRcbjRlSFhzREVPM09iM1BSNkNvejZUUjJDQjVHd25vNXRLbTFtTEEvbFo0UUtCZ1FEd3F1K1VxVm9TZDA4LzlFU3ZcbmQwWmRrZmtxZ2JFa1JCdFhralowb2dib1N0TjB3OWFyc25lWUFqMmdHYnVycVE5dUluWUw2NVdHc1FDdzFOVE1cbkRMNlg3eDRmNjlGaE42NHJ0anpnUTVXNTlHQ0cvN1hSbDhRWHQ5bThjMTQweENqdThJQTNrMVBqUWF4VzBBK3NcbmpEQ1RRcXlhL1FFUEZZUWZnYXNlZndIbnNRS0JnUURYTGYrSHNwd3NTWmh4Wm5qcHJQdkhiMzBnRDhWYVh5TDdcbmxUOWNHYjhXUnpsbEswbDRxM25HNEFMVHhPcHdoT2QxYUFOTkNKSko3cXcvNXg5d01SVysydkRRMkYxbXpxb0NcblQ1dmFFaVFNZUUrSTQwQXFiN28vaDNqYzVieVd0MjFYK3pINTVBQUcyVDVCeWZCdlJHd0hwMWp6NWsyUVo4ZTVcbkhIRXhxbWlVNFFLQmdHZnNxSUE5a1JPZ1NheUlRcEN5cE1RTElObG1INlJWZEtrZ0RqdlhLN3hyYzF4Y3BQcUhcbm1uVWRvcGJjQmRwZXFyY1lVbmxiUmJwZi9MaGZiM1NkbkQvbmxjNmErbE5Ndy8xRU9JMXZJZHltMW5mMVBBSkJcbjB2K2ErSDhVSW40T3BzNW5ORGJMZTlJS3JlemU4NlhDODhialo3MlZ1enRVUXpXSHZPanlWMVJCQW9HQWF0OVhcbnVPZ0hGU0FBYk9JK1Q2RXc5QjcxZ0lVVXVndmliaDMwZUNQNWVuRXBtb3ZqVStHbS9CV3FrYytOdVJEcGZMQ0tcbll5cE1yaGV5eVpKYlZQZXNHenpXdW9PYjhFSFl3b2tUbVQzRlZjUXpqSU9DRFJHczZYeTVsTTB0MjVXQzQxM0pcbnRwbDlRZW1JT0ZpNTZDbU5sa2VSc0tIRUNHTGpHWmQ4eVBRZ09VRUNnWUVBM0luaGZDTmFIYjhra1FWOTBsLzJcbldTVFhNaWFPRWVoVG04dEZlYk5WOVRVcWhlV1BXUXBReTYxNGIyb1cyNG9WZTZIYlZaZnJWb0xtdVlHRE5CTVpcbjJOTXNub213OXZ3L2dwWlYyWUUxZjRKdFV5ZVBvUGk4OHR1bHR5TXdKWi9IN0c5UTU5L2pVdHR4UE43b3VnNkVcbjZ5TVdJRHFNaUNrVDdYM0ZUQzlWOHR3PVxuLS0tLS1FTkQgUFJJVkFURSBLRVktLS0tLVxuIiwgICJjbGllbnRfZW1haWwiOiAiZmlyZWJhc2UtYWRtaW5zZGsteGxobTNAc2VsbGVyLXNlbnNlLWxpY2Vuc2UuaWFtLmdzZXJ2aWNlYWNjb3VudC5jb20iLCAgImNsaWVudF9pZCI6ICIxMTI2ODkwMTUyOTExMTA5MTM4ODMiLCAgImF1dGhfdXJpIjogImh0dHBzOi8vYWNjb3VudHMuZ29vZ2xlLmNvbS9vL29hdXRoMi9hdXRoIiwgICJ0b2tlbl91cmkiOiAiaHR0cHM6Ly9vYXV0aDIuZ29vZ2xlYXBpcy5jb20vdG9rZW4iLCAgImF1dGhfcHJvdmlkZXJfeDUwOV9jZXJ0X3VybCI6ICJodHRwczovL3d3dy5nb29nbGVhcGlzLmNvbS9vYXV0aDIvdjEvY2VydHMiLCAgImNsaWVudF94NTA5X2NlcnRfdXJsIjogImh0dHBzOi8vd3d3Lmdvb2dsZWFwaXMuY29tL3JvYm90L3YxL21ldGFkYXRhL3g1MDkvZmlyZWJhc2UtYWRtaW5zZGsteGxobTMlNDBzZWxsZXItc2Vuc2UtbGljZW5zZS5pYW0uZ3NlcnZpY2VhY2NvdW50LmNvbSIsICAidW5pdmVyc2VfZG9tYWluIjogImdvb2dsZWFwaXMuY29tIn0=";
        //    string decodedKey = Base64Decode(encoded);

        //    var firestoreDb = new FirestoreDbBuilder
        //    {
        //        ProjectId = "seller-sense-license",
        //        JsonCredentials = decodedKey
        //    }.Build();

        //    DocumentReference dbref = firestoreDb.Collection("lics").Document("tV7bQx9hMB3lJOzA2ops");
        //    DocumentSnapshot dbSnap = await dbref.GetSnapshotAsync();
        //    if (dbSnap.Exists)
        //    {
        //        var obj = dbSnap.ToDictionary();
        //    }
        //    Dictionary<string, object> updates = new Dictionary<string, object>
        //        {
        //            { "update", "updateTest" }
        //        };
        //    await dbref.UpdateAsync(updates);
        //}

        public async Task Delay(int secs)
        {
            await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
            {
                Console.WriteLine("Start");
                await Task.Delay(secs);
                Console.WriteLine("Done");
            });
            Console.WriteLine("All done");
        }


        private void EnableLicInfoButton()
        {
            //button_licInfo.Enabled = true;
        }


        private static IEnumerable<Control> AllSubControls(Control control)
            => Enumerable.Repeat(control, 1)
       .Union(control.Controls.OfType<Control>()
                              .SelectMany(AllSubControls)
             );


        //private void DisableAllControls(ControlCollection controls)
        //{
        //    foreach (var ctrl in controls)
        //    {
        //        if (ctrl is TextBox)
        //            (ctrl as TextBox).Enabled = false;
        //        if (ctrl is Button)
        //            (ctrl as Button).Enabled = false;

        //        if ((ctrl as Control).Controls.Count > 0)
        //            DisableAllControls((ctrl as ControlCollection));
        //    } 

        //}

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_firstName_Validated(object sender, EventArgs e)
        {
            if (RequiredAndTextOnly(textBox_firstName.Text))
                errorProvider_firstName.SetError(textBox_firstName, String.Empty);
            else
                errorProvider_firstName.SetError(textBox_firstName, "Only alphabets are allowed");
        }

        private bool RequiredAndTextOnly(string text)
        {
            if(string.IsNullOrEmpty(text))
                return false;
            Regex regex = new Regex("^[a-zA-Z]+$");
            bool match = regex.IsMatch(text);
            if (!match)
                return false;
            return true;
        }

        private static bool IsValidEmail(string email)
        {
            // Define the regular expression pattern for a simple email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Create a Regex object
            Regex regex = new Regex(pattern);

            // Use the IsMatch method to test the email against the pattern
            return regex.IsMatch(email);
        }

        private static bool IsValidNumericWithPlusAndSpace(string input)
        {

            string pattern = "^[+\\d\\s]+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(input);
        }

        private void textBox_lastName_Validated(object sender, EventArgs e)
        {
            if (RequiredAndTextOnly(textBox_lastName.Text))
                errorProvider_lastName.SetError(textBox_lastName, String.Empty);
            else
                errorProvider_lastName.SetError(textBox_lastName, "Only alphabets are allowed");
        }

        private void textBox_companyName_Validated(object sender, EventArgs e)
        {
            if (RequiredAndTextOnly(textBox_companyName.Text))
                errorProvider_companyName.SetError(textBox_companyName, String.Empty);
            else
                errorProvider_companyName.SetError(textBox_companyName, "Only alphabets are allowed");
        }

        private void textBox_contactNo_Validated(object sender, EventArgs e)
        {
            if(IsValidNumericWithPlusAndSpace(textBox_contactNo.Text))
                errorProvider_contactNo.SetError(textBox_contactNo, String.Empty);
            else
                errorProvider_contactNo.SetError(textBox_contactNo, "Only numbers and + are allowed");
        }

        private void textBox_Email_Validated(object sender, EventArgs e)
        {
            if (IsValidEmail(textBox_Email.Text))
                errorProvider_EMail.SetError(textBox_Email, String.Empty);
            else
                errorProvider_EMail.SetError(textBox_Email, "Only valid email address are allowed");
        }

        private void textBox_Address_Validated(object sender, EventArgs e)
        {
            if (textBox_Address.Text.Length>0)
                errorProvider_BillingAddress.SetError(textBox_Address, String.Empty);
            else
                errorProvider_BillingAddress.SetError(textBox_Address, "Billing address required.");
        }

        private void button_licInfo_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LicDetails))
            {
                AllSubControls(this).OfType<TextBox>().ToList()
                    .ForEach(o => o.Enabled = false);
                AllSubControls(this).OfType<Button>().ToList()
                    .ForEach(o => o.Enabled = false);
                FillFormData(LicDetails);
            }
            //DisableAllControls();
        }

        private void FillFormData(string LicDetails)
        {
            Identity.RegistrationHelper reg = JsonConvert.DeserializeObject<Identity.RegistrationHelper>(LicDetails);
            textBox_firstName.Text = reg.ContactFirstName;
            textBox_lastName.Text = reg.ContactLastName;
            textBox_contactNo.Text = reg.ContactNumber;
            textBox_companyName.Text = reg.BusinessName;
            textBox_Address.Text = reg.Address;
                textBox_Email.Text=reg.Email;

            //registerationHelper.ContactFirstName = textBox_firstName.Text;
            //registerationHelper.ContactLastName = textBox_lastName.Text;
            //registerationHelper.ContactNumber = textBox_contactNo.Text;
            //registerationHelper.BusinessName = textBox_companyName.Text;
            //registerationHelper.Address = textBox_Address.Text;
            //registerationHelper.Email = textBox_Email.Text;
        }

        private string LoadUserLicDetails()
        {
           string ejson = ProjIO.GetUserSetting("lic");
            if (string.IsNullOrEmpty(ejson))
                return string.Empty;
           string json = En.DecryptString(k, ejson);
           return json;
        }

        private void SetUserLicDetails(string licValue)
        {
            licValue = En.EncryptString(k, licValue);
            ProjIO.SaveUserSetting("lic",licValue);
        }

        private void progressBar_Register_Click(object sender, EventArgs e)
        {

        }
    }
}
