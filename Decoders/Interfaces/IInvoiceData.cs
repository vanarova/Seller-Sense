using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders.Interfaces
{
    public interface IInvoiceData
    {
        string Count { get; set; }
        string ItemName { get; set; }
        string ItemQty { get; set; }
        string ItemPrice { get; set; }
    }

    public interface IInvoiceClient
    {
        string Name { get; set; }
        string Address { get; set; }
        string TaxNo { get; set; }
    }

}
