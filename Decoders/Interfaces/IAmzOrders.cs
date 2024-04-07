using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders.Interfaces
{
    public interface IAmzOrders
    {
        string asin { get; set; }
        string qty { get; set; }
        string city { get; set; }
        string state { get; set; }

    }
}
