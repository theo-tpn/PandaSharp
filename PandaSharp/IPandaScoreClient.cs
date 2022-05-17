using PandaSharp.Entities;
using PandaSharp.Utils;

namespace PandaSharp
{
    public interface IPandaScoreClient
    {
        Task<List<Videogame>?> GetVideogames(string? query = null);
        Task<Videogame?> GetVideogame(int id);
        Task<Videogame?> GetVideogame(string slug);
        Task<List<League>?> GetLeagues(string? query = null);
        Task<League?> GetLeague(int id);
        Task<League?> GetLeague(string slug);
        Task<List<Match>?> GetMatchesByLeague(int id, TimeReference? timeRef = null, string? query = null);
        Task<List<Match>?> GetMatchesByLeague(string slug, TimeReference? timeRef = null, string? query = null);
        Task<List<Serie>?> GetSeriesByLeague(int id, string? query = null);
        Task<List<Serie>?> GetSeriesByLeague(string slug, string? query = null);
        Task<List<Tournament>?> GetTournamentsByLeague(int id, string? query = null);
        Task<List<Tournament>?> GetTournamentsByLeague(string slug, string? query = null);
        Task<List<Live>?> GetLives(string? query = null);
    }
}
