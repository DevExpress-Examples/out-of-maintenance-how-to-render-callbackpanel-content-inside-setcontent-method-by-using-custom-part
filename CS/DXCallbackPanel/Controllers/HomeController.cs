using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXCallbackPanel.Models;

namespace DXCallbackPanel.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewData["Employees"] = NorthwindDataProvider.GetEmployeesList();
            int employeeID = NorthwindDataProvider.GetFirstEmployeeID();
            return View("Index", NorthwindDataProvider.GetEmployee(employeeID));
        }
        public ActionResult CallbackPanelPartial() {
            int employeeID = !string.IsNullOrEmpty(Request.Params["EmployeeID"]) ? int.Parse(Request.Params["EmployeeID"]) : NorthwindDataProvider.GetFirstEmployeeID();
            return PartialView("CallbackPanelPartial", NorthwindDataProvider.GetEmployee(employeeID));
        }
    }
}
