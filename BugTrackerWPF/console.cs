using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace UI
{
    public class console
    {
        public static readonly Logger loger = LogManager.GetCurrentClassLogger();

        public static void log(object o)
        {
            loger.Trace(o);
        }
    }
}
