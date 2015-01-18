namespace JobApplications.Web.Models.Applications
{
    using System.Collections.Generic;

    public class ApplicationIndexViewModel
    {
        public int Page { get; set; }

        public int Count { get; set; }

        public IEnumerable<ApplicationTableViewModel> Items { get; set; }
    }
}
