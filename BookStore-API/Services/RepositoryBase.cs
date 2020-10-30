using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore_API.Contracts;
using BookStore_API.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Services
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext Db;

        protected RepositoryBase(ApplicationDbContext db)
        {
            Db = db;
        }

        public async Task<IList<T>> FindAll()
        {
            var entities = await Db.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> FindById(int id)
        {
            var entity = await Db.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<bool> Create(T entity)
        {
            await Db.Set<T>().AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Update(T entity)
        {
            Db.Set<T>().Update(entity);
            return await Save();
        }

        public async Task<bool> Delete(T entity)
        {
            Db.Set<T>().Remove(entity);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var changes = await Db.SaveChangesAsync();
            return changes > 0;
        }
    }
}
