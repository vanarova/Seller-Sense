using SellerSense.Model;
using SellerSense.Model.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.ViewModelManager
{
    internal class VM_ProductListing
    {
        internal string _name;
        internal string _code;
        internal M_Products _productGridData { get; set; }
        

        public VM_ProductListing(M_Map map)
        {
            _productGridData = new M_Products(map._mapEntries);
            //_name = name;
            //_code = code;
        }

        internal void AssignImages(Dictionary<string,Image> imags)
        {
            _productGridData.FillProductsAndImagesCollection(imags);
        }


        /// Start - Event handlers for data grid view


        //Handles event fired after data binding complete.
        internal void DataGridDataBindingComplete(System.Windows.Forms.DataGridView gridView)
        {
            SetHyperlinks(gridView);
        }

        private void SetHyperlinks(System.Windows.Forms.DataGridView gridView)
        {
            gridView.Columns[Constants.PCols.AmazonCode].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            gridView.Columns[Constants.PCols.FlipkartCode].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            gridView.Columns[Constants.PCols.SnapDealCode].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            gridView.Columns[Constants.PCols.MeeshoCode].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            gridView.RowHeadersVisible = false;
        }

        /// <summary>  
        /// This function is use to get hyperlink style .  
        /// </summary>  
        /// <returns></returns>  
        private System.Windows.Forms.DataGridViewCellStyle GetHyperLinkStyleForGridCell()
        {
            // Set the Font and Uderline into the Content of the grid cell .  
            {
                System.Windows.Forms.DataGridViewCellStyle l_objDGVCS = new System.Windows.Forms.DataGridViewCellStyle();
                //System.Drawing.Font l_objFont = new System.Drawing.Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline);
                //l_objDGVCS.Font = l_objFont;
                l_objDGVCS.ForeColor = Color.Blue;
                return l_objDGVCS;
            }
        }

        internal void SearchTags(bool IsEnable,string textToSearch, BindingList<M_Product> bindedProducts)
        {
            bindedProducts.Clear();
            _productGridData.products.Where(x => x.Tag.ToLower().Contains(textToSearch.ToLower())).ToList().
                ForEach(p => bindedProducts.Add(p));
        }

        internal void SearchTitle(bool IsEnable, string textToSearch, BindingList<M_Product> bindedProducts)
        {
            bindedProducts.Clear();
            _productGridData.products.Where(x => x.Title.ToLower().Contains(textToSearch.ToLower())).ToList().
                ForEach(p=> bindedProducts.Add(p));
        }

        internal void ResetBindings(bool IsEnable)
        {

        }

        /// End - Event handlers for data grid view


        //internal Dictionary<string, Image> LoadImages()
        //{
        //    //TODO : Remove background worker
        //    BackgroundWorker bg = new BackgroundWorker();

        //    bg.WorkerReportsProgress = true;
        //    bg.DoWork += (sender, doWorkEventArgs) =>
        //    {
        //        Dictionary<string,Image> imgs = Helper.ProjIO.LoadAllImagesAndDownSize75x75(_map._lastSavedMapImageDirectory);
        //    };
        //    bg.RunWorkerCompleted += (s, ev) =>
        //    {

        //    };
        //    bg.RunWorkerAsync();
        //}
    }
}
