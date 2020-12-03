using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BookStore_UI.WASM.Contracts;
using BookStore_UI.WASM.Models;

namespace BookStore_UI.WASM.Services
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(IHttpClientFactory client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
