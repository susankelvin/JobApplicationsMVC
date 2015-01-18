namespace JobApplications.Database.Data
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Models;

    public class Data : IData, IDisposable
    {
        private readonly ApplicationDbContext context;
        private readonly Dictionary<Type, object> repositories;

        public Data(ApplicationDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "cannot be null");
            }

            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public ApplicationDbContext Context
        {
            get
            {
                return this.context;

            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();

            }
        }

        public IRepository<Application> Applications
        {
            get
            {
                return this.GetRepository<Application>();

            }
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            foreach (var item in this.repositories)
            {
                IDisposable repository = item.Value as IDisposable;
                if (repository != null)
                {
                    repository.Dispose();
                }
            }

            this.context.Dispose();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            Type type = typeof(Repository<T>);
            if (!this.repositories.ContainsKey(type))
            {
                var repository = Activator.CreateInstance(type, this.Context);
                this.repositories.Add(type, repository);
            }

            return this.repositories[type] as IRepository<T>;
        }
    }
}
