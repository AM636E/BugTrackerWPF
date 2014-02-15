using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugAccessLibrary.Entities
{
    public class ProjectEntity
    {
        private int projectid;

        public ProjectEntity(int projectid)
        {
            // TODO: Complete member initialization
            this.projectid = projectid;
        }
    }
}
