using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AssetManager.Data;
using AssetManager.Config;
using AssetManager.Utils;

namespace AssetManager {

    public class Startup {        
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<AssetManagerDbContext>(
                options => options.UseNpgsql(
                    Configuration.GetConnectionString("AssetManagerDbContext")
                )
            );
            services.ConfigureRepositories();
            services.ConfigureModelServices();
            
            services.AddRazorPages().AddMvcOptions(options => {
                options.ModelBinderProviders.Insert(0, new EnumerationBinderProvider());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles(); 

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();

                endpoints.MapGet("/hi", async context => {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
