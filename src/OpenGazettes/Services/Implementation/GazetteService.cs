using Newtonsoft.Json;
using OpenGazettes.Models;
using OpenGazettes.Services.Api;
using OpenGazettes.Services.Interfaces;
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenGazettes.Services.Implementation
{
    public class GazetteService : IGazetteService
    {
        #region Services
        readonly IGazetteApi _api;
        #endregion

        #region Constructor

        public GazetteService(IHttpService httpService)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            var settings = new RefitSettings(new NewtonsoftJsonContentSerializer());

            _api = RestService.For<IGazetteApi>(httpService?.Client, settings);
        }

        #endregion

        public async Task<List<GazetteGroup>> FilterByYears(GazetteResult gazette)
        {
            List<Models.GazetteGroup> grouped3 = new List<GazetteGroup>();
            var result = await All();

            var group4 = result.GroupBy(x => new { x.PublicationDate.Year })
                               .Select(x => new { x.Key.Year, Count = x.Count() })
                               .OrderByDescending(x => x.Year);

            foreach (var item in group4)
            {
                var yes = new GazetteGroup(item.Year.ToString(), item.Count, new List<GazetteMonths>());

                grouped3.Add(yes);
            }

            return grouped3;
        }

        public async Task<string> GetAll()
        {
            var results = await _api.GetAll();
            results = results.Insert(0, "[").Insert(results.Length, "]").Replace("\n", "").Replace("}{", "},{");
            return results;
        }

        public async Task<List<Gazette>> All()
        {
            var result = await GetAll();
            return JsonConvert.DeserializeObject<List<Gazette>>(result);
        }

        public async Task<CollectionResponse> GetAllCountries()
        {
            var result = await _api.GetCollections();
            return result;
        }

        public async Task<SearchResponse> FacetSearch(string facet, int collectionId)
        {
            var param = new QueryRequest
            {
                Facet = facet,
                Limit = 20,
                Offset = 0,
                Snippet = 140,
                Sort = "score",
                Filter = collectionId
            };
            var results = await _api.Query(param);
            return results;
        }

        public async Task<byte[]> DownloadPdf(string path)
        {
            HttpContent content = await _api.DownloadFile(path);
            byte[] bytes = await content.ReadAsByteArrayAsync();

            return bytes;
        }

        public async Task<SearchResponse> QuerySearch(string query)
        {
            var param = new QueryRequest
            {
                Facet = "entities",
                Limit = 20,
                Offset = 0,
                Query = query,
                Snippet = 140,
                Sort = "score"
            };
            var results = await _api.Query(param);
            return results;
        }
    }
}