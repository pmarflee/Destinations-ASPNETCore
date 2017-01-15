using System.Collections.Generic;

namespace Destinations.Models
{
    public class ViewModel
    {
        public IEnumerable<Region> Regions { get; set; }
    }

    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<RegionColumn> Columns { get; set; }
    }

    public class RegionColumn
    {
        public int Index { get; set; }
        public IEnumerable<Country> Countries { get; set; }

        public bool IsLastColumn { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }
    }
}