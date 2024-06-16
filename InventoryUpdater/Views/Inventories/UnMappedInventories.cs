using CommonUtil;
using SellerSense.Helper;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Views.Inventories
{
    public partial class UnMappedInventories : SfForm
    {
        private string title;
        private IList<string> unmappedInhouseCode;
        private IList<string> unmappedInv;
        public UnMappedInventories(string Title, IList<string> unmappedInhouseCode, IList<string> unmappedInv)
        {
            InitializeComponent();
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
            this.title = Title;
            this.unmappedInv = unmappedInv;
            this.unmappedInhouseCode = unmappedInhouseCode;
        }

        private void UnMappedInventories_Load(object sender, EventArgs e)
        {
            label_title.Text = $"Unmapped product codes in imported inventory file for: {title}";
            listBox_Inv.Items.Clear();
            listBox_InHouse.Items.Clear();

            foreach (var item in unmappedInhouseCode)
                listBox_InHouse.Items.Add(item);

            foreach (var item in unmappedInv)
                listBox_Inv.Items.Add(item);
        }

        private void sfButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sfButton_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file|*.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.CheckFileExists = true;
            saveFileDialog.CheckPathExists = true;

            DialogResult d = saveFileDialog.ShowDialog();
            if(d == DialogResult.OK && !string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                ProjIO.SaveListToFile(CreateFormattedList(), saveFileDialog.FileName);
            }
        }

        private List<string> CreateFormattedList()
        {
            List<string> formattedList = new List<string>();
            unmappedInhouseCode.Insert(0, "Un-mapped inhouse codes");
            unmappedInv.Insert(0, $"Un-mapped {title} inventory codes");
            formattedList.AddRange(unmappedInhouseCode);
            formattedList.Add("");
            formattedList.AddRange(unmappedInv);
            return formattedList;
        }

        
    }
}
