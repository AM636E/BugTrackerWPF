using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

using UI.Models;

namespace UI.ViewModel
{
    class BugViewModel
    {
        private BugModel _model;

        public ObservableCollection<UI.Entities.BugEntity> Bugs
        {
            get{return _model.Entities;}
        }

        public BugViewModel()
        {
            _model = new BugModel();
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
