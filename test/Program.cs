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
using UI.Entities;
using UI.Models;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using NLog;


namespace test
{
    using BugAccessLibrary;
   

    public class Program
    {
        public static void Main()
        {
            ServiceHost host = new ServiceHost(typeof(BugAccessService),
            new Uri(@"http://localhost:8080/BugAccessLibrary/"));
            host.AddServiceEndpoint(typeof(IBugAccessService), new BasicHttpBinding(), "BugAccess");
            
            host.Open();

            WebServiceHost webhost = null;
            try
            {
                webhost = new WebServiceHost(typeof(BugAccessService), new Uri(@"http://localhost:5555/"));
                webhost.Open();

                System.Net.WebClient client = new System.Net.WebClient();
                client.DownloadString(@"http://localhost:5555/GetTest");

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                ChannelFactory<IBugAccessService> factory;
                try
                {
                    BasicHttpBinding binding = new BasicHttpBinding();
                    EndpointAddress adress = new EndpointAddress(@"http://localhost:8080/BugAccessLibrary/BugAccess");

                    factory = new ChannelFactory<IBugAccessService>(binding, adress);
                    IBugAccessService service = factory.CreateChannel();

                    service.GetValue();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Press any key to stop");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ServiceModel;

//namespace Service
//{
//    [ServiceContract]
//    public interface IMyService
//    {
//        [OperationContract]
//        string GetInfo();
//    }

//    public class MyService : IMyService
//    {

//        public string GetInfo()
//        {
//            return "Some Info from inside...";
//        }
//    }


//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ServiceHost host = new ServiceHost(typeof(MyService), new Uri("http://localhost:8377/TestService"));
//            host.AddServiceEndpoint(typeof(IMyService), new BasicHttpBinding(), "one");
//            host.Open();

//            Console.WriteLine("Service started...");
//            Console.ReadKey();

//            host.Close();

//        }
//    }
//}

