using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders.Interfaces
{
    public interface IFkPayments
    {
        string orderId { get; set; }
        string orderItemId { get; set; }
        string sku { get; set; }
        string bankSettlementValue { get; set; }
        string gst_tcs_Credits { get; set; }
        string tds { get; set; }
        string saleAmount { get; set; }
        string totalOfferAmt { get; set; }
        string myShare { get; set; }
        string customerAddonAmt { get; set; }
        string marketplaceFee { get; set; }
        string taxes { get; set; }



        //string commisionRate { get; set; }
        //string commisionFee { get; set; }
        //string fixedFee { get; set; }
        //string collectionFee { get; set; }
        //string pickAndPackFee { get; set; }
        //string shipmentFee { get; set; }
        //string reverseShipmentFee { get; set; }


    }
}
