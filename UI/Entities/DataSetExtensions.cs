using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using BugTrackerWPF.DAL;

namespace UI.Entities
{
    public static class DataSetExtensions
    {

        public static List<EmployeeEntity> ToEmployeers(this DataSet ds)
        {
            List<EmployeeEntity> result = new List<EmployeeEntity>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                result.Add(new EmployeeEntity((string)dr["empfname"], (string)dr["empsname"], (EmployeePosition)dr["emppositionid"]));
            }

            return result;
        }
    }
}
