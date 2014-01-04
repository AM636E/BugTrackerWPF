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
        ObservableCollection<BugEntity>  _entities;

        public ObservableCollection<BugEntity> Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }
        public BugModel()
        {
            _entities = new ObservableCollection<BugEntity>();
        }

        public void Load()
        {
            Entities = DAL.Manager.SelectFromTable("bug", String.Empty, "*").ToBugsObs();
        }
    }
}
