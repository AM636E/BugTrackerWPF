using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace UI.ViewModel
{
    class FilterViewModel
    {
        ICollection _items;
        public FilterViewModel(ICollection items)
        {
            _items = items;
        }

        public RelayCommand<String> ApplyFilter
        { get; set; }

        public RelayCommand RemoveFilter { get; set; }

        private void Apply(object term)
        {

        }
    }
}
