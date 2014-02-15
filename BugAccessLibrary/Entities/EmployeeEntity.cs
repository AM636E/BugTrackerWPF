using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugAccessLibrary.Entities
{
    [DataContract]
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

        public EmployeeEntity(string empfname, string empsname, EmployeePosition position)
        {
            _empfname = empfname;
            _empsname = empsname;
            _position = position;
        }

        public EmployeeEntity(int reporterid)
        {
        }
    }
}
