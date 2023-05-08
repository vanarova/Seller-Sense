using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryUpdater.Model.Interfaces;

namespace InventoryUpdater.Model
{

    /// <summary>
    /// Base code class common functionality of base code, basec ode means user's inventory codes 
    /// versions of this class are possible by inheritance, currently V1 and V2 are available, 
    /// in V2 count was added.
    /// </summary>
    public abstract class BaseCode
    {

        public string BaseCodeValue { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }

        public BaseCode(string img, string code, string price, string title)
        {
            Image = img;
            BaseCodeValue = code;
            Price = price;
            Title = title;
        }

    }



    /// <summary>
    /// First implementation of base codes
    /// </summary>
    public class BaseCodeV1 : BaseCode, IBaseCodeV1
    {
        public BaseCodeV1(string img, string code, string price, string title) :
             base(img,  code,  price,  title)
        {

        }

    }



    /// <summary>
    /// Second implementation of base codes
    /// Note: Count introduced
    /// </summary>
    public class BaseCodeV2 : BaseCode, IBaseCodeV2
    {
        public string Count { get; set; }
        public BaseCodeV2(string img, string code, string price, string title, string count) :
             base(img, code, price, title)
        {
            Count = count;
        }

    }



}
