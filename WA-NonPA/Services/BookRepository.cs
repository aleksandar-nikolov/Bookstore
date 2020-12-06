using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using WA_NonPA.Contracts;
using WA_NonPA.Models;

namespace WA_NonPA.Services
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(HttpClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
