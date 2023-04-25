using InventoryUpdater.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryUpdater
{
    public partial class Welcome : Form
    {
        Driver _driver;
        public Welcome()
        {
            _driver = new Driver();
            InitializeComponent();
            FileIO.LoadUserSettings();
            
        }

        private void btn_mapping_Click(object sender, EventArgs e)
        {
            try
            {
                //DataSet mapGridData = new DataSet();
                pbarLoadForms.Visible = true;
                _driver._map.LoadLastSavedMap();
                _driver.GetMappingGridDataset(() =>
                {
                    Mapping mp = new Mapping(_driver);
                    mp.MdiParent = this;
                    pbarLoadForms.Visible = false;
                    mp.FormClosed += (s, args) => { AdjustUI("BringWelcomeButtonToFront"); };
                    mp.Show();

                    AdjustUI("SendWelcomeButtonToBack");
                });
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void Mp_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void Welcome_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.Shift && e.KeyCode == Keys.P)
            {
                SuperAdmin sa = new SuperAdmin();
                sa.ShowDialog();
            }
        }

        private void Welcome_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

       

        private void btn_invUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                pbarLoadForms.Visible = true;
                _driver.LoadInvDataFromLastSavedMap();
                _driver.GetInvUpdateGridDataset(() =>
                {
                    InvUpdate mp = new InvUpdate(_driver);
                    mp.MdiParent = this;
                    pbarLoadForms.Visible = !pbarLoadForms.Visible;
                    mp.Show();
                    mp.FormClosed += (s, args) => { AdjustUI("BringWelcomeButtonToFront"); };
                    AdjustUI("SendWelcomeButtonToBack");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error occurred",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            AdjustUI("AdjustWelcomeButtons");
        }

        internal void AdjustUI(string trigger, object sender = null, object args = null)
        {
            switch (trigger)
            {
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
    }
}
