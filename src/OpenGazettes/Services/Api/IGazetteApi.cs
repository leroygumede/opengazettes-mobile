using OpenGazettes.Models;
using Refit;
using System.Net.Http;
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

        [Get("/query")]
        Task<HttpContent> DownloadFile(string path);
    }
}