﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore_API.Data;

namespace BookStore_API.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<bool> DoesExist(int id);
        public Task<string> GetImageFileName(int id);
    }
}
