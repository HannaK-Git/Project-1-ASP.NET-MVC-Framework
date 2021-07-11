using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FirstProject.Models;

namespace FirstProject.Controllers
{

    public class EmployeeController : Controller
    {
        EmployeeBL employeeBL = new EmployeeBL();
        // GET: Employee
        public ActionResult GetAllEmpInfo()
        {
            var emp = employeeBL.GetAllEmpInfo();
            ViewBag.empData = emp;
            return checkCounterOfActionsAndReturnAction(View("Employees"));
        }

        
        public ActionResult SearchEmpoloyee(string searchItem)
        {
            List<JoinedData> emp = employeeBL.SearchEmp(searchItem);
            ViewBag.empData = emp;

            return checkCounterOfActionsAndReturnAction(View("SearchResult"));
        }

        

        public ActionResult EditEmployee(int empID)
        {
            
            JoinedData e = employeeBL.GetEmployeeModel(empID);

            return checkCounterOfActionsAndReturnAction(View("EditEmployee", e));
        }

        [HttpPost]
        public ActionResult GetUpdatedEmpData(JoinedData emp)
        {
           employeeBL.UpdateEmp(emp.ID, emp);
            return RedirectToAction("GetAllEmpInfo");
        }

        public ActionResult DeleteEmployee(int empID)
        {
            
            employeeBL.DeleteEmployee(empID);
            employeeBL.DeleteShift(empID);
            

            return checkCounterOfActionsAndReturnAction(RedirectToAction("GetAllEmpInfo"));
        }

        public ActionResult AddShiftToEmployee(int empID)
        {
            int tempID = empID;
            EmployeeWithShifts emp = employeeBL.GetEmployeeForAddShift(empID);
            ViewBag.empName = emp.Name;
            return checkCounterOfActionsAndReturnAction(View("AddShiftToEmployee", emp));
        }

        [HttpPost]
        public ActionResult GetNewShiftData(EmployeeWithShifts emp)
        {
            employeeBL.AddNewShift(emp);
            return RedirectToAction("GetAllEmpInfo");
        }

        

        public ActionResult GetShiftsForEmp(int empID, string empName)
        {
            var shifts = employeeBL.GetShiftsForEmployees(empID);
            ViewBag.shiftsData = shifts;
            ViewBag.empName = empName;
            return checkCounterOfActionsAndReturnAction(View("ShiftsForEmployee"));
        }
        public ActionResult checkCounterOfActionsAndReturnAction(ActionResult action)
        {
            int counter = (int)Session["numOfActions"];
            counter--;
            Session["numOfActions"] = counter;

            if (counter != 0)
            {
                return action;
            }
            else
            {
                return Redirect("/login/Logout");
            }
        }
        }
}