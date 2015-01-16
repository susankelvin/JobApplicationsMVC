namespace JobApplications.Web.Controllers
{
    using System.Web.Mvc;
    using Base;
    using Database.Data.Interfaces;

    public class HomeController : BaseController
    {
        public HomeController(IData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}