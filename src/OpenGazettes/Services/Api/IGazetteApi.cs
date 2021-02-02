using OpenGazettes.Models;
using Refit;
using System.Threading.Tasks;

namespace OpenGazettes.Services.Api
{
    public interface IGazetteApi
    {
        [Get("/index/gazette-index-latest.jsonlines")]
        Task<string> GetAll();

        [Get("/collections")]
        Task<CollectionResponse> GetCollections();

        [Get("/query")]
        Task<SearchResponse> Query(QueryRequest queryRequest);
    }
}