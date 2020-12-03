using System.Net.Http;
using Blazored.LocalStorage;
using BookStore_UI.WASM.Contracts;
using BookStore_UI.WASM.Models;

namespace BookStore_UI.WASM.Services
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(IHttpClientFactory client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
