using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using PWATest.Contracts;
using PWATest.Models;

namespace PWATestServices
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(HttpClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
