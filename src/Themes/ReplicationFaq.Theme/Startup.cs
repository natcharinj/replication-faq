using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace ReplicationFaq.Theme
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services) =>
        services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();
    }
}