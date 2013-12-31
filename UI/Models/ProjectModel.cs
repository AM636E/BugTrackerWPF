using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UI.Entities;

namespace UI.Models
{
    class ProjectModel
    {
        ICollectionView _entities;

        public ICollectionView Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public ProjectModel()
            :base()
        { }

        public void Load()
        {
            _entities = new CollectionViewSource
            {
                Source = new ObservableCollection<ProjectEntity>(ProjectModel.GetProjects())
            }
            .View;
        }

        public static IEnumerable<ProjectEntity> GetProjects()
        {
            return DAL.Manager.SelectFromTable("Project", String.Empty, "*").ToProjects();
        }
    }
}
