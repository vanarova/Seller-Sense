using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model
{
    public class AppVersion
    {
       public static Number Ver { get; set; }
        //public static Number Ver;
       public enum Number
        {
            V1,V2
        }

        public AppVersion()
        {
            Ver = Number.V1;
        }
    }
}
