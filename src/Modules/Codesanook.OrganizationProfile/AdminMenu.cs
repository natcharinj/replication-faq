using System;
using System.Threading.Tasks;
using Codesanook.OrganizationProfile.Controllers;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using YesSql;
using OrchardCore.Mvc.Core.Utilities;


namespace Codesanook.OrganizationProfile
{
    public class AdminMenu : INavigationProvider
    {
        private readonly IStringLocalizer S;

        public AdminMenu(
            IStringLocalizer<AdminMenu> localizer 
        )
        {
            S = localizer;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            // We want to add our menus to the "admin" menu only.
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase)) return Task.CompletedTask;

            // Adding our menu items to the builder.
            // The builder represents the full admin menu tree.
            builder.Add(
                S["Configuration"], // No need for position for an existing menu
                configuration => configuration
                    .Add(
                        S["Settings"],
                        settings =>
                        {
                            // Naming for menu
                            AddActionMenu(settings, menuName: "Organization Profile", contentTypeName: "OrganizationProfile");
                        }
                    ) // End child menu 1
            );

            return Task.CompletedTask;
        }

        private NavigationBuilder AddActionMenu(
            NavigationBuilder builder,
            string menuName,
            string contentTypeName
        )
        {
            return builder.Add(
                S[menuName],
                S[menuName].PrefixPosition(),
                builder => builder.Action(
                    nameof(OrganizationProfileController.Edit),
                    typeof(OrganizationProfileController).ControllerName(),
                    new { area = "Codesanook.OrganizationProfile" }
                )
            );
        }
    }

}