using Punjab_Ornaments.Resources.Constant;
using System.Net;
using System.Text.Json;
using static SQLite.SQLite3;

namespace Punjab_Ornaments.Infrastructure.RestService
{
    public class RestService : IRestService
    {

        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

        public RestService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public Task DeleteAsync(string uri, string token = "")
        {
            throw new NotImplementedException();
        }

        public async Task<TResult> GetAsync<TResult>(string uri, string token = "", Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var content = new StringContent("", null, "text/plain");
            request.Content = content;
            var response = await _client.SendAsync(request);
            var serialized = HandleResponse(response);
            var result = JsonSerializer.Deserialize<TResult>(serialized.Result, _serializerOptions);
            return result;
        }

        public async Task<TResult> PutAsync<TResult>(string url, TResult data, string token = "", Dictionary<string, string> headers = null)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, url);
                string jsonserilozer = System.Text.Json.JsonSerializer.Serialize(data, _serializerOptions);
                var content = new StringContent(jsonserilozer, null, "application/json");
                request.Content = content;
                var response = await _client.SendAsync(request);
                var serialized = HandleResponse(response);
                TResult result = await Task.Run(() => JsonSerializer.Deserialize<TResult>(serialized.Result, _serializerOptions));

                return result;
            }
            catch (Exception ex)
            {
            }

            return data;

        }

        public async Task<TResult> PutAsync<TResult, TInput>(string uri, TInput data, string token = "", Dictionary<string, string> headers = null)
        {
            //var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            var content = new StringContent("", null, "text/plain");
            request.Content = content;
            var response = await _client.SendAsync(request);
            var serialized = HandleResponse(response);
            TResult result = await Task.Run(() => JsonSerializer.Deserialize<TResult>(serialized.Result, _serializerOptions));

            return result;
        }

        public async Task<TResponse> PostAsync<TInput, TResponse>(string uri, TInput data, TResponse response, string token = "", Dictionary<string, string> headers = null)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, uri);
                string jsonSerializer = System.Text.Json.JsonSerializer.Serialize(data, _serializerOptions);
                var content = new StringContent(jsonSerializer, null, "application/json");
                request.Content = content;
                var domainResponse = await _client.SendAsync(request);
                var serialized = await HandleResponse(domainResponse);
                TResponse result = await Task.Run(() => JsonSerializer.Deserialize<TResponse>(serialized, _serializerOptions));
                response = result;
            }
            catch (Exception ex)
            {
                Preferences.Set(PreferenceConstant.LastError, ex.Message);
            }
            return response;
        }

        public static HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        private static async Task<string> HandleResponse(HttpResponseMessage response)
        {
            try
            {
                if(response.StatusCode == HttpStatusCode.OK) 
                {
                    response.EnsureSuccessStatusCode();
                }
                if (response.StatusCode == HttpStatusCode.Unauthorized) 
                {
                }
                if(response.StatusCode == HttpStatusCode.NotFound)
                {
                }
                if(response.StatusCode == HttpStatusCode.BadRequest) {
                }
                {
                }

                var abc = await response.Content.ReadAsStringAsync();
                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }

            return null;
        }
    }
}
