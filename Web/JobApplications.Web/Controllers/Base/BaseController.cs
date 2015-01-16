namespace JobApplications.Web.Controllers.Base
{
    using System;
    using System.Web.Mvc;
    using Database.Data.Interfaces;

    public class BaseController : Controller
    {
        protected IData Data { get; set; }

        public BaseController(IData data)
            : base()
        {
            if (data == null)
            {
                throw new ArgumentNullException("data", "cannot be null");
            }

            this.Data = data;
        }
    }
}
