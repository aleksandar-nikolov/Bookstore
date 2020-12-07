using System.Net.Http;
using Blazored.LocalStorage;
using PWATest.Contracts;
using PWATest.Models;

namespace PWATestServices
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(HttpClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
