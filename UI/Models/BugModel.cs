using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Threading;
using UI.Entities;
using DA = UI.DataAccessService;

namespace UI.Models
{
    public class BugModel
    {
        ObservableCollection<BugEntity> _entities;

        public ObservableCollection<BugEntity> Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }
        public BugModel()
        {
            _entities = new ObservableCollection<BugEntity>();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 3, 0);

            timer.Tick += (o, e) => { Load(); };
        }

        public void AddBug(BugEntity entity)
        {
            _entities.Add(entity);
            DAL.Manager.InsertBug(entity);
        }

        public void Load()
        {            
            App.Current.Resources["Bugs"] = Entities = new ObservableCollection<BugEntity>(BugEntity.GetBugs());
        }

        public static System.Collections.Generic.IEnumerable<BugEntity> GetBugs()
        {
            throw new NotImplementedException();
        }
    }
}
