using SellerSense.Helper;
using SellerSense.Views.Inventories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense
{
    internal partial class Welcome : Form
    {
        //Company _company;
        SellerSense.ViewManager.VM_Companies _companiesMgr;
        public Welcome()
        {
            _companiesMgr = new SellerSense.ViewManager.VM_Companies();
            
            InitializeComponent();
            //ProjIO.LoadUserSettings();
            
        }


        private void CheckIfSetupNeedsToRun()
        {
            if (_companiesMgr._companies == null || _companiesMgr._companies.Count == 0)
                AdjustUI("EnableOnlySetupButton"); //Force use to run set again.
            else
                AdjustUI("EnableAllButton");
        }

        private async void btn_Inventories_Click(object sender, EventArgs e)
        {
            pbarLoadForms.Visible = true;

            //load images for all companies async
            var imgs = await _companiesMgr._companies[0].LoadImages();
            _companiesMgr._companies[0]._images = imgs;
            _companiesMgr._companies[0]._inventoriesViewManager.AssignImagesToProducts(imgs);

            var imgs1 = await _companiesMgr._companies[1].LoadImages();
            _companiesMgr._companies[1]._images = imgs1;
            _companiesMgr._companies[1]._inventoriesViewManager.AssignImagesToProducts(imgs1);

            DisplayInvForm();


            ////try
            ////{
            //    //DataSet mapGridData = new DataSet();
            //    pbarLoadForms.Visible = true;
            //    //_company._map.LoadLastSavedMap();

            //    //Load data one after another async fashion..at the end display form.
            //    _companiesMgr._companies[0]._mapping.FillLoadedMapToGridDataset(() => {
            //        if (_companiesMgr._companies.Count > 1)
            //        {
            //            _companiesMgr._companies[1]._mapping.FillLoadedMapToGridDataset(() => {
            //                if (_companiesMgr._companies.Count > 2)
            //                {
            //                    _companiesMgr._companies[2]._mapping.FillLoadedMapToGridDataset(() => {
            //                        if (_companiesMgr._companies.Count > 3)
            //                        {

            //                            _companiesMgr._companies[3]._mapping.FillLoadedMapToGridDataset(() => {
            //                                if (_companiesMgr._companies.Count > 4)
            //                                {
            //                                    _companiesMgr._companies[4]._mapping.FillLoadedMapToGridDataset(() => {
            //                                        //max count reached, 5th company
            //                                        DisplayMapForm();

            //                                    });

            //                                }
            //                                else
            //                                    DisplayMapForm();
            //                            });
            //                        }
            //                        else
            //                            DisplayMapForm();
            //                    });

            //                } else
            //                    DisplayMapForm();
            //            });
            //        }
            //        else
            //            DisplayMapForm();
            //    });




        }


        //private void DisplayMapForm()
        //{
        //    Mapping mp = new Mapping(_companiesMgr);
        //    mp.MdiParent = this;
        //    pbarLoadForms.Visible = false;
        //    mp.FormClosed += (s, args) => { AdjustUI("BringWelcomeButtonToFront"); };
        //    mp.Show();

        //    AdjustUI("SendWelcomeButtonToBack");
        //}


        private void DisplayProductForm()
        {
            ProductListing mp = new ProductListing(_companiesMgr);
            mp.MdiParent = this;
            pbarLoadForms.Visible = false;
            mp.FormClosed += (s, args) => { AdjustUI("BringWelcomeButtonToFront"); };
            mp.Show();

            AdjustUI("SendWelcomeButtonToBack");
        }

        //private void Mp_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void Welcome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.P)
            {
                Admin sa = new Admin();
                sa.ShowDialog();
            }

        }

        private void Welcome_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        

        private void DisplayInvForm()
        {
            //Mapping mp = new Mapping(_companiesMgr);
            //mp.MdiParent = this;
            //pbarLoadForms.Visible = false;
            //mp.FormClosed += (s, args) => { AdjustUI("BringWelcomeButtonToFront"); };
            //mp.Show();
            //AdjustUI("SendWelcomeButtonToBack");

            Inventories iu = new Inventories(_companiesMgr);
            iu.MdiParent = this;
            pbarLoadForms.Visible = !pbarLoadForms.Visible;
            iu.Show();
            iu.FormClosed += (s, args) => { AdjustUI("BringWelcomeButtonToFront"); };
            AdjustUI("SendWelcomeButtonToBack");
        }


        private async void btn_invUpdate_Click(object sender, EventArgs e)
        {

            pbarLoadForms.Visible = true;

            //load images for all companies async
            var imgs = await _companiesMgr._companies[0].LoadImages();
            _companiesMgr._companies[0]._images = imgs;
            _companiesMgr._companies[0]._productViewManager.AssignImagesToProducts(imgs);

            var imgs1 = await _companiesMgr._companies[1].LoadImages();
            _companiesMgr._companies[1]._images = imgs1;
            _companiesMgr._companies[1]._productViewManager.AssignImagesToProducts(imgs1);

            DisplayProductForm();

            //pbarLoadForms.Visible = true;

            //_companiesMgr._companies[0]._inventoriesViewManager.LoadInvDataFromLastSavedMap(); //TODO load async
            //if (_companiesMgr._companies.Count > 1)
            //    _companiesMgr._companies[1]._inventoriesViewManager.LoadInvDataFromLastSavedMap(); //TODO load async
            //if (_companiesMgr._companies.Count > 2)
            //    _companiesMgr._companies[2]._inventoriesViewManager.LoadInvDataFromLastSavedMap(); //TODO load async
            //if (_companiesMgr._companies.Count > 3)
            //    _companiesMgr._companies[3]._inventoriesViewManager.LoadInvDataFromLastSavedMap(); //TODO load async
            //if (_companiesMgr._companies.Count > 4)
            //    _companiesMgr._companies[4]._inventoriesViewManager.LoadInvDataFromLastSavedMap(); //TODO load async


            //_companiesMgr._companies[0]._inventoriesViewManager.GetInvUpdateGridDataset(() =>
            //{
            //    if (_companiesMgr._companies.Count > 1)
            //    {
            //        _companiesMgr._companies[1]._inventoriesViewManager.GetInvUpdateGridDataset(() =>
            //        {
            //            if (_companiesMgr._companies.Count > 2)
            //            {
            //                _companiesMgr._companies[2]._inventoriesViewManager.GetInvUpdateGridDataset(() =>
            //                {
            //                    if (_companiesMgr._companies.Count > 2)
            //                    {
            //                        _companiesMgr._companies[3]._inventoriesViewManager.GetInvUpdateGridDataset(() =>
            //                        {
            //                            if (_companiesMgr._companies.Count > 3)
            //                            {
            //                                _companiesMgr._companies[4]._inventoriesViewManager.GetInvUpdateGridDataset(() =>
            //                                {
            //                                    DisplayInvForm();
            //                                });
            //                            }
            //                            else DisplayInvForm();

            //                        });
            //                    }
            //                    else DisplayInvForm();

            //                });
            //            }
            //            else DisplayInvForm();

            //        });
            //    }
            //    else DisplayInvForm();

            //});


        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            CheckIfSetupNeedsToRun();
            AdjustUI("AdjustWelcomeButtons");
        }

        internal void AdjustUI(string trigger, object sender = null, object args = null)
        {
            switch (trigger)
            {
                case "EnableOnlySetupButton":
                    btn_invUpdate.Enabled = false;
                    btn_Reports.Enabled = false;
                    btn_Setup.Enabled = true;
                    btn_mapping.Enabled = false;
                    break;
                case "EnableAllButtons":
                    btn_invUpdate.Enabled = true;
                    btn_Reports.Enabled = true;
                    btn_Setup.Enabled = true;
                    btn_mapping.Enabled = true;
                    break;
                case "AdjustWelcomeButtons":
                    tblWelcomeButtons.Location = 
                        new Point(Convert.ToInt16(this.Size.Width / 2) - 285, Convert.ToInt16(this.Size.Height / 2) - 137);
                    break;
                case "SendWelcomeButtonToBack":
                    tblWelcomeButtons.SendToBack();
                    break;
                case "BringWelcomeButtonToFront":
                    tblWelcomeButtons.BringToFront();
                    break;
                default:
                    break;
            }

        }

        private void Welcome_SizeChanged(object sender, EventArgs e)
        {
            AdjustUI("AdjustWelcomeButtons");
        }

        private void btn_Setup_Click(object sender, EventArgs e)
        {
            SetUp c = new SetUp(_companiesMgr); //TODO : sometimes user double click these dashboard buttons and 2 windows open, handle this issue.
            c.FormClosed += (senderObj, formClosedEventArgs) => {
                CheckIfSetupNeedsToRun();
            };
            c.Show();
        }

        private async void btn_products_Click(object sender, EventArgs e)
        {
           
            //pbarLoadForms.Visible = true;

            ////load images for all companies async
            //var imgs = await _companiesMgr._companies[0].LoadImages();
            //_companiesMgr._companies[0]._images = imgs;
            //_companiesMgr._companies[0]._productViewManager.AssignImagesToProducts(imgs);
               
            //var imgs1 = await _companiesMgr._companies[1].LoadImages();
            //_companiesMgr._companies[1]._images = imgs1;
            //_companiesMgr._companies[1]._productViewManager.AssignImagesToProducts(imgs1);
            
            //DisplayProductForm();

        }
    }
}
