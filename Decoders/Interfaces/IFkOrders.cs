using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders.Interfaces
{
    public interface IFkOrders
    {
        string sku { get; set; }
        string fsn { get; set; }
        string qty { get; set; }
    }
}
