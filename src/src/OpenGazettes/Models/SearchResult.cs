using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGazettes.Models
{
    public class SearchResult
    {
        [JsonProperty("source_collection_id")]
        public long SourceCollectionId { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("countries")]
        public object[] Countries { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("source_url")]
        public Uri SourceUrl { get; set; }

        [JsonProperty("languages")]
        public string[] Languages { get; set; }

        [JsonProperty("records")]
        public Records Records { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("collection_id")]
        public long[] CollectionId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}