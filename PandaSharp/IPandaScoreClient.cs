using PandaSharp.Utils;

namespace PandaSharp
{
    public interface IPandaScoreClient
    {
        Task<T?> Execute<T>(PandaRequest request);
        Task<T?> Execute<T>(string request);
    }
}
