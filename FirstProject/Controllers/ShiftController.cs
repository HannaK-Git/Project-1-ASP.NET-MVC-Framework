using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FirstProject.Models;

namespace FirstProject.Controllers
{
    public class ShiftController : Controller
    {
        ShiftBL employeeShiftBL = new ShiftBL();
        // GET: Shift
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult GetShifts()
        {
             var result = employeeShiftBL.GetShifts();
             ViewBag.ShiftsData = result;


             return checkCounterOfActionsAndReturnAction(View("Shifts"));
         }

        public ActionResult EditEmployee(int empID)
        {
           
            string returnURL = "/employee/EditEmployee?empID=" + empID.ToString();

            return checkCounterOfActionsAndReturnAction(Redirect(returnURL));

           
        }

        public ActionResult AddShiftToEmployee(int empID)
        {
            string returnURL = "/employee/AddShiftToEmployee?empID=" + empID.ToString();

            return checkCounterOfActionsAndReturnAction(Redirect(returnURL));
        }

        public ActionResult GetEmpForShift(int shID)
        {
            var emp = employeeShiftBL.GetEmpForShift(shID);
            ViewBag.empData = emp;
            
            return checkCounterOfActionsAndReturnAction(View("EmployeesForShift"));
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