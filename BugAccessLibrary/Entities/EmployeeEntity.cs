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
        [EnumMember]
        Jun = 1,
        [EnumMember]
        Middle,
        [EnumMember]
        Lead,
        [EnumMember]
        Boss
    }
    [DataContract]
    public class Employee
    {

        private int _empid;
        private string _empfname;
        private string _empsname;
        private EmployeePosition _position;
        [DataMember]
        public string FirstName
        {
            set { _empfname = value; }
            get { return _empfname; }
        }
        [DataMember]
        public string SurName
        {
            set {_empsname = value;}
            get { return _empsname; }
        }
        [DataMember]
        public int Id
        {
            get { return _empid; }
            set { _empid = value; }
        }
        [DataMember]
        public EmployeePosition Position = EmployeePosition.Boss;

         public Employee(string empfname, string empsname, EmployeePosition position)
        {
            _empfname = empfname;
            _empsname = empsname;
            _position = position;
        }

        public Employee(int reporterid)
        {
        }
    }
}
