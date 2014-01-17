using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.Entities;

namespace UI.Models
{
    class ProjectModel
    {
        ObservableCollection<ProjectEntity> _entities;

        public ObservableCollection<ProjectEntity> Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public ProjectModel()
            :base()
        { }


        /// <summary>
        /// Load from database
        /// and wrtite to application resources
        /// </summary>
        public void Load()
        {
            Application.Current.Resources["Projects"] = _entities = new ObservableCollection<ProjectEntity>(ProjectModel.GetProjects());
        }

        public static IEnumerable<ProjectEntity> GetProjects()
        {
            return DAL.Manager.SelectFromTable("Project", String.Empty, "*").ToProjects();
        }
    }
}
