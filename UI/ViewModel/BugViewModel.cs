using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

using UI.Entities;
using UI.Models;
using UI.Helpers;

namespace UI.ViewModel
{
    class BugViewModel : ViewModelBase
    {
        private BugModel _model;
        private string _selectedTitle;
        private string  _selectedProjectTitle;

        private ObservableCollection<string> _projects;

        public ICollectionView Bugs
        {
            get{return _model.Entities;}
            set { _model.Entities = value; }
        }

        private CollectionViewSource CVS { get; set; }

        public BugViewModel()
        {
            _model = new BugModel();
            _model.Load();
            LoadCommand = new RelayCommand(_model.Load);
            LoadData();
        }

        private void LoadData()
        {
            var projects = ProjectModel.GetProjects();
            var q1 = from t in projects
                     select t.Title;
            _projects = new ObservableCollection<string>(q1);
        }

        private void Handle_ViewCollectionViewSourceMessageToken(Hel)

        public RelayCommand LoadCommand
        {
            get;
            set;
        }
    }
}
