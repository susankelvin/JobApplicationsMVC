namespace JobApplications.Web.Infrastructure.Filters
{
    using System;
    using System.Net;
    using System.Web.Mvc;

    /// <summary>
    /// Action filter to check if route has parameter of type int with custom name.
    /// </summary>
    public class RequireRouteIntParamAttribute : FilterAttribute, IActionFilter
    {
        private readonly string value;

        /// <summary>
        /// Initializes a new instance of the RequiredRouteIntParamAttribute class with a specified name of route parameter to check for.
        /// </summary>
        /// <param name="value">Name of route parameter</param>
        public RequireRouteIntParamAttribute(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("cannot be null or blank string", "value");
            }

            this.value = value;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionParameters.ContainsKey(this.value))
            {
                int? routeValue = filterContext.ActionParameters[this.value] as int?;
                if (routeValue != null)
                {
                    return;
                }
            }

            filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
