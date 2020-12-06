using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using WA_NonPA.Contracts;
using WA_NonPA.Models;
using WA_NonPA.Providers;
using WA_NonPA.Static;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;

namespace WA_NonPA.Services
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public AuthenticationStateProvider _authProvider;
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationRepository(HttpClient client, ILocalStorageService localStorage, AuthenticationStateProvider authProvider)
        {
            _authProvider = authProvider;
            _client = client;
            _localStorage = localStorage;
        }

        //public async Task<bool> Register(RegistrationModel user)
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.RegisterEndpoint);

        //    request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, Constants.MediaTypeJson);
        //    request.
        //    var client = _client.CreateClient();
        //    //HttpResponseMessage response = await client.SendAsync(request);
        //    HttpResponseMessage response = await client. Send(new HttpRequestMessage(HttpMethod.Get, Endpoints.BooksEndpoint));
        //    return response.IsSuccessStatusCode;
        //}

        public async Task<bool> Register(RegistrationModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.RegisterEndpoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, Constants.MediaTypeJson);

            //var client = _client.CreateClient();
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Login(LoginModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.LoginEndpoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, Constants.MediaTypeJson);

            var result = await _client.SendAsync(request);

            if (!result.IsSuccessStatusCode)
            {
                return false;
            }

            var token = JsonConvert.DeserializeObject<TokenResponse>(await result.Content.ReadAsStringAsync());

            //store token
            await _localStorage.SetItemAsync(Constants.AuthToken, token.Token);

            //change auth state
            await ((ApiAuthenticationStateProvider) _authProvider).LoggedIn();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.Token);

            return true;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(Constants.AuthToken);
            ((ApiAuthenticationStateProvider) _authProvider).LoggedOut();
        }
    }
}
