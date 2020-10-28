using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using web.Infrastructures.Extensions;

namespace web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabase(this.Configuration);
            services.AddJwtAuthentication(services.GetApplicationSettings(this.Configuration));
            services.AddApplicationServices();
            services.AddSwagger();
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              );
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c => c.SerializeAsV2 = true)
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "My App API V1");
                   c.RoutePrefix = string.Empty;
               });

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin()
                              .AllowAnyMethod()
                             .AllowAnyHeader())
               .UseAuthentication()
               .UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}