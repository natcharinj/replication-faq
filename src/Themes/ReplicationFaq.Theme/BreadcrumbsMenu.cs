using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace ReplicationFaq.Theme
{
    public class BreadcrumbsMenu : INavigationProvider
    {
        private readonly IStringLocalizer S;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BreadcrumbsMenu(IStringLocalizer<BreadcrumbsMenu> localizer, IHttpContextAccessor httpContextAccessor)
        {
            S = localizer;
            _httpContextAccessor = httpContextAccessor;
        }


        // /OrchardCore/src/OrchardCore.Modules/OrchardCore.Navigation/NavigationShapes.cs
        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            // https://codesandbox.io/s/great-ellis-4d0lc?file=/src/Breadcrumbs.jsx:839-846
            if (!string.Equals(name, "breadcrumbs", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            var paths = new List<string>() { "" };
            var requestPath = _httpContextAccessor.HttpContext.Request.Path.Value;
            paths.AddRange(requestPath.Split('/', StringSplitOptions.RemoveEmptyEntries));

            for (var index = 0; index < paths.Count; index++)
            {
                var isFirstPath = index == 0;
                var caption = isFirstPath ? "Home" : paths[index];
                var url = isFirstPath ? "/" : string.Join('/', paths.Take(index + 1));

                var isLastPath = index == paths.Count - 1;
                var cssClasses = isLastPath ? new[] { "-active" } : Array.Empty<string>();

                builder.Add(
                    S[caption],
                    index.ToString(),
                    builder => builder.Url(url),
                    cssClasses
                );
            }

            return Task.CompletedTask;
        }
    }
}