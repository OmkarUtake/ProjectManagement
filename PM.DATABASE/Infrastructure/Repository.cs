using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PM.DATABASE.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MasterDbContext _db;
        public Repository(MasterDbContext db)
        {
            _db = db;
        }
        public async Task Add(T model)
        {
            _db.Set<T>().Add(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(Func<Expression, bool> model)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetByID(Func<Expression, bool> model)
        {
            throw new NotImplementedException();
        }

        public Task Update(Func<Expression, bool> model, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
