using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace IssueTracker.Data.Helpers
{
    public class MigrationContextFactory : IDbContextFactory<EFDbContext>
    {
        public EFDbContext Create(DbContextFactoryOptions options)
        {
            //should be only used for generating migration files
            var builder = new ConfigurationBuilder()
                .SetBasePath(options.ContentRootPath)
                .AddJsonFile("appsettings.development.json");           

            var configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<EFDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new EFDbContext(optionsBuilder.Options);
        }
    }
}
