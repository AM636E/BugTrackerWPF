using System;
using System.Windows;

namespace UI.Entities
{
    public class ProjectEntity
    {
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

        public ProjectEntity(string title, string desc, decimal price)
        {
            _title = title;
            _description = desc;
            _price = price;
        }

        public ProjectEntity(int projectid)
        {
            _id = projectid;

            try
            {
                ProjectEntity tmp = 
                DAL.Manager.SelectFromTable(
                    "project",
                    "projectid =  " + _id,
                    "projecttitle",
                    "PROJECTDESCRIPTION",
                    "projectprice")
                .ToProjectsObs()[0];

                _title = tmp.Title;
                _price = tmp.Price;
                _description = tmp.Description;
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format("Unable to get project from DB: " + e.Message));
            }
        }

        public static ProjectEntity GetProjectById(int projectid)
        {
            return new ProjectEntity(projectid);
        }
    }
}
