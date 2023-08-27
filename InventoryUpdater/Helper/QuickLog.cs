using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerSense.Helper
{
    // Purpose of this class is for testing/debugging during development..
    // And providing logs in production, Original logger will be merged or restructured with this class.
    internal static class QuickLog
    {
        private static List<string> _quickLogs = new List<string>();
    }
}
