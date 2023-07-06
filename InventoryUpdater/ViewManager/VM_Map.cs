using SellerSense.Model;
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
    internal class VM_Map
    {
        internal string _name;
        internal string _code;
        internal M_Product _map { get; set; }
        internal DataSet _mapGridData { get; set; }

        public VM_Map(string name, string code)
        {
            _name = name;
            _code = code;
            _map = new M_Product(_code);
            _map.LoadLastSavedMap(); //Todo : Why calling twice, already called inside ctor of Map
        }

        internal void FillLoadedMapToGridDataset(Action DataSetLoaded)
        {
            //this.WindowState = FormWindowState.Minimized;
            //TODO : Remove background worker
            BackgroundWorker bg = new BackgroundWorker();
            DataSet ds = new DataSet(); ds.Tables.Add("t");
            ds.Tables[0].Columns.Add(Constants.MCols.Image, typeof(Image));
            ds.Tables[0].Columns.Add(Constants.MCols.Code);
            ds.Tables[0].Columns.Add(Constants.MCols.Title);
            ds.Tables[0].Columns.Add(Constants.MCols.amz_Code);
            ds.Tables[0].Columns.Add(Constants.MCols.fK_Code);
            ds.Tables[0].Columns.Add(Constants.MCols.spd_Code);
            ds.Tables[0].Columns.Add(Constants.MCols.mso_Code);
            ds.Tables[0].Columns.Add(Constants.MCols.notes);

            bg.WorkerReportsProgress = true;
            bg.DoWork += (sender, doWorkEventArgs) =>
            {
                Dictionary<string,Image> imgs = Helper.ProjIO.LoadAllImagesAndDownSize75x75(_map._lastSavedMapImageDirectory);
                _map._productEntries.ForEach((x) =>
                {
                    Image timg = imgs.Where(i => Path.GetFileName(i.Key) == x.Image).FirstOrDefault().Value;
                    //Image img = null; Image timg = null;
                    //if (File.Exists(Path.Combine(_map._lastSavedMapImageDirectory, x.Image))) //TODO : Remove File IO code, already in ProjIO
                    //{
                    //    img = Image.FromFile(Path.Combine(_map._lastSavedMapImageDirectory, x.Image));
                    //    timg = new Bitmap(img, new Size(75, 75));
                    //}
                    DataRow dr = ds.Tables[0].Rows.Add(timg, x.InHouseCode, x.Title, x.AmazonCode, x.FlipkartCode, x.SnapdealCode, x.MeeshoCode, x.Notes);
                });
            };
            bg.RunWorkerCompleted += (s, ev) =>
            {
                _mapGridData = ds;
                DataSetLoaded();
            };
            bg.RunWorkerAsync();
            //return ds;
        }
    }
}
