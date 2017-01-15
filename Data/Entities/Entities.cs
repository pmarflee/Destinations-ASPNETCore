using System.Collections.Generic;

namespace Destinations.Data.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Country> Countries { get; set; } = new List<Country>();
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}