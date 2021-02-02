using Newtonsoft.Json;
using Refit;

namespace OpenGazettes.Models
{
    public class QueryRequest
    {
        [JsonProperty("facet")]
        [AliasAs("facet")]
        public string Facet { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty(PropertyName = "q")]
        [AliasAs("q")]
        public string Query { get; set; }

        [JsonProperty("snippet")]
        public int Snippet { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("filter:collection_id")]
        [AliasAs("filter:collection_id")]
        public int Filter { get; set; }
    }
}