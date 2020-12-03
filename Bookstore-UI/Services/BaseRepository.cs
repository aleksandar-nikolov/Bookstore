using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BookStore_UI.Contracts;
using BookStore_UI.Static;
using Newtonsoft.Json;

namespace BookStore_UI.Services
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;

        protected Encoding UsedEncoding => Encoding.UTF8;
        protected string MediaType => Constants.MediaTypeJson;

        public BaseRepository(IHttpClientFactory client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<IList<T>> Get(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = await GetAuthenticatedClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<T>>(await response.Content.ReadAsStringAsync());
            }

            //todo
            return null;
        }

        public async Task<T> Get(string url, int id)
        {
            if (id < 1)
            {
                return null;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}{id}");
            var client = await GetAuthenticatedClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<bool> Create(string url, T obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (obj == null)
            {
                return false;
            }

            request.Content = new StringContent(JsonConvert.SerializeObject(obj), UsedEncoding, MediaType);

            var client = await GetAuthenticatedClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(string url, T obj, int id)
        {
            //if (id < 1)
            //{
            //    return false;
            //}

            if (obj == null)
            {
                return false;
            }

            var request = new HttpRequestMessage(HttpMethod.Put, url + id);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), UsedEncoding, MediaType);
            var client = await GetAuthenticatedClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(string url, int id)
        {
            if (id < 1)
            {
                return false;
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, url + id);
            var client = await GetAuthenticatedClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }

            return false;
        }

        protected async Task<HttpClient> GetAuthenticatedClient()
        {
            var client = _client.CreateClient();
            await SetAuthenticationToClient(client);
            return client;
        }

        private async Task SetAuthenticationToClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.Bearer, await GetBearerToken());
        }

        private async Task<string> GetBearerToken()
        {
            var savedToken = await _localStorage.GetItemAsync<string>(Constants.AuthToken);
            return savedToken;
        }
    }
}
