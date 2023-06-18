using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model.Product
{
    internal class ProductListing
    {
        M_Map.MapEntry _MapEntry { get; set; }
        public string _ListingDesc { get; set; }
        public string _ListingName { get; set; }
        public string _ListingSKU { get; set; }

        public ProductListing()
        {
            
        }

       
    }
}
