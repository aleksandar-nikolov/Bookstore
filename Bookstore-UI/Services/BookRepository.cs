using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Bookstore_UI.Contracts;
using Bookstore_UI.Models;

namespace Bookstore_UI.Services
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(IHttpClientFactory client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
