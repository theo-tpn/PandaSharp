using PandaSharp.Entities;
using System.Net.Http.Headers;
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

        public async Task<List<Videogame>?> GetVideogames(string? query = null)
        {
            var response = await _httpClient.GetAsync($"videogames{(query == null ? "" : $"?{query}")}");
            if(response == null)
                return null;

            return JsonSerializer.Deserialize<List<Videogame>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Videogame?> GetVideogame(int id)
        {
            var response = await _httpClient.GetAsync($"videogames/{id}");
            if (response == null)
                return null;

            return JsonSerializer.Deserialize<Videogame>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Videogame?> GetVideogame(string slug)
        {
            var response = await _httpClient.GetAsync($"videogames/{slug}");
            if (response == null)
                return null;

            return JsonSerializer.Deserialize<Videogame>(await response.Content.ReadAsStringAsync());
        }
    }
}
