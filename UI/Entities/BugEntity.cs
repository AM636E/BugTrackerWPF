using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.Entities
{
    public enum BugSeverity
    {
        Blocked = 1,
        Critical = 2,
        Normal = 3,
        Major = 4,
        FeatureRequest = 5
    }

    public enum BugPriority
    {
        Low,
        High,
        Normal
    }

    public enum Component
    {
        CONFIG = 1,
        API = 2,
        COMPONENT = 3
    }

    public enum Status
    {
        New = 1,
        Assigned = 2,
        Reopened = 3,
        Verifield = 4,
        Closed = 5,
        Unconfirmed = 6
    }

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
        #region Constructors
        public BugEntity()
            : base()
        {

        }


        public BugEntity(int id)
        {
            _id = id;

            try
            {
                BugEntity tmp = BugEntity.GetBugs()[0];

                this._project = tmp._project;
                this._reporter = tmp._reporter;
                this._fixer = tmp._fixer;
                this._severity = tmp._severity;
                this._status = tmp._status;
                this._priority = tmp._priority;
                this._component = tmp._component;
                this._build = tmp._build;
                this._summary = tmp._summary;
                this._title = tmp._title;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to get bug from DB : " + e.Message);
            }
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
        public static List<BugEntity> GetBugs()
        {
            return
            DAL.Manager.SelectFromTable(
            "bug",
            "1 = 1",
             "*")
            .ToBugs();
        }
    }
}
