using System;
using System.Collections.Generic;
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
            set { _entities = value; }
        }


        public EmployeeModel()
        {
            _entities = new ObservableCollection<EmployeeEntity>();
        }

        /// <summary>
        /// Load employees from database and assing to application resources
        /// </summary>
        public void Load()
        {
             App.Current.Resources["Employees"] = _entities = new ObservableCollection<EmployeeEntity>(EmployeeModel.GetEmployees());
        }

        public static IEnumerable<EmployeeEntity> GetEmployees()
        {
            return DAL.Manager.SelectFromTable("Employee", String.Empty, "*").ToEmployeers();
        }
    }
}
