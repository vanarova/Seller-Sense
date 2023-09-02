using SellerSense.ViewManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.Views.Inventories
{
    internal partial class CustomSnapshotDate : Form
    {
        public CustomSnapshotDate(VM_CustomSnapshotDate vm_CustomSnapshotDate)
        {
            InitializeComponent();
            vm_CustomSnapshotDate.AssignView(this);
        }
    }
}
