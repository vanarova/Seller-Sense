using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders.Interfaces
{
    public interface IShelfInventory
    {
        string inHouseCode { get; set; }
        string shelfCount { get; set; }
    }
}
