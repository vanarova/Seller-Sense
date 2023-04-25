using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater.Model.Interfaces
{
    internal interface IBaseCodeV1
    {
        string Code { get; set; }
        string ImageURL { get; set; }
        string Price { get; set; }
        string Title { get; set; }

    }
}
