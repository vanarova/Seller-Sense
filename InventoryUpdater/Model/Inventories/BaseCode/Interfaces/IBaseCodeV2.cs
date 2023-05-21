using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model.Interfaces
{
    internal interface IBaseCodeV2
    {
        string BaseCodeValue { get; set; }
        string Image { get; set; }
        string Price { get; set; }
        string Title { get; set; }
        string Count { get; set; }

    }
}
