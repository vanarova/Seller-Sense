using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater.Model
{
    internal abstract class AmzInventory : IAmzInventory
    {
       public string sku { get; set; }
       public string asin { get; set; }
       public string price { get; set; }
       public string quantity { get; set; }

        public AmzInventory(string sku, string asin, string price, string quantity)
        {
            this.sku = sku;
            this.asin = asin;
            this.price = price;
            this.quantity = quantity;
        }
    }


    internal class AmzInventoryV1: AmzInventory
    {
        public AmzInventoryV1(string sku, string asin, string price, string quantity) :
            base(sku, asin, price, quantity)
        {

        }
    }



}
