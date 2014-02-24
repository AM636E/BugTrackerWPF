using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugAccessLibrary.Entities
{
    [DataContract]
    public enum BugSeverity
    {
        [EnumMember]
        Blocked = 1,
        [EnumMember]
        Critical = 2,
        [EnumMember]
        Normal = 3,
        [EnumMember]
        Major = 4,
        [EnumMember]
        FeatureRequest = 5
    }
    [DataContract]
    public enum BugPriority
    {
        [EnumMember]
        Low,
        [EnumMember]
        High,
        [EnumMember]
        Normal
    }
    [DataContract]
    public enum Component
    {
        [EnumMember]
        CONFIG = 1,
        [EnumMember]
        API = 2,
        [EnumMember]
        COMPONENT = 3
    }

    [DataContract]
    public enum Status
    {
        [EnumMember]
        New = 1,
        Assigned = 2,
        [EnumMember]
        Reopened = 3,
        [EnumMember]
        Verifield = 4,
        [EnumMember]
        Closed = 5,
        [EnumMember]
        Unconfirmed = 6
    }

    [DataContract]
    public class Bug
    {
        private int _id;
        private string _title;
        private string _summary;

        private DateTime _created = DateTime.Now;

        private Project _project;
        private Employee _reporter;
        private Employee _fixer;

        private BugSeverity _severity = BugSeverity.Normal;
        private BugPriority _priority = BugPriority.Normal;

        private Component _component = Component.API;
        private Status _status = Status.New;
        private int _build;


        #region Properties
        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        //[DataMember]
        public BugSeverity Severity
        {
            get;
            set;
        }
        //[DataMember]
        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }
        //[DataMember]
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        //[DataMember]
        public Employee Repoter
        {
            get { return _reporter; }
            set { _reporter = value; }
        }
        //[DataMember]
        public Employee Fixer
        {
            get { return _fixer; }
            set { _fixer = value; }
        }

       
        //[DataMember]
        public int PriorityInt { get { return 3; } }
        public BugPriority Prioriry { get { return _priority; } set { _priority = value; } }
        //[DataMember]
        public Component Component { get { return _component; } set { _component = value; } }
       //[DataMember]
        public int Build { get { return _build; } set { _build = value; } }
        //[DataMember]
        public Project Project { get { return _project; } set { _project = value; } }
        #endregion


        #region Constructors
        public Bug() : base() { }
        public Bug(
          int id,
          int projectid,
          string title,
          string summary,
          int reporterid,
          int fixerid,
          BugPriority priority,
          BugSeverity severity,
          Component component,
          int build,
          Status status
      )
        {
            this._id = id;
            this._project = new Project(projectid);
            this._reporter = new Employee(reporterid);
            this._fixer = new Employee(fixerid);
            this._severity = severity;
            this._status = status;
            this._priority = priority;
            this._component = component;
            this._build = build;
            this._summary = summary;
            this._title = title;
        }



        #endregion
    }
}