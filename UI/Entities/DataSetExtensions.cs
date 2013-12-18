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

        public static Collection<EmployeeEntity> ToEmployeers(this DataSet ds)
        {
            Collection<EmployeeEntity> result = new Collection<EmployeeEntity>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(new EmployeeEntity(dr["empfname"].ToString(), dr["empsname"].ToString(), (EmployeePosition)Convert.ToInt32(dr["emppositionid"])));
            }

            return result;
        }

        public static Collection<ProjectEntity> ToProjects(this DataSet ds)
        {
            Collection<ProjectEntity> result = new Collection<ProjectEntity>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(new ProjectEntity((string)dr["projecttitle"], dr["PROJECTDESCRIPTION"].ToString(), (decimal)dr["projectprice"]));
            }

            return result;
        }

        public static Collection<BugEntity> ToBugs(this DataSet ds)
        {
            Collection<BugEntity> result = new Collection<BugEntity>();
            result.Add(new BugEntity());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var a = Convert.ToInt32(dr["bugprojectid"]);
                var b = dr["bugtitle"].ToString();
                var c = dr["bugsummary"].ToString();
                var d = Convert.ToInt32(dr["bugreporterid"]);
                var e = Convert.ToInt32(dr["bugfixerid"]);
                var f = (BugPriority)Convert.ToInt32(dr["bugpriority"]);
                var g = (BugSeverity)Convert.ToInt32(dr["bugseverityid"]);
                var h = (Component)Convert.ToInt32(dr["bugcomponentid"]);
                var i = Convert.ToInt32(dr["bugbuild"]);
                var j = (Status)Convert.ToInt32(dr["bugstatusid"]);

                result.Add(new BugEntity(
                        a, b, c, d, e, f, g, h, i, j 
               ));
                MessageBox.Show(Convert.ToInt32(dr["bugbuild"]).ToString());
            }

            return result;
        }
    }
}
