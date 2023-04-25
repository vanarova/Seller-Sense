using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders.Interfaces
{
    public interface IAmzInventory
    {
        string sku { get; set; }
        string asin { get; set; }
        string price { get; set; }
        string quantity { get; set; }
    }
}
