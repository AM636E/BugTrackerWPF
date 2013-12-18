using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;

using BugTrackerWPF.DAL;
using BugTrackerWPF;

using test.Entities;
using UI.Entities;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EmployeeEntity pe = new EmployeeEntity(1);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
