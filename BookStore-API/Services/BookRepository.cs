using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
