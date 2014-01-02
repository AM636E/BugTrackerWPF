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
        //priorities
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
        }
        public string Title
        {
            get { return _title; }
        }
       
        public ProjectEntity Project { get { return _project; } }
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
                "Bugid",
                "BUGPROJECTID",
                "BUGTITLE",
                "BUGSUMMARY",
                "BUGSUBMITTED",
                "BUGREPORTERID",
                "BUGFIXERID",
                "BUGPRIORITY",
                "BUGSEVERITYID",
                "BUGCOMPONENTID",
                "BUGBUILD",
                "BUGSTATUSID")
                .ToBugs();
        }
    }
}
