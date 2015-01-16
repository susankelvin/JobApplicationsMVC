namespace JobApplications.Database.Data.Interfaces
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        IQueryable<T> All();

        T Find(object id);

        void Delete(object id);

        void Delete(T entity);

        void Update(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}
