using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.ViewManager
{
    public interface IManageTwoUserControls
    {
        void AssignViewAManager(UserControl view);
        void AssignViewBManager(UserControl view);
    }

}
