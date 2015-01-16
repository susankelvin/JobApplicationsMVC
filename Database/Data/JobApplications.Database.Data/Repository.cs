namespace JobApplications.Database.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using Interfaces;

    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "cannot be null");
            }

            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public IQueryable<T> All()
        {
            return this.dbSet.AsQueryable();
        }

        public T Find(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Delete(object id)
        {
            T entity = this.Find(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntity = this.context.Entry(entity);
            if (dbEntity.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            this.dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntity = this.context.Entry(entity);
            if (dbEntity.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            dbEntity.State = EntityState.Modified;
        }

        public void Detach(T entity)
        {
            DbEntityEntry dbEntity = this.context.Entry(entity);
            dbEntity.State = EntityState.Detached;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
