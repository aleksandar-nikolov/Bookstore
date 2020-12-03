﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore_UI.Models;

namespace BookStore_UI.Contracts
{
    public interface IBookRepository : IBaseRepository<Book>
    {
    }
}
