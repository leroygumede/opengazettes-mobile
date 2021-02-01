using Newtonsoft.Json;

namespace OpenGazettes.Models
{
    public class Records
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("results")]
        public object[] Results { get; set; }
    }
}