using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryUpdater.Model.Interfaces;
using Newtonsoft.Json.Linq;

namespace InventoryUpdater.Model
{
    public class BaseCodeList
    {
        public List<BaseCode> codes;

        public BaseCodeList()
        {
            codes = new List<BaseCode>();
        }

        internal void ImportBaseInvCodesFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                string txt = File.ReadAllText(fileName); //create separate function for file IO
                JArray jobj = JArray.Parse(txt);
                foreach (var item in jobj)
                {
                    if (AppVersion.Ver == AppVersion.Number.V1)
                        codes.Add(item.ToObject<BaseCodeV1>());
                    else if (AppVersion.Ver == AppVersion.Number.V2)
                        codes.Add(item.ToObject<BaseCodeV2>());

                }
                //foreach (var item in jobj.Property("Inventory").Values())
                //{
                //    if (AppVersion.Ver == AppVersion.Number.V1)
                //        codes.Add(item.ToObject<BaseCodeV1>());
                //    else if (AppVersion.Ver == AppVersion.Number.V2)
                //        codes.Add(item.ToObject<BaseCodeV2>());

                //}
                //_map.CreateAnEmptyMap(_baseCodes);
            }

        }
    }




}
