using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace UI.Entities
{
    public enum EmployeePosition
    {
        Jun = 1,
        Middle,
        Lead,
        Boss
    }
    public class EmployeeEntity
    {
        private int _empid;
        private string _empfname;
        private string _empsname;
        private EmployeePosition _position;

        public string FirstName
        {
            get { return _empfname; }
        }

        public string SurName
        {
            get { return _empsname; }
        }

        public int Id
        { get { return _empid; } }

        public EmployeeEntity( string empfname, string empsname, EmployeePosition position)
        {
            _empfname = empfname;
            _empsname = empsname;
            _position = position;
        }

        public EmployeeEntity(int empid)
        {
            _empid = empid;
            try
            {
                /*EmployeeEntity tmp =
                    ((ObservableCollection<EmployeeEntity>)
                    App.Current.Resources["Employees"])[0];

                if(tmp != null)
                {
	               _empfname = tmp._empfname;
	               _empsname = tmp._empsname;
	               _position = tmp._position;
           		}*/
            }
            catch(Exception e)
            {
                console.log("Unable to get employee from DB : " + e.Message);
            }
        }

        public override string ToString()
        {
            return FirstName + ' ' + SurName;
        }
    }
}
