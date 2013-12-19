using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UI.Entities;

namespace UI.Models
{
    public class BugModel
    {
        ObservableCollection<BugEntity> _entities;

        public ObservableCollection<BugEntity> Entities
        {
            get { return _entities; }
        }

        public BugModel()
        {
            _entities = new ObservableCollection<BugEntity>();
        }

        public void Load()
        {
            _entities = DAL.Manager.SelectFromTable("bug", String.Empty, "*").ToBugs();
        }
    }
}
