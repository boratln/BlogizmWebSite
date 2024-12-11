using Blogizm.Application.Interfaces;
using Blogizm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BlogContext _blogContext;

        public Repository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task Create(T entity)
        {
            _blogContext.Set<T>().Add(entity);
            await _blogContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _blogContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return await _blogContext.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetById(int id)
        {
            return await _blogContext.Set<T>().FindAsync(id);
        }

        public async Task Remove(T entity)
        {
            _blogContext.Set<T>().Remove(entity);
            await _blogContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _blogContext.Set<T>().Update(entity);
            await _blogContext.SaveChangesAsync();
        }
    }
}
