using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstProject.Models;

namespace FirstProject.Controllers
{
    public class LoginController : Controller
    {
        static LoginBL loginBL = new LoginBL();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetHomePage()
        {
            return View("HomePage");
        }
        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult HomePage()
        {
            if (Session["authenticated"] != null)
            {
                return View("HomePage");
            }
            else
            {
                return Redirect("Login");
            }

        }

       
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("HomePage");
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


            [HttpPost]
        public ActionResult GetLoginData(string username, string pwd)
        {
            bool isUserExist = loginBL.CheckUser(username, pwd);

            if (isUserExist == true)
            {
                Session["authenticated"] = true;


                bool isauthentificated = (bool)Session["authenticated"];

                 
                Session["numOfActions"] = (int) loginBL.getUser(username).NumOfActions;

               
                
                Session["userFullName"] = loginBL.getUser(username).FullName;


                return View("HomePage");
            }
            else
            {
                ViewBag.errorMsg = "Details are invalid";

                return View("Login");
            }
        }
    }
}