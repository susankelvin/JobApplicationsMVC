namespace JobApplications.Web.Controllers
{
    using System.Web.Mvc;
    using JobApplications.Database.Data.Interfaces;
    using JobApplications.Web.Controllers.Base;
    using JobApplications.Web.Models.Error;

    public class ErrorController : BaseController
    {
        public ErrorController(IData data)
            : base(data)
        {
        }

        // GET: Error
        public ActionResult Index()
        {
            ErrorViewModel model = new ErrorViewModel()
            {
                PanelHeading = "We are sorry",
                PanelBody = "We are not able to process Your request right now. Please, try again later."
            };
            return View("Error", model);
        }

        // GET: NotFound
        public ActionResult NotFound()
        {
            ErrorViewModel model = new ErrorViewModel()
            {
                PanelHeading = "Not found",
                PanelBody = "The requested page was not found. Check the address and try again."
            };
            return View("NotFound", model);
        }

        // GET: BadRequest
        public ActionResult BadRequest()
        {
            ErrorViewModel model = new ErrorViewModel()
            {
                PanelHeading = "Bad Request",
                PanelBody = "We are not able to understand Your request."
            };
            return View("BadRequest", model);
        }

        // GET: NotAuthorized
        public ActionResult NotAuthorized()
        {
            ErrorViewModel model = new ErrorViewModel()
            {
                PanelHeading = "Unauthorized",
                PanelBody = "The requested page requires authorization."
            };
            return View("NotAuthorized", model);
        }
    }
}
