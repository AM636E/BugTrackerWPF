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

namespace UI.ViewModel
{
    class BugViewModel : ViewModelBase
    {
        private readonly IFilter _filter;
        

        public IFilteringSubViewModel FilterVM { get; set; }

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
            FilterVM = new FilteringSubViewModel();
            _filter = new BugTitleFilter(FilterVM as IFilterOption);
            FilterApply = new RelayCommand(ApplyFilter);
            FilterRemove = new RelayCommand(RemoveFilter);
        }
        
        public void ApplyFilter()
        {
            //System.Windows.MessageBox.Show("hello");
            FilterVM.Apply();
            Bugs.Filter = _filter.Apply;
        }

        public void RemoveFilter()
        {
            FilterVM.Clear();
            Bugs.Filter = null;
        }
        public RelayCommand FilterApply { get; set; }
        public RelayCommand FilterRemove { get; set; }

        public RelayCommand LoadCommand
        {
            get;
            set;
        }
    }
}
