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
            exportingOptions.ExportAllDetails = true;
            exportingOptions.ExportDetailsView = true;
            exportingOptions.Exporting += OnExporting;
            //if (shouldCustomizeStyle.Checked)
            //    exportingOptions.CellExporting += OnCustomizedCellExporting;
            //else
            exportingOptions.CellExporting += OnCellExporting;
            var document = (sender as SfDataGrid).ExportToPdf(exportingOptions);
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files(*.pdf)|*.pdf",
                FileName = "Sample"
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
            e.PdfGridCell.Style.Font = font;
        }


        private static void Open(string fileName)
        {
            System.Diagnostics.Process.Start(fileName);
        }


    }
}
