using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugAccessLibrary.Entities
{
    [DataContract]
    public class ProjectEntity
    {
        [DataMember]
        private int projectid;
        [DataMember]
        public int ProjectID { get { return projectid; } set { projectid = value; } }

        public ProjectEntity(int projectid)
        {
            this.projectid = projectid;
        }
    }
}
