using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugAccessLibrary
{
    using Entities;
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(ProtectionLevel=System.Net.Security.ProtectionLevel.None)]
    public interface IBugAccessService
    {
        [OperationContract]
        [WebGet(UriTemplate="/GetBugs", ResponseFormat=WebMessageFormat.Json)]
        BugEntity[] GetBugs();
        [OperationContract]
        [WebGet(UriTemplate = "/GetTwo", ResponseFormat = WebMessageFormat.Json)]
        int GetValue();

        [OperationContract]
        [WebGet(UriTemplate = "/GetTest", ResponseFormat = WebMessageFormat.Json)]
        Data GetTest();
        [OperationContract]
        [WebGet(UriTemplate = "/GetBug", ResponseFormat = WebMessageFormat.Json)]
        BugEntity GetBug();
    }

    [DataContract]
    public enum Test
    {
        [EnumMember]
        ONE,
        [EnumMember]
        TWO
    }
    [DataContract]
    public class Data
    {
        [DataMember]
        public Test Test { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
   
}
