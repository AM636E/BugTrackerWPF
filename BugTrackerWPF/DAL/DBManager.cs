using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace BugTrackerWPF.DAL
{
    abstract public class DBManager
    {
        public abstract void Connect();

        public abstract DataSet ExecuteQuery(string query);
    }
}
