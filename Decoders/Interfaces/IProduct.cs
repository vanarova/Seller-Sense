using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoders.Interfaces
{
    public interface IProduct
    {

        string InHouseCode { get; set; }
        string Image { get; set; }
        string ImageAlt1 { get; set; }
        string ImageAlt2 { get; set; }
        string ImageAlt3 { get; set; }
        string Title { get; set; }
        string Tag { get; set; }
        string MRP { get; set; }
        string SellingPrice { get; set; }
        string CostPrice { get; set; }
        string Weight { get; set; }
        string WeightAfterPackaging { get; set; }
        string DimensionsBeforePackaging { get; set; }
        string DimensionsAfterPackaging { get; set; }
        string Description { get; set; }
        string AmazonCode { get; set; }
        string AmazonSKU { get; set; }
        string FlipkartCode { get; set; }
        string FlipkartSKU { get; set; }
        string SnapdealCode { get; set; }
        string SnapdealSKU { get; set; }
        string MeeshoCode { get; set; }
        string Notes { get; set; }

        string LinkedInHouseCode { get; set; }
        string LinkItemQty { get; set; }
    }
}
