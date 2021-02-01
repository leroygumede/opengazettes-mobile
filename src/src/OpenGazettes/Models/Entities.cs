using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGazettes.Models
{
    public class Entities
    {
        [JsonProperty("values")]
        public EntitiesValue[] Values { get; set; }
    }
}