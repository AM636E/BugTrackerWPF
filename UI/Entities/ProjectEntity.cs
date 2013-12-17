using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace UI.Entities
{
    class ProjectEntity
    {
        private int _projectid;
        private string _projecttitle;
        private string _projectdescription;
        private decimal _projectprice;

        public ProjectEntity(int projectid)
        {
            _projectid = projectid;

            try
            {
                DataSet ds = DAL.Manager.ExecuteQuery(
                    String.Format(
                        "SELECT projecttitle, projectdescription, projectprice " +
                        "FROM Project " +
                        "WHERE projectid = {0}", _projectid
                    )
                );

            }
            catch(Exception e)
            {
                
            }
        }
    }
}
