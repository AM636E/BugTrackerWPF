using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        private bool _canRemoveTitleFilter;
        private bool _canRemoveProjectFilter;
        private ObservableCollection<ProjectEntity> _projects;
        private ObservableCollection<BugEntity> _bugs;

        private enum FilterField
        {
            Title,
            ProjectTitle
        }

        #region Properties
        public ObservableCollection<ProjectEntity> Projects
        {
            get { return _projects; }
        }

        public ICollectionView Bugs
        {
            get{return _model.Entities;}
            set { _model.Entities = value; }
        } 
        private CollectionViewSource CVS { get; set; }

        public bool CanRemoveTitleFilter
        {
            get { return _canRemoveTitleFilter; }
            set
            {
                _canRemoveTitleFilter = value;
                RaisePropertyChanged("CanRemoveTitleFilter");
            }
        }
        public bool CanRemoveProjectFilter
        {
            get { return _canRemoveProjectFilter; }
            set
            {
                _canRemoveTitleFilter = value;
                RaisePropertyChanged("CanRemoveProjectFilter");
            }
        }
        public string SelectedTitle
        {
            get { return _selectedTitle; }
            set
            {
                MessageBox.Show(value.ToString());
                if(_selectedTitle == value)
                {
                    return;
                }
                _selectedTitle = value;
                RaisePropertyChanged("SelectedCountry");
            }
        }
        #endregion       

        public BugViewModel()
        {
            _model = new BugModel();
            _model.Load();
            LoadCommand = new RelayCommand(_model.Load);
            LoadData();
        }

        private void LoadData()
        {
            List<BugEntity> data = BugEntity.GetBugs();
            var a = from bug in data
                    select bug.Project;
            _projects = new ObservableCollection<ProjectEntity>(a.Distinct());
            _bugs = new ObservableCollection<BugEntity>(data);
        }

        private void InitCommands()
        {

        }

        private void Handle_ViewCollectionViewSourceMessageToken(ViewCollectionViewSourceMessageToken token)
        {
            CVS = token.CVS;        
        }

        public void AddTitleFilter()
        {
            if(CanRemoveTitleFilter)
            {
                CVS.Filter -= new FilterEventHandler(FilterByTitle);
                CVS.Filter += new FilterEventHandler(FilterByTitle);
            }
            else
            {
                CVS.Filter += new FilterEventHandler(FilterByTitle);
                CanRemoveTitleFilter = true;
            }
        }
        private void FilterByTitle(object sender, FilterEventArgs e)
        {
            var src = e.Item as BugEntity;

            if(src == null)
            {
                e.Accepted = false;
            }
            else if(src.Title.IndexOf(SelectedTitle) == -1 )
            {
                e.Accepted = false;
            }
        }

        private void ApplyFilter(FilterField filter)
        {
            switch(filter)
            {
                case FilterField.Title:
                    {

                        break;
                    }
            }
        }

        public RelayCommand LoadCommand
        {
            get;
            set;
        }
    }
}
