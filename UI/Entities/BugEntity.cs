using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Entities
{
    enum BugSeverity
    {
        Blocked         = 1,                                                                                             
        Critical        = 2,                                                                                            
        Normal          = 3,                                                                                           
        Major           = 4,                                                                                          
        FeatureRequest  = 5  
    }

    enum BugPriority
    {
        //priorities
    }

    enum Component
    {
        CONFIG = 1,
        API = 2,
        COMPONENT = 3
    }

    enum Status
    {
        New         = 1,  
        Assigned    = 2,
        Reopened    = 3,
        Verifield   = 4,
        Closed      = 5,
        Unconfirmed = 6  
    }

    class BugEntity
    {
        private string _id;
        private string _title;
        
        private int _bugprojectid;
        private int _bugreporterid;
        private int _bugfixer;
       
        private ProjectEntity _project;
        private EmployeeEntity _reporter;
        private EmployeeEntity _fixer;

        private BugSeverity _severity;
        private BugPriority _priority;

        private Component _component;
        private Status _status;
        private int _build;
    }
}
