using System.Collections.Generic;

namespace OpenGazettes.Models
{
    public class GazetteMonths
    {
        public string Label { get; set; }
        public int Count { get; set; }
    }

    public class GazetteGroup : List<GazetteMonths>
    {
        public string Name { get; private set; }
        public int Count { get; private set; }

        public GazetteGroup(string name, int count, List<GazetteMonths> gazettemonths) : base(gazettemonths)
        {
            Name = name;
            Count = count;
        }
    }
}