﻿using Newtonsoft.Json;

namespace OpenGazettes.Models
{
    public class CollectionsValue
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}