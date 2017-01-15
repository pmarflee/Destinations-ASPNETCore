using System.Linq;
using System.Collections.Generic;
using System;
using Destinations.Data;
using Microsoft.EntityFrameworkCore;

namespace Destinations.Models
{
    public interface IViewModelFactory
    {
        ViewModel Create();
    }

    public class ViewModelFactory : IViewModelFactory
    {
        private readonly DataContext _dataContext;

        public ViewModelFactory(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public ViewModel Create()
        {
            var regions = _dataContext.Regions
              .Include(region => region.Countries)
              .ToList();
              
            return new ViewModel
            {
                Regions = CreateRegions(regions)
            };
        }

        private IEnumerable<Region> CreateRegions(IEnumerable<Data.Entities.Region> regions)
        {
            return regions.Select(CreateRegion);
        }

        private Region CreateRegion(Data.Entities.Region region)
        {
            return new Region
            {
                Id = region.Id,
                Name = region.Name,
                Columns = CreateColumns(region.Countries)
            };
        }

        private IEnumerable<RegionColumn> CreateColumns(IEnumerable<Data.Entities.Country> countries)
        {
            var groups = countries
              .Select((country, i) => new { Country = country, Index = i })
              .GroupBy(pair => pair.Index % 6);

            return groups.Select(g => new RegionColumn
              {
                  Index = g.Key,
                  Countries = g.Select(pair => CreateCountry(pair.Country)),
                  IsLastColumn = g.Key == groups.Count() - 1
              });
        }

        private Country CreateCountry(Data.Entities.Country country)
        {
            return new Country
            {
                Id = country.Id,
                Name = country.Name,
                Link = country.Name.Replace(' ', '-').Replace("&", "and")
            };
        }
    }
}