using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

using UI.Models;
using UI.Entities;

namespace UI.ViewModel
{
    class ProjectViewModel : ViewModelBase
    {
       
        private ProjectModel _model;

        public ObservableCollection<ProjectEntity> Projects
        {
            get { return _model.Entities; }
            set { _model.Entities = value; }
        }

        public ProjectViewModel()
        {
            _model = new ProjectModel();
            _model.Load();
            LoadCommand = new RelayCommand(_model.Load);      
        }

        public RelayCommand LoadCommand
        {
            get;
            set;
        }
    }
}
