using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGazettes.Models
{
    public class Collections
    {
        [JsonProperty("values")]
        public CollectionsValue[] Values { get; set; }
    }
}