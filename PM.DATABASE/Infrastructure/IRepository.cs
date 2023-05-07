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
        Task Add(T model);
        Task<List<T>> GetAll();
        Task GetByID(Func<Expression, bool> model);
        Task Delete(Func<Expression, bool> model);
        Task Update(Func<Expression, bool> model, T entity);


    }
}
