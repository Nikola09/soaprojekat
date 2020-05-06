using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoService.Context;
using MongoService.Models;
using MongoService.Services;
using MongoService.Repositories;

namespace MongoService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ServerConfig();
            Configuration.Bind(config);
            var databaseContext = new DatabaseContext(config.MongoDB);

            var repo1 = new AmbientRepository(databaseContext);
            services.AddSingleton<AmbientRepository>(repo1);
            var repo2 = new ApiiRepository(databaseContext);
            services.AddSingleton<ApiiRepository>(repo2);
            var repo3 = new BatteryRepository(databaseContext);
            services.AddSingleton<BatteryRepository>(repo3);
            var repo4 = new LocationRepository(databaseContext);
            services.AddSingleton<LocationRepository>(repo4);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHostedService<RuleDbService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
