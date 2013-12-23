using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Entities;

namespace UI.ViewModel
{
    public interface IFilter
    {
        bool Apply(object parameter);
    }

    class BugTitleFilter : IFilter
    {
        private IFilterOption _filterOption;

        public IFilterOption FilterOption { get { return _filterOption; } set { _filterOption = value; } }

        public BugTitleFilter(IFilterOption fo)
        {
            _filterOption = fo;
        }

        public bool Apply(object parameter)
        {
            return (parameter as BugEntity).Title.IndexOf(_filterOption.FilterTerm) != -1;
        }
    }
}
