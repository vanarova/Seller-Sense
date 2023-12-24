using SellerSense.Helper;
using SellerSense.Views;
using SellerSense.Views.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelegramBot;

namespace SellerSense.ViewManager
{
    internal class VM_TelegramSetup : IManageForm
    {
        TelegramSetup _v_TelegramSetup;
        public string BotId { get; set; }
        public string ChatId { get; set; }
        

        public void AssignView(Form view)
        {
            _v_TelegramSetup = view as TelegramSetup;
            HandleTeleGramSetUpEvents();
        }

        private void HandleTeleGramSetUpEvents()
        {
            _v_TelegramSetup.Load += (s, e) => {
                GetTelegramSettings();
                _v_TelegramSetup.textBox_BotToken.Text = BotId;
                _v_TelegramSetup.textBox_chatId.Text = ChatId ;

            };
            _v_TelegramSetup.button_Cancel.Click += (s, e) => _v_TelegramSetup.Close();
            _v_TelegramSetup.button_Ok.Click += (s, e) => {
                BotId = _v_TelegramSetup.textBox_BotToken.Text;
                ChatId = _v_TelegramSetup.textBox_chatId.Text;
                SaveTelegramSettings();
                _v_TelegramSetup.Close();
            };

            _v_TelegramSetup.button_test_connection.Click += async(s, e) => {
                string msg = string.Empty;
                try
                {
                    long.Parse(ChatId);
                    msg = await Messenger.SendTelegramMessage(_v_TelegramSetup.textBox_BotToken.Text, long.Parse(_v_TelegramSetup.textBox_chatId.Text), "Test message");
                }catch (Exception ex)
                {
                    AlertBox abox = new AlertBox("Error", "Unexpected Error occurred " + ex.Message);
                    abox.ShowDialog();
                }finally
                {
                    AlertBox abox = new AlertBox("Info", "Message returned from Telegram: " + msg,false);
                    abox.ShowDialog();
                } 
            };

        }

        private void SaveTelegramSettings()
        {
            ProjIO.SaveUserSetting(Constants.TelegramSettings.BotID.ToString(), BotId);
            ProjIO.SaveUserSetting(Constants.TelegramSettings.ChatID.ToString(), ChatId);
        }

        private void GetTelegramSettings()
        {
           BotId= ProjIO.GetUserSetting(Constants.TelegramSettings.BotID.ToString());
           ChatId = ProjIO.GetUserSetting(Constants.TelegramSettings.ChatID.ToString());
        }
    }
}
