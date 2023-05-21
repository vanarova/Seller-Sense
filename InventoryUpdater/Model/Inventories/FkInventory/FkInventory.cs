using Decoders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model
{
    internal abstract class FkInventory : IFkInventory
    {
       public string name { get; set; }
       public string fsn { get; set; }
       public string price { get; set; }
        public string systemQuantity { get; set; }
        public string sellerQuantity { get; set; }

        public FkInventory(string sku, string fsn, string price, string systemQuantity, string sellerQuantity)
        {
            this.name = sku;
            this.fsn = fsn;
            this.price = price;
            this.systemQuantity = systemQuantity;
            this.sellerQuantity = sellerQuantity;
        }
    }

    // Use this class to extend functionality of parent class if needed or to create another version.
    internal class FkInventoryV2 : FkInventory
    {
        public FkInventoryV2(string sku, string asin, string price, string systemQuantity, string sellerQuantity) :
            base(sku, asin, price, systemQuantity, sellerQuantity)
        {

        }
    }



}
