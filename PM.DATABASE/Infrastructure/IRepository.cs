using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PM.DATABASE.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entity);
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        void Add(List<T> entity);
        void Delete(T entity);
        T Update(T entity);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression);
        Task<T> GetDefault(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        void SaveChanges();


    }
}
