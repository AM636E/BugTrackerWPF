using System;
using System.Collections.ObjectModel;
using System.Windows;
using NLog;
using DumpObject;
using ObjectDumper;
using System.IO;
namespace UI.Entities
{
    public class ProjectEntity
    {
        
        public static TextDumper dumper = new TextDumper();
        public static Logger log = LogManager.GetCurrentClassLogger();
        private int _id;
        private string _title;
        private string _description;
        private decimal _price;
        
        public int Id { get { return _id; } }
        public Decimal Price { get { return _price; } set { _price = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Description { get { return _description; } set { _description = value; } }

        public ProjectEntity()
            :base()
        {
        }
        public ProjectEntity(int id, string title, string desc, decimal price)
        {
            _id = id;
            _title = title;
            _description = desc;
            _price = price;
        }
        public ProjectEntity(int projectid)
        {
            _id = projectid;

            try
            {
                ProjectEntity tmp = new ProjectEntity();
                ObservableCollection<ProjectEntity> a = 
                (ObservableCollection<ProjectEntity>)App.Current.FindResource("Projects");
                
                if(a != null && _id < a.Count) 
                {
                    tmp = a[_id];
                }
                _title = tmp.Title;
                _price = tmp.Price;
                _description = tmp.Description;
            }
            catch (Exception e)
            {
                log.Trace(String.Format("Unable to get project from DB: " + e.Message));
            }
        }

        public static ProjectEntity GetProjectById(int projectid)
        {
            return new ProjectEntity(projectid);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
