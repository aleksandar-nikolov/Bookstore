using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using WA.Contracts;
using WA.Models;

namespace WA.Services
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(HttpClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
