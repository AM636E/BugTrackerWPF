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
        Bug[] GetBugs();
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
        public Employee Repoter = new Employee("Vasia", "Pupkin.", EmployeePosition.Boss);
        [DataMember]
        public DateTime Created = DateTime.Now;
        [DataMember]
        public BugSeverity Severity = BugSeverity.Blocked;

        [DataMember]
        public Status Status = Status.New;

        [DataMember]
        public Component Component = Component.API;
        [DataMember]
        public Test Test { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Project Project = new Project(344) { Id = 3 };

        [DataMember]
        public Bug Bug = new Bug();
    }
   
}
