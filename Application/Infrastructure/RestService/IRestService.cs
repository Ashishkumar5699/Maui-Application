namespace Punjab_Ornaments.Infrastructure.RestService
{
    public interface IRestService
    {
        Task<TResult> GetAsync<TResult>(string uri, string token = "", Dictionary<string, string> headers = null);

        Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "", Dictionary<string, string> headers = null);

        Task<TResult> PutAsync<TResult, TInput>(string uri, TInput data, string token = "", Dictionary<string, string> headers = null);

        Task<TResponse> PostAsync<TInput, TResponse>(string uri, TInput data, TResponse response, string token = "", Dictionary<string, string> headers = null);

        Task DeleteAsync(string uri, string token = "");
    }
}
