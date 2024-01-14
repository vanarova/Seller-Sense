using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.GroupingGridExcelConverter;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.WinForms.DataGridConverter.Events;
using Syncfusion.WinForms.Input.Enums;
using Syncfusion.XlsIO;
using ExcelExportingOptions = Syncfusion.WinForms.DataGridConverter.ExcelExportingOptions;

namespace ssGrid
{
    public class HelperExcel

    {
        public static void ExportAllRecordsToExcel(object sender, EventArgs e)
        {
            ExcelExportingOptions exportingOptions = new ExcelExportingOptions();
            exportingOptions.ExcelVersion = ExcelVersion.Excel2016;
            exportingOptions.Exporting += OnExporting;
            //if (shouldCustomizeStyle.Checked)
            //    exportingOptions.CellExporting += OnCustomizedCellExporting;
            //else
            exportingOptions.CellExporting += OnCellExporting;
            var excelEngine = (sender as SfDataGrid).ExportToExcel((sender as SfDataGrid).View, exportingOptions);
            var workBook = excelEngine.Excel.Workbooks[0];
            SaveFileDialog sfd = new SaveFileDialog
            {
                FilterIndex = 2,
                Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx",
                FileName = "Book1"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = sfd.OpenFile())
                {
                    if (sfd.FilterIndex == 1)
                        workBook.Version = ExcelVersion.Excel97to2003;
                    else
                        workBook.Version = ExcelVersion.Excel2010;
                    workBook.SaveAs(stream);
                }

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    Open(sfd.FileName);
                }
            }
        }

        private static void OnCellExporting(object sender, DataGridCellExcelExportingEventArgs e)
        {
            e.Range.CellStyle.Font.Size = 12;
            e.Range.CellStyle.Font.FontName = "Segoe UI";
        }

        private static void OnExporting(object sender, DataGridExcelExportingEventArgs e)
        {
            if (e.CellType == ExportCellType.HeaderCell)
            {
                if (e.Level == 0)
                    e.CellStyle.BackGroundColor = Color.FromArgb(255, 155, 194, 230);
                else
                    e.CellStyle.BackGroundColor = Color.FromArgb(255, 146, 208, 80);

                e.CellStyle.ForeGroundColor = Color.White;
                e.CellStyle.FontInfo.Bold = true;
                e.Handled = true;
            }
        }



        private static void Open(string fileName)
        {
//#if !NETCORE
            System.Diagnostics.Process.Start(fileName);
//#else
//            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
//            {
//                FileName = "cmd",
//                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
//                UseShellExecute = false,
//                CreateNoWindow = true,
//                Arguments = "/c start " + fileName
//            };
//            System.Diagnostics.Process.Start(psi);
//#endif
        }














    }
}
