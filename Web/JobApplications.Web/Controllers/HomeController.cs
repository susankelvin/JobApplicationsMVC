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
    }
}
