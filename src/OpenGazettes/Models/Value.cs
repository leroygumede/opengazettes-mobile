using Newtonsoft.Json;
using System;

namespace OpenGazettes.Models
{
    public class Value
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("key_as_string")]
        public DateTimeOffset KeyAsString { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}