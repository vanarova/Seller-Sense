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
    public class FlipkartOrdersDecoder
    {

        private static ExcelMapper _exm;
        private static IEnumerable<IFkOrders> _spdOrders;


        public static IList<IFkOrders> ImportFlipkartOrders(string fileName)
        {
            var error = string.Empty; List<IFkOrders> spdOrders;
            //_invFlipkartFileName = fileName;
            try
            {
                _exm = new ExcelMapper(fileName) { HeaderRowNumber = 1, MinRowNumber = 1 };
                _spdOrders = _exm.Fetch<FlipkartOrders>("Orders");
            }
            catch (Exception e) { error = e.Message; return new List<IFkOrders>(); }

            spdOrders = _spdOrders.ToList<IFkOrders>();
            return spdOrders;
        }


        class FlipkartOrders : IFkOrders
        {
            [Column(8)]
            public string sku { get; set; }
            [Column(9)]
            public string fsn { get; set; }
            [Column(11)]
            public string qty { get; set; }

            //public FlipkartOrders(string asin, string qty, string city, string state)
            //{
            //    this.asin = asin;
            //    this.qty = qty;
            //    this.city = city;
            //    this.state = state;
            //}


        }
    }
}
