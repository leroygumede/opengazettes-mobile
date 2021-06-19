using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenGazettes.Models
{
    public class CollectionResponse
    {
        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("prev_url")]
        public object PrevUrl { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("next_url")]
        public object NextUrl { get; set; }

        [JsonProperty("facets")]
        public Facets Facets { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("results")]
        public List<GazetteResult> Results { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("pages")]
        public long Pages { get; set; }
    }
}