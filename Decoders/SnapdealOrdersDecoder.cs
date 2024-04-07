using Decoders.Interfaces;
using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders
{
    public class SnapdealOrdersDecoder
    {
        private static ExcelMapper _exm;
        private static IEnumerable<ISpdOrders> _spdOrders;

        public static IList<ISpdOrders> ImportSnapdealOrders(string fileName)
        {
            var error = string.Empty; List<ISpdOrders> spdOrders;
            //_invFlipkartFileName = fileName;
            try
            {
                _exm = new ExcelMapper(fileName) { HeaderRowNumber = 1, MinRowNumber = 1 };
                _spdOrders = _exm.Fetch<SnapdealOrders>(0);
            }
            catch (Exception e) { error = e.Message; return new List<ISpdOrders>(); }

            spdOrders = _spdOrders.ToList<ISpdOrders>();
            return spdOrders;

        }


        class SnapdealOrders : ISpdOrders
        {
            [Column(8)]
            public string SUPC { get; set; }
            [Column(7)]
            public string SKU { get; set; }

        }
    }
}
