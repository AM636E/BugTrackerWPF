using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using UI.Entities;

namespace UI.Models
{
    public class BugModel
    {
        ICollectionView  _entities;

        public ICollectionView Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public ObservableCollection<BugEntity> EntitiesObs
        {
            set { _entities = new CollectionViewSource { Source = value }.View; }
        }

        public BugModel()
        {
            
        }

        public void Load()
        {
            EntitiesObs = DAL.Manager.SelectFromTable("bug", String.Empty, "*").ToBugsObs();
        }
    }
}
