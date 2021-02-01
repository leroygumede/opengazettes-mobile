using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGazettes.Models
{
    public class Facets
    {
        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        [JsonProperty("collections")]
        public Collections Collections { get; set; }
    }
}