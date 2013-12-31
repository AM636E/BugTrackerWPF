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
        public static IEnumerable<ProjectEntity> ToProjects(this DataSet ds)
        {
            List<ProjectEntity> result = new List<ProjectEntity>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(new ProjectEntity((string)dr["projecttitle"], dr["PROJECTDESCRIPTION"].ToString(), (decimal)dr["projectprice"]));
            }

            return result;
        }

        public static IEnumerable<EmployeeEntity> ToEmployeers(this DataSet ds)
        {
            List<EmployeeEntity> result = new List<EmployeeEntity>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(new EmployeeEntity(dr["empfname"].ToString(), dr["empsname"].ToString(), (EmployeePosition)Convert.ToInt32(dr["emppositionid"])));
            }

            return result;
        }

        public static IEnumerable<BugEntity> ToBugs(this DataSet ds)
        {
            List<BugEntity> result = new List<BugEntity>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(dr["bugid"]);
                int a = Convert.ToInt32(dr["bugprojectid"]);
                string b = dr["bugtitle"].ToString();
                string c = dr["bugsummary"].ToString();
                int d = Convert.ToInt32(dr["bugreporterid"]);
                int e = Convert.ToInt32(dr["bugfixerid"]);
                BugPriority f = (BugPriority)Convert.ToInt32(dr["bugpriority"]);
                BugSeverity g = (BugSeverity)Convert.ToInt32(dr["bugseverityid"]);
                Component h = (Component)Convert.ToInt32(dr["bugcomponentid"]);
                int i = Convert.ToInt32(dr["bugbuild"]);
                Status j = (Status)Convert.ToInt32(dr["bugstatusid"]);

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
