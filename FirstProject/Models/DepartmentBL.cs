using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstProject.Models
{
    
    public class DepartmentBL
    {
        private FactoryEntities db = new FactoryEntities();

        public List<Department> GetDepartmentsData()
        {
            return db.Departments.ToList();
        }

        public Department GetDepartment(int depID)
        {
            return db.Departments.Where(x => x.ID == depID).First();
        }

        public void UpdateDepartment(int depID, Department d)
        {
            Department newDep = db.Departments.Where(x => x.ID == depID).First();
            newDep.Name = d.Name;
            newDep.Manager = d.Manager;

            db.SaveChanges();
        }

        public void DeleteDepartment(int depID)
        {
           var d = db.Departments.Where(x => x.ID == depID).First();
            db.Departments.Remove(d);
            db.SaveChanges();
        }

        public void AddDepartment(Department d)
        {
            db.Departments.Add(d);
            db.SaveChanges();
        }


       
    }
}