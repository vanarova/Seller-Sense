using System;
using System.Collections.Generic;
using System.Linq;
using Decoders.Interfaces;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

namespace Decoders
{
    public static class ShelfInventoryDecorder
    {
        private static string _invFileName;
        private static ObservableCollection<IShelfInventory> _shelfInventoryUnmodified;

        public static ObservableCollection<IShelfInventory> ImportShelfInventory(string fileName)
        {
            _invFileName = fileName;
            _shelfInventoryUnmodified = new ObservableCollection<IShelfInventory>();
            var lines = File.ReadAllLines(fileName);
            for (var i = 0; i < lines.Length; i += 1)
            {
                var line = lines[i].Split('\t');
                _shelfInventoryUnmodified.Add(new ShelfInventory(line[0],line[1]));
            }
            _shelfInventoryUnmodified.RemoveAt(0); // remove header
            return _shelfInventoryUnmodified;
        }



    }


    class ShelfInventory : IShelfInventory
    {
        public string inHouseCode { get; set; }
        public string shelfCount { get; set; }
        //public string sellerQuantity { get; set; }
        public string systemQuantity { get; set; }

        public ShelfInventory(string asin, string count)
        {
            this.inHouseCode = asin;
            this.shelfCount = count;
        }

        
    }

}
