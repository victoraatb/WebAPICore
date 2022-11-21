using System.Net.Http.Headers;
using System.Net.Http.Json;
using MyApp.Repository;

namespace App.Repository.ApiClient
{
    public class WebApiExecuter : IWebApiExecuter
    {
        private readonly string baseUrl;
        private readonly HttpClient httpClient;

        public WebApiExecuter(HttpClient httpClient)
        {
            this.baseUrl = httpClient.BaseAddress.AbsoluteUri;
            this.httpClient = httpClient;
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));            
        }

        public async Task<T> InvokeGet<T>(string uri)
        {
            //AddTokenHeader();
            return await httpClient.GetFromJsonAsync<T>(GetUrl(uri));
        }

        public async Task<T> InvokePost<T>(string uri, T obj)
        {
            //AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(GetUrl(uri), obj);
            await HandleError(response);

            return await response.Content.ReadFromJsonAsync<T>();
        }      

        public async Task<string> InvokePostReturnString<T>(string uri, T obj)
        {
            //AddTokenHeader();
            var response = await httpClient.PostAsJsonAsync(GetUrl(uri), obj);
            await HandleError(response);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task InvokePut<T>(string uri, T obj)
        {
            //AddTokenHeader();
            var response = await httpClient.PutAsJsonAsync(GetUrl(uri), obj);
            await HandleError(response);
        }

        public async Task InvokeDelete(string uri)
        {
            //AddTokenHeader();
            var response = await httpClient.DeleteAsync(GetUrl(uri));
            await HandleError(response);
        }

        private string GetUrl(string uri)
        {
            if (baseUrl.EndsWith("/"))
                return $"{baseUrl}{uri}";
            else
                return $"{baseUrl}/{uri}";
        }

        private async Task HandleError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {                
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(error);
            }
        }

        /*private async Task AddTokenHeader()
        {
            if (tokenRepository != null && !string.IsNullOrWhiteSpace(await tokenRepository.GetToken()))
            {
                httpClient.DefaultRequestHeaders.Remove("TokenHeader");
                httpClient.DefaultRequestHeaders.Add("TokenHeader", await tokenRepository.GetToken());            
            }
        }*/
    }
}