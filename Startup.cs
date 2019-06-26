using Edura.WebUI.Helpers;
using Edura.WebUI.IdentityCore;
using Edura.WebUI.Repository.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Edura.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
     
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EduraContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Edure")));
           
            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Identityed")));
            Tools.LoadService(services);
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routers =>
            {
                routers.MapRoute(
                    name:"products",
                    template:"products/{category?}",
                    defaults:new {controller="Product",action="List"}
                    );
                routers.MapRoute(
                    
                    name:"default",
                    template:"{controller=Home}/{action=Index}/{id?}"
                    );
                routers.MapRoute(
                    name: "cart",
                    template: "{controller=Cart}/{action=Index}/{id?}");
            });
            SeedIdentity.CreateIdentityUsers(app.ApplicationServices, Configuration);
            SeedData.EnsurePopulated(app);
        }
    }
}
