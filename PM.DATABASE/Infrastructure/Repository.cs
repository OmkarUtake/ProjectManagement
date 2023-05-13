using Microsoft.EntityFrameworkCore;
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
        protected MasterDBContext _context;
        public Repository(MasterDBContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;

        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await _context.Set<T>().ToListAsync();
            return data;
        }
        public async Task<T> GetById(int id)
        {
            var data = await _context.Set<T>().FindAsync(id);
            return data;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
