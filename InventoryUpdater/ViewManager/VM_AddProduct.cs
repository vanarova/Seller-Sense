using CustomControls.Rule;
using OrderedPropertyGrid;
using SellerSense.Helper;
using SellerSense.Model;
using SellerSense.Views;
using SellerSense.Views.AddEditProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.ViewManager
{
    internal class VM_AddProduct:IManageForm
    {
        AddProduct _v_AddProduct;
        M_Product _m_Product;
        public bool MarkedForDeletion { get { return _v_AddProduct.checkBox_markForDeletion.Checked; } }
        internal AddProductView AddProductViewBindingObj;
        private Dictionary<string, Image> _images;


        public void AssignViewManager(Form view)
        {
            _v_AddProduct = view as AddProduct;
        }

        //new product add mode
        internal VM_AddProduct(AddProduct v_addproduct, M_Product m_Product )
        {
            _m_Product = m_Product;
            AssignViewManager(v_addproduct);
            AddProductViewBindingObj = new AddProductView();
            AddProductViewBindingObj.EditMode = false;
            _v_AddProduct.button_linkedProducts.Enabled = AddProductViewBindingObj.EditMode;
            _v_AddProduct.label_linkProducts.Text = "First create product, then add linked products composing in this product";
            //_v_AddProduct.labe
            AddProductViewBindingObj.SetPropertyReadOnly("InHouseCode", false);
            AddProductViewBindingObj.SetPropertyReadOnly("PrimaryImage", false);
            AddProductViewBindingObj.SetPropertyReadOnly("Image2", false);
            AddProductViewBindingObj.SetPropertyReadOnly("Image3", false);
            AddProductViewBindingObj.SetPropertyReadOnly("Image4", false);
            _v_AddProduct.propertyGrid_AddProduct.SelectedObject = AddProductViewBindingObj;
            HandleAddProductEvents();
        }


        //edit mode
        internal VM_AddProduct(AddProduct v_addproduct, M_Product m_Product, M_Product.ProductEntry _m_productModelEntry,
            Dictionary<string, Image> images, string companyCode)
        {
            _images = images;
            _m_Product = m_Product;
            //_v_AddProduct = v_addproduct;
            AssignViewManager(v_addproduct);
            AddProductViewBindingObj = new AddProductView();
            AddProductViewBindingObj.SetPropertyReadOnly("InHouseCode", true);
            //AddProductViewBindingObj.SetPropertyReadOnly("PrimaryImage", true);
            //AddProductViewBindingObj.SetPropertyReadOnly("Image2", true);
            //AddProductViewBindingObj.SetPropertyReadOnly("Image3", true);
            //AddProductViewBindingObj.SetPropertyReadOnly("Image4", true);

            AddProductViewBindingObj.EditMode = true;
            _v_AddProduct.button_linkedProducts.Enabled = AddProductViewBindingObj.EditMode;
            AddProductViewBindingObj.Name = _m_productModelEntry.Title;
            AddProductViewBindingObj.Tag = _m_productModelEntry.Tag;
            AddProductViewBindingObj.Description = _m_productModelEntry.Description;
            AddProductViewBindingObj.MRP = _m_productModelEntry.MRP;
            AddProductViewBindingObj.Weight= _m_productModelEntry.Weight;
            AddProductViewBindingObj.DimensionAfterPackaging = _m_productModelEntry.DimensionsAfterPackaging;
            AddProductViewBindingObj.DimensionBeforePackaging = _m_productModelEntry.DimensionsBeforePackaging;
            AddProductViewBindingObj.InHouseCode = _m_productModelEntry.InHouseCode;

            //Image pathis incorrect, fix, use full path
            (_, AddProductViewBindingObj.Image2) = ProjIO.LoadImageUsingFileNameAndDownSize75x75(_m_productModelEntry.ImageAlt1,companyCode);
            (_, AddProductViewBindingObj.Image3) = ProjIO.LoadImageUsingFileNameAndDownSize75x75(_m_productModelEntry.ImageAlt2,companyCode);
            (_, AddProductViewBindingObj.Image4) = ProjIO.LoadImageUsingFileNameAndDownSize75x75(_m_productModelEntry.ImageAlt3, companyCode);
            (_,AddProductViewBindingObj.PrimaryImage) = ProjIO.LoadImageUsingFileNameAndDownSize75x75(_m_productModelEntry.Image,companyCode);
            AddProductViewBindingObj.SellingPrice = _m_productModelEntry.SellingPrice;
            AddProductViewBindingObj.WeightAfterPackaging = _m_productModelEntry.WeightAfterPackaging;
            AddProductViewBindingObj.SetDirtyImages(false, false, false, false);
            _v_AddProduct.propertyGrid_AddProduct.SelectedObject = AddProductViewBindingObj;
            HandleAddProductEvents();
        }


        private void HandleAddProductEvents()
        {
            _v_AddProduct.button_editImages.Click += (s, e) => { 
                PasteImage pi = new PasteImage();
                ////pi.FormClosed += (se, ev) => { };
                pi.ShowDialog();
                if(pi.DialogResult == DialogResult.OK && pi._isImg1)
                    AddProductViewBindingObj.PrimaryImage = pi._image;
                if (pi.DialogResult == DialogResult.OK && pi._isImg2)
                    AddProductViewBindingObj.Image2 = pi._image;
                if (pi.DialogResult == DialogResult.OK && pi._isImg3)
                    AddProductViewBindingObj.Image3 = pi._image;
                if (pi.DialogResult == DialogResult.OK && pi._isImg4)
                    AddProductViewBindingObj.Image4 = pi._image;
            };

            _v_AddProduct.button_linkedProducts.Click += (s, e) => { //Linked products form here
                //_m_Product
                LinkedProducts linkedProducts = new LinkedProducts();
                VM_LinkedProducts vM_LinkedProducts = new VM_LinkedProducts(AddProductViewBindingObj, _m_Product, _images);
                vM_LinkedProducts.AssignViewManager(linkedProducts);
                linkedProducts.ShowDialog();
            };
            _v_AddProduct.button_cancel.Click += (s, e) => {
                _v_AddProduct.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                _v_AddProduct.Close(); };
            _v_AddProduct.button_ok.Click += (s, e) => {
                if(!_v_AddProduct.checkBox_markForDeletion.Checked && !ValidateForm() )
                    return;
                _v_AddProduct.DialogResult = System.Windows.Forms.DialogResult.OK;
                _v_AddProduct.Close(); };

            _v_AddProduct.propertyGrid_AddProduct.PropertyValueChanged += (s, e) =>
            {
                PropertyGridControl_PropertyValueChanged(e);
            };

            _v_AddProduct.checkBox_markForDeletion.CheckedChanged += (s,e) => {
                //if(_v_AddProduct.checkBox_markForDeletion.Checked)

            };
        }

        
        private bool ValidateForm()
        {
            if (!AddProductViewBindingObj.EditMode)
            {
                if (_m_Product.ChecKProductImageExists(AddProductViewBindingObj.PrimaryImage, AddProductViewBindingObj.InHouseCode))
                    return false;
                if (_m_Product.ChecKProductImageExists(AddProductViewBindingObj.Image2, AddProductViewBindingObj.InHouseCode + "_2"))
                    return false;
                if (_m_Product.ChecKProductImageExists(AddProductViewBindingObj.Image3, AddProductViewBindingObj.InHouseCode + "_3"))
                    return false;
                if (_m_Product.ChecKProductImageExists(AddProductViewBindingObj.Image4, AddProductViewBindingObj.InHouseCode + "_4"))
                    return false;
            }

            string empties = string.Empty;
            //check empties ---
            if (string.IsNullOrEmpty(AddProductViewBindingObj.Name))
                empties = empties + "Name ";
            if (AddProductViewBindingObj.PrimaryImage == null)
                empties = empties + "Image ";
            if (string.IsNullOrEmpty(AddProductViewBindingObj.Tag))
                empties = empties + "Tag ";
            if (string.IsNullOrEmpty(AddProductViewBindingObj.Weight))
                empties = empties + "Weight ";
            if (string.IsNullOrEmpty(AddProductViewBindingObj.InHouseCode))
                empties = empties + "InHouseCode ";
            if (string.IsNullOrEmpty(AddProductViewBindingObj.SellingPrice))
                empties = empties + "SellingPrice ";
            if (!string.IsNullOrEmpty(empties))
            {
                MessageBox.Show("Empty field(s), please provide value for :" + empties);
                return false;
            }
            else return true;

        }

       
        private void PropertyGridControl_PropertyValueChanged(PropertyValueChangedEventArgs e)
        {
            if (_v_AddProduct.propertyGrid_AddProduct.ActiveControl.Text == string.Empty)
                return;
            RuleBaseAttribute rule;
            Type classType;
            string propertyName;
            PropertyInfo propertyInfo;
            object[] attributes;

            classType = e.ChangedItem.PropertyDescriptor.ComponentType;
            propertyName = e.ChangedItem.PropertyDescriptor.Name;
            propertyInfo = classType.GetProperty(propertyName);
            attributes = propertyInfo.GetCustomAttributes(true);

            if ((attributes != null) && (attributes.Length > 0))
            {
                foreach (object attribute in attributes)
                {
                    // Is this Attribute a RuleBaseAttribute
                    rule = attribute as RuleBaseAttribute;
                    if (rule != null)
                    {
                        // Validate the data using the rule
                        if (rule.IsValid(e.ChangedItem.Value) == false)
                        {
                            _v_AddProduct.propertyGrid_AddProduct.ActiveControl.Text = "";
                            //propertgrid
                            //propertyInfo.SetValue(e.OldValue, attribute, null);
                            // Data was invalid - show the error
                            MessageBox.Show(rule.ErrorMessage, "Data Entry Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        //View class for AddProduct form, this class will be used for binding controls on form.
        [TypeConverter(typeof(PropertySorter))]
        [DefaultPropertyAttribute("Name")]
        
        public class AddProductView
        {
            public AddProductView()
            {
                EditMode = false;
                Img1Dirty = false; Img22Dirty = false; Img3Dirty = false; Img4Dirty = false;
            }

            private string _m_Name;
            private string _m_desc;
            private string _m_InHouseCode;
            private string _m_Tag;
            private string _m_Weight;
            private string _m_Weight_After_Pkging;
            private string _m_MRP;
            private string _m_SellingPrice;
            private string _m_DimensionBeforePackaging;
            private string _m_DimensionAfterPackaging;
            private Image _m_PrimaryImg;
            private Image _m_Img2;
            private Image _m_Img3;
            private Image _m_Img4;

            //internal bool IsDirty { get; set; }
            private bool Img1Dirty { get; set; }
            private bool Img22Dirty { get; set; }
            private bool Img3Dirty { get; set; }
            private bool Img4Dirty { get; set; }
            internal bool EditMode { get; set; }
            internal  (bool,bool,bool,bool) GetDirtyImages()
            {
                return(Img1Dirty, Img22Dirty, Img3Dirty, Img4Dirty);
            }

            internal void SetDirtyImages(bool i1, bool i2, bool i3, bool i4)
            {
                Img1Dirty = i1; Img22Dirty = i2; Img3Dirty = i3; Img4Dirty=i4;
            }

            // this method, dynamically changes attribute value, and applies ReadyOnlyAttrbute to a property
            // Note, ReadOnlyAttribute is already available in Property grid, this method just switches it to true or false.
            internal void SetPropertyReadOnly(string lsProperty, bool lbIsReadOnly)
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())[lsProperty];
                ReadOnlyAttribute attribute = (ReadOnlyAttribute) descriptor.Attributes[typeof(ReadOnlyAttribute)];
                FieldInfo fieldToChange = attribute.GetType().GetField("isReadOnly",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);
                fieldToChange.SetValue(attribute, lbIsReadOnly);
            }

            [CategoryAttribute("1. Product Details"), DescriptionAttribute("Name of product, generally this will display as title on emcommerce site")
                , PropertyOrder(1), ReadOnlyAttribute(false)]
            public string Name { get { return _m_Name; } set { _m_Name = value;  } }

            [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
            [CategoryAttribute("1. Product Details"), DescriptionAttribute("Description : for buyers to know more about your product")
                , PropertyOrder(2), ReadOnlyAttribute(false)]
            public string Description { get { return _m_desc; } set { _m_desc = value;  } }

            [CategoryAttribute("1. Product Details"), DescriptionAttribute("Inhouse Code : Internal inventory code, will be used by Seller-Sense to keep track of products \n You can not change InHouseCode once it is set, Delete and re-create product.")
                , PropertyOrder(3), ReadOnlyAttribute(false)]
            public string InHouseCode { get { return _m_InHouseCode; } set { 
                     _m_InHouseCode = value;  } }

            [CategoryAttribute("1. Product Details"), DescriptionAttribute("Tag helps in searching product, use keywords which you can use later on product screen to search product faster.")
                , PropertyOrder(4), ReadOnlyAttribute(false)]
            public string Tag { get { return _m_Tag; } set { _m_Tag = value;  } }

            [CategoryAttribute("1. Product Details"), DescriptionAttribute("Weight of product only, excluding any packaging weight. \n Valid values : Positive Numbers")
                , PropertyOrder(5), ReadOnlyAttribute(false)]
            [PatternRule(@"\b(?:\d+\.\d+|\d+(?!\.))\b")]
            public string Weight { get { return _m_Weight; } set { _m_Weight = value;  } }

            [CategoryAttribute("1. Product Details"), DescriptionAttribute("MRP : Maximum retail price. \n Valid values : Positive Numbers"), PropertyOrder(6)]
            [PatternRule(@"\b(?:\d+\.\d+|\d+(?!\.))\b"), ReadOnlyAttribute(false)] //Regex.IsMatch( "1", @"\b(?:\d+\.\d+|\d+(?!\.))\b")
            public string MRP { get { return _m_MRP; } set { _m_MRP = value;  } }

            [CategoryAttribute("1. Product Details"), DescriptionAttribute("Selling price. \n Valid values : Positive Numbers"), PropertyOrder(7)]
            [PatternRule(@"\b(?:\d+\.\d+|\d+(?!\.))\b"), ReadOnlyAttribute(false)]
            public string SellingPrice { get { return _m_SellingPrice; } set { _m_SellingPrice = value;  } }

            [CategoryAttribute("2. Product Images"), DescriptionAttribute("Primary Image"), PropertyOrder(8), ReadOnlyAttribute(false)]
            public Image PrimaryImage { get { return _m_PrimaryImg; } set { _m_PrimaryImg = value; Img1Dirty = true;  } }

            [CategoryAttribute("2. Product Images"), DescriptionAttribute("Image 2"), PropertyOrder(9), ReadOnlyAttribute(false)]
            public Image Image2 { get { return _m_Img2; } set { if (value != null) {  _m_Img2 = value; Img22Dirty = true; } } }

            [CategoryAttribute("2. Product Images"), DescriptionAttribute("Image 3"), PropertyOrder(10), ReadOnlyAttribute(false)]
        public Image Image3 { get { return _m_Img3; } set { if (value != null) {  _m_Img3 = value; Img3Dirty = true; } } }

            [CategoryAttribute("2. Product Images"), DescriptionAttribute("Image 4"), PropertyOrder(11), ReadOnlyAttribute(false)]
            public Image Image4 { get { return _m_Img4; } set { if (value != null) { _m_Img4 = value; Img4Dirty = true; } } }

            //TODO : Add another drop down to choose, if weight should be in gms/kgs
            [CategoryAttribute("3. Addtional Details"), DescriptionAttribute("Weight of product with packaging in grams. \n Valid values : Positive Numbers"), PropertyOrder(12)]
            [PatternRule(@"\b(?:\d+\.\d+|\d+(?!\.))\b"), ReadOnlyAttribute(false)]
            public string WeightAfterPackaging { get { return _m_Weight_After_Pkging; } set { _m_Weight_After_Pkging = value;  } }

            [CategoryAttribute("3. Addtional Details"), DescriptionAttribute("Dimensions of product WITHOUT packaging"), PropertyOrder(13), ReadOnlyAttribute(false)]
            public string DimensionBeforePackaging { get { return _m_DimensionBeforePackaging; } set { _m_DimensionBeforePackaging = value;  } }

            [CategoryAttribute("3. Addtional Details"), DescriptionAttribute("Dimensions of product WITH packaging"), PropertyOrder(14), ReadOnlyAttribute(false)]
            public string DimensionAfterPackaging { get { return _m_DimensionAfterPackaging; } set { _m_DimensionAfterPackaging = value;  } }
        }

    }
}
