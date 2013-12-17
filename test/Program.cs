using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;

using BugTrackerWPF.DAL;
using BugTrackerWPF;

using test.Entities;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            OracleDB db = OracleDB.Instance;

            DataSet ds = db.ExecutQuery("SELECT bugtitle FROM Bug");


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine(dr["bugtitle"]);
            }
        }
    }
}
