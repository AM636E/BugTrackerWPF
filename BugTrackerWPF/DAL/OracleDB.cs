using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace BugTrackerWPF.DAL
{
    public class OracleDB : DBManager, IDisposable
    {
        private static OracleDB _instance;
        private OracleConnection _connection;

        private OracleDB() { Connect(); }

        public override void Connect()
        {
            OracleConnectionStringBuilder osb = new OracleConnectionStringBuilder();

            osb.UserID = "zaz";
            osb.Password = "1";

            osb.DataSource = "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)))";

            _connection = new OracleConnection(osb.ToString());
        }

        public DataSet GetValue(string tablename)
        {
            return this.ExecuteQuery("SELECT * FROM " + tablename);
        }

       public override DataSet ExecuteQuery(string query)
        {
            OracleCommand command = _connection.CreateCommand();
            command.CommandText = query;

            OracleDataAdapter da = new OracleDataAdapter(command);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;
        }

       public static OracleDB Instance
        {
           get
            {
               if(_instance == null)
               {
                   _instance = new OracleDB();
               }

               return _instance;
            }
        }

        public void Dispose()
       {
           _connection.Close();
       }
    }
}
