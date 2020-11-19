using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using BookStore_API.Contracts;
using BookStore_API.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Services
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<bool> DoesExist(int id)
        {
            return await Db.Books.AnyAsync(_ => _.Id == id);
        }

        public new async Task<IList<Book>> FindAll()
        {
            var entities = await Db.Set<Book>().Include(b => b.Author).ToListAsync();
            return entities;
        }

        public new async Task<Book> FindById(int id)
        {
            var entity = await Db.Set<Book>().Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
            return entity;
        }
    }
}
