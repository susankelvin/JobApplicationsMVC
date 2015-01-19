namespace JobApplications.Web.Models.Applications
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ApplicationEditViewModel : ApplicationNewViewModel
    {
        [Required]
        public int ApplicationId { get; set; }

        [Display(Name = "Application date")]
        public string ApplicationDate { get; set; }

        [AllowHtml]
        public string Result { get; set; }
    }
}
