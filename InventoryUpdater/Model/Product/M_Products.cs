using SellerSense.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Model.Product
{
    //internal class M_Products 
    //{
    //    internal List<M_Product> products;
    //    internal Dictionary<string, Image> _imgs;
    //    private List<M_Map.MapEntry> _mapEntries;
    //    public  M_Products(List<M_Map.MapEntry> mapEntries)
    //    {
    //        products = new List<M_Product>();
    //        _mapEntries = mapEntries;
            
    //    }

    //    //Load image and assign here, image load is done on form, async task
    //    internal void FillProductsAndImagesCollection(Dictionary<string, Image> imgs)
    //    {
    //        _imgs = imgs;
    //        TranslateMapEntriesToProducts();
    //    }



    //    private void TranslateMapEntriesToProducts()
    //    {
    //        foreach (var item in _mapEntries)
    //        {
    //            Image timg = null;
    //            if(_imgs.ContainsKey(item.Image))
    //                timg = _imgs[item.Image];
    //            products.Add(new M_Product()
    //            {
    //                AmazonCode = item.AmazonCode,
    //                BaseCodeValue = item.InHouseCode,
    //                Description = "",
    //                FlipkartCode = item.FlipkartCode,
    //                Image = timg,
    //                MeeshoCode = item.MeeshoCode,
    //                Tag = "",
    //                Notes = "",
    //                SKU = "",
    //                SnapDealCode = item.SnapdealCode,
    //                Title= item.Title
    //            }); 
    //        }
    //    }
    //}

    //internal class M_Product
    //{
    //    public Image Image { get; set; }
    //    public string Description { get; set; }
    //    public string Tag { get; set; }
    //    public string SKU { get; set; }
    //    //below taken from map_entry
    //    public string BaseCodeValue { get; set; }
    //    public string Title { get; set; }
    //    public string AmazonCode { get; set; }
    //    public string FlipkartCode { get; set; }
    //    public string SnapDealCode { get; set; }
    //    public string MeeshoCode { get; set; }
    //    public string Notes { get; set; }
    //}

}
