using InventoryUpdater.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryUpdater
{
    public partial class EmailSetup : Form
    {
        public EmailSetup()
        {
            InitializeComponent();
        }

        //TODO Add Email model file
        private void btn_SendEmail_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void SendEmail()
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Port = Convert.ToInt16(txt_ServerPort.Text.Trim());
                smtpClient.Host = txt_SMTP.Text.Trim();
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(txt_SenderEmail.Text.Trim(), txt_SenderPwd.Text.Trim());

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(txt_SenderEmail.Text.Trim());
                mailMessage.To.Add(txt_RecipentEmail.Text.Trim());
                mailMessage.Subject = txt_Subject.Text.Trim();
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = txt_Body.Text.Trim();

                string fattach1; string fattach2;
                ProjIO.CleanLocalAppData();
                (fattach1, fattach2, _, _, _) = ProjIO.RenameAppendCompanyCodeAndCopyFilesToTempDir(
                    ProjIO.GetCompany1MapFilePathAndCheckFileExists(),
                    ProjIO.GetCompany2MapFilePathAndCheckFileExists());

                if (!string.IsNullOrEmpty(fattach1))
                    mailMessage.Attachments.Add(new Attachment(fattach1));
                if (!string.IsNullOrEmpty(fattach2))
                    mailMessage.Attachments.Add(new Attachment(fattach2));

                //if(!string.IsNullOrEmpty(ProjIO.GetCompany1MapFilePathAndCheckFileExists()))
                //    mailMessage.Attachments.Add(new Attachment(ProjIO.GetCompany1MapFilePathAndCheckFileExists()));
                //if (!string.IsNullOrEmpty(ProjIO.GetCompany2MapFilePathAndCheckFileExists()))
                //    mailMessage.Attachments.Add(new Attachment(ProjIO.GetCompany2MapFilePathAndCheckFileExists()));

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

    }
}
