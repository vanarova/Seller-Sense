using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryUpdater
{
    public static class Constants
    {
       public enum Company
        {
            Amazon,Flipkart,Snapdeal, Meesho
        }

       public enum SearchType
        {
            ByUserId,ByCompanyId
        }

        public struct ICols
        {
             public const string Image="Image";
             public const string Code="Code";
             public const string Title="Title";
             public const string stock= "Stock Count";
             public const string acode="Amazon Code";
             public const string acount= "Amazon Count";
             public const string fcode= "Flipkart Code";
             public const string fcount= "Flipkart Count";
             public const string fsyscount= "Flipkart System Count";
             public const string scode = "Snapdeal Code";
             public const string scount = "Snapdeal Count";
             public const string sSyscount = "Snapdeal System Count";
             public const string mcode = "Meesho Code";
             public const string mcount = "Meesho Count";
             public const string msyscount = "Meesho System Count";
             public const string notes = "Notes";
        }
    }
}
