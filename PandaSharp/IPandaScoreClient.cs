using PandaSharp.Entities;

namespace PandaSharp
{
    public interface IPandaScoreClient
    {
        Task<List<Videogame>?> GetVideogames(string? query = null);
        Task<Videogame?> GetVideogame(int id);
        Task<Videogame?> GetVideogame(string slug);
    }
}
