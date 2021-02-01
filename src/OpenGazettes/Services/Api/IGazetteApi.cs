using OpenGazettes.Models;
using Refit;
using System.Threading.Tasks;
using static OpenGazettes.Models.CollectionResponse;

namespace OpenGazettes.Services.Api
{
    public interface IGazetteApi
    {
        [Get("/index/gazette-index-latest.jsonlines")]
        Task<string> GetAll();

        [Get("/collections")]
        Task<CollectionResponse> GetCollections();

        [Get("/query")]
        Task<SearchResponse> QueryFacet(QueryRequest queryRequest);

        //Task<SearchResponse> QueryFacet([Body(BodySerializationMethod.UrlEncoded)] QueryRequest queryRequest);
    }
}