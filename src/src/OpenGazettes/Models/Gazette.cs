using Newtonsoft.Json;
using System;

namespace OpenGazettes.Models
{
    public class Gazette
    {
        [JsonProperty("archive_url")]
        public Uri ArchiveUrl { get; set; }

        [JsonProperty("original_uri")]
        public string OriginalUri { get; set; }

        [JsonProperty("unique_id")]
        public string UniqueId { get; set; }

        [JsonProperty("pagecount")]
        public long Pagecount { get; set; }

        [JsonProperty("publication_date")]
        public DateTimeOffset PublicationDate { get; set; }

        [JsonProperty("publication_subtitle")]
        public string PublicationSubtitle { get; set; }

        [JsonProperty("issue_number")]
        public long IssueNumber { get; set; }

        [JsonProperty("language_edition")]
        public string LanguageEdition { get; set; }

        [JsonProperty("volume_number")]
        public string VolumeNumber { get; set; }

        [JsonProperty("jurisdiction_code")]
        public string JurisdictionCode { get; set; }

        [JsonProperty("special_issue")]
        public string SpecialIssue { get; set; }

        [JsonProperty("archive_path")]
        public string ArchivePath { get; set; }

        [JsonProperty("jurisdiction_name")]
        public string JurisdictionName { get; set; }

        [JsonProperty("publication_title")]
        public string PublicationTitle { get; set; }

        [JsonProperty("issue_title")]
        public string IssueTitle { get; set; }
    }
}