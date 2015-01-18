using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using JobApplications.Database.Data.Interfaces;
using JobApplications.Database.Models;
using JobApplications.Web.Controllers.Base;
using JobApplications.Web.Models.Applications;
using Microsoft.AspNet.Identity;


namespace JobApplications.Web.Controllers
{
    [Authorize]
    public class ApplicationController : BaseController
    {
        public ApplicationController(IData data) :
            base(data)
        {
        }

        // GET: Application
        public ActionResult Index()
        {
            return View();
        }

        // GET: New
        public ActionResult New()
        {
            return View();
        }

        // POST: New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(ApplicationNewViewModel model)
        {
            if (ModelState.IsValid)
            {
                Application application = new Application();
                Mapper.Map(model, application);
                if (!String.IsNullOrWhiteSpace(model.OfferDate) && (application.OfferDate == null))
                {
                    this.TempData["ErrorMessage"] = "Invalid offer date";
                }
                else
                {
                    application.AuthorId = this.User.Identity.GetUserId();
                    this.Data.Applications.Add(application);
                    this.Data.SaveChanges();
                    return RedirectToAction("Index", "Application");
                }
            }
            else
            {
                this.TempData["ErrorMessage"] = "Required information is missing";
            }

            return View(model);
        }
    }
}
