using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FirstProject.Models;
namespace FirstProject.Controllers
{
    public class DepartmentController : Controller
    {
        static DepartmentBL departmentBL = new DepartmentBL();
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDepartmentTable()
        {
            
            var details = departmentBL.GetDepartmentsData();

            ViewBag.TableData = details; 

            return checkCounterOfActionsAndReturnAction(View("DepartmentTable"));
        }

        public ActionResult EditDepartment(int depID)
        {
            Department d = departmentBL.GetDepartment(depID);

            return checkCounterOfActionsAndReturnAction(View("EditDepartment", d));
        }

        [HttpPost]
        public ActionResult GetUpdatedDepData(Department d)
        {
            departmentBL.UpdateDepartment(d.ID, d);

            return RedirectToAction("GetDepartmentTable");
        }

        public ActionResult DeleteDepartment(int depID)
        {
             departmentBL.DeleteDepartment(depID);

            return checkCounterOfActionsAndReturnAction(RedirectToAction("GetDepartmentTable"));
        }

        public ActionResult AddDepartment()
        {

            return checkCounterOfActionsAndReturnAction(View("AddDepartment"));


        }

        [HttpPost]
        public ActionResult GetNewDepData(Department d)
        {
            departmentBL.AddDepartment(d);

            return RedirectToAction("GetDepartmentTable");
        }

        public ActionResult checkCounterOfActionsAndReturnAction(ActionResult action)
        {
            int counter = (int)Session["numOfActions"];
            counter--;
            Session["numOfActions"] = counter;

            if(counter != 0)
            {
                return action;
            }else
            {
                return Redirect("/login/Logout");
            }
            


        }
    }
}