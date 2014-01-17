using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using UI.Models;
using UI.ViewModel;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
            :base()
        {
            ProjectModel project = new ProjectModel();
            project.Load();
            BugModel bugs = new BugModel();
            bugs.Load();
            EmployeeModel employees = new EmployeeModel();
            employees.Load();

            Current.Resources["Employees"]  = (object)employees.Entities;
            Current.Resources["Bugs"]       = (object)bugs.Entities;
            Current.Resources["Projects"]   = (object)project.Entities;
        }
    }
}
