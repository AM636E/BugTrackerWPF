using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugAccessLibrary.Entities
{
    [DataContract]
    public class Project
    {

        private int _id;
        private string _title;
        private string _description;
        private decimal _price;
        [DataMember]
        public int Id { get { return _id; } set { _id = value; } }

        [DataMember]
        public Decimal Price { get { return _price; } set { _price = value; } }
        [DataMember]
        public string Title { get { return _title; } set { _title = value; } }
        [DataMember]
        public string Description { get { return _description; } set { _description = value; } }

        public Project(int projectid)
        {
            
        }
        public Project(int id, string title, string desc, decimal price)
        {
            _id = id;
            _title = title;
            _description = desc;
            _price = price;
        }
    }
}
