using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UI.Entities;

namespace UI.Models
{
    class EmployeeModel
    {
        ObservableCollection<EmployeeEntity> _entities;

        public ObservableCollection<EmployeeEntity> Entities
        {
            get { return _entities; }
        }

        public EmployeeModel()
        {
            _entities = new ObservableCollection<EmployeeEntity>();
        }

        public void Load()
        {
            _entities = DAL.Manager.SelectFromTable("Employee", String.Empty, "*").ToEmployeers();
        }
    }
}
