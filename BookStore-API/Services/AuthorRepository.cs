using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore_API.Contracts;
using BookStore_API.Data;
using BookStore_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace BookStore_API.Servicces
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext db) : base(db)
        { }

        public async Task<bool> DoesExist(int id)
        {
            return await Db.Authors.AnyAsync(_ => _.Id == id);
        }

    }
}
