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
        }

        public BugModel()
        {
            
        }

        public void Load()
        {
            _entities = 
                new CollectionViewSource { Source = DAL.Manager.SelectFromTable("bug", String.Empty, "*").ToBugs() }.View;
        }
    }
}
