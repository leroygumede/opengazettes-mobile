using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGazettes.Models
{
    public class GazetteResult
    {
        [JsonProperty("category")]
        public GazetteCategory Category { get; set; }

        [JsonProperty("foreign_id")]
        public string ForeignId { get; set; }

        [JsonProperty("managed")]
        public bool Managed { get; set; }

        [JsonProperty("api_url")]
        public Uri ApiUrl { get; set; }

        [JsonProperty("countries")]
        public List<string> Countries { get; set; }

        [JsonProperty("generate_entities")]
        public bool GenerateEntities { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        [JsonProperty("$schema")]
        public string Schema { get; set; }

        [JsonProperty("deleted_at")]
        public object DeletedAt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}