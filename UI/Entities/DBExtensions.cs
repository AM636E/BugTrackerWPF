using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

using BugTrackerWPF.DAL;

namespace UI.Entities
{
    public static class DBExtensions
    {
        public static List<ProjectEntity> ToProjects(this DataSet ds)
        {
            var rows = ds.Tables[0].Rows;
            ProjectEntity[] en = new ProjectEntity[rows.Count];

            foreach (DataRow dr in rows)
            {
                int id = Convert.ToInt32(dr["projectid"]);
                console.log(id);
                if (id < en.Length)
                {
                    en[id] = new ProjectEntity((string)dr["projecttitle"], dr["PROJECTDESCRIPTION"].ToString(), (decimal)dr["projectprice"]);
                }
            }

            return new List<ProjectEntity>(en);
        }

        public static List<EmployeeEntity> ToEmployeers(this DataSet ds)
        {
            List<EmployeeEntity> result = new List<EmployeeEntity>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(new EmployeeEntity(dr["empfname"].ToString(), dr["empsname"].ToString(), (EmployeePosition)Convert.ToInt32(dr["emppositionid"])));
            }

            return result;
        }

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
                    BugPriority f = (BugPriority)Convert.ToInt32(row["bugpriority"].ToString());
                    BugSeverity g = (BugSeverity)Convert.ToInt32(row["bugseverityid"].ToString());
                    Component h = (Component)Convert.ToInt32(row["bugcomponentid"]);
                    int i = Convert.ToInt32(row["bugbuild"]);
                    Status j = (Status)Convert.ToInt32(row["bugstatusid"]);
                    DateTime n = (DateTime)row["bugsubmitted"];//.GetType();
                    console.log(n.ToString());
                    result.Add(new BugEntity(
                            id, a, b, c, d, e, f, g, h, i, j
                    ));
                }
                catch (Exception e)
                {
                    console.log("Shit happens - " + e.Message);
                }
            }

            return result;
        }

        public static ObservableCollection<EmployeeEntity> ToEmployeersObs(this DataSet ds)
        {
            return new ObservableCollection<EmployeeEntity>(ds.ToEmployeers());
        }

        public static ObservableCollection<ProjectEntity> ToProjectsObs(this DataSet ds)
        {
            return new ObservableCollection<ProjectEntity>(ds.ToProjects());
        }

        public static ObservableCollection<BugEntity> ToBugsObs(this DataSet ds)
        {
            return new ObservableCollection<BugEntity>(ds.ToBugs());
        }

        public static void InsertBug(this DBManager manage, BugEntity bug)
        {
            string query = @"
INSERT INTO BUG
(
    BUGPROJECTID,
    BUGTITLE,
    BUGSUMMARY,
    BUGSUBMITTED,
    BUGREPORTERID,
    BUGFIXERID,
    BUGPRIORITY,
    BUGSEVERITYID,
    BUGCOMPONENTID,
    BUGBUILD,
    BUGSTATUSID
)
VALUES (";
            //to_timestamp('17-DEC-13 11.53.46.053000000 AM','DD-MON-RR HH.MI.SSXFF AM')
            Console.WriteLine(bug.Project.Id.ToString());
            query += bug.Project.Id.ToString() + ",\'";
            query += bug.Title + "\',";
            query += '\'' + bug.Summary + "\',";
            query += @"to_timestamp( '" + bug.Created.ToString("dd-MM-yyyy HH.m.s") + @"', 'DD-MM-RRRR HH24.MI.SS'),";
            query += bug.Repoter.Id.ToString() + ',';
            query += bug.Fixer.Id.ToString() + ',';
            query += ((int)bug.Prioriry).ToString() + ',';
            query += ((int)bug.Severity).ToString() + ',';
            query += ((int)bug.Component).ToString() + ',';
            query += ((int)bug.Build).ToString() + ',';
            query += ((int)bug.Status).ToString() + ")";

            DAL.Manager.ExecuteQuery(query);
            DAL.Manager.ExecuteQuery("COMMIT");
        }
    }
}
