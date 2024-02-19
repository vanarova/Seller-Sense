using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Syncfusion.WinForms.Controls;

namespace Updates
{
    public partial class News : SfForm
    {
        public string NewsText { get; set; }

        public News(string newsText)
        {
            InitializeComponent();

            this.Style.TitleBar.ForeColor = Color.White;
            this.Style.TitleBar.BackColor = Common.Constants.Theme.BorderColor;
            this.Style.Border.Color = Constants.Theme.BorderColor;
            this.Style.InactiveBorder.Color = Constants.Theme.BorderColor;
            this.Style.Border.Width = Constants.Theme.BorderWidth;
            this.Style.InactiveBorder.Width = Constants.Theme.BorderWidth;
            NewsText = newsText;
        }

        private void News_Load(object sender, EventArgs e)
        {

            textBox_news.Text = NewsText;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
