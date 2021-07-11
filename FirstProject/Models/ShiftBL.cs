using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstProject.Models
{
    public class ShiftBL
    {
        FactoryEntities db = new FactoryEntities();

          public List<JoinedData> GetShifts()
          {
            var result = from EmSh in db.EmployeeShifts join
                         ShData in db.Shifts on
                         EmSh.ShiftID equals ShData.ID
                         join Emp in db.Employees on
                         EmSh.EmployeeID equals Emp.DepartmentID
                         select new JoinedData
                         {
                             ID = Emp.ID,
                             ShiftID = ShData.ID,
                             ShiftDate = ShData.Date,
                             StartTime = ShData.StartTime,
                             EndTime = ShData.EndTime,
                              FName = Emp.FirstName + " " + Emp.LastName
                           };
              return result.ToList();

          }

        

        public List<JoinedData> GetEmpForShift(int shift)
        {
            List<JoinedData> s = GetShifts();
            var sh = s.Where(x => x.ShiftID == shift).ToList();
            return sh;
        }



        public Employee GetEmployee(int empid)
        {
            return db.Employees.Where(x => x.ID == empid).First();
        }



       

       


    }
}