using Alg.Core.Models;
using Alg.Core.Repositories;
using Alg.Core.Services;
using Alg.Data;
using Alg.Data.Repositories;
using Alg.Services.Factories;
using Alg.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Alg.API
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
            services.AddDatabase("sqlserver", Configuration.GetConnectionString("DefaultConnection"))
                .AddControllers();

            services.AddTransient<IFileContext, FileContext>();
            services.AddTransient<DataFactory>();
            services.AddTransient<IDbRepository<Item>, DbRepository>();
            services.AddTransient<IFileRepository, FileRepository>();

            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IDbService, DbService>();
            services.AddTransient<IEntryService, EntryService>();

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}