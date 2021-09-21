using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;
using OrchardCore.Navigation;
using OrchardCore.Data.Migration;
using OrchardCore.ContentManagement;
using ReplicationFaq.Theme.Drivers;
using ReplicationFaq.Theme.Models;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.Descriptors;

namespace ReplicationFaq.Theme
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INavigationProvider, BreadcrumbsMenu>();
            services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();
            services.AddScoped<IDataMigration, Migrations>();
            services.AddContentPart<BlockListPart>().UseDisplayDriver<BlockListPartDisplayDriver>();

            services.AddScoped<IShapeTableProvider, BlogShapeProvider>();

        }
    }
}