using EmployeeAPI.Repo.DataContext;
using EmployeeAPI.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeAPI.Repo.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        //Inject the DBContext into the base repository using Constructor DI.
        #region property  
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entities;
        #endregion

        #region Constructor  
        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }
        #endregion

        //DELETE THE ENTITY
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        //GET ALL RECORDS OF THE ENTITY
        public IQueryable<T> GetAll()
        {
            return _applicationDbContext.Set<T>();
        }

        //Get data rows by a condition eg.get empoloyees by id
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
           return _applicationDbContext.Set<T>().Where(expression);
        }

        //insert data to employee
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
        }


    }
}
