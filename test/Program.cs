using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel.Web;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Threading;
using System.Data.Sql;
using System.Net.Http;
using System.Web;

namespace test
{
    using DA = DataAccess;
    using BugAccessLibrary;
    public class Program
    {
        public static void Main()
        {
            ServiceHost service = new ServiceHost(typeof(BugAccessService), new Uri("net.tcp://localhost:5685/"));
            service.AddServiceEndpoint(typeof(IBugAccessService), new NetTcpBinding(), "Bugs");
            service.Open();

            ChannelFactory<IBugAccessService> factory = new ChannelFactory<IBugAccessService>(new NetTcpBinding(), "net.tcp://localhost:5685/Bugs");
            IBugAccessService c = factory.CreateChannel();
           // IBugAccessService c1 = factory.CreateChannel();
           // c.GetTest();
            Console.WriteLine(c.GetBugs()[0].Status);
            DA.BugAccessServiceClient cl = 
                new DA.BugAccessServiceClient(
                    new BasicHttpBinding(), 
                    new EndpointAddress("http://localhost:5685/Bugs")
                ); cl.Open();
            
           // Console.Read();

        }
    }

}