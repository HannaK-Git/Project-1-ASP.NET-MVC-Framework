using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstProject.Models
{
    public class EmployeeBL
    {
        FactoryEntities db = new FactoryEntities();

        public List<JoinedData> GetAllEmpInfo()
        {
            var result = from Department in db.Departments

                         join Employee in db.Employees on Department.ID equals Employee.DepartmentID
                         join ShiftTable in db.EmployeeShifts on Employee.ID equals ShiftTable.EmployeeID
                         join Data in db.Shifts on ShiftTable.ShiftID equals Data.ID
                         select new JoinedData

                         {
                             
                             ID = Employee.ID,
                             ShiftID = ShiftTable.ID,
                             FName = Employee.FirstName,
                             LName = Employee.LastName,
                             FullName = Employee.FirstName + " " + Employee.LastName,
                             SWY = Employee.StartWorkYear,
                             Dep = Department.Name,
                             ShiftDate = Data.Date,
                             StartTime = Data.StartTime,
                             EndTime = Data.EndTime
                         };

            return result.ToList();


        }

       public EmployeeWithShifts GetEmployeeForAddShift(int empID)
        {
            Employee e = db.Employees.Where(x => x.ID == empID).First();
            EmployeeWithShifts emp = new EmployeeWithShifts();
            emp.Name = e.FirstName + " " + e.LastName;
            emp.EmployeeID = e.ID;
            foreach(var item in db.Shifts)
            {
                var sli = new SelectListItem();
                sli.Text = item.Date.ToString();
                sli.Value = item.ID.ToString();
                emp.shifts.Add(sli);
            }
            return emp;
        }

        public void AddNewShift(EmployeeWithShifts emp)
        {
            EmployeeShift shift = new EmployeeShift();
            shift.EmployeeID = emp.EmployeeID;
            shift.ShiftID = emp.ShiftID;
            db.EmployeeShifts.Add(shift);
            db.SaveChanges();
        }

        public List<JoinedData> SearchEmp(string searchItem)
        {
            List<JoinedData> emp = GetAllEmpInfo();
            var result = emp.Where(x => x.LName.Contains(searchItem) || x.FName.Contains(searchItem) || x.Dep.Contains(searchItem)); 
            return result.ToList();
        }

       
        public JoinedData GetEmployeeModel(int empID)
        {
            List<JoinedData> emp = GetAllEmpInfo();
            var result = emp.Where(x => x.ID == empID).First();
            
            JoinedData d = new JoinedData();
                
             d.ID = result.ID;
             d.FName = result.FName;
             d.LName = result.LName;
             d.SWY = result.SWY;
             d.Dep = result.Dep;

            foreach (var dep in db.Departments)
            {
                var sli = new SelectListItem();
                sli.Text = dep.Name;
                sli.Value = dep.ID.ToString();

                d.departments.Add(sli);

            }
            return d;
        }

         public void UpdateEmp(int empID, JoinedData d)
         {
            
            Employee emp = db.Employees.Where(x => x.ID == empID).First();
            emp.ID = d.ID;
            emp.FirstName = d.FName;
            emp.LastName = d.LName;
            emp.StartWorkYear = d.SWY;
            emp.DepartmentID = d.DepID;
           
            db.SaveChanges();
        }
        

        public void DeleteEmployee(int empID)
        {
            var e = db.Employees.Where(x => x.ID == empID).First();
           
            db.Employees.Remove(e);
           
            db.SaveChanges();
            
        }

        public void DeleteShift(int empID)
        {
            var s = db.EmployeeShifts.Where(x => x.EmployeeID == empID);

            foreach (var item in s)
            {
                db.EmployeeShifts.Remove(item);

            }

            db.SaveChanges();

        }

        
        

        public List <JoinedData> GetShiftsForEmployees(int emp)
            {
            List<JoinedData> s = GetAllEmpInfo();
            var sh = s.Where(x => x.ID == emp).ToList();
            return sh;
            }

    }
}