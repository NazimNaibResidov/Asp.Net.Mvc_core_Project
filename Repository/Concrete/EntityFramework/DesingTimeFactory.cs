using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class DesingTimeFactory : IDesignTimeDbContextFactory<EduraContext>
    {
        public EduraContext CreateDbContext(string[] args)
        {
            IConfigurationRoot root = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var builder = new DbContextOptionsBuilder<EduraContext>();
            var connectionString = root.GetConnectionString("Edure");
            builder.UseSqlServer(connectionString);
            return new EduraContext(builder.Options);
        }
    }
}
