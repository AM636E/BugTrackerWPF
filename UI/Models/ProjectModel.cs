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

        public void Load()
        {
            _entities = new ObservableCollection<ProjectEntity>(ProjectModel.GetProjects());
            ProjectEntity.log.Trace("load");
            App.Current.Resources.Add("Projects", null);
            App.Current.Resources["Projects"] = _entities;
        }

        public static IEnumerable<ProjectEntity> GetProjects()
        {
            return DAL.Manager.SelectFromTable("Project", String.Empty, "*").ToProjects();
        }
    }
}
