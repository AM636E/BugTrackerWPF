using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

using System.Windows;

namespace UI.Entities
{
    public class ProjectEntity
    {
        private int _projectid;
        private string _projecttitle;
        private string _projectdescription;
        private decimal _projectprice;

        public int Id { get { return _projectid; } }
        public Decimal Price { get { return _projectprice; } set { _projectprice = value; } }
        public string Title { get { return _projecttitle; } set { _projecttitle = value; } }
        public string Description { get { return _projectdescription; } set { _projectdescription = value; } }

        public ProjectEntity()
        {

        }

        public ProjectEntity(int projectid)
        {
            _projectid = projectid;

            try
            {
                DataSet ds = DAL.Manager.SelectFromTable(
                    "project",
                    String.Format("projectid = {0}", _projectid),
                    "projecttitle",
                    "projectdescription",
                    "projectprice"
                    );

                DataRow row = ds.Tables[0].Rows[0];

                _projecttitle = (string)row["projecttitle"];
                _projectprice = (decimal)row["projectprice"];;
                _projectdescription = row["projectdescription"].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format("Unable to get project from DB: {0}", e.Message));
            }
        }

        public static ProjectEntity GetProjectById(int projectid)
        {
            return new ProjectEntity(projectid);
        }
    }
}
