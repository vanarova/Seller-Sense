using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssGrid
{
    public class SyncFusionHelper
    {

        public static object GetCellValue(Syncfusion.WinForms.DataGrid.SfDataGrid dGrid, int rowIndex, int columnIndex)
        {
            object cellValue;
            if (columnIndex < 0)
                return string.Empty;
            var mappingName = dGrid.Columns[columnIndex].MappingName;
            var recordIndex = dGrid.TableControl.ResolveToRecordIndex(rowIndex);
            if (recordIndex < 0)
                return string.Empty;
            if (dGrid.View.TopLevelGroup != null)
            {
                var record = dGrid.View.TopLevelGroup.DisplayElements[recordIndex];
                if (!record.IsRecords)
                    return string.Empty;
                var data = (record as RecordEntry).Data;
                cellValue = (data.GetType().GetProperty(mappingName).GetValue(data, null));
            }
            else
            {
                var record1 = dGrid.View.Records.GetItemAt(recordIndex);
                cellValue = (record1.GetType().GetProperty(mappingName).GetValue(record1, null));
            }

            return cellValue;
        }

        //Gets column index from column name. else return -1.
        public static int GetGridColumnIndex(SfDataGrid grid, string columnName)
        {
            int columnIndex = 0;bool found = false;
            foreach (GridColumn column in grid.Columns)
            {
                if (column.MappingName == columnName)
                {
                    found = true;
                    break;
                }
                columnIndex++;
            }
            if(found)
                return columnIndex;
            else
                return -1;
        }
    }
}
