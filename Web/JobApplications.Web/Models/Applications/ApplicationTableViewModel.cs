using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobApplications.Web.Models.Applications
{
    public class ApplicationTableViewModel
    {
        public int ApplicationId { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public DateTime? ApplicationDate { get; set; }

        public string Notes { get; set; }
    }
}
