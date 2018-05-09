using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RolesDemo.Controllers
{
    public class SupportController : Controller
    {
        //
        // GET: /Support/
        public ActionResult Index()
        {
            ViewBag.Message = "Email Tech Support";
            return View();
        }

	}
}