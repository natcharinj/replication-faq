using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ReplicationFaq.Cms
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // cause issue in admin page
            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;
                // options.LowercaseUrls = true;
            });

            services.AddOrchardCms();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseOrchardCore();
        }
    }
}
