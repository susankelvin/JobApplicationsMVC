namespace JobApplications.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    public class Application
    {
        public int  Applicationid { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Description { get; set; }


    }
}
