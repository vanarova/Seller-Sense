using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders
{
    public static class AmazonInvDecoder
    {
        private static List<IAmzInventory> _amvInventory;
        public static IList<IAmzInventory> ImportAmazonInventory(string fileName)
        {
            if (_amvInventory == null)
            {
                _amvInventory = new List<IAmzInventory>();
                var lines = File.ReadAllLines(fileName);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    var line = lines[i].Split('\t');
                    _amvInventory.Add(new AmazonInventory(line[0], line[1], line[2], line[3]));
                }
                _amvInventory.RemoveAt(0); // remove header
                return _amvInventory;
            }else return _amvInventory;
        }
    }


    class AmazonInventory : IAmzInventory
    {
        public string sku { get; set; }
        public string asin { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }

        public AmazonInventory(string sku, string asin, string price, string quantity)
        {
            this.sku = sku;
            this.asin = asin;
            this.price = price;
            this.quantity = quantity;
        }
    }

}
