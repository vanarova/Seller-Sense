using Decoders;
using InventoryUpdater.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryUpdater
{
    public partial class SetUp : Form
    {
        public SetUp()
        {
            InitializeComponent();
        }

        private void btn_baseMapGen_Click(object sender, EventArgs e)
        {
            HTMLToJSON.AngleSharpParse(File.ReadAllText("out_prices.html"));
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
           
            //make controls visible
            foreach (var item in pnl_Admin.Controls)
            {
                (item as Control).Visible = (txt_pwd.Text == "ADMIN))!@".ToLower());
            }
           
        }

        private void btnJsonExport_Click(object sender, EventArgs e)
        {
            string json = HTMLToJSON.GetJSON(
                HTMLToJSON.AngleSharpParse(File.ReadAllText(txt_htmlFile.Text))
                );
            File.WriteAllText("out.json", json);
        }

        private void btn_JSONExport_NoFormat_Click(object sender, EventArgs e)
        {
            string json = HTMLToJSON.GetJSON(
               HTMLToJSON.AngleSharpParse(File.ReadAllText(txt_htmlFile.Text))
               ,true);
            File.WriteAllText("out.json", json);
        }

        private void btnJsonConvertImgNamesasCodes_Click(object sender, EventArgs e)
        {
            //JsonConvert.des
        }
    }
}
