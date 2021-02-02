using Newtonsoft.Json;

namespace OpenGazettes.Models
{
    public class Facets
    {
        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        [JsonProperty("collections")]
        public Collections Collections { get; set; }

        [JsonProperty("publication_date")]
        public PublicationDate PublicationDate { get; set; }

        [JsonProperty("phone_numbers")]
        public PublicationDate PhoneNumbers { get; set; }

        [JsonProperty("emails")]
        public PublicationDate EmailAddress { get; set; }

        [JsonProperty("domains")]
        public PublicationDate Domains { get; set; }
    }
}