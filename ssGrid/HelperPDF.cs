using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.WinForms.DataGridConverter.Events;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Pdf;

namespace ssGrid
{
    public class HelperPDF
    {


        /// <summary>
        /// Exports the SfDataGrid to PDF.
        /// </summary>
        public static void ExportToPDF(object sender, EventArgs e)
        {
            PdfExportingOptions exportingOptions = new PdfExportingOptions();
            List<string> headers = new List<string>();
            for (int i = 0; i < (sender as SfDataGrid).Columns.Count; i++)
            {
                if (!(sender as SfDataGrid).Columns[i].Visible)
                    headers.Add((sender as SfDataGrid).Columns[i].HeaderText);
            }
            if(headers.Count>0)
                exportingOptions.ExcludeColumns = headers;
            //GridBoundColumnsCollection gc = (sender as SfDataGrid).group
            exportingOptions.ExportAllDetails = true;
            exportingOptions.AutoRowHeight = true;
            exportingOptions.ExportDetailsView = true;
            exportingOptions.Exporting += OnExporting;
            //if (shouldCustomizeStyle.Checked)
            //    exportingOptions.CellExporting += OnCustomizedCellExporting;
            //else
            exportingOptions.CellExporting += OnCellExporting;
            exportingOptions.HeaderFooterExporting += ExportingOptions_HeaderFooterExporting;
            var document = (sender as SfDataGrid).ExportToPdf(exportingOptions);
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files(*.pdf)|*.pdf",
                FileName = DateTime.Now.ToFileTimeUtc() + "_SellerSense"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = sfd.OpenFile())
                {
                    document.Save(stream);
                }

                //Message box confirmation to view the created Pdf file.
                if (MessageBox.Show("Do you want to view the created Pdf file?", "Pdf has been created", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    Open(sfd.FileName);
                }
            }
        }

        private static void ExportingOptions_HeaderFooterExporting(object sender, PdfHeaderFooterEventArgs e)
        {
            var width = e.PdfPage.GetClientSize().Width;
            PdfPageTemplateElement footer = new PdfPageTemplateElement(width, 30);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 12f);
            //Create a page template
            footer.Graphics.DrawImage(PdfImage.FromFile(@"..\..\Images\favicon-32x32.png"), 0, 0);
            footer.Graphics.DrawString("Seller Sense", font, PdfPens.Black, 30, 5);
            //Add the footer template at the bottom
            e.PdfDocumentTemplate.Bottom = footer;
        }


        /// <summary>
        /// Occurs when the PdfExportingOptions.Exporting event occurs.
        /// </summary>
        /// <param name="sender">The PdfExportingOptions object.</param>
        /// <param name="e">The DataGridPdfExportingEventArgs that contains the event data.</param>
        private static void OnExporting(object sender, DataGridPdfExportingEventArgs e)
        {
            if (e.CellType == ExportCellType.HeaderCell)
            {
                if (e.Level == 0)
                    e.CellStyle.BackgroundBrush = PdfBrushes.DarkBlue;
                else
                    e.CellStyle.BackgroundBrush = PdfBrushes.OrangeRed;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                e.CellStyle.Font = font;
                e.CellStyle.TextBrush = PdfBrushes.White;
            }
        }

        /// <summary>
        /// Occurs when the PdfExportingOptions.CellExporting event occurs.
        /// </summary>
        /// <param name="sender">The PdfExportingOptions object.</param>
        /// <param name="e">The DataGridCellPdfExportingEventArgs that contains the event data.</param>
        private static void OnCellExporting(object sender, DataGridCellPdfExportingEventArgs e)
        {
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            Syncfusion.Pdf.PdfPaddings p = new Syncfusion.Pdf.PdfPaddings(5,5,30,30);
            e.PdfGridCell.Style.Font = font;
            PdfGridCellStyle st = new PdfGridCellStyle();
            st.CellPadding = p;
            st.Font = font;
            e.PdfGridCell.Style = st;
        }

        //void PdfHeaderFooterEventHandler(object sender, PdfHeaderFooterEventArgs e)
        //{
        //    var width = e.PdfPage.GetClientSize().Width;
        //    PdfPageTemplateElement footer = new PdfPageTemplateElement(width, 30);
        //    //Create a page template
        //    footer.Graphics.DrawImage(PdfImage.FromFile(@"..\..\Resources\Footer.jpg"), 0, 0);
        //    //Add the footer template at the bottom
        //    e.PdfDocumentTemplate.Bottom = footer;
        //}


        private static void Open(string fileName)
        {
            System.Diagnostics.Process.Start(fileName);
        }


    }
}
