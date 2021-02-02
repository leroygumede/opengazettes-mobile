using OpenGazettes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenGazettes.Services.Interfaces
{
    public interface IGazetteService
    {
        Task<List<Gazette>> All();

        Task<CollectionResponse> GetAllCountries();

        Task<List<GazetteGroup>> FilterByYears(GazetteResult gazette);

        Task<SearchResponse> FacetSearch(string facet, int collectionId);

        Task<SearchResponse> QuerySearch(string query);
    }
}