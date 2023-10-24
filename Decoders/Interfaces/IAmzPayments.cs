using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders.Interfaces
{
    public interface IAmzPayments
    {
        string orderId { get; set; }
        string shipmentId { get; set; }
        string amountType { get; set; }
        string amountDesc { get; set; }
        string amount { get; set; }
        string postedDateTime { get; set; }
        string orderItemCode { get; set; }
        string sku { get; set; }
        string quantityPurchased { get; set; }

    }
}
