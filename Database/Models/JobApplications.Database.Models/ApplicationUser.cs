using System;

namespace JobApplications.Database.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Application> applications;

        public virtual ICollection<Application> Applications
        {
            get
            {
                return this.applications;
            }
            set
            {
                this.applications = value;
            }
        }

        public DateTime? LastActivity { get; set; }

        public ApplicationUser()
            : base()
        {
            this.applications = new HashSet<Application>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
