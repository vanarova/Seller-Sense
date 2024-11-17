using CommonUtil;
using SellerSense.Model;
using SellerSense.Model.Invoice;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Views.Products
{
    public partial class ProductInvoice :  SfForm
    {
        M_Product m_product;
        M_Invoice m_Invoice;

        public ProductInvoice(M_Product mproduct, M_Invoice invoice)
        {
            InitializeComponent();
            this.Style.TitleBar.ForeColor = Color.White;
            this.Style.TitleBar.BackColor = Constants.Theme.BorderColor;
            this.Style.Border.Color = Constants.Theme.BorderColor;
            this.Style.InactiveBorder.Color = Constants.Theme.BorderColor;
            this.Style.Border.Width = Constants.Theme.BorderWidth;
            this.Style.InactiveBorder.Width = Constants.Theme.BorderWidth;
            m_product = mproduct;
            m_Invoice = invoice;
            m_Invoice.LineItems.Clear();
        }

        private void button_TemplateDir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start($"{ProjIO.DefaultWorkspaceLocation()}");
            }
            catch (Exception ex)
            {
                AlertBox ab = new AlertBox("Error","Error opening template location", ex);
                ab.ShowDialog();
            }
        }

        private void ProductInvoice_Load(object sender, EventArgs e)
        {
            label_SelectedProdCount.Text = "Selected items :" + m_Invoice.LineQty.Count.ToString();
        }


        private (string,string) GetProductDetails(string inhouseCode)
        {
            var prod = m_product._productEntries.FirstOrDefault(x => x.InHouseCode == inhouseCode);
            if (prod != null)
            {
                return (prod.Title, prod.SellingPrice);
            }
            return (null,null);
        }

        private void sfButton_Ok_Click(object sender, EventArgs e)
        {
            FillProductLineItems();
            m_Invoice.Date = dateTimePicker1.Value;
            m_Invoice.BillTo = richTextBox_BillTo.Text;
            m_Invoice.ShipTo = richTextBox_ShipTo.Text;
            m_Invoice.Comments = richTextBox_Comments.Text;
            m_Invoice.RefNo = textBox_RefID.Text;
            m_Invoice.InvoiceID = textBox_InvoiceID.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FillProductLineItems()
        {
            foreach (var item in m_Invoice.LineQty.Keys)
            {
               (string title, string sprice) = GetProductDetails(item);
                m_Invoice.LineItems.Add(new M_Invoice.LineItem() {Code=item, Name=title, Price=sprice, Quantity= m_Invoice.LineQty[item] });
            }
        }

        private void sfButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
