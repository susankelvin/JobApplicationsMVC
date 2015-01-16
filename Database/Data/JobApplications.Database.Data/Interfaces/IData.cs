namespace JobApplications.Database.Data.Interfaces
{
    using Data;
    using Models;

    public interface IData
    {
        ApplicationDbContext Context { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Application> Applications { get; }

        int SaveChanges();
    }
}
