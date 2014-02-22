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
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class BugAccessService : IBugAccessService
    {
        private Employee[] _employees;
        private Bug[] _bugs;
        private Project[] _projects;
        public BugAccessService()
        {
            _employees = GetEmployees();            
            _projects = GetProjects();
            _bugs = GetBugs();
        }

        public Project[] GetProjects()
        {
            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
            con.DataSource = @"DRUD\ZAZSQLSERVER";
            con.IntegratedSecurity = true;
            con.InitialCatalog = "Zaz";
            con.UserID = "zaz";

            SqlConnection sql = new SqlConnection(con.ToString());
            SqlCommand query = sql.CreateCommand();
            query.CommandText = "SELECT * FROM Project";

            SqlDataAdapter da = new SqlDataAdapter(query);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds.ToProjects().ToArray();
        }

        public Employee[] GetEmployees()
        {
            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
            con.DataSource = @"DRUD\ZAZSQLSERVER";
            con.IntegratedSecurity = true;
            con.InitialCatalog = "Zaz";
            con.UserID = "zaz";

            SqlConnection sql = new SqlConnection(con.ToString());
            SqlCommand query = sql.CreateCommand();
            query.CommandText = "SELECT * FROM Employee";

            SqlDataAdapter da = new SqlDataAdapter(query);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds.ToEmployees().ToArray();
        }

        public Bug[] GetBugs()
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

            return ds.ToBugs().ToArray();
        }


        public int GetValue()
        {
            Console.WriteLine("Request");
            return 2;
        }

        public Data GetTest()
        {
            return new Data() { Component = Component.API, Severity = BugSeverity.Critical };
        }


        public Bug GetBug()
        {
            return new Bug(){ Component = Component.API, Severity = BugSeverity.Critical };
        }
    }

    public static class DBExtensions
    {
        public static List<Bug> ToBugs(this DataSet ds)
        {
            var rows = ds.Tables[0].Rows;
            List<Bug> result = new List<Bug>(rows.Count);

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
                    BugPriority f = (BugPriority)Convert.ToInt32(row["bugpriority"].ToString());
                    BugSeverity g = (BugSeverity)Convert.ToInt32(row["bugseverityid"].ToString());
                    Component h = (Component)Convert.ToInt32(row["bugcomponentid"]);
                    int i = Convert.ToInt32(row["bugbuild"]);
                    Status j = (Status)Convert.ToInt32(row["bugstatusid"]);
                    DateTime n = (DateTime)row["bugsubmitted"];//.GetType();
                    
                    result.Add(new Bug(
                            id, a, b, c, d, e, f, g, h, i, j
                    ));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return result;
        }
        public static List<Project> ToProjects(this DataSet ds)
        {
            var rows = ds.Tables[0].Rows;
            Project[] en = new Project[rows.Count];

            foreach (DataRow dr in rows)
            {
                int id = Convert.ToInt32(dr["projectid"]);
                if (id < en.Length)
                {
                    en[id] = new Project(id, (string)dr["projecttitle"], dr["PROJECTDESCRIPTION"].ToString(), (decimal)dr["projectprice"]);
                }
            }

            return new List<Project>(en);
        }

        public static List<Employee> ToEmployees(this DataSet ds)
        {
            List<Employee> result = new List<Employee>();
            var rows = ds.Tables[0].Rows;
            Employee[] en = new Employee[rows.Count];

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(dr["empid"]);
                if (id < en.Length)
                {
                    en[id] = new Employee(dr["empfname"].ToString(), dr["empsname"].ToString(), (EmployeePosition)Convert.ToInt32(dr["emppositionid"]));
                }
            }

            return new List<Employee>(en);
        }
        
    }
}
