using System.Net.Http;
using Blazored.LocalStorage;
using WA_NonPA.Contracts;
using WA_NonPA.Models;

namespace WA_NonPA.Services
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(HttpClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
