namespace JobApplications.Web.Models.Applications
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ApplicationNewViewModel
    {
        [Required]
        [AllowHtml]
        public string Position { get; set; }

        [Required]
        [AllowHtml]
        public string Description { get; set; }

        [Required]
        [AllowHtml]
        public string Company { get; set; }

        [AllowHtml]
        [Display(Name = "Ref. No")]
        public string RefNo { get; set; }

        [Url]
        [Display(Name = "Offer url")]
        public string OfferUrl { get; set; }

        [Url]
        [Display(Name = "Company web site")]
        public string CompanyUrl { get; set; }

        [AllowHtml]
        public string Contacts { get; set; }

        [Display(Name = "Offer date")]
        public string OfferDate { get; set; }

        [AllowHtml]
        public string Notes { get; set; }
    }
}
