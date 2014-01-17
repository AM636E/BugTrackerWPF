using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using UI.Models;
using NLog;
using System.Threading;
using BugTrackerWPF.DAL;
using BugTrackerWPF;
using UI.Entities;

namespace test
{
    static class DAL
    {
        private static DBManager _manager = OracleDB.Instance;
        public static DBManager Manager
        {
            get
            {
                return _manager;
            }
        }
    }
    class Program
    {
        class Test
        {
            private DateTime _created = DateTime.Now;

            public DateTime Created
            {
                get { return _created; }
            }
        }

        public static Logger log;



        static void Main(string[] args)
        {
            BugEntity bug = new BugEntity(100);
           
            string query = @"
INSERT INTO BUG
(
    BUGPROJECTID,
    BUGTITLE,
    BUGSUMMARY,
    BUGSUBMITTED,
    BUGREPORTERID,
    BUGFIXERID,
    BUGPRIORITY,
    BUGSEVERITYID,
    BUGCOMPONENTID,
    BUGBUILD,
    BUGSTATUSID
)
VALUES (";
            //to_timestamp('17-DEC-13 11.53.46.053000000 AM','DD-MON-RR HH.MI.SSXFF AM')
            Console.WriteLine(bug.Project.Id.ToString());
            query += bug.Project.Id.ToString() + ",\'";
            query += bug.Title + "\',";
            query += '\'' + bug.Summary + "\',";
            query += @"to_timestamp( '" + bug.Created.ToString("dd-MM-yyyy HH.m.s") + @"', 'DD-MM-RRRR HH24.MI.SS'),";
            query += bug.Repoter.Id.ToString() + ',';
            query += bug.Fixer.Id.ToString() + ',';
            query += ((int)bug.Prioriry).ToString() + ',';
            query += ((int)bug.Severity).ToString() + ',';
            query += ((int)bug.Component).ToString() + ',';
            query += ((int)bug.Build).ToString() + ',';
            query += ((int)bug.Status).ToString() + ")";


            try
            {Console.WriteLine(query);
                DAL.Manager.ExecuteQuery(query);
                DAL.Manager.ExecuteQuery("COMMIT");
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
