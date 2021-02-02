using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenGazettes.Models
{
    public class PublicationDate
    {
        [JsonProperty("values")]
        public List<Value> Values { get; set; }
    }
}