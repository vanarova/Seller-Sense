using PrimitiveExt;
using SellerSense.Model;
using SellerSense.Views.AddEditProduct;
using ssViewControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SellerSense.ViewManager.VM_AddProduct;
using static SellerSense.ViewManager.VM_Inventories;
using static SellerSense.ViewManager.VM_LinkedProducts;
using static SellerSense.ViewManager.VM_Products;

namespace SellerSense.ViewManager
{
    internal class VM_LinkedProducts
    {
        private List<LinkedProduct> _linkedProducts;
        private ssGridView<LinkedProduct> _cntrlGridView;
        LinkedProducts _v_linkedProds;
        private M_Product _m_products;
        private Dictionary<string, Image> _images;
        private EventList<LinkedProduct> _selectedProducts;
        private AddProductView _currentProductInView;
        private List<M_Product.LinkedProduct> _currentLinkedProductList;

        public VM_LinkedProducts(AddProductView currentProductInView, M_Product products, Dictionary<string, Image> images)
        {
            _m_products = products;
            _currentProductInView = currentProductInView;
            _images = images;
            _linkedProducts = new List<LinkedProduct>();
            FillProducts();
            
            
            
        }


        

        internal void SearchTitle(bool IsEnable, string textToSearch, BindingList<LinkedProduct> bindedProducts)
        {
            bindedProducts.Clear();
            _linkedProducts.Where(x => x.Title.ToLower().Contains(textToSearch.ToLower())).ToList().
                ForEach(p => bindedProducts.Add(p));
        }

        private void FillProducts()
        {
            foreach (var item in _m_products._productEntries)
            {
                LinkedProduct product = new LinkedProduct();
                product.Title = item.Title;
                product.InHouseCode = item.InHouseCode;
                if(_images.ContainsKey(Path.GetFileNameWithoutExtension(item.Image)))
                    product.Image = _images[Path.GetFileNameWithoutExtension(item.Image)];
                else
                    product.Image = default;
                _linkedProducts.Add(product);
            }
        }

        private void AssignViewManager(UserControl ssGrid)
        {
            _cntrlGridView = ssGrid as ssGridView<LinkedProduct>;

            HandlessGridViewControlEvents();

        }

        public void AssignViewManager(LinkedProducts linkedProds)
        {
            _v_linkedProds = linkedProds;

            HandlessFormControlEvents();

        }

        private void HandlessFormControlEvents()
        {
            _v_linkedProds.Load += (s, e) => {
                CompareProductView comparer = new CompareProductView();
                ssGridView<LinkedProduct> ssGrid = new ssGridView<LinkedProduct>(_linkedProducts, comparer, showSearchCntrls: true, tagLabel: "Tag", titleLabel: "Title");
                _v_linkedProds.tableLayoutPanel1.Controls.Add(ssGrid, 0, 1);
                if (_currentLinkedProductList == null)
                    _currentLinkedProductList = new List<M_Product.LinkedProduct>();

                CleanAndClearLinkProducts();
                AddExistingLinkedProductsToCollection();
                ShowLinkedProductsUI();
                AssignViewManager(ssGrid);
            };


            _v_linkedProds.button_linkSelectedItem.Click += (s, e) =>
            {
                _cntrlGridView.UpdateBindings();
                _v_linkedProds.button_linkSelectedItem.Enabled = false;
                // Create a collection in product model, to save linked products, iterate that collection in below loop first.
                //then add any selected products.


                CleanAndClearLinkProducts();
                //add existing products
                AddExistingLinkedProductsToCollection();
                //add new selected products
                foreach (var prod in _selectedProducts)
                {
                    var linkProductModel = new M_Product.LinkedProduct() { InHouseCode = prod.InHouseCode };
                    if (_currentLinkedProductList.FirstOrDefault(x => x.InHouseCode == prod.InHouseCode) == null)
                        _currentLinkedProductList.Add(linkProductModel);
                    //m_product.LinkedProduct.Add(linkProductModel);
                }

                //Now show all products as usercontrols.
                ShowLinkedProductsUI();


            };

            var product = _m_products._productEntries.FirstOrDefault(x => x.InHouseCode == _currentProductInView.InHouseCode);
            //if (m_product != null && m_product.LinkedProduct != null)
            //{
            _v_linkedProds.button_Save.Click += (sd, ev) => {
                foreach (var item in _currentLinkedProductList)
                {
                    product.LinkedProduct.Add(item);
                }
                _v_linkedProds.Close();
            };
        }

        private void CleanAndClearLinkProducts()
        {
            if (_currentLinkedProductList == null)
                _currentLinkedProductList = new List<M_Product.LinkedProduct>();
            if (_currentLinkedProductList != null && _currentLinkedProductList.Count > 0)
                _currentLinkedProductList.Clear();
        }

        private void ShowLinkedProductsUI()
        {
            _v_linkedProds.flowLayoutPanel1.Controls.Clear();
            foreach (var item in _currentLinkedProductList)
            {
                var tLinkProduct = new AddLinkedProduct(item.InHouseCode, item.LinkQty);
                tLinkProduct.button_Remove.Click += (sd, ev) =>
                {
                    int index = _currentLinkedProductList.FindIndex(x => x.InHouseCode == tLinkProduct.textBox_inhouseCode.Text);
                    _currentLinkedProductList.RemoveAt(index);
                    _v_linkedProds.flowLayoutPanel1.Controls.Remove(tLinkProduct);
                };
                tLinkProduct.textBox_LinkQty.TextChanged += (se, ev) =>
                {
                    var productFromModel = _currentLinkedProductList.FirstOrDefault(x => x.InHouseCode == tLinkProduct.textBox_inhouseCode.Text);
                    if (productFromModel != null)
                        productFromModel.LinkQty = tLinkProduct.textBox_LinkQty.Text;
                };

                _v_linkedProds.flowLayoutPanel1.Controls.Add(tLinkProduct);
            }
        }

        private void AddExistingLinkedProductsToCollection()
        {
            var m_product = _m_products._productEntries.FirstOrDefault(x => x.InHouseCode == _currentProductInView.InHouseCode);
            if (m_product != null && m_product.LinkedProduct != null)
                foreach (var item in m_product.LinkedProduct)
                { 
                    if(_currentLinkedProductList.Find(x=>x.InHouseCode == item.InHouseCode) == null )
                        _currentLinkedProductList.Add(item); 
                }
        }

        private void HandlessGridViewControlEvents()
        {
            _cntrlGridView.SearchTitleTriggered += SearchTitle;
            _cntrlGridView.OnRowSelectionChanged += (EventList<LinkedProduct> eList) => { 
                _selectedProducts = eList;
                _v_linkedProds.button_linkSelectedItem.Enabled = true;
            };
            //throw new NotImplementedException();
        }


        internal class CompareProductView : IComparer<LinkedProduct>
        {
            public int Compare(LinkedProduct x, LinkedProduct y)
            {
                if (x.InHouseCode == y.InHouseCode) return 0;
                else return 1;
                ;
            }
        }

        internal class LinkedProduct
        {
            public string InHouseCode { get; set; }
            public Image Image { get; set; }
            public string Title { get; set; }
        }
    }
}
