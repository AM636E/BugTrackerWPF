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
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace test
{
    using DataAccess;
    public class Program
    {
        public static void Main()
        {
            BugAccessServiceClient client = new BugAccessServiceClient();

            var a = client.GetBugs();

            foreach(var i in a)
            {
                Console.WriteLine(i.Title);
            }

            client.Close();
        }
    }
}
