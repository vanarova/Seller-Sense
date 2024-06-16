using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil
{
    public static class Constants
    {
        //public const string Version = "1.0.3.0";

        public const string JPG = ".jpg";
        public const string PNG = ".png";
        public const int MaxHistoryDaysToKeepSnapshots = 30;
        public const string Imgs = "imgs";
        public const string MapFileName = "map.json";
        public const string logFileName = "log.txt";
        public const string Snapshots = "Snapshots";
        public const string LogDepth = "LogDepth";
        public const string TelegramLogging = "TelegramLogging";


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

        public const string PrestasopSiteURL = "PrestashopURL";
        public const string PrestasopSiteAccessKey = "PrestashopKey";


        public const int FixedColumnsProductGrid = 1;

        public enum TelegramSettings
        {
            BotID, ChatID
        }


        public enum Company
        {
            Amazon, Flipkart, Snapdeal, Meesho
        }

        public enum SearchType
        {
            ByUserId, ByCompanyId
        }

        //public struct ICols
        //{
        //     public const string Image="Image";
        //     public const string Code="Code";
        //     public const string Title="Title";
        //     public const string stock= "Stock Count";
        //     public const string acode="Amazon Code";
        //     public const string asyscount = "Amazon System Count";
        //     public const string acount= "Amazon Count";
        //     public const string fcode= "Flipkart Code";
        //     public const string fcount= "Flipkart Count";
        //     public const string fsyscount= "Flipkart System Count";
        //     public const string scode = "Snapdeal Code";
        //     public const string scount = "Snapdeal Count";
        //     public const string sSyscount = "Snapdeal System Count";
        //     public const string mcode = "Meesho Code";
        //     public const string mcount = "Meesho Count";
        //     public const string msyscount = "Meesho System Count";
        //     public const string notes = "Notes";
        //}

        //public static readonly Color BorderColor = Color.DeepSkyBlue;

        public struct Theme
        {
            //public static readonly Color MainFormBorderColor = Color.SteelBlue;
            public static readonly int MainFormBorderWidth = 3;
            public static readonly Color BorderColor = Color.SteelBlue;

            public static readonly int BorderWidth = 2;


        }


        public struct MCols
        {
            public const string Image = "Image";
            public const string Code = "InHouseCode";
            public const string Title = "Title";
            public const string notes = "Notes";
            public const string amz_Code = "AmazonCode";
            public const string fK_Code = "FlipkartCode";
            public const string spd_Code = "SnapdealCode";
            public const string mso_Code = "MeeshoCode";

        }

        public struct PCols
        {
            public const string AmazonCode = "AmazonCode";
            public const string FlipkartCode = "FlipkartCode";
            public const string SnapDealCode = "SnapdealCode";
            public const string MeeshoCode = "MeeshoCode";
            public const string Image = "Image";
            public const string InHouseCode = "InHouseCode";
            public const string Title = "Title";
            public const string Description = "Description";
            public const string Tag = "Tag";
            public const string Notes = "Notes";
            public const string CostPrice = "CostPrice";

        }


        public struct InventoryViewCols
        {
            public const string AmazonCount = "AmazonCount";
            public const string AmazonSystemCount = "AmazonSystemCount";
            public const string FlipkartCount = "FlipkartCount";
            public const string FlipkartSystemCount = "FlipkartSystemCount";
            public const string SnapdealCount = "SnapdealCount";
            public const string SnapdealSystemCount = "SnapdealSystemCount";
            public const string MeeshoCount = "MeeshoCount";
            public const string MeeshoSystemCount = "MeeshoSystemCount";
            public const string AmazonCode = "AmazonCode";
            public const string FlipkartCode = "FlipkartCode";
            public const string SnapdealCode = "SnapdealCode";
            public const string MeeshoCode = "MeeshoCode";
            public const string InHouseCode = "InHouseCode";
            public const string Title = "Title";
            public const string Tag = "Tag";
            public const string AmazonOrders = "AmazonOrders";
            public const string FlipkartOrders = "FlipkartOrders";
            public const string SnapdealOrders = "SnapdealOrders";

        }


        //public  class AmazonInvColumnMapping
        //{
        //    public static string amazon_inv_report_sku
        //    {   get {return ProjIO.GetUserSetting(nameof(AmazonInvColumnMapping.amazon_inv_report_sku));}
        //        set { ProjIO.SaveUserSetting(nameof(AmazonInvColumnMapping.amazon_inv_report_sku), value); } 
        //    }
        //    public static string amazon_inv_report_asin
        //    {
        //        get { return ProjIO.GetUserSetting(nameof(AmazonInvColumnMapping.amazon_inv_report_asin)); }
        //        set { ProjIO.SaveUserSetting(nameof(AmazonInvColumnMapping.amazon_inv_report_asin), value); }
        //    }
        //    public static string amazon_inv_report_price
        //    {
        //        get { return ProjIO.GetUserSetting(nameof(AmazonInvColumnMapping.amazon_inv_report_price)); }
        //        set { ProjIO.SaveUserSetting(nameof(AmazonInvColumnMapping.amazon_inv_report_price), value); }
        //    }
        //    public static string amazon_inv_report_sellerQuantity
        //    {
        //        get { return ProjIO.GetUserSetting(nameof(AmazonInvColumnMapping.amazon_inv_report_sellerQuantity)); }
        //        set { ProjIO.SaveUserSetting(nameof(AmazonInvColumnMapping.amazon_inv_report_sellerQuantity), value); }
        //    }

        //}

    }
}
