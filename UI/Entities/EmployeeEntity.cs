using System;
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
               EmployeeEntity tmp =
               DAL.Manager.SelectFromTable("employee", "empid = " + _empid, "empfname", "empsname", "emppositionid")
               .ToEmployeersObs()[0];

               _empfname = tmp._empfname;
               _empsname = tmp._empsname;
               _position = tmp._position;
            }
            catch(Exception e)
            {
                MessageBox.Show("Unable to get employee from DB : " + e.Message);
            }
        }
    }
}
