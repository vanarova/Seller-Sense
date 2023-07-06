using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense
{
    public static class Constants
    {
        public const string Imgs = "imgs";
        public const string MapFileName = "map.json";
        public const string logFileName = "log.txt";
        public const string Snapshots = "Snapshots";


        public const string WorkspaceDir = "workspace";
        public const string WorkspaceDefaultDirName = "Seller-Sense";

        public const string Company1Code = "Company1Code";
        public const string Company1Name = "Company1Name";
        public const string Company2Code = "Company2Code";
        public const string Company2Name = "Company2Name";
        public const string Company3Code = "Company3Code";
        public const string Company3Name = "Company3Name";
        public const string Company4Code = "Company4Code";
        public const string Company4Name = "Company4Name";
        public const string Company5Code = "Company5Code";
        public const string Company5Name = "Company5Name";

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
             public const string asyscount = "Amazon System Count";
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


        public struct MCols
        {
            public const string Image = "Image";
            public const string Code = "InHouseCode";
            public const string Title = "Title";
            public const string notes = "Notes";
            public const string amz_Code = "AmazonCode";
            public const string fK_Code = "FlipkartCode";
            public const string spd_Code = "SnapDealCode";
            public const string mso_Code = "MeeshoCode";

        }

        public struct PCols
        {
            public const string AmazonCode = "AmazonCode";
            public const string FlipkartCode = "FlipkartCode";
            public const string SnapDealCode = "SnapDealCode";
            public const string MeeshoCode = "MeeshoCode";
            public const string BaseCodeValue = "BaseCodeValue";

        }


    }
}
