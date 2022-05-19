using PandaSharp.Utils;
using System.Text.Json;

namespace PandaSharp
{
    public class PandaScoreClient : IPandaScoreClient
    {
        private readonly HttpClient _httpClient;

        public PandaScoreClient(HttpClient httpCient)
        {
            _httpClient = httpCient;
        }

        public async Task<T?> Execute<T>(PandaRequest request)
        {
            return await Execute<T>(request.ToString());
        }

        public async Task<T?> Execute<T>(string request)
        {
            var response = await _httpClient.GetAsync($"{request}");
            if (!response.IsSuccessStatusCode)
                return default;

            return JsonSerializer.Deserialize<T?>(await response.Content.ReadAsStringAsync());
        }
    }
}