using OrderedPropertyGrid;
using SellerSense.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.ViewManager
{
    internal class VM_AddProduct
    {
        AddProduct _v_AddProduct;
        internal AddProductView AddProductViewBindingObj;
        internal VM_AddProduct(AddProduct v_product)
        {
            _v_AddProduct = v_product;
            AddProductViewBindingObj = new AddProductView();
            _v_AddProduct.propertyGrid_AddProduct.SelectedObject = AddProductViewBindingObj;
            HandleAddProductEvents();
        }

        private void HandleAddProductEvents()
        {
            _v_AddProduct.button_cancel.Click += (s, e) => { _v_AddProduct.Close(); };
            _v_AddProduct.button_ok.Click += (s, e) => {  _v_AddProduct.Close(); };
            
            //_v_AddProduct.propertyGrid_AddProduct.PropertyValueChanged += (s, e) => { 
            //    var obj = s as System.Windows.Forms.PropertyGrid;
            //    var item = obj.SelectedObject as AddProductView;
            //};
        }

        //private void SaveChangesToProductModel()
        //{
           
        //}



        //View class for AddProduct form, this class will be used for binding controls on form.
        [TypeConverter(typeof(PropertySorter))]
        [DefaultPropertyAttribute("Name")]
        public class AddProductView
        {
            [CategoryAttribute("Product Details"), DescriptionAttribute("Name of product, generally this will display as title on emcommerce site")
                , PropertyOrder(1)]
            public string Name { get; set; }

            [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
            [CategoryAttribute("Product Details"), DescriptionAttribute("Description : for buyers to know more about your product")
                , PropertyOrder(2)]
            public string Description { get; set; }

            [CategoryAttribute("Product Details"), DescriptionAttribute("Inhouse Code : Internal inventory code, will be used by Seller-Sense to keep track of products")
                , PropertyOrder(3)]
            public string InHouseCode { get; set; }

            [CategoryAttribute("Product Details"), DescriptionAttribute("Tag helps in searching product, use keywords which you can use later on product screen to search product faster.")
                , PropertyOrder(4)]
            public string Tag { get; set; }

            [CategoryAttribute("Product Details"), DescriptionAttribute("Weight of product only, excluding any packaging weight")
                , PropertyOrder(5)]
            public string Weight { get; set; }

            [CategoryAttribute("Product Details"), DescriptionAttribute("MRP"), PropertyOrder(6)]
            public string MRP { get; set; }

            [CategoryAttribute("Product Details"), DescriptionAttribute("Selling price"), PropertyOrder(7)]
            public string SellingPrice { get; set; }

            [CategoryAttribute("Product Images"), DescriptionAttribute("Primary Image"), PropertyOrder(8)]
            public Image PrimaryImage { get; set; }

            [CategoryAttribute("Product Images"), DescriptionAttribute("Image 2"), PropertyOrder(9)]
            public Image Image2 { get; set; }

            [CategoryAttribute("Product Images"), DescriptionAttribute("Image 3"), PropertyOrder(10)]
            public Image Image3 { get; set; }

            [CategoryAttribute("Product Images"), DescriptionAttribute("Image 4"), PropertyOrder(11)]
            public Image Image4 { get; set; }

            [CategoryAttribute("Addtional Details"), DescriptionAttribute("Weight of product with packaging"), PropertyOrder(12)]
            public string WeightAfterPackaging { get; set; }

            [CategoryAttribute("Addtional Details"), DescriptionAttribute("Dimensions of product WITHOUT packaging"), PropertyOrder(13)]
            public string DimensionBeforePackaging { get; set; }

            [CategoryAttribute("Addtional Details"), DescriptionAttribute("Dimensions of product WITH packaging"), PropertyOrder(14)]
            public string DimensionAfterPackaging { get; set; }
        }

    }
}
