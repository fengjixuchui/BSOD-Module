using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Crash
{
    class Properties
    {
        public static Process GetVRCProcess()
        {
            return Process.GetProcessesByName("csrss")[0];
        }
    }
}
