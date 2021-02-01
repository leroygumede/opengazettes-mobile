using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenGazettes.Models
{
    public class SearchResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("facets")]
        public Facets Facets { get; set; }

        [JsonProperty("results")]
        public List<SearchResult> Results { get; set; }

        [JsonProperty("next")]
        public object Next { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}