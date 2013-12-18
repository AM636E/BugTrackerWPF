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

        public static ObservableCollection<EmployeeEntity> ToEmployeers(this DataSet ds)
        {
            ObservableCollection<EmployeeEntity> result = new ObservableCollection<EmployeeEntity>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(new EmployeeEntity(dr["empfname"].ToString(), dr["empsname"].ToString(), (EmployeePosition)Convert.ToInt32(dr["emppositionid"])));
            }

            return result;
        }

        public static ObservableCollection<ProjectEntity> ToProjects(this DataSet ds)
        {
            ObservableCollection<ProjectEntity> result = new ObservableCollection<ProjectEntity>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(new ProjectEntity((string)dr["projecttitle"], dr["PROJECTDESCRIPTION"].ToString(), (decimal)dr["projectprice"]));
            }

            return result;
        }

        public static ObservableCollection<BugEntity> ToBugs(this DataSet ds)
        {
            ObservableCollection<BugEntity> result = new ObservableCollection<BugEntity>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int         a =              Convert.ToInt32(dr["bugprojectid"]);
                string      b =              dr["bugtitle"].ToString();
                string      c =              dr["bugsummary"].ToString();
                int         d =              Convert.ToInt32(dr["bugreporterid"]);
                int         e =              Convert.ToInt32(dr["bugfixerid"]);
                BugPriority f = (BugPriority)Convert.ToInt32(dr["bugpriority"]);
                BugSeverity g = (BugSeverity)Convert.ToInt32(dr["bugseverityid"]);
                Component   h = (Component)  Convert.ToInt32(dr["bugcomponentid"]);
                int         i =              Convert.ToInt32(dr["bugbuild"]);
                Status      j = (Status)     Convert.ToInt32(dr["bugstatusid"]);

                result.Add(new BugEntity(
                        a, b, c, d, e, f, g, h, i, j 
               ));
            }

            return result;
        }
    }
}
