
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders.Interfaces
{
    public interface IFkInventory
    {
        string name { get; set; }
        string fsn { get; set; } //flipkart serial number
        string price { get; set; }
        string systemQuantity { get; set; }
        string sellerQuantity { get; set; }
    }
}
