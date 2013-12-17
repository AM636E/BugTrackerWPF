using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.Entities
{
    public enum EmployeePosition
    {
        Jun = 1,
        Middle,
        Lead,
        Boss
    }
    class EmployeeEntity
    {
        private int _empid;
        private string _empfname;
        private string _empsname;
        private EmployeePosition _position;
    }
}
