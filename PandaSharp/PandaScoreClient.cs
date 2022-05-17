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

        public async Task<T?> Execute<T>(PandaRequest request, PandaQuery? query = null)
        {
            return await Execute<T>(request.ToString(), query?.ToString());
        }

        public async Task<T?> Execute<T>(string request, string? query = null)
        {
            var response = await _httpClient.GetAsync($"{request}{(query == null ? "" : $"?{query}")}");
            if (!response.IsSuccessStatusCode)
                return default;

            return JsonSerializer.Deserialize<T?>(await response.Content.ReadAsStringAsync());
        }
    }
}