using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugAccessLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(ProtectionLevel=System.Net.Security.ProtectionLevel.None)]
    public interface IBugAccessService
    {
        [OperationContract]
        BugEntity[] GetBugs();
    }
  /*  [DataContract]
    [Flags]
    public enum BugSeverity
    {
        [EnumMember]
        Blocked = 1,
        [EnumMember]
        Critical = 2,
        [EnumMember]
        Normal = 3,
        [EnumMember]
        Major = 4,
        [EnumMember]
        FeatureRequest = 5
    }
    [DataContract]
    [Flags]
    public enum BugPriority
    {
        [EnumMember]
        Low,
        [EnumMember]
        High,
        [EnumMember]
        Normal
    }
    [DataContract]
    [Flags]
    public enum Component
    {
        [EnumMember]
        CONFIG = 1,
        [EnumMember]
        API = 2,
        [EnumMember]
        COMPONENT = 3
    }

    [DataContract]
    [Flags]
    public enum Status
    {
        [EnumMember]
        New = 1,
        Assigned = 2,
        [EnumMember]
        Reopened = 3,
        [EnumMember]
        Verifield = 4,
        [EnumMember]
        Closed = 5,
        [EnumMember]
        Unconfirmed = 6
    }*/

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "BugAccessLibrary.ContractType".
    [DataContract]
    public class BugEntity
    {
        [DataMember]
        private int _id;
        [DataMember]
        private string _title;
        [DataMember]
        private string _summary;
        [DataMember]
        public int Id { get { return _id; } set { _id = value; } }
        [DataMember]
        public string Title { get { return _title; } set { _title = value; } }
        [DataMember]
        public string Summary { get { return _summary; } set { _summary = value; } }
        public BugEntity(int id, string b, string c)
        {
            this.Id = id;
            this.Title = b;
            this.Summary = c;   
        }

        public BugEntity()
        {
        }
    }
}
