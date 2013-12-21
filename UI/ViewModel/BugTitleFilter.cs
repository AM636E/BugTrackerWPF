using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public interface IFilter
    {
        string FilterTerm{get; private set;}
        void Apply();
        void Remove();
    }

    class BugTitleFilter : IFilter
    {
        private string _filterTerm;

        public string FilterTerm { get { return _filterTerm; } set { _filterTerm = value; } }

        public BugTitleFilter()
        {

        }
    }
}
