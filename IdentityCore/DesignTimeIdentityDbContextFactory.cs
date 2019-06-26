using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Edura.WebUI.IdentityCore
{
    public class DesignTimeIdentityDbContextFactory : IDesignTimeDbContextFactory<ApplicationIdentityDbContext>
    {
        public ApplicationIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var builder = new DbContextOptionsBuilder<ApplicationIdentityDbContext>();
            var connectionstring = configuration.GetConnectionString("Identityed");
            builder.UseSqlServer(connectionstring);
            return new ApplicationIdentityDbContext(builder.Options);

        }
    }
}
