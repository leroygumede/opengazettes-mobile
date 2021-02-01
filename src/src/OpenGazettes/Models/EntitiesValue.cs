using Newtonsoft.Json;

namespace OpenGazettes.Models
{
    public class EntitiesValue
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("collection_id")]
        public long[] CollectionId { get; set; }

        [JsonProperty("$schema")]
        public string Schema { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}