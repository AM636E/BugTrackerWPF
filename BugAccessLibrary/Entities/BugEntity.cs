﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugAccessLibrary.Entities
{
    [DataContract]
    [Flags]
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
    [Flags]
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
    [Flags]
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
    [Flags]
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

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "BugAccessLibrary.ContractType".
    [DataContract]
    public class BugEntity
    {

        #region Members
        private int _id;
        private string _title;
        private string _summary;

        private DateTime _created = DateTime.Now;

        private ProjectEntity _project;
        private EmployeeEntity _reporter;
        private EmployeeEntity _fixer;

        private BugSeverity _severity;
        private BugPriority _priority;

        private Component _component;
        private Status _status;
        private int _build;

        #endregion
        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public BugSeverity Severity
        {
            get { return _severity; }
            set { _severity = value; }
        }
        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public EmployeeEntity Repoter
        {
            get { return _reporter; }
            set { _reporter = value; }
        }

        public EmployeeEntity Fixer
        {
            get { return _fixer; }
            set { _fixer = value; }
        }

        public double UnixTimestamp
        {
            get { return (double)(_created.Subtract(new DateTime(1970, 1, 1))).TotalSeconds; }
        }
        public BugPriority Prioriry { get { return _priority; } set { _priority = value; } }
        public Component Component { get { return _component; } set { _component = value; } }
        public int Build { get { return _build; } set { _build = value; } }
        public ProjectEntity Project { get { return _project; } set { _project = value; } }
        #endregion
        public BugEntity(int id, string b, string c)
        {
            this.Id = id;
            this.Title = b;
            this.Summary = c;
        }

        #region Constructors
        public BugEntity()
            : base()
        {

        }
        public BugEntity(
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
            this._project = new ProjectEntity(projectid);
            this._reporter = new EmployeeEntity(reporterid);
            this._fixer = new EmployeeEntity(fixerid);
            this._severity = severity;
            this._status = status;
            this._priority = priority;
            this._component = component;
            this._build = build;
            this._summary = summary;
            this._title = title;
        }

        public BugEntity(
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
            this._project = new ProjectEntity(projectid);
            this._reporter = new EmployeeEntity(reporterid);
            this._fixer = new EmployeeEntity(fixerid);
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