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
    public static class DataSetExtensions
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
                int id = Convert.ToInt32(row["bugid"]);
                int a = Convert.ToInt32(row["bugprojectid"]);
                string b = row["bugtitle"].ToString();
                string c = row["bugsummary"].ToString();
                int d = Convert.ToInt32(row["bugreporterid"]);
                int e = Convert.ToInt32(row["bugfixerid"]);
                BugPriority f = (BugPriority)Convert.ToInt32(row["bugpriority"]);
                BugSeverity g = (BugSeverity)Convert.ToInt32(row["bugseverityid"]);
                Component h = (Component)Convert.ToInt32(row["bugcomponentid"]);
                int i = Convert.ToInt32(row["bugbuild"]);
                Status j = (Status)Convert.ToInt32(row["bugstatusid"]);
                result.Add(new BugEntity(
                        id, a, b, c, d, e, f, g, h, i, j
                ));
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
    }
}
