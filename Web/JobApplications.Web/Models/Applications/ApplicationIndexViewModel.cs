namespace JobApplications.Web.Models.Applications
{
    using System.Collections.Generic;

    public class ApplicationIndexViewModel
    {
        public int ActivePage { get; set; }

        public int PageCount { get; set; }

        public IEnumerable<ApplicationTableViewModel> Items { get; set; }
    }
}
