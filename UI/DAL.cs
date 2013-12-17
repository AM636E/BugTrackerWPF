using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BugTrackerWPF.DAL;

namespace UI
{
    static class DAL
    {
        private static DBManager _manager = OracleDB.Instance;
        public static DBManager Manager
        {
            get
            {
                return _manager;
            }
        }
    }
}
