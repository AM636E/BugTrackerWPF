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

using UI.Models;

namespace UI.ViewModel
{
    class BugViewModel : ViewModelBase
    {
        private BugModel _model;

        public ICollectionView Bugs
        {
            get{return _model.Entities;}
            set { _model.Entities = value; }
        }

        public BugViewModel()
        {
            _model = new BugModel();
            _model.Load();
            LoadCommand = new RelayCommand(_model.Load);          
        }
    
        public void SetFilter(int index)
        {
            
        }
       
        public RelayCommand LoadCommand
        {
            get;
            set;
        }
    }
}
