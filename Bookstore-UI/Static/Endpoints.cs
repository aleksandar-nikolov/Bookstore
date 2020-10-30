using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_UI.Static
{
    public static class Endpoints
    {
        public static string BaseUrl = "https://localhost:44304/";
        public static string BaseApiUrl = $"{BaseUrl}api/";
        public static string AuthorsEndpoint = $"{BaseApiUrl}authors/";
        public static string BooksEndpoint = $"{BaseApiUrl}books/";
        public static string RegisterEndpoint = $"{BaseApiUrl}users/register/";
        public static string LoginEndpoint = $"{BaseApiUrl}users/login/";
    }
}
