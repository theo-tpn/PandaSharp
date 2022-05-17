using PandaSharp.Entities;
using PandaSharp.Utils;

namespace PandaSharp
{
    public interface IPandaScoreClient
    {
        Task<T?> Execute<T>(PandaRequest request, PandaQuery? query = null);
        Task<T?> Execute<T>(string request, string? query = null);
    }
}
