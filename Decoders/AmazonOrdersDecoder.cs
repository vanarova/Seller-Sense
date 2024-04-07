using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders
{
    public class AmazonOrdersDecoder
    {

        private static IList<IAmzOrders> _amvOrders;
        private static string _ordersAmazonFileName;
        private static readonly string[] _colsToExport = {
            "asin","quantity","ship-city","ship-state"};



        public static IList<IAmzOrders> ImportAmazonOrders(string fileName)
        {
            _ordersAmazonFileName = fileName;
            _amvOrders = new List<IAmzOrders>();
            var lines = File.ReadAllLines(fileName);
            for (var i = 0; i < lines.Length; i += 1)
            {
                var line = lines[i].Split('\t');
                _amvOrders.Add(new AmazonOrders(line[12], line[14], line[24],
                    line[25]));
            }
            _amvOrders.RemoveAt(0); // remove header
            _amvOrders.RemoveAt(0); // remove second row, contains total payment received etc
            return _amvOrders;
        }


        class AmazonOrders : IAmzOrders
        {

            public string asin { get; set; }
            public string qty { get; set; }
            public string city { get; set; }
            public string state { get; set; }

            public AmazonOrders(string asin, string qty, string city, string state)
            {
                this.asin = asin;
                this.qty = qty;
                this.city = city;
                this.state = state;
            }


        }
    }
}
