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
    [ServiceContract(ProtectionLevel=System.Net.Security.ProtectionLevel.None)]
    public interface IBugAccessService
    {
        [OperationContract]
        Bug[] GetBugs();

        [OperationContract]
        int GetTest();

        [OperationContract]
        Data GetData();
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
