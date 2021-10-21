using System;
using Codesanook.OrganizationProfile.Controllers;
using Codesanook.OrganizationProfile.Drivers;
using Codesanook.OrganizationProfile.Handlers;
using Codesanook.OrganizationProfile.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Admin;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.Mvc.Core.Utilities;
using OrchardCore.Navigation;

namespace Codesanook.OrganizationProfile
{
    public class Startup : StartupBase
    {
        private readonly AdminOptions _adminOptions;
        public Startup(IOptions<AdminOptions> adminOptions) => _adminOptions = adminOptions.Value;

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<AddressPart>().UseDisplayDriver<AddressPartDisplayDriver>();
            services.AddContentPart<ContactInformationPart>().UseDisplayDriver<ContactInformationPartDisplayDriver>();
            services.AddContentPart<SocialNetworkPart>().UseDisplayDriver<SocialNetworkPartDisplayDriver>();

            services.AddScoped<IDataMigration, Migrations>();
            services.AddScoped<INavigationProvider, AdminMenu>();
            services.AddScoped<IContentDisplayHandler, ContentDisplayHandler>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "OrganizationProfileAdmin",
                areaName: "Codesanook.OrganizationProfile",
                pattern: _adminOptions.AdminUrlPrefix + "/OrganizationProfile/{action}",
                defaults: new
                {
                    controller = typeof(OrganizationProfileController).ControllerName(),
                    action = nameof(OrganizationProfileController.Edit)
                }
            );
        }
    }
}
