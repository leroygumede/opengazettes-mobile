using OpenGazettes.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using static OpenGazettes.Models.CollectionResponse;

namespace OpenGazettes.Services.Interfaces
{
    public interface IGazetteService
    {
        Task<List<Gazette>> All();

        Task<CollectionResponse> GetAllCountries();

        Task<List<GazetteGroup>> FilterByYears(GazetteResult gazette);

        Task<SearchResponse> FacetSearch(string searchKey);
    }
}