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

namespace SellerSense.Views
{
    public partial class MessagePopBox : Form
    {
        Action _callBackAction;
        string _message;
        string _callBackActionTitle;
        public MessagePopBox(string message, Action callBackAction=null, string callbackActionButtonTitle= "")
        {
            InitializeComponent();
            _message = message;
            _callBackAction = callBackAction;
            _callBackActionTitle = callbackActionButtonTitle;
            if (callBackAction != null)
                this._callBackAction = callBackAction;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MessagePopBox_Load(object sender, EventArgs e)
        {

           if (_callBackAction == null) //if call back is not assigned, hide button..
               button_Action1.Visible = false;
           button_Action1.Text = _callBackActionTitle;
           richTextBox_Message.Text = _message;

           // TelegramHighlight();
        }


        //private void TelegramHighlight()
        //{
        //    string outStock = "Out of Stock Items";
        //    richTextBox_Message.Text = richTextBox_Message.Text.Replace(outStock, "**" + outStock  + "**");
        //    string sstock = "Single Stock Items";
        //    richTextBox_Message.Text = richTextBox_Message.Text.Replace(sstock, "**" + sstock + "**");

        //}


        //private void HighlightText()
        //{
        //    string outStock = "Out of Stock Items";
        //    IEnumerable<int>  indexes = IndexOfAll(richTextBox_Message.Text, outStock);
        //    foreach (int start in indexes)
        //    {
        //        if (start >= 0)
        //        {
        //            richTextBox_Message.Select(start, outStock.Length);
        //            richTextBox_Message.SelectionFont =
        //                new Font(richTextBox_Message.Font, FontStyle.Bold);
        //            richTextBox_Message.SelectionBackColor = Color.Yellow;
        //        }
        //    }
            
        //}

        //private static IEnumerable<int> IndexOfAll(string sourceString, string subString)
        //{
        //    return Regex.Matches(sourceString, subString).Cast<Match>().Select(m => m.Index);
        //}

        private void button_Action1_Click(object sender, EventArgs e)
        {
            _callBackAction();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
