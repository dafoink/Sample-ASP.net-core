using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using aspnetcoreapp.Repositories;
using aspnetcoreapp.Models;



namespace aspnetcoreapp
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                ;
            Configuration = builder.Build();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // app.Run(context =>
            // {
            //     return context.Response.WriteAsync("Hello from ASP.NET Core!");
            // });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

                // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["Production:SqliteConnectionString"];

            services.AddDbContext<DBContext>(options =>
                options.UseSqlite(connection)
            );

            services.AddMvc();
            services.AddScoped<IDBContextRepository, DBContextRepository>();

        }
    }
}