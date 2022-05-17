using PandaSharp.Entities;
using PandaSharp.Utils;
using System.Text;
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
            if (!response.IsSuccessStatusCode)
                return null;

            return JsonSerializer.Deserialize<List<Videogame>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Videogame?> GetVideogame(int id)
        {
            var response = await _httpClient.GetAsync($"videogames/{id}");
            if (!response.IsSuccessStatusCode)
                return null;

            return JsonSerializer.Deserialize<Videogame>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Videogame?> GetVideogame(string slug)
        {
            var response = await _httpClient.GetAsync($"videogames/{slug}");
            if (!response.IsSuccessStatusCode)
                return null;

            return JsonSerializer.Deserialize<Videogame>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<League>?> GetLeagues(string? query = null)
        {
            var response = await _httpClient.GetAsync($"leagues{(query == null ? "" : $"?{query}")}");
            if (!response.IsSuccessStatusCode)
                return null;

            return JsonSerializer.Deserialize<List<League>>(await response.Content.ReadAsStringAsync());
        }
        public async Task<League?> GetLeague(int id)
        {
            var response = await _httpClient.GetAsync($"leagues/{id}");
            if (!response.IsSuccessStatusCode)
                return null;

            return JsonSerializer.Deserialize<League>(await response.Content.ReadAsStringAsync());
        }
        public async Task<League?> GetLeague(string slug)
        {
            var response = await _httpClient.GetAsync($"leagues/{slug}");
            if (!response.IsSuccessStatusCode)
                return null;

            return JsonSerializer.Deserialize<League>(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<Match>?> GetMatchesByLeague(int id, TimeReference? timeRef = null, string? query = null)
        {
            return await InnerGetMatchesByLeague(id, timeRef, query);
        }
        public async Task<List<Match>?> GetMatchesByLeague(string slug, TimeReference? timeRef = null, string? query = null)
        {
            return await InnerGetMatchesByLeague(slug, timeRef, query);
        }
        public async Task<List<Serie>?> GetSeriesByLeague(int id, string? query = null)
        {
            return await InnerGetSeriesByLeague(id, query);
        }
        public async Task<List<Serie>?> GetSeriesByLeague(string slug, string? query = null)
        {
            return await InnerGetSeriesByLeague(slug, query);
        }
        public async Task<List<Tournament>?> GetTournamentsByLeague(int id, string? query = null)
        {
            return await InnerGetTournamentsdByLeague(id, query);
        }
        public async Task<List<Tournament>?> GetTournamentsByLeague(string slug, string? query = null)
        {
            return await InnerGetTournamentsdByLeague(slug, query);
        }
        public async Task<List<Live>?> GetLives(string? query = null)
        {
            var response = await _httpClient.GetAsync($"lives{(query == null ? "" : $"?{query}")}");
            if (!response.IsSuccessStatusCode)
                return null;

            var c = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Live>>(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<Match>?> GetMatches(TimeReference? timeRef = null, string? query = null)
        {
            var sb = new StringBuilder();
            sb.Append("matches");
            switch (timeRef)
            {
                case TimeReference.Past:
                    sb.Append("/past");
                    break;
                case TimeReference.Running:
                    sb.Append("/running");
                    break;
                case TimeReference.Upcoming:
                    sb.Append("/upcoming");
                    break;
            }

            var response = await _httpClient.GetAsync($"{sb}{(query == null ? "" : $"?{query}")}");
            if (!response.IsSuccessStatusCode)
                return null;

            return JsonSerializer.Deserialize<List<Match>>(await response.Content.ReadAsStringAsync());
        }
        public async Task<Match?> GetMatch(int id, string? query = null)
        {
            return await InnertGetMatch(id, query);
        }
        public async Task<Match?> GetMatch(string slug, string? query = null)
        {
            return await InnertGetMatch(slug, query);
        }

        private async Task<List<Match>?> InnerGetMatchesByLeague(object by, TimeReference? timeRef = null, string? query = null)
        {
            var sb = new StringBuilder();
            sb.Append("leagues").Append($"/{by}").Append("/matches");
            switch (timeRef)
            {
                case TimeReference.Past:
                    sb.Append("/past");
                    break;
                case TimeReference.Running:
                    sb.Append("/running");
                    break;
                case TimeReference.Upcoming:
                    sb.Append("/upcoming");
                    break;
            }
            var response = await _httpClient.GetAsync($"{sb}{(query == null ? "" : $"?{query}")}");
            if (!response.IsSuccessStatusCode)
                return null;

            return JsonSerializer.Deserialize<List<Match>?>(await response.Content.ReadAsStringAsync());
        }
        private async Task<List<Serie>?> InnerGetSeriesByLeague(object by, string? query = null)
        {
            var response = await _httpClient.GetAsync($"leagues/{by}/series{(query == null ? "" : $"?{query}")}");

            if (!response.IsSuccessStatusCode)
                return null;

            return JsonSerializer.Deserialize<List<Serie>?>(await response.Content.ReadAsStringAsync());
        }
        private async Task<List<Tournament>?> InnerGetTournamentsdByLeague(object by, string? query = null)
        {
            var response = await _httpClient.GetAsync($"leagues/{by}/tournaments{(query == null ? "" : $"?{query}")}");

            if (!response.IsSuccessStatusCode)
                return null;

            return JsonSerializer.Deserialize<List<Tournament>?>(await response.Content.ReadAsStringAsync());
        }
        private async Task<Match?> InnertGetMatch(object by, string? query = null)
        {
            var response = await _httpClient.GetAsync($"matches/{by}{(query == null ? "" : $"?{query}")}");

            if (!response.IsSuccessStatusCode)
                return null;

            return JsonSerializer.Deserialize<Match?>(await response.Content.ReadAsStringAsync());
        }
    }
}
