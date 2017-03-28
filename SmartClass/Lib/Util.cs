using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.Lib
{
    class Util
    {
        public static void DealWithDisConnect(Parameters param)
        {
            
        }
        public static long GetTimeStamp(DateTime dt)
        {
            TimeSpan ts = dt - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            long ret = Convert.ToInt64(ts.TotalMilliseconds) - 28800000;
            return ret;
        }
    }
}
