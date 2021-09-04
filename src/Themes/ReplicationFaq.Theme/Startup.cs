using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;
using OrchardCore.Navigation;

namespace ReplicationFaq.Theme
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INavigationProvider, BreadcrumbsMenu>();
            services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();
        }
    }
}