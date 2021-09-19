using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using OrchardCore.Autoroute.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Taxonomies.Models;
using OrchardCore.Taxonomies.Settings;
using OrchardCore.Title.Models;
using ReplicationFaq.Theme.Models;
using YesSql;

namespace ReplicationFaq.Theme.Drivers
{
    public class BlockListPartDisplayDriver : ContentPartDisplayDriver<BlockListPart>
    {
        private readonly ISession _session;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IContentManager _contentManager;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;

        public BlockListPartDisplayDriver(
            ISession session,
            IContentDefinitionManager contentDefinitionManager,
            IContentManager contentManager,
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor
        )
        {
            _session = session;
            _contentDefinitionManager = contentDefinitionManager;
            _contentManager = contentManager;
            _urlHelperFactory = urlHelperFactory;
            this._actionContextAccessor = actionContextAccessor;
        }

        public override async Task<IDisplayResult> DisplayAsync(BlockListPart part, BuildPartDisplayContext context)
        {
            var actionContext = _actionContextAccessor.ActionContext;
            var urlHelper = _urlHelperFactory.GetUrlHelper(actionContext);
            var blogPostType = _contentDefinitionManager.GetTypeDefinition("BlogPost");

            var typePart = blogPostType.Parts.FirstOrDefault(x => string.Equals(x.Name, blogPostType.Name, StringComparison.OrdinalIgnoreCase));
            var categoryField = typePart.PartDefinition.Fields.Single(f => f.Name == "Category");
            var settings = categoryField.GetSettings<TaxonomyFieldSettings>();
            var taxonomyContentItem = await _contentManager.GetAsync(settings.TaxonomyContentItemId, VersionOptions.Latest);

            var termes = taxonomyContentItem.As<TaxonomyPart>().Terms;
            part.Items = termes.Select(t =>
            {
                var autoroutePart = t.As<AutoroutePart>();
                var titlepart = t.As<TitlePart>();
                return new BlockListItem()
                {
                    Name = titlepart.Title,
                    Url = urlHelper.Content(autoroutePart.Path)
                };
            }).ToArray();

            return View(nameof(BlockListPart), part).Location("Detail", "Content:10");
        }
    }
}