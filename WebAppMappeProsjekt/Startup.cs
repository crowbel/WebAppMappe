using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAppMappeProsjekt.DAL;
using WebAppMappeProsjekt.Model;

namespace WebAppMappeProsjekt
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
            services.AddControllers();

            services.AddDbContext<RuteContext>(options => options.UseSqlite("Data source=Rute.db"));
            //services.AddDbContext<OrdreContext>(options => options.UseSqlite("Data source=Ordre.db"));

            services.AddScoped<IOrdreRepository, OrdreRepository>();
            services.AddScoped<IRuteRepository, RuteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddFile("Logs/WebAppLog.txt");
                DBInit.Initialize(app);
            }
            
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

   
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
