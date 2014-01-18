using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;

using UI.Entities;
using UI.Models;

namespace UI.ViewModel
{
    class EmployeeViewModel : ViewModelBase
    {
        private EmployeeModel _model;

        public ObservableCollection<EmployeeEntity> Employees
        {
            get { return _model.Entities; }
        }

        public EmployeeViewModel()
        {
            _model.Load();
        }
    }
}
