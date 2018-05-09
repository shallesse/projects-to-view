
using System.Web.Mvc;



namespace RolesDemo.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {

            ViewBag.Message = "Hamilton's Club .";
            
            return View();
        }

        //[Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Hamilton's Club.";

            return View();
        }
        public ActionResult Help()
        {
            ViewBag.Message = "Help!";

            return View();
        }
        public ActionResult Support()
        {
            ViewBag.Message = "Email Tech Support";

            return View();
        }

        [Authorize]
        public ActionResult tblBookings()
        {
           

            return View("Index");
        }

        [Authorize]
        public ActionResult Chat()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
    }
}
