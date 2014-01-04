using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
        private ProjectEntity  _selectedProject;
        private bool _canRemoveTitleFilter;
        private bool _canRemoveProjectFilter;
        private ObservableCollection<ProjectEntity> _projects;
        private ObservableCollection<BugEntity> _bugs;

        private enum FilterField
        {
            Title,
            ProjectTitle
        }

        #region Commands
        public RelayCommand<String> RemoveFilter
        {
            get;
            set;
        }
        public RelayCommand LoadCommand
        {
            get;
            set;
        }
        #endregion

        #region Properties
        public RemoveFilterDelegate ProjectTitleFilter
        {
            get { return AddProjectTitleFilter; }
        }
        public ObservableCollection<ProjectEntity> Projects
        {
            get 
            {
                return (ObservableCollection<ProjectEntity>)App.Current.FindResource("Projects");
            }
        }

        public ObservableCollection<BugEntity> BugsObs
        {
            get { return _bugs; }
        }

        public ObservableCollection<BugEntity> Bugs
        {
            get{return _model.Entities;}
            set { _model.Entities = value; RaisePropertyChanged("Bugs"); }
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
                if (_selectedTitle == value)
                {
                    return;
                }
                _selectedTitle = value;
                RaisePropertyChanged("SelectedTitle");
                AddTitleFilter();
            }
        }
        public ProjectEntity SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                if (_selectedProject == value)
                {
                    return;
                }
                _selectedProject = value;
                RaisePropertyChanged("SelectedProjectTitle");
                AddProjectTitleFilter();
            }
        }
        #endregion       

        public BugViewModel()
        {
            _model = new BugModel();
            _model.Load();
            LoadCommand = new RelayCommand(_model.Load);
            LoadData();
            Messenger.Default.Register<ViewCollectionViewSourceMessageToken>(this, Handle_ViewCollectionViewSourceMessageToken);
            _InitCommands();
            _InitRemoveFilters();
        }

        private void LoadData()
        {
            _projects = (ObservableCollection<ProjectEntity>)App.Current.FindResource("Projects");
            _bugs = (ObservableCollection<BugEntity>)App.Current.FindResource("Bugs");
        }

        private void _InitCommands()
        {
            RemoveFilter = new RelayCommand<String>(_RemoveFilter);
        }
        
        public delegate void RemoveFilterDelegate();
        Dictionary<string, RemoveFilterDelegate> _removeFilters;        

        private void _InitRemoveFilters()
        {
            _removeFilters["project"] = () => 
            {
                CVS.Filter -= FilterByProjectTitle;
                CanRemoveProjectFilter = false;
            };

            _removeFilters["project"] = () =>
            {
                CVS.Filter -= FilterByProjectTitle;
                CanRemoveProjectFilter = false;
            };
        }

        private void _RemoveFilter(String filtername)
        {
            _removeFilters["filtername"]();
        }

        private void Handle_ViewCollectionViewSourceMessageToken(ViewCollectionViewSourceMessageToken token)
        {
            CVS = token.CVS;        
        }

        #region Filters
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

        public void AddProjectTitleFilter()
        {
            if(CanRemoveProjectFilter)
            {
                CVS.Filter -= new FilterEventHandler(FilterByProjectTitle);
                CVS.Filter += new FilterEventHandler(FilterByProjectTitle);
            }
            else
            {
                CVS.Filter += new FilterEventHandler(FilterByProjectTitle);
                CanRemoveProjectFilter = true;
            }
        }

        private void FilterByProjectTitle(object sender, FilterEventArgs e)
        {
            BugEntity bug = e.Item as BugEntity;
            
            if(bug == null || bug.Project.Title != SelectedProject.Title)
            {
                e.Accepted = false;
            }
        }

        private void FilterByTitle(object sender, FilterEventArgs e)
        {
            var src = e.Item as BugEntity;

            if(src == null || src.Title.IndexOf(SelectedTitle) == -1)
            {
                e.Accepted = false;
            }
        }
        #endregion
    }
}
