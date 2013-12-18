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

        public DataSet SelectFromTable(string tableName, string whereCondition,params string[] columns)
        {
            string query = "SELECT ";

            for (int i = 0; i < columns.Length - 1; i ++ )
            {
                query += columns[i] + ',';
            }

            query += columns[columns.Length - 1];

            query += " FROM " + tableName;
            
            if (whereCondition != String.Empty)
            {
                query += " WHERE " + whereCondition;
            }

            return this.ExecuteQuery(query);
        }

        public DataSet SelectFromTable(string tablename, params string[] columns)
        {
            return this.SelectFromTable(tablename, String.Empty, columns);
        }
    }
}
