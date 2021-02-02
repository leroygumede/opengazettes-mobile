using Newtonsoft.Json;
using OpenGazettes.Models;
using OpenGazettes.Services.Api;
using OpenGazettes.Services.Interfaces;
using Refit;
using System.Collections.Generic;
using System.Linq;
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
            _api = RestService.For<IGazetteApi>(httpService?.Client);
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
            // var res = JsonConvert.SerializeObject(results);

            // var mock = "[{\"archive_url\":
            // \"https://archive.opengazettes.org.za/archive/ZA-NW/2015/provincial-gazette-ZA-NW-vol-258-no-7533-dated-2015-09-08.pdf\",
            // \"original_uri\": null, \"unique_id\": \"provincial-gazette-ZA-NW-vol-258-no-7533\",
            // \"pagecount\": 4, \"publication_date\": \"2019-09-08\", \"publication_subtitle\":
            // null, \"issue_number\": 7533, \"language_edition\": null, \"volume_number\": \"258\",
            // \"jurisdiction_code\": \"ZA-NW\", \"special_issue\": null, \"archive_path\":
            // \"ZA-NW/2015/provincial-gazette-ZA-NW-vol-258-no-7533-dated-2015-09-08.pdf\",
            // \"jurisdiction_name\": \"North West\", \"publication_title\": \"Provincial Gazette\",
            // \"issue_title\": \"North West Provincial Gazette vol 258 no 7533 dated 08 September 2015\"},{\"archive_url\":

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