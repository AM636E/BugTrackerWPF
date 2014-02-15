using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BugAccessLibrary
{
    using Entities;
    public class BugAccessService : IBugAccessService
    {
        static int elementsSend = 0;
        public BugEntity[] GetBugs()
        {
            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
            con.DataSource = @"DRUD\ZAZSQLSERVER";
            con.IntegratedSecurity = true;
            con.InitialCatalog = "Zaz";
            con.UserID = "zaz";

            SqlConnection sql = new SqlConnection(con.ToString());
            SqlCommand query = sql.CreateCommand();
            query.CommandText = "SELECT * FROM Bug";

            SqlDataAdapter da = new SqlDataAdapter(query);

            DataSet ds = new DataSet();
            
            da.Fill(ds);

            var a = ds.ToBugs();
            return new BugEntity[]
            {
                new BugEntity(1, "3", 5.ToString())
            };
        }
    }

    public static class DBExtensions
    {
        public static List<BugEntity> ToBugs(this DataSet ds)
        {
            var rows = ds.Tables[0].Rows;
            List<BugEntity> result = new List<BugEntity>(rows.Count);

            foreach (DataRow row in rows)
            {
                try
                {
                    int id = Convert.ToInt32(row["bugid"]);
                    int a = Convert.ToInt32(row["bugprojectid"]);
                    string b = row["bugtitle"].ToString();
                    string c = row["bugsummary"].ToString();
                    int d = Convert.ToInt32(row["bugreporterid"].ToString());
                    int e = Convert.ToInt32(row["bugfixerid"].ToString());
                  
                    DateTime n = (DateTime)row["bugsubmitted"];//.GetType();

                    result.Add(new BugEntity(
                            id, b, c
                    ));
                }
                catch (Exception e)
                {
                    result.Add(new BugEntity() { Title = e.Message });
                }
            }

            return result;
        }
    }
}
