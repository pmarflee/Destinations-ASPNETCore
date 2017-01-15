using System.Linq;

namespace Destinations.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context, IFileReader reader)
        {
            context.Database.EnsureCreated();     

            if (context.Regions.Any()) return;

            context.Regions.AddRange(reader.ReadAll());            
            context.SaveChanges();
        }
    }
}