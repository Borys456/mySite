using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MyStorageSite.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Proxies;

namespace MyStorageSite
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
            //string connection = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<StorageContext>(o => o.UseSqlServer(connection));

            services.AddDbContext<StorageContext>(o => o.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddRazorPages();
            services.AddMvc();
            //services.AddEntityFrameworkSqlServer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();

                //endpoints.MapControllerRoute(
                //    name:"default",
                //    pattern: "{controller=Home}/{action=AllProducts}/{id?}"
                //    );

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=AllOrders}/{id?}"
                //    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MainPage}/{action=_ViewStart}/{id?}"
                    );


            });
        }
    }
}
