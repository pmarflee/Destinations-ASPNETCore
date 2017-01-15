using System.Collections.Generic;
using System.IO;

using Destinations.Data.Entities;
using Microsoft.Extensions.Options;

namespace Destinations.Data
{
    public interface IFileReader
    {
        IEnumerable<Region> ReadAll();
    }
    public class FileReader : IFileReader
    {
        private readonly AppSettings _settings;

        public FileReader(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }
        public IEnumerable<Region> ReadAll()
        {
            var regions = new List<Region>();
            Region region = null;
            var data = File.ReadLines(_settings.DataPath);

            foreach (var line in data)
            {
                if (line.StartsWith("\t"))
                {                    
                    region.Countries.Add(new Country { Name = line.Trim() });
                }
                else
                {
                    region = new Region { Name = line };
                    regions.Add(region);                    
                }
            }

            return regions;            
        }
    }
}