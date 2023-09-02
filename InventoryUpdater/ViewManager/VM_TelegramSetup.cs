using SellerSense.Helper;
using SellerSense.Views.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
