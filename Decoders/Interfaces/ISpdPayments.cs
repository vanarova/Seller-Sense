using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders.Interfaces
{
    public interface ISpdPayments
    {
        string transactionDate { get; set; }
        string type { get; set; }
        string transactionId { get; set; }
        string sku { get; set; }
        string invoiceNumber { get; set; }
        string webSalePrice { get; set; }
        string paymentReceicedBySpd { get; set; }
        string commission { get; set; }
        string netPayable  { get; set; }
       



    }
}
