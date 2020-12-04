using System.Net.Http;
using Blazored.LocalStorage;
using WA.Contracts;
using WA.Models;

namespace WA.Services
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(HttpClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
