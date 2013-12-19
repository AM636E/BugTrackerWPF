using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UI.Entities;

namespace UI.Models
{
    class ProjectModel
    {
        ObservableCollection<ProjectEntity> _entities;

        public ObservableCollection<ProjectEntity> Entities
        {
            get { return _entities; }
        }

        public ProjectModel()
        {
            _entities = new ObservableCollection<ProjectEntity>();
        }

        public void Load()
        {
            _entities = DAL.Manager.SelectFromTable("Project", String.Empty, "*").ToProjects();
        }
    }
}
