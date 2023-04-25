//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace InventoryUpdater.Model
//{
//    [Obsolete]
//    public class InvMap
//    {
//        readonly List<BaseMapEntry> MapTable = new List<BaseMapEntry>();
//        readonly String MapName;

//        public InvMap(List<BaseMapEntry> mapTable, string mapName)
//        {
//            MapTable = mapTable;
//            MapName = mapName;
//        }
//    }

//    public class BaseMapEntry {
//        public string Code { get; set; }
//        public string Image { get; set; }
//        List<Flipkart> fkCodeEntries;
//        List<Amazon> azCodeEntries;
//        List<Snapdeal> spCodeEntries;
//        List<Meesho> msCodeEntries;

//        public BaseMapEntry()
//        {
//            fkCodeEntries = new List<Flipkart>();
//            azCodeEntries = new List<Amazon>();
//            spCodeEntries = new List<Snapdeal>();
//            msCodeEntries = new List<Meesho>();
//        }

//        public void AddMapEntryForEachAcc(string code, string image, 
//            Flipkart fk, Amazon az, Snapdeal sp, Meesho ms)
//        {
//            Code = code;
//            Image = image;
//            fkCodeEntries.Add(fk);
//            azCodeEntries.Add(az);
//            spCodeEntries.Add(sp);
//            msCodeEntries.Add(ms);
//        }

//        public void AddMapEntryForMultipleAcc(string code, string image,
//            List<Flipkart> fk, List<Amazon> az, List<Snapdeal> sp, List<Meesho> ms)
//        {
//            Code = code;
//            Image = image;
//            fkCodeEntries.AddRange(fk);
//            azCodeEntries.AddRange(az);
//            spCodeEntries.AddRange(sp);
//            msCodeEntries.AddRange(ms);
//        }



//    }


//    public class Flipkart { readonly string code; readonly int count; }
//    public class Amazon { readonly string code; readonly int count; }
//    public class Snapdeal { readonly string code; readonly int count; }
//    public class Meesho { readonly string code; readonly int count; }






//}
