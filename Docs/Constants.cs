using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Docs
{
    public static class Constants
    {

        public enum HelpTopic
        {
            Welcome,Products,Inventory,FkPayment,AnzPayment,SpdPayment, Orders
        }

        public struct Theme
        {
            //public static readonly Color MainFormBorderColor = Color.SteelBlue;
            public static readonly int MainFormBorderWidth = 3;
            public static readonly Color BorderColor = Color.SteelBlue;

            public static readonly int BorderWidth = 2;


        }


       


    }
}
