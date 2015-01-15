namespace JobApplications.Database.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Application
    {
        public int Applicationid { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Company { get; set; }

        public string RefNo { get; set; }

        public string OfferUrl { get; set; }

        public string CompanyUrl { get; set; }

        public string Contacts { get; set; }

        public DateTime OfferDate { get; set; }

        public DateTime ApplicationDate { get; set; }

        public string Notes { get; set; }

        public string Result { get; set; }
    }
}
