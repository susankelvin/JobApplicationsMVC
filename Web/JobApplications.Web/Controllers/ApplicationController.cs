using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private const int PAGE_SIZE = 2;

        public ApplicationController(IData data) :
            base(data)
        {
        }

        // GET: Application
        public ActionResult Index()
        {
            ApplicationIndexViewModel result = this.FilterApplications("", 0);
            return View(result);
        }

        // AJAX update
        public ActionResult Update(string search, int? page)
        {
            if (!this.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if ((page == null) || (page < 0))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationIndexViewModel result = this.FilterApplications(search, page ?? 0);
            if (result.ActivePage < result.PageCount)
            {
                return PartialView("_applicationTable", result);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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

        // GET: Edit


        // GET: Details



        private ApplicationIndexViewModel FilterApplications(string search, int page)
        {
            string userId = this.User.Identity.GetUserId();
            var query = this.Data.Applications.All()
                .Where(a => a.AuthorId == userId);

            if (!String.IsNullOrWhiteSpace(search))
            {
                query = query.Where(a => a.Position.Contains(search) || a.Company.Contains(search));
            }

            int count = query.Count();
            ApplicationIndexViewModel result = new ApplicationIndexViewModel
            {
                ActivePage = page,
                PageCount = count / PAGE_SIZE
            };
            if (count % PAGE_SIZE != 0)
            {
                result.PageCount++;
            }

            var applications = query.OrderByDescending(a => a.ApplicationDate)
                .Skip(page * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToList();
            var resultList = new List<ApplicationTableViewModel>(applications.Count);
            foreach (Application application in applications)
            {
                ApplicationTableViewModel item = new ApplicationTableViewModel();
                Mapper.Map(application, item);
                resultList.Add(item);
            }

            result.Items = resultList;
            return result;
        }
    }
}
