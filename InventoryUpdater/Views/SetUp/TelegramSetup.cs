using SellerSense.ViewManager;
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
    internal partial class TelegramSetup : Form
    {
        public string BotToken { get; set; }
        public string ChatId { get; set; }

        public TelegramSetup(VM_TelegramSetup vm_Telegram)
        {
            InitializeComponent();
            vm_Telegram.AssignViewManager(this);
        }

       
    }
}
