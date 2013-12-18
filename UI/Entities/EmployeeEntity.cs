using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Windows;

namespace UI.Entities
{
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

        public EmployeeEntity( string empfname, string empsname, EmployeePosition position)
        {
            _empfname = empfname;
            _empsname = empsname;
            _position = position;
        }

        public EmployeeEntity(int empid)
        {
            _empid = empid;
            try
            {
               List<EmployeeEntity> emps =
               DAL.Manager.SelectFromTable("employee", "empid = " + _empid, "empfname", "empsname", "emppositionid")
               .ToEmployeers();

               EmployeeEntity tmp = emps[0];

               _empfname = tmp._empfname;
               _empsname = tmp._empsname;
               _position = tmp._position;
            }
            catch(Exception e)
            {
                MessageBox.Show("Unable to get project from DB : " + e.Message);
            }
        }
    }
}
