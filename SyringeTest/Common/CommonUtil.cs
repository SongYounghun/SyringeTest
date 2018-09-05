using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvoScanner.Common
{
    static public class CommonUtil
    {
        static public bool Is64BitMode()
        {
            return System.Runtime.InteropServices.Marshal.SizeOf(typeof(IntPtr)) == 8;
        }
    }
}
