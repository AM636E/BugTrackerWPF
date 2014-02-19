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
    [DataContract]
    public class EmployeeEntity
    {
        [DataMember]

        private int _empid;
        [DataMember]
        private string _empfname;
        [DataMember]
        private string _empsname;
        [DataMember]
        private EmployeePosition _position;
        [DataMember]
        public string FirstName
        {
            get { return _empfname; }
        }
        [DataMember]
        public string SurName
        {
            get { return _empsname; }
        }
        [DataMember]
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
