using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections;
using System.ComponentModel;


using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace UI.ViewModel
{
    public interface IFilterOption
    {
        string FilterTerm { get; }
    }

    public interface IFilteringSubViewModel
    {
        string FilterTerm { get; }
        bool FilterActive { get; }
        void Apply();
        void Clear();
    }

    public class FilteringSubViewModel : INotifyPropertyChanged,
                  IFilterOption, IFilteringSubViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _filterActive;
        private string _filterTerm;

        public FilteringSubViewModel()
        {
            _filterTerm = string.Empty;
        }



        public string FilterTerm
        {
            get { return _filterTerm; }
            set
            {
                _filterTerm = value;
                NotifyPropertyChanged("FilterTerm");
            }
        }

        public bool FilterActive
        {
            get { return _filterActive; }
            set
            {
                _filterActive = value;
                NotifyPropertyChanged("FilterActive");
            }
        }

        public void Apply()
        {
            FilterActive = true;
        }

        public void Clear()
        {
            FilterTerm = string.Empty;
            FilterActive = false;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
